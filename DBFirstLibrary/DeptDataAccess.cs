using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBFirstLibrary.Models;

namespace DBFirstLibrary
{
    public class DeptDataAccess : IDataAccess<Department, int>
    {

        sample1Context ctx;
        public DeptDataAccess()
        {
            ctx = new sample1Context();
        }
        async Task<Department> IDataAccess<Department, int>.CreateAsync(Department entity)
        {
            try
            {
                var DeptCreate = await ctx.Departments.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return DeptCreate.Entity;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Department> IDataAccess<Department, int>.DeleteAsync(int id)
        {
            try
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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        async Task<IEnumerable<Department>> IDataAccess<Department, int>.GetAllAsync()
        {
            var Departments = await ctx.Departments.ToListAsync();
            return Departments;
        }

        async Task<Department> IDataAccess<Department, int>.GetByIdAsync(int id)
        {
            try
            {
                var department = await ctx.Departments.FindAsync(id);
                if (department == null)
                {
                    return null;
                }
                return department;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Department> IDataAccess<Department, int>.UpdateAsync(int id, Department entity)
        {
            try
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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
