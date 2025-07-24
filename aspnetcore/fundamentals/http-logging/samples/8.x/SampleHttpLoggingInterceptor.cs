using Microsoft.AspNetCore.HttpLogging;

namespace HttpLoggingSample;

internal sealed class SampleHttpLoggingInterceptor : IHttpLoggingInterceptor
{
    public ValueTask OnRequestAsync(HttpLoggingInterceptorContext logContext)
    {
        if (logContext.HttpContext.Request.Method == "POST")
        {
            // Don't log anything if the request is a POST.
            logContext.LoggingFields = HttpLoggingFields.None;
        }

        // Don't enrich if we're not going to log any part of the request.
        if (!logContext.IsAnyEnabled(HttpLoggingFields.Request))
        {
            return default;
        }

        if (logContext.TryDisable(HttpLoggingFields.RequestPath))
        {
            RedactPath(logContext);
        }

        if (logContext.TryDisable(HttpLoggingFields.RequestHeaders))
        {
            RedactRequestHeaders(logContext);
        }

        EnrichRequest(logContext);

        return default;
    }

    public ValueTask OnResponseAsync(HttpLoggingInterceptorContext logContext)
    {
        // Don't enrich if we're not going to log any part of the response
        if (!logContext.IsAnyEnabled(HttpLoggingFields.Response))
        {
            return default;
        }

        if (logContext.TryDisable(HttpLoggingFields.ResponseHeaders))
        {
            RedactResponseHeaders(logContext);
        }

        EnrichResponse(logContext);

        return default;
    }

    private void RedactPath(HttpLoggingInterceptorContext logContext)
    {
        logContext.AddParameter(nameof(logContext.HttpContext.Request.Path), "RedactedPath");
    }

    private void RedactRequestHeaders(HttpLoggingInterceptorContext logContext)
    {
        foreach (var header in logContext.HttpContext.Request.Headers)
        {
            logContext.AddParameter(header.Key, "RedactedHeader");
        }
    }

    private void EnrichRequest(HttpLoggingInterceptorContext logContext)
    {
        logContext.AddParameter("RequestEnrichment", "Stuff");
    }

    private void RedactResponseHeaders(HttpLoggingInterceptorContext logContext)
    {
        foreach (var header in logContext.HttpContext.Response.Headers)
        {
            logContext.AddParameter(header.Key, "RedactedHeader");
        }
    }

    private void EnrichResponse(HttpLoggingInterceptorContext logContext)
    {
        logContext.AddParameter("ResponseEnrichment", "Stuff");
    }
}

