using CustomModelBindingSample.Binders;
using CustomModelBindingSample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomModelBindingSample
{
    public class Startup
    {

        #region callout
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase());

            services.AddMvc(options =>
            {
                // add custom binder to beginning of collection
                options.ModelBinderProviders.Insert(0, new AuthorEntityBinderProvider());
            });
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