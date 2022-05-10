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
                if (Reader.HasRows)
                {
                    Console.WriteLine($"Employees that belong to {dname} are");
                    while (Reader.Read())
                    {
                       
                        Console.WriteLine(Reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine($"Department  {dname} is not found");
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
            Cmd.CommandText = "select top 1 * from Employee join Department on Employee.DeptNo=Department.DeptNo where DeptName=@DeptName order  by  Salary Desc";
            SqlParameter pDeptName = new SqlParameter();
            pDeptName.ParameterName = "@DeptName";
            pDeptName.SqlDbType = SqlDbType.VarChar;
            pDeptName.Direction = ParameterDirection.Input;
            pDeptName.Value = dname;
            Cmd.Parameters.Add(pDeptName);
            SqlDataReader Reader = Cmd.ExecuteReader();
            if (Reader.HasRows)
            {
                Console.WriteLine($"Person with max Salary in the Department  Is");
                while (Reader.Read())
                {
                    Console.WriteLine($"EmpNo:{Reader[0]}Empname:{Reader[1]}Salary:{Reader[2]}Designation:{Reader[4]}Department:{Reader[6]}");
                }
            }
            else
            {
                Console.WriteLine("Department Not Found");
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
               
                if (Reader.HasRows)
                {
                    Console.WriteLine($"Employees that belong to {location} are");
                    while (Reader.Read())
                    {
                        Console.WriteLine(Reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("There are no Employees in the location");
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
                while (Reader.Read())
                {
                    if (!Reader.IsDBNull(0))
                    {
                        Console.WriteLine($"Sum of Slaries of {dname} Department is ");
                        Console.WriteLine(Reader[0]);
                    }
                    else
                        Console.WriteLine("Department Not Found ");

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
