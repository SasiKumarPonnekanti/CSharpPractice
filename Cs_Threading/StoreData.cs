using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Cs_Threading
{
    internal class StoreData
    {
        public void WriteDataToDb(Employee emp)
        {
            SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=SSPI");
            try
            {
                
                Conn.Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Employee Values({emp.EmpNo}, '{emp.EmpName}','{emp.Salary}',{emp.DeptNo},'{emp.Designation}')";

                int res = Cmd.ExecuteNonQuery();
                if (res != 0)
                {

                    Console.WriteLine("Db Entry Suceess");
                }
            }
            catch (Exception ex)
            {
              
                Console.WriteLine(ex.Message);
                Thread.CurrentThread.Abort();
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }                            
            }
        }
        public void WriteDataToFile(Employee emp)
        {
            string path = @"C:\Users\Coditas\Desktop\EmpData.txt";
            if (!File.Exists(path))
            {
                Thread.CurrentThread.Abort();
            }
            else
            {


                StreamWriter writer = File.AppendText(path);
                writer.WriteLine($"==================\nEmpNum:{emp.EmpNo}\nName:{emp.EmpName}\n" +
                    $"DepartmentId:{emp.DeptNo}\nDesignation:{emp.Designation}\n" +
                    $"Salary:{emp.Salary}");
                Console.WriteLine("Data Is Stored to File");
                writer.Close();
            }
        }

        public void PrintData(Employee emp)
        {
            Console.WriteLine($"EmpNo:{emp.EmpNo} EmpName:{emp.EmpName} Designation:{emp.Designation} Salary:{emp.Salary}");
        }








    }
}
