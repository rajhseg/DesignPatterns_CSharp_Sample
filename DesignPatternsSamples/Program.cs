// See https://aka.ms/new-console-template for more information
using DesignPatternsSamples;
using DesignPatternsSamples.Behaviour;
using DesignPatternsSamples.Creational;
using DesignPatternsSamples.Models;
using DesignPatternsSamples.Structural;
using System.Collections.ObjectModel;
using System.Data;
using PersonModel = DesignPatternsSamples.Models.Person;

int matCount = 0;
Combination combination = new Combination();
combination.OnMatching += Combination_OnMatching;

combination.Permutation("ABC");

void Combination_OnMatching(object sender, string match)
{
    matCount++;
    Console.WriteLine(match);
}

Console.WriteLine($"Total combination {matCount}");
var dt = Builder.GetData();
IEnumerable<PersonModel> listPersons = DataTableModelBinder.Bind<PersonModel>(dt);
DataTable table1 = listPersons.ToDatatable();
PersonModel mod = listPersons.First();
Collection<string> names = new Collection<string>();
names.Add("d");
names.Add("l");

Collection<Book> writebooks = new Collection<Book>();
writebooks.Add(new Book { BookId = 4, Name = "T" });

Emp per1 = new Emp
{
    Id = 1,
    Name = "a",
    IsDeleted = true,
    Department = new Dep { Name = "E", DepId = 2 },
    Books = new List<Book> { new Book { BookId = 1, Name = "C" }, new Book { BookId = 2, Name = "C++" } },
    Guids = new List<Guid> { Guid.NewGuid() },
    Samples = names,
    WrittenBooks = writebooks
};

Emp? per2 = per1.CloneObject();

per1.Guids.Add(Guid.NewGuid());
per1.Name = "f";
per1.Id = 2;
per1.IsDeleted = false;
per1.Department.Name = "F";
per1.Books.Add(new Book { BookId = 3, Name = "B" });
per1.Samples.Add("vvv");
per1.WrittenBooks.Add(new Book { BookId = 6, Name = "Y" });

var cloneObject = mod.CloneObject();


ObjectTesting testing = new ObjectTesting() { Id = 1 };
ObjectTesting testing1 = new ObjectTesting() { Id = 2 };

ObjectTesting t3 = testing + testing1;


Rup tenrup = new Rup(10);
Eu eu1 = tenrup;
SMoney sm1 = (SMoney)tenrup;

Rup r1 = eu1;

AsyncPrograms asyncPro = new AsyncPrograms();
List<Thread> threads = new List<Thread>();


for (int i = 0; i < 10000; i++)
{
    Thread th = new Thread(() => { asyncPro.IncNum(); });
    threads.Add(th);
    ////th.Start();
}

List<Task> tasks = new List<Task>();

for (int i = 0; i < 10000; i++)
{
    tasks.Add(asyncPro.DecNum());
}

await Task.WhenAll(tasks);

////Parallel.ForEach(threads, t => t.Start());

Console.ReadLine();

if (testing == testing1)
{
    Console.WriteLine("Equal");
}

EventsRegisterr reg1 = new EventsRegisterr();
reg1.Test();

Console.WriteLine("Hello, World!");

/* Singleton Pattern */
List<Singleton> single = new List<Singleton>();

ParallelOptions parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 5 };
int[] nums = new int[] { 1, 2, 3, 4, 5 };

Parallel.ForEachAsync(nums, parallelOptions, async (x, token) =>
{
    await Task.Run(() => { single.Add(Singleton.Instance()); });
}).GetAwaiter().GetResult();

Console.WriteLine("\nSingleton pattern");
Console.WriteLine("************************");

foreach (var item in single)
{
    Console.WriteLine(item.GetHashCode());
}

/* Factory Method */
Console.WriteLine("\nFactory method pattern");
Console.WriteLine("************************");

IAnimal animalObj1 = FactoryMethod.GetInstance(1);
IAnimal animalObj2 = FactoryMethod.GetInstance(2);

Console.WriteLine(animalObj1.Name.ToString());
Console.WriteLine(animalObj2.Name.ToString());

