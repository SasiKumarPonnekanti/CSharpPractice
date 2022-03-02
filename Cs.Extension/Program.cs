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
            double c = m.GetCubeRoot(64);
            Console.WriteLine(Math.Round(c));
            string s = "sasi";
            Console.WriteLine(s.ReverseString());


        }
    }
    public class math
    {
         static math()
        {
            Console.WriteLine("static constructer is being tested");
        }
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
            return Math.Pow(x, 0.33);
        }
        
        public static int SentenceExtract(this string s ,string str1)
        {
            int count = 0;
            foreach (string i in str1.Split('.'))
            {
                Console.WriteLine(i);
                count++;
            }
            return count;
        }
        public static int getCountOfChar(this string s ,char c, string str1)
        {
            int coun = 0;
            foreach (char ch in str1)
            {
                if (ch == c)
                {
                    coun++;
                }
            }
            return coun;
        }
        public static string ReverseString(this string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

    }
}