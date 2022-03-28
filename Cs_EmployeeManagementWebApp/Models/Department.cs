using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Cs_EmployeeManagementWebApp.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Required(ErrorMessage = ("The Feild is required"))]
       
        public int DeptNo { get; set; }

        [Required(ErrorMessage = ("The Feild is required"))]
        public string DeptName { get; set; }

        [Required(ErrorMessage = ("The Feild is required"))]
        public string Location { get; set; }

        [Required(ErrorMessage = ("The Feild is required"))]
        public int Capacity { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
