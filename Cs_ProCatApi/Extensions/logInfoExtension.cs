namespace Cs_ProCatApi.Extensions
{
    public static class LogInfoExtensions
    {
        public static void UseLogRequest(this IApplicationBuilder builder)
        {
            // Registering the CLass as Custom Middleware
            // so that it can be used in Pipeline
            builder.UseMiddleware<LogEntryMiddleWare>();
        }
    }
}
