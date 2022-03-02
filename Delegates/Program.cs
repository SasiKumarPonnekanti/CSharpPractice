using System;
using System.Collections.Generic;
namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { Id = 23, Name = "sasi", Experience = 5, Salary = 20000 });
            empList.Add(new Employee() { Id = 24, Name = "naveen", Experience = 7, Salary = 30000 });
            empList.Add(new Employee() { Id = 25, Name = "mahesh", Experience = 9, Salary = 40000 });
            empList.Add(new Employee() { Id = 28, Name = "rajesh", Experience = 3, Salary = 50000 });
            empList.Add(new Employee() { Id = 26, Name = "Dravid", Experience = 8, Salary = 80000 });
            IsPromotable ispromotable = new IsPromotable(promote);
                

           Employee.PromoteEmployee(empList,ispromotable);
           Employee.PromoteEmployee(empList, empList => empList.Experience>5);



        }
        public static bool promote(Employee emp)
        {
            if (emp.Experience>5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
   public delegate bool IsPromotable(Employee emplist);       
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }

        public static void PromoteEmployee(List<Employee> employeeList, IsPromotable IsEligibleToPromote  )
        {
            foreach( Employee employee in employeeList )
            {
                if(IsEligibleToPromote(employee))
                {
                    Console.WriteLine( employee.Name +"is promoted");
                }
            }
        }
         
    }
}
