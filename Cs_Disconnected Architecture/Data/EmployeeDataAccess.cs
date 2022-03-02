using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs_Disconnected_Architecture.Models;
using System.Data;
using System.Data.SqlClient;

namespace Cs_Disconnected_Architecture.Data
{
    internal class EmployeeDataAccess : IDataAccess<Employee, int>
    {

        SqlConnection Conn;

        public EmployeeDataAccess()
        {

            Conn = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=SSPI");
            
        }
        void IDataAccess<Employee, int>.Create(Employee entity)
        {
            try
            {
                SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
                DataSet Ds = new DataSet();
                AdEmp.Fill(Ds, "Employee");

                DataRow DrNew = Ds.Tables["Employee"].NewRow();
                // 2. Set data for all columns for the row

                DrNew["EMpNo"] = entity.EmpNo;
                DrNew["EmpName"] = entity.EmpName;
                DrNew["Salary"] = entity.Salary;
                DrNew["DeptNo"] = entity.DeptNo;
                DrNew["Designation"] = entity.Designation;
                // 3. Add the Row into the Table
                Ds.Tables["Employee"].Rows.Add(DrNew);
                // 4. Define a Command Builder to Ask the Adpater to Update Record in Database Table
                SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdEmp);
                // 5. Call Update
                AdEmp.Update(Ds, "Employee");
            }
            catch (Exception ex)
            {
                Console.WriteLine("May Be Employee Is Already Present Try Again");
            }
        }

        Employee IDataAccess<Employee, int>.Delete(int id)
        {
            Employee Emp = null;
            try
            {
                SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
                AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet Ds = new DataSet();
                AdEmp.Fill(Ds, "Employee");

                //1. Search Record BAsed on Primary Key
                DataRow DrFind = Ds.Tables["Employee"].Rows.Find(id);
                // 2. Call Delete() method on the searched record
                if (DrFind != null)
                {
                    Emp = new Employee()
                    {


                        EmpNo = Convert.ToInt32(DrFind["EmpNo"]),
                        EmpName = DrFind["EmpName"].ToString(),
                        Designation = DrFind["Designation"].ToString(),
                        Salary = Convert.ToInt32(DrFind["Salary"]),
                        DeptNo = Convert.ToInt32(DrFind["DeptNo"])


                    };
                    DrFind.Delete();
                }
               
                // 3. Command Build and Update
                SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdEmp);
                AdEmp.Update(Ds, "Employee");
               
            }
            catch(Exception ex)
            {
               
            }
            return Emp;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.GetData()
        {
            List<Employee> Employees = new List<Employee>();
            Conn = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=SSPI");
            SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
            DataSet Ds = new DataSet();
            AdEmp.Fill(Ds, "Employee");

            DataRowCollection dataRows = Ds.Tables["Employee"].Rows;

            foreach (DataRow row in dataRows)
            {

                Employees.Add(
                         
                               new Employee()
                               {
                                   EmpNo = Convert.ToInt32(row["EmpNo"]),
                                   EmpName = row["EmpName"].ToString(),
                                   Designation = row["Designation"].ToString(),
                                   Salary = Convert.ToInt32(row["Salary"]),
                                   DeptNo = Convert.ToInt32(row["DeptNo"])
                               }

                          );
            }
            return Employees;
        }

        Employee IDataAccess<Employee, int>.GetData(int id)
        {
            Employee Emp = null;
            try
            {
                SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
                AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet Ds = new DataSet();
                AdEmp.Fill(Ds, "Employee");
                //1. Search Record BAsed on Primary Key
                DataRow DrFind = Ds.Tables["Employee"].Rows.Find(id);
                if (DrFind != null)
               {
                    Emp = new Employee()
                    {
                        EmpNo = Convert.ToInt32(DrFind["EmpNo"]),
                        EmpName = DrFind["EmpName"].ToString(),
                        DeptNo = Convert.ToInt32(DrFind["DeptNo"]),
                        Designation = DrFind["Designation"].ToString(),
                        Salary = Convert.ToInt32(DrFind["Salary"])


                    };
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                       
                return Emp;          
        }

        Employee IDataAccess<Employee, int>.Update(int id, Employee entity)
        {
            if (id == entity.EmpNo)
            {
                SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Employee", Conn);
                AdEmp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet Ds = new DataSet();
                AdEmp.Fill(Ds, "Employee");
                //1. Search Record BAsed on Primary Key
                DataRow DrFind = Ds.Tables["Employee"].Rows.Find(entity.EmpNo);
                // 2. Update its Values
                DrFind["Designation"] = entity.Designation;

                // 3. Command Build and Update
                SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdEmp);
                AdEmp.Update(Ds, "Employee");
                return entity;
            }
            else
            {
                Console.WriteLine("Department Not found");
                return null;
            }
        }
    }
}
