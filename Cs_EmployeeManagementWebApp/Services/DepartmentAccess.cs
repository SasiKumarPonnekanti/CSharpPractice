using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cs_EmployeeManagementWebApp.Models;

namespace Cs_EmployeeManagementWebApp.Services
{
    public class DepartmentAccess : IService<Department, int>
    {
        private readonly sample1Context ctx;
        /// <summary>
        /// Inject the EnterpriseContext
        /// </summary>
        public DepartmentAccess(sample1Context ctx)
        {
            this.ctx = ctx;
        }

        async Task<Department> IService<Department, int>.CreateAsync(Department entity)
        {
            var res = await ctx.Departments.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Department> IService<Department, int>.DeleteAsync(int id)
        {
            var objToDelete = await ctx.Departments.FindAsync(id);
            if (objToDelete == null) return null;
            ctx.Departments.Remove(objToDelete);
            await ctx.SaveChangesAsync();
            return objToDelete;
        }

        async Task<IEnumerable<Department>> IService<Department, int>.GetAsync()
        {
            return await ctx.Departments.ToListAsync();
        }

        async Task<Department> IService<Department, int>.GetAsync(int id)
        {
            return await ctx.Departments.FindAsync(id);
        }

        async Task<Department> IService<Department, int>.UpdateAsync(int id, Department entity)
        {
            var objToUpate = await ctx.Departments.FindAsync(id);
            if (objToUpate == null) return null;

            objToUpate.DeptName = entity.DeptName;
            objToUpate.Location = entity.Location;
            objToUpate.Capacity = entity.Capacity;

            await ctx.SaveChangesAsync();
            return objToUpate;
        }
    }

}
