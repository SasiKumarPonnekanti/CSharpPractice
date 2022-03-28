using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cs_EmployeeManagementWebApp.Models;
using Cs_EmployeeManagementWebApp.Services;
using Cs_EmployeeManagementWebApp.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cs_EmployeeManagementWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddDbContext<sample1Context>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("AppConnStr"));
            });
            services.AddScoped<IService<Department, int>, DepartmentAccess>();
            services.AddScoped<IService<Employee, int>, EmployeeAccess>();
            services.AddScoped<IService<User, int>, UserAccess>();
            services.AddDistributedMemoryCache();
            services.AddSession(options=>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });
            
            services.AddControllersWithViews(options =>
            {
                //options.Filters.Add(new LogFilterAttribute());
                options.Filters.Add(typeof(AppExceptionFilterAttribute));
                options.Filters.Add(typeof(LogFilterAttribute));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Map with MVC controller

                endpoints.MapControllerRoute(
                    name: "default",
                    //Route Url Expression
                    //       Homecontroller           The index Action Method id is ooptional
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
