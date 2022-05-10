using Microsoft.AspNetCore.Mvc;
using Cs_ProductClient.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Cs_ProductClient.Controllers
{
    public class ProductsController : Controller
    {
        HttpClient client;
        public ProductsController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index(string CategoryName)
        {
            ProductList products = new ProductList();
            if (CategoryName == null)
            {
                products.products = await client.GetFromJsonAsync<List<Product>>("https://localhost:7292/api/Product");
            }
            else
            {
                var res = await client.GetFromJsonAsync<List<Product>>("https://localhost:7292/api/Search/" + CategoryName);
                products.products = await client.GetFromJsonAsync<List<Product>>("https://localhost:7292/api/Search/"+CategoryName);
            }
            return View(products);
        }
        public IActionResult showproducts(string CategoryName)
        {
            
            return RedirectToAction("Index", new { CategoryName = CategoryName });
        }

       
    }
}
