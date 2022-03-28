using Cs_JobPortalWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cs_JobPortalWebApp.Services
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

        Task<IEnumerable<ProjectInfo>> IService<ProjectInfo, int>.GetAsync()
        {
            throw new System.NotImplementedException();
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
            if (list.Count != 0)
            {
                foreach (ProjectInfo entity in list)
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
