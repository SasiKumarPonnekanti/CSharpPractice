using Cs_EmployeeManagementWebApp.Models;
using Cs_EmployeeManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Cs_EmployeeManagementWebApp.CustomFilters;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;

namespace Cs_EmployeeManagementWebApp.Controllers
{
    //[LogFilter]
    public class EmployeeController : Controller
    {
       
        private readonly IService<Employee, int> empService;
        private readonly IService<Department, int> deptService;

        public EmployeeController(IService<Employee, int> service1,IService<Department,int> service2)
        {
            empService = service1;
            deptService = service2;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> res;
            int DeptNo = Convert.ToInt32(HttpContext.Session.GetInt32("DeptNo"));
            if (DeptNo == 0)
            {
                 res = empService.GetAsync().Result;
            }
            else
            {
                 res = empService.GetAsync().Result.Where(e=>e.DeptNo==DeptNo);
            }
          
            return View(res);
        }
        public IActionResult Create()
        {
            ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName");
            
            var emp = new Employee();
            
            return View(emp);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int count = empService.GetAsync().Result.Where(e => e.DeptNo == employee.DeptNo).Count();
                int Capacity = deptService.GetAsync(employee.DeptNo).Result.Capacity;
                if (count >= Capacity)
                    throw new Exception("Department is full cannot add Employees");

                ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName");
                var res = empService.CreateAsync(employee).Result;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName");

                return View(employee);
            }
        }

        public IActionResult Edit(int id)
        {
            var res = empService.GetAsync(id).Result;
            ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName", "select Department");
            return View(res);
        }

       
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
           
            ModelState.Remove("EmpNo");
            if (ModelState.IsValid)
            {
                ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName", "select Department");
                var res = empService.UpdateAsync(id, employee).Result;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Department = new SelectList(deptService.GetAsync().Result, "DeptNo", "DeptName", "select Department");
                return View(employee);
            }
        }

        
        public IActionResult Delete(int id)
        {
            ModelState.Remove("EmpName");
            var res = empService.GetAsync(id).Result;
            return View(res);
        }
        [HttpPost]
        public IActionResult Delete(int id, Employee employee)
        {
            ModelState.Remove("EmpName");
            var res = empService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
        
        public IActionResult IsEmpNoValid(int EmpNo)
        {
            return Json(IsEmpNoPresent(EmpNo));
        }
        public bool IsEmpNoPresent(int id)
        {
            var Emp = empService.GetAsync(id).Result;
            if(Emp == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IActionResult ValidateDeptNoCount(int DeptNo)
        {
            int count = empService.GetAsync().Result.Where(e=>e.DeptNo==DeptNo).Count();
            int Capacity = deptService.GetAsync(DeptNo).Result.Capacity;
            if (count>= Capacity)
                return Json(false); 
            return Json(true); 
        }
        public JsonResult ValidateEmpName (string EmpName)
        {
            Regex r = new Regex("([A-Z][a-z]{3,} )([A-Z][a-z]{3,} )?([A-Z][a-z]{3,})");
            Match m = r.Match(EmpName);
            if (m.Success)
            {
                return Json(true);
            }
            return Json(false);

        }


       
        
    }
}
