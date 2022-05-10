using Microsoft.AspNetCore.Mvc;
using Asp.Net_EmployeeWebApp.Models;
using System.Collections.Generic;

namespace Asp.Net_EmployeeWebApp.Controllers
{
    public class EmployeeController1 : Controller
    {
        Employees emps;
        public EmployeeController1()
        {
            emps = new Employees(); 
        }
        public IActionResult EmployeesInfo()
        {
            return View(emps);
        }
    }
}
