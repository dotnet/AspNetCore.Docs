using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Models;

namespace MiddlewareExtensibilitySample.Middleware
{
    // <snippet1>
    public class ConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public ConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            var keyValue = context.Request.Query["key"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                db.Add(new Request()
                    {
                        DT = DateTime.UtcNow, 
                        MiddlewareActivation = "ConventionalMiddleware", 
                        Value = keyValue
                    });

                await db.SaveChangesAsync();
            }

            await _next(context);
        }
    }
    // </snippet1>
}
