using Microsoft.AspNetCore.Mvc;

namespace RoutingSample.Snippets.Controllers;
    
// <snippet_Host>
[Host("contoso.com", "adventure-works.com")]
public class ProductsController : Controller
{
    public IActionResult Index() =>
        View();

    [Host("example.com")]
    public IActionResult Example() =>
        View();
}
// </snippet_Host>
