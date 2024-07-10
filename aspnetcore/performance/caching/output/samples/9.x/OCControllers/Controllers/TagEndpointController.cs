using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

// <snippet_tagendpoint>
[ApiController]
[Route("/[controller]")]
[OutputCache(Tags = new[] { "tag-blog", "tag-all" })]
public class TagEndpointController : ControllerBase
{
    public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}
// </snippet_tagendpoint>
