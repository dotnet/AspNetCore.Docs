using System;
using Microsoft.AspNetCore.Mvc.Filters;

#region snippet1
[AttributeUsage(AttributeTargets.Class)]
public class ReplaceRouteValueFilterAttribute : Attribute, IPageFilter
{
    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        // Called after the handler method executes before the result.
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        // Called before the handler method executes after model binding is complete.
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        // Called after a handler method is selected but before model binding occurs.
        context.RouteData.Values.TryGetValue("globalAttribute", 
            out var globalAttributeValue);
        if (string.Equals((string)globalAttributeValue, "TriggerValue", 
            StringComparison.Ordinal))
        {
            context.RouteData.Values["globalAttribute"] = "ReplacementValue";
        }
    }
}
#endregion
