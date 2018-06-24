using System;
using System.Threading.Tasks;
using Build;
using Microsoft.AspNetCore.Http;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Models;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1

    public class BuildActivatedMiddleware : IMiddleware
    {
        readonly AppDbContext _db;

        public BuildActivatedMiddleware(Lazy<AppDbContext> factory)
        {
            _db = factory.GetInstance();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var keyValue = context.Request.Query["key"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                _db.Add(new Request()
                {
                    DT = DateTime.UtcNow,
                    MiddlewareActivation = "BuildActivatedMiddleware",
                    Value = keyValue
                });

                await _db.SaveChangesAsync();
            }

            await next(context);
        }
    }

    #endregion snippet1
}