---
title: Consume ASP.NET Core Razor components from a Razor class library (RCL)
author: guardrex
description: Discover how components can be included in Blazor apps from an external Razor class library (RCL).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/class-libraries
---
# Consume ASP.NET Core Razor components from a Razor class library (RCL)

[!INCLUDE[](~/includes/not-latest-version.md)]

Components can be shared in a [Razor class library (RCL)](xref:razor-pages/ui-class) across projects. Include components and static assets in an app from:

* Another project in the [solution](xref:blazor/tooling#visual-studio-solution-file-sln).
* A referenced .NET library.
* A NuGet package.

Just as components are regular .NET types, components provided by an RCL are normal .NET assemblies.

## Create an RCL

# [Visual Studio](#tab/visual-studio)

1. Create a new project.
1. In the **Create a new project** dialog, select **Razor Class Library** from the list of ASP.NET Core project templates. Select **Next**.
1. In the **Configure your new project** dialog, provide a project name in the **Project name** field or accept the default project name. Examples in this topic use the project name `ComponentLibrary`. Select **Create**.
1. In the **Create a new Razor class library** dialog, select **Create**.
1. Add the RCL to a solution:
   1. Open the solution.
   1. Right-click the solution in **Solution Explorer**. Select **Add** > **Existing Project**.
   1. Navigate to the RCL's project file.
   1. Select the RCL's project file (`.csproj`).
1. Add a reference to the RCL from the app:
   1. Right-click the app project. Select **Add** > **Project Reference**.
   1. Select the RCL project. Select **OK**.

:::moniker range=">= aspnetcore-5.0"

If the **Support pages and views** checkbox is selected to support pages and views when generating the RCL from the template:

* Add an `_Imports.razor` file to root of the generated RCL project with the following contents to enable Razor component authoring:

  ```razor
  @using Microsoft.AspNetCore.Components.Web
  ```

* Add the following `SupportedPlatform` item to the project file (`.csproj`):

  ```xml
  <ItemGroup>
    <SupportedPlatform Include="browser" />
  </ItemGroup>
  ```

  For more information on the `SupportedPlatform` item, see the [client-side browser compatibility analyzer](#client-side-browser-compatibility-analyzer) section.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

If the **Support pages and views** checkbox is selected to support pages and views when generating the RCL from the template, add an `_Imports.razor` file to root of the generated RCL project with the following contents to enable Razor component authoring:

```razor
@using Microsoft.AspNetCore.Components.Web
```

:::moniker-end

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

1. Use the **Razor Class Library** project template (`razorclasslib`) with the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in a command shell. In the following example, an RCL is created and named `ComponentLibrary` using the `-o|--output` option. The folder that holds `ComponentLibrary` is created automatically when the command is executed:

   ```dotnetcli
   dotnet new razorclasslib -o ComponentLibrary
   ```

1. To add the library to an existing project, use the [`dotnet add reference`](/dotnet/core/tools/dotnet-add-reference) command in a command shell. In the following command, the `{PATH TO LIBRARY}` placeholder is the path to the library's project folder:

   ```dotnetcli
   dotnet add reference {PATH TO LIBRARY}
   ```

:::moniker range=">= aspnetcore-5.0"

If the `-s|--support-pages-and-views` option is used to support pages and views when generating the RCL from the template:

* Add an `_Imports.razor` file to root of the generated RCL project with the following contents to enable Razor component authoring:

  ```razor
  @using Microsoft.AspNetCore.Components.Web
  ```

* Add the following `SupportedPlatform` item to the project file (`.csproj`):

  ```xml
  <ItemGroup>
    <SupportedPlatform Include="browser" />
  </ItemGroup>
  ```

  For more information on the `SupportedPlatform` item, see the [client-side browser compatibility analyzer](#client-side-browser-compatibility-analyzer) section.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

If the `-s|--support-pages-and-views` option is used to support pages and views when generating the RCL from the template, add an `_Imports.razor` file to root of the generated RCL project with the following contents to enable Razor component authoring:

```razor
@using Microsoft.AspNetCore.Components.Web
```

:::moniker-end

---

## Consume a Razor component from an RCL

To consume components from an RCL in another project, use either of the following approaches:

* Use the full component type name, which includes the RCL's namespace.
* Individual components can be added by name without the RCL's namespace if Razor's [`@using`](xref:mvc/views/razor#using) directive declares the RCL's namespace. Use the following approaches:
  * Add the `@using` directive to individual components.
  * include the `@using` directive in the top-level `_Imports.razor` file to make the library's components available to an entire project. Add the directive to an `_Imports.razor` file at any level to apply the namespace to a single component or set of components within a folder. When an `_Imports.razor` file is used, individual components don't require an `@using` directive for the RCL's namespace.

In the following examples, `ComponentLibrary` is an RCL containing the `Component1` component. The `Component1` component is an example component automatically added to an RCL created from the RCL project template that isn't created to support pages and views.

> [!NOTE]
> If the RCL is created to support pages and views, manually add the `Component1` component and its static assets to the RCL if you plan to follow the examples in this article. The component and static assets are shown in this section.

`Component1.razor` in the `ComponentLibrary` RCL:

```razor
<div class="my-component">
    This component is defined in the <strong>ComponentLibrary</strong> package.
</div>
```

In the app that consumes the RCL, reference the `Component1` component using its namespace, as the following example shows.

`ConsumeComponent1.razor`:

```razor
@page "/consume-component-1"

<h1>Consume component (full namespace example)</h1>

<ComponentLibrary.Component1 />
```

Alternatively, add a [`@using`](xref:mvc/views/razor#using) directive and use the component without its namespace. The following `@using` directive can also appear in any `_Imports.razor` file in or above the current folder.

`ConsumeComponent2.razor`:

```razor
@page "/consume-component-2"
@using ComponentLibrary

<h1>Consume component (<code>@@using</code> example)</h1>

<Component1 />
```

:::moniker range=">= aspnetcore-6.0"

For library components that use [CSS isolation](xref:blazor/components/css-isolation), the component styles are automatically made available to the consuming app. There's no need to manually link or import the library's individual component stylesheets or its bundled CSS file in the app that consumes the library. The app uses CSS imports to reference the RCL's bundled styles. The bundled styles aren't published as a static web asset of the app that consumes the library. For a class library named `ClassLib` and a Blazor app with a `BlazorSample.styles.css` stylesheet, the RCL's stylesheet is imported at the top of the app's stylesheet automatically at build time:
  
```css
@import '_content/ClassLib/ClassLib.bundle.scp.css';
```

For the preceding examples, `Component1`'s stylesheet (`Component1.razor.css`) is bundled automatically.

`Component1.razor.css` in the `ComponentLibrary` RCL:

```css
.my-component {
    border: 2px dashed red;
    padding: 1em;
    margin: 1em 0;
    background-image: url('background.png');
}
```

The background image is also included from the RCL project template and resides in the `wwwroot` folder of the RCL.

`wwwroot/background.png` in the `ComponentLibrary` RCL:

![Diagonally-striped background image from the RCL project template](~/blazor/components/class-libraries/_static/background.png)

To provide additional library component styles from stylesheets in the library's `wwwroot` folder, add stylesheet `<link>` tags to the RCL's consumer, as the next example demonstrates.

> [!IMPORTANT]
> Generally, library components use [CSS isolation](xref:blazor/components/css-isolation) to bundle and provide component styles. Component styles that rely upon CSS isolation are automatically made available to the app that uses the RCL. There's no need to manually link or import the library's individual component stylesheets or its bundled CSS file in the app that consumes the library. The following example is for providing global stylesheets *outside of CSS isolation*, which usually isn't a requirement for typical apps that consume RCLs.

The following background image is used in the next example. If you implement the example shown in this section, right-click the image to save it locally.

`wwwroot/extra-background.png` in the `ComponentLibrary` RCL:

![Diagonally-striped background image added to the library by the developer](~/blazor/components/class-libraries/_static/extra-background.png)

Add a new stylesheet to the RCL with an `extra-style` class.

`wwwroot/additionalStyles.css` in the `ComponentLibrary` RCL:

```css
.extra-style {
    border: 2px dashed blue;
    padding: 1em;
    margin: 1em 0;
    background-image: url('extra-background.png');
}
```

Add a component to the RCL that uses the `extra-style` class.

`ExtraStyles.razor` in the `ComponentLibrary` RCL:

```razor
<div class="extra-style">
    <p>
        This component is defined in the <strong>ComponentLibrary</strong> package.
    </p>
</div>
```

Add a page to the app that uses the `ExtraStyles` component from the RCL.

`ConsumeComponent3.razor`:

```razor
@page "/consume-component-3"
@using ComponentLibrary

<h1>Consume component (<code>additionalStyles.css</code> example)</h1>

<ExtraStyles />
```

Link to the library's stylesheet in the app's `<head>` markup ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)).

```html
<link href="_content/ComponentLibrary/additionalStyles.css" rel="stylesheet" />
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

For library components that use [CSS isolation](xref:blazor/components/css-isolation), the component styles are automatically made available to the consuming app. There's no need to manually link or import the library's individual component stylesheets or its bundled CSS file in the app that consumes the library. The app uses CSS imports to reference the RCL's bundled styles. The bundled styles aren't published as a static web asset of the app that consumes the library. For a class library named `ClassLib` and a Blazor app with a `BlazorSample.styles.css` stylesheet, the RCL's stylesheet is imported at the top of the app's stylesheet automatically at build time:
  
```css
@import '_content/ClassLib/ClassLib.bundle.scp.css';
```

For the preceding examples, `Component1`'s stylesheet (`Component1.razor.css`) is bundled automatically.

`Component1.razor.css` in the `ComponentLibrary` RCL:

```css
.my-component {
    border: 2px dashed red;
    padding: 1em;
    margin: 1em 0;
    background-image: url('background.png');
}
```

The background image is also included from the RCL project template and resides in the `wwwroot` folder of the RCL.

`wwwroot/background.png` in the `ComponentLibrary` RCL:

![Diagonally-striped background image from the RCL project template](~/blazor/components/class-libraries/_static/background.png)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

The following background image and stylesheet are used by the RCL's `Component1` example component. There's no need to add these static assets to a new RCL created from the RCL project template, as they're added automatically by the project template.

`wwwroot/background.png` in the `ComponentLibrary` RCL:

![Diagonally-striped background image added to the library by the RCL project template](~/blazor/components/class-libraries/_static/background.png)

`wwwroot/styles.css` in the `ComponentLibrary` RCL:

```css
.my-component {
    border: 2px dashed red;
    padding: 1em;
    margin: 1em 0;
    background-image: url('background.png');
}
```

To provide `Component1`'s `my-component` CSS class, link to the library's stylesheet in the app's `<head>` markup ([location of `<head>` content](xref:blazor/project-structure#location-of-head-and-body-content)):

```html
<link href="_content/ComponentLibrary/styles.css" rel="stylesheet" />
```

:::moniker-end

## Make routable components available from the RCL

To make routable components in the RCL available for direct requests, the RCL's assembly must be disclosed to the app's router.

Open the app's `App` component (`App.razor`). Assign an <xref:System.Reflection.Assembly> collection to the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies%2A> parameter of the <xref:Microsoft.AspNetCore.Components.Routing.Router> component to include the RCL's assembly. In the following example, the `ComponentLibrary.Component1` component is used to discover the RCL's assembly.

```razor
AdditionalAssemblies="new[] { typeof(ComponentLibrary.Component1).Assembly }"
```

For more information, see <xref:blazor/fundamentals/routing#route-to-components-from-multiple-assemblies>.

## Create an RCL with static assets in the `wwwroot` folder

An RCL's static assets are available to any app that consumes the library.

Place static assets in the `wwwroot` folder of the RCL and reference the static assets with the following path in the app: `_content/{PACKAGE ID}/{PATH AND FILE NAME}`. The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. The `{PATH AND FILE NAME}` placeholder is path and file name under `wwwroot`. This path format is also used in the app for static assets supplied by NuGet packages added to the RCL.

The following example demonstrates the use of RCL static assets with an RCL named `ComponentLibrary` and a Blazor app that consumes the RCL. The app has a project reference for the `ComponentLibrary` RCL.

The following Jeep&reg; image is used in this section's example. If you implement the example shown in this section, right-click the image to save it locally.

`wwwroot/jeep-yj.png` in the `ComponentLibrary` RCL:

![Jeep YJ&reg;](~/blazor/components/class-libraries/_static/jeep-yj.png)

Add the following `JeepYJ` component to the RCL.

`JeepYJ.razor` in the `ComponentLibrary` RCL:

```razor
<h3>ComponentLibrary.JeepYJ</h3>

<p>
    <img alt="Jeep YJ&reg;" src="_content/ComponentLibrary/jeep-yj.png" />
</p>
```

Add the following `Jeep` component to the app that consumes the `ComponentLibrary` RCL. The `Jeep` component uses:

* The Jeep YJ&reg; image from the `ComponentLibrary` RCL's `wwwroot` folder.
* The `JeepYJ` component from the RCL.

`Jeep.razor`:

```razor
@page "/jeep"
@using ComponentLibrary

<div style="float:left;margin-right:10px">
    <h3>Direct use</h3>

    <p>
        <img alt="Jeep YJ&reg;" src="_content/ComponentLibrary/jeep-yj.png" />
    </p>
</div>

<JeepYJ />

<p>
    <em>Jeep</em> and <em>Jeep YJ</em> are registered trademarks of 
    <a href="https://www.stellantis.com">FCA US LLC (Stellantis NV)</a>.
</p>
```

Rendered `Jeep` component:

![Jeep component](~/blazor/components/class-libraries/_static/jeep-component.png)

For more information, see <xref:razor-pages/ui-class#create-an-rcl-with-static-assets>.

:::moniker range=">= aspnetcore-6.0"

## Create an RCL with JavaScript files collocated with components

[!INCLUDE[](~/blazor/includes/js-interop/js-collocation.md)]

:::moniker-end

:::moniker range="< aspnetcore-8.0"

## Supply components and static assets to multiple hosted Blazor apps

For more information, see <xref:blazor/host-and-deploy/multiple-hosted-webassembly>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## Client-side browser compatibility analyzer

Client-side apps target the full .NET API surface area, but not all .NET APIs are supported on WebAssembly due to browser sandbox constraints. Unsupported APIs throw <xref:System.PlatformNotSupportedException> when running on WebAssembly. A platform compatibility analyzer warns the developer when the app uses APIs that aren't supported by the app's target platforms. For client-side apps, this means checking that APIs are supported in browsers. Annotating .NET framework APIs for the compatibility analyzer is an on-going process, so not all .NET framework API is currently annotated.

Blazor Web Apps that enable Interactive WebAssembly components, Blazor WebAssembly apps, and RCL projects *automatically* enable browser compatibility checks by adding `browser` as a supported platform with the `SupportedPlatform` MSBuild item. Library developers can manually add the `SupportedPlatform` item to a library's project file to enable the feature:

```xml
<ItemGroup>
  <SupportedPlatform Include="browser" />
</ItemGroup>
```

When authoring a library, indicate that a particular API isn't supported in browsers by specifying `browser` to <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute>:

```csharp
using System.Runtime.Versioning;

...

[UnsupportedOSPlatform("browser")]
private static string GetLoggingDirectory()
{
    ...
}
```

For more information, see [Annotating APIs as unsupported on specific platforms (dotnet/designs GitHub repository](https://github.com/dotnet/designs/blob/main/accepted/2020/platform-exclusion/platform-exclusion.md#build-configuration-for-platforms).

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules). JavaScript isolation provides the following benefits:

* Imported JavaScript no longer pollutes the global namespace.
* Consumers of the library and components aren't required to manually import the related JavaScript.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Avoid trimming JavaScript-invokable .NET methods

[Runtime relinking](xref:blazor/host-and-deploy/webassembly#runtime-relinking) trims class instance JavaScript-invokable .NET methods unless they're explicitly preserved. For more information, see <xref:blazor/js-interop/call-dotnet-from-javascript#avoid-trimming-javascript-invokable-net-methods>.

:::moniker-end

## Build, pack, and ship to NuGet

Because Razor class libraries that contain Razor components are standard .NET libraries, packing and shipping them to NuGet is no different from packing and shipping any library to NuGet. Packing is performed using the [`dotnet pack`](/dotnet/core/tools/dotnet-pack) command in a command shell:

```dotnetcli
dotnet pack
```

Upload the package to NuGet using the [`dotnet nuget push`](/dotnet/core/tools/dotnet-nuget-push) command in a command shell.

## Trademarks

*Jeep* and *Jeep YJ* are registered trademarks of [FCA US LLC (Stellantis NV)](https://www.stellantis.com).

## Additional resources

:::moniker range=">= aspnetcore-5.0"

* <xref:razor-pages/ui-class>
* <xref:fundamentals/target-aspnetcore>
* [Add an XML Intermediate Language (IL) Trimmer configuration file to a library](xref:blazor/host-and-deploy/configure-trimmer)
* [CSS isolation support with Razor class libraries](xref:blazor/components/css-isolation#razor-class-library-rcl-support)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

* <xref:razor-pages/ui-class>
* <xref:fundamentals/target-aspnetcore>
* [Add an XML Intermediate Language (IL) Linker configuration file to a library](xref:blazor/host-and-deploy/configure-linker#add-an-xml-linker-configuration-file-to-a-library)

:::moniker-end
