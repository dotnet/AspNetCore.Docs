public class AsyncLoggingFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    {
        await Trace.WriteAsync("Executing action named {0} for request {1}.", 
            actionContext.ActionDescriptor.ActionName, 
            actionContext.Request.GetCorrelationId());
    }
}