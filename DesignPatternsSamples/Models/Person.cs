using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Models
{
    public class Person
    {
        public int Id { get; set; }

        [ColumnProp("nam")]
        public string? Name { get; set; }

        [ColumnProp("ag")]
        public int Age { get; set; }

        public string? Details { get;set; }

        [ColumnProp("isdel")]
        public bool IsDeleted { get; set; }
    }

    public class Builder
    {
        public static DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("nam");
            dt.Columns.Add("Id");
            dt.Columns.Add("ag");
            dt.Columns.Add("details");
            dt.Columns.Add("isdel");

            DataRow row = dt.NewRow();
            row["nam"] = "ABC";
            row["id"] = 1;
            row["ag"] = 25;
            row["details"] = "sample1";
            row["isdel"] = true;

            DataRow row1 = dt.NewRow();
            row1["nam"] = "EDF";
            row1["id"] = 2;
            row1["ag"] = 28;
            row1["details"] = "sample2";
            row1["isdel"] = false;

            dt.Rows.Add(row);
            dt.Rows.Add(row1);

            return dt;
        }
    }
}
