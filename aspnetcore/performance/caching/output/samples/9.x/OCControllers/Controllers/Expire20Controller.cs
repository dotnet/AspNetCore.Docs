using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

[ApiController]
[Route("/[controller]")]
[OutputCache(PolicyName = "Expire20")]
public class Expire20Controller : ControllerBase
{
    public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}

