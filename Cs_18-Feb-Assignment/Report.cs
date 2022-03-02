using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Cs_18_Feb_Assignment
{
    internal class Report
    {
        //Declaring Connection and cammand Object
        SqlConnection Conn;
        SqlCommand Cmd;
        public Report()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=SSPI");
        }
        
        public void GetAllEmployeesByDeptName(string dname)

        {
            try
            {
                Cmd = new SqlCommand();
                Conn.Open();
                Cmd.Connection = Conn;
                Cmd.CommandText = "select * from Employee join Department on  Employee.DeptNo = DEpartment.DeptNo where DeptName=@DeptName";
                SqlParameter pDeptName = new SqlParameter();
                pDeptName.ParameterName = "@DeptName";
                pDeptName.SqlDbType = SqlDbType.VarChar;
                pDeptName.Direction = ParameterDirection.Input;
                pDeptName.Value = dname;
                Cmd.Parameters.Add(pDeptName);
                SqlDataReader Reader = Cmd.ExecuteReader();
                Console.WriteLine($"Employees that belong to {dname} are");
                while (Reader.Read())
                {
                    Console.WriteLine(Reader[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

        }

        public void GetAllEmployeesWithMaxSalByDeptName(string dname)
        {
            Cmd = new SqlCommand();
            Conn.Open();
            Cmd.Connection= Conn;
            Cmd.CommandText = "select max(salary) ,EmpName from Employee join Department on  Employee.DeptNo = DEpartment.DeptNo where DeptName=@DeptName";
            SqlParameter pDeptName = new SqlParameter();
            pDeptName.ParameterName = "@DeptName";
            pDeptName.SqlDbType = SqlDbType.VarChar;
            pDeptName.Direction = ParameterDirection.Input;
            pDeptName.Value = dname;
            Cmd.Parameters.Add(pDeptName);
            SqlDataReader Reader = Cmd.ExecuteReader(); 
            while(Reader.Read())
            {
                Console.WriteLine($"{Reader[0]}");
            }

        }

        public void GetAllEmployeesByLocation(string location)
        {
            try
            {
                Cmd = new SqlCommand();
                Conn.Open();
                Cmd.Connection = Conn;
                Cmd.CommandText = "select * from Employee join Department on  Employee.DeptNo = Department.DeptNo where Location=@Location";
                SqlParameter pLocation = new SqlParameter();
                pLocation.ParameterName = "@Location";
                pLocation.SqlDbType = SqlDbType.VarChar;
                pLocation.Direction = ParameterDirection.Input;
                pLocation.Value = location;
                Cmd.Parameters.Add(pLocation);
                SqlDataReader Reader = Cmd.ExecuteReader();
                Console.WriteLine($"Employees that belong to {location} are");
                while (Reader.Read())
                {
                    Console.WriteLine(Reader[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }


        }

        public void GetSumSalaryByDeptName(string dname)
        {
            try
            {
                Cmd = new SqlCommand();
                Conn.Open();
                Cmd.Connection = Conn;
                Cmd.CommandText = "select sum(salary) as SUM from Employee join Department on Employee.DeptNo = Department.DeptNo where DeptName=@DeptName";
                SqlParameter pDeptName = new SqlParameter();
                pDeptName.ParameterName = "@DeptName";
                pDeptName.SqlDbType = SqlDbType.VarChar;
                pDeptName.Direction = ParameterDirection.Input;
                pDeptName.Value = dname;
                Cmd.Parameters.Add(pDeptName);
                SqlDataReader Reader = Cmd.ExecuteReader();
                Console.WriteLine($"Sum of Slaries of {dname} Department is ");
                while (Reader.Read())
                {
                    Console.WriteLine(Reader[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

        }






    }
}
