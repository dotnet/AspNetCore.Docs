---
title: Return Razor component HTML from a web API in ASP.NET Core Blazor
ai-usage: ai-assisted
author: guardrex
description: Learn how to return HTML (as a string) from a web API (Minimal API) using the RazorComponentResult class.
monikerRange: '>= aspnetcore-8.0'
ms.author: wpickett
ms.date: 07/31/2026
uid: blazor/components/return-component-html-from-a-web-api
---
# Return Razor component HTML from a web API in ASP.NET Core Blazor

This article demonstrates how to return Razor component HTML (as a `string`) from a web API (Minimal API) using the <xref:Microsoft.AspNetCore.Http.HttpResults.RazorComponentResult> class.

Components returned via <xref:Microsoft.AspNetCore.Http.HttpResults.RazorComponentResult> are rendered as static HTML strings. Features requiring an active SignalR connection for component interactivity can't execute in this context.

## Add the Razor components to the web API

`Components/Greeting.razor`:

```razor
<h2>Greeting component</h2>

<p>Hello, world!</p>
```

`Components/UserData.razor`:

```razor
<h2>UserData component</h2>

<p>Viewing details for User ID: @UserId</p>

@code {
    [Parameter]
    public int UserId { get; set; }
}
```

## Add Razor component services and endpoints to the web API

For components with parameters, pass dictionary keys that exactly match the names of properties decorated with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute).

```csharp
using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

var app = builder.Build();

app.MapGet("/hello", () => new RazorComponentResult<Greeting>());

app.MapGet("/user/{id:int}", (int id) =>
{
    var parameters = new Dictionary<string, object?>
    {
        { "UserId", id }
    };

    return new RazorComponentResult<UserData>(parameters);
});
```

## Consume the API and read the component HTML from the `RazorComponentResult`

In the app's `Program` file, set up HTTP client services. The following example assumes that the web API responds to requests at `https://localhost:7286` using a [named `HttpClient`](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory):

```csharp
builder.Services.AddHttpClient("WebAPI", client =>
    client.BaseAddress = new Uri("https://localhost:7286"));
```

In a component, inject an <xref:System.Net.Http.IHttpClientFactory> and request the component HTML (as `string`s), casting each to a <xref:Microsoft.AspNetCore.Components.MarkupString> for rendering:

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should **always** be avoided.

```razor
@inject IHttpClientFactory ClientFactory

@greeting

@userData

@code {
    private MarkupString? greeting;
    private MarkupString? userData;

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient("WebAPI");
        greeting = new MarkupString(await client.GetStringAsync("hello"));
        userData = new MarkupString(await client.GetStringAsync("user/12345"));
    }
}
```
