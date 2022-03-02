using System;
using System.IO;

namespace Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StreamReader streamReader = null;
            try
            {
                 streamReader = new StreamReader(@"C:\Users\Coditas\DocumentAs\C sharp.txt");
                Console.WriteLine(streamReader.ReadToEnd());
                streamReader.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("plese check the file");

            }
            catch(Exception ex)
            {
            }
            finally
            {
                streamReader.Close();
            }
        }
    }
   
}
