public class HomeController : Controller
{
    [RedirectMobileDevicesToMobileArea] // Applies just to this action
    public ActionResult Index()
    {
        // ...
    }
}