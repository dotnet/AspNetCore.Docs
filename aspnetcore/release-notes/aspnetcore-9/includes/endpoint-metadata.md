### Endpoint metadata on the developer exception page

Attributes added to MVC actions, Minimal APIs, and gRPC methods are examples of [endpoint metadata](xref:fundamentals/routing#endpoint-metadata). ASP.NET Core uses endpoint metadata to control endpoint behavior, such as routing, authentication and authorization, response caching, rate limiting, OpenAPI generation, and more.

.NET 9 adds metadata to the [developer exception page](xref:fundamentals/error-handling#developer-exception-page). The new metadata information appears in the `Routing` section alongside other routing information. This information makes it easier to debug ASP.NET Core errors during development. The following image shows the new metadata information on the developer exception page:

:::image type="content" source="~/release-notes/aspnetcore-9/_static/endpoint-metadata.png" alt-text="The new metadata information on the developer exception page":::
