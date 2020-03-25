using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebAPI
{
    public class Test2Model : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string CtlNum { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Number { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(CtlNum))
            {
                CtlNum = "1";
            }
        }
    }
}