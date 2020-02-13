using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting
{
    #region snippet
    public class CCAD : Controller
    {
        public ContentResult GetADinfo(ControllerContext ctlCtx, int id)
        {
            return GetADinfo(ctlCtx, id.ToString());
        }

        public ContentResult GetADinfo(ControllerContext ctlCtx, string id = null)
        {
            var actionDesc = ctlCtx.ActionDescriptor;
            var template = actionDesc?.AttributeRouteInfo?.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;
            var order = actionDesc.AttributeRouteInfo?.Order;

            var tms = (template == null) ? "" : $"Template: {template}";
            var ids = (id == null) ? "" : $"id = {id}";
            var ors = (order == null) ? "" : $"Order = {order}";

            return Content($"{ids} {ors} {tms} {controllerName}.{actionName}");
        }
    }
    #endregion
}
