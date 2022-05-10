using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cs_CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category, int> catService;
        public CategoryController(IService<Category, int> serv)
        {
            catService = serv;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = catService.GetAsync().Result;
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = catService.GetAsync(id).Result;
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Post(Category cat)
        {
            if(ModelState.IsValid)
            {
                var res = catService.CreateAsync(cat).Result;
                return Ok(res);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category cat)
        {
            var record = catService.GetAsync(id).Result;
            if (record == null) return NotFound($"BAsed of Category Row Id {id} the record is not found");

            // Check if the id from header is mapping with the id from the Body
            if (id != cat.CategoryRowId)
                return BadRequest($"Id for seaarch {id} does not match with Category Row Id in Body {cat.CategoryRowId}");

            if (ModelState.IsValid)
            {
                var res = catService.UpdateAsync(id, cat).Result;
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
            var res = catService.DeleteAsync(id).Result;
            return Ok(res);
        }
    }
}
