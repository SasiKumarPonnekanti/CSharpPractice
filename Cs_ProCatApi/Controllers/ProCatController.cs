using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cs_ProCatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProCatController : ControllerBase
    {
        private readonly IService<Product, int> proService;
        private readonly IService<Category, int> catService;
        public ProCatController(IService<Product, int> serv1, IService<Category, int> serv2)
        {
            proService = serv1;
            catService = serv2;
        }
        [HttpPost]
        public IActionResult Post(ProCat data)
        {
            if (ModelState.IsValid)
            {
                var cat = data.category;
               
                var res = catService.CreateAsync(cat).Result;
                foreach (var item in data.Products)
                {
                    item.CategoryRowId = res.CategoryRowId;
                    var res1 = proService.CreateAsync(item).Result;
                }
                return Ok(data);
            }
            return BadRequest(ModelState);
        }
    }
}
