using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebR2C
{
    #region snippet
    public static class UserApi
    {
        public static void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/user/{id}", async context =>
            {
                // Get user logic...
            });

            endpoints.MapGet("/user", async context =>
            {
                // Get all users logic...
            });
        }
    }
    #endregion
}
