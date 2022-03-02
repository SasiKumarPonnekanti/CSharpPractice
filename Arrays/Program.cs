using System;
using System.Linq;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] citi = { "Guntur", "Hyderabad", "pune", "Mumbai", "Delhi", "Chennai" };
            Console.WriteLine("Accessing Array Element....!");
            Console.WriteLine(citi[2]); // Access Array Element
            Console.WriteLine(" ");
            Console.WriteLine("Print All Element from Array");
            foreach (string i in citi)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
            Console.WriteLine("Array Element Changed");
            citi[0] = "Bengalore";    //Changing Array element
            Console.WriteLine(citi[0]);

            Console.WriteLine("");
            Console.WriteLine("Length of the Array is :");
            Console.WriteLine(citi.Length);   // We can print Array Length

            Console.WriteLine("");
            Console.WriteLine("Sorting the array by Alphabatically  :");
            Array.Sort(citi);     // Sorting the array by Alphabatically 
            foreach (string i in citi)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(" ");
            int[] numbers = { 5, 36, 23, 45, 15, 92, -5, 3, 33 };
            int max = numbers.Max();
            foreach (int num in numbers)
            {
                Console.Write(num + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("=================================");

            Console.WriteLine("Max Value in Array :" + max);
        }
    }
}
