using CustomXMLrepo.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomXMLrepo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataProtectionDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, DataProtectionDbContext dataProtectionDbContext)
        {
            _logger = logger;
            _context = dataProtectionDbContext;
        }

        public IList<XmlKey> XmlKey { get; set; }

        public async Task<Microsoft.AspNetCore.Mvc.ContentResult> OnGetAsync()
        {
            XmlKey = await _context.XmlKeys.ToListAsync();
            var count = XmlKey.Count();
            return Content($"Key Count = {count}");
        }
    }
}