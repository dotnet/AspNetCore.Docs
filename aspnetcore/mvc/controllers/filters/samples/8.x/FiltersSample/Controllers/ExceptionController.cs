using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers;

// <snippet_Class>
[TypeFilter<SampleExceptionFilter>]
public class ExceptionController : Controller
{
    public IActionResult Index() =>
        Content($"- {nameof(ExceptionController)}.{nameof(Index)}");
}
// </snippet_Class>
