using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace WebAPI
{
    public class TestModel : HostPageModel
    {
        private readonly IConfiguration Configuration;

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Number { get; set; } = 1;


        public TestModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //[BindProperty(SupportsGet = true)]
        //public int Number { get; set; } = 1;

        public void OnGet()
        {
            var list = new List<string>() { "1", "2" };
            Genres = new SelectList(list);
            var dictionary = new Dictionary<int, string>()
            {
                {1,"No preflight" },
                {2,"Preflight" }

            };
            Genres = new SelectList(dictionary, "Key", "Value");
            SetHost(Configuration, true);
        }
    }
}