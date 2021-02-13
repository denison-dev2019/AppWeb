using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AppWeb.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //await exception.ShipAsync(context);
            // Implementar o que vou fazer com a exceção aqui


        }


    }
}
