using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PageFilter.Filters;

namespace PageFilter
{
    public class Startup2
    {
        ILogger _logger;
        public Startup2(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<GlobalFiltersLogger>();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet2
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
               .AddRazorPagesOptions(options =>
               {
                   options.Conventions.AddFolderApplicationModelConvention(
                       "/subFolder",
                       model => model.Filters.Add(new SampleAsyncPageFilter(_logger)));
               });
        }
        #endregion

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
