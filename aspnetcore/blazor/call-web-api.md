---
title: Call a web API from an ASP.NET Core Blazor app
author: guardrex
description: Learn how to call a web API from Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/08/2024
uid: blazor/call-web-api
---
# Call a web API from ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes how to call a web API from a Blazor app.

## Package

The [`System.Net.Http.Json`](https://www.nuget.org/packages/System.Net.Http.Json) package provides extension methods for <xref:System.Net.Http.HttpClient?displayProperty=fullName> and <xref:System.Net.Http.HttpContent?displayProperty=fullName> that perform automatic serialization and deserialization using [`System.Text.Json`](https://www.nuget.org/packages/System.Text.Json). The `System.Net.Http.Json` package is provided by the .NET shared framework and doesn't require adding a package reference to the app.

:::moniker range=">= aspnetcore-8.0"

## Sample apps

See the sample apps in the [`dotnet/blazor-samples`](https://github.com/dotnet/blazor-samples/) GitHub repository.

### `BlazorWebAppCallWebApi`

Call an external (not in the Blazor Web App) todo list web API from a Blazor Web App:

* `Backend`: A web API app for maintaining a todo list, based on [Minimal APIs](xref:fundamentals/minimal-apis). The web API app is a separate app from the Blazor Web App, possibly hosted on a different server.
* `BlazorApp`/`BlazorApp.Client`: A Blazor Web App that calls the web API app with an <xref:System.Net.Http.HttpClient> for todo list operations, such as creating, reading, updating, and deleting (CRUD) items from the todo list.

For client-side rendering (CSR), which includes Interactive WebAssembly components and Auto components that have adopted CSR, calls are made with a preconfigured <xref:System.Net.Http.HttpClient> registered in the `Program` file of the client project (`BlazorApp.Client`):

```csharp
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:5002")
    });
```

For server-side rendering (SSR), which includes prerendered and interactive Server components, prerendered WebAssembly components, and Auto components that are prerendered or have adopted SSR, calls are made with an <xref:System.Net.Http.HttpClient> registered in the `Program` file of the server project (`BlazorApp`):

```csharp
builder.Services.AddHttpClient();
```

Call an internal (inside the Blazor Web App) movie list API, where the API resides in the server project of the Blazor Web App:

* `BlazorApp`: A Blazor Web App that maintains a movie list:
  * When operations are performed on the movie list within the app on the server, ordinary API calls are used.
  * When API calls are made by a web-based client, a web API is used for movie list operations, based on [Minimal APIs](xref:fundamentals/minimal-apis).
* `BlazorApp.Client`: The client project of the Blazor Web App, which contains Interactive WebAssembly and Auto components for user management of the movie list.

For CSR, which includes Interactive WebAssembly components and Auto components that have adopted CSR, calls to the API are made via a client-based service (`ClientMovieService`) that uses a preconfigured <xref:System.Net.Http.HttpClient> registered in the `Program` file of the client project (`BlazorApp.Client`). Because these calls are made over a public or private web, the movie list API is a *web API*.

The following example obtains a list of movies from the `/movies` endpoint:

```csharp
public class ClientMovieService(HttpClient http) : IMovieService
{
    public async Task<Movie[]> GetMoviesAsync(bool watchedMovies)
    {
        return await http.GetFromJsonAsync<Movie[]>("movies") ?? [];
    }
}
```

For SSR, which includes prerendered and interactive Server components, prerendered WebAssembly components, and Auto components that are prerendered or have adopted SSR, calls are made directly via a server-based service (`ServerMovieService`). The API doesn't rely on a network, so it's a standard API for movie list CRUD operations.

The following example obtains a list of movies:

```csharp
public class ServerMovieService(MovieContext db) : IMovieService
{
    public async Task<Movie[]> GetMoviesAsync(bool watchedMovies)
    {
        return watchedMovies ? 
            await db.Movies.Where(t => t.IsWatched).ToArrayAsync() : 
            await db.Movies.ToArrayAsync();
    }
}
```

### `BlazorWebAppCallWebApi_Weather`

A weather data sample app that uses streaming rendering for weather data.

### `BlazorWebAssemblyCallWebApi`

Calls a todo list web API from a Blazor WebAssembly app:

* `Backend`: A web API app for maintaining a todo list, based on [Minimal APIs](xref:fundamentals/minimal-apis).
* `BlazorTodo`: A Blazor WebAssembly app that calls the web API with a preconfigured <xref:System.Net.Http.HttpClient> for todo list CRUD operations.

:::moniker-end

## Server-side scenarios for calling external web APIs

Server-based components call external web APIs using <xref:System.Net.Http.HttpClient> instances, typically created using <xref:System.Net.Http.IHttpClientFactory>. For guidance that applies to server-side apps, see <xref:fundamentals/http-requests>.

A server-side app doesn't include an <xref:System.Net.Http.HttpClient> service by default. Provide an <xref:System.Net.Http.HttpClient> to the app using the [`HttpClient` factory infrastructure](xref:fundamentals/http-requests).

In the `Program` file:

```csharp
builder.Services.AddHttpClient();
```

The following Razor component makes a request to a web API for GitHub branches similar to the *Basic Usage* example in the <xref:fundamentals/http-requests> article.

`CallWebAPI.razor`:

```razor
@page "/call-web-api"
@using System.Text.Json
@using System.Text.Json.Serialization
@inject IHttpClientFactory ClientFactory

<h1>Call web API from a Blazor Server Razor component</h1>

@if (getBranchesError || branches is null)
{
    <p>Unable to get branches from GitHub. Please try again later.</p>
}
else
{
    <ul>
        @foreach (var branch in branches)
        {
            <li>@branch.Name</li>
        }
    </ul>
}

@code {
    private IEnumerable<GitHubBranch>? branches = [];
    private bool getBranchesError;
    private bool shouldRender;

    protected override bool ShouldRender() => shouldRender;

    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches");
        request.Headers.Add("Accept", "application/vnd.github.v3+json");
        request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

        var client = ClientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            branches = await JsonSerializer.DeserializeAsync
                <IEnumerable<GitHubBranch>>(responseStream);
        }
        else
        {
            getBranchesError = true;
        }

        shouldRender = true;
    }

    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
```

In the preceding example for C# 12 or later, an empty array (`[]`) is created for the `branches` variable. For earlier versions of C#, create an empty array (`Array.Empty<GitHubBranch>()`).

For an additional working example, see the server-side file upload example that uploads files to a web API controller in the <xref:blazor/file-uploads#upload-files-to-a-server-with-server-side-rendering> article.

:::moniker range=">= aspnetcore-8.0"

## Service abstractions for web API calls

*This section applies to Blazor Web Apps that maintain a web API in the server project or transform web API calls to an external web API.*

When using the interactive WebAssembly and Auto render modes, components are prerendered by default. Auto components are also initially rendered interactively from the server before the Blazor bundle downloads to the client and the client-side runtime activates. This means that components using these render modes should be designed so that they run successfully from both the client and the server. If the component must call a server project-based API or transform a request to an external web API (one that's outside of the Blazor Web App) when running on the client, the recommended approach is to abstract that API call behind a service interface and implement client and server versions of the service:

* The client version calls the web API with a preconfigured <xref:System.Net.Http.HttpClient>.
* The server version can typically access the server-side resources directly. Injecting an <xref:System.Net.Http.HttpClient> on the server that makes calls back to the server is ***not*** recommended, as the network request is typically unnecessary. Alternatively, the API might be external to the server project, but a service abstraction for the server is required to transform the request in some way, for example to add an access token to a proxied request.

When using the WebAssembly render mode, you also have the option of disabling prerendering, so the components only render from the client. For more information, see <xref:blazor/components/render-modes#prerendering>.

Examples ([sample apps](#sample-apps)):

* Movie list web API in the `BlazorWebAppCallWebApi` sample app.
* Streaming rendering weather data web API in the `BlazorWebAppCallWebApi_Weather` sample app.
* Weather data returned to the client in either the `BlazorWebAppOidc` (non-BFF pattern) or `BlazorWebAppOidcBff` (BFF pattern) sample apps. These apps demonstrate secure (web) API calls. For more information, see <xref:blazor/security/blazor-web-app-oidc>.

## Blazor Web App external web APIs

*This section applies to Blazor Web Apps that call a web API maintained by a separate (external) project, possibly hosted on a different server.*

Blazor Web Apps normally prerender client-side WebAssembly components, and Auto components render on the server during static or interactive server-side rendering (SSR). <xref:System.Net.Http.HttpClient> services aren't registered by default in a Blazor Web App's main project. If the app is run with only the <xref:System.Net.Http.HttpClient> services registered in the `.Client` project, as described in the [Add the `HttpClient` service](#add-the-httpclient-service) section, executing the app results in a runtime error:

> :::no-loc text="InvalidOperationException: Cannot provide a value for property 'Http' on type '...{COMPONENT}'. There is no registered service of type 'System.Net.Http.HttpClient'.":::

Use ***either*** of the following approaches:

* Add the <xref:System.Net.Http.HttpClient> services to the server project to make the <xref:System.Net.Http.HttpClient> available during SSR. Use the following service registration in the server project's `Program` file:

  ```csharp
  builder.Services.AddHttpClient();
  ```

  No explicit package reference is required because <xref:System.Net.Http.HttpClient> services are provided by the shared framework.

  Example: Todo list web API in the `BlazorWebAppCallWebApi` [sample app](#sample-apps)

* If prerendering isn't required for a WebAssembly component that calls the web API, disable prerendering by following the guidance in <xref:blazor/components/render-modes#prerendering>. If you adopt this approach, you don't need to add <xref:System.Net.Http.HttpClient> services to the main project of the Blazor Web App because the component won't be prerendered on the server.

For more information, see [Client-side services fail to resolve during prerendering](xref:blazor/components/render-modes#client-side-services-fail-to-resolve-during-prerendering).

## Prerendered data

When prerendering, components render twice: first statically, then interactively. State doesn't automatically flow from the prerendered component to the interactive one. If a component performs asynchronous initialization operations and renders different content for different states during initialization, such as a "Loading..." progress indicator, you may see a flicker when the component renders twice.

<!-- UPDATE 9.0 Keep an eye on the status of the enhanced nav fix
                currently scheduled for Pre4. Remove the cross-link
                to the PU issue when 9.0 releases. 
                Note that the README of the "weather" call web API
                sample has a cross-link and remark on this, and the
                sample app disabled enhanced nav on the weather
                component link. -->

You can address this by flowing prerendered state using the Persistent Component State API, which the `BlazorWebAppCallWebApi` and `BlazorWebAppCallWebApi_Weather` [sample apps](#sample-apps) demonstrate. When the component renders interactively, it can render the same way using the same state. However, the API doesn't currently work with enhanced navigation, which you can work around by disabling enhanced navigation on links to the page (`data-enhanced-nav=false`). For more information, see the following resources:

* <xref:blazor/components/prerender#persist-prerendered-state>
* <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>
* [Support persistent component state across enhanced page navigations (`dotnet/aspnetcore` #51584)](https://github.com/dotnet/aspnetcore/issues/51584)

:::moniker-end

## Add the `HttpClient` service

*The guidance in this section applies to client-side scenarios.*

Client-side components call web APIs using a preconfigured <xref:System.Net.Http.HttpClient> service, which is focused on making requests back to the server of origin. Additional <xref:System.Net.Http.HttpClient> service configurations for other web APIs can be created in developer code. Requests are composed using Blazor JSON helpers or with <xref:System.Net.Http.HttpRequestMessage>. Requests can include [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) option configuration.

The configuration examples in this section are only useful when a single web API is called for a single <xref:System.Net.Http.HttpClient> instance in the app. When the app must call multiple web APIs, each with its own base address and configuration, you can adopt the following approaches, which are covered later in this article:

* [Named `HttpClient` with `IHttpClientFactory`](#named-httpclient-with-ihttpclientfactory): Each web API is provided a unique name. When app code or a Razor component calls a web API, it uses a named <xref:System.Net.Http.HttpClient> instance to make the call.
* [Typed `HttpClient`](#typed-httpclient): Each web API is typed. When app code or a Razor component calls a web API, it uses a typed <xref:System.Net.Http.HttpClient> instance to make the call.

In the `Program` file, add an <xref:System.Net.Http.HttpClient> service if it isn't already present from a Blazor project template used to create the app:

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });
```

The preceding example sets the base address with `builder.HostEnvironment.BaseAddress` (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress%2A?displayProperty=nameWithType>), which gets the base address for the app and is typically derived from the `<base>` tag's `href` value in the host page.

The most common use cases for using the client's own base address are:

* The client project (`.Client`) of a Blazor Web App (.NET 8 or later) makes web API calls from WebAssembly components or code that runs on the client in WebAssembly to APIs in the server app.
* The client project (**:::no-loc text="Client":::**) of a hosted Blazor WebAssembly app makes web API calls to the server project (**:::no-loc text="Server":::**). Note that the hosted Blazor WebAssembly project template is no longer available in .NET 8 or later. However, hosted Blazor WebAssembly apps remain supported for .NET 8.

If you're calling an external web API (not in the same URL space as the client app), set the URI to the web API's base address. The following example sets the base address of the web API to `https://localhost:5001`, where a separate web API app is running and ready to respond to requests from the client app:

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:5001")
    });
```

## JSON helpers

<xref:System.Net.Http.HttpClient> is available as a preconfigured service for making requests back to the origin server.

<xref:System.Net.Http.HttpClient> and JSON helpers (<xref:System.Net.Http.Json.HttpClientJsonExtensions?displayProperty=nameWithType>) are also used to call third-party web API endpoints. <xref:System.Net.Http.HttpClient> is implemented using the browser's [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) and is subject to its limitations, including enforcement of the same-origin policy, which is discussed later in this article in the *Cross-Origin Resource Sharing (CORS)* section.

The client's base address is set to the originating server's address. Inject an <xref:System.Net.Http.HttpClient> instance into a component using the [`@inject`](xref:mvc/views/razor#inject) directive:

```razor
@using System.Net.Http
@inject HttpClient Http
```

Use the <xref:System.Net.Http.Json?displayProperty=fullName> namespace for access to <xref:System.Net.Http.Json.HttpClientJsonExtensions>, including <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A>, <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A>, and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A>:

```razor
@using System.Net.Http.Json
```

The following sections cover JSON helpers:

* [GET](#get-from-json-getfromjsonasync)
* [POST](#post-as-json-postasjsonasync)
* [PUT](#put-as-json-putasjsonasync)
* [PATCH](#patch-as-json-patchasjsonasync)

<xref:System.Net.Http> includes additional methods for sending HTTP requests and receiving HTTP responses, for example to send a DELETE request. For more information, see the [DELETE and additional extension methods](#delete-deleteasync-and-additional-extension-methods) section.

## GET from JSON (`GetFromJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> sends an HTTP GET request and parses the JSON response body to create an object.

In the following component code, the `todoItems` are displayed by the component. <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> is called when the component is finished initializing ([`OnInitializedAsync`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)).

```csharp
todoItems = await Http.GetFromJsonAsync<TodoItem[]>("todoitems");
```

## POST as JSON (`PostAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> sends a POST request to the specified URI containing the value serialized as JSON in the request body.

In the following component code, `newItemName` is provided by a bound element of the component. The `AddItem` method is triggered by selecting a `<button>` element.

```csharp
await Http.PostAsJsonAsync("todoitems", addItem);
```

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> returns an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data as an array:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast[]>() ?? 
    Array.Empty<WeatherForecast>();
```

## PUT as JSON (`PutAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> sends an HTTP PUT request with JSON-encoded content.

In the following component code, `editItem` values for `Name` and `IsCompleted` are provided by bound elements of the component. The item's `Id` is set when the item is selected in another part of the UI (not shown) and `EditItem` is called. The `SaveItem` method is triggered by selecting the `<button>` element. The following example doesn't show loading `todoItems` for brevity. See the [GET from JSON (`GetFromJsonAsync`)](#get-from-json-getfromjsonasync) section for an example of loading items.

```csharp
await Http.PutAsJsonAsync($"todoitems/{editItem.Id}", editItem);
```

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> returns an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data as an array:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast[]>() ?? 
    Array.Empty<WeatherForecast>();
```

:::moniker range=">= aspnetcore-7.0"

## PATCH as JSON (`PatchAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PatchAsJsonAsync%2A> sends an HTTP PATCH request with JSON-encoded content.

> [!NOTE]
> For more information, see <xref:web-api/jsonpatch>.

In the following example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.PatchAsJsonAsync%2A> receives a JSON PATCH document as a plain text string with escaped quotes:

```csharp
await Http.PatchAsJsonAsync(
    $"todoitems/{id}", 
    "[{\"operationType\":2,\"path\":\"/IsComplete\",\"op\":\"replace\",\"value\":true}]");
```

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PatchAsJsonAsync%2A> returns an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON todo item data as an array. An empty array is created if no item data is returned by the method, so `content` isn't null after the statement executes:

```csharp
var response = await Http.PatchAsJsonAsync(...);
var content = await response.Content.ReadFromJsonAsync<TodoItem[]>() ??
    Array.Empty<TodoItem>();
```

Laid out with indentation, spacing, and unescaped quotes, the unencoded PATCH document appears as the following JSON:

```json
[
  {
    "operationType": 2,
    "path": "/IsComplete",
    "op": "replace",
    "value": true
  }
]
```

To simplify the creation of PATCH documents in the app issuing PATCH requests, an app can use .NET JSON PATCH support, as the following guidance demonstrates.

Install the [`Microsoft.AspNetCore.JsonPatch`](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch) NuGet package and use the API features of the package to compose a <xref:Microsoft.AspNetCore.JsonPatch.JsonPatchDocument> for a PATCH request.

[!INCLUDE[](~/includes/package-reference.md)]

Add `@using` directives for the <xref:System.Text.Json?displayProperty=fullName>, <xref:System.Text.Json.Serialization?displayProperty=fullName>, and <xref:Microsoft.AspNetCore.JsonPatch?displayProperty=fullName> namespaces to the top of the Razor component:

```razor
@using System.Text.Json
@using System.Text.Json.Serialization
@using Microsoft.AspNetCore.JsonPatch
```

Compose the <xref:Microsoft.AspNetCore.JsonPatch.JsonPatchDocument> for a `TodoItem` with `IsComplete` set to `true` using the <xref:Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Replace%2A> method:

```csharp
var patchDocument = new JsonPatchDocument<TodoItem>()
    .Replace(p => p.IsComplete, true);
```

Pass the document's operations (`patchDocument.Operations`) to the <xref:System.Net.Http.Json.HttpClientJsonExtensions.PatchAsJsonAsync%2A> call:

```csharp
private async Task UpdateItem(long id)
{
    await Http.PatchAsJsonAsync(
        $"todoitems/{id}", 
        patchDocument.Operations, 
        new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        });
}
```

<xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition?displayProperty=nameWithType> is set to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault?displayProperty=nameWithType> to ignore a property only if it equals the default value for its type.

Add <xref:System.Text.Json.JsonSerializerOptions.WriteIndented?displayProperty=nameWithType> set to `true` if you want to present the JSON payload in a pleasant format for display. Writing indented JSON has no bearing on processing PATCH requests and isn't typically performed in production apps for web API requests.

Follow the guidance in the <xref:web-api/jsonpatch> article to add a PATCH controller action to the web API. Alternatively, PATCH request processing can be implemented as a [Minimal API](xref:fundamentals/minimal-apis) with the following steps.

Add a package reference for the [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson) NuGet package to the web API app.

> [!NOTE]
> There's no need to add a package reference for the [`Microsoft.AspNetCore.JsonPatch`](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch) package to the app because the reference to the `Microsoft.AspNetCore.Mvc.NewtonsoftJson` package automatically transitively adds a package reference for `Microsoft.AspNetCore.JsonPatch`.

In the `Program` file add an `@using` directive for the <xref:Microsoft.AspNetCore.JsonPatch?displayProperty=fullName> namespace:

```csharp
using Microsoft.AspNetCore.JsonPatch;
```

Provide the endpoint to the request processing pipeline of the web API:

```csharp
app.MapPatch("/todoitems/{id}", async (long id, TodoContext db) =>
{
    if (await db.TodoItems.FindAsync(id) is TodoItem todo)
    {
        var patchDocument = 
            new JsonPatchDocument<TodoItem>().Replace(p => p.IsComplete, true);
        patchDocument.ApplyTo(todo);
        await db.SaveChangesAsync();

        return TypedResults.Ok(todo);
    }

    return TypedResults.NoContent();
});
```

> [!WARNING]
> As with the other examples in the <xref:web-api/jsonpatch> article, the preceding PATCH API doesn't protect the web API from over-posting attacks. For more information, see <xref:tutorials/first-web-api#prevent-over-posting>.

For a fully working PATCH experience, see the `BlazorWebAppCallWebApi` [sample app](#sample-apps).

:::moniker-end

## DELETE (`DeleteAsync`) and additional extension methods

<xref:System.Net.Http> includes additional extension methods for sending HTTP requests and receiving HTTP responses. <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> is used to send an HTTP DELETE request to a web API.

In the following component code, the `<button>` element calls the `DeleteItem` method. The bound `<input>` element supplies the `id` of the item to delete.

```csharp
await Http.DeleteAsync($"todoitems/{id}");
```

## Named `HttpClient` with `IHttpClientFactory`

<xref:System.Net.Http.IHttpClientFactory> services and the configuration of a named <xref:System.Net.Http.HttpClient> are supported.

> [!NOTE]
> An alternative to using a named <xref:System.Net.Http.HttpClient> from an <xref:System.Net.Http.IHttpClientFactory> is to use a typed <xref:System.Net.Http.HttpClient>. For more information, see the [Typed `HttpClient`](#typed-httpclient) section.

Add the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

In the `Program` file of a client project:

```csharp
builder.Services.AddHttpClient("WebAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

:::moniker range=">= aspnetcore-8.0"

If the named client is to be used by prerendered client-side components of a Blazor Web App, the preceding service registration should appear in both the server project and the `.Client` project. On the server, `builder.HostEnvironment.BaseAddress` is replaced by the web API's base address, which is described further below.

:::moniker-end

The preceding client-side example sets the base address with `builder.HostEnvironment.BaseAddress` (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress%2A?displayProperty=nameWithType>), which gets the base address for the client-side app and is typically derived from the `<base>` tag's `href` value in the host page.

:::moniker range=">= aspnetcore-8.0"

The most common use cases for using the client's own base address are:

* The client project (`.Client`) of a Blazor Web App that makes web API calls from WebAssembly/Auto components or code that runs on the client in WebAssembly to APIs in the server app at the same host address.
* The client project (**:::no-loc text="Client":::**) of a hosted Blazor WebAssembly app that makes web API calls to the server project (**:::no-loc text="Server":::**).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The most common use case for using the client's own base address is in the client project (**:::no-loc text="Client":::**) of a hosted Blazor WebAssembly app that makes web API calls to the server project (**:::no-loc text="Server":::**).

:::moniker-end

If you're calling an external web API (not in the same URL space as the client app) or you're configuring the services in a server-side app (for example to deal with prerendering of client-side components on the server), set the URI to the web API's base address. The following example sets the base address of the web API to `https://localhost:5001`, where a separate web API app is running and ready to respond to requests from the client app:

```csharp
builder.Services.AddHttpClient("WebAPI", client => 
    client.BaseAddress = new Uri(https://localhost:5001));
```

In the following component code:

* An instance of <xref:System.Net.Http.IHttpClientFactory> creates a named <xref:System.Net.Http.HttpClient>.
* The named <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API at `/forecast`.

```razor
@inject IHttpClientFactory ClientFactory

...

@code {
    private Forecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient("WebAPI");

        forecasts = await client.GetFromJsonAsync<Forecast[]>("forecast") ?? [];
    }
}
```

:::moniker range=">= aspnetcore-8.0"

The `BlazorWebAppCallWebApi` [sample app](#sample-apps) demonstrates calling a web API with a named <xref:System.Net.Http.HttpClient> in its `CallTodoWebApiCsrNamedClient` component. For an additional working demonstration in a client app based on calling Microsoft Graph with a named <xref:System.Net.Http.HttpClient>, see <xref:blazor/security/webassembly/graph-api?pivots=named-client-graph-api>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

For a working demonstration in a client app based on calling Microsoft Graph with a named <xref:System.Net.Http.HttpClient>, see <xref:blazor/security/webassembly/graph-api?pivots=named-client-graph-api>.

:::moniker-end

## Typed `HttpClient`

Typed <xref:System.Net.Http.HttpClient> uses one or more of the app's <xref:System.Net.Http.HttpClient> instances, default or named, to return data from one or more web API endpoints.

> [!NOTE]
> An alternative to using a typed <xref:System.Net.Http.HttpClient> is to use a named <xref:System.Net.Http.HttpClient> from an <xref:System.Net.Http.IHttpClientFactory>. For more information, see the [Named `HttpClient` with `IHttpClientFactory`](#named-httpclient-with-ihttpclientfactory) section.

Add the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The following example issues a GET request for JSON weather forecast data from the web API at `/forecast`.

`ForecastHttpClient.cs`:

```csharp
using System.Net.Http.Json;

namespace BlazorSample.Client;

public class ForecastHttpClient(HttpClient http)
{
    public async Task<Forecast[]> GetForecastAsync()
    {
        return await http.GetFromJsonAsync<Forecast[]>("forecast") ?? [];
    }
}
```

In the `Program` file of a client project:

```csharp
builder.Services.AddHttpClient<ForecastHttpClient>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

:::moniker range=">= aspnetcore-8.0"

If the typed client is to be used by prerendered client-side components of a Blazor Web App, the preceding service registration should appear in both the server project and the `.Client` project. On the server, `builder.HostEnvironment.BaseAddress` is replaced by the web API's base address, which is described further below.

:::moniker-end

The preceding example sets the base address with `builder.HostEnvironment.BaseAddress` (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress%2A?displayProperty=nameWithType>), which gets the base address for the client-side app and is typically derived from the `<base>` tag's `href` value in the host page.

:::moniker range=">= aspnetcore-8.0"

The most common use cases for using the client's own base address are:

* The client project (`.Client`) of a Blazor Web App that makes web API calls from WebAssembly/Auto components or code that runs on the client in WebAssembly to APIs in the server app at the same host address.
* The client project (**:::no-loc text="Client":::**) of a hosted Blazor WebAssembly app that makes web API calls to the server project (**:::no-loc text="Server":::**).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The most common use case for using the client's own base address is in the client project (**:::no-loc text="Client":::**) of a hosted Blazor WebAssembly app that makes web API calls to the server project (**:::no-loc text="Server":::**).

:::moniker-end

If you're calling an external web API (not in the same URL space as the client app) or you're configuring the services in a server-side app (for example to deal with prerendering of client-side components on the server), set the URI to the web API's base address. The following example sets the base address of the web API to `https://localhost:5001`, where a separate web API app is running and ready to respond to requests from the client app:

```csharp
builder.Services.AddHttpClient<ForecastHttpClient>(client => 
    client.BaseAddress = new Uri(https://localhost:5001));
```

Components inject the typed <xref:System.Net.Http.HttpClient> to call the web API.

In the following component code:

* An instance of the preceding `ForecastHttpClient` is injected, which creates a typed <xref:System.Net.Http.HttpClient>.
* The typed <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API.

```razor
@inject ForecastHttpClient Http

...

@code {
    private Forecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetForecastAsync();
    }
}
```

:::moniker range=">= aspnetcore-8.0"

The `BlazorWebAppCallWebApi` [sample app](#sample-apps) demonstrates calling a web API with a typed <xref:System.Net.Http.HttpClient> in its `CallTodoWebApiCsrTypedClient` component. Note that the component adopts and client-side rendering (CSR) (`InteractiveWebAssembly` render mode) ***with prerendering***, so the typed client service registration appears in the `Program` file of both the server project and the `.Client` project.

:::moniker-end

## Cookie-based request credentials

*The guidance in this section applies to client-side scenarios that rely upon an authentication cookie.*

For cookie-based authentication, which is considered more secure than bearer token authentication, cookie credentials can be sent with each web API request by calling <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> with a <xref:System.Net.Http.DelegatingHandler> on a preconfigured <xref:System.Net.Http.HttpClient>. The handler configures <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> with <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.BrowserRequestCredentials.Include?displayProperty=nameWithType>, which advises the browser to send credentials with each request, such as cookies or HTTP authentication headers, including for cross-origin requests.

`CookieHandler.cs`:

```csharp
public class CookieHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        request.Headers.Add("X-Requested-With", ["XMLHttpRequest"]);

        return base.SendAsync(request, cancellationToken);
    }
}
```

The `CookieHandler` is registered in the `Program` file:

```csharp
builder.Services.AddTransient<CookieHandler>();
```

The message handler is added to any preconfigured <xref:System.Net.Http.HttpClient> that requires cookie authentication:

```csharp
builder.Services.AddHttpClient(...)
    .AddHttpMessageHandler<CookieHandler>();
```

:::moniker range=">= aspnetcore-8.0"

For a demonstration, see <xref:blazor/security/webassembly/standalone-with-identity>.

:::moniker-end

When composing an <xref:System.Net.Http.HttpRequestMessage>, set the browser request credentials and header directly:

```csharp
var requestMessage = new HttpRequestMessage() { ... };

requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
requestMessage.Headers.Add("X-Requested-With", ["XMLHttpRequest"]);
```

## `HttpClient` and `HttpRequestMessage` with Fetch API request options

*The guidance in this section applies to client-side scenarios that rely upon bearer token authentication.*

[`HttpClient`](xref:fundamentals/http-requests) ([API documentation](xref:System.Net.Http.HttpClient)) and <xref:System.Net.Http.HttpRequestMessage> can be used to customize requests. For example, you can specify the HTTP method and request headers. The following component makes a `POST` request to a web API endpoint and shows the response body.

`TodoRequest.razor`:

```razor
@page "/todo-request"
@using System.Net.Http.Headers
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject HttpClient Http
@inject IAccessTokenProvider TokenProvider

<h1>ToDo Request</h1>

<h1>ToDo Request Example</h1>

<button @onclick="PostRequest">Submit POST request</button>

<p>Response body returned by the server:</p>

<p>@responseBody</p>

@code {
    private string? responseBody;

    private async Task PostRequest()
    {
        var requestMessage = new HttpRequestMessage()
        {
            Method = new HttpMethod("POST"),
            RequestUri = new Uri("https://localhost:10000/todoitems"),
            Content =
                JsonContent.Create(new TodoItem
                {
                    Name = "My New Todo Item",
                    IsComplete = false
                })
        };

        var tokenResult = await TokenProvider.RequestAccessToken();

        if (tokenResult.TryGetToken(out var token))
        {
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token.Value);

            requestMessage.Content.Headers.TryAddWithoutValidation(
                "x-custom-header", "value");

            var response = await Http.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;

            responseBody = await response.Content.ReadAsStringAsync();
        }
    }

    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
```

Blazor's client-side implementation of <xref:System.Net.Http.HttpClient> uses [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch) and configures the underlying [request-specific Fetch API options](https://developer.mozilla.org/docs/Web/API/fetch#Parameters) via <xref:System.Net.Http.HttpRequestMessage> extension methods and <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions>. Set additional options using the generic <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestOption%2A> extension method. Blazor and the underlying Fetch API don't directly add or modify request headers. For more information on how user agents, such as browsers, interact with headers, consult external user agent documentation sets and other web resources.

The HTTP response is typically buffered to enable support for synchronous reads on the response content. To enable support for response streaming, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserResponseStreamingEnabled%2A> extension method on the request.

To include credentials in a cross-origin request, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> extension method:

```csharp
requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
```

For more information on Fetch API options, see [MDN web docs: WindowOrWorkerGlobalScope.fetch(): Parameters](https://developer.mozilla.org/docs/Web/API/fetch#Parameters).

## Handle errors

Handle web API response errors in developer code when they occur. For example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> expects a JSON response from the web API with a `Content-Type` of `application/json`. If the response isn't in JSON format, content validation throws a <xref:System.NotSupportedException>.

In the following example, the URI endpoint for the weather forecast data request is misspelled. The URI should be to `WeatherForecast` but appears in the call as `WeatherForcast`, which is missing the letter `e` in `Forecast`.

The <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> call expects JSON to be returned, but the web API returns HTML for an unhandled exception with a `Content-Type` of `text/html`. The unhandled exception occurs because the path to `/WeatherForcast` isn't found and middleware can't serve a page or view for the request.

In <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> on the client, <xref:System.NotSupportedException> is thrown when the response content is validated as non-JSON. The exception is caught in the `catch` block, where custom logic could log the error or present a friendly error message to the user.

`ReturnHTMLOnException.razor`:

```razor
@page "/return-html-on-exception"
@using {PROJECT NAME}.Shared
@inject HttpClient Http

<h1>Fetch data but receive HTML on unhandled exception</h1>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <h2>Temperatures by Date</h2>

    <ul>
        @foreach (var forecast in forecasts)
        {
            <li>
                @forecast.Date.ToShortDateString():
                @forecast.TemperatureC &#8451;
                @forecast.TemperatureF &#8457;
            </li>
        }
    </ul>
}

<p>
    @exceptionMessage
</p>

@code {
    private WeatherForecast[]? forecasts;
    private string? exceptionMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            // The URI endpoint "WeatherForecast" is misspelled on purpose on the 
            // next line. See the preceding text for more information.
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForcast");
        }
        catch (NotSupportedException exception)
        {
            exceptionMessage = exception.Message;
        }
    }
}
```

> [!NOTE]
> The preceding example is for demonstration purposes. A web API can be configured to return JSON even when an endpoint doesn't exist or an unhandled exception occurs on the server.

For more information, see <xref:blazor/fundamentals/handle-errors>.

## Cross-Origin Resource Sharing (CORS)

Browser security restricts a webpage from making requests to a different domain than the one that served the webpage. This restriction is called the *same-origin policy*. The same-origin policy restricts (but doesn't prevent) a malicious site from reading sensitive data from another site. To make requests from the browser to an endpoint with a different origin, the *endpoint* must enable [Cross-Origin Resource Sharing (CORS)](https://www.w3.org/TR/cors/).

For more information on server-side CORS, see <xref:security/cors>. The article's examples don't pertain directly to Razor component scenarios, but the article is useful for learning general CORS concepts.

For information on client-side CORS requests, see <xref:blazor/security/webassembly/additional-scenarios#cross-origin-resource-sharing-cors>.

:::moniker range=">= aspnetcore-8.0"

## Antiforgery support

To add antiforgery support to an HTTP request, inject the `AntiforgeryStateProvider` and add a `RequestToken` to the headers collection as a `RequestVerificationToken`:

```razor
@inject AntiforgeryStateProvider Antiforgery
```

```csharp
private async Task OnSubmit()
{
    var antiforgery = Antiforgery.GetAntiforgeryToken();
    var request = new HttpRequestMessage(HttpMethod.Post, "action");
    request.Headers.Add("RequestVerificationToken", antiforgery.RequestToken);
    var response = await client.SendAsync(request);
    ...
}
```

For more information, see <xref:blazor/security/index#antiforgery-support>.

:::moniker-end

## Blazor framework component examples for testing web API access

Various network tools are publicly available for testing web API backend apps directly, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/). Blazor framework's reference source includes <xref:System.Net.Http.HttpClient> test assets that are useful for testing:

[`HttpClientTest` assets in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/BasicTestApp/HttpClientTest)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Additional resources

### General

* [Cross-Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)
* <xref:security/cors>: Although the content applies to ASP.NET Core apps, not Razor components, the article covers general CORS concepts.

### Server-side

* <xref:blazor/security/server/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:fundamentals/http-requests>
* <xref:security/enforcing-ssl>
* [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints)

### Client-side

* <xref:blazor/security/webassembly/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:blazor/security/webassembly/graph-api>
* [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch)
