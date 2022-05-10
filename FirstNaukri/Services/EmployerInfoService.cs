using FirstNaukri.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FirstNaukri.Services
{
    public class EmployerInfoService : IService<Employer, int>
    {
        private readonly JobPortalContext ctx;

        public EmployerInfoService(JobPortalContext ctx)
        {
            this.ctx = ctx;
        }

        Task<List<Employer>> IService<Employer, int>.AddList(List<Employer> list, int id)
        {
            throw new System.NotImplementedException();
        }

        async Task<Employer> IService<Employer, int>.CreateAsync(Employer entity)
        {
            var res = await ctx.Employers.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        Task<Employer> IService<Employer, int>.DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Employer>> IService<Employer, int>.GetAllByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        async Task<Employer> IService<Employer, int>.GetAsync(int id)
        {
            return await ctx.Employers.FindAsync(id);
        }

        Task<Employer> IService<Employer, int>.UpdateAsync(int id, Employer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
