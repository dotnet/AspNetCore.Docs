using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class IndexModel : HostPageModel
    {
        private readonly IConfiguration Configuration;

        public IndexModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void OnGet()
        {
            SetHost(Configuration);
        }
    }
}