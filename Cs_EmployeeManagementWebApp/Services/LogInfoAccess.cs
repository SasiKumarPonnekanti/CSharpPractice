using Cs_EmployeeManagementWebApp.Models;
using System.Threading.Tasks;

namespace Cs_EmployeeManagementWebApp.Services
{
    public class LogInfoAccess
    {
        private readonly sample1Context ctx;
        /// <summary>
        /// Inject the EnterpriseContext
        /// </summary>
        public LogInfoAccess(sample1Context ctx)
        {
            this.ctx = ctx;
        }
        async Task<LogInfo> CreateLogAsync(LogInfo entity)
        {
            var res = await ctx.LogInfos.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }
        async Task<ErrorLog> CreateErrorLogAsync(ErrorLog entity)
        {
            var res = await ctx.ErrorLogs.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

    }
}
