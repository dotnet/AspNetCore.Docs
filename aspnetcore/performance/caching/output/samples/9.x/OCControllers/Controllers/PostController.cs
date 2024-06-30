using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

// <snippet_post>
[ApiController]
[Route("/[controller]")]
[OutputCache(PolicyName = "CachePost")]
public class PostController : ControllerBase
{
    public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}
// </snippet_post>
