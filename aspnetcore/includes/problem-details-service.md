[Problem Details](https://www.rfc-editor.org/rfc/rfc7807.html) are not the only response format to describe an HTTP API error, however, they are commonly used to report errors for HTTP APIs.

The problem details service implements the <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> interface, which supports creating problem details in ASP.NET Core. The <xref:Microsoft.Extensions.DependencyInjection.ProblemDetailsServiceCollectionExtensions.AddProblemDetails(Microsoft.Extensions.DependencyInjection.IServiceCollection)> extension method on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> registers the default `IProblemDetailsService` implementation.

In ASP.NET Core apps, the following middleware generates problem details HTTP responses when `AddProblemDetails` is called, except when the [`Accept` request HTTP header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept) doesn't include one of the content types supported by the registered <xref:Microsoft.AspNetCore.Http.IProblemDetailsWriter> (default: `application/json`):

* <xref:Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware>: Generates a problem details response when a custom handler is not defined.
* <xref:Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware>: Generates a problem details response by default.
* <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware>: Generates a problem details response in development when the `Accept` request HTTP header doesn't include `text/html`.
