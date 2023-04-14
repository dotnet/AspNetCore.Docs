---
title: Render Razor components outside of ASP.NET Core
author: guardrex
description: 
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/14/2023
uid: blazor/components/render-outside-of-aspnetcore
---
# Render Razor components outside of ASP.NET Core

Razor components can be rendered outside of the context of an HTTP request. You can render Razor components as HTML directly to a string or stream independently of the ASP.NET Core hosting environment. This is convenient for scenarios where you want to generate HTML fragments, such as for a generated email or static site content.

In the following example, a Razor component is rendered to an HTML string from a console app:

In a command shell, create a new console app project:

```dotnetcli
dotnet new console -o ConsoleApp1
cd ConsoleApp1
```

In a command shell in the `ConsoleApp1` folder, add package references for <xref:Microsoft.AspNetCore.Components.Web?displayProperty=fullName> and <xref:Microsoft.Extensions.Logging?displayProperty=fullName> to the console app:

```dotnetcli
dotnet add package Microsoft.AspNetCore.Components.Web --prerelease
dotnet add package Microsoft.Extensions.Logging --prerelease
```

In the console app's project file (`ConsoleApp1.csproj`), update the console app project to use the Razor SDK:

```diff
- <Project Sdk="Microsoft.NET.Sdk">
+ <Project Sdk="Microsoft.NET.Sdk.Razor">
```

In a command shell, add a Razor component to the project:

```dotnetcli
dotnet new razorcomponent -n Component1
```

```razor
<h1>Component1</h1>

<p>Hello from Component1!</p>

@code {

}
```

Update `Program.cs`:

* Set up dependency injection (<xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>/<xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A>) and logging (<xref:Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging%2A>/<xref:Microsoft.Extensions.Logging.ILoggerFactory>).
* Create an `HtmlRenderer` and render the `Component1` component by calling `RenderComponentAsync`.

Any calls to `RenderComponentAsync` must be made in the context of calling `InvokeAsync` on a component dispatcher. A component dispatcher is available from the `HtmlRender.Dispatcher` property.

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ConsoleApp1;

IServiceCollection services = new ServiceCollection();
services.AddLogging();

IServiceProvider serviceProvider = services.BuildServiceProvider();
ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
{
    var parameters = ParameterView.Empty;
    var output = await htmlRenderer.RenderComponentAsync<Component1>(parameters);
    return output.ToHtmlString();
});

Console.WriteLine(html);
```

Alternatively, you can write the HTML to a <xref:System.IO.TextWriter> by calling `output.WriteHtmlTo(textWriter)`.

The task returned by `RenderComponentAsync` completes when the component is fully rendered, including completing any asynchronous lifecycle methods. If you want to observe the rendered HTML earlier, call `BeginRenderComponentAsync` instead. Then, wait for the component rendering to complete by awaiting `WaitForQuiescenceAsync` on the returned `HtmlComponent` instance.
