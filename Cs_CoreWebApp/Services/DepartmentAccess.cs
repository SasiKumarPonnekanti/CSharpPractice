using Cs_CoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cs_CoreWebApp.Services
{
    public class DepartmentAccess : IService<Department, int>
    {
        public readonly sample1Context ctx;

        public  DepartmentAccess(sample1Context ctx)
        {
            this.ctx = ctx; 
        }

        async Task<Department> IService<Department, int>.CreateAsync(Department entity)
        {
            var DeptCreated = await ctx.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return DeptCreated.Entity;
        }

        async Task<Department> IService<Department, int>.DeleteAsync(int id)
        {
            var DeptToDelete = await ctx.Departments.FindAsync(id);
            if (DeptToDelete == null)
            {
                return null;
            }

            ctx.Departments.Remove(DeptToDelete);
            await ctx.SaveChangesAsync();
            return DeptToDelete;
        }

        async Task<IEnumerable<Department>> IService<Department, int>.GetAsync()
        {
            var Departments = await ctx.Departments.ToListAsync();
            return Departments;
        }

        async Task<Department> IService<Department, int>.GetAsync(int id)
        {
            var department = await ctx.Departments.FindAsync(id);
            if (department == null)
            {
                return null;
            }
            return department;
        }

        async Task<Department> IService<Department, int>.UpdateAsync(int id,Department entity)
        {
            var DeptToUpdate = await ctx.Departments.FindAsync(id);
            if (DeptToUpdate == null)
            {
                return null;
            }
            DeptToUpdate.DeptName = entity.DeptName;
            DeptToUpdate.Capacity = entity.Capacity;
            DeptToUpdate.Location = entity.Location;
            await ctx.SaveChangesAsync();
            return DeptToUpdate;
        }
    }
}
