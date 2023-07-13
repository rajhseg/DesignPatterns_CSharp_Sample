using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatternsSamples
{
    internal class ObjectTableMapping
    {
        public string ObjectPropertyName { get; set; }
        
        public string TableColumnName { get; set; }
    }

    public static class DataTableModelBinder
    {
        public static IEnumerable<T> Bind<T>(DataTable table) where T : class, new()
        {
            List<T> list = new List<T>();
            List<ObjectTableMapping> columnsPresent = new List<ObjectTableMapping>();

            var props = typeof(T).GetProperties();
            var attr = typeof(T).GetProperties().SelectMany(x=>x.GetCustomAttributes(typeof(ColumnProp)));

            foreach (DataColumn item in table.Columns)
            {
               var property = props.FirstOrDefault(x => x.Name.ToLower() == item.ColumnName.ToLower());
                if (property != null)
                {
                    columnsPresent.Add(new ObjectTableMapping { ObjectPropertyName = property.Name, TableColumnName = item.ColumnName });
                }
                else
                {
                    var colattr = attr?.FirstOrDefault(x => ((ColumnProp)x).Name.ToLower() == item.ColumnName.ToLower());
                    if (colattr != null)
                    {
                        columnsPresent.Add(new ObjectTableMapping { 
                            ObjectPropertyName =((ColumnProp)colattr).PropertyName, 
                            TableColumnName = ((ColumnProp)colattr).Name
                        });                       
                    }
                }
            }
           
            foreach (DataRow item in table.Rows)
            {
                T obj = new T();

                foreach (ObjectTableMapping key in columnsPresent)
                {
                    var pro = obj.GetType().GetProperty(key.ObjectPropertyName);                    
                    Type typ = pro.PropertyType;                    

                    if (item[key.TableColumnName] !=null && typ!=null)
                    {
                        if (item[key.TableColumnName] != DBNull.Value)
                        {
                            var value = Convert.ChangeType(item[key.TableColumnName], typ);
                            pro?.SetValue(obj, value);
                        }
                        else
                        {
                            var value = GetDefault(typ);
                            pro?.SetValue(obj, value);
                        }
                    }
                }

                list.Add(obj);
            }

            return list;
        }

        public static DataTable ToDatatable<T>(this IEnumerable<T> values) where T: class, new()
        {
            DataTable dt = new DataTable();

            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name);
            }


            foreach (var item in values)
            {
                var row = dt.NewRow();
                
                foreach (DataColumn col in dt.Columns)
                {
                    var _prop = item.GetType().GetProperty(col.ColumnName);
                    if(_prop != null)
                    {
                        var value = _prop.GetValue(item);
                        row[col.ColumnName] = value != null ? value : DBNull.Value;
                    }
                } 
                
                dt.Rows.Add(row);
            }

            return dt;
        }

        public static T? CloneObject<T>(this T obj) where T:class, new()
        {
            if (obj == null)
                return default;

            T newObj = new T();
            var props = typeof(T).GetProperties();

            foreach (var item in props)
            {
                var newProp = newObj.GetType().GetProperty(item.Name);

                if (item.CanWrite && newProp!=null)
                {                  
                    if (!item.PropertyType.Namespace.StartsWith("System"))
                    {
                        var customObj = item.GetValue(obj);
                        Type propType = item.PropertyType;
                        object? subObj = CastAndClone(customObj, propType);
                        newProp.SetValue(newObj, subObj);
                    }
                    else
                    {
                        if (item.PropertyType.GetInterfaces().Contains(typeof(System.Collections.IEnumerable)) && item.PropertyType.FullName != "System.String")
                        {
                            var colType = item.PropertyType.GetGenericArguments()[0];

                            if (colType.IsValueType || colType.IsEnum || colType.FullName == "System.String")
                            {                                
                                dynamic collection = item.GetValue(obj, null);
                                IList<dynamic> list = new List<dynamic>();
                                                                    
                                foreach (var singleItem in collection)
                                {
                                    list.Add(singleItem);
                                }

                                var castList = item.PropertyType.Name.Contains("Collection") ? 
                                    CastCollectionObj(colType, list) 
                                    :  CastListObj(colType, list);
                                
                                newProp.SetValue(newObj, castList, null);
                            }
                            else
                            {
                                IEnumerable<dynamic>? collection = item.GetValue(obj, null) as IEnumerable<dynamic>;
                                IList<dynamic> list = new List<dynamic>();
                                Type propType = collection.First().GetType();

                                foreach (var singleItem in collection)
                                {
                                    object? subobj = CastAndClone(singleItem, propType);
                                    list.Add(subobj);
                                }

                                var castList = item.PropertyType.Name.Contains("Collection") ?
                                    CastCollectionObj(propType, list)
                                    : CastListObj(propType, list);

                                newProp.SetValue(newObj, castList);
                            }
                        }
                        else
                        {
                            newProp.SetValue(newObj, item.GetValue(obj));
                        }
                    }                                      
                }
            }

            return newObj;
        }

        public static V Map<U,V>(U item) where V : class, new() 
            where U: class, new()
        {
            V obj = new V();
            var props = typeof(U).GetProperties();
            return obj;
        }

        private static object? CastAndClone(object? customObj, Type propType)
        {
            var baseMethod = typeof(DataTableModelBinder).GetMethod(nameof(DataTableModelBinder.CloneObject));
            var genericMethod = baseMethod.MakeGenericMethod(propType);
            var subObj = genericMethod.Invoke(customObj, new[] { customObj });
            return subObj;
        }

        private static object? CastListObj<U>(Type objTyp, IEnumerable<U> list) where U: class
        {
            var IListRef = typeof(List<>);
            var obj = CastEnumerableObj(objTyp, list, IListRef);
            return obj;
        }

        private static object? CastCollectionObj<U>(Type objTyp, IEnumerable<U> list) where U : class
        {
            var ICollectionRef = typeof(Collection<>);
            var obj = CastEnumerableObj(objTyp, list, ICollectionRef);
            return obj;
        }

        private static object? CastEnumerableObj<U>(Type objTyp, IEnumerable<U> list, Type t) where U : class
        {
            Type[] Param = { objTyp };
            object result = Activator.CreateInstance(t.MakeGenericType(Param));

            foreach (var item in list)
            {
                result.GetType().GetMethod("Add").Invoke(result, new[] { item });
            }

            return result;
        }

        private static object GetDefault(Type typ)
        {
            if (typ.IsValueType)
            {
                return Activator.CreateInstance(typ);
            }

            return null;
        }
    }
}
