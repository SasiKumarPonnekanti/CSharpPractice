using System;
using Cs_EmployeeManagementWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Cs_EmployeeManagementWebApp.Areas.Identity.IdentityHostingStartup))]
namespace Cs_EmployeeManagementWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<SecurityDbContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("SecurityDbContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<SecurityDbContext>();
            });
        }
    }
}
