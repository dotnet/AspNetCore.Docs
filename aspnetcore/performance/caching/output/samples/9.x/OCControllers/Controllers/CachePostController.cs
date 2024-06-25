using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

[ApiController]
[Route("/[controller]")]
[OutputCache(PolicyName = "CachePost")]
public class CachePostController : ControllerBase
{
    [HttpPost]
    public async Task PostAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}

