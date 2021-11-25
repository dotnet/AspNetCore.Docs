using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HandleErrorsSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorsController : ControllerBase
{
    // <snippet_Throw>
    [HttpGet("Throw")]
    public IActionResult Throw() =>
        throw new Exception("Sample exception.");
    // </snippet_Throw>

    // <snippet_ConsistentEnvironments>
    [Route("/error-development")]
    public IActionResult HandleErrorDevelopment(
        [FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return NotFound();
        }

        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        return Problem(
            detail: exceptionHandlerFeature.Error.StackTrace,
            title: exceptionHandlerFeature.Error.Message);
    }

    // <snippet_HandleError>
    [Route("/error")]
    public IActionResult HandleError() =>
        Problem();
    // </snippet_HandleError>
    // </snippet_ConsistentEnvironments>
}
