using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RoutingSample
{
    public class StartupConstraint
    {
        public StartupConstraint(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // <snippet>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(options =>
            {
                options.ConstraintMap.Add("customName", typeof(MyCustomConstraint));
            });
        }
        // </snippet>

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    // <snippet2>
    class MyCustomConstraint : IRouteConstraint
    {
        private Regex _regex;

        public MyCustomConstraint()
        {
            _regex = new Regex(@"^[1-9]*$",
                                RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
                                TimeSpan.FromMilliseconds(100));
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object value))
            {
                var parameterValueString = Convert.ToString(value,
                                                            CultureInfo.InvariantCulture);
                if (parameterValueString == null)
                {
                    return false;
                }

                return _regex.IsMatch(parameterValueString);
            }

            return false;
        }
    }
    // </snippet2>
}
