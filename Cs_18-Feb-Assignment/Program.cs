using System;
using Cs_18_Feb_Assignment.DataAcces;
using Cs_18_Feb_Assignment.Models;

namespace Cs_18_Feb_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using Connected Architecture");
            do
            {
                IDataAccess<Employee, int> empDA = new DataAccess();
                Employee emp = new Employee() { EmpNo = 134, EmpName = "SasiKumar", Designation = "Manager", DeptNo = 40, Salary = 25000 };
                Report report = new Report();
                Console.WriteLine();
                Console.WriteLine("Enter Choice");
                Console.WriteLine("1.GetallData \n2.GetDatbyId \n3.Create\n4.Update\n5.Delete");
                Console.WriteLine("6.GetAllEmployeesByDeptName");
                Console.WriteLine("7.GetEmpofMaxSalarybyDept");
                Console.WriteLine("8.GetAllEmployeesBylocation");
                Console.WriteLine("9.GetSumSalaryByDeptName");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var Employees = empDA.GetData();
                        foreach (Employee em in Employees)
                        {
                            Console.WriteLine($"EmpName:{em.EmpName}||Designation:{em.Designation}||Salary:{em.Salary}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Number");
                        int num = Convert.ToInt32(Console.ReadLine());
                        Employee empe = empDA.GetData(num);
                        if (empe.EmpNo != 0)
                            Console.WriteLine($"EmpNO:{empe.EmpNo}||EmpNAme:{empe.EmpName}Department:{empe.DeptNo}Designation:{empe.Designation}");
                        else
                            Console.WriteLine("Emp Not Found");
                        break;
                    case 3:
                        
                        Console.WriteLine("Enter Employee Number");
                        int id = Convert.ToInt32((Console.ReadLine()));
                        empe = empDA.GetData(id);
                        if (empe.EmpNo ==0)
                        {
                            Employee Emp = new Employee();
                            Emp.EmpNo = id;
                            Console.WriteLine("Enter Name");
                            Emp.EmpName = Console.ReadLine();
                            Console.WriteLine("Enter  DeptNo");
                            Emp.DeptNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter  Designation");
                            Emp.Designation = Console.ReadLine();
                            Console.WriteLine("Enter Salary");
                            Emp.Salary = Convert.ToInt32(Console.ReadLine());
                            empDA.Create(Emp);
                        }
                        else
                        {
                            Console.WriteLine("Employee number is already present ");
                        }
                        
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Number to Update");
                        id = Convert.ToInt32((Console.ReadLine()));
                        empe = empDA.GetData(id);
                        if (empe.EmpNo != 0)
                        {
                            Employee updatedEmp = new Employee();
                            updatedEmp.EmpNo = id;
                            Console.WriteLine("Enter New Name");
                            updatedEmp.EmpName = Console.ReadLine();
                            Console.WriteLine("Enter New DeptNo");
                            updatedEmp.DeptNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter New Designation");
                            updatedEmp.Designation = Console.ReadLine();
                            Console.WriteLine("Enter New Salary");
                            updatedEmp.Salary = Convert.ToInt32(Console.ReadLine());
                            empDA.Update(id, updatedEmp);
                        }
                        else
                        {
                            Console.WriteLine("Employee Not In DataBase Try again..");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Employee Number To Delete");
                        id = Convert.ToInt32((Console.ReadLine()));
                        Employee empd = empDA.Delete(id);
                        break;
                    case 6:
                        Console.WriteLine("Enter Department");
                        string Dept = Console.ReadLine();
                        report.GetAllEmployeesByDeptName(Dept);
                        break;
                    case 7:
                        Console.WriteLine("Enter Department");
                        Dept = Console.ReadLine();
                        report.GetAllEmployeesWithMaxSalByDeptName(Dept);
                        break;
                    case 8:
                        Console.WriteLine("Enter Location");
                        string location = Console.ReadLine();
                        report.GetAllEmployeesByLocation(location);
                        break;
                    case 9:
                        Console.WriteLine("Enter Department");
                        Dept = Console.ReadLine();
                        report.GetSumSalaryByDeptName(Dept);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
            }
            while (true);


        }
    }
}
