using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigSample
{
    public class ArrayModel : PageModel
    {
        private readonly IConfiguration Config;
        public ArrayExample _array { get; private set; }


        public ArrayModel(IConfiguration config)
        {
            Config = config;
        }

        public ContentResult OnGet()
        {
            _array = Config.GetSection("array").Get<ArrayExample>();
            string s = null;

            for (int j = 0; j < _array.Entries.Length; j++)
            {
                s += "Index: " + j.ToString() + "  Value: " + _array.Entries[j] + "\n";
            }

            return Content(s);
        }
    }
}