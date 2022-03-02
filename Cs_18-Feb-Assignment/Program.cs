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
            #region Data Access
            IDataAccess<Employee, int> empDA = new DataAccess();
            Employee emp = new Employee() { EmpNo = 134, EmpName = "SasiKumar", Designation = "Manager", DeptNo = 40, Salary = 25000 };


            //Adding Employee
            Console.WriteLine("Adding An Employee");
            Employee empd = empDA.Create(emp);
            Console.WriteLine($"{empd.EmpName}");
            emp.Salary = 2345;
            emp.EmpName = "GopiKrishna";

            //Deleting Employee
            Console.WriteLine("Delete an Employee By EmpNo");
             empd = empDA.Delete(134);

            
            Console.WriteLine("Get Data of All Employees");
            var Employees = empDA.GetData();
            foreach (Employee em in Employees)
            {
                Console.WriteLine($"EmpName:{em.EmpName}||Designation:{em.Designation}||Salary:{em.Salary}");
            }


            Console.WriteLine("Get Employee Data By EmpNO");
            emp = empDA.GetData(133);
            Console.WriteLine($"EmpNO:{emp.EmpNo}||EmpNAme:{emp.EmpName}Department:{emp.DeptNo}Designation:{emp.Designation}");
            #endregion




            #region using Rport
            Report report = new Report();
            report.GetAllEmployeesByDeptName("HR");

            //report.GetAllEmployeesWithMaxSalByDeptName("IT");

            report.GetAllEmployeesByLocation("pune");
            report.GetSumSalaryByDeptName("IT");
            #endregion



        }
    }
}
