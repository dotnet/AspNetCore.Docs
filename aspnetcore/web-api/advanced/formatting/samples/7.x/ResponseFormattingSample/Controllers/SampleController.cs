using Microsoft.AspNetCore.Mvc;
using ResponseFormattingSample.Snippets.Models;

namespace ResponseFormattingSample.Controllers;

[ApiController]
[Route("/api/Sample")]
public class SampleController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(SampleModel sampleModel)
        => Ok(sampleModel);
}
