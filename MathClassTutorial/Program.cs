using System;

namespace MathClassTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int c = Math.Min(2, 3);
            Console.WriteLine("Absolute value of {0} = {1}",-2, Math.Abs(-2));
            int remainder = Math.DivRem(4, 5, out int quotient);
            Console.WriteLine($"Quotient is ={ quotient}");
            Console.WriteLine($"Remainder is ={ remainder}");
            Console.WriteLine("AntiCosine value of {0} : {1}", 0.23, Math.Acos(0.23));
            double res;
            res = Math.Pow(5, 2);
            Console.WriteLine("Math.Pow(5,2) = " + res);
            double e = Math.E;
            Console.WriteLine("Math.E = " + e);
            double a = 70;
            double b = (a * (Math.PI)) / 180;
            Console.WriteLine($" cosine value {Math.Cos(b)}");
            Console.WriteLine($" sine value {Math.Sin(b)}");
            Console.WriteLine($" tangent value {Math.Tan(b)}");
            Decimal dec = 45.89511m;
            Decimal dec2 = 54569.478021m;
            Console.WriteLine($"Integral Part of dec is {Math.Truncate(dec)}");
            Console.WriteLine($"integral prt of dec 2 is {Math.Truncate(dec2)}");
            Console.WriteLine($"Expnent power of 10{Math.Exp(10.0)}");
            Console.WriteLine($"Exponent of 15.57 {Math.Exp(15.57)}");
        }
    }
}
