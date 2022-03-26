---
title: Call a web API from an ASP.NET Core Blazor app
author: guardrex
description: Learn how to call a web API from Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/call-web-api
zone_pivot_groups: blazor-hosting-models
---
# Call a web API from ASP.NET Core Blazor

This article describes how to call a web API from a Blazor app.

:::moniker range=">= aspnetcore-6.0"

:::zone pivot="webassembly"

> [!NOTE]
> This article has loaded **Blazor WebAssembly** coverage for calling web APIs. The [Blazor Server coverage](?pivots=server) addresses the following subjects:
>
> * Use of the `HttpClient` factory infrastructure to provide an `HttpClient` to the app.
> * Cross-origin resource sharing (CORS) pertaining to Blazor Server apps.
> * Blazor framework component examples for testing web API access.
> * Additional resources for developing Blazor Server apps that call a web API.

[Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) apps call web APIs using a preconfigured <xref:System.Net.Http.HttpClient> service, which is focused on making requests back to the server of origin. Additional <xref:System.Net.Http.HttpClient> service configurations for other web APIs can be created in developer code. Requests are composed using Blazor JSON helpers or with <xref:System.Net.Http.HttpRequestMessage>. Requests can include [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) option configuration.

## Examples in this article

In this article's component examples, a hypothetical todo list web API is used to create, read, update, and delete (CRUD) todo items on a server. The examples are based on a `TodoItem` class that stores the following todo item data:

* ID (`Id`, `long`): Unique ID of the item.
* Name (`Name`, `string`): Name of the item.
* Status (`IsComplete`, `bool`): Indication if the todo item is finished.

Use the following `TodoItem` class with this article's examples if you build the examples into a test app:

```csharp
public class TodoItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
```

For guidance on how to create a server-side web API, see <xref:tutorials/first-web-api>. For information on Cross-origin resource sharing (CORS), see the [CORS guidance](#cross-origin-resource-sharing-cors) later in this article.

## Packages

Add a package reference for [`System.Net.Http.Json`](https://www.nuget.org/packages/System.Net.Http.Json).

[!INCLUDE[](~/includes/package-reference.md)]

## Add the `HttpClient` service

In `Program.cs`, add an <xref:System.Net.Http.HttpClient> service if it isn't already present from a Blazor project template used to create the app:

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });
```

## `HttpClient` and JSON helpers

<xref:System.Net.Http.HttpClient> is available as a preconfigured service for making requests back to the origin server.

<xref:System.Net.Http.HttpClient> and JSON helpers (<xref:System.Net.Http.Json.HttpClientJsonExtensions?displayProperty=nameWithType>) are also used to call third-party web API endpoints. <xref:System.Net.Http.HttpClient> is implemented using the browser's [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) and is subject to its limitations, including enforcement of the [same-origin policy (discussed later in this article)](#cross-origin-resource-sharing-cors).

The client's base address is set to the originating server's address. Inject an <xref:System.Net.Http.HttpClient> instance into a component using the [`@inject`](xref:mvc/views/razor#inject) directive:

```razor
@using System.Net.Http
@inject HttpClient Http
```

Use the <xref:System.Net.Http.Json?displayProperty=fullName> namespace for access to <xref:System.Net.Http.Json.HttpClientJsonExtensions>, including <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A>, <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A>, and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A>:

```razor
@using System.Net.Http.Json
```

### GET from JSON (`GetFromJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> sends an HTTP GET request and parses the JSON response body to create an object.

In the following component code, the `todoItems` are displayed by the component. <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> is called when the component is finished initializing ([`OnInitializedAsync`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)).

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject HttpClient Http

@if (todoItems == null)
{
    <p>No Todo Items found.</p>
}
else
{
    <ul>
        @foreach (var item in todoItems)
        {
            <li>@item.Name</li>
        }
    </ul>
}

@code {
    private TodoItem[]? todoItems;

    protected override async Task OnInitializedAsync() => 
        todoItems = await Http.GetFromJsonAsync<TodoItem[]>("api/TodoItems");
}
```

### POST as JSON (`PostAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> sends a POST request to the specified URI containing the value serialized as JSON in the request body.

In the following component code, `newItemName` is provided by a bound element of the component. The `AddItem` method is triggered by selecting a `<button>` element.

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject HttpClient Http

<input @bind="newItemName" placeholder="New Todo Item" />
<button @onclick="AddItem">Add</button>

@code {
    private string? newItemName;

    private async Task AddItem()
    {
        var addItem = new TodoItem { Name = newItemName, IsComplete = false };
        await Http.PostAsJsonAsync("api/TodoItems", addItem);
    }
}
```

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### PUT as JSON (`PutAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> sends an HTTP PUT request with JSON-encoded content.

