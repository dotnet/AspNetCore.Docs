using Microsoft.AspNetCore.Mvc;

namespace RoutingSample.Snippets.Controllers;

[NonController]
// <snippet_Class>
[Host("contoso.com", "adventure-works.com")]
public class HostsController : Controller
{
    public IActionResult Index() =>
        View();

    [Host("example.com")]
    public IActionResult Example() =>
        View();
}
// </snippet_Class>
