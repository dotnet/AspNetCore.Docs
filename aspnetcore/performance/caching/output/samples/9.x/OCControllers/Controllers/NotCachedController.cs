using Microsoft.AspNetCore.Mvc;

namespace OCControllers.Controllers;

[ApiController]
[Route("/")]
public class NotCachedController : ControllerBase
{
     public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}