In the following component code, `editItem` values for `Name` and `IsCompleted` are provided by bound elements of the component. The item's `Id` is set when the item is selected in another part of the UI (not shown) and `EditItem` is called. The `SaveItem` method is triggered by selecting the `<button>` element. Note that the following example doesn't show loading `todoItems` for brevity (see the [GET from JSON (`GetFromJsonAsync`)](#get-from-json-getfromjsonasync) section for an example of loading items).

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject HttpClient Http

<input type="checkbox" @bind="editItem.IsComplete" />
<input @bind="editItem.Name" />
<button @onclick="SaveItem">Save</button>

@code {
    private string? id;
    private TodoItem editItem = new TodoItem();

    private void EditItem(long id)
    {
        editItem = todoItems.Single(i => i.Id == id);
    }

    private async Task SaveItem() =>
        await Http.PutAsJsonAsync($"api/TodoItems/{editItem.Id}", editItem);
}
```

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### Additional extension methods

<xref:System.Net.Http> includes additional extension methods for sending HTTP requests and receiving HTTP responses. <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> is used to send an HTTP DELETE request to a web API.

In the following component code, the `<button>` element calls the `DeleteItem` method. The bound `<input>` element supplies the `id` of the item to delete.

```razor
@using System.Net.Http
@using System.Threading.Tasks
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

Add the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

In `Program.cs`:

```csharp
builder.Services.AddHttpClient("WebAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

In the following component code:

* An instance of <xref:System.Net.Http.IHttpClientFactory> creates a named <xref:System.Net.Http.HttpClient>.
* The named <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API.

`Pages/FetchDataViaFactory.razor`:

```razor
@page "/fetch-data-via-factory"
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject IHttpClientFactory ClientFactory

<h1>Fetch data via <code>IHttpClientFactory</code></h1>

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

@code {
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient("WebAPI");

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
        try
        {
            return await http.GetFromJsonAsync<WeatherForecast[]>(
                "WeatherForecast");
        }
        catch
        {
            ...

            return new WeatherForecast[0];
        }
    }
}
```

In `Program.cs`:

```csharp
builder.Services.AddHttpClient<WeatherForecastHttpClient>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

Components inject the typed <xref:System.Net.Http.HttpClient> to call the web API.

In the following component code:

* An instance of the preceding `WeatherForecastHttpClient` is injected, which creates a typed <xref:System.Net.Http.HttpClient>.
* The typed <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API.

`Pages/FetchDataViaTypedHttpClient.razor`:

```razor
@page "/fetch-data-via-typed-httpclient"
@using System.Threading.Tasks
@inject WeatherForecastHttpClient Http

<h1>Fetch data via typed <code>HttpClient</code></h1>

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

@code {
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetForecastAsync();
    }
}
```

## `HttpClient` and `HttpRequestMessage` with Fetch API request options

[`HttpClient`](xref:fundamentals/http-requests) ([API documentation](xref:System.Net.Http.HttpClient)) and <xref:System.Net.Http.HttpRequestMessage> can be used to customize requests. For example, you can specify the HTTP method and request headers. The following component makes a `POST` request to a web API endpoint and shows the response body.

`Pages/TodoRequest.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-web-api/TodoRequest.razor)]

Blazor WebAssembly's implementation of <xref:System.Net.Http.HttpClient> uses [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch). Fetch API allows the configuration of several [request-specific options](https://developer.mozilla.org/docs/Web/API/fetch#Parameters). Options can be configured with <xref:System.Net.Http.HttpRequestMessage> extension methods shown in the following table.

| Extension method | Fetch API request property |
| --- | --- |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCache%2A> | [`cache`](https://developer.mozilla.org/docs/Web/API/Request/cache) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> | [`credentials`](https://developer.mozilla.org/docs/Web/API/Request/credentials) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestIntegrity%2A> | [`integrity`](https://developer.mozilla.org/docs/Web/API/Request/integrity) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestMode%2A> | [`mode`](https://developer.mozilla.org/docs/Web/API/Request/mode) |

Set additional options using the generic <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestOption%2A> extension method.

The HTTP response is typically buffered to enable support for synchronous reads on the response content. To enable support for response streaming, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserResponseStreamingEnabled%2A> extension method on the request.

To include credentials in a cross-origin request, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> extension method:

```csharp
requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
```

For more information on Fetch API options, see [MDN web docs: WindowOrWorkerGlobalScope.fetch(): Parameters](https://developer.mozilla.org/docs/Web/API/fetch#Parameters).

## Call web API example

The following example calls a web API. The example requires a running web API based on the sample app described by the <xref:tutorials/first-web-api> article. This example makes requests to the web API at `https://localhost:10000/api/TodoItems`. If a different web API address is used, update the `ServiceEndpoint` constant value in the component's `@code` block.

The following example makes a [cross-origin resource sharing (CORS)](xref:security/cors) request from `http://localhost:5000` or `https://localhost:5001` to the web API. Add the following CORS middleware configuration to the web API's service's `Program.cs` file:

```csharp
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));
```

Adjust the domains and ports of `WithOrigins` as needed for the Blazor app. For more information, see <xref:security/cors>.

By default, ASP.NET Core apps use ports 5000 (HTTP) and 5001 (HTTPS). To run both apps on the same machine at the same time for testing, use a different port for the web API app (for example, port 10000). For more information on setting the port, see <xref:fundamentals/servers/kestrel/endpoints>.

`Pages/CallWebAPI.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-web-api/CallWebAPI.razor)]

## Handle errors

Handle web API response errors in developer code when they occur. For example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> expects a JSON response from the web API with a `Content-Type` of `application/json`. If the response isn't in JSON format, content validation throws a <xref:System.NotSupportedException>.

In the following example, the URI endpoint for the weather forecast data request is misspelled. The URI should be to `WeatherForecast` but appears in the call as `WeatherForcast`, which is missing the letter `e` in `Forecast`.

The <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> call expects JSON to be returned, but the web API returns HTML for an unhandled exception with a `Content-Type` of `text/html`. The unhandled exception occurs because the path to `/WeatherForcast` isn't found and middleware can't serve a page or view for the request.

In <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> on the client, <xref:System.NotSupportedException> is thrown when the response content is validated as non-JSON. The exception is caught in the `catch` block, where custom logic could log the error or present a friendly error message to the user.

`Pages/FetchDataReturnsHTMLOnException.razor`:

```razor
@page "/fetch-data-returns-html-on-exception"
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
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

:::zone-end

:::zone pivot="server"

> [!NOTE]
> This article has loaded **Blazor Server** coverage for calling web APIs. The [Blazor WebAssembly coverage](?pivots=webassembly) addresses the following subjects:
>
> * Blazor WebAssembly examples based on an client-side WebAssembly app that calls a web API to create, read, update, and delete todo list items.
> * `System.Net.Http.Json` package.
> * `HttpClient` service configuration.
> * `HttpClient` and JSON helpers (`GetFromJsonAsync`, `PostAsJsonAsync`, `PutAsJsonAsync`, `DeleteAsync`).
> * `IHttpClientFactory` services and the configuration of a named `HttpClient`.
> * Typed `HttpClient`.
> * `HttpClient` and `HttpRequestMessage` to customize requests.
> * Call web API example with cross-origin resource sharing (CORS) and how CORS pertains to Blazor WebAssembly apps.
> * How to handle web API response errors in developer code.
> * Blazor framework component examples for testing web API access.
> * Additional resources for developing Blazor WebAssembly apps that call a web API.

[Blazor Server](xref:blazor/hosting-models#blazor-server) apps call web APIs using <xref:System.Net.Http.HttpClient> instances, typically created using <xref:System.Net.Http.IHttpClientFactory>. For guidance that applies to Blazor Server, see <xref:fundamentals/http-requests>.

A Blazor Server app doesn't include an <xref:System.Net.Http.HttpClient> service by default. Provide an <xref:System.Net.Http.HttpClient> to the app using the [`HttpClient` factory infrastructure](xref:fundamentals/http-requests).

In `Program.cs`:

```csharp
builder.Services.AddHttpClient();
```

The following Blazor Server Razor component makes a request to a web API for GitHub branches similar to the *Basic Usage* example in the <xref:fundamentals/http-requests> article.

`Pages/CallWebAPI.razor`:

```razor
@page "/call-web-api"
@using System.Text.Json
@using System.Text.Json.Serialization;
@inject IHttpClientFactory ClientFactory

<h1>Call web API from a Blazor Server Razor component</h1>

@if (getBranchesError)
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
    private IEnumerable<GitHubBranch> branches = Array.Empty<GitHubBranch>();
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
        public string Name { get; set; }
    }
}
```

For an additional working example, see the Blazor Server file upload example that uploads files to a web API controller in the <xref:blazor/file-uploads#upload-files-to-a-server> article.

:::zone-end

## Cross-origin resource sharing (CORS)

Browser security restricts a webpage from making requests to a different domain than the one that served the webpage. This restriction is called the *same-origin policy*. The same-origin policy restricts (but doesn't prevent) a malicious site from reading sensitive data from another site. To make requests from the browser to an endpoint with a different origin, the *endpoint* must enable [cross-origin resource sharing (CORS)](https://www.w3.org/TR/cors/).

:::zone pivot="webassembly"

For information on CORS requests in Blazor WebAssembly apps, see <xref:blazor/security/webassembly/additional-scenarios#cross-origin-resource-sharing-cors>.

For information on CORS, see <xref:security/cors>. The article's examples don't pertain directly to Blazor WebAssembly apps, but the article is useful for learning general CORS concepts.

:::zone-end

:::zone pivot="server"

For more information, see <xref:security/cors>.

:::zone-end

## Blazor framework component examples for testing web API access

Various network tools are publicly available for testing web API backend apps directly, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/) and [Postman](https://www.postman.com). Blazor framework's reference source includes <xref:System.Net.Http.HttpClient> test assets that are useful for testing:

[`HttpClientTest` assets in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/BasicTestApp/HttpClientTest)

## Additional resources

:::zone pivot="webassembly"

* <xref:blazor/security/webassembly/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:security/cors>: Although the content applies to ASP.NET Core apps, not Blazor WebAssembly apps, the article covers general CORS concepts.
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)
* [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch)

:::zone-end

:::zone pivot="server"

* <xref:blazor/security/server/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:fundamentals/http-requests>
* <xref:security/enforcing-ssl>
* <xref:security/cors>
* [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints)
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)

:::zone-end

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::zone pivot="webassembly"

> [!NOTE]
> This article has loaded **Blazor WebAssembly** coverage for calling web APIs. The [Blazor Server coverage](?pivots=server) addresses the following subjects:
>
> * Use of the `HttpClient` factory infrastructure to provide an `HttpClient` to the app.
> * Cross-origin resource sharing (CORS) pertaining to Blazor Server apps.
> * Blazor framework component examples for testing web API access.
> * Additional resources for developing Blazor Server apps that call a web API.

[Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) apps call web APIs using a preconfigured <xref:System.Net.Http.HttpClient> service, which is focused on making requests back to the server of origin. Additional <xref:System.Net.Http.HttpClient> service configurations for other web APIs can be created in developer code. Requests are composed using Blazor JSON helpers or with <xref:System.Net.Http.HttpRequestMessage>. Requests can include [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) option configuration.

## Examples in this article

In this article's component examples, a hypothetical todo list web API is used to create, read, update, and delete (CRUD) todo items on a server. The examples are based on a `TodoItem` class that stores the following todo item data:

* ID (`Id`, `long`): Unique ID of the item.
* Name (`Name`, `string`): Name of the item.
* Status (`IsComplete`, `bool`): Indication if the todo item is finished.

Use the following `TodoItem` class with this article's examples if you build the examples into a test app:

```csharp
public class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}
```

For guidance on how to create a server-side web API, see <xref:tutorials/first-web-api>. For information on Cross-origin resource sharing (CORS), see the [CORS guidance](#cross-origin-resource-sharing-cors) later in this article.

## Packages

Add a package reference for [`System.Net.Http.Json`](https://www.nuget.org/packages/System.Net.Http.Json).

[!INCLUDE[](~/includes/package-reference.md)]

## Add the `HttpClient` service

In `Program.cs`, add an <xref:System.Net.Http.HttpClient> service if it isn't already present from a Blazor project template used to create the app:

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });
```

## `HttpClient` and JSON helpers

<xref:System.Net.Http.HttpClient> is available as a preconfigured service for making requests back to the origin server.

<xref:System.Net.Http.HttpClient> and JSON helpers (<xref:System.Net.Http.Json.HttpClientJsonExtensions?displayProperty=nameWithType>) are also used to call third-party web API endpoints. <xref:System.Net.Http.HttpClient> is implemented using the browser's [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) and is subject to its limitations, including enforcement of the [same-origin policy (discussed later in this article)](#cross-origin-resource-sharing-cors).

The client's base address is set to the originating server's address. Inject an <xref:System.Net.Http.HttpClient> instance into a component using the [`@inject`](xref:mvc/views/razor#inject) directive:

```razor
@using System.Net.Http
@inject HttpClient Http
```

Use the <xref:System.Net.Http.Json?displayProperty=fullName> namespace for access to <xref:System.Net.Http.Json.HttpClientJsonExtensions>, including <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A>, <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A>, and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A>:

```razor
@using System.Net.Http.Json
```

### GET from JSON (`GetFromJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> sends an HTTP GET request and parses the JSON response body to create an object.

In the following component code, the `todoItems` are displayed by the component. <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> is called when the component is finished initializing ([`OnInitializedAsync`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)).

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject HttpClient Http

@if (todoItems == null)
{
    <p>No Todo Items found.</p>
}
else
{
    <ul>
        @foreach (var item in todoItems)
        {
            <li>@item.Name</li>
        }
    </ul>
}

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
@using System.Net.Http.Json
@using System.Threading.Tasks
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

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### PUT as JSON (`PutAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> sends an HTTP PUT request with JSON-encoded content.

In the following component code, `editItem` values for `Name` and `IsCompleted` are provided by bound elements of the component. The item's `Id` is set when the item is selected in another part of the UI (not shown) and `EditItem` is called. The `SaveItem` method is triggered by selecting the `<button>` element.

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject HttpClient Http

<input type="checkbox" @bind="editItem.IsComplete" />
<input @bind="editItem.Name" />
<button @onclick="SaveItem">Save</button>

@code {
    private string id;
    private TodoItem editItem = new TodoItem();

    private void EditItem(long id)
    {
        editItem = todoItems.Single(i => i.Id == id);
    }

    private async Task SaveItem() =>
        await Http.PutAsJsonAsync($"api/TodoItems/{editItem.Id}", editItem);
}
```

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### Additional extension methods

<xref:System.Net.Http> includes additional extension methods for sending HTTP requests and receiving HTTP responses. <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> is used to send an HTTP DELETE request to a web API.

In the following component code, the `<button>` element calls the `DeleteItem` method. The bound `<input>` element supplies the `id` of the item to delete.

```razor
@using System.Net.Http
@using System.Threading.Tasks
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

Add the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

In `Program.cs`:

```csharp
builder.Services.AddHttpClient("WebAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

In the following component code:

* An instance of <xref:System.Net.Http.IHttpClientFactory> creates a named <xref:System.Net.Http.HttpClient>.
* The named <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API.

`Pages/FetchDataViaFactory.razor`:

```razor
@page "/fetch-data-via-factory"
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject IHttpClientFactory ClientFactory

<h1>Fetch data via <code>IHttpClientFactory</code></h1>

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

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient("WebAPI");

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
        try
        {
            return await http.GetFromJsonAsync<WeatherForecast[]>(
                "WeatherForecast");
        }
        catch
        {
            ...

            return new WeatherForecast[0];
        }
    }
}
```

In `Program.cs`:

```csharp
builder.Services.AddHttpClient<WeatherForecastHttpClient>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

