### Performance improvements

Kestrel's HTTP/1.1 request parser now uses a non-throwing code path for handling malformed requests. Instead of throwing <xref:Microsoft.AspNetCore.Http.BadHttpRequestException> on every parse failure, the parser returns a result struct indicating success, incomplete, or error states. In scenarios with many malformed requests — such as port scanning, malicious traffic, or misconfigured clients — this eliminates expensive exception handling overhead and improves throughput by up to 20-40%. There's no impact on valid request processing.

The HTTP logging middleware now pools its `ResponseBufferingStream` instances, reducing per-request allocations when response body logging or interceptors are enabled.
