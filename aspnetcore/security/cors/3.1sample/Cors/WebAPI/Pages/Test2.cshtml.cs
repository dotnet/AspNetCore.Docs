using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI
{
    public class Test2Model : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Port { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(Port))
            {
                Port = "5001";
            }
        }
    }
}