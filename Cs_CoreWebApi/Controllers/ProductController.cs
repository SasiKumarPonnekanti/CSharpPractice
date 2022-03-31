using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cs_CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product, int> proService;
        public ProductController(IService<Product, int> serv)
        {
            proService = serv;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = proService.GetAsync().Result;
            return Ok(res);
        }

        [HttpGet("{id}")]
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
