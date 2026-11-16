using Microsoft.AspNetCore.Mvc;

namespace RoutingSample.Snippets.Controllers;
    
[ApiController]
[Route("api/[controller]")]
public class BetterNoZeroesController : ControllerBase
{
    // <snippet_Action>
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        if (id.Contains('0'))
        {
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        return Content(id);
    }
    // </snippet_Action>
}
