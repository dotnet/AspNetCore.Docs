### OpenAPI schemas better match ASP.NET Core behavior

OpenAPI generation now handles two schema cases more accurately. Non-body enum parameters keep the original C# enum member names even when HTTP JSON options configure a `JsonStringEnumConverter` naming policy, because query, route, header, and form binding use `Enum.TryParse` rather than JSON serialization. Array schema reference IDs now use valid component names such as `stringArray` and `TodoArray` instead of names with array syntax.

```csharp
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter(JsonNamingPolicy.KebabCaseLower));
});

app.MapGet("/orders", (OrderStatus status) => Results.Ok(status));
```

With this configuration, a body schema can still describe `OrderStatus.PendingReview` as `pending-review`, while the query parameter schema describes the accepted value as `PendingReview`.

Minimal API endpoints can support multiple <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method calls for the same status code—for example, to specify that a 200 response may arrive as `application/json` or `text/plain` with different schemas. The same support applies to MVC controllers via multiple [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) attributes.

In prior releases, the framework collapsed each status code to a single response type and silently dropped the rest, making it impossible to describe endpoints that serve multiple content types. <xref:Microsoft.AspNetCore.Mvc.ApiExplorer> now preserves every declared response type with deterministic ordering, and the generated OpenAPI document emits separate content entries per media type—or an `anyOf` schema when multiple types share the same content type.

Thank you [@marcominerva](https://github.com/marcominerva) for the array schema reference contribution!
