using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Cs_SuperMarketWebApp.Services;
using Cs_SuperMarketWebApp.Models;
using Cs_SuperMarketWebApp.customSessions;
using System.Collections.Generic;
using System.Linq;
namespace Cs_SuperMarketWebApp.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product, int> _prdRepo;
        public ProductController(IRepository<Product, int> prd)
        {
            _prdRepo = prd;
        }
        public IActionResult Index()
        {
            var catId = HttpContext.Session.GetInt32("CategoryId");
            List<Product> Products = null;
            if (catId != 0)
            {
                Products = _prdRepo.Get().Where(p => p.CategoryId == catId).ToList();
            }
            return View(Products);
        }
        public IActionResult SelectForPurchase(int id)
        {
            var prd = _prdRepo.Get(id);
            var billDetails = new BillDetail()
            {
                ProductId = id,
                ProductName = prd.ProductName,
                Quantity = 0,
                RowPrice = 0
            };
            HttpContext.Session.SetInt32("UnitPrice", prd.UnitPrice);
            HttpContext.Session.SetSessionData<BillDetail>("SelProduct", billDetails);
            return RedirectToAction("Index", "BillGenerator");
        }
    }
}
