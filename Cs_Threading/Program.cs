using System;
using System.Threading;

namespace Cs_Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using Threading");
            Employee employee = new Employee();
            Console.WriteLine("Enter EmpNO");
            employee.EmpNo=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmpName");
            employee.EmpName=Console.ReadLine();
            Console.WriteLine("Enter DeptNO");
            employee.DeptNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Designation");
            employee.Designation=Console.ReadLine();
            Console.WriteLine("Enter Salary");
            employee.Salary = Convert.ToInt32(Console.ReadLine());
            StoreData storeData = new StoreData();
          
            Thread t1= new Thread(()=> storeData.WriteDataToDb(employee));
            Thread t2 = new Thread(() => storeData.WriteDataToFile(employee));
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"EmpNo:{employee.EmpNo} EmpName:{employee.EmpName} Designation:{employee.Designation} Salary:{employee.Salary}");


        }

       
    }
}
