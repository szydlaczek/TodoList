using Microsoft.AspNetCore.Builder;

namespace TodoList.Api.Core
{
    public static class ApiExceptionMiddlewareExtensions
    {
        public static void UseApiException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiMiddleware>();
        }
    }
}