using Cs_SuperMarketWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cs_SuperMarketWebApp.Services
{
    public class CategoryRepository : IRepository<Category, int>
    {
        supermarketContext ctx;
        public CategoryRepository(supermarketContext c)
        {
            ctx = c;
        }
        public bool Create(Category data)
        {
            int res = 0;
            bool isSuccess = false;
            ctx.Categories.Add(data);
            res = ctx.SaveChanges();
            if (res >= 0)
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool Delete(int id)
        {
            bool isSuccess = false;
            var cat = ctx.Categories.Find(id);
            if (cat != null)
            {
                ctx.Categories.Remove(cat);
                ctx.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public IEnumerable<Category> Get()
        {
            var cats = ctx.Categories.ToList();
            return cats;
        }

        public Category Get(int id)
        {
            var cat = ctx.Categories.Find(id);
            return cat;
        }

        public bool Update(int id, Category data)
        {
            bool isSuccess = false;
            var cat = ctx.Categories.Find(id);
            if (cat != null)
            {
                cat.CategoryName = data.CategoryName;
                ctx.SaveChanges();
            }
            return isSuccess;
        }
    }

}
