using Microsoft.AspNetCore.Mvc;

namespace AppModelSample.Controllers
{
    #region AppModelController
    public class AppModelController : Controller
    {
        public string Description()
        {
            return "Description: " + ControllerContext.ActionDescriptor.Properties["description"];
        }
    }
    #endregion
}
