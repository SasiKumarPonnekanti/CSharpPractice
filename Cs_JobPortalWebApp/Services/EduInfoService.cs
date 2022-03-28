
using Cs_JobPortalWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cs_JobPortalWebApp.Services
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

        Task<IEnumerable<EduInfo>> IService<EduInfo, int>.GetAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<EduInfo> IService<EduInfo, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<EduInfo> IService<EduInfo, int>.UpdateAsync(int id, EduInfo entity)
        {
            throw new System.NotImplementedException();
        }
         async Task<List<EduInfo>> IService<EduInfo, int>.AddList(List<EduInfo> list,int id)
        {
            if (list.Count != 0)
            {
                foreach (EduInfo entity in list)
                {
                    entity.PersonId = id;
                }
                await ctx.AddRangeAsync(list);
                await  ctx.SaveChangesAsync();
            }
            return null;
        }
    }
}
