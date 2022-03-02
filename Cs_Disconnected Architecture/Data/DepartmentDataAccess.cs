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
    internal class DepartmentDataAccess : IDataAccess<Department, int>
    {
        SqlConnection Conn;
        
        public DepartmentDataAccess()
        {

            Conn = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=SSPI");
        }

        void  IDataAccess<Department,int>.Create(Department entity)
        {
            try
            {
                SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
                DataSet Ds = new DataSet();
                AdDept.Fill(Ds, "Department");
                // 1. Create a new Row in the Department DataTable in DataSet
                DataRow DrNew = Ds.Tables["Department"].NewRow();
                // 2. Set data for all columns for the row

                DrNew["DeptNo"] = entity.DeptNo;
                DrNew["DeptName"] = entity.DeptName;
                DrNew["Location"] = entity.Location;
                DrNew["Capacity"] = entity.Capacity;
                // 3. Add the Row into the Table
                Ds.Tables["Department"].Rows.Add(DrNew);
                // 4. Define a Command Builder to Ask the Adpater to Update Record in Database Table
                SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdDept);
                // 5. Call Update
                AdDept.Update(Ds, "Department");
            }
            catch (Exception ex)
            {
                Console.WriteLine("MaY Be Dapartment Is present Try Again");
            }

            

        }

        Department IDataAccess<Department,int>.Delete(int id)
        {
            Department Depart = null;
            try
            {
                
                SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
                AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet Ds = new DataSet();
                AdDept.Fill(Ds, "Department");

                //1. Search Record BAsed on Primary Key
                DataRow DrFind = Ds.Tables["Department"].Rows.Find(id);
                // 2. Call Delete() method on the searched record
                if (DrFind != null)
                {
                    Depart = new Department()
                    {
                        DeptNo = Convert.ToInt32(DrFind["DeptNo"]),
                        DeptName = DrFind["DeptName"].ToString(),
                        Location = DrFind["location"].ToString(),
                        Capacity = Convert.ToInt32(DrFind["Capacity"])

                    };
                    DrFind.Delete();
                }
                // 3. Command Build and Update
                SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdDept);
                AdDept.Update(Ds, "Department");
            }
            catch(Exception ex)
            {
               
            }
            return Depart;

        }





        Department IDataAccess<Department,int>.Update(int id,Department entity)
        {
            if (id == entity.DeptNo)
            {
                SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
                AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet Ds = new DataSet();
                AdDept.Fill(Ds, "Department");
                //1. Search Record BAsed on Primary Key
                DataRow DrFind = Ds.Tables["Department"].Rows.Find(entity.DeptNo);
                // 2. Update its Values
                DrFind["Location"] = entity.Location;

                // 3. Command Build and Update
                SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdDept);
                AdDept.Update(Ds, "Department");
                return entity;
            }
            else
            {
                Console.WriteLine("Department Not found");
                return null;
            }
            
        }
        Department IDataAccess<Department,int>.GetData(int id)
        {
            Department Depart = null;
            try
            {
                SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
                AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet Ds = new DataSet();
                AdDept.Fill(Ds, "Department");
                //1. Search Record BAsed on Primary Key
                DataRow DrFind = Ds.Tables["Department"].Rows.Find(id);
                if (DrFind != null)
                {
                    Depart = new Department()
                    {
                        DeptNo = Convert.ToInt32(DrFind["DeptNo"]),
                        DeptName = DrFind["DeptName"].ToString(),
                        Location = DrFind["location"].ToString(),
                        Capacity = Convert.ToInt32(DrFind["Capacity"])

                    };
                }
            }
            catch(Exception ex)
            {

            }
            return Depart;

        }

        IEnumerable<Department> IDataAccess<Department, int>.GetData()
        {
            List<Department> Departments = new List<Department>();
            Conn = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=SSPI");
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            DataSet Ds = new DataSet();
            AdDept.Fill(Ds, "Department");
            
            DataRowCollection dataRows = Ds.Tables["Department"].Rows;

            foreach (DataRow row in dataRows)
            {
               
                Departments.Add(
                          new Department()
                          {
                              DeptNo = Convert.ToInt32(row["DeptNo"]),
                              DeptName = row["DeptName"].ToString(),
                              Location = row["location"].ToString(),
                              Capacity = Convert.ToInt32(row["Capacity"])

                          });
            }
            return Departments;
        }
    }
}