/* Prototype */
Console.WriteLine("\nPrototype pattern");
Console.WriteLine("************************");

PermanentEmployee e1 = new PermanentEmployee("a", "d1", 25000);
PermanentEmployee e2 = e1.Clone();
e2.Name = "b";
e2.Salary = 30000;

PartTimeEmployee p1 = new PartTimeEmployee("p", "d1", 4);
PartTimeEmployee p2 = p1.Clone();
p2.Name = "q";
p2.Hours = 3;

Console.WriteLine($"e1: Name {e1.Name}, e2: Name {e2.Name}, Salary:{e2.Salary}");
Console.WriteLine($"p1: Name {p1.Name}, p2: Name {p2.Name}, Hours:{p2.Hours}");

/* Builder */
Console.WriteLine("\nBuilder pattern");
Console.WriteLine("************************");
Home home = new Home();
Library lib = new Library();

var homeDetails = BuilderPattern.GetBuilding(home);
var libaryDetails = BuilderPattern.GetBuilding(lib);

Console.WriteLine(homeDetails);
Console.WriteLine(libaryDetails);


Console.WriteLine();

/* Abstract Factory */
Console.WriteLine("\nAbstract Factory pattern");
Console.WriteLine("************************");

ISystemFactory factory = AbstractFactory.GetFactory(1, 2);
ISystemFactory factory2 = AbstractFactory.GetFactory(2, 1);

IProcessor pro1 = factory.ProcesscorDetails();
ISystemType sys1 = factory.SystemTypeDetails();
IBrand br1 = factory.BrandDetails();

Console.WriteLine($"Details: Brand:{br1.GetBrand().ToString()}, SysType: {sys1.GetSystemType().ToString()}, processor: {pro1.GetProcessor().ToString()}");

/* Decorator */
Console.WriteLine("\nDecorator pattern");
Console.WriteLine("************************");

ICar c1 = new Car("Abc");
CarDecorator dec1 = new CarDecorator(c1);
int offerPrice = dec1.GetOfferPrice();

Console.WriteLine(offerPrice);

/* Adapter */
Console.WriteLine("\nAdapter pattern");
Console.WriteLine("************************");

string[,] emps = new string[4, 3] { { "a", "22", "10000" }, { "a", "21", "20000" }, { "a", "25", "30000" }, { "a", "26", "30003" } };
CliSystem emp12 = new CliSystem(new DBAdapter());
emp12.Exec("mm");

/* Bridge */
Console.WriteLine("\nBridge pattern");
Console.WriteLine("************************");

Bank b1 = new ABank();
b1.PaymentSystem = new UpiPayment();
b1.Credit(40000);

/* Proxy */
Console.WriteLine("\nProxy pattern");
Console.WriteLine("************************");

Employee emp = new Employee { Name = "a" };
PersonProxy proxy = new PersonProxy(emp);
proxy.Walk();

/* Composite */
Console.WriteLine("\nComposite pattern");
Console.WriteLine("************************");

var m2 = new Manager("b");
m2.AddSubOrdinate(new Employee { Name = "c" });

Manager m1 = new Manager("x");
m1.AddSubOrdinate(m2);
m1.AddSubOrdinate(new Employee { Name = "f" });

var m1details = m1.GetDetails(1);

Console.WriteLine(m1details);

/* Facade */
Console.WriteLine("**********************************");
Console.WriteLine("\nFacade");

ITheatreFacade facade = new TheatreFacade(new SoundSystem(), new Projector(), new DVDPlayer());
facade.WatchMovie();

/* FlyWeight */
FlyWeightFactory fac1 = new FlyWeightFactory();
var fl1 = fac1.GetInstance("A");
fl1.AB();

/* Iterator */
EmployeeList list = new EmployeeList();
list.Add(new Employee { Name = "a", Age = 21 });
list.Add(new Employee { Name = "b", Age = 22 });
list.Add(new Employee { Name = "c", Age = 23 });

Console.WriteLine();
Console.WriteLine("Iterator Pattern");
Console.WriteLine("*****************************");

foreach (var item in list)
{
    Console.WriteLine(item);
}

CVSamples sample = new CVSamples();
sample.Proc();

Console.ReadLine();