Components inject the typed <xref:System.Net.Http.HttpClient> to call the web API.

In the following component code:

* An instance of the preceding `WeatherForecastHttpClient` is injected, which creates a typed <xref:System.Net.Http.HttpClient>.
* The typed <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API.

`Pages/FetchDataViaTypedHttpClient.razor`:

```razor
@page "/fetch-data-via-typed-httpclient"
@using System.Threading.Tasks
@inject WeatherForecastHttpClient Http

<h1>Fetch data via typed <code>HttpClient</code></h1>

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

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetForecastAsync();
    }
}
```

## `HttpClient` and `HttpRequestMessage` with Fetch API request options

[`HttpClient`](xref:fundamentals/http-requests) ([API documentation](xref:System.Net.Http.HttpClient)) and <xref:System.Net.Http.HttpRequestMessage> can be used to customize requests. For example, you can specify the HTTP method and request headers. The following component makes a `POST` request to a web API endpoint and shows the response body.

`Pages/TodoRequest.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-web-api/TodoRequest.razor)]

Blazor WebAssembly's implementation of <xref:System.Net.Http.HttpClient> uses [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch). Fetch API allows the configuration of several [request-specific options](https://developer.mozilla.org/docs/Web/API/fetch#Parameters). Options can be configured with <xref:System.Net.Http.HttpRequestMessage> extension methods shown in the following table.

| Extension method | Fetch API request property |
| --- | --- |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCache%2A> | [`cache`](https://developer.mozilla.org/docs/Web/API/Request/cache) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> | [`credentials`](https://developer.mozilla.org/docs/Web/API/Request/credentials) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestIntegrity%2A> | [`integrity`](https://developer.mozilla.org/docs/Web/API/Request/integrity) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestMode%2A> | [`mode`](https://developer.mozilla.org/docs/Web/API/Request/mode) |

Set additional options using the generic <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestOption%2A> extension method.

The HTTP response is typically buffered to enable support for synchronous reads on the response content. To enable support for response streaming, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserResponseStreamingEnabled%2A> extension method on the request.

To include credentials in a cross-origin request, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> extension method:

```csharp
requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
```

For more information on Fetch API options, see [MDN web docs: WindowOrWorkerGlobalScope.fetch(): Parameters](https://developer.mozilla.org/docs/Web/API/fetch#Parameters).

## Call web API example

The following example calls a web API. The example requires a running web API based on the sample app described by the <xref:tutorials/first-web-api> article. This example makes requests to the web API at `https://localhost:10000/api/TodoItems`. If a different web API address is used, update the `ServiceEndpoint` constant value in the component's `@code` block.

