---
title: Call a web API in an ASP.NET Core Blazor app
author: guardrex
description: Learn how to call a web API in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/27/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/call-web-api
zone_pivot_groups: blazor-hosting-models
---
# Call a web API from ASP.NET Core Blazor

::: zone pivot="webassembly"

[Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) apps call web APIs using a preconfigured <xref:System.Net.Http.HttpClient> service. Compose requests, which can include [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) options, using Blazor JSON helpers or with <xref:System.Net.Http.HttpRequestMessage>. The <xref:System.Net.Http.HttpClient> service in Blazor WebAssembly apps is focused on making requests back to the server of origin.

## Packages

Reference the [`System.Net.Http.Json`](https://www.nuget.org/packages/System.Net.Http.Json) NuGet package in the project file.

## Add the `HttpClient` service

In `Program.Main`, add an <xref:System.Net.Http.HttpClient> service if it doesn't already exist:

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });
```

## `HttpClient` and JSON helpers

[`HttpClient`](xref:fundamentals/http-requests) is available as a preconfigured service for making requests back to the origin server.

<xref:System.Net.Http.HttpClient> and JSON helpers are also used to call third-party web API endpoints. <xref:System.Net.Http.HttpClient> is implemented using the browser [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) and is subject to its limitations, including enforcement of the same origin policy.

The client's base address is set to the originating server's address. Inject an <xref:System.Net.Http.HttpClient> instance using the [`@inject`](xref:mvc/views/razor#inject) directive:

```razor
@using System.Net.Http
@inject HttpClient Http
```

In the following examples, a Todo web API processes create, read, update, and delete (CRUD) operations. The examples are based on a `TodoItem` class that stores the:

* ID (`Id`, `long`): Unique ID of the item.
* Name (`Name`, `string`): Name of the item.
* Status (`IsComplete`, `bool`): Indication if the Todo item is finished.

```csharp
private class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}
```

JSON helper methods send requests to a URI (a web API in the following examples) and process the response:

### GET from JSON (`GetFromJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A>: Sends an HTTP GET request and parses the JSON response body to create an object.

In the following component code, the `todoItems` are displayed by the component. The `GetTodoItems` method is triggered when the component is finished rendering ([`OnInitializedAsync`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)).

```razor
@using System.Net.Http
@inject HttpClient Http

@code {
    private TodoItem[] todoItems;

    protected override async Task OnInitializedAsync() => 
        todoItems = await Http.GetFromJsonAsync<TodoItem[]>("api/TodoItems");
}
```

### POST as JSON (`PostAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> sends a POST request to the specified URI containing the value serialized as JSON in the request body.

In the following component code, `newItemName` is provided by a bound element of the component. The `AddItem` method is triggered by selecting a `<button>` element.

```razor
@using System.Net.Http
@inject HttpClient Http

<input @bind="newItemName" placeholder="New Todo Item" />
<button @onclick="AddItem">Add</button>

@code {
    private string newItemName;

    private async Task AddItem()
    {
        var addItem = new TodoItem { Name = newItemName, IsComplete = false };
        await Http.PostAsJsonAsync("api/TodoItems", addItem);
    }
}
```

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the `ReadFromJsonAsync<T>` extension method:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### PUT as JSON (`PutAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> sends an HTTP PUT request, including JSON-encoded content.

In the following component code, `editItem` values for `Name` and `IsCompleted` are provided by bound elements of the component. The item's `Id` is set when the item is selected in another part of the UI and `EditItem` is called. The `SaveItem` method is triggered by selecting the Save `<button>` element.

```razor
@using System.Net.Http
@inject HttpClient Http

<input type="checkbox" @bind="editItem.IsComplete" />
<input @bind="editItem.Name" />
<button @onclick="SaveItem">Save</button>

@code {
    private TodoItem editItem = new TodoItem();

    private void EditItem(long id)
    {
        editItem = todoItems.Single(i => i.Id == id);
    }

    private async Task SaveItem() =>
        await Http.PutAsJsonAsync($"api/TodoItems/{editItem.Id}", editItem);
}
```

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### Additional extension methods

<xref:System.Net.Http> includes additional extension methods for sending HTTP requests and receiving HTTP responses. <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> is used to send an HTTP DELETE request to a web API.

In the following component code, the Delete `<button>` element calls the `DeleteItem` method. The bound `<input>` element supplies the `id` of the item to delete.

```razor
@using System.Net.Http
@inject HttpClient Http

<input @bind="id" />
<button @onclick="DeleteItem">Delete</button>

@code {
    private long id;

    private async Task DeleteItem() =>
        await Http.DeleteAsync($"api/TodoItems/{id}");
}
```

## Named `HttpClient` with `IHttpClientFactory`

<xref:System.Net.Http.IHttpClientFactory> services and the configuration of a named <xref:System.Net.Http.HttpClient> are supported.

