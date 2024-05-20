### Developer exception page improvements

The [ASP.NET Core developer exception page](xref:fundamentals/error-handling#developer-exception-page) is displayed when an app throws an unhandled exception during development. The developer exception page provides detailed information about the exception and request.

Preview 3 added endpoint metadata to the developer exception page. ASP.NET Core uses endpoint metadata to control endpoint behavior, such as routing, authentication and authorization, response caching, rate limiting, OpenAPI generation, and more. Attributes added to MVC actions, Minimal APIs, and gRPC methods are examples of endpoint metadata. The new metadata information appears in the `Routing` section alongside other routing information. This information makes it easier to debug ASP.NET Core errors during development. The following image shows the new metadata information on the developer exception page:

:::image type="content" source="~/release-notes/aspnetcore-9/_static/endpoint-metadata.png" alt-text="The new metadata information on the developer exception page":::

While testing the developer exception page, small quality of life improvements were identified. They shipped in preview 4:

* Better text wrapping. Long cookies, query string values and method names no longer add horizontal browser scroll bars.
* Bigger text. This page has a long history (10+ years) and web design has changed over time. The text felt a little small compared to modern designs.
* More consistent table sizes.

The following animated image shows the new developer exception page:

:::image type="content" source="~/release-notes/aspnetcore-9/aspnetcore-9/_static/aspnetcore-developer-page-improvements.gif" alt-text="The new developer exception page":::
