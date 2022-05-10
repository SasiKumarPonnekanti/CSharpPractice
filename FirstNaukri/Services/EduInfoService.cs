using FirstNaukri.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNaukri.Services
{
    public class EduInfoService : IService<EduInfo, int>
    {

        private readonly JobPortalContext ctx;

        public EduInfoService(JobPortalContext ctx)
        {
            this.ctx = ctx;
        }

        Task<EduInfo> IService<EduInfo, int>.CreateAsync(EduInfo entity)
        {
            throw new System.NotImplementedException();
        }

        Task<EduInfo> IService<EduInfo, int>.DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        async Task<IEnumerable<EduInfo>> IService<EduInfo, int>.GetAllByIdAsync(int id)
        {
            var res = await ctx.EduInfos.Where(e => e.PersonId == id).ToListAsync();
            return res;
        }

        Task<EduInfo> IService<EduInfo, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<EduInfo> IService<EduInfo, int>.UpdateAsync(int id, EduInfo entity)
        {
            throw new System.NotImplementedException();
        }
        async Task<List<EduInfo>> IService<EduInfo, int>.AddList(List<EduInfo> list, int id)
        {
            if (list != null)
            {
                foreach (EduInfo entity in list)
                {
                    entity.PersonId = id;
                }
                await ctx.EduInfos.AddRangeAsync(list);
                await ctx.SaveChangesAsync();
            }
            return null;
        }
    }
}
