using Microsoft.AspNetCore.Mvc;

namespace KestrelSample.Snippets.Controllers;

public class SampleController : ControllerBase
{
    // <snippet_RequestSizeLimit>
    [RequestSizeLimit(100_000_000)]
    public IActionResult Get()
    // </snippet_RequestSizeLimit>
        => NoContent();
}
