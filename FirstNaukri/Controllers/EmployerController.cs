using Microsoft.AspNetCore.Mvc;
using FirstNaukri.Models;

namespace FirstNaukri.Controllers
{
    public class EmployerController : Controller
    {

        public IActionResult CreateEmployer()
        {
            return View(new Employer());  

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewProfiles(int id)
        {
            return View();
        }
    }
}
