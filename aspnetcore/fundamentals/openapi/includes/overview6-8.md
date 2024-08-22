:::moniker range=">= aspnetcore-6.0 <= aspnetcore-8.0"

The [OpenAPI specification](https://spec.openapis.org/oas/latest.html) is a programming language-agnostic standard for documenting HTTP APIs. This standard is supported in minimal APIs through a combination of built-in APIs and open-source libraries. There are three key aspects to OpenAPI integration in an application:

* Generating information about the endpoints in the app.
* Gathering the information into a format that matches the OpenAPI schema.
* Exposing the generated OpenAPI schema via a visual UI or a serialized file.

Minimal APIs provide built-in support for generating information about endpoints in an app via the `Microsoft.AspNetCore.OpenApi` package. Exposing the generated OpenAPI definition via a visual UI requires a third-party package.

For information about support for OpenAPI in controller-based APIs, see the [.NET 9 version of this article](?view=aspnetcore-9.0&preserve-view=true). 

:::moniker-end
