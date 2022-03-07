using System;
using Employee_App.models;
using System.Collections.Generic;

namespace Employee_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("welcome to Coditas");
                Console.WriteLine("Enter Your choice");
                Console.WriteLine("1.Add Employee");
                Console.WriteLine("2.Update Employee");
                Console.WriteLine("3.Delete Employee");
                Console.WriteLine("4.Search employee");
                Console.WriteLine("5.Display employeelist");
                int choice = Convert.ToInt32(Console.ReadLine());
                Client client = new Client();
                switch (choice)
                {
                    case 1:
                        client.Add();
                        break;
                    case 2:
                        client.Update();
                        break;
                    case 3:
                        client.Delete();
                        break;
                    case 4:
                        client.Search();
                        break;
                    case 5:
                        client.Display();
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

            }
            while (true);
        }
        
       
    }
}
