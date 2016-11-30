using AppModelSample.Conventions;
using Microsoft.AspNetCore.Mvc;

namespace AppModelSample.Controllers
{
    #region ParameterModelController
    public class ParameterModelController : Controller
    {
        public string GetById([SpecialParameter]int id)
        {
            return "BinderModelName: " + 
                ControllerContext.ActionDescriptor.Parameters[0].BindingInfo?.BinderModelName;
        }
    }
    #endregion
}
