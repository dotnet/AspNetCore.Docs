using Microsoft.AspNetCore.Mvc;

#region snippet
internal static class ControllerContextExtensions
{
    public static IActionResult ToActionResult(this ControllerContext ctx, int ?id, string msg = null) =>
        ctx.ToActionResult(id?.ToString(), msg);

    public static IActionResult ToActionResult(this ControllerContext ctx,
                                               string id = null, string msg = null)
    {
        return new ContentResult {  Content = ToCtxString(ctx,id,msg) };
    }

    public static string ToCtxString(this ControllerContext ctx, int? id, string msg = null) =>
        ctx.ToCtxString(id?.ToString(), msg);

    public static string ToCtxString(this ControllerContext ctx,
                                               string id = null, string msg = null)
    {
        var actionDescriptor = ctx.ActionDescriptor;
        var routeTemplate = actionDescriptor?.AttributeRouteInfo?.Template;
        var routeName = actionDescriptor.AttributeRouteInfo?.Name;
        var actionName = actionDescriptor.ActionName;
        var controllerName = actionDescriptor.ControllerName;
        var routeOrder = actionDescriptor.AttributeRouteInfo?.Order;
        var method = ctx.HttpContext.Request.Method;
        var path = ctx.HttpContext.Request.Path;

        var areaStr = string.Empty;
        object area;
        if (ctx.RouteData.Values.TryGetValue("area", out area))
        {
            areaStr = $"area:" + area.ToString();
        }

        var tms = (routeTemplate == null) ? "" : $"Template = {routeTemplate}";
        var ids = (string.IsNullOrEmpty(id)) ? "" : $"id = {id}";
        var ors = (routeOrder == null) ? "" : $"Order = {routeOrder}";
        var methods = (method == "GET") ? "" : $"{method}";

        return $"{methods} {path} {areaStr} {ids} {ors} {tms} " +
            $"{controllerName}.{actionName} {routeName} {msg}";        
    }
}
#endregion