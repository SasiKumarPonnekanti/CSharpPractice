using Cs_JobPortalWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cs_JobPortalWebApp.Services
{
    public class PersonalInfoService : IService<Personal, int>
    {
        private readonly JobPortalContext ctx;

        public PersonalInfoService(JobPortalContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<Personal> IService<Personal, int>.CreateAsync(Personal entity)
        {
            var res = await ctx.Personals.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        Task<Personal> IService<Personal, int>.DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Personal>> IService<Personal, int>.GetAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<Personal> IService<Personal, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<Personal> IService<Personal, int>.UpdateAsync(int id, Personal entity)
        {
            throw new System.NotImplementedException();
        }
        Task<List<Personal>> IService<Personal, int>.AddList(List<Personal> list, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