Reference the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package in the project file.

`Program.Main` (`Program.cs`):

```csharp
builder.Services.AddHttpClient("ServerAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

In the following component code, XXXXXXXXXXXXXXXXX

```razor
@inject IHttpClientFactory ClientFactory

...

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient("ServerAPI");

        forecasts = await client.GetFromJsonAsync<WeatherForecast[]>(
            "WeatherForecast");
    }
}
```

## Typed `HttpClient`

Typed <xref:System.Net.Http.HttpClient> uses one or more of the app's <xref:System.Net.Http.HttpClient> instances, default or named, to return data from one or more web API endpoints.

`WeatherForecastClient.cs`:

```csharp
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class WeatherForecastHttpClient
{
    private readonly HttpClient http;

    public WeatherForecastHttpClient(HttpClient http)
    {
        this.http = http;
    }

    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        var forecasts = new WeatherForecast[0];

        try
        {
            forecasts = await http.GetFromJsonAsync<WeatherForecast[]>(
                "WeatherForecast");
        }
        catch
        {
            ...
        }

        return forecasts;
    }
}
```

`Program.Main` (`Program.cs`):

```csharp
builder.Services.AddHttpClient<WeatherForecastHttpClient>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

Components inject the typed <xref:System.Net.Http.HttpClient> to call the web API.

In the following component code, XXXXXXXXXXXXXXXX

```razor
@inject WeatherForecastHttpClient Http

...

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetForecastAsync();
    }
}
```

## `HttpClient` and `HttpRequestMessage` with Fetch API request options

[`HttpClient`](xref:fundamentals/http-requests) ([API documentation](xref:System.Net.Http.HttpClient)) and <xref:System.Net.Http.HttpRequestMessage> can be used to customize requests. For example, you can specify the HTTP method and request headers. The following component makes a `POST` request to a To Do List API endpoint on the server and shows the response body:

`Pages/TodoRequest.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-web-api/TodoRequest.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-web-api/TodoRequest.razor)]

::: moniker-end

Blazor WebAssembly's implementation of <xref:System.Net.Http.HttpClient> uses [Fetch API](https://developer.mozilla.org/docs/Web/API/WindowOrWorkerGlobalScope/fetch). The Fetch API allows configuring several [request-specific options](https://developer.mozilla.org/docs/Web/API/WindowOrWorkerGlobalScope/fetch#Parameters).

Fetch API request options can be configured with <xref:System.Net.Http.HttpRequestMessage> extension methods shown in the following table.

| Extension method | Fetch API request property |
| --- | --- |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> | [`credentials`](https://developer.mozilla.org/docs/Web/API/Request/credentials) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCache%2A> | [`cache`](https://developer.mozilla.org/docs/Web/API/Request/cache) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestMode%2A> | [`mode`](https://developer.mozilla.org/docs/Web/API/Request/mode) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestIntegrity%2A> | [`integrity`](https://developer.mozilla.org/docs/Web/API/Request/integrity) |

You can set additional options using the more generic <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestOption%2A> extension method.

The HTTP response is typically buffered to enable support for sync reads on the response content. To enable support for response streaming, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserResponseStreamingEnabled%2A> extension method on the request.

To include credentials in a cross-origin request, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> extension method:

```csharp
requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
```

For more information on Fetch API options, see [MDN web docs: WindowOrWorkerGlobalScope.fetch(): Parameters](https://developer.mozilla.org/docs/Web/API/WindowOrWorkerGlobalScope/fetch#Parameters).

## Call web API example

The following example calls a Web API. The example requires a running web API based on the sample app described by the <xref:tutorials/first-web-api> article. This example makes requests to the web API at `https://localhost:10000/api/TodoItems`. If a different web API address is used, update the `ServiceEndpoint` constant value in the component's `@code` block.

The following example makes a [cross-origin resource sharing (CORS)](xref:security/cors) request from `http://localhost:5000` or `https://localhost:5001` to the web API service app. Add the following CORS middleware configuration to the web API's service's `Startup.Configure` method:

```csharp
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));
```

Adjust the domains and ports of `WithOrigins` as needed for the Blazor app. For more information, see <xref:security/cors>.

::: moniker range=">= aspnetcore-5.0"

By default, ASP.NET Core apps use ports 5000 (HTTP) and 5001 (HTTPS). To run both apps on the same machine at the same time for testing, use a different port for the web API app (for example, port 10000). For more information on setting the port, see <xref:fundamentals/servers/kestrel/endpoints>.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

By default, ASP.NET Core apps use ports 5000 (HTTP) and 5001 (HTTPS). To run both apps on the same machine at the same time for testing, use a different port for the web API app (for example, port 10000). For more information on setting the port, see <xref:fundamentals/servers/kestrel#endpoint-configuration>.

::: moniker-end

