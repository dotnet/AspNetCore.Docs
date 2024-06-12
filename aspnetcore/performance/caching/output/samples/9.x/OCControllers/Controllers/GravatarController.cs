using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GravatarController : ControllerBase
{
    private readonly ILogger<GravatarController> _logger;

    public GravatarController(ILogger<GravatarController> logger)
    {
        _logger = logger;
    }

#if oneendpoint
    //<oneendpoint>
    [HttpGet()]
    [OutputCache()]
    public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}
//</oneendpoint>
#endif
