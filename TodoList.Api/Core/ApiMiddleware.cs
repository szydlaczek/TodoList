using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Api.Core
{
    public class ApiMiddleware
    {
        private readonly RequestDelegate _next;
        public ApiMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {              

                await _next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //_logger.LogError($"Something went wrong: {exception}  {exception.Message}");

            //context.Response.ContentType = "application/json";

            //string result = new ErrorResponse() { Message = exception.Message }.ToString();
            //context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //return context.Response.WriteAsync(result);

            //var errorResponse = GetErrorResponse(exception);

            //context.Response.StatusCode = (int)errorResponse.StatusCode;
            //context.Response.ContentType = errorResponse.ResponseType;
            //string result = JsonConvert.SerializeObject(new
            //{
            //    errors = errorResponse.Errors
            //});
            //return context.Response.WriteAsync(result);
            throw new Exception();
        }
    }
}
