using System;

namespace Method_parameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int k = 0;
            int sum, prod;
            int[] numbers = new int[3];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;


            Calculate(10, 20,out  sum,out prod);

            simple(i);
            Console.WriteLine(i);
            Simple(ref k);
            Console.WriteLine(k);
            Console.WriteLine(sum);
            Console.WriteLine(prod);
            paramsMethod();
        }
        public static void simple(int j)
        {
            j = 101;
        }
        public static void Simple(ref int j)
        {
            j = 101;
        }
        public static void Calculate(int a,int b,out int  sum,out int prod)
        {
            sum = a + b;
            prod = a * b;

        }
        public static void paramsMethod(params int[] numbers)
        {
            Console.WriteLine("No of elements is {0}",numbers.Length);
        }

    }
}
