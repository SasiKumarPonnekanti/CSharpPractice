using System;

namespace DataTyoeConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Conversion of Int to Double (Implicit)
            int i = 10;
            double d = i;
            Console.WriteLine(d);

            // Conversion of Double to Int (explicit)
            double a = 20.45;
            int b = (int)a;
            Console.WriteLine(b);

            // Conversion Methods
            int r = 34;
            double g = 45.65;
            bool myBool = true;

            Console.WriteLine(Convert.ToString(r));
            Console.WriteLine(Convert.ToInt32(d));
            Console.WriteLine(Convert.ToInt64(r));
            Console.WriteLine(Convert.ToString(myBool));
        }
    }
}
