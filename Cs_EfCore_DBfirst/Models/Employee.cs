using System;
using System.Collections.Generic;

namespace Cs_EfCore_DBfirst.Models
{
    public partial class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; } = null!;
        public int Salary { get; set; }
        public int DeptNo { get; set; }
        public string? Designation { get; set; }

        public virtual Department DeptNoNavigation { get; set; } = null!;
    }
}
