using System;

namespace ConditionalStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Progaramme that covers ConditionalStatements
            //Declaring Variables needed
            int a, b, c;
            double d;
            string cal;
            Console.WriteLine("Enter first Number");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            b = Convert.ToInt32(Console.ReadLine());
            // Calling Add Sub Mul Div Sqr methods
            c = Add(a, b);
            Console.WriteLine("Addition answer is" + c);
            c = Sub(a, b);
            Console.WriteLine("Subtraction Answer is " + c);
            c = Mul(a, b);
            Console.WriteLine("multiplication Answer is" + c);
            d = Div(a, b);
            Console.WriteLine("Division Answer is" + d);
            c = Sqr(a);
            Console.WriteLine("sqare  of firstnumber is" + c);
            //Take Opeartion tobe performed as a string like add, sub , mul
            Console.WriteLine("Enter Operation Add,Mul sub,div,sqr");
            cal = Console.ReadLine();
            d = Method(a, b, cal);
            Console.WriteLine($" The answer for {cal} is " + d);
        }

        static int Add(int x, int y)
        {
            int z;
            if (x <= 0 || y <= 0)
            {
                return 0;
            }
            else
            {
                z = x + y;
            }
            return z;

        }
        static int Sub(int x, int y)
        {
            int z;
            if (x <= 0 || y <= 0)
            {
                return 0;
            }
            else
            {
                z = x - y;
            }
            return z;
        }
        static int Mul(int x, int y)
        {
            int z;
            if (x <= 0 || y <= 0)
            {
                return 0;
            }
            else
            {
                z = x * y;
            }
            return z;
        }
        static double Div(int x, int y)
        {
            double z;
            if (y <= 0 || x <= 0)
            {
                return 0;
            }
            else
            {
                z = (double)x / y;
            }
            return z;
        }
        static int Sqr(int x)
        {
            int z;
            if (x <= 0)
            {
                return 0;
            }
            else
            {
                z = x * x;
            }
            return z;
        }
        static double Method(int x, int y, string st)
        {
            int z = 0;
            double d;
            switch (st.ToUpper())
            {
                case "ADD":
                    z = Add(x, y);
                    break;
                case "SUB":
                    z = Sub(x, y);
                    break;
                case "MUL":
                    z = Mul(x, y);
                    break;
                case "DIV":
                    d = Div(x, y);
                    return d;

                default:
                    Console.WriteLine("Enter Valid Input");
                    break;

            }
            return z;
        }

    }
}

