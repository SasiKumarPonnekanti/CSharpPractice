using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var c = new test() { age=22,name="",id=2};
            var d = new test() { age = 42, name = "", id = 4 };

            var k  = c.GetAge();
            Console.WriteLine(k);
        }
    }

    public class test
    {
        public int id { get; set; }

        public string name { get; set; }    

        public int age { get; set; }    

        public int GetAge()
        {
            return this.age;
        }
    }
}
