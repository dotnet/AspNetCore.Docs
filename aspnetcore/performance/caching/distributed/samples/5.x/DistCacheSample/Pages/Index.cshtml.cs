using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;

namespace SampleApp.Pages
{
    #region snippet_IndexModel
    public class IndexModel : PageModel
    {
        private readonly IDistributedCache _cache;

        public IndexModel(IDistributedCache cache)
        {
            _cache = cache;
        }

        public string CachedTimeUTC { get; set; }
        public string ASP_Environment { get; set; }

        public async Task OnGetAsync()
        {
            CachedTimeUTC = "Cached Time Expired";
            var encodedCachedTimeUTC = await _cache.GetAsync("cachedTimeUTC");

            if (encodedCachedTimeUTC != null)
            {
                CachedTimeUTC = Encoding.UTF8.GetString(encodedCachedTimeUTC);
            }

            ASP_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (String.IsNullOrEmpty(ASP_Environment))
            {
                ASP_Environment = "Null, so Production";
            }
        }

        public async Task<IActionResult> OnPostResetCachedTime()
        {
            var currentTimeUTC = DateTime.UtcNow.ToString();
            byte[] encodedCurrentTimeUTC = Encoding.UTF8.GetBytes(currentTimeUTC);
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(20));
            await _cache.SetAsync("cachedTimeUTC", encodedCurrentTimeUTC, options);

            return RedirectToPage();
        }
    }
    #endregion
}
