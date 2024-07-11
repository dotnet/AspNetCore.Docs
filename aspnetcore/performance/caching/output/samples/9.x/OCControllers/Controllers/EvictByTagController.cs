using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

// <snippet_evictbytag>
[ApiController]
[Route("/[controller]/purge/{tag}")]
[OutputCache]
public class EvictByTagController : ControllerBase
{
    [HttpPost]
    public async Task PostAsync(IOutputCacheStore cache, string tag)
    {
        await cache.EvictByTagAsync(tag, default);
    }
}
// </snippet_evictbytag>
