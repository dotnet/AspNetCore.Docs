using CustomModelBindingSample.Binders;
using CustomModelBindingSample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomModelBindingSample
{
    public class Startup
    {
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("App"));

            services.AddMvc(options =>
                {
                    // add custom binder to beginning of collection
                    options.ModelBinderProviders.Insert(0, new AuthorEntityBinderProvider());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        #endregion

        public void Configure(IApplicationBuilder app, AppDbContext db)
        {
            app.UseStaticFiles();

            app.UseMvc();

            PopulateTestData(db);
        }

        private void PopulateTestData(AppDbContext db)
        {
            db.Authors.Add(new Author() { Name = "Steve Smith", Twitter = "ardalis", GitHub = "ardalis", BlogUrl = "ardalis.com" });
            db.SaveChanges();
        }
    }
}
