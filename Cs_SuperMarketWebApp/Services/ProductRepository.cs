using Cs_SuperMarketWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cs_SuperMarketWebApp.Services
{
    public class ProductRepository : IRepository<Product, int>
    {
        supermarketContext ctx;

        public ProductRepository(supermarketContext c)
        {
            ctx = c;
        }
        public bool Create(Product data)
        {
            bool isSuccess = false;
            int res = 0;
            ctx.Products.Add(data);
            res = ctx.SaveChanges();
            if (res > 0)
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool Delete(int id)
        {
            bool isSuccess = false;
            var prd = ctx.Products.Find(id);
            if (ctx != null)
            {
                ctx.Products.Remove(prd);
                ctx.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public IEnumerable<Product> Get()
        {
            var prds = ctx.Products.ToList();
            return prds;
        }

        public Product Get(int id)
        {
            var prd = ctx.Products.Find(id);
            return prd;
        }

        public bool Update(int id, Product data)
        {
            bool isSuccess = false;
            var prd = ctx.Products.Find(id);
            if (prd != null)
            {
                prd.ProductName = data.ProductName;
                prd.UnitPrice = data.UnitPrice;
                prd.CategoryId = data.CategoryId;
                ctx.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
    }

}
