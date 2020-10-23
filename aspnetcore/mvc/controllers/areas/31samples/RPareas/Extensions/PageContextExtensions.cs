using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region snippet
internal static class PageContextExtensions
{
    public static IActionResult ToActionResultP(this PageContext ctx, int ?id, string msg = null) =>
        ctx.ToActionResultP(id?.ToString(), msg);

    public static IActionResult ToActionResultP(this PageContext ctx,
                                               string id = null, string msg = null)
    {
        return new ContentResult {  Content = ToCtxStringP(ctx,id,msg) };
    }

    public static string ToCtxStringP(this PageContext ctx, int? id, string msg = null) =>
        ctx.ToCtxStringP(id?.ToString(), msg);

    public static string ToCtxStringP(this PageContext ctx,
                                               string id = null, string msg = null)
    {
        var actionDescriptor = ctx.ActionDescriptor;
        var routeTemplate = actionDescriptor?.AttributeRouteInfo?.Template;
        var routeName = actionDescriptor.AttributeRouteInfo?.Name;
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
            $"  {routeName} {msg}";        
    }
}
#endregion