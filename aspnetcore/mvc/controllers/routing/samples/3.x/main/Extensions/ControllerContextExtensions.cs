using Microsoft.AspNetCore.Mvc;

#region snippet
internal static class ControllerContextExtensions
{
    public static IActionResult ToActionResult(this ControllerContext ctx, int id) =>
        ctx.ToActionResult(id.ToString());

    public static IActionResult ToActionResult(this ControllerContext ctx,
                                               string id = null, string msg = null)
    {
        var actionDescriptor = ctx.ActionDescriptor;
        var routeTemplate = actionDescriptor?.AttributeRouteInfo?.Template;
        var actionName = actionDescriptor.ActionName;
        var controllerName = actionDescriptor.ControllerName;
        var routeOrder = actionDescriptor.AttributeRouteInfo?.Order;
        var method = ctx.HttpContext.Request.Method;

        var tms = (routeTemplate == null) ? "" : $"Template = {routeTemplate}";
        var ids = (id == null) ? "" : $"id = {id}";
        var ors = (routeOrder == null) ? "" : $"Order = {routeOrder}";
        var methods = (method == "GET") ? "" : $"{method}";

        return new ContentResult { 
            Content = $"{methods} {ids} {ors} {tms} {controllerName}.{actionName} {msg}" };
    }
}
#endregion