The following example makes a [cross-origin resource sharing (CORS)](xref:security/cors) request from `http://localhost:5000` or `https://localhost:5001` to the web API. Add the following CORS middleware configuration to the web API's service's `Startup.Configure` method:

```csharp
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));
```

Adjust the domains and ports of `WithOrigins` as needed for the Blazor app. For more information, see <xref:security/cors>.

By default, ASP.NET Core apps use ports 5000 (HTTP) and 5001 (HTTPS). To run both apps on the same machine at the same time for testing, use a different port for the web API app (for example, port 10000). For more information on setting the port, see <xref:fundamentals/servers/kestrel/endpoints>.

`Pages/CallWebAPI.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-web-api/CallWebAPI.razor)]

## Handle errors

Handle web API response errors in developer code when they occur. For example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> expects a JSON response from the web API with a `Content-Type` of `application/json`. If the response isn't in JSON format, content validation throws a <xref:System.NotSupportedException>.

In the following example, the URI endpoint for the weather forecast data request is misspelled. The URI should be to `WeatherForecast` but appears in the call as `WeatherForcast`, which is missing the letter `e` in `Forecast`.

The <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> call expects JSON to be returned, but the web API returns HTML for an unhandled exception with a `Content-Type` of `text/html`. The unhandled exception occurs because the path to `/WeatherForcast` isn't found and middleware can't serve a page or view for the request.

In <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> on the client, <xref:System.NotSupportedException> is thrown when the response content is validated as non-JSON. The exception is caught in the `catch` block, where custom logic could log the error or present a friendly error message to the user.

`Pages/FetchDataReturnsHTMLOnException.razor`:

```razor
@page "/fetch-data-returns-html-on-exception"
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
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
    private WeatherForecast[] forecasts;
    private string exceptionMessage;

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

