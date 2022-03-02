using System;

namespace Structs
{
    internal class Program
    {
       
        public struct Student
        {
            int id;
            int zipcode;
            double salary;
            // all the members of the struct has to be initialized in this way  
            public Student(int id, int zipcode, double salary)
            {
                this.id = id;
                this.zipcode = zipcode;
                this.salary = salary;
            }
            // all the members of the struct has to be initialized either in this way  
            public Student(int id, int zipcode)
            {
                this.id = id;
                this.zipcode = zipcode;
                this.salary = 3400.00;
            }
            // if you left any member of a struct uninitialzed it will give error  
            // code below will give error because the zipcode and salary field is left uninitialzed  
            //public Student(int id)  
            //{  
            // this.id = id;  
            //}  
            // struct can also have copy constructor but have to be fully initialzed  
            public Student(Student x)
            {
                this.id = x.id;
                this.zipcode = x.zipcode;
                this.salary = x.salary;
            }
            public void DisplayValues()
            {
                Console.WriteLine("ID: " + this.id.ToString());
                Console.WriteLine("Zipcode : " + this.zipcode.ToString());
                Console.WriteLine("Salary : " + this.salary.ToString());
            }
        }
        static void Main(string[] args)
        {
            Student stu = new Student(12, 201301, 4560.00);
            Student stu1 = new Student(stu);
            stu.DisplayValues();
            Console.WriteLine("Copy constructor values");
            stu1.DisplayValues();
           
        }
    
    }
}
