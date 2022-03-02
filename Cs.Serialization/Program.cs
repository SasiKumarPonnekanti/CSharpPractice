using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cs.Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Serialization");
            FileStream fs = null;
            BinaryFormatter bf = new BinaryFormatter();
            Employees emps = new Employees();
            foreach(var e in emps)
            {
                fs = new FileStream(@$"C:\Users\Coditas\Desktop\payslips\{e.EmpNo}.txt", FileMode.CreateNew);
                bf.Serialize(fs, e);
               
                fs.Close();

            }


        }
    }
}
