using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class MyController : ControllerBase
{
    // GET /api/my/red/2/joe
    // GET /api/my/red/2
    // GET /api/my
    [Route("api/[controller]/{color}/{id:int?}/{name?}")]
    public IActionResult GetByIdAndOptionalName(string color, int id=1, string? name = null)
    {
        return Ok($"{color} {id} {name ?? ""}");
    }
}