:::zone-end

:::zone pivot="server"

> [!NOTE]
> This article has loaded **Blazor Server** coverage for calling web APIs. The [Blazor WebAssembly coverage](?pivots=webassembly) addresses the following subjects:
>
> * Blazor WebAssembly examples based on an client-side WebAssembly app that calls a web API to create, read, update, and delete todo list items.
> * `System.Net.Http.Json` package.
> * `HttpClient` service configuration.
> * `HttpClient` and JSON helpers (`GetFromJsonAsync`, `PostAsJsonAsync`, `PutAsJsonAsync`, `DeleteAsync`).
> * `IHttpClientFactory` services and the configuration of a named `HttpClient`.
> * Typed `HttpClient`.
> * `HttpClient` and `HttpRequestMessage` to customize requests.
> * Call web API example with cross-origin resource sharing (CORS) and how CORS pertains to Blazor WebAssembly apps.
> * How to handle web API response errors in developer code.
> * Blazor framework component examples for testing web API access.
> * Additional resources for developing Blazor WebAssembly apps that call a web API.

[Blazor Server](xref:blazor/hosting-models#blazor-server) apps call web APIs using <xref:System.Net.Http.HttpClient> instances, typically created using <xref:System.Net.Http.IHttpClientFactory>. For guidance that applies to Blazor Server, see <xref:fundamentals/http-requests>.

A Blazor Server app doesn't include an <xref:System.Net.Http.HttpClient> service by default. Provide an <xref:System.Net.Http.HttpClient> to the app using the [`HttpClient` factory infrastructure](xref:fundamentals/http-requests).

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
services.AddHttpClient();
```

The following Blazor Server Razor component makes a request to a web API for GitHub branches similar to the *Basic Usage* example in the <xref:fundamentals/http-requests> article.

`Pages/CallWebAPI.razor`:

```razor
@page "/call-web-api"
@using System.Text.Json
@using System.Text.Json.Serialization;
@inject IHttpClientFactory ClientFactory

<h1>Call web API from a Blazor Server Razor component</h1>

@if (getBranchesError)
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
    private IEnumerable<GitHubBranch> branches = Array.Empty<GitHubBranch>();
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
        public string Name { get; set; }
    }
}
```

For an additional working example, see the Blazor Server file upload example that uploads files to a web API controller in the <xref:blazor/file-uploads#upload-files-to-a-server> article.

:::zone-end

## Cross-origin resource sharing (CORS)

Browser security restricts a webpage from making requests to a different domain than the one that served the webpage. This restriction is called the *same-origin policy*. The same-origin policy restricts (but doesn't prevent) a malicious site from reading sensitive data from another site. To make requests from the browser to an endpoint with a different origin, the *endpoint* must enable [cross-origin resource sharing (CORS)](https://www.w3.org/TR/cors/).

:::zone pivot="webassembly"

For information on CORS requests in Blazor WebAssembly apps, see <xref:blazor/security/webassembly/additional-scenarios#cross-origin-resource-sharing-cors>.

For information on CORS, see <xref:security/cors>. The article's examples don't pertain directly to Blazor WebAssembly apps, but the article is useful for learning general CORS concepts.

:::zone-end

:::zone pivot="server"

For more information, see <xref:security/cors>.

:::zone-end

## Blazor framework component examples for testing web API access

Various network tools are publicly available for testing web API backend apps directly, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/) and [Postman](https://www.postman.com). Blazor framework's reference source includes <xref:System.Net.Http.HttpClient> test assets that are useful for testing:

[`HttpClientTest` assets in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/BasicTestApp/HttpClientTest)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Additional resources

:::zone pivot="webassembly"

* <xref:blazor/security/webassembly/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:security/cors>: Although the content applies to ASP.NET Core apps, not Blazor WebAssembly apps, the article covers general CORS concepts.
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)
* [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch)

:::zone-end

:::zone pivot="server"

* <xref:blazor/security/server/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:fundamentals/http-requests>
* <xref:security/enforcing-ssl>
* <xref:security/cors>
* [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints)
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)

:::zone-end

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::zone pivot="webassembly"

> [!NOTE]
> This article has loaded **Blazor WebAssembly** coverage for calling web APIs. The [Blazor Server coverage](?pivots=server) addresses the following subjects:
>
> * Use of the `HttpClient` factory infrastructure to provide an `HttpClient` to the app.
> * Cross-origin resource sharing (CORS) pertaining to Blazor Server apps.
> * Blazor framework component examples for testing web API access.
> * Additional resources for developing Blazor Server apps that call a web API.

[Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) apps call web APIs using a preconfigured <xref:System.Net.Http.HttpClient> service, which is focused on making requests back to the server of origin. Additional <xref:System.Net.Http.HttpClient> service configurations for other web APIs can be created in developer code. Requests are composed using Blazor JSON helpers or with <xref:System.Net.Http.HttpRequestMessage>. Requests can include [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) option configuration.

## Examples in this article

In this article's component examples, a hypothetical todo list web API is used to create, read, update, and delete (CRUD) todo items on a server. The examples are based on a `TodoItem` class that stores the following todo item data:

* ID (`Id`, `long`): Unique ID of the item.
* Name (`Name`, `string`): Name of the item.
* Status (`IsComplete`, `bool`): Indication if the todo item is finished.

Use the following `TodoItem` class with this article's examples if you build the examples into a test app:

```csharp
public class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}
```

For guidance on how to create a server-side web API, see <xref:tutorials/first-web-api>. For information on Cross-origin resource sharing (CORS), see the [CORS guidance](#cross-origin-resource-sharing-cors) later in this article.

## Packages

Add a package reference for [`System.Net.Http.Json`](https://www.nuget.org/packages/System.Net.Http.Json).

[!INCLUDE[](~/includes/package-reference.md)]

## Add the `HttpClient` service

In `Program.cs`, add an <xref:System.Net.Http.HttpClient> service if it isn't already present from a Blazor project template used to create the app:

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });
```

