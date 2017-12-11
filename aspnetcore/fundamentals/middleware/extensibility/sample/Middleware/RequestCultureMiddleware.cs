using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Models;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1
    public class RequestCultureMiddleware : IMiddleware
    {
        private readonly AppDbContext _db;

        public RequestCultureMiddleware(AppDbContext db)
        {
            _db = db;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var cultureQuery = context.Request.Query["culture"];

            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

                _db.Add(new CultureRequest()
                    {
                        DT = DateTime.UtcNow, 
                        Culture = cultureQuery
                    });
                await _db.SaveChangesAsync();
            }

            await next(context);
        }
    }
    #endregion
}
