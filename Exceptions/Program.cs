using System;
using System.IO;
namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    int a;
                    int b;
                    a = Convert.ToInt32(Console.ReadLine());
                    b = Convert.ToInt32(Console.ReadLine());
                    int c = a / b;
                }
                catch (Exception ex)
                {

                    string filepath = @"C:\Users\Coditas\Desktop\llogs.txt";
                    if (File.Exists(filepath))
                    {
                        StreamWriter sw = new StreamWriter(filepath);
                        sw.Write(ex.Message);
                        sw.Close();
                    }
                    else
                    {
                        throw new FileNotFoundException("file not found", ex);
                    }
                }

            }
            catch (Exception exce)
            {
                Console.WriteLine(exce.GetType().Name);
                Console.WriteLine(exce.InnerException.GetType().Name);
            }
        }
    }
}