## `HttpClient` and JSON helpers

<xref:System.Net.Http.HttpClient> is available as a preconfigured service for making requests back to the origin server.

<xref:System.Net.Http.HttpClient> and JSON helpers (<xref:System.Net.Http.Json.HttpClientJsonExtensions?displayProperty=nameWithType>) are also used to call third-party web API endpoints. <xref:System.Net.Http.HttpClient> is implemented using the browser's [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) and is subject to its limitations, including enforcement of the [same-origin policy (discussed later in this article)](#cross-origin-resource-sharing-cors).

The client's base address is set to the originating server's address. Inject an <xref:System.Net.Http.HttpClient> instance into a component using the [`@inject`](xref:mvc/views/razor#inject) directive:

```razor
@using System.Net.Http
@inject HttpClient Http
```

Use the <xref:System.Net.Http.Json?displayProperty=fullName> namespace for access to <xref:System.Net.Http.Json.HttpClientJsonExtensions>, including <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A>, <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A>, and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A>:

```razor
@using System.Net.Http.Json
```

### GET from JSON (`GetFromJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> sends an HTTP GET request and parses the JSON response body to create an object.

In the following component code, the `todoItems` are displayed by the component. <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> is called when the component is finished initializing ([`OnInitializedAsync`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)).

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject HttpClient Http

@if (todoItems == null)
{
    <p>No Todo Items found.</p>
}
else
{
    <ul>
        @foreach (var item in todoItems)
        {
            <li>@item.Name</li>
        }
    </ul>
}

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
@using System.Net.Http.Json
@using System.Threading.Tasks
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

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### PUT as JSON (`PutAsJsonAsync`)

<xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> sends an HTTP PUT request with JSON-encoded content.

In the following component code, `editItem` values for `Name` and `IsCompleted` are provided by bound elements of the component. The item's `Id` is set when the item is selected in another part of the UI (not shown) and `EditItem` is called. The `SaveItem` method is triggered by selecting the `<button>` element.

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject HttpClient Http

<input type="checkbox" @bind="editItem.IsComplete" />
<input @bind="editItem.Name" />
<button @onclick="SaveItem">Save</button>

@code {
    private string id;
    private TodoItem editItem = new TodoItem();

    private void EditItem(long id)
    {
        editItem = todoItems.Single(i => i.Id == id);
    }

    private async Task SaveItem() =>
        await Http.PutAsJsonAsync($"api/TodoItems/{editItem.Id}", editItem);
}
```

Calls to <xref:System.Net.Http.Json.HttpClientJsonExtensions.PutAsJsonAsync%2A> return an <xref:System.Net.Http.HttpResponseMessage>. To deserialize the JSON content from the response message, use the <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> extension method. The following example reads JSON weather data:

```csharp
var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
```

### Additional extension methods

<xref:System.Net.Http> includes additional extension methods for sending HTTP requests and receiving HTTP responses. <xref:System.Net.Http.HttpClient.DeleteAsync%2A?displayProperty=nameWithType> is used to send an HTTP DELETE request to a web API.

In the following component code, the `<button>` element calls the `DeleteItem` method. The bound `<input>` element supplies the `id` of the item to delete.

```razor
@using System.Net.Http
@using System.Threading.Tasks
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

Add the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

In `Program.cs`:

```csharp
builder.Services.AddHttpClient("WebAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

In the following component code:

* An instance of <xref:System.Net.Http.IHttpClientFactory> creates a named <xref:System.Net.Http.HttpClient>.
* The named <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API.

`Pages/FetchDataViaFactory.razor`:

```razor
@page "/fetch-data-via-factory"
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
@inject IHttpClientFactory ClientFactory

<h1>Fetch data via <code>IHttpClientFactory</code></h1>

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

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient("WebAPI");

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
        try
        {
            return await http.GetFromJsonAsync<WeatherForecast[]>(
                "WeatherForecast");
        }
        catch
        {
            ...

            return new WeatherForecast[0];
        }
    }
}
```

In `Program.cs`:

```csharp
builder.Services.AddHttpClient<WeatherForecastHttpClient>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

