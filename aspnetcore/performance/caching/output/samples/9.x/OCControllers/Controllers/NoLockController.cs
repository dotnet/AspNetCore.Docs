using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OCControllers.Controllers;

// <snippet_selectnolock>
[ApiController]
[Route("/[controller]")]
[OutputCache(PolicyName = "NoLock")]
public class NoLockController : ControllerBase
{
    public async Task GetAsync()
    {
        await Gravatar.WriteGravatar(HttpContext);
    }
}
// </snippet_selectnolock>
