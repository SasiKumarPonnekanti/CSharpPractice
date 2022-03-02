using System;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.EvenNumbers();
            OddNumbers();
        }
        //Instance Method
        public void EvenNumbers()
        {
            int n = 0;
            Console.WriteLine("Even numbers less than 20");
            while (n< 20)
            {
                if( n%2==0)
                {
                    Console.WriteLine(n);
                   
                }
                n++;
                 
            }
        }
        //Static method
        public static void OddNumbers()
        {
            Console.WriteLine("Odd Numbers less than 20");
            int n = 0;
            while(n<20)
            {
                if (n%2 !=0)
                {
                    Console.WriteLine(n);
                }
                n++;
            }
        }

    }
}
