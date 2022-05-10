using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs_EfCore_DBfirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Cs_EfCore_DBfirst.DataAccess
{
    internal class EmpDataAccess : IdataAccess<Employee, int>
    {
        sample1Context ctx;
        public EmpDataAccess()
        {
            ctx = new sample1Context();
        }
        async Task<Employee> IdataAccess<Employee, int>.CreateAsync(Employee entity)
        {
            try
            {
                var result = await ctx.Employees.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        async Task<Employee> IdataAccess<Employee, int>.DeleteAsync(int id)
        {
            try
            {
                var EmpToDelete = await ctx.Employees.FindAsync(id);
                if (EmpToDelete == null)
                {
                    return null;
                }
                ctx.Employees.Remove(EmpToDelete);
                await ctx.SaveChangesAsync();
                return EmpToDelete;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<Employee>> IdataAccess<Employee, int>.GetAllAsync()
        {
            try
            {
                var Employees = await ctx.Employees.ToListAsync();
                return Employees;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Employee> IdataAccess<Employee, int>.GetByIdAsync(int id)
        {
            try
            {
                var Employee = await ctx.Employees.FindAsync(id);
                if (Employee == null)
                {
                    return null;
                }

                return Employee;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Employee> IdataAccess<Employee, int>.UpdateAsync(int Id, Employee entity)
        {
            try
            {
                var EmpToUpdate = await ctx.Employees.FindAsync(Id);
                if (EmpToUpdate == null)
                {
                    return null;
                }
                EmpToUpdate.EmpName = entity.EmpName;
                EmpToUpdate.DeptNo = entity.DeptNo;
                EmpToUpdate.Designation = entity.Designation;
                EmpToUpdate.Salary = entity.Salary;
                await ctx.SaveChangesAsync();
                return EmpToUpdate;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
