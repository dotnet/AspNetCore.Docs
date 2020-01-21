using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace RoutingSample
{
	public class StartupSW
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthorization();
		}

		#region snippet
		public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
		{
			app.Use(next => async context =>
			{
				using (new MyStopwatch(logger, "Time 1"))
				{
					await next(context);
				}

			});

			app.UseRouting();

			app.Use(next => async context =>
			{
				using (new MyStopwatch(logger, "Time 2"))
				{
					await next(context);
				}
			});

			app.UseAuthorization();

			app.Use(next => async context =>
			{
				using (new MyStopwatch(logger, "Time 3"))
				{
					await next(context);
				}
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Timing test.");
				});
			});
		}
		#endregion
	}

	#region snippetSW
	public class MyStopwatch : IDisposable
	{
		ILogger<Startup> _logger;
		string _message;
		Stopwatch _sw;

		public  MyStopwatch(ILogger<Startup> logger, string message)
		{
			_logger = logger;
			_message = message;
			_sw = Stopwatch.StartNew();
		}

		private bool disposedValue = false; 

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_logger.LogInformation("{Message }: {ElapsedMilliseconds}ms",
											_message, _sw.ElapsedMilliseconds);
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
	}
	#endregion
}
