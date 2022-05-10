using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cs_ProCatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IService<Category, int> catService;
        private readonly IService<Product, int> proService;
        private readonly ApiDbContext ctx;
        public SearchController(IService<Category, int> serv1, IService<Category, int> serv2, ApiDbContext ctx)
        {
            catService = serv1;
            catService = serv2;
            this.ctx = ctx;
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var res = catService.GetAsync(id).Result;
        //    return Ok(res);
        //}
        [HttpGet("{name}")]
        public  IActionResult GetByName(string name)
        {
           var res1 = catService.GetAsync().Result.Where(e=>e.CategoryName==name).FirstOrDefault();
            if(res1==null)
            {
                return Ok(new List<Product>()) ;
            }
            
            var products =  ctx.Products.Where(p => p.CategoryRowId == res1.CategoryRowId).ToList();
            if(products==null)
            {
                return Ok(new { Message ="No Products Found"});
            }
            
            return Ok(products);
        }

        [HttpGet]
         public IActionResult GetByCondition(string Category,string condition,string ProdName)
        {
            var res1 = catService.GetAsync().Result.Where(e => e.CategoryName == Category).FirstOrDefault();
            if (res1 == null)
            {
                var c = ctx.Products.Where(p => p.ProductName == ProdName).ToList();
                return Ok(new { Message = "No category Found with Name ",c });
            }
            List<Product> products;
            if (condition.ToUpper() == "AND")
            {
                  products = ctx.Products.Where(p => (p.CategoryRowId == res1.CategoryRowId) && (p.ProductName == ProdName)).ToList();
            }
            else if(condition.ToUpper() == "OR")
            {
                  products = ctx.Products.Where(p => (p.CategoryRowId == res1.CategoryRowId) ).ToList();
                   var c = ctx.Products.Where(p=> p.ProductName == ProdName).ToList();
                return Ok(products.Concat(c));
              
            }
            else
            {
                return BadRequest("Invalid Operator");
            }
           
            return Ok(products);
        }

    }
}
