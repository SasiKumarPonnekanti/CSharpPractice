using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_App.models
{
    internal class Employee
    {
        private int _EmpNo;
        public int EmpNo
        {
            get { return this._EmpNo; } // read
            set { this._EmpNo = value; } // write
        }
        private string _EmpName;
        public string EmpName
        {
            get { return this._EmpName; }
            set { this._EmpName = value; }
        }
        private string _DeptName;
        public string DeptName

        {
            get { return this._DeptName; }
            set { this._DeptName = value; }
        }
        private string _Designation;
        public string Designation
        {
            get { return this._Designation; }
            set { this._Designation = value; }
        }
        private int _Salary;
        public int Salary
        {
            get { return this._Salary; }
            set { this._Salary = value; }
        }


    }
}
