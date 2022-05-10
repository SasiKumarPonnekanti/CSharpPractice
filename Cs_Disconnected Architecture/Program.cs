using System;
using Cs_Disconnected_Architecture.Data;
using Cs_Disconnected_Architecture.Models;
using System.Collections.Generic;

namespace Cs_Disconnected_Architecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Using Disconnected Architecture");
                Console.WriteLine("Enter Your Choice \n1.Department 2.Employee");
                int Choice1 = Convert.ToInt32(Console.ReadLine());
                switch (Choice1)
                {
                    case 1:
                        IDataAccess<Department, int> DeptAccess = new DepartmentDataAccess();
                        Console.WriteLine();
                        Console.WriteLine("1.GetAllData\n2.GetById\n3.Create\n4.Update\n5.Delete");
                        int Choice2 = Convert.ToInt32(Console.ReadLine());
                        switch (Choice2)
                        {
                            case 1:
                                var departments =DeptAccess.GetData();
                                foreach (var d in departments)
                                {
                                    Console.WriteLine($"DeptName:{d.DeptName} DeptNo:{d.DeptNo} Location:{d.Location} capacity:{d.Capacity}");
                                }
                                Console.WriteLine();
                               
                                break;
                            case 2:
                                Console.WriteLine("Enter Department Number");
                                int dnumber = Convert.ToInt32(Console.ReadLine());
                                var de = DeptAccess.GetData(dnumber);
                                if(de != null)
                                {
                                    Console.WriteLine($"DeptName:{de.DeptName} DeptNo:{de.DeptNo} Location:{de.Location} Capacity:{de.Capacity}");
                                }
                                else
                                {
                                    Console.WriteLine("Department Not Found");
                                }
                                break;
                            case 3:
                                
                                Console.WriteLine("Enter Department Number");
                                dnumber = Convert.ToInt32(Console.ReadLine());
                                var dept = DeptAccess.GetData(dnumber);
                                if (dept == null)
                                {
                                    dept = new Department();
                                    dept.DeptNo = dnumber;
                                    Console.WriteLine("Enter  DeptName");
                                    dept.DeptName = Console.ReadLine();
                                    Console.WriteLine("Enter  Location");
                                    dept.Location = Console.ReadLine();
                                    Console.WriteLine("Enter  capacity");
                                    dept.Capacity = Convert.ToInt32(Console.ReadLine());
                                    DeptAccess.Create( dept);

                                }
                                else
                                {
                                    Console.WriteLine("Department Not Found To Update");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Enter Department Number");
                                dnumber  = Convert.ToInt32(Console.ReadLine());
                                dept = DeptAccess.GetData(dnumber);
                                if (dept != null)
                                {
                                    Console.WriteLine("Enter new DeptName");
                                    dept.DeptName=Console.ReadLine();
                                    Console.WriteLine("Enter New Location");
                                    dept.Location=Console.ReadLine();
                                    Console.WriteLine("Enter New capacity");
                                    dept.Capacity = Convert.ToInt32(Console.ReadLine());
                                    DeptAccess.Update(dnumber, dept);

                                }
                                else
                                {
                                    Console.WriteLine("Department Not Found To Update");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Enter Department Number");
                                dnumber = Convert.ToInt32(Console.ReadLine());
                                dept = DeptAccess.GetData(dnumber);
                                if (dept != null)
                                {
                                    DeptAccess.Delete(dnumber);
                                }
                                else
                                {
                                    Console.WriteLine("Department not Found to delete");
                                }
                                    break;
                            default:
                                Console.WriteLine("Wrong Choice");
                                break;

                        }
                        break;
                    case 2:
                        IDataAccess<Employee, int> EmpAccess = new EmployeeDataAccess();
                        Console.WriteLine();
                        Console.WriteLine("1.GetAllData\n2.GetById\n3.Create\n4.Update\n5.Delete");
                        int Choice3 = Convert.ToInt32(Console.ReadLine());
                        switch (Choice3)
                        {
                            case 1:
                                var Employees = EmpAccess.GetData();
                                foreach (var e in Employees)
                                {
                                    Console.WriteLine($"EmpName :{e.EmpName} Emp No :{e.EmpNo} Designation {e.Designation}");
                                }
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter Number");
                                int id = Convert.ToInt32(Console.ReadLine());
                                var emp = EmpAccess.GetData(id);
                                if (emp != null)
                                {
                                    Console.WriteLine($"Data Of Employee Having EmpNo {emp.EmpNo}");
                                    Console.WriteLine($"EmpName:{emp.EmpName}EmpNo:{emp.EmpNo}Desigantion:{emp.Designation}");
                                }
                                else
                                {
                                    Console.WriteLine("Emp Not Found");
                                }
                                Console.WriteLine();
                                break;
                            case 3:
                                Employee Nemp = new Employee();
                                Console.WriteLine("Enter Employee number");
                                id = Convert.ToInt32(Console.ReadLine());
                                emp = EmpAccess.GetData(id);
                                if(emp==null)
                                {
                                    Nemp.EmpNo = id;
                                    Console.WriteLine("Enter Name");
                                    Nemp.EmpName=Console.ReadLine();
                                    Console.WriteLine("Enter Department number");
                                    Nemp.DeptNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter Designtion");
                                    Nemp.Designation = Console.ReadLine();
                                    Console.WriteLine("Enter Salary");
                                    Nemp.Salary = Convert.ToInt32(Console.ReadLine());
                                    EmpAccess.Create(Nemp);
                                }
                                else
                                {
                                    Console.WriteLine("Employee Number Already present");
                                }
                                break;
                            case 4:
                                Employee Uemp = new Employee();
                                Console.WriteLine("Enter Employee number");
                                id = Convert.ToInt32(Console.ReadLine());
                                emp = EmpAccess.GetData(id);
                                if (emp != null)
                                {
                                    Uemp.EmpNo = id;
                                    Console.WriteLine("Enter New Name");
                                    Uemp.EmpName = Console.ReadLine();
                                    Console.WriteLine("Enter New Department number");
                                    Uemp.DeptNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter new Designtion");
                                    Uemp.Designation = Console.ReadLine();
                                    Console.WriteLine("Enter New Salary");
                                    Uemp.Salary = Convert.ToInt32(Console.ReadLine());
                                    EmpAccess.Update(id,Uemp);
                                }
                                else
                                {
                                    Console.WriteLine("Employee Number NOT found");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Enter Employee number");
                                id = Convert.ToInt32(Console.ReadLine());
                                var de = EmpAccess.Delete(id);
                                if (de!=null)
                                {
                                    Console.WriteLine("Delete Success");
                                }
                                else
                                {
                                    Console.WriteLine("Delete UNSuccess");
                                }

                                break;
                            default:
                                Console.WriteLine("Wrong Choice");
                                break;

                        }
                        break;
                }
            }
            while (true);

        }
    }
}
