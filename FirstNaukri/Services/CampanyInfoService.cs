using FirstNaukri.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNaukri.Services
{
    public class CampanyInfoService : IService<CampanyInfo, int>
    {
        private readonly JobPortalContext ctx;

        public CampanyInfoService(JobPortalContext ctx)
        {
            this.ctx = ctx;
        }

        Task<CampanyInfo> IService<CampanyInfo, int>.CreateAsync(CampanyInfo entity)
        {
            throw new System.NotImplementedException();
        }

        Task<CampanyInfo> IService<CampanyInfo, int>.DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        async Task<IEnumerable<CampanyInfo>> IService<CampanyInfo, int>.GetAllByIdAsync(int id)
        {
            var res = await ctx.CampanyInfos.Where(c => c.PersonId == id).ToListAsync();
            return res;
        }

        Task<CampanyInfo> IService<CampanyInfo, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<CampanyInfo> IService<CampanyInfo, int>.UpdateAsync(int id, CampanyInfo entity)
        {
            throw new System.NotImplementedException();
        }
        async Task<List<CampanyInfo>> IService<CampanyInfo, int>.AddList(List<CampanyInfo> list, int id)
        {
            if (list != null)
            {
                foreach (CampanyInfo entity in list)
                {
                    entity.PersonId = id;
                }
                await ctx.CampanyInfos.AddRangeAsync(list);
                await ctx.SaveChangesAsync();

            }
            return null;
        }
    }
}
