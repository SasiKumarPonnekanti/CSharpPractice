namespace Cs_ProCatApi.Extensions
{
    public static class ErrorInfoExtensions
    {
        public static void UseRequestException(this IApplicationBuilder builder)
        {
            // Registering the CLass as Custom Middleware
            // so that it can be used in Pipeline
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
