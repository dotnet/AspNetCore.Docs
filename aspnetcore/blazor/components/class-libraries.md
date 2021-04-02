---
title: Consume ASP.NET Core Razor components from Razor class libraries
author: guardrex
description: Discover how components can be included in Blazor apps from an external component library.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/01/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/class-libraries
---
# Consume ASP.NET Core Razor components from Razor class libraries

Components can be shared in a [Razor class library (RCL)](xref:razor-pages/ui-class) across projects. An RCL can be included from:

* Another project in the solution.
* A NuGet package.
* A referenced .NET library.

Just as components are regular .NET types, components provided by an RCL are normal .NET assemblies.

## Create a Razor class library (RCL)

# [Visual Studio](#tab/visual-studio)

1. Create a new project.
1. Select **Razor Class Library**. Select **Next**.
1. In the **Create a new Razor class library** dialog, select **Create**.
1. Provide a project name in the **Project name** field or accept the default project name. The examples in this topic use the project name `ComponentLibrary`. Select **Create**.
1. Add the RCL to a solution:
   1. Right-click the solution. Select **Add** > **Existing Project**.
   1. Navigate to the RCL's project file.
   1. Select the RCL's project file (`.csproj`).
1. Add a reference to the RCL from the app:
   1. Right-click the app project. Select **Add** > **Reference**.
   1. Select the RCL project. Select **OK**.

> [!NOTE]
> If the **Support pages and views** check box is selected when generating the RCL from the template, then also add an `_Imports.razor` file to root of the generated project with the following contents to enable Razor component authoring:
>
> ```razor
> @using Microsoft.AspNetCore.Components.Web
> ```
>
> Manually add the file the root of the generated project.

# [.NET Core CLI](#tab/netcore-cli)

1. Use the **Razor Class Library** project template (`razorclasslib`) with the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in a command shell. In the following example, an RCL is created and named `ComponentLibrary` using the `-o|--output` option. The folder that holds `ComponentLibrary` is created automatically when the command is executed:

   ```dotnetcli
   dotnet new razorclasslib -o ComponentLibrary
   ```

   > [!NOTE]
   > If the `-s|--support-pages-and-views` option is used when generating the RCL from the template, then also add an `_Imports.razor` file to root of the generated project with the following contents to enable Razor component authoring:
   >
   > ```razor
   > @using Microsoft.AspNetCore.Components.Web
   > ```
   >
   > Manually add the file the root of the generated RCL project.

1. To add the library to an existing project, use the [`dotnet add reference`](/dotnet/core/tools/dotnet-add-reference) command in a command shell. In the following example, the RCL is added to the app. Execute the following command from the app's project folder. The `{PATH TO LIBRARY}` placeholder is the path to the library:

   ```dotnetcli
   dotnet add reference {PATH TO LIBRARY}
   ```

---

## Consume a Razor component from a Razor class library

In order to consume components defined in a Razor class library (RCL) in another project, use either of the following approaches:

* Use the full type name with the RCL's namespace.
* Use Razor's [`@using`](xref:mvc/views/razor#using) directive. Individual components can be added by name.

In the following examples, `ComponentLibrary` is a component library containing the `Component1` component (`Component1.razor`). The `Component1` component is an example component automatically added to an RCL created from the RCL project template.

You can reference the `Component1` component using its namespace, as the following example shows.

`Pages/ConsumeComponent1.razor`:

```razor
@page "/consume-component-1"

<h1>Consume component (full namespace example)</h1>

<ComponentLibrary.Component1 />
```

