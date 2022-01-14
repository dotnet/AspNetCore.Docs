#region snippet
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace AuthScheme.Controllers;

[Authorize(AuthenticationSchemes = AuthSchemes)]
public class MixedController : Controller
{
    #region snippet2
    private const string AuthSchemes =
        CookieAuthenticationDefaults.AuthenticationScheme + "," +
        JwtBearerDefaults.AuthenticationScheme;
    #endregion
    public ContentResult Index()
    {
        return Content(MyWidgets.GetMyContent());
    } 
}
#endregion