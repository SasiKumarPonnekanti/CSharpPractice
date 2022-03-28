using Cs_JobPortalWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cs_JobPortalWebApp.Services
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

        Task<IEnumerable<CampanyInfo>> IService<CampanyInfo, int>.GetAsync()
        {
            throw new System.NotImplementedException();
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
            if (list.Count != 0)
            {
                foreach (CampanyInfo entity in list)
                {
                    entity.PersonId = id;
                }
                await ctx.AddRangeAsync(list);
                await ctx.SaveChangesAsync();
               
            }
            return null;
        }
    }
}
