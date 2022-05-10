namespace Cs_ProCatApi.CustomMiddleware
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;
        public ApiDbContext ctx;
         
        public ExceptionMiddleware(RequestDelegate request)
        {
            next = request;
            
        }

        public async Task InvokeAsync(HttpContext context, ApiDbContext ctx)
        {
            this.ctx = ctx;
            try
            {
                await next(context);    
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                // 2. Read the exception MEssage
                string message = ex.Message;
                // 3. Set this information to ErrorInfo class
                var errorInfo = new ErrorInfo()
                {
                    ErrorCode = context.Response.StatusCode,
                    ErrorMessage = message
                };
                // 4. Write the ErrorInfo object into the Response
                // with JSON Serialization
                var errorLog = new ErrorLog()
                {
                    ControllerName = context.GetRouteValue("controller").ToString(),
                    RequestMethodType = context.Request.Method,
                    Date = DateTime.Now,
                    Time = DateTime.Now.ToString("hh:mm:ss tt"),
                    ErrorMessage = message,
                    StackTrace = ex.StackTrace.Trim()
                };

                 var res = await ctx.ErrorLogs.AddAsync(errorLog);
                await ctx.SaveChangesAsync();           
                await context.Response.WriteAsJsonAsync<ErrorInfo>(errorInfo);
            }

        }
    }
}
