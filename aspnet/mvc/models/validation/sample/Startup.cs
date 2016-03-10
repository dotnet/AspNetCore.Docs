using Microsoft.AspNet.Mvc;

namespace MVCMovie
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.MaxModelValidationErrors = 50;
            });           
        }
    }
}
