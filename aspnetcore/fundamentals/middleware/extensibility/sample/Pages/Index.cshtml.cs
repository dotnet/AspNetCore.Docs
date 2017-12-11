using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Models;

namespace MiddlewareExtensibilitySample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public string CurrentCultureSetting { get; private set; }

        public List<CultureRequest> CultureRequests { get; private set; }

        public async Task OnGetAsync()
        {
            CurrentCultureSetting = $"{CultureInfo.CurrentCulture.TwoLetterISOLanguageName}/{CultureInfo.CurrentCulture.ThreeLetterISOLanguageName} {CultureInfo.CurrentCulture.DisplayName}";

            CultureRequests = await _db.CultureRequests.ToListAsync();
        }
    }
}
