using System;
using Namespace_Example2;

namespace Namespace_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Namespace_Example2.Example.Method();
        }
    }
}
namespace Namespace_Example2
{
    class Example
    {
       public static void Method()
        {
            Console.WriteLine("Welcome to another name space");
        }
    }
}