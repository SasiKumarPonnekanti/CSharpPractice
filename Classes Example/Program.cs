using System;

namespace Classes_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassExample2 p = new ClassExample2();
            p.printmethod();
            
        }
    }
    class ClassExample2
    {
        string Firstname;
        string SecondName;
        public ClassExample2() 
        {

        }
        public  void printmethod()
        {
            Console.WriteLine("printing method");
        }
    }
}
