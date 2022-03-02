using System;
using DirectoryAssignment.Logics;

namespace DirectoryAssignment
{
    internal class Program
    {
        static DirectoryOperations DiOp = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DiOp = new DirectoryOperations();
            DiOp.ReadAllFilesOfDict(@"C:\Users\Coditas\Desktop\payslips");
            //calling Read all Files method and passing path as argument
        }
    }
}