Components inject the typed <xref:System.Net.Http.HttpClient> to call the web API.

In the following component code:

* An instance of the preceding `WeatherForecastHttpClient` is injected, which creates a typed <xref:System.Net.Http.HttpClient>.
* The typed <xref:System.Net.Http.HttpClient> is used to issue a GET request for JSON weather forecast data from the web API.

`Pages/FetchDataViaTypedHttpClient.razor`:

```razor
@page "/fetch-data-via-typed-httpclient"
@using System.Threading.Tasks
@inject WeatherForecastHttpClient Http

<h1>Fetch data via typed <code>HttpClient</code></h1>

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

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetForecastAsync();
    }
}
```

## `HttpClient` and `HttpRequestMessage` with Fetch API request options

[`HttpClient`](xref:fundamentals/http-requests) ([API documentation](xref:System.Net.Http.HttpClient)) and <xref:System.Net.Http.HttpRequestMessage> can be used to customize requests. For example, you can specify the HTTP method and request headers. The following component makes a `POST` request to a web API endpoint and shows the response body.

`Pages/TodoRequest.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-web-api/TodoRequest.razor)]

Blazor WebAssembly's implementation of <xref:System.Net.Http.HttpClient> uses [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch). Fetch API allows the configuration of several [request-specific options](https://developer.mozilla.org/docs/Web/API/fetch#Parameters). Options can be configured with <xref:System.Net.Http.HttpRequestMessage> extension methods shown in the following table.

| Extension method | Fetch API request property |
| --- | --- |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCache%2A> | [`cache`](https://developer.mozilla.org/docs/Web/API/Request/cache) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> | [`credentials`](https://developer.mozilla.org/docs/Web/API/Request/credentials) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestIntegrity%2A> | [`integrity`](https://developer.mozilla.org/docs/Web/API/Request/integrity) |
| <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestMode%2A> | [`mode`](https://developer.mozilla.org/docs/Web/API/Request/mode) |

Set additional options using the generic <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestOption%2A> extension method.

The HTTP response is typically buffered to enable support for synchronous reads on the response content. To enable support for response streaming, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserResponseStreamingEnabled%2A> extension method on the request.

To include credentials in a cross-origin request, use the <xref:Microsoft.AspNetCore.Components.WebAssembly.Http.WebAssemblyHttpRequestMessageExtensions.SetBrowserRequestCredentials%2A> extension method:

```csharp
requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
```

For more information on Fetch API options, see [MDN web docs: WindowOrWorkerGlobalScope.fetch(): Parameters](https://developer.mozilla.org/docs/Web/API/fetch#Parameters).

## Call web API example

The following example calls a web API. The example requires a running web API based on the sample app described by the <xref:tutorials/first-web-api> article. This example makes requests to the web API at `https://localhost:10000/api/TodoItems`. If a different web API address is used, update the `ServiceEndpoint` constant value in the component's `@code` block.

The following example makes a [cross-origin resource sharing (CORS)](xref:security/cors) request from `http://localhost:5000` or `https://localhost:5001` to the web API. Add the following CORS middleware configuration to the web API's service's `Startup.Configure` method:

```csharp
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));
```

Adjust the domains and ports of `WithOrigins` as needed for the Blazor app. For more information, see <xref:security/cors>.

By default, ASP.NET Core apps use ports 5000 (HTTP) and 5001 (HTTPS). To run both apps on the same machine at the same time for testing, use a different port for the web API app (for example, port 10000). For more information on setting the port, see <xref:fundamentals/servers/kestrel#endpoint-configuration>.

