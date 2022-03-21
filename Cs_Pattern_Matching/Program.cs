
// See https://aka.ms/new-console-template for more information
using Cs_Pattern_Matching;

Console.WriteLine("Hello, World!");
List<Object> Objects = new List<Object>() 
{ 1,2,3,4,5,6,7,8,9,10,
 10.1,20.1,33.232,21.345,12.34,1.32,33.12,
 'A','B','C','D','F','G','H','I','J','L','M',
 "Sasi","Gopi","Naveen","Abhi","Harsha","Tarak","Charan",
 "Mounika","Dharani","Darshana",
 //list of employes
 new List<Employee>(){new Employee() { EmpName="Sasi",EmpNo=10,DeptNo=10,Salary=10000,Designation="Manager"},
   new Employee() { EmpName="Gopi",EmpNo=20,DeptNo=20,Salary=90000,Designation="Engineer"},
    new Employee() { EmpName="Naveen",EmpNo=30,DeptNo=30,Salary=30000,Designation="Manager"},
     new Employee() { EmpName="Darshana",EmpNo=40,DeptNo=40,Salary=230000,Designation="Engineer"},
   new Employee() { EmpName="Abhi",EmpNo=50,DeptNo=10,Salary=90000,Designation="Manager"},
    new Employee() { EmpName="harsha",EmpNo=60,DeptNo=20,Salary=30000,Designation="Engineer"},
     new Employee() { EmpName="Mounika",EmpNo=70,DeptNo=30,Salary=10000,Designation="Manager"},
      new Employee() { EmpName="Tarak",EmpNo=80,DeptNo=40,Salary=90000,Designation="Engineer"},
       new Employee() { EmpName="Charan",EmpNo=90,DeptNo=50,Salary=40000,Designation="Manager"},
new Employee() { EmpName = "sai", EmpNo = 100, DeptNo = 20, Salary = 440000, Designation = "Engineer" }},

 new List<int>(){10,20,30,31,32,33,34,23,43,45,56,22},

 new List<string>(){"Sasi","Gopi","Naveen","Abhi","Harsha","Tarak","Charan",
 "Mounika","Dharani","Darshana"},

 new List<Char>(){ 'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I', 'J', 'L', 'M'},

 new DateTime(2022,10,21),
 new DateTime(2022,10,22),
 new DateTime(2022,10,23),
 new DateTime(2022,10,24),
 new DateTime(2022,10,25),
 new DateTime(2022,10,26),
 new DateTime(2022,10,27),
 new DateTime(2022,10,28),
 new DateTime(2022,10,29),
 new DateTime(2022,10,30),



};
ProcessCollection(Objects,out List<Employee> Employees, out List<int> integers, out List<string> strings, out List<double> decimals, out List<char> characters, out List<DateTime> dates);

foreach(var v in strings)
{
    Console.WriteLine(v);
}
foreach (var v in decimals)
{
    Console.WriteLine(v);
}
foreach (var v in strings)
{
    Console.WriteLine(v);
}
foreach (var v in characters)
{
    Console.WriteLine(v);
}
static void ProcessCollection(List<object> values, out List<Employee> Employees, out List<int> integers, out List<string> strings, out List<double> decimals, out List<char> characters, out List<DateTime> dates)
{
    Console.WriteLine("Pocessing a collection");
    Employees = new List<Employee>() ;
    integers = new List<int>() ;
    strings = new List<string>() ;
    decimals = new List<double>()  ;
    dates = new List<DateTime>()  ;
    characters = new List<char>() ;

    foreach (object val in values)
    {
        switch (val)
        {
            case IEnumerable<int> intList:
                foreach (var item in intList)
                {
                   integers.Add(item);
                }
                
                break;
            case IEnumerable<Employee> EmpList:
                foreach (var item in EmpList)
                {
                    Employees.Add(item);
                }

                break;
            case IEnumerable<string> strList:
                foreach (var item in strList)
                {
                    strings.Add(item);
                }
               
                break;
            case string s:
                strings.Add(s);
                break;
           
            case int v:
                integers.Add((int)v);
                break;
            
            case double d:
                decimals.Add(d);
                break;
            case char c:
                characters.Add(c);
                break;
            case DateTime d:
                dates.Add(d);
                break;
            default:
                Console.WriteLine("Finally.....");
                break;
        }
    }
}