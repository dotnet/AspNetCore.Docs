using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

// <snippet_etag>
[ApiController]
[Route("/[controller]")]
[OutputCache]
public class EtagController : ControllerBase
{
    public async Task GetAsync()
    {
        var etag = $"\"{Guid.NewGuid():n}\"";
        HttpContext.Response.Headers.ETag = etag;
        await Gravatar.WriteGravatar(HttpContext);
    }
}
// </snippet_etag>
