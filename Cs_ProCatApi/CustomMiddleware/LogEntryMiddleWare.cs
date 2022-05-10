namespace Cs_ProCatApi.CustomMiddleware
{
    public class LogEntryMiddleWare
    {
        public readonly RequestDelegate next;
        public  ApiDbContext ctx;

        public LogEntryMiddleWare(RequestDelegate request)
        {
            next = request;
           
        }
        public async Task InvokeAsync(HttpContext context, ApiDbContext ctx)
        {
           this.ctx = ctx;
            LogInfo lohInfo = new LogInfo()
            {
                ControllerName = context.GetRouteValue("controller").ToString(),
                RequestMethodType = context.Request.Method,
                Date = DateTime.Now,
                Time = DateTime.Now.ToString("hh:mm:ss tt"),
            };
            await ctx.LogInfos.AddAsync(lohInfo);
            await ctx.SaveChangesAsync();
            await next(context);
        }
    }
}
