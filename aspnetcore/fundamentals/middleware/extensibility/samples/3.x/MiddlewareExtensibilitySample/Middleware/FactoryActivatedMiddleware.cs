using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Models;

namespace MiddlewareExtensibilitySample.Middleware
{
    // <snippet1>
    public class FactoryActivatedMiddleware : IMiddleware
    {
        private readonly AppDbContext _db;

        public FactoryActivatedMiddleware(AppDbContext db)
        {
            _db = db;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var keyValue = context.Request.Query["key"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                _db.Add(new Request()
                    {
                        DT = DateTime.UtcNow, 
                        MiddlewareActivation = "FactoryActivatedMiddleware", 
                        Value = keyValue
                    });

                await _db.SaveChangesAsync();
            }

            await next(context);
        }
    }
    // </snippet1>
}
