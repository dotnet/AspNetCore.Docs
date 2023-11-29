---
title: Render Razor components outside of ASP.NET Core
author: guardrex
description: Render Razor components outside of the context of an HTTP request.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/render-outside-of-aspnetcore
---
# Render Razor components outside of ASP.NET Core

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

Razor components can be rendered outside of the context of an HTTP request. You can render Razor components as HTML directly to a string or stream independently of the ASP.NET Core hosting environment. This is convenient for scenarios where you want to generate HTML fragments, such as for generating email content, generating static site content, or for building a content templating engine.

In the following example, a Razor component is rendered to an HTML string from a console app:

In a command shell, create a new console app project:

```dotnetcli
dotnet new console -o ConsoleApp1
cd ConsoleApp1
```

In a command shell in the `ConsoleApp1` folder, add package references for <xref:Microsoft.AspNetCore.Components.Web?displayProperty=fullName> and <xref:Microsoft.Extensions.Logging?displayProperty=fullName> to the console app:

```dotnetcli
dotnet add package Microsoft.AspNetCore.Components.Web
dotnet add package Microsoft.Extensions.Logging
```

In the console app's project file (`ConsoleApp1.csproj`), update the console app project to use the Razor SDK:

```diff
- <Project Sdk="Microsoft.NET.Sdk">
+ <Project Sdk="Microsoft.NET.Sdk.Razor">
```

Add the following `RenderMessage` component to the project.

`RenderMessage.razor`:

```razor
<h1>Render Message</h1>

<p>@Message</p>

@code {
    [Parameter]
    public string Message { get; set; }
}
```

Update the `Program` file:

* Set up dependency injection (<xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>/<xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A>) and logging (<xref:Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging%2A>/<xref:Microsoft.Extensions.Logging.ILoggerFactory>).
* Create an <xref:Microsoft.AspNetCore.Components.Web.HtmlRenderer> and render the `RenderMessage` component by calling <xref:Microsoft.AspNetCore.Components.Web.HtmlRenderer.RenderComponentAsync%2A>.

Any calls to <xref:Microsoft.AspNetCore.Components.Web.HtmlRenderer.RenderComponentAsync%2A> must be made in the context of calling `InvokeAsync` on a component dispatcher. A component dispatcher is available from the <xref:Microsoft.AspNetCore.Components.Web.HtmlRenderer.Dispatcher?displayProperty=nameWithType> property.

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
    var dictionary = new Dictionary<string, object?>
    {
        { "Message", "Hello from the Render Message component!" }
    };

    var parameters = ParameterView.FromDictionary(dictionary);
    var output = await htmlRenderer.RenderComponentAsync<RenderMessage>(parameters);

    return output.ToHtmlString();
});

Console.WriteLine(html);
```

> [!NOTE]
> Pass <xref:Microsoft.AspNetCore.Components.ParameterView.Empty?displayProperty=nameWithType> to <xref:Microsoft.AspNetCore.Components.Web.HtmlRenderer.RenderComponentAsync%2A> when rendering the component without passing parameters.

Alternatively, you can write the HTML to a <xref:System.IO.TextWriter> by calling `output.WriteHtmlTo(textWriter)`.

The task returned by <xref:Microsoft.AspNetCore.Components.Web.HtmlRenderer.RenderComponentAsync%2A> completes when the component is fully rendered, including completing any asynchronous lifecycle methods. If you want to observe the rendered HTML earlier, call <xref:Microsoft.AspNetCore.Components.Web.HtmlRenderer.BeginRenderingComponent%2A> instead. Then, wait for the component rendering to complete by awaiting <xref:Microsoft.AspNetCore.Components.Web.HtmlRendering.HtmlRootComponent.QuiescenceTask%2A?displayProperty=nameWithType> on the returned <xref:Microsoft.AspNetCore.Components.Web.HtmlRendering.HtmlRootComponent> instance.
