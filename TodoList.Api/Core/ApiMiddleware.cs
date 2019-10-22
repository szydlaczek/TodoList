using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using TodoList.Domain.Exceptions;

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
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result = "";
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (exception is TodoListException)
            {
                var res = new
                {
                    Message = "Something goes wrong, Contact with administrator"
                };
                result = JsonConvert.SerializeObject(res);
            }
            if (exception is Exception)
            {
                var res = new
                {
                    Message = "Something goes wrong, Contact with administrator"
                };

                result = JsonConvert.SerializeObject(res);
            }

            return context.Response.WriteAsync(result);
        }
    }
}