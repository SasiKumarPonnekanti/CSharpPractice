using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NetFrwk_AllLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees emps = new Employees();
            NEmployees nemps = new NEmployees();
            // nwe Employees is similar to employees but with one more property DptNo insted of DeptName which is used to join with Drpartments
            Departments dpmts = new Departments();
            //  Created a method for each Sttement and calling them 
            AcsendingOrderByName();
            DepartmentWiseData();
            DepartmentWiseData();
            DesigWiseData();
            ManagerOrDirectorInfo();
            SalaryRange();
            SalariesDepartmentWise();
            MaxSalaryPerson();
            AllTaxes();
            TaxesDwise();
            CombiningDandE();
            static  double Calculator(int x)
            {
                if (x < 20000)
                    return 0;
                else if (x > 20000 && x < 40000)
                    return x * 0.05;
                else if (x > 40000 && x < 60000)
                    return x * 0.1;
                else
                    return x * 0.15;
            }
            void AcsendingOrderByName()
            {
                Console.WriteLine("---------------------Accending order by name-----------------------------");
                var res1 = from e in emps
                           orderby e.EmpName
                           select e;
                PrintResult(res1);
            }
            void DepartmentWiseData()
            {
                Console.WriteLine("----------------Department Wise Data--------------------------");
                var res2 = (from e in emps
                            group e by e.DeptName into deptgroup
                            select new
                            {
                                DeptName = deptgroup.Key,
                                Records = deptgroup.ToList(),
                                SumSalary = deptgroup.Sum(x => x.Salary),
                                MaxSalaryperson = deptgroup.OrderByDescending(x => x.Salary).Take(1),
                                MinSalaryperson = (from e in deptgroup orderby e.Salary select e).Take(1),
                                MaxSalaryperson2 = deptgroup.OrderByDescending(x => x.Salary).Skip(1).Take(1),
                                //preson with second max salary in each Dept
                                MinSalaryperson2 = (from e in deptgroup orderby e.Salary select e).Skip(1).Take(1),
                                //persom with 2nd min salary in each Dept
                                AverageSlary = deptgroup.Average(x => x.Salary),
                                count = deptgroup.Count()
                            });
                //Adding Required Info to anynymous object 

                //var res3 = from a in res2 select ((from b in a.Records orderby b.Salary select b.EmpName).Take(1));
                foreach (var record in res2)
                {
                    //printing a the data The have saved in anonymous object earlier
                    Console.WriteLine($"Group Key = {record.DeptName}");
                    Console.WriteLine($"Total Salary of {record.DeptName}  = {record.SumSalary}");
                    //  MaxSalaryPerson is Ienumberable type so i used foreach to print data and also for remaining
                    foreach (var a in record.MaxSalaryperson)
                    {
                        Console.WriteLine($"Person wit max Salary in {record.DeptName} is { a.EmpName}/{a.Designation}/{a.Salary}/{a.EmpNo}");
                    }
                    foreach (var a in record.MinSalaryperson)
                    {
                        Console.WriteLine($"person with min salary { a.EmpName}/{a.Designation}/{a.Salary}/{a.EmpNo}");
                    }
                    foreach (var a in record.MaxSalaryperson2)
                    {
                        Console.WriteLine($"Person wit 2 nd max Salary in {record.DeptName} is { a.EmpName}/{a.Designation}/{a.Salary}/{a.EmpNo}");
                    }
                    foreach (var a in record.MinSalaryperson2)
                    {
                        Console.WriteLine($"person with 2 nd min salary { a.EmpName}/{a.Designation}/{a.Salary}/{a.EmpNo}");
                    }
                    Console.WriteLine($"Average Salary of {record.DeptName}  = {record.AverageSlary}");
                    Console.WriteLine($"count of {record.DeptName} 's  = {record.count}");
                    // Calling print resultmetod to print data in eac group
                    PrintResult(record.Records);
                    
                }
            }
            void DesigWiseData()
            {
                var res4 = from e in emps
                           group e by e.Designation into desiggroup
                           select new
                           {
                               Designation = desiggroup.Key,
                               records = desiggroup.ToList()
                           };
                Console.WriteLine("--------------Designation wise Data-----------------");
                foreach (var record in res4)
                {
                    Console.WriteLine($"Group Key = {record.Designation}");

                    PrintResult(record.records);
                   
                }
            }
            
            void ManagerOrDirectorInfo()
            {
                var res5 = from e in emps where (e.Designation == "Manager" || e.Designation == "Director") select e;
                Console.WriteLine("---------------Employees who are Managers or directors--------------------------");
                PrintResult(res5);
            }
           
            void SalaryRange()
            {
                Console.WriteLine("---------------Employees with salary <75000 and >25000--------------------------");
                var res6 = from e in emps where (e.Salary > 25000 && e.Salary < 75000) select e;
                PrintResult(res6);
            }
            void SalariesDepartmentWise()
            {
                var res7 = from e in emps
                           group e by e.DeptName into SalaryGroupByDept
                           select new
                           {
                               Departent = SalaryGroupByDept.Key,
                               salary = (from e in SalaryGroupByDept select e.Salary).ToList()
                           };
                
                Console.WriteLine("------------------------All Salaries department wise----------------------------");
                foreach (var e in res7)
                {
                    Console.WriteLine(e.Departent);
                    foreach (var a in e.salary)
                    {
                        Console.WriteLine(a);
                    }

                }
            }
            void MaxSalaryPerson()
            {
                Console.WriteLine("------------------------person with second max Salary----------------------------");
                var res8 = (from e in emps orderby e.Salary descending select e).Skip(1).Take(1);
                PrintResult(res8);
            }
           
            Func<int, double> Tax = Calculator;
            //Func is a Delegate that encapsulates a method and retun the Output of T Type
            // calling calculator method which calculatws tax using Func named as tax
            void AllTaxes()
            {
                Func<int, double> Tax = Calculator;
                //
                var res9 = from e in emps orderby e.DeptName select (e.EmpName, Tax(e.Salary)).ToTuple();

                foreach (var e in res9)
                {
                    Console.WriteLine($"Name = {e.Item1}|| Tax= {e.Item2}");
                }
            }
            
            void TaxesDwise()
            {
                Func<int, double> Tax = Calculator;
                // Calaculator is metod that calculates Tax
                // I am calling that Method using Func named as Tax
                var res10 = from e in emps group e by e.DeptName into TaxGroup 
                            select new { Key = TaxGroup.Key,
                                tax = (from e in TaxGroup select (e.EmpName, Tax(e.Salary))).ToList()
                                        };
                Console.WriteLine("--------------------------Employees and their Taxes Department Wise--------------------------------");
                foreach (var e in res10)
                {
                    Console.WriteLine($" {e.Key} ");
                    foreach (var a in e.tax)
                    {
                        Console.WriteLine($"Name = {a.Item1}  Tax = {a.Item2}");
                    }

                }
            }
           
            void CombiningDandE()
            {
                Console.WriteLine("--------------combining employees and departments---------------");
                var res11 = from e1 in nemps
                            join e2 in dpmts on e1.DptNo equals e2.DptNo
                            select new
                            {
                                EmpName = e1.EmpName,
                                Department = e2.DptName,
                                EmpID = e1.EmpNo,
                                DptId = e2.DptNo,
                                Location = e2.Location,
                                salary = e1.Salary,
                                Designation = e1.Designation
                            };
                foreach (var e in res11)
                {
                    Console.WriteLine($"{e.EmpID} {e.EmpName} {e.DptId} {e.Designation} {e.Location}");
                }
            }





        }

        static void PrintResult(IEnumerable<Employee> emps)
        {
            foreach (var item in emps)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName}  {item.Designation} {item.Salary}");
            }
        }
    }

    internal class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
    internal class NEmployee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int DptNo { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
    internal class Department
    {
        public int DptNo { get; set; }
        public string DptName { get; set; }
        public string Location { get; set; }
        public int Capacity{ get; set; }
    }
    internal class Departments : List<Department>
    {
        public Departments()
        {
            
            Add(new Department() { DptNo = 101, DptName = "IT", Location = "Chennai", Capacity = 100 });
            Add(new Department() { DptNo = 102, DptName = "Account", Location = "Delhi", Capacity = 100 });
            Add(new Department() { DptNo = 103, DptName = "HR", Location = "Mumbai", Capacity = 100 });
            Add(new Department() { DptNo = 104, DptName = "SL", Location = "Kolkata", Capacity = 100 });
            Add(new Department() { DptNo = 105, DptName = "Admin", Location = "Amaravati", Capacity = 100 });
            Add(new Department() { DptNo = 106, DptName = "IT", Location = "Guntur", Capacity = 100 });
            Add(new Department() { DptNo = 107, DptName = "Account", Location = "Vizag", Capacity = 100 });
            Add(new Department() { DptNo = 108, DptName = "HR", Location = "Newyork", Capacity = 100 });
            Add(new Department() { DptNo = 109, DptName = "SL", Location = "Japan", Capacity = 100 });
            Add(new Department() { DptNo = 110, DptName = "Admin", Location = "Guntur", Capacity = 100 });
        }
    }


    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "Admin", Designation ="Manager", Salary = 113000 });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Designation = "Director", Salary = 122000 });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Designation = "Staff", Salary = 123000 });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = " Account", Designation = "Director", Salary = 143000 });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Designation = "Staff", Salary = 10000 });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Designation = " Engineer", Salary = 93000 });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Designation = " Engineer", Salary = 80300 });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = " Account", Designation = " Engineer", Salary = 73000 });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Designation = "Director", Salary = 64000 });
            Add(new Employee() { EmpNo = 110, EmpName = "Suprotim", DeptName = "IT", Designation = "Manager", Salary = 54000 });
            Add(new Employee() { EmpNo = 111, EmpName = "Ravi", DeptName = "IT", Designation = "Manager", Salary = 110040 });
            Add(new Employee() { EmpNo = 112, EmpName = "Suresh", DeptName = "Admin", Designation = " Engineer", Salary = 124000 });
            Add(new Employee() { EmpNo = 113, EmpName = "Harish", DeptName = "SL", Designation = "Staff", Salary = 123000 });
            Add(new Employee() { EmpNo = 114, EmpName = "Surya", DeptName = "IT", Designation = " Engineer", Salary = 142000 });
            Add(new Employee() { EmpNo = 115, EmpName = "Akansha", DeptName = " Account", Designation = " Engineer", Salary = 120000 });
            Add(new Employee() { EmpNo = 116, EmpName = "Abhi", DeptName = "SL", Designation = "Manager", Salary = 92000 });
            Add(new Employee() { EmpNo = 117, EmpName = "Harsha", DeptName = "IT", Designation = "Staff", Salary = 84000 });
            Add(new Employee() { EmpNo = 118, EmpName = "Suchand", DeptName = "HR", Designation = "Director",Salary = 74000 });
            Add(new Employee() { EmpNo = 119, EmpName = "Sai", DeptName = " Account", Designation = "Director", Salary = 60300 });
            Add(new Employee() { EmpNo = 120, EmpName = "Brahma", DeptName = "Admin", Designation = "Director", Salary = 52000 });
            Add(new Employee() { EmpNo = 121, EmpName = "Amar", DeptName = "IT", Designation = "Manager", Salary = 110200 });
            Add(new Employee() { EmpNo = 122, EmpName = "Tarun", DeptName = "HR", Designation = "Director", Salary = 122000 });
            Add(new Employee() { EmpNo = 123, EmpName = "BalaKrishna", DeptName = "SL", Designation = "Staff", Salary = 130200 });
            Add(new Employee() { EmpNo = 124, EmpName = "Hema", DeptName = "IT", Designation = "Staff", Salary = 140200 });
            Add(new Employee() { EmpNo = 125, EmpName = "Asha", DeptName = "HR", Designation = " Engineer", Salary = 100200 });
            Add(new Employee() { EmpNo = 126, EmpName = "Akshay", DeptName = "SL", Designation = "Staff", Salary = 92000 });
            Add(new Employee() { EmpNo = 127, EmpName = "sharukh", DeptName = "IT", Designation = "Director", Salary = 83000 });
            Add(new Employee() { EmpNo = 128, EmpName = "Salman", DeptName = "HR", Designation = "Manager", Salary = 70300 });
            Add(new Employee() { EmpNo = 129, EmpName = "Vivek obeari", DeptName = "SL", Designation = "Director", Salary = 36000 });
            Add(new Employee() { EmpNo = 130, EmpName = "Sushant", DeptName = "IT", Designation = "Director", Salary = 25000 });
            Add(new Employee() { EmpNo = 131, EmpName = "vishnu", DeptName = "Admin", Designation = "Staff", Salary = 121000 });
            Add(new Employee() { EmpNo = 132, EmpName = "Bhaskar", DeptName = "HR", Designation = "Manager", Salary = 122000 });
            Add(new Employee() { EmpNo = 133, EmpName = "Raju", DeptName = "SL", Designation = "Staff", Salary = 132000 });
            Add(new Employee() { EmpNo = 134, EmpName = "Brunda", DeptName = "IT", Designation = " Engineer", Salary = 143000 });
            Add(new Employee() { EmpNo = 135, EmpName = "Anurdha", DeptName = "HR", Designation = "Staff", Salary = 100300 });
            Add(new Employee() { EmpNo = 136, EmpName = "Soundarya", DeptName = "SL", Designation = "Manager", Salary = 39000 });
            Add(new Employee() { EmpNo = 137, EmpName = "Mounisha", DeptName = "Admin", Designation = "Staff", Salary = 28000 });
            Add(new Employee() { EmpNo = 138, EmpName = "Mounika", DeptName = "HR", Designation = "Director", Salary = 73000 });
            Add(new Employee() { EmpNo = 139, EmpName = "Dhanvi", DeptName = "SL", Designation = "Staff", Salary = 63000 });
            Add(new Employee() { EmpNo = 140, EmpName = "Keerthi", DeptName = " Account", Designation = "Staff", Salary = 53000 });
            Add(new Employee() { EmpNo = 141, EmpName = "Dharani", DeptName = "Admin", Designation = "Manager", Salary = 11000 });
            Add(new Employee() { EmpNo = 142, EmpName = "Sirisha", DeptName = "HR", Designation = "Staff", Salary = 12000 });
            Add(new Employee() { EmpNo = 143, EmpName = "Janu", DeptName = " Account", Designation = " Engineer", Salary = 132000 });
            Add(new Employee() { EmpNo = 144, EmpName = "Deepika", DeptName = "IT", Designation = "Director", Salary = 140400 });
            Add(new Employee() { EmpNo = 145, EmpName = "Kajal", DeptName = " Account", Designation = " Engineer", Salary = 130000 });
            Add(new Employee() { EmpNo = 146, EmpName = "Eesha", DeptName = "Admin", Designation = " Engineer", Salary = 39000 });
            Add(new Employee() { EmpNo = 147, EmpName = "Ananya", DeptName = "IT", Designation = "Manager", Salary = 83000 });
            Add(new Employee() { EmpNo = 148, EmpName = "Manasi", DeptName = " Account", Designation = "Director", Salary = 77000 });
            Add(new Employee() { EmpNo = 149, EmpName = "MAyur", DeptName = " Account", Designation = " Engineer", Salary = 60000 });
            Add(new Employee() { EmpNo = 150, EmpName = "Venkat Raman", DeptName = "Admin", Designation = "Manager", Salary = 50000 });
        }
    }
    internal class NEmployees : List<NEmployee>
    {
        public NEmployees()
        {
            Add(new NEmployee() { EmpNo = 101, EmpName = "Mahesh", DptNo = 101, Designation = "Manager", Salary = 113000 });
            Add(new NEmployee() { EmpNo = 102, EmpName = "Tejas", DptNo = 102, Designation = "Director", Salary = 122000 });
            Add(new NEmployee() { EmpNo = 103, EmpName = "Nandu", DptNo = 103, Designation = "Staff", Salary = 123000 });
            Add(new NEmployee() { EmpNo = 104, EmpName = "Anil", DptNo = 104, Designation = "Director", Salary = 143000 });
            Add(new NEmployee() { EmpNo = 105, EmpName = "Jaywant", DptNo = 105, Designation = "Staff", Salary = 10000 });
            Add(new NEmployee() { EmpNo = 106, EmpName = "Abhay", DptNo = 106, Designation = " Engineer", Salary = 93000 });
            Add(new NEmployee() { EmpNo = 107, EmpName = "Anil", DptNo = 107, Designation = " Engineer", Salary = 80300 });
            Add(new NEmployee() { EmpNo = 108, EmpName = "Shyam", DptNo = 108, Designation = " Engineer", Salary = 73000 });
            Add(new NEmployee() { EmpNo = 109, EmpName = "Vikram", DptNo = 109, Designation = "Director", Salary = 64000 });
            Add(new NEmployee() { EmpNo = 110, EmpName = "Suprotim", DptNo = 110, Designation = "Manager", Salary = 54000 });
            Add(new NEmployee() { EmpNo = 111, EmpName = "Ravi", DptNo = 101, Designation = "Manager", Salary = 110040 });
            Add(new NEmployee() { EmpNo = 112, EmpName = "Suresh", DptNo = 102, Designation = " Engineer", Salary = 124000 });
            Add(new NEmployee() { EmpNo = 113, EmpName = "Harish", DptNo = 103, Designation = "Staff", Salary = 123000 });
            Add(new NEmployee() { EmpNo = 114, EmpName = "Surya", DptNo = 104, Designation = " Engineer", Salary = 142000 });
            Add(new NEmployee() { EmpNo = 115, EmpName = "Akansha", DptNo = 105, Designation = " Engineer", Salary = 120000 });
            Add(new NEmployee() { EmpNo = 116, EmpName = "Abhi", DptNo = 106, Designation = "Manager", Salary = 92000 });
            Add(new NEmployee() { EmpNo = 117, EmpName = "Harsha", DptNo = 107, Designation = "Staff", Salary = 84000 });
            Add(new NEmployee() { EmpNo = 118, EmpName = "Suchand", DptNo = 108, Designation = "Director", Salary = 74000 });
            Add(new NEmployee() { EmpNo = 119, EmpName = "Sai", DptNo = 109, Designation = "Director", Salary = 60300 });
            Add(new NEmployee() { EmpNo = 120, EmpName = "Brahma", DptNo = 110, Designation = "Director", Salary = 52000 });
            Add(new NEmployee() { EmpNo = 121, EmpName = "Amar", DptNo = 101, Designation = "Manager", Salary = 110200 });
            Add(new NEmployee() { EmpNo = 122, EmpName = "Tarun", DptNo = 102, Designation = "Director", Salary = 122000 });
            Add(new NEmployee() { EmpNo = 123, EmpName = "BalaKrishna", DptNo = 103, Designation = "Staff", Salary = 130200 });
            Add(new NEmployee() { EmpNo = 124, EmpName = "Hema", DptNo = 104, Designation = "Staff", Salary = 140200 });
            Add(new NEmployee() { EmpNo = 125, EmpName = "Asha", DptNo = 105, Designation = " Engineer", Salary = 100200 });
            Add(new NEmployee() { EmpNo = 126, EmpName = "Akshay", DptNo = 106, Designation = "Staff", Salary = 92000 });
            Add(new NEmployee() { EmpNo = 127, EmpName = "sharukh", DptNo = 107, Designation = "Director", Salary = 83000 });
            Add(new NEmployee() { EmpNo = 128, EmpName = "Salman", DptNo = 108, Designation = "Manager", Salary = 70300 });
            Add(new NEmployee() { EmpNo = 129, EmpName = "Vivek obeari", DptNo = 109, Designation = "Director", Salary = 36000 });
            Add(new NEmployee() { EmpNo = 130, EmpName = "Sushant", DptNo = 110, Designation = "Director", Salary = 25000 });
            Add(new NEmployee() { EmpNo = 131, EmpName = "vishnu", DptNo = 101, Designation = "Staff", Salary = 121000 });
            Add(new NEmployee() { EmpNo = 132, EmpName = "Bhaskar", DptNo = 102, Designation = "Manager", Salary = 122000 });
            Add(new NEmployee() { EmpNo = 133, EmpName = "Raju", DptNo = 103, Designation = "Staff", Salary = 132000 });
            Add(new NEmployee() { EmpNo = 134, EmpName = "Brunda", DptNo = 104, Designation = " Engineer", Salary = 143000 });
            Add(new NEmployee() { EmpNo = 135, EmpName = "Anurdha", DptNo = 105, Designation = "Staff", Salary = 100300 });
            Add(new NEmployee() { EmpNo = 136, EmpName = "Soundarya", DptNo = 106, Designation = "Manager", Salary = 39000 });
            Add(new NEmployee() { EmpNo = 137, EmpName = "Mounisha", DptNo = 107 ,Designation = "Staff", Salary = 28000 });
            Add(new NEmployee() { EmpNo = 138, EmpName = "Mounika", DptNo = 108, Designation = "Director", Salary = 73000 });
            Add(new NEmployee() { EmpNo = 139, EmpName = "Dhanvi", DptNo = 109, Designation = "Staff", Salary = 63000 });
            Add(new NEmployee() { EmpNo = 140, EmpName = "Keerthi", DptNo = 110, Designation = "Staff", Salary = 53000 });
            Add(new NEmployee() { EmpNo = 141, EmpName = "Dharani", DptNo = 101, Designation = "Manager", Salary = 11000 });
            Add(new NEmployee() { EmpNo = 142, EmpName = "Sirisha", DptNo = 102, Designation = "Staff", Salary = 12000 });
            Add(new NEmployee() { EmpNo = 143, EmpName = "Janu", DptNo = 103, Designation = " Engineer", Salary = 132000 });
            Add(new NEmployee() { EmpNo = 144, EmpName = "Deepika", DptNo = 104, Designation = "Director", Salary = 140400 });
            Add(new NEmployee() { EmpNo = 145, EmpName = "Kajal", DptNo = 105, Designation = " Engineer", Salary = 130000 });
            Add(new NEmployee() { EmpNo = 146, EmpName = "Eesha", DptNo = 106, Designation = " Engineer", Salary = 39000 });
            Add(new NEmployee() { EmpNo = 147, EmpName = "Ananya", DptNo = 107, Designation = "Manager", Salary = 83000 });
            Add(new NEmployee() { EmpNo = 148, EmpName = "Manasi", DptNo = 108, Designation = "Director", Salary = 77000 });
            Add(new NEmployee() { EmpNo = 149, EmpName = "MAyur", DptNo = 109, Designation = " Engineer", Salary = 60000 });
            Add(new NEmployee() { EmpNo = 150, EmpName = "Venkat Raman", DptNo = 110, Designation = "Manager", Salary = 50000 });
        }
    }
}