using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class Test2Model : HostPageModel
    {
        private readonly IConfiguration Configuration;

        public Test2Model(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public int Number { get; set; } = 1;


        public void OnGet()
        {
            SetHost(Configuration);
        }
    }
}