using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
