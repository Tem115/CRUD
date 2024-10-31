using CRUD.Middlewares;

namespace CRUD.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestLoggerMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
