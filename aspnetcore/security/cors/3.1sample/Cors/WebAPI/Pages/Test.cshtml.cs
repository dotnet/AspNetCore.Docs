using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class TestModel : HostPageModel
    {
        private readonly IConfiguration Configuration;

        public TestModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public int Number { get; set; } = 1;

        public void OnGet()
        {
            SetHost(Configuration,true);
        }
    }
}