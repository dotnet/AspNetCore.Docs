### Improved Kestrel connection metrics

We've made a significant improvement to Kestrel's connection metrics by including metadata about why a connection failed. The [`kestrel.connection.duration`](/dotnet/core/diagnostics/built-in-metrics-aspnetcore#metric-kestrelconnectionduration) metric now includes the connection close reason in the `error.type` attribute.

Here is a small sample of the `error.type` values:

- `tls_handshake_failed` - The connection requires TLS, and the TLS handshake failed.
- `connection_reset` - The connection was unexpectedly closed by the client while requests were in progress.
- `request_headers_timeout` - Kestrel closed the connection because it didn't receive request headers in time.
- `max_request_body_size_exceeded` - Kestrel closed the connection because uploaded data exceeded max size.

Previously, diagnosing Kestrel connection issues required a server to record detailed, low-level logging. However, logs can be expensive to generate and store, and it can be difficult to find the right information among the noise.

Metrics are a much cheaper alternative that can be left on in a production environment with minimal impact. Collected metrics can [drive dashboards and alerts](/aspnet/core/log-mon/metrics/metrics#show-metrics-on-a-grafana-dashboard). Once a problem is identified at a high-level with metrics, further investigation using logging and other tooling can begin.

We expect improved connection metrics to be useful in many scenarios:

- Investigating performance issues caused by short connection lifetimes.
- Observing ongoing external attacks on Kestrel that impact performance and stability.
- Recording attempted external attacks on Kestrel that Kestrel's built-in security hardening prevented.

For more information, see [ASP.NET Core metrics](/aspnet/core/log-mon/metrics/metrics).
