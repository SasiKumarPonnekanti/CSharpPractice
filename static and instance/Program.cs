using System;

namespace static_and_instance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double result;
            Console.WriteLine("Hello World!");
            Console.WriteLine("enter radius ");
            int radius = Convert.ToInt32(Console.ReadLine());
            Circle a = new Circle(radius);
            result = a.Area();
            Console.WriteLine(result);
            Circle.printpi();
        }
    }
    class Circle
    {
        static float pi = 3.14f;
        int rad;
        public  Circle(int rad)
        {
            this.rad = rad;
        }
        public double Area()
        {
            return pi * rad * rad;
        }
        public static void printpi()
        {
            Console.WriteLine("the pi value is {0}",pi);
        }
    }
}
