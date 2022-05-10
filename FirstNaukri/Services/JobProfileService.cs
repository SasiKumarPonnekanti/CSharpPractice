using FirstNaukri.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNaukri.Services
{
    public class JobProfileService : IService<JobProfile, int>
    {
        private readonly JobPortalContext ctx;

        public JobProfileService(JobPortalContext ctx)
        {
            this.ctx = ctx;
        }
        Task<List<JobProfile>> IService<JobProfile, int>.AddList(List<JobProfile> list, int id)
        {
            throw new System.NotImplementedException();
        }

        async Task<JobProfile> IService<JobProfile, int>.CreateAsync(JobProfile entity)
        {
            var res = await ctx.JobProfiles.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        Task<JobProfile> IService<JobProfile, int>.DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        async Task<IEnumerable<JobProfile>> IService<JobProfile, int>.GetAllByIdAsync(int Id)
        {
            return await ctx.JobProfiles.ToListAsync();
        }

        Task<JobProfile> IService<JobProfile, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<JobProfile> IService<JobProfile, int>.UpdateAsync(int id, JobProfile entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
