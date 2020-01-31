using Microsoft.AspNetCore.Mvc;

public class TestController : Controller
{
    #region snippet
    public IActionResult Index()
    {
        var url = Url.Action("Buy", "Products", new { id = 17, color = "red" });
        return Content(url);
    }
    #endregion
    #region snippet2
    public IActionResult Index2()
    {
        var url = Url.Action("Buy", "Products", new { id = 17 }, protocol: Request.Scheme);
        return Content(url);
    }
    #endregion
}