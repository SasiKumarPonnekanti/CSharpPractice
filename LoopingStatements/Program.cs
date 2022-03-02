using System;

namespace LoopingStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //While loop
            int a = 10;

    
            while (a < 20)
            {
                Console.WriteLine("value of a: {0}", a);
                a++;
            }
            a = 10;

            //Do while loop
            do
            {
                Console.WriteLine("value of a: {0}", a);
                a = a + 1;
            }
            while (a < 20);






            //for loop
            int n = 5, sum = 0;

            for (int i = 1; i <= n; i++)
            {
                // sum = sum + i;
                sum += i;
            }

            Console.WriteLine("Sum of first {0} natural numbers = {1}", n, sum);
            //Foreach loop
            char[] myArray = { 'H', 'e', 'l', 'l', 'o' };

            foreach (char ch in myArray)
            {
                Console.WriteLine(ch);
            }
        }
    }
}
