
using Cs_EmployeeManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cs_EmployeeManagementWebApp.Services
{
    public class UserAccess : IService<User, int>
    {
        private readonly sample1Context ctx;
        /// <summary>
        /// Inject the EnterpriseContext
        /// </summary>
        public UserAccess(sample1Context ctx)
        {
            this.ctx = ctx;
        }
         async  Task<User> IService<User, int>.CreateAsync(User entity)
        {
            var res = await ctx.Users.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<User> IService<User, int>.DeleteAsync(int id)
        {
            var objToDelete = await ctx.Users.FindAsync(id);
            if (objToDelete == null) return null;
            ctx.Users.Remove(objToDelete);
            await ctx.SaveChangesAsync();
            return objToDelete;
        }

        async Task<IEnumerable<User>> IService<User, int>.GetAsync()
        {
            return await ctx.Users.ToListAsync();
        }

        async Task<User> IService<User, int>.GetAsync(int id)
        {
            return await ctx.Users.FindAsync(id);
        }

        async Task<User> IService<User, int>.UpdateAsync(int id, User entity)
        {
            var objToUpate = await ctx.Users.FindAsync(id);
            if (objToUpate == null) return null;

            objToUpate.UserName = entity.UserName;
            objToUpate.Phone = entity.Phone;
            objToUpate.EmailId = entity.EmailId;

            await ctx.SaveChangesAsync();
            return objToUpate;

        }
    }

}
