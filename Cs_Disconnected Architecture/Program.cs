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
            Console.WriteLine("Using Disconnected Architecture");
            IDataAccess<Department ,int> DeptAccess = new DepartmentDataAccess();
            // Using Get Data Method
            var Depts = DeptAccess.GetData();
            Console.WriteLine("Printing all Data of Departments using Get() Method");
            foreach(Department d in Depts)
            {
                Console.WriteLine($"{d.DeptNo}||{d.DeptName}||{d.Location}||{d.Capacity}");
            }
            Console.WriteLine();



            // Get Data By Id
            var Dept = DeptAccess.GetData(10);
            Console.WriteLine("Printing Department having Dept Id As 10");
            Console.WriteLine($"{Dept.DeptNo}||{Dept.DeptName}||{Dept.Location}||{Dept.Capacity}");
            Console.WriteLine();


            //creating A Department
            Department NEwDept = new Department() { DeptNo = 70,DeptName="NEWDEpt" ,Location="MYDen",Capacity=100};
            DeptAccess.Create(NEwDept);
            Depts = DeptAccess.GetData();
            Console.WriteLine("Printring data After Creating new Dapartment");
            foreach (Department d in Depts)
            {
                Console.WriteLine($"{d.DeptNo}||{d.DeptName}||{d.Location}||{d.Capacity}");
            }
            Console.WriteLine();

            //Updating A Department
             var UpdatedDept = DeptAccess.Update(70, NEwDept);

            //Deleting A Department
            var DelDEpt = DeptAccess.Delete(70);


            //Calling EMployee Access Methods


            IDataAccess<Employee, int> EmpAccess = new EmployeeDataAccess();
            Employee NewEmp = new Employee() { DeptNo = 10, EmpNo = 190, EmpName = "Rajesh", Designation = "TechLead", Salary = 34987 };

            // Adding An Employee
            EmpAccess.Create(NewEmp);
            Console.WriteLine();


            Console.WriteLine("Printing data of All Employees");
            var Employees = EmpAccess.GetData();
            foreach(var  e in Employees)
            {
                Console.WriteLine($"EmpName :{e.EmpName} Emp No :{e.EmpNo} Designation {e.Designation}");
            }
            Console.WriteLine();

            

            var emp = EmpAccess.GetData(190);
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





            emp = EmpAccess.Delete(190);
            if (emp != null)
            {
                Console.WriteLine("The Employee Info Is Deleted and the info Is");
                Console.WriteLine($"Emp Name:{emp.EmpName}EmpNo:{emp.EmpNo}Designation:{emp.Designation}");
            }
            else
            {
                Console.WriteLine("Emp Not Found");
            }
        }
    }
}
