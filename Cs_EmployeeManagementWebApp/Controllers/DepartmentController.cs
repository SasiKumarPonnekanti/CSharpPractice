using Cs_EmployeeManagementWebApp.Models;
using Cs_EmployeeManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Cs_EmployeeManagementWebApp.CustomFilters;
using Microsoft.AspNetCore.Http;

namespace Cs_EmployeeManagementWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IService<Department, int> deptService;
        
        public DepartmentController(IService<Department, int> service)
        {
            deptService = service;
        }
        public IActionResult Index()
        {
            var res = deptService.GetAsync().Result;
            return View(res);
        }
        public IActionResult Create()
        {
            var dept = new Department();
            return View(dept);
        }
        [HttpPost]
       
        public IActionResult Create(Department department)
        {
            //try
            //{
                var dept = deptService.GetAsync(department.DeptNo).Result;
                if(dept != null)
                {
                    throw new Exception("The Department is already present");
                }
                if (ModelState.IsValid)
                {
                    var res = deptService.CreateAsync(department).Result;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(department);
                }
        //}
        //    catch(Exception ex)
        //    {
        //        return View("Error", new ErrorViewModel()
        //{
        //    ControllerName = RouteData.Values["controller"].ToString(),
        //            Actionname = RouteData.Values["action"].ToString(),
        //            ErrorMessage = ex.Message
        //        });
        //    }
         }

        public IActionResult ValidateDeptNoUnique(int DeptNo)
        {
            var dept = deptService.GetAsync(DeptNo).Result;
            if (dept != null)
                return Json(false); // invalid
            return Json(true); // Valid 
        }
        public IActionResult Edit(int id)
        {
            var res = deptService.GetAsync(id).Result;
            // return a view that will show the record to be edited
            return View(res);
        }

        /// <summary>
        /// Edit the record with Post request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                var res = deptService.UpdateAsync(id, department).Result;
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
        }

        /// <summary>
        /// Http Get Request that will accept an id of record to delete 
        /// and return a veiw that will show the record to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var res = deptService.GetAsync(id).Result;
            return View(res);
        }
        [HttpPost]
        public IActionResult Delete(int id, Department department)
        {
            var res = deptService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }

        public IActionResult ShowEmployees(int id)
        {
            HttpContext.Session.SetInt32("DeptNo",id);
           return RedirectToAction("Index","Employee");
        }
    }
}
