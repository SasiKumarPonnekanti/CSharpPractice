using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cs.Serialization
{
    [Serializable]
    internal class Employee
    {      
         public int EmpNo { get; set; }
         public string EmpName { get; set; }
         public string DeptName { get; set; }
         public string Designation { get; set; } 
         public int Salary { get; set; }
    }
}
