---
title: ASP.NET Core Blazor CSS isolation
author: daveabrock
description: Learn how CSS isolation allows you to scope CSS to your components, which can simplify your CSS and avoid collisions with other components or libraries.
monikerRange: '= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/20/2020
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/css-isolation
---
# ASP.NET Core Blazor CSS isolation

By [Dave Brock](https://twitter.com/daveabrock)

CSS isolation simplifies an app's CSS footprint by preventing dependencies on global styles and helps to avoid styling conflicts among components and libraries.

## Enable CSS isolation 

To define component-specific styles, create a `.razor.css` file matching the name of the `.razor` file for the component in the same folder. The `.razor.css` file is a *scoped CSS file*. 

For an `Example` component in an `Example.razor` file, create a file alongside the component named `Example.razor.css`. The `Example.razor.css` file must reside in the same folder as the `Example` component (`Example.razor`). The "`Example`" base name of the file is **not** case-sensitive.

`Pages/Example.razor`:

```razor
@page "/example"

<h1>Scoped CSS Example</h1>
```

`Pages/Example.razor.css`:

```css
h1 { 
    color: brown;
    font-family: Tahoma, Geneva, Verdana, sans-serif;
}
```

**The styles defined in `Example.razor.css` are only applied to the rendered output of the `Example` component.** CSS isolation is applied to HTML elements in the matching Razor file. Any `h1` CSS declarations defined elsewhere in the app don't conflict with the `Example` component's styles.

> [!NOTE]
> In order to guarantee style isolation when bundling occurs, importing CSS in Razor code blocks isn't supported.

## CSS isolation bundling

CSS isolation occurs at build time. Blazor rewrites CSS selectors to match markup rendered by the component. The rewritten CSS styles are bundled and produced as a static asset. The stylesheet is referenced inside the `<head>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server). The following `<link>` element is added by default to an app created from the Blazor project templates, where the placeholder `{ASSEMBLY NAME}` is the project's assembly name:

```html
<link href="{ASSEMBLY NAME}.styles.css" rel="stylesheet">
```

The following example is from a hosted Blazor WebAssembly **`Client`** app. The app's assembly name is `BlazorSample.Client`, and the `<link>` is added by the Blazor WebAssembly project template when the project is created with the Hosted option (`-ho|--hosted` option using the .NET CLI or **ASP.NET Core hosted** checkbox using Visual Studio):

```html
<link href="BlazorSample.Client.styles.css" rel="stylesheet">
```

Within the bundled file, each component is associated with a scope identifier. For each styled component, an HTML attribute is appended with the format `b-<10-character-string>`. The identifier is unique and different for each app. In the rendered `Counter` component, Blazor appends a scope identifier to the `h1` element:

```html
<h1 b-3xxtam6d07>
```

The `{ASSEMBLY NAME}.styles.css` file uses the scope identifier to group a style declaration with its component. The following example provides the style for the preceding `<h1>` element:

```css
/* /Pages/Counter.razor.rz.scp.css */
h1[b-3xxtam6d07] {
    color: brown;
}
```

At build time, a project bundle is created with the convention `{STATIC WEB ASSETS BASE PATH}/Project.lib.scp.css`, where the placeholder `{STATIC WEB ASSETS BASE PATH}` is the static web assets base path.

If other projects are utilized, such as NuGet packages or [Razor class libraries](xref:blazor/components/class-libraries), the bundled file:

* References the styles using CSS imports.
* Isn't published as a static web asset of the app that consumes the styles.

## Child component support

By default, CSS isolation only applies to the component you associate with the format `{COMPONENT NAME}.razor.css`, where the placeholder `{COMPONENT NAME}` is usually the component name. To apply changes to a child component, use the `::deep` combinator to any descendant elements in the parent component's `.razor.css` file. The `::deep` combinator selects elements that are *descendants* of an element's generated scope identifier. 

The following example shows a parent component called `Parent` with a child component called `Child`.

`Pages/Parent.razor`:

```razor
@page "/parent"

<div>
    <h1>Parent component</h1>

    <Child />
</div>
```

`Shared/Child.razor`:

```razor
<h1>Child Component</h1>
```

Update the `h1` declaration in `Parent.razor.css` with the `::deep` combinator to signify the `h1` style declaration must apply to the parent component and its children.

`Pages/Parent.razor.css`:

```css
::deep h1 { 
    color: red;
}
```

The `h1` style now applies to the `Parent` and `Child` components without the need to create a separate scoped CSS file for the child component.

The `::deep` combinator only works with descendant elements. The following markup applies the `h1` styles to components as expected. The parent component's scope identifier is applied to the `div` element, so the browser knows to inherit styles from the parent component.

`Pages/Parent.razor`:

```razor
<div>
    <h1>Parent</h1>

    <Child />
</div>
```

However, excluding the `div` element removes the descendant relationship. In the following example, the style is **not** applied to the child component.

`Pages/Parent.razor`:

```razor
<h1>Parent</h1>

<Child />
```

## CSS preprocessor support

CSS preprocessors are useful for improving CSS development by utilizing features such as variables, nesting, modules, mixins, and inheritance. While CSS isolation doesn't natively support CSS preprocessors such as Sass or Less, integrating CSS preprocessors is seamless as long as preprocessor compilation occurs before Blazor rewrites the CSS selectors during the build process. Using Visual Studio for example, configure existing preprocessor compilation as a **Before Build** task in the Visual Studio Task Runner Explorer.

Many third-party NuGet packages, such as [Delegate.SassBuilder](https://www.nuget.org/packages/Delegate.SassBuilder), can compile SASS/SCSS files at the beginning of the build process before CSS isolation occurs, and no additional configuration is required.

## CSS isolation configuration

CSS isolation is designed to work out-of-the-box but provides configuration for some advanced scenarios, such as when there are dependencies on existing tools or workflows.

### Customize scope identifier format

By default, scope identifiers use the format `b-<10-character-string>`. To customize the scope identifier format, update the project file to a desired pattern:

```xml
<ItemGroup>
  <None Update="Pages/Example.razor.css" CssScope="my-custom-scope-identifier" />
</ItemGroup>
```

In the preceding example, the CSS generated for `Example.razor.css` changes its scope identifier from `b-<10-character-string>` to `my-custom-scope-identifier`.

Use scope identifiers to achieve inheritance with scoped CSS files. In the following project file example, a `BaseComponent.razor.css` file contains common styles across components. A `DerivedComponent.razor.css` file inherits these styles.

```xml
<ItemGroup>
  <None Update="Pages/BaseComponent.razor.css" CssScope="my-custom-scope-identifier" />
  <None Update="Pages/DerivedComponent.razor.css" CssScope="my-custom-scope-identifier" />
</ItemGroup>
```

Use the wildcard (`*`) operator to share scope identifiers across multiple files:

```xml
<ItemGroup>
  <None Update="Pages/*.razor.css" CssScope="my-custom-scope-identifier" />
</ItemGroup>
```

### Change base path for static web assets

The `scoped.styles.css` file is generated at the root of the app. In the project file, use the `StaticWebAssetBasePath` property to change the default path. The following example places the `scoped.styles.css` file, and the rest of the app's assets, at the `_content` path:

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>_content/$(PackageId)</StaticWebAssetBasePath>
</PropertyGroup>
```

### Disable automatic bundling

To opt out of how Blazor publishes and loads scoped files at runtime, use the `DisableScopedCssBundling` property. When using this property, it means other tools or processes are responsible for taking the isolated CSS files from the `obj` directory and publishing and loading them at runtime:

```xml
<PropertyGroup>
  <DisableScopedCssBundling>true</DisableScopedCssBundling>
</PropertyGroup>
```

## Razor class library (RCL) support

When a [Razor class library (RCL)](xref:razor-pages/ui-class) provides isolated styles, the `<link>` tag's `href` attribute points to `{STATIC WEB ASSET BASE PATH}/{ASSEMBLY NAME}.bundle.scp.css`, where the placeholders are:

* `{STATIC WEB ASSET BASE PATH}`: The static web asset base path.
* `{ASSEMBLY NAME}`: The class library's assembly name.

In the following example:

* The static web asset base path is `_content/ClassLib`.
* The class library's assembly name is `ClassLib`.

`wwwroot/index.html` (Blazor WebAssembly) or `Pages_Host.cshtml` (Blazor Server):

```html
<link href="_content/ClassLib/ClassLib.bundle.scp.css" rel="stylesheet">
```

For more information on RCLs and Razor class libraries, see the following articles:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>
