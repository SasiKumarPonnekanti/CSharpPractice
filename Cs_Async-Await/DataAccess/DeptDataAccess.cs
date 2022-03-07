using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Cs_Async_Await.models;

namespace Cs_Async_Await.DataAccess
{
    internal class DeptDataAccess:IDisposable
    {
        SqlConnection _connection;
        SqlCommand cmdDept;
        public DeptDataAccess()
        {
            _connection = new SqlConnection("Data Source =.; Initial Catalog = sample1; Integrated Security = SSPI"); 
        }
        public async Task<List<Department>> GetAllDeptDataAsync()
        {
            List<Department> depts = new List<Department>();
            try
            {
                cmdDept = new SqlCommand();
                _connection.Open();
                cmdDept.Connection = _connection;

                cmdDept.CommandText = "Select * from Department";
                var readerDept = await cmdDept.ExecuteReaderAsync();

                while (readerDept.Read())
                {
                    depts.Add(new Department()
                    {
                        DeptNo = Convert.ToInt32(readerDept["DeptNo"]),
                        DeptName = readerDept["DeptName"].ToString(),
                        Location= readerDept["Location"].ToString(),
                        Capacity = Convert.ToInt32(readerDept["Capacity"]),

                    });
                }
                readerDept.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                _connection.Close();
            }
          
            return depts;            
        }
        public async Task<Department> GetDeptByIdAsync(int id)
        {
            Department department = new Department();
            try
            {

                cmdDept = new SqlCommand();
                _connection.Open();
                cmdDept.Connection = _connection;
                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = id;
                cmdDept.Parameters.Add(pDeptNo);
                

                cmdDept.CommandText = "Select * from Department where DeptNo=@DeptNo";
                var readerDept = await cmdDept.ExecuteReaderAsync();
                while (readerDept.Read())
                {
                    department.DeptNo = Convert.ToInt32(readerDept["DeptNo"]);
                    department.DeptName = readerDept["DeptName"].ToString();
                    department.Location = readerDept["Location"].ToString();
                    department.Capacity = Convert.ToInt32(readerDept["Capacity"]);
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
           
            return department;
        }
        public async void UpdateDeptAsync(Department department)
        {
            try
            {
                
                _connection.Open();
                cmdDept.Connection = _connection;

                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = department.DeptNo;
                cmdDept.Parameters.Add(pDeptNo);

                SqlParameter pDeptName = new SqlParameter();
                pDeptName.ParameterName = "@DeptName";
                pDeptName.SqlDbType= SqlDbType.VarChar;
                pDeptName.Direction = ParameterDirection.Input;
                pDeptName.Value = department.DeptName;
                cmdDept.Parameters.Add(pDeptName);

                SqlParameter pLocation = new SqlParameter();
                pLocation.ParameterName = "@Location";
                pLocation.SqlDbType = SqlDbType.VarChar;
                pLocation.Direction = ParameterDirection.Input;
                pLocation.Value = department.Location;
                cmdDept.Parameters.Add(pLocation);

                SqlParameter pCapacity = new SqlParameter();
                pCapacity.ParameterName = "@Capacity";
                pCapacity.SqlDbType = SqlDbType.Int;
                pCapacity.Direction = ParameterDirection.Input;
                pCapacity.Value = department.Capacity;
                cmdDept.Parameters.Add(pCapacity);



                cmdDept.CommandText = "Update Department Set DeptName=@DeptName, Location=@Location, Capacity=@Capacity where DeptNo=@DeptNo";
                int res =await cmdDept.ExecuteNonQueryAsync();
                Console.WriteLine(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
               
            }
            

        }
        public async void CreateDeptAsync(Department department)
        {

            try
            {

                cmdDept = new SqlCommand();
                _connection.Open();
                cmdDept.Connection = _connection;

                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = department.DeptNo;

                SqlParameter pCapacity = new SqlParameter();
                pCapacity.ParameterName = "@Capacity";
                pCapacity.SqlDbType = SqlDbType.Int;
                pCapacity.Direction = ParameterDirection.Input;
                pCapacity.Value = department.Capacity;

                SqlParameter pLocation = new SqlParameter();
                pLocation.ParameterName = "@Location";
                pLocation.SqlDbType = SqlDbType.VarChar;
                pLocation.Direction = ParameterDirection.Input;
                pLocation.Value = department.Location;

                SqlParameter pDeptName = new SqlParameter();
                pDeptName.ParameterName = "@DeptName";
                pDeptName.SqlDbType = SqlDbType.VarChar;
                pDeptName.Direction = ParameterDirection.Input;
                pDeptName.Value = department.DeptName;


                // Add parameters into the Parameters Collection of the Command object
                cmdDept.Parameters.Add(pDeptNo);
                cmdDept.Parameters.Add(pDeptName);
                cmdDept.Parameters.Add(pLocation);
                cmdDept.Parameters.Add(pCapacity);


                cmdDept.CommandText = "Insert into Department Values (@DeptNo,@DeptName,@Location,@Capacity)";


                int res = await cmdDept.ExecuteNonQueryAsync();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            
         

        }

        public async Task<int>  DeleteDeptAsync(int id)
        {
            int res=0;
            try
            {
                cmdDept = new SqlCommand();
                _connection.Open();
                cmdDept.Connection = _connection;
                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = id;



                // Add parameters into the Parameters Collection of the Command object
                cmdDept.Parameters.Add(pDeptNo);


                cmdDept.CommandText = "Delete from Department where DeptNo=@DeptNo";
                res = await cmdDept.ExecuteNonQueryAsync();
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

        public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(this);           
        }
    }
    
}
