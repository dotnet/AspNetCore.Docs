using AppModelSample.Conventions;
using Microsoft.AspNetCore.Mvc;

namespace AppModelSample.Controllers
{
    #region DescriptionAttributesController
    #region ControllerDescription
    [ControllerDescription("Controller Description")]
    public class DescriptionAttributesController : Controller
    {
        public string Index()
        {
            return "Description: " + ControllerContext.ActionDescriptor.Properties["description"];
        }
        #endregion

        [ActionDescription("Action Description")]
        public string UseActionDescriptionAttribute()
        {
            return "Description: " + ControllerContext.ActionDescriptor.Properties["description"];
        }
    }
    #endregion
}
