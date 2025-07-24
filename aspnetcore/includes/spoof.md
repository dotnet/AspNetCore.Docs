  > [!WARNING]
  > API that relies on the [Host header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Host), such as <xref:Microsoft.AspNetCore.Http.HttpRequest.Host%2A?displayProperty=nameWithType> and <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.RequireHost%2A>, are subject to potential spoofing by clients.
>
> To prevent host and port spoofing, use one of the following approaches:
>
> * Use <xref:Microsoft.AspNetCore.Http.HttpContext.Connection%2A?displayProperty=nameWithType> (<xref:Microsoft.AspNetCore.Http.ConnectionInfo.LocalPort?displayProperty=nameWithType>) where the ports are checked.
> * Employ [Host filtering](xref:fundamentals/servers/kestrel/host-filtering).
