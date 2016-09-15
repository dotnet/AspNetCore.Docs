using Microsoft.AspNetCore.Mvc;
#region snippet
[Route("Home")]
public class HomeController : Controller
{
    [Route("")] // Combines to define the route template "Home"
    [Route("Index")] // Combines to define the route template "Home/Index"
    [Route("/")] // Does not combine, defines the route template ""
    public IActionResult Index()
    {
        return View();
    }

    [Route("About")] // Combines to define the route template "Home/About"
    public IActionResult About()
    {
        return View();
    }   
}
#endregion

/*
 [Route("Contact")] // Combines to define the route template "Home/Contact"
    public IActionResult Contact()
    {
        return View();
    }

    */