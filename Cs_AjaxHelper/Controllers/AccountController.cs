using Microsoft.AspNetCore.Mvc;
using Cs_AjaxHelper.Models;

namespace Cs_AjaxHelper.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public IActionResult Index(LoginModel Model)
        {
            return View();
        }

        [HttpPost]
        public void ProcessUserName(string UserName)
        {

           
        }
    }
}
