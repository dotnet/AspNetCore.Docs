using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers;

// <snippet_Class>
[TypeFilter(typeof(SampleExceptionFilter))]
public class ExceptionController : Controller
{
    public IActionResult Index() =>
        throw new Exception($"Testing {nameof(SampleExceptionFilter)}.");
}
// </snippet_Class>