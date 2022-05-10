using Cs_EmployeeManagementWebApp.Models;
using Cs_EmployeeManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Cs_EmployeeManagementWebApp.Controllers
{
    public class DeptEmpController : Controller
    {

        private readonly IService<Employee, int> empService;
        private readonly IService<Department, int> deptService;

        public DeptEmpController(IService<Employee, int> service1, IService<Department, int> service2)
        {
            empService = service1;
            deptService = service2;
        }
        public IActionResult Index(int id =0)
        {
            var deptEmps = new DeptEmpList();
            ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName", "select Department");
           
            deptEmps.Departments = deptService.GetAsync().Result.ToList();
            if (id == 0)
            {
                deptEmps.Employees = empService.GetAsync().Result.ToList();
            }
            else
            {
                deptEmps.Employees = empService.GetAsync().Result.Where(e => e.DeptNo == id).ToList();
            }

            return View(deptEmps); 
        }
        public IActionResult ShowEmps(int DeptNo)
        {
            // return to Index View with a Route Parameter
            return RedirectToAction("Index", new { id = DeptNo });
        }
        //public IActionResult GetResult(int id)
        //{
        //    DeptEmpList dl = new DeptEmpList();
        //    ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName", "select Department");
        //    return RedirectToAction("Index",new {id = dl.DeptNo});
        //}
        
    }
}
