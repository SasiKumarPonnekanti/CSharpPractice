using Microsoft.AspNetCore.Mvc;
using Cs_CoreWebApp.Models;
using Cs_CoreWebApp.Services;

namespace Cs_CoreWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IService<Department,int> deptService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public DepartmentController(IService<Department,int> service)
        {
            this.deptService = service;
        }
        public IActionResult Index()
        {
            var res = deptService.GetAsync().Result;
            return View(res);
        }

        public IActionResult Create()
        {
            var dept  = new Department(); 
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            var res = deptService.CreateAsync(department).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var res = deptService.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]

        public IActionResult Edit(int id,Department department)
        {
            var res = deptService.UpdateAsync(id, department).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var res = deptService.GetAsync(id).Result;
            return View(res);
        }
        [HttpPost]

        public IActionResult Delete(int id,Department department)
        {
            var res = deptService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
    }
}
