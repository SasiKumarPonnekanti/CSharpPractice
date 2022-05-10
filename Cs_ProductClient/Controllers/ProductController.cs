using Cs_ProductClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cs_ProductClient.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;
        public ProductController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var pros = await client.GetFromJsonAsync<List<Product>>("https://localhost:7292/api/Product");
            return View(pros);

        }
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var res = await client.PostAsJsonAsync<Product>("https://localhost:7292/api/Product", product);
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(product);
            }
        }
        public   IActionResult Edit(int id)
        {
            
            
           var res2 = client.GetFromJsonAsync<Product>("https://localhost:7292/"+id).Result;
            return View(res2);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, int id)
        {
            var response = await client.PutAsJsonAsync<Product>("https://localhost:7292/api/Product/" + id, product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(product);
            }
        }
        public IActionResult Delete(int id)
        {
            var res2 = client.GetFromJsonAsync<Product>("https://localhost:7292/"+id).Result; 
            return View(res2);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product, int id)
        {
            var response = await client.DeleteAsync("https://localhost:7292/api/Product/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(product);
            }
        }

    }
}
