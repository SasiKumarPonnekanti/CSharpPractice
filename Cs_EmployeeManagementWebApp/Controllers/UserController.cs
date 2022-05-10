using Cs_EmployeeManagementWebApp.Models;
using Cs_EmployeeManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cs_EmployeeManagementWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<User, int> userService;

        public UserController(IService<User, int> service)
        {

            userService = service;
        }
        public IActionResult Index()
        {
            var res = userService.GetAsync().Result;
            return View(res);
        }
        public IActionResult Create()
        {
            var user = new User();
            return View(user);
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserId == 7)
                    throw new System.Exception("Are Kya Yaar");
                var res = userService.CreateAsync(user).Result;
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult Edit(int id)
        {
             var res = userService.GetAsync(id).Result;
                return View(res);
            
            
        }


        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            var res = userService.UpdateAsync(id, user).Result;
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var res = userService.GetAsync(id).Result;
            return View(res);
        }
        [HttpPost]
        public IActionResult Delete(int id, User user)
        {
            var res = userService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
    }
}