`Pages/CallWebAPI.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-web-api/CallWebAPI.razor)]

## Handle errors

Handle web API response errors in developer code when they occur. For example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> expects a JSON response from the web API with a `Content-Type` of `application/json`. If the response isn't in JSON format, content validation throws a <xref:System.NotSupportedException>.

In the following example, the URI endpoint for the weather forecast data request is misspelled. The URI should be to `WeatherForecast` but appears in the call as `WeatherForcast`, which is missing the letter `e` in `Forecast`.

The <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A> call expects JSON to be returned, but the web API returns HTML for an unhandled exception with a `Content-Type` of `text/html`. The unhandled exception occurs because the path to `/WeatherForcast` isn't found and middleware can't serve a page or view for the request.

In <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> on the client, <xref:System.NotSupportedException> is thrown when the response content is validated as non-JSON. The exception is caught in the `catch` block, where custom logic could log the error or present a friendly error message to the user.

`Pages/FetchDataReturnsHTMLOnException.razor`:

```razor
@page "/fetch-data-returns-html-on-exception"
@using System.Net.Http
@using System.Net.Http.Json
@using System.Threading.Tasks
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
    private WeatherForecast[] forecasts;
    private string exceptionMessage;

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

:::zone-end

:::zone pivot="server"

> [!NOTE]
> This article has loaded **Blazor Server** coverage for calling web APIs. The [Blazor WebAssembly coverage](?pivots=webassembly) addresses the following subjects:
>
> * Blazor WebAssembly examples based on an client-side WebAssembly app that calls a web API to create, read, update, and delete todo list items.
> * `System.Net.Http.Json` package.
> * `HttpClient` service configuration.
> * `HttpClient` and JSON helpers (`GetFromJsonAsync`, `PostAsJsonAsync`, `PutAsJsonAsync`, `DeleteAsync`).
> * `IHttpClientFactory` services and the configuration of a named `HttpClient`.
> * Typed `HttpClient`.
> * `HttpClient` and `HttpRequestMessage` to customize requests.
> * Call web API example with cross-origin resource sharing (CORS) and how CORS pertains to Blazor WebAssembly apps.
> * How to handle web API response errors in developer code.
> * Blazor framework component examples for testing web API access.
> * Additional resources for developing Blazor WebAssembly apps that call a web API.

[Blazor Server](xref:blazor/hosting-models#blazor-server) apps call web APIs using <xref:System.Net.Http.HttpClient> instances, typically created using <xref:System.Net.Http.IHttpClientFactory>. For guidance that applies to Blazor Server, see <xref:fundamentals/http-requests>.

A Blazor Server app doesn't include an <xref:System.Net.Http.HttpClient> service by default. Provide an <xref:System.Net.Http.HttpClient> to the app using the [`HttpClient` factory infrastructure](xref:fundamentals/http-requests).

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
services.AddHttpClient();
```

The following Blazor Server Razor component makes a request to a web API for GitHub branches similar to the *Basic Usage* example in the <xref:fundamentals/http-requests> article.

`Pages/CallWebAPI.razor`:

```razor
@page "/call-web-api"
@using System.Text.Json
@using System.Text.Json.Serialization;
@inject IHttpClientFactory ClientFactory

<h1>Call web API from a Blazor Server Razor component</h1>

@if (getBranchesError)
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
    private IEnumerable<GitHubBranch> branches = Array.Empty<GitHubBranch>();
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
        public string Name { get; set; }
    }
}
```

For an additional working example, see the Blazor Server file upload example that uploads files to a web API controller in the <xref:blazor/file-uploads#upload-files-to-a-server> article.

:::zone-end

## Cross-origin resource sharing (CORS)

Browser security restricts a webpage from making requests to a different domain than the one that served the webpage. This restriction is called the *same-origin policy*. The same-origin policy restricts (but doesn't prevent) a malicious site from reading sensitive data from another site. To make requests from the browser to an endpoint with a different origin, the *endpoint* must enable [cross-origin resource sharing (CORS)](https://www.w3.org/TR/cors/).

:::zone pivot="webassembly"

For information on CORS requests in Blazor WebAssembly apps, see <xref:blazor/security/webassembly/additional-scenarios#cross-origin-resource-sharing-cors>.

For information on CORS, see <xref:security/cors>. The article's examples don't pertain directly to Blazor WebAssembly apps, but the article is useful for learning general CORS concepts.

:::zone-end

:::zone pivot="server"

For more information, see <xref:security/cors>.

:::zone-end

## Blazor framework component examples for testing web API access

Various network tools are publicly available for testing web API backend apps directly, such as [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/) and [Postman](https://www.postman.com). Blazor framework's reference source includes <xref:System.Net.Http.HttpClient> test assets that are useful for testing:

[`HttpClientTest` assets in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/main/src/Components/test/testassets/BasicTestApp/HttpClientTest)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Additional resources

:::zone pivot="webassembly"

* <xref:blazor/security/webassembly/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:security/cors>: Although the content applies to ASP.NET Core apps, not Blazor WebAssembly apps, the article covers general CORS concepts.
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)
* [Fetch API](https://developer.mozilla.org/docs/Web/API/fetch)

:::zone-end

:::zone pivot="server"

* <xref:blazor/security/server/additional-scenarios>: Includes coverage on using <xref:System.Net.Http.HttpClient> to make secure web API requests.
* <xref:fundamentals/http-requests>
* <xref:security/enforcing-ssl>
* <xref:security/cors>
* [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration)
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)

:::zone-end

:::moniker-end
