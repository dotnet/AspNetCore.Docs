using Filters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers;

// <snippet_Class>
// <snippet_ClassIndex>
[ResponseHeader("X-Filter-Header", "Filter Value")]
public class ResponseHeaderController : ControllerBase
{
    public IActionResult Index() =>
        Content("Examine the response headers using the F12 developer tools.");

    // ...
    // </snippet_ClassIndex>

    [ResponseHeader("X-Another-Filter-Header", "Another Filter Value")]
    public IActionResult Multiple() =>
        Content("Examine the response headers using the F12 developer tools.");
}
// </snippet_Class>
