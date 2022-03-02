using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App.models
{
    internal class EmployeeOperations
    {
       public   static List<Employee> Employees = new List<Employee>() ;
        public static Dictionary<string, string> DptWiseList = new Dictionary<string, string>();
        public static Dictionary<string, string> DesigWiseList = new Dictionary<string, string>();


        public List<Employee> GetEmployees()
        {
            return Employees;
        }

        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            //Employees.Append(emp);
           // DptWiseList.Add(emp.EmpName, emp.DeptName);
            //DesigWiseList.Add(emp.EmpName, emp.Designation);

        }
       
        public void DeleteEmployee(int id)
        {
            try
            {
                if (SearchEmployee(id, out int? Index))
                {
                    int index = (int)Index;
                    Console.WriteLine($"The Employee info is Deleted and Deleted info is { Employees[index].EmpName}");
                    Employees.RemoveAt(index);
                   // DptWiseList.Remove(Employees[index].EmpName);
                    //DesigWiseList.Remove(Employees[index].EmpName);
                }
                else
                {
                    throw new Exception("The employee Not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        public bool SearchEmployee(int Id,out int? index)
        {
            bool flag= false;
            index = null;
            if (Employees!=null)
            {
                foreach (Employee emp in Employees)
                {
                    if (emp.EmpNo == Id)
                    {
                        flag = true;
                        index = Employees.IndexOf(emp);
                    }
                }
            }
            //else
            //{
              //  Console.WriteLine("The list is empty");
            //}
                return flag;
        }
    }
}
