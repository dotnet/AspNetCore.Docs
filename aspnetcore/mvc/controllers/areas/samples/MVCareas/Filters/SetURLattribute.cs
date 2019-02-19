using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCareas.Filters
{
    public class SetURLattribute : ActionFilterAttribute
    {
        public SetURLattribute() { }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            if (controller == null)
            {
                return;
            }

            controller.ViewData["url"] = controller.Url.Action("About", "Manage", new { area = "Products" });
            controller.ViewData["urlNo"] = controller.Url.Action("About", "Manage");

            base.OnActionExecuting(filterContext);
        }
    }
}
