using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

// <snippet_selectquery>
[ApiController]
[Route("/[controller]")]
[OutputCache(PolicyName = "VaryByValue")]
public class VaryByValueController : ControllerBase
{
    public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}
// </snippet_selectquery>
