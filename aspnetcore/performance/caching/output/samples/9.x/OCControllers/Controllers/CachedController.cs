using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

// <snippet_oneendpoint>
[ApiController]
[Route("/[controller]")]
[OutputCache]
public class CachedController : ControllerBase
{
    public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}
// </snippet_oneendpoint>
