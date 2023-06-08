  > [!WARNING]
  > API that relies on the [Host header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Host), such as <xref:Microsoft.AspNetCore.Http.HttpRequest.Host%2A?displayProperty=nameWithType>, is subject to potential spoofing by clients.
>
> To prevent host port spoofing, use one of the following approaches:
> * Assigning a value to <xref:Microsoft.AspNetCore.Http.HttpRequest.Host?displayProperty=nameWithType> in [middleware](xref:fundamentals/middleware/write) before <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> is called.
> * Use <xref:Microsoft.AspNetCore.Http.HttpContext.Connection%2A?displayProperty=nameWithType> (<xref:Microsoft.AspNetCore.Http.ConnectionInfo.LocalPort?displayProperty=nameWithType>) where the ports are checked.
