using System;

namespace Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student sasi= new Student();
            sasi.ID = 33;
            sasi.name = "sasi kumar";
            Console.WriteLine("his name is {0} ans his id is {1} and he should get {2} to pass",sasi.name,sasi.ID,sasi.PassMark);
           
        }
    }
    public class Student
    {
        private int Id;
        private string Name;
        private static int passMark=35;
        private string email { get;set;}
        private string city { get;set;}
        public int ID
        {
            get
            {
                return this.Id;
            }
            set
            {
                if (value<0)
                {
                    throw new Exception("Id cannot be Negative");
                }
                this.Id = value;
            }
        }
        public string name
        {
            get 
            { 
                if (this.Name == null)
                {
                    return "no name found";
                }
                return this.Name;        
                        
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("enter a name");
                }
                this.Name= value;
            }
        }
        public int PassMark
        {
            get { return passMark; }
        }
    }
}
