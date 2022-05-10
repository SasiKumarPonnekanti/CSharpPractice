using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cs_Cookie_Auth.Controllers
{
    
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
