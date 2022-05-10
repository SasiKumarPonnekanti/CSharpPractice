using FirstNaukri.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNaukri.Services
{
    public class ProjectInfoService : IService<ProjectInfo, int>
    {
        private readonly JobPortalContext ctx;

        public ProjectInfoService(JobPortalContext ctx)
        {
            this.ctx = ctx;
        }

        Task<ProjectInfo> IService<ProjectInfo, int>.CreateAsync(ProjectInfo entity)
        {
            throw new System.NotImplementedException();
        }

        Task<ProjectInfo> IService<ProjectInfo, int>.DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        async Task<IEnumerable<ProjectInfo>> IService<ProjectInfo, int>.GetAllByIdAsync(int id)
        {
            var res = await ctx.ProjectInfos.Where(p => p.PersonId == id).ToListAsync();
            return res;
        }

        Task<ProjectInfo> IService<ProjectInfo, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<ProjectInfo> IService<ProjectInfo, int>.UpdateAsync(int id, ProjectInfo entity)
        {
            throw new System.NotImplementedException();
        }
        async Task<List<ProjectInfo>> IService<ProjectInfo, int>.AddList(List<ProjectInfo> list, int id)
        {
            if (list != null)
            {
                foreach (ProjectInfo entity in list)
                {
                    entity.PersonId = id;
                }
                await ctx.ProjectInfos.AddRangeAsync(list);
                await ctx.SaveChangesAsync();
            }
            return null;
        }
    }
}
