using System;

namespace polymorphism_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Employee employee = new Employee();
            employee.firstName = "sasi";
            employee.lastName = "kumar";
            employee.Print();
            partTime parttime= new partTime();
            parttime.Print();
            Employee sasi = new partTime();
            sasi.Print();
            Employee kumar = new Temp();
            kumar.lastName = "kumar";
            kumar.firstName = "first name ";
            kumar.Print();
            kumar.temp();
        }
    }
    class Employee
    {
        public string firstName;
        public string lastName;
        public virtual void Print()
        {
            Console.WriteLine(firstName+lastName);
        }
        public void temp()
        {
            Console.WriteLine("............");        }
    }
    class partTime : Employee
    {
        public override void Print()
        {
            Console.WriteLine(firstName + lastName+"parttime");
        }
    }
    class fullTime : Employee
    {
        public override void Print()
        {
            Console.WriteLine(firstName + lastName+"fulltime");
        }
    }
    class Temp:Employee
    {
       
    }
}
