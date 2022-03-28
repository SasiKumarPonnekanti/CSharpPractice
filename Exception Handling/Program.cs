using System;
using System.IO;

namespace Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            try
            {
                
                try
                {
                    throw new Exception("Notfound");
                }
                catch(Exception ex)
                {
                    throw new Exception("File not found again",);
                }
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
   
}
