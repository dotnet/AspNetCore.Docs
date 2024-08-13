### Opt-out of HTTP metrics on certain endpoints and requests

.NET 9 introduces the ability to opt-out of HTTP metrics for specific endpoints and requests. Opting out of recording metrics is beneficial for endpoints frequently called by automated systems, such as health checks. Recording metrics for these requests is generally unnecessary.

HTTP requests to an endpoint can be excluded from metrics by adding metadata. Either:

* Add the [`[DisableHttpMetrics]`](https://source.dot.net/#Microsoft.AspNetCore.Http.Extensions/DisableHttpMetricsAttribute.cs,258cd11ebe5f2ee1) attribute to the Web API controller, SignalR hub or gRPC service.
* Call [DisableHttpMetrics](https://source.dot.net/#Microsoft.AspNetCore.Http.Extensions/HttpMetricsEndpointConventionBuilderExtensions.cs,7537104878c6f44a) when mapping endpoints in app startup:

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/Metrics/Program.cs" id="snippet_1" highlight="5":::

The `MetricsDisabled` property has been added to `IHttpMetricsTagsFeature` for:

* Advanced scenarios where a request doesn't map to an endpoint.
* Dynamically disabling metrics collection for specific HTTP requests.

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/Metrics/Program.cs" id="snippet_2":::
