using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cs_ProCatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product, int> proService;
        private readonly IService<Category, int> catService;
        public ProductController(IService<Product, int> serv1, IService<Category, int> serv2)
        {
            proService = serv1;
            catService = serv2;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = proService.GetAsync().Result;
            return Ok(res);
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var res = proService.GetAsync(id).Result;
            return Ok(res);

        }
        [HttpPost]
        public IActionResult Post(Product pro)
        {
            if (ModelState.IsValid)
            {
                var CatBasePrice = catService.GetAsync(pro.CategoryRowId).Result.BasePrice;
                if(pro.Price<CatBasePrice)
                {
                    throw new Exception("Price Cannot Be less than Base Price");
                }
                var res = proService.CreateAsync(pro).Result;
                return Ok(res);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Product pro)
        {
            var CatBasePrice = catService.GetAsync(pro.CategoryRowId).Result.BasePrice;
            if (pro.Price < CatBasePrice)
            {
                throw new Exception("Price Cannot Be less than Base Price");
            }


            if (ModelState.IsValid)
            {
                var res = proService.UpdateAsync(id, pro).Result;
                return Ok(res);
            }
            else
            {
                // Data is Invalid
                return BadRequest(ModelState);

            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = proService.DeleteAsync(id).Result;
            return Ok(res);
        }
    }
}

