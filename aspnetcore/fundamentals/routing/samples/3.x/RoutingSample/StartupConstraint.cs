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

		#region snippet
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddRouting(options =>
			{
				options.ConstraintMap.Add("customName", typeof(MyCustomConstraint));
			});
		}
		#endregion

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

	class MyCustomConstraint : IRouteConstraint
	{
		public bool Match(HttpContext httpContext, IRouter route, string routeKey, 
						  RouteValueDictionary values, RouteDirection routeDirection)
		{
			if ( route == null || httpContext == null ||
				routeKey == null || values == null)
			{
				throw new ArgumentNullException("Null arg");
			}


			if (values.TryGetValue(routeKey, out object value))
			{
				var parameterValueString = Convert.ToString(value, CultureInfo.InvariantCulture);
				return new Regex(@"^[a-z]*$",
								RegexOptions.CultureInvariant
								| RegexOptions.IgnoreCase).IsMatch(parameterValueString);
			}

			return false;
		}
	}

	/* API Controller
		[HttpGet("{id:customName}")]
		public ActionResult<string> Get(string id)
		{
			return "OK";
		}
		*/
}
