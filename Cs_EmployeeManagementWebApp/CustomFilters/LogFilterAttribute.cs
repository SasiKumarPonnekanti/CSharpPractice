using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System;
using Cs_EmployeeManagementWebApp.Models;
using System.Threading.Tasks;

namespace Cs_EmployeeManagementWebApp.CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly sample1Context ctx;
        public LogFilterAttribute(sample1Context ctx)
        {
            this.ctx= ctx;
        }
        private void LogRequest( RouteData route, long timeElapsed)
        {
            LogInfo logInfo= new LogInfo();
            logInfo.ActionName = route.Values["action"].ToString();
            logInfo.Controllername = route.Values["controller"].ToString();
            logInfo.RequestDate = System.DateTime.Now;
            logInfo.ElapsedTime = timeElapsed;
           ctx.LogInfos.Add(logInfo);
            ctx.SaveChanges();
            
           
        }
        Stopwatch stopWatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();

            //LogRequest("OnActionExecuting", context.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //LogRequest("OnActionExecuted", context.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
           // LogRequest("OnResultExecuting", context.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // LogRequest("OnResultExecuted", context.RouteData);
            stopWatch.Stop();
           
            LogRequest(context.RouteData, stopWatch.ElapsedMilliseconds);

        }
        

    }
}
