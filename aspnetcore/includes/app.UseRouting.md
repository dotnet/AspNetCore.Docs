***Note:*** When using <xref:Microsoft.AspNetCore.Builder.WebApplication>, [`app.UseRouting`](xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A) must be called after `UsePathBase` so that the Routing Middleware can observe the modified path before matching routes. Otherwise, routes are matched before the path is rewritten by `UsePathBase`. For more information, see:

* [Middleware Ordering](xref:fundamentals/middleware/index#order)
* [Routing](xref:fundamentals/routing)
* `WebApplication`: <xref:migration/50-to-60#new-hosting-model>)