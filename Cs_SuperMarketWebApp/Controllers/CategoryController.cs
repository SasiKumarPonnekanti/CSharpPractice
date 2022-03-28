using Cs_SuperMarketWebApp.Models;
using Cs_SuperMarketWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cs_SuperMarketWebApp.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category, int> _catRepo;

        public CategoryController(IRepository<Category, int> cat)
        {
            _catRepo = cat;
        }
        public IActionResult Index()
        {
            var cats = _catRepo.Get();
            return View(cats);
        }
        public IActionResult LoadProducts(int id)
        {
            HttpContext.Session.SetInt32("CategoryId", id);
            return RedirectToAction("Index", "Product");

        }
    }
}
