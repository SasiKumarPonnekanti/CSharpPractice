using System;

namespace Interfaces
{

    interface ICustomer
    {
        void print();
       
    }
    class Program
    { 
        public static void Main(string[] args)
        {
            
        }
    }
    class Customer: ICustomer
    {
       public void  print()
        {
            Console.WriteLine("Oooooooo");
        }
    }
}
