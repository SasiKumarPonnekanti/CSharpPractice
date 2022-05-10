using Cs_EmployeeManagementWebApp.Models;
using System.Collections.Generic;

namespace Cs_EmployeeManagementWebApp.Models
{
    public class DeptEmpList
    {
        public int DeptNo;
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
