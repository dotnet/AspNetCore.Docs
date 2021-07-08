---
title: Lazy load assemblies in ASP.NET Core Blazor WebAssembly
author: guardrex
description: Discover how to lazy load assemblies in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/08/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/webassembly-lazy-load-assemblies
---
# Lazy load assemblies in ASP.NET Core Blazor WebAssembly

Blazor WebAssembly app startup performance can be improved by deferring the loading of some app assemblies until they're required, which is called *lazy loading*.

The [Complete example](#complete-example) section at the end of this article provides a working example.

> [!NOTE]
> Assembly lazy loading doesn't benefit Blazor Server apps because Blazor Server app assemblies aren't downloaded to the client.

## Project file

Mark assemblies for lazy loading in the app's project file (`.csproj`) using the `BlazorWebAssemblyLazyLoad` item. Use the assembly name with the `.dll` extension. The Blazor framework prevents the assembly from loading at app launch.

```xml
<ItemGroup>
  <BlazorWebAssemblyLazyLoad Include="{ASSEMBLY NAME}.dll" />
</ItemGroup>
```

The `{ASSEMBLY NAME}` placeholder is the name of the assembly. The `.dll` file extension is required.

Include one `BlazorWebAssemblyLazyLoad` item for each assembly. If an assembly has dependencies, they must also be marked for lazy loading.

## `Router` component

Blazor's <xref:Microsoft.AspNetCore.Components.Routing.Router> component designates the assemblies that Blazor searches for routable components. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component is also responsible for rendering the component for the route where the user navigates. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component supports an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> feature that can be used in conjunction with lazy loading.

In the app's <xref:Microsoft.AspNetCore.Components.Routing.Router> component, which appears in the `App.razor` file:

* Add an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> handler is invoked when the user:
  * Visits a route for the first time by navigating to it directly in their browser.
  * Navigates to a new route using a link or a <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> invocation.
* If lazy-loaded assemblies contain routable components, add a [List](xref:System.Collections.Generic.List%601)\<<xref:System.Reflection.Assembly>> (for example, named `lazyLoadedAssemblies`) to the component. The assemblies are passed back to the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> collection in case the assemblies contain routable components. The framework searches the assemblies for routes and updates the route collection if new routes are found.

The following example is for lazy loaded assemblies that may contain routable components.

At the top of the `App` component (`App.razor`) file, add the namespace for <xref:System.Reflection?displayProperty=fullName> to access the <xref:System.Reflection.Assembly> type:

```razor
@using System.Reflection
```

In the `App` component (`App.razor`):

```razor
<Router AppAssembly="@typeof(Program).Assembly" 
    AdditionalAssemblies="@lazyLoadedAssemblies" 
    OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private List<Assembly> lazyLoadedAssemblies = new();

    private async Task OnNavigateAsync(NavigationContext args)
    {
        ...
    }
}
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

For more information on <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync>, see <xref:blazor/fundamentals/routing#handle-asynchronous-navigation-events-with-onnavigateasync>.

## Assembly load logic in `OnNavigateAsync`

<xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> has a <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> parameter that provides information about the current asynchronous navigation event, including the target path (<xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.Path>) and the cancellation token (<xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken>):

* The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.Path> property is the user's destination path relative to the app's base path.
* The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken> can be used to observe the cancellation of the asynchronous task. <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> automatically cancels the currently running navigation task when the user navigates to a different page.

Inside <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync>, implement logic to determine the assemblies to load. Options include:

* Conditional checks inside the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> method.
* A lookup table that maps routes to assembly names, either injected into the component or implemented within the [`@code`](xref:mvc/views/razor#code) block.

<xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> is a framework-provided singleton service for loading assemblies.

At the top of the `App` component (`App.razor`) file:

* Add the namespace for <xref:Microsoft.AspNetCore.Components.WebAssembly.Services?displayProperty=fullName>.
* Inject the <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> service.

```razor
@using Microsoft.AspNetCore.Components.WebAssembly.Services
@inject LazyAssemblyLoader AssemblyLoader
```

The <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> provides the <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader.LoadAssembliesAsync%2A> method that:

* Uses [JS interop](xref:blazor/js-interop/call-dotnet-from-javascript) to fetch assemblies via a network call.
* Loads assemblies into the runtime executing on WebAssembly in the browser.

```csharp
await AssemblyLoader.LoadAssembliesAsync(new[] { "{LIST OF ASSEMBLIES}" });
```

The `{LIST OF ASSEMBLIES}` placeholder is the comma-separated list of assembly filenames, including their `.dll` extensions.

If the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback throws an unhandled exception, the [Blazor error UI](xref:blazor/fundamentals/handle-errors#detailed-errors-during-development) is invoked.

## Lazy load assemblies in a hosted Blazor WebAssembly solution

The framework's lazy loading implementation supports lazy loading with prerendering in a hosted Blazor WebAssembly solution. During prerendering, all assemblies, including those marked for lazy loading, are assumed to be loaded. Manually register the <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> service in the **`Server`** project.

At the top of the `Startup.cs` file of the **`Server`** project, add the namespace for <xref:Microsoft.AspNetCore.Components.WebAssembly.Services?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Services;
```

In the `Startup.ConfigureServices` method (`Startup.cs`) of the **`Server`** project, register the service:

```csharp
services.AddScoped<LazyAssemblyLoader>();
```

## User interaction with `<Navigating>` content

While loading assemblies, which can take several seconds, the <xref:Microsoft.AspNetCore.Components.Routing.Router> component can indicate to the user that a page transition is occurring with the router's <xref:Microsoft.AspNetCore.Components.Routing.Router.Navigating> property.

For more information, see <xref:blazor/fundamentals/routing#user-interaction-with-navigating-content>.

## Handle cancellations in `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> object passed to the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback contains a <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken> that's set when a new navigation event occurs. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback must throw when this cancellation token is set to avoid continuing to run the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback on a outdated navigation.

For more information, see <xref:blazor/fundamentals/routing#handle-cancellations-in-onnavigateasync>.

## `OnNavigateAsync` events and renamed assembly files

The resource loader relies on the assembly names that are defined in the `blazor.boot.json` file. If [assemblies are renamed](xref:blazor/host-and-deploy/webassembly#change-the-filename-extension-of-dll-files), the assembly names used in an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback and the assembly names in the `blazor.boot.json` file are out of sync.

To rectify this:

* Check to see if the app is running in the `Production` environment when determining which assembly names to use.
* Store the renamed assembly names in a separate file and read from that file to determine what assembly name to use in the <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> service and <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback methods.

## Complete example

The demonstration in this section:

* Creates a robot controls assembly (`GrantImaharaRobotControls.dll`) as a [Razor class library (RCL)](xref:blazor/components/class-libraries) that includes a `Robot` component (`Robot.razor` with a route template of `/robot`).
* Lazily loads the RCL's assembly in a Blazor WebAssembly app to render its `Robot` component when the `/robot` URL is requested by the user.

1. Create a new ASP.NET Core class library project:

   * Visual Studio: **Create a solution** > **Create a new project** > **Razor Class Library**. Name the project `GrantImaharaRobotControls`.
   * Visual Studio Code/.NET CLI: Execute `dotnet new razorclasslib -o GrantImaharaRobotControls` from a command prompt. The `-o|--output` option creates a folder for the solution and names the project `GrantImaharaRobotControls`.

1. The example component presented later in this section uses a [Blazor form](xref:blazor/forms-validation). Add a package reference to the RCL project for [`Microsoft.AspNetCore.Components.Forms`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Forms):

   ```xml
   <PackageReference Include="Microsoft.AspNetCore.Components.Forms" Version="{VERSION}" />
   ```

   The `{VERSION}` placeholder is the version of the package.

1. Create a `HandGesture` class in the RCL with a `ThumbUp` method that hypothetically makes a robot perform a thumbs-up gesture. The method accepts an argument for the axis, `Left` or `Right`, as an [`enum`](/dotnet/csharp/language-reference/builtin-types/enum). The method returns `true` on success.

   `HandGesture.cs`:

   ```csharp
   using Microsoft.Extensions.Logging;

   namespace GrantImaharaRobotControls
   {
       public static class HandGesture
       {
           public static bool ThumbUp(Axis axis, ILogger logger)
           {
               logger.LogInformation("Thumb up gesture. Axis: {Axis}", axis);

               // Code to make robot perform gesture

               return true;
           }
       }

       public enum Axis { Left, Right }
   }
   ```

1. Add the following component to the root of the RCL project. The component permits the user to submit a left or right hand thumb-up gesture request.

   `Robot.razor`:

   ```razor
   @page "/robot"
   @using Microsoft.AspNetCore.Components.Forms
   @using Microsoft.Extensions.Logging
   @inject ILogger<Robot> Logger

   <h1>Robot</h1>

   <EditForm Model="@robotModel" OnValidSubmit="@HandleValidSubmit">
       <InputRadioGroup @bind-Value="robotModel.AxisSelection">
           @foreach (var entry in (Axis[])Enum
               .GetValues(typeof(Axis)))
           {
               <InputRadio Value="entry" />
               <text>&nbsp;</text>@entry<br>
           }
       </InputRadioGroup>

       <button type="submit">Submit</button>
   </EditForm>

   <p>
       @message
   </p>

   @code {
       private RobotModel robotModel = new() { AxisSelection = Axis.Left };
       private string message;

       private void HandleValidSubmit()
       {
           Logger.LogInformation("HandleValidSubmit called");

           var result = HandGesture.ThumbUp(robotModel.AxisSelection, Logger);

           message = $"ThumbUp returned {result} at {DateTime.Now}.";
       }

       public class RobotModel
       {
           public Axis AxisSelection { get; set; }
       }
   }
   ```

Create a Blazor WebAssembly app to demonstrate lazy loading of the RCL's assembly:

1. Create the Blazor WebAssembly app in Visual Studio, Visual Studio Code, or via a command prompt with the .NET CLI. Name the project `LazyLoadTest`.

1. Create a project reference for the `GrantImaharaRobotControls` RCL:

   * Visual Studio: Add the `GrantImaharaRobotControls` RCL project to the solution (**Add** > **Existing Project**). Select **Add** > **Project Reference** to add a project reference for the `GrantImaharaRobotControls` RCL.
   * Visual Studio Code/.NET CLI: Execute `dotnet add reference {PATH}` in a command shell from the project's folder. The `{PATH}` placeholder is the path to the RCL project.

Build and run the app. For the default page that loads the `Index` component (`Pages/Index.razor`), the developer tool's Network tab indicates that the RCL's assembly `GrantImaharaRobotControls.dll` is loaded. The `Index` component makes no use of the assembly, so loading the assembly is inefficient. In the upcoming steps, the app is configured to lazily load the assembly only for the `Robot` component.

![Index component loaded in the browser with developer tool's Network tab indicating that the GrantImaharaRobotControls.dll assembly is loaded.](webassembly-lazy-load-assemblies/_static/screenshot1.png)

Configure the app to lazy load the `GrantImaharaRobotControls.dll` assembly:

1. Specify the RCL's assembly for lazy loading in the Blazor WebAssembly app's project file (`.csproj`):

   ```xml
   <ItemGroup>
     <BlazorWebAssemblyLazyLoad Include="GrantImaharaRobotControls.dll" />
   </ItemGroup>
   ```

1. The following <xref:Microsoft.AspNetCore.Components.Routing.Router> component demonstrates loading the `GrantImaharaRobotControls.dll` assembly when the user navigates to `/robot`. During page transitions, a styled message is displayed to the user.

   The following example also provides the list of additional assemblies to load to the `AdditionalAssemblies` parameter of the `Router` component, which results in the router searching the assemblies for routable components in those assemblies. For more information, see <xref:blazor/fundamentals/routing#route-to-components-from-multiple-assemblies>.

   `App.razor`:

   ```razor
   @using System.Reflection
   @using Microsoft.AspNetCore.Components.Routing
   @using Microsoft.AspNetCore.Components.WebAssembly.Services
   @using Microsoft.Extensions.Logging
   @inject LazyAssemblyLoader AssemblyLoader
   @inject ILogger<App> Logger

   <Router AppAssembly="@typeof(Program).Assembly"
           AdditionalAssemblies="@lazyLoadedAssemblies" 
           OnNavigateAsync="@OnNavigateAsync">
       <Navigating>
           <div style="padding:20px;background-color:blue;color:white">
               <p>Loading the requested page&hellip;</p>
           </div>
       </Navigating>
       <Found Context="routeData">
           <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
       </Found>
       <NotFound>
           <LayoutView Layout="@typeof(MainLayout)">
               <p>Sorry, there's nothing at this address.</p>
           </LayoutView>
       </NotFound>
   </Router>

   @code {
       private List<Assembly> lazyLoadedAssemblies = new();

       private async Task OnNavigateAsync(NavigationContext args)
       {
           try
           {
               if (args.Path == "/robot")
               {
                   var assemblies = await AssemblyLoader.LoadAssembliesAsync(
                       new[] { "GrantImaharaRobotControls.dll" });
                   lazyLoadedAssemblies.AddRange(assemblies);
               }
           }
           catch (Exception ex)
           {
               Logger.LogError("Error: {Message}", ex.Message);
           }
       }
   }
   ```

   [!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

Build and run the app again. For the default page that loads the `Index` component (`Pages/Index.razor`), the developer tool's Network tab indicates that the RCL's assembly (`GrantImaharaRobotControls.dll`) does **not** load for the `Index` component:

![Index component loaded in the browser with developer tool's Network tab indicating that the GrantImaharaRobotControls.dll assembly isn't loaded.](webassembly-lazy-load-assemblies/_static/screenshot2.png)

If the `Robot` component from the RCL is requested at `https://localhost:5001/robot`, the `GrantImaharaRobotControls.dll` assembly is loaded and the `Robot` component is rendered:

![Robot component loaded in the browser with developer tool's Network tab indicating that the GrantImaharaRobotControls.dll assembly is loaded.](webassembly-lazy-load-assemblies/_static/screenshot3.png)

## Troubleshoot

* If unexpected rendering occurs, such as rendering a component from a previous navigation, confirm that the code throws if the cancellation token is set.
* If assemblies configured for lazy loading unexpectedly load at app start, check that the assembly is marked for lazy loading in the project file.

> [!NOTE]
> A known issue exists for loading types from a lazily-loaded assembly. For more information, see [Blazor WebAssembly lazy loading assemblies not working when using @ref attribute in the component (dotnet/aspnetcore #29342)](https://github.com/dotnet/aspnetcore/issues/29342).

## Additional resources

* <xref:blazor/webassembly-performance-best-practices>
