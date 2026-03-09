#pragma warning disable EXTEXP0013

using Microsoft.AspNetCore.Diagnostics.Logging;
using Microsoft.Extensions.Diagnostics.Enrichment;

public class CustomHttpLogEnricher : IHttpLogEnricher
{
    public void Enrich(IEnrichmentTagCollector collector, HttpContext httpContext)
    {
        // Add custom tags based on the incoming HTTP request
        collector.Add("request_method", httpContext.Request.Method);
        collector.Add("request_scheme", httpContext.Request.Scheme);

        // Add tags based on the response status code (available during the response phase)
        collector.Add("response_status_code", httpContext.Response.StatusCode);

        // Add tags based on user authentication status
        if (httpContext.User?.Identity?.IsAuthenticated is true)
        {
            collector.Add("user_authenticated", true);
        }
    }
}
