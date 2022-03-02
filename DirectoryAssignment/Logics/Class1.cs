using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryAssignment.Logics
{
    internal class DirectoryOperations
    {

       public void ReadAllFilesOfDict(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                //var files = (from file in Directory.GetFiles(dirName,"*.cs",SearchOption.AllDirectories) select file).ToList();
               var files = Directory.GetFiles(dirName,"",SearchOption.AllDirectories).ToList();
               // var files = Directory.GetFiles(dirName, "*.cs", SearchOption.AllDirectories).ToList();
               // If i Want to Read only Files Of cs. Extension above line can be Used
                //Get all Files in that Dictionary and Saving to list named Files
                int c = 1;
                //  Iterating over List To display File names and also Displaying  anumber which refers to index in list
                //  so that based on index we can read file we require 
                foreach(var file in files)
                {
                    Console.WriteLine($"{c}=={file}");
                    c++;
                }
                // Taking choice from user
                Console.WriteLine("Enter Your Choice of File to be read");
                int choice = Convert.ToInt32(Console.ReadLine());
                //Getting path from list based on users choice
                string path = files[choice].ToString();
                FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                //Getting the data
                string Data = sw.ReadToEnd();
                //Printing the Obtained data
                Console.WriteLine(Data);
                FileInfo Fi = new FileInfo(path);
                //Displaying File Info using FileInfo Class
                Console.WriteLine($"FileName={Fi.Name}|Extension={Fi.Extension}|Size={Fi.Length} Bytes|Last Modified{Fi.LastWriteTime}");
                sw.Close();
                fs.Close();
              
            }
            else
            {
                Console.WriteLine($"Directory {dirName} is Not present");
            }
        }
    }
}
