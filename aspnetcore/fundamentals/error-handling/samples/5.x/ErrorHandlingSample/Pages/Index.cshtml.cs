using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ErrorHandlingSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(int? code = null)
        {
            if (code.HasValue)
            {
                if (code == 1 )
                {
                    throw new FileNotFoundException("File not found exception thrown in index.chtml");
                }
                else if(code == 2)
                {
                    return StatusCode(500);
                }
            }

            return Page();
        }
    }
}
