using Microsoft.AspNetCore.Mvc;

namespace RoutingSample.Snippets.Controllers;

// <snippet_Class>
public class GadgetController : ControllerBase
{
    public IActionResult Index() =>
        Content(Url.Action("Edit", new { id = 17 })!);
}
// </snippet_Class>
