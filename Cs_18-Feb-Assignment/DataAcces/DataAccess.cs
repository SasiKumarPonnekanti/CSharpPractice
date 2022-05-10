using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs_18_Feb_Assignment.Models;
using System.Data;
using System.Data.SqlClient;
namespace Cs_18_Feb_Assignment.DataAcces
{
    internal class DataAccess : IDataAccess<Employee, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public DataAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=SSPI");
        }
        void IDataAccess<Employee, int>.Create(Employee entity)
        {
           
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Employee Values({entity.EmpNo}, '{entity.EmpName}','{entity.Salary}',{entity.DeptNo},'{entity.Designation}')";
               
                int res = Cmd.ExecuteNonQuery();
                if (res != 0) 
                {
                  
                    Console.WriteLine("Entry Suceess");
                }
                
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Data);
            }
            finally 
            // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
           
        }

        Employee IDataAccess<Employee, int>.Delete(int id)
        {
            Employee emp = new Employee();
            try
            {

                Conn.Open();
                Cmd= new SqlCommand();
                Cmd.Connection=Conn;
                Cmd.CommandText = "Delete From Employee where EmpNo=@EmpNo";

                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = id;



                // Add parameters into the Parameters Collection of the Command object
                Cmd.Parameters.Add(pEmpNo);

                // Call the execute method
                int res = Cmd.ExecuteNonQuery();

                if (res == 0)
                {
                    emp = null;
                    Console.WriteLine("Employee Not Found to Delete");
                }
                else
                {
                    Console.WriteLine(" Delete Success");
                }
            }
           
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            return emp;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.GetData()
        {
            List<Employee> Employees = new List<Employee>();
            try
            {
               
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Employee";
                SqlDataReader Reader = Cmd.ExecuteReader();

               
                while (Reader.Read())
                {
                    
                    Employees.Add(
                          new Employee()
                          {
                              EmpNo = Convert.ToInt32(Reader["EmpNo"]),
                              EmpName = Reader["EmpName"].ToString(),
                              Designation = Reader["Designation"].ToString(),
                              Salary = Convert.ToInt32(Reader["Salary"]),
                              DeptNo = Convert.ToInt32(Reader["DeptNo"])
                          }
                        );
                }
                Reader.Close();
               
                Conn.Close();
            }
            catch (SqlException ex)
            {


                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            finally // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            return Employees;
        }

        Employee IDataAccess<Employee, int>.GetData(int id)
        {
            Employee employee = new Employee();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection= Conn;
                Cmd.CommandText = "Select * from Employee where EmpNo = @EmpNo";
                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = id;

                Cmd.Parameters.Add(pEmpNo);

                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    Console.WriteLine($"{Reader["EmpNo"]}");
                    employee.EmpNo = Convert.ToInt32(Reader["EmpNo"]);
                    employee.EmpName = Reader["EmpName"].ToString();
                    employee.Designation = Reader["Designation"].ToString();
                    employee.Salary = Convert.ToInt32(Reader["Salary"]);
                    employee.DeptNo = Convert.ToInt32(Reader["DeptNo"]);
                }
                Reader.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            return employee;
        }

        void IDataAccess<Employee, int>.Update(int id, Employee entity)
        {
            
            try
            {
                
                    Conn.Open();
                    Cmd = new SqlCommand();
                    Cmd.Connection = Conn;
                    Cmd.CommandText = "Update Employee Set EmpName=@EmpName,Salary=@Salary,DeptNo=@DeptNo,Designation=@Designation where EmpNo=@EmpNo";
                    SqlParameter pEmpName = new SqlParameter();
                    pEmpName.ParameterName = "@EmpName";
                    pEmpName.SqlDbType = SqlDbType.VarChar;
                    pEmpName.Direction = ParameterDirection.Input;
                    pEmpName.Size = 100;
                    pEmpName.Value = entity.EmpName;

                    SqlParameter pSalary = new SqlParameter();
                    pSalary.ParameterName = "@Salary";
                    pSalary.SqlDbType = SqlDbType.Int;
                    pSalary.Direction = ParameterDirection.Input;
                    pSalary.Value = entity.Salary;

                    SqlParameter pDeptNo = new SqlParameter();
                    pDeptNo.ParameterName = "@DeptNo";
                    pDeptNo.SqlDbType = SqlDbType.Int;
                    pDeptNo.Direction = ParameterDirection.Input;
                    pDeptNo.Value = entity.DeptNo;

                    SqlParameter pDesignation = new SqlParameter();
                    pDesignation.ParameterName = "@Designation";
                    pDesignation.SqlDbType = SqlDbType.VarChar;
                    pDesignation.Size = 100;
                    pDesignation.Direction = ParameterDirection.Input;
                    pDesignation.Value = entity.Designation;

                    SqlParameter pEmpNo = new SqlParameter();
                    pEmpNo.ParameterName = "@EmpNo";
                    pEmpNo.SqlDbType = SqlDbType.Int;
                    pEmpNo.Direction = ParameterDirection.Input;
                    pEmpNo.Value = id;
                    Cmd.Parameters.Add(pEmpNo);
                    Cmd.Parameters.Add(pEmpName);
                    Cmd.Parameters.Add(pDesignation);
                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pSalary);
                    int res = Cmd.ExecuteNonQuery();

                    if (res == 0)
                    {
                        Console.WriteLine("Employee Not Found to Delete");
                    }
                    else
                    {
                        Console.WriteLine("Update Success");
                        
                    }              
               
            }

            
            catch(Exception ex)
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