`Pages/CallWebAPI.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-web-api/CallWebAPI.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-web-api/CallWebAPI.razor)]

::: moniker-end

## Handle errors

When errors occur while interacting with a web API, they can be handled by developer code. For example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> expects a JSON response from the server API with a `Content-Type` of `application/json`. If the response isn't in JSON format, content validation throws a <xref:System.NotSupportedException>.

In the following example, the URI endpoint for the weather forecast data request is misspelled. The URI should be to `WeatherForecast` but appears in the call as `WeatherForcast` (missing "e").

The <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> call expects JSON to be returned, but the server returns HTML for an unhandled exception on the server with a `Content-Type` of `text/html`. The unhandled exception occurs on the server because the path isn't found and middleware can't serve a page or view for the request.

In <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> on the client, <xref:System.NotSupportedException> is thrown when the response content is validated as non-JSON. The exception is caught in the `catch` block, where custom logic could log the error or present a friendly error message to the user:

```razor
@code {
    ...

    protected override async Task OnInitializedAsync()
    {
        try
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForcast");
        }
        catch (NotSupportedException exception)
        {
            ...
        }
    }

    ...
}
```

> [!NOTE]
> The preceding example is for demonstration purposes. A web API server app can be configured to return JSON even when an endpoint doesn't exist or an unhandled exception on the server occurs.

For more information, see <xref:blazor/fundamentals/handle-errors>.

::: zone-end

::: zone pivot="server"

[Blazor Server](xref:blazor/hosting-models#blazor-server) apps call web APIs using <xref:System.Net.Http.HttpClient> instances, typically created using <xref:System.Net.Http.IHttpClientFactory>. For guidance that applies to Blazor Server, see <xref:fundamentals/http-requests>.

XXXXXXXXXXXXXXXXXXXXXXXXX

In the following example ....... or cross-link to File Uploads example.






A Blazor Server app doesn't include an <xref:System.Net.Http.HttpClient> service by default. Provide an <xref:System.Net.Http.HttpClient> to the app using the [`HttpClient` factory infrastructure](xref:fundamentals/http-requests).






::: zone-end

## Cross-origin resource sharing (CORS)

::: zone pivot="webassembly"

Browser security prevents a webpage from making requests to a different domain than the one that served the webpage. This restriction is called the *same-origin policy*. The same-origin policy prevents a malicious site from reading sensitive data from another site. To make requests from the browser to an endpoint with a different origin, the *endpoint* must enable [cross-origin resource sharing (CORS)](https://www.w3.org/TR/cors/).

<!--

XXXXXXXXXX Include guidance here or refer/cross-link the snippets sample app for this scenario XXXXXXXXXXX

The [Blazor WebAssembly sample app (BlazorWebAssemblySample)](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/common/samples/) demonstrates the use of CORS in the Call Web API component (`Pages/CallWebAPI.razor`).

-->

For more information on secure CORS requests in Blazor WebAssembly apps, see <xref:blazor/security/webassembly/additional-scenarios#cross-origin-resource-sharing-cors>.

For general information on CORS, see <xref:security/cors>.

::: zone-end

::: zone pivot="server"

Browser security prevents a webpage from making requests to a different domain than the one that served the webpage. This restriction is called the *same-origin policy*. The same-origin policy prevents a malicious site from reading sensitive data from another site. To make requests from the browser to an endpoint with a different origin, the *endpoint* must enable [cross-origin resource sharing (CORS)](https://www.w3.org/TR/cors/).

For more information, see <xref:security/cors>.

::: zone-end

## Blazor framework component examples for testing web API access

Various network tools are publicly available for testing web API backend apps directly, such as [Fiddler](https://www.telerik.com/fiddler), [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/), or [Postman](https://www.postman.com). Blazor framework's reference source includes <xref:System.Net.Http.HttpClient> test assets that are useful for testing:

[`HttpClientTest` assets in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/BasicTestApp/HttpClientTest)

[!INCLUDE[](~/blazor/includes/aspnetcore-repo-ref-source-links.md)]

## Additional resources

::: zone pivot="webassembly"

* <xref:blazor/security/webassembly/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:security/cors>: Although the content applies to ASP.NET Core apps, not Blazor WebAssembly apps, the article covers general CORS concepts.
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)
* [Fetch API](https://developer.mozilla.org/docs/Web/API/WindowOrWorkerGlobalScope/fetch)

::: zone-end

::: zone pivot="server"

::: moniker range=">= aspnetcore-5.0"

* <xref:blazor/security/server/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:fundamentals/http-requests>
* <xref:security/enforcing-ssl>
* <xref:security/cors>
* [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints)
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)

::: moniker-end

::: moniker range="< aspnetcore-5.0"

* <xref:blazor/security/server/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:fundamentals/http-requests>
* <xref:security/enforcing-ssl>
* <xref:security/cors>
* [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration)
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)

::: moniker-end

::: zone-end
