using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Cs_EmployeeManagementWebApp.Models
{
    public partial class Employee
    {
        [Required(ErrorMessage =("The Feild is required"))]
        //[Remote("IsEmpNoValid", "Employee", ErrorMessage = "EmpValue already in use")]
        public int EmpNo { get; set; }
        [ValidName(ErrorMessage = ("User Name Should statrt with Capital and does not cantain numbers or special Characters"))]
        //[Remote("ValidateEmpName", "Employee", ErrorMessage = "EmpNameNot Valid")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = ("The Feild is required"))]
        public int Salary { get; set; }
        [Required(ErrorMessage = ("The Feild is required"))]
        //[Remote("ValidateDeptNoCount","Employee",ErrorMessage ="Capacity is full Cannot add in that Department")]
        public int DeptNo { get; set; }
        [Required(ErrorMessage = ("The Feild is required"))]
        public string Designation { get; set; }

        public virtual Department DeptNoNavigation { get; set; }
    }
}
