<!-- 
[!INCLUDE[](~/release-notes/aspnetcore-9/includes/opt_out_metrics.md)]
-->

### Opt-out of HTTP metrics on certain endpoints and requests

.NET 9 adds the ability to opt-out of HTTP metrics and not record a value for certain endpoints and requests. It's common for apps to have endpoints that are frequently called by automated systems, such as a health checks endpoint. Recording information about those requests isn't useful.

HTTP requests to an endpoint can be excluded from metrics by adding metadata. Either add the [`[DisableHttpMetrics]`](https://source.dot.net/#Microsoft.AspNetCore.Http.Extensions/DisableHttpMetricsAttribute.cs,258cd11ebe5f2ee1) attribute to your Web API controller, SignalR hub or gRPC service; or call [DisableHttpMetrics](https://source.dot.net/#Microsoft.AspNetCore.Http.Extensions/HttpMetricsEndpointConventionBuilderExtensions.cs,7537104878c6f44a) when mapping endpoints in app startup:

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/Metrics/Program.cs" id="snippet_1" highlight="5":::

In more advanced scenarios where a request doesn't map to an endpoint, or you want to opt-out HTTP requests dynamically, the `MetricsDisabled` property has been added to `IHttpMetricsTagsFeature`. Set `MetricsDisabled` to true during a HTTP request to opt-out.

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/Metrics/Program.cs" id="snippet_2":::
