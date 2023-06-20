using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters;

public class LoggingResponseHeaderFilter : IActionFilter
{
    private readonly ILogger _logger;
    private readonly string _name;
    private readonly string _value;

    public LoggingResponseHeaderFilter(
            ILogger<LoggingResponseHeaderFilter> logger, string name, string value) =>
        (_logger, _name, _value) = (logger, name, value);

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation(
            $"- {nameof(LoggingResponseHeaderFilter)}.{nameof(OnActionExecuting)}");

        context.HttpContext.Response.Headers.Add(_name, _value);
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
