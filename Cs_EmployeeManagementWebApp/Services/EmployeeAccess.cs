using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cs_EmployeeManagementWebApp.Models;
namespace Cs_EmployeeManagementWebApp.Services
{
    public class EmployeeAccess : IService<Employee, int>
    {
        private readonly sample1Context ctx;
        /// <summary>
        /// Inject the EnterpriseContext
        /// </summary>
        public EmployeeAccess(sample1Context ctx)
        {
            this.ctx = ctx;
        }

        async Task<Employee> IService<Employee, int>.CreateAsync(Employee entity)
        {
            var res = await ctx.Employees.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Employee> IService<Employee, int>.DeleteAsync(int id)
        {
            var objToDelete = await ctx.Employees.FindAsync(id);
            if (objToDelete == null) return null;
            ctx.Employees.Remove(objToDelete);
            await ctx.SaveChangesAsync();
            return objToDelete;
        }

        async Task<IEnumerable<Employee>> IService<Employee, int>.GetAsync()
        {
            return await ctx.Employees.ToListAsync();
        }

        async Task<Employee> IService<Employee, int>.GetAsync(int id)
        {
            return await ctx.Employees.FindAsync(id);
        }

        async Task<Employee> IService<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            var objToUpate = await ctx.Employees.FindAsync(id);
            if (objToUpate == null) return null;

            objToUpate.EmpName = entity.EmpName;
            objToUpate.DeptNo = entity.DeptNo;
            objToUpate.Designation = entity.Designation;
            objToUpate.Salary = entity.Salary;

            await ctx.SaveChangesAsync();
            return objToUpate;
        }
    }
}
