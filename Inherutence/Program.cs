using System;

namespace Inherutence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PartTimeEmployee sasi = new PartTimeEmployee();
            sasi.FirstName = "Sasi";
            sasi.Lastname = "Kumar";
            int salary = sasi.Salary(22);
            Console.WriteLine(salary);
            sasi.Datails();
        }
    }
    class Emplyee
    {
       public string FirstName;
       public string Lastname;
        public string MailId;
        public void Datails()
        {
            Console.WriteLine("first name is {0} and Last name is {1}  ", this.FirstName, Lastname);

        }
    }
    class PartTimeEmployee : Emplyee
    {
        static int rate=66;
       
        public int Salary(int time)
        {
            return  rate * time;
        }
    }
    class FullTimeEmployee : Emplyee
    {
        static int salaryPerYear=600000;
       
        public int Salary(int years)
        {
            return salaryPerYear * years;
        }
    }
}
