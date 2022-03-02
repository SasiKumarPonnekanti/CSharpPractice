using System;

namespace Cs.Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Extending math class");
            math m = new math();
            double z = m.GetPower(2, 4);
            Console.WriteLine(z);
            //double t = Extendedmath.GetPower(m,2, 3);
            int n = m.Factorial(5);
            Console.WriteLine(n);
           

        }
    }
    public class math
    {
        
    }
    public static class Extendedmath
    {
        public static double GetPower(this math s,double x,double y)
        {
            return Math.Pow(x,y);
        }
        public static int Factorial(this math s,int x)
        {
            int res =1;
            for(int i = x; i > 0; i--)
            {
                res = res * i;
            }
            return res;
        }
        public static double GetCubeRoot(this math s ,int x)
        {
            return Math.Pow(x, 0.3);
        }
    }
}