Alternatively, add a [`@using`](xref:mvc/views/razor#using) directive and use the component without its namespace.

`Pages/ConsumeComponent2.razor`:

```razor
@page "/consume-component-2"
@using ComponentLibrary

<h1>Consume component (<code>@using</code> example)</h1>

<Component1 />
```

Optionally, include the `@using ComponentLibrary` directive in the top-level `_Import.razor` file to make the library's components available to an entire project. Add the directive to an `_Import.razor` file at any level to apply the namespace to a single component or set of components within a folder. When this approach is adopted, individual components don't require an `@using` directive for the RCL's namespace.

::: moniker range=">= aspnetcore-5.0"

For library components that use [CSS isolation](xref:blazor/components/css-isolation), the component styles are automatically made available to the consuming app. There's no need to link the library's individual component stylesheets in the app that consumes the library.

::: moniker-end

::: moniker range=">= aspnetcore-6.0"

To provide additional library component styles from stylesheets in the library's `wwwroot` folder, link the stylesheets using the framework's `Link` component in `Component1.razor`:

```razor
<div class="extra-style">
    <Link href="_content/ComponentLibrary/additionalStyles.css" rel="stylesheet" />

    <p>
        This Blazor component is defined in the <strong>ComponentLibrary</strong> package.
    </p>
</div>
```

When the `Link` component is used in a child component, the linked asset is also available to any other child component of the parent component if the child with the `Link` component is rendered. The distinction between using the `Link` component in a child component and placing a `<link>` HTML tag in `wwwroot/index.html` or `Pages/_Host.cshtml` is that a framework component's rendered HTML tag:

* Can be modified by application state. A hard-coded `<link>` HTML tag can't be modified by application state.
* Is removed from the HTML `<head>` when the parent component is no longer rendered.

::: moniker-end

::: moniker range="< aspnetcore-6.0"

To provide `Component1`'s `my-component` CSS class, link to the library's stylesheet in the `<head>` element's markup.

`wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server):

```diff
+ <link href="_content/ComponentLibrary/styles.css" rel="stylesheet" />
```

::: moniker-end

To provide additional component styles from stylesheets in the library's `wwwroot` folder, link the stylesheets in the consuming app's `<head>` element markup.

`wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server):

```diff
+ <link href="_content/ComponentLibrary/additionalStyles.css" rel="stylesheet" />
```

## Create a Razor class library with Razor components and static assets

The static assets are available to any app that consumes the Razor class  (RCL).

Place the static asset in the `wwwroot` folder of the RCL and reference the static asset with the following path: `_content/{LIBRARY NAME}/{ASSET FILE NAME}`. The `{LIBRARY NAME}` placeholder is the library name. The `{ASSET FILE NAME}` placeholder is the asset's file name.

::: moniker range=">= aspnetcore-6.0"

Components provided to a client app of a hosted Blazor WebAssembly solution by an RCL are referenced normally. If any components require stylesheets or JavaScript files, use either of the following approaches to obtain the static assets:

* The client app's `wwwroot/index.html` file can link (`<link>`) to the static assets.
* The component can use the framework's `Link` component to obtain the static assets.

The preceding approaches are demonstrated in the following examples.

::: moniker-end

::: moniker range="< aspnetcore-6.0"

Components provided to a client app of a hosted Blazor WebAssembly solution by an RCL are referenced normally. If any components require additional stylesheets or JavaScript files, the client app's `wwwroot/index.html` file must include the correct static asset links. These approaches are demonstrated in the following examples.

::: moniker-end

Add the following `Jeep` component to the app. The `Jeep` component uses:

* An image (`jeep-cj.png`) from the client app's `wwwroot` folder in a hosted Blazor WebAssembly app.
* An image (`jeep-yj.png`) from an RCL's (`JeepImage`) `wwwroot` folder.
* The example component (`Component1`) is created automatically by the RCL project template when the `JeepImage` library is added to the solution.

`Pages/Jeep.razor`:

```razor
@page "/jeep"

<h1>1979 Jeep CJ-5&trade;</h1>

<p>
    <img alt="1979 Jeep CJ-5&trade;" src="/jeep-cj.png" />
</p>

<h1>1991 Jeep YJ&trade;</h1>

<p>
    <img alt="1991 Jeep YJ&trade;" src="_content/JeepImage/jeep-yj.png" />
</p>

<p>
    <em>Jeep CJ-5</em> and <em>Jeep YJ</em> are a trademarks of 
    <a href="https://www.fcagroup.com">Fiat Chrysler Automobiles</a>.
</p>

<JeepImage.Component1 />
```

> [!WARNING]
> Do **not** publish images of vehicles publicly unless you own the images. Otherwise, you risk copyright infringement.

::: moniker range=">= aspnetcore-6.0"

The library's `jeep-yj.png` image can also be added to the library's `Component1` component. To provide the `my-component` CSS class to the client app's page, link to the library's stylesheet using the framework's `Link` component.

`Component1.razor`:

```razor
<div class="my-component">
    <Link href="_content/JeepImage/styles.css" rel="stylesheet" />

    <h1>JeepImage.Component1</h1>

    <p>
        This Blazor component is defined in the <strong>JeepImage</strong> package.
    </p>

    <p>
        <img alt="1991 Jeep YJ&trade;" src="_content/JeepImage/jeep-yj.png" />
    </p>
</div>
```

