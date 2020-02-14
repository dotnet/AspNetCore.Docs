using Microsoft.AspNetCore.Mvc;

namespace RoutingSample.Extensions
{
    #region snippet
    internal static class ControllerContextExtensions
    {
        public static IActionResult ToActionResult(this ControllerContext ctx, int id) =>
            ctx.ToActionResult(id.ToString());

        public static IActionResult ToActionResult(this ControllerContext ctx, string id = null)
        {
            var actionDescriptor = ctx.ActionDescriptor;
            var routeTemplate = actionDescriptor?.AttributeRouteInfo?.Template;
            var actionName = actionDescriptor.ActionName;
            var controllerName = actionDescriptor.ControllerName;
            var routeOrder = actionDescriptor.AttributeRouteInfo?.Order;

            var tms = (routeTemplate == null) ? "" : $"Template = {routeTemplate}";
            var ids = (id == null) ? "" : $"id = {id}";
            var ors = (routeOrder == null) ? "" : $"Order = {routeOrder}";

            return new ContentResult { Content = $"{ids} {ors} {tms} {controllerName}.{actionName}" };
        }
    }
    #endregion
}
