using Cs_ProductClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cs_ProductClient.Controllers
{
    public class CategoryController : Controller
    {
        HttpClient client;
        public CategoryController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var cats = await client.GetFromJsonAsync<List<Category>>("https://localhost:7292/api/Category");
            return View(cats);
            
        }

        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            var response = await client.PostAsJsonAsync<Category>("https://localhost:7292/api/Category", category);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(category);
            }
        }

        public IActionResult Edit(int id)
        {
           
            var res = client.GetFromJsonAsync<Category>("https://localhost:7292/api/Category/"+id).Result;
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category,int id)
        {
            var response = await client.PutAsJsonAsync<Category>("https://localhost:7292/api/Category/"+id, category);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(category);
            }
        }
        public IActionResult Delete(int id)
        {
            var res2 = client.GetFromJsonAsync<Category>("https://localhost:7292/api/Category/"+id).Result;
            return View(res2);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(Category category,int id)
        {
            var response = await client.DeleteAsync("https://localhost:7292/api/Category/"+id);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Succes";
                return View(category);
            }
        }
    }
}