An alternative to using the `Link` component is to load the stylesheet from a `<link>` element of the `<head>` element. This approach makes the stylesheet available to all of the components in the client app:

`wwwroot/index.html` (Blazor WebAssembly):

```diff
+ <link href="_content/JeepImage/styles.css" rel="stylesheet" />
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

The library's `jeep-yj.png` image can also be added to the library's `Component1` component.

`Component1.razor`:

```razor
<div class="my-component">
    <h1>JeepImage.Component1</h1>

    <p>
        This Blazor component is defined in the <strong>JeepImage</strong> package.
    </p>

    <p>
        <img alt="1991 Jeep YJ&trade;" src="_content/JeepImage/jeep-yj.png" />
    </p>
</div>
```

The following `<link>` tag is added to the `<head>` element's markup.

`wwwroot/index.html` (Blazor WebAssembly):

```diff
+ <link href="_content/JeepImage/styles.css" rel="stylesheet" />
```

::: moniker-end

Add navigation to the `Jeep` component in the client app's `NavMenu` component.

`Shared/NavMenu.razor`:

```razor
<li class="nav-item px-3">
    <NavLink class="nav-link" href="Jeep">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Jeep
    </NavLink>
</li>
```

For more information, see <xref:razor-pages/ui-class#create-an-rcl-with-static-assets>.

## Supply components and static assets to multiple hosted Blazor apps

For more information, see <xref:blazor/host-and-deploy/webassembly#static-assets-and-class-libraries-for-multiple-blazor-webassembly-apps>.

::: moniker range=">= aspnetcore-5.0"

## Browser compatibility analyzer for Blazor WebAssembly

Blazor WebAssembly apps target the full .NET API surface area, but not all .NET APIs are supported on WebAssembly due to browser sandbox constraints. Unsupported APIs throw <xref:System.PlatformNotSupportedException> when running on WebAssembly. A platform compatibility analyzer warns the developer when the app uses APIs that aren't supported by the app's target platforms. For Blazor WebAssembly apps, this means checking that APIs are supported in browsers. Annotating .NET framework APIs for the compatibility analyzer is an on-going process, so not all .NET framework API is currently annotated.

Blazor WebAssembly and Razor class library projects *automatically* enable browser compatibilty checks by adding `browser` as a supported platform with the `SupportedPlatform` MSBuild item. Library developers can manually add the `SupportedPlatform` item to a library's project file to enable the feature:

```xml
<ItemGroup>
  <SupportedPlatform Include="browser" />
</ItemGroup>
```

When authoring a library, indicate that a particular API isn't supported in browsers by specifying `browser` to <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute>:

```csharp
[UnsupportedOSPlatform("browser")]
private static string GetLoggingDirectory()
{
    ...
}
```

For more information, see [Annotating APIs as unsupported on specific platforms (dotnet/designs GitHub repository](https://github.com/dotnet/designs/blob/main/accepted/2020/platform-exclusion/platform-exclusion.md#build-configuration-for-platforms).

## Blazor JavaScript isolation and object references

Blazor enables JavaScript isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules). JavaScript isolation provides the following benefits:

* Imported JavaScript no longer pollutes the global namespace.
* Consumers of the library and components aren't required to manually import the related JavaScript.

For more information, see <xref:blazor/call-javascript-from-dotnet#blazor-javascript-isolation-and-object-references>.

::: moniker-end

## Build, pack, and ship to NuGet

Because component libraries are standard .NET libraries, packaging and shipping them to NuGet is no different from packaging and shipping any library to NuGet. Packaging is performed using the [`dotnet pack`](/dotnet/core/tools/dotnet-pack) command in a command shell:

```dotnetcli
dotnet pack
```

Upload the package to NuGet using the [`dotnet nuget push`](/dotnet/core/tools/dotnet-nuget-push) command in a command shell.

## Additional resources

::: moniker range=">= aspnetcore-5.0"

* <xref:razor-pages/ui-class>
* [Add an XML Intermediate Language (IL) Trimmer configuration file to a library](xref:blazor/host-and-deploy/configure-trimmer)
* [CSS isolation support with Razor class libraries](xref:blazor/components/css-isolation#razor-class-library-rcl-support)

::: moniker-end

::: moniker range="< aspnetcore-5.0"

* <xref:razor-pages/ui-class>
* [Add an XML Intermediate Language (IL) Linker configuration file to a library](xref:blazor/host-and-deploy/configure-linker#add-an-xml-linker-configuration-file-to-a-library)

::: moniker-end
