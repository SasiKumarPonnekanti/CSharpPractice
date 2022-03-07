using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Cs_Async_Await.models;
using Cs_Async_Await.DataAccess;

namespace Cs_Async_Await
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using Async and await");
            do
            {
                Console.WriteLine();
               
                Console.WriteLine("Enter Your Choice \n1.Department 2.Employee");
                int Choice1 = Convert.ToInt32(Console.ReadLine());
                switch (Choice1)
                {
                    case 1:

                        Console.WriteLine();
                        DeptDataAccess de= new DeptDataAccess();
                        Console.WriteLine("1.GetAllData\n2.GetById\n3.Create\n4.Update\n5.Delete");
                        int Choice2 = Convert.ToInt32(Console.ReadLine());
                        switch (Choice2)
                        {
                            case 1:
                                var departments = de.GetAllDeptDataAsync().Result;
                                if (departments != null)
                                {
                                    foreach(var department in departments)
                                    {
                                        Console.WriteLine($"DeptNo:{department.DeptNo} Name:{department.DeptName}" +
                                            $"Location:{department.Location} Capacity:{department.Capacity}");
                                    }
                                }

                                break;
                            case 2:
                                Console.WriteLine("Enter Dept Number");
                                bool IsNum = int.TryParse(Console.ReadLine(), out int num);
                                while (!IsNum)
                                {
                                    Console.WriteLine("Enter Dept No correctly");
                                    IsNum = int.TryParse(Console.ReadLine(), out num);
                                }
                                var dep = de.GetDeptByIdAsync(num).Result;
                                if (dep.DeptNo != 0)
                                {
                                    Console.WriteLine($"DeptNo:{dep.DeptNo} Name:{dep.DeptName}" +
                                             $"Location:{dep.Location} Capacity:{dep.Capacity}");
                                }
                                else
                                {
                                    Console.WriteLine("Department not found");
                                }

                                break;
                            case 3:
                                Console.WriteLine("Enter Dept No");
                                IsNum = int.TryParse(Console.ReadLine(), out int number);
                                while (!IsNum)
                                {
                                    Console.WriteLine("Enter Dept No correctly");
                                    IsNum = int.TryParse(Console.ReadLine(), out  number);
                                }
                                 dep = de.GetDeptByIdAsync(number).Result;
                                if (dep.DeptNo == 0)
                                {
                                    dep.DeptNo = number;
                                    Console.WriteLine("Enter Dept Name");
                                    dep.DeptName=Console.ReadLine();
                                    Console.WriteLine("Enter Location");
                                    dep.Location = Console.ReadLine();
                                    Console.WriteLine("Enter Capacity");
                                    IsNum = int.TryParse(Console.ReadLine(), out int Capacity);
                                    while (!IsNum)
                                    {
                                        Console.WriteLine("Enter Number Only");
                                        IsNum = int.TryParse(Console.ReadLine(), out Capacity);
                                    }
                                    dep.Capacity = Capacity;
                                    de.CreateDeptAsync(dep);
                                }
                                else
                                {
                                    Console.WriteLine("Department already Present Try Another Number");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Enter Dept No");
                                IsNum = int.TryParse(Console.ReadLine(), out  number);
                                while (!IsNum)
                                {
                                    Console.WriteLine("Enter Dept No correctly");
                                    IsNum = int.TryParse(Console.ReadLine(), out number);
                                }
                                dep = de.GetDeptByIdAsync(number).Result;
                                if (dep.DeptNo != 0)
                                {
                                    dep.DeptNo = number;
                                    Console.WriteLine("Enter New Dept Name");
                                    dep.DeptName = Console.ReadLine();
                                    Console.WriteLine("Enter New Location");
                                    dep.Location = Console.ReadLine();
                                    Console.WriteLine("Enter New Capacity");
                                    IsNum = int.TryParse(Console.ReadLine(), out int Capacity);
                                    while (!IsNum)
                                    {
                                        Console.WriteLine("Enter Number Only");
                                        IsNum = int.TryParse(Console.ReadLine(), out Capacity);
                                    }
                                    dep.Capacity = Capacity;
                                    de.UpdateDeptAsync(dep);
                                }
                                else
                                {
                                    Console.WriteLine("Department Not Present Try Another Number");
                                }


                                break;
                            case 5:
                                Console.WriteLine("Enter Dept No");
                                IsNum = int.TryParse(Console.ReadLine(), out  number);
                                while (!IsNum)
                                {
                                    Console.WriteLine("Enter Dept No correctly");
                                    IsNum = int.TryParse(Console.ReadLine(), out number);
                                }
                                dep = de.GetDeptByIdAsync(number).Result;
                                if (dep.DeptNo != 0)
                                {
                                    var res = de.DeleteDeptAsync(number).Result;
                                    if (res == 0)
                                    {
                                        Console.WriteLine("Delete UnSuccess");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Delete Success");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Department Not found");
                                }
                                break;
                            default:
                                Console.WriteLine("Wrong Choice");
                                break;

                        }
                        break;
                    case 2:
                        EmpDataAccess EA = new EmpDataAccess();
                        Console.WriteLine();
                        Console.WriteLine("1.GetAllData\n2.GetById\n3.Create\n4.Update\n5.Delete");
                        int Choice3 = Convert.ToInt32(Console.ReadLine());
                        switch (Choice3)
                        {
                            case 1:
                                var emps = EA.GetEmployeesAsync().Result;
                                foreach(var emp in emps)
                                {
                                    Console.WriteLine($"EmpNo:{emp.EmpNo} EmpName:{emp.EmpName} DeptNo:{emp.DeptNo}" +
                                        $" Designation:{emp.Designation} Salary:{emp.Salary}");
                                }

                                break;
                            case 2:
                                Console.WriteLine("Enter Emp Number");
                                bool IsNum = int.TryParse(Console.ReadLine(), out int num);
                                while (!IsNum)
                                {
                                    Console.WriteLine("Enter Dept No correctly");
                                    IsNum = int.TryParse(Console.ReadLine(), out num);
                                }
                                var empl = EA.GetEmpByIdAsync(num).Result;
                                if (empl.EmpNo != 0)
                                {
                                    Console.WriteLine($"EmpNo:{empl.EmpNo} EmpName:{empl.EmpName} DeptNo:{empl.DeptNo}" +
                                         $" Designation:{empl.Designation} Salary:{empl.Salary}");
                                }
                                else
                                {
                                    Console.WriteLine("Employee not found");
                                }

                                break;
                            case 3:
                                Employee empe = new Employee() ;
                                Console.WriteLine("Enter Emp Number");
                                IsNum = int.TryParse(Console.ReadLine(), out  num);
                                while (!IsNum)
                                {
                                    Console.WriteLine("Enter Dept No correctly");
                                    IsNum = int.TryParse(Console.ReadLine(), out num);
                                }
                                empl = EA.GetEmpByIdAsync(num).Result;
                                if (empl.EmpNo == 0)
                                {
                                    empe.EmpNo = num;
                                    Console.WriteLine("Enter name");
                                    empe.EmpName = Console.ReadLine();
                                    Console.WriteLine("Enter DeptNo");
                                    IsNum = int.TryParse(Console.ReadLine(), out num);
                                    while (!IsNum)
                                    {
                                        Console.WriteLine("Enter Dept No correctly");
                                        IsNum = int.TryParse(Console.ReadLine(), out num);
                                    }
                                    empe.DeptNo = num;
                                    Console.WriteLine("Enter Designation");
                                    empe.Designation = Console.ReadLine();
                                    var res = EA.CreateEmpAsync(empe).Result;
                                    if(res!=0)
                                    {
                                        Console.WriteLine("Employee Creation Successful");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee Creation Unsuccess");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Employee already present in DB");
                                }




                                break;
                            case 4:

                                break;
                            case 5:

                                Console.WriteLine("Enter Emp Number");
                                IsNum = int.TryParse(Console.ReadLine(), out  num);
                                while (!IsNum)
                                {
                                    Console.WriteLine("Enter Emp No correctly");
                                    IsNum = int.TryParse(Console.ReadLine(), out num);
                                }
                                 var result = EA.DeleteEmpAsync(num).Result;
                                if(result!=0)
                                {
                                    Console.WriteLine("Delete Employee Success");
                                }
                                else
                                {
                                    Console.WriteLine("Delete Employee UnSuccess");
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
