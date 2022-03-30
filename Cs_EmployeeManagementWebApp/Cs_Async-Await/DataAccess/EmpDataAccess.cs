using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Cs_Async_Await.models;

namespace Cs_Async_Await.DataAccess
{
    internal class EmpDataAccess:IDisposable
    {
        SqlConnection _connection;
        SqlCommand cmdEmp;
        public EmpDataAccess()
        {
            _connection = new SqlConnection("Data Source =.; Initial Catalog = sample1; Integrated Security = SSPI");
            

        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                _connection.Open();
                cmdEmp = new SqlCommand();
                cmdEmp.Connection = _connection;
                cmdEmp.CommandText = "select * from Employee";
                var reader = await cmdEmp.ExecuteReaderAsync();
                while (reader.Read())
                {
                    employees.Add(new Employee()
                    {
                        EmpNo = Convert.ToInt32(reader["EmpNo"]),
                        EmpName = reader["EmpName"].ToString(),
                        Salary = Convert.ToInt32(reader["Salary"]),
                        Designation = reader["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(reader["DeptNo"]),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return employees;
        }

        public async Task<Employee> GetEmpByIdAsync(int Id)
        {
            Employee emp = new Employee();
            try
            {
                _connection.Open();
                cmdEmp = new SqlCommand();
                cmdEmp.Connection = _connection;


                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = Id;
                cmdEmp.Parameters.Add(pEmpNo);

                cmdEmp.CommandText = "select * from Employee where EmpNo=@EmpNo";
                var reader = await cmdEmp.ExecuteReaderAsync();
                while (reader.Read())
                {

                    emp.EmpNo = Convert.ToInt32(reader["EmpNo"]);
                        emp.EmpName = reader["EmpName"].ToString();
                    emp.Salary = Convert.ToInt32(reader["Salary"]);
                    emp.Designation = reader["Designation"].ToString();
                    emp.DeptNo = Convert.ToInt32(reader["DeptNo"]);
                   
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return emp;
        }
        public async Task<int> CreateEmpAsync(Employee emp)
        {
            int res = 0;
            try
            {
                _connection.Open();
                cmdEmp = new SqlCommand();
                cmdEmp.Connection = _connection;

                SqlParameter pEmpName = new SqlParameter();
                pEmpName.ParameterName = "@EmpName";
                pEmpName.SqlDbType = SqlDbType.VarChar;
                pEmpName.Direction = ParameterDirection.Input;
                pEmpName.Size = 100;
                pEmpName.Value = emp.EmpName;

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@Salary";
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Direction = ParameterDirection.Input;
                pSalary.Value = emp.Salary;

                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = emp.DeptNo;

                SqlParameter pDesignation = new SqlParameter();
                pDesignation.ParameterName = "@Designation";
                pDesignation.SqlDbType = SqlDbType.VarChar;
                pDesignation.Size = 100;
                pDesignation.Direction = ParameterDirection.Input;
                pDesignation.Value = emp.Designation;

                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = emp.EmpNo;
                cmdEmp.Parameters.Add(pEmpNo);
                cmdEmp.Parameters.Add(pEmpName);
                cmdEmp.Parameters.Add(pDesignation);
                cmdEmp.Parameters.Add(pDeptNo);
                cmdEmp.Parameters.Add(pSalary);
                cmdEmp.CommandText = "insert into Employee values (@EmpNo,@Empname,@Salary,@DeptNo,@Designation)";
                res = await cmdEmp.ExecuteNonQueryAsync();
                
                
            }
           
            catch(Exception ex)
            {
                if (ex.Message.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint "))
                {
                    Console.WriteLine("Please Check the Department You Enterd " +
                        "It is Not Found in DB");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
            finally
            {
                _connection.Close();
            }
            return res;
        }

        public async Task<int> DeleteEmpAsync(int Id)
        {
            int res = 0;
            try
            {
                _connection.Open();
                cmdEmp = new SqlCommand();
                cmdEmp.Connection = _connection;
                cmdEmp.CommandText = "Delete from Employee where EmpNo=@EmpNo";


                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = Id;
                cmdEmp.Parameters.Add(pEmpNo);
                res = await cmdEmp.ExecuteNonQueryAsync();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return res;
        }

        public async Task<int> UpdateEmpAsync(Employee emp)
        {
            int res = 0;
            try
            {

                _connection.Open();
                cmdEmp.Connection = _connection;

                cmdEmp.CommandText = $"Update Employee Set EmpName='{emp.EmpName}',DeptNo={emp.DeptNo}, Designation='{emp.Designation}', Salary={emp.Salary} where EmpNo={emp.EmpNo}";
                res = await cmdEmp.ExecuteNonQueryAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();

            }
            return res;
        }
            public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
