---
title: ASP.NET Core Blazor CSS isolation
author: daveabrock
description: Learn how CSS isolation allows you to scope CSS to your components, which can simplify your CSS and avoid collisions with other components or libraries.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/20/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/css-isolation
---
# ASP.NET Core Blazor CSS isolation

By [Dave Brock](https://twitter.com/daveabrock)

CSS isolation simplifies an app's CSS footprint by preventing dependencies on global styles and helps to avoid styling conflicts among components and libraries.

## Enable CSS isolation 

To define component-specific styles, create a `razor.css` file matching the name of the `.razor` file for the component. This `razor.css` file is a *scoped CSS file*. 

For a `MyComponent` component that has a `MyComponent.razor` file, create a file alongside the component called `MyComponent.razor.css`. The `MyComponent` value in the `razor.css` filename is **not** case-sensitive.

For example to add CSS isolation to the `Counter` component in the default Blazor project template, add a new file named `Counter.razor.css` alongside the `Counter.razor` file, then add the following CSS:

```css
h1 { 
    color: brown;
    font-family: Tahoma, Geneva, Verdana, sans-serif;
}
```

The styles defined in `Counter.razor.css` are only applied to the rendered output of the `Counter` component. Any `h1` CSS declarations defined elsewhere in the app don't conflict with `Counter` styles.

> [!NOTE]
> In order to guarantee style isolation when bundling occurs, `@import` Razor blocks aren't supported with scoped CSS files.

## CSS isolation bundling

CSS isolation occurs at build time. During this process, Blazor rewrites CSS selectors to match markup rendered by the component. These rewritten CSS styles are bundled and produced as a static asset at `{PROJECT NAME}.styles.css`, where the placeholder `{PROJECT NAME}` is the referenced package or product name.

These static files are referenced from the root path of the app by default. In the app, reference the bundled file by inspecting the reference inside the `<head>` tag of the generated HTML:

```html
<link href="MyProjectName.styles.css" rel="stylesheet">
```

Within the bundled file, each component is associated with a scope identifier. For each styled component, an HTML attribute is appended with the format `b-<10-character-string>`. The identifier is unique and different for each app. In the rendered `Counter` component, Blazor appends a scope identifier to the `h1` element:

```html
<h1 b-3xxtam6d07>
```

The `MyProjectName.styles.css` file uses the scope identifier to group a style declaration with its component. The following example provides the style for the preceding `<h1>` element:

```css
/* /Pages/Counter.razor.rz.scp.css */
h1[b-3xxtam6d07] {
    color: brown;
}
```

At build time, a project bundle is created with the convention `{STATIC WEB ASSETS BASE PATH}/MyProject.lib.scp.css`, where the placeholder `{STATIC WEB ASSETS BASE PATH}` is the static web assets base path.

If other projects are utilized, such as NuGet packages or [Razor class libraries](xref:blazor/components/class-libraries), the bundled file:

* References the styles using CSS imports.
* Isn't published as a static web asset of the app that consumes the styles.

## Child component support

By default, CSS isolation only applies to the component you associate with the format `{COMPONENT NAME}.razor.css`, where the placeholder `{COMPONENT NAME}` is usually the component name. To apply changes to a child component, use the `::deep` combinator to any descendant elements in the parent component's `razor.css` file. The `::deep` combinator selects elements that are *descendants* of an element's generated scope identifier. 

The following example shows a parent component called `Parent` with a child component called `Child`.

`Parent.razor`:

```razor
@page "/parent"

<div>
    <h1>Parent component</h1>

    <Child />
</div>
```

`Child.razor`:

```razor
<h1>Child Component</h1>
```

Update the `h1` declaration in `Parent.razor.css` with the `::deep` combinator to signify the `h1` style declaration must apply to the parent component and its children:

```css
::deep h1 { 
    color: red;
}
```

The `h1` style now applies to the `Parent` and `Child` components without the need to create a separate scoped CSS file for the child component.

> [!NOTE]
> The `::deep` combinator only works with descendant elements. The following HTML structure applies the `h1` styles to components as expected:
> 
> ```razor
> <div>
>     <h1>Parent</h1>
>
>     <Child />
> </div>
> ```
>
> In this scenario, ASP.NET Core applies the parent component's scope identifier to the `div` element, so the browser knows to inherit styles from the parent component.
>
> However, excluding the `div` element removes the descendant relationship, and the style is **not** applied to the child component:
>
> ```razor
> <h1>Parent</h1>
>
> <Child />
> ```

## CSS preprocessor support

CSS preprocessors are useful for improving CSS development by utilizing features such as variables, nesting, modules, mixins, and inheritance. While CSS isolation doesn't natively support CSS preprocessors such as Sass or Less, integrating CSS preprocessors is seamless as long as preprocessor compilation occurs before Blazor rewrites the CSS selectors during the build process. Using Visual Studio for example, configure existing preprocessor compilation as a **Before Build** task in the Visual Studio Task Runner Explorer.

Many third-party NuGet packages, such as [Delegate.SassBuilder](https://www.nuget.org/packages/Delegate.SassBuilder), can compile SASS/SCSS files at the beginning of the build process before CSS isolation occurs, and no additional additional configuration is required.

## CSS isolation configuration

CSS isolation is designed to work out-of-the-box but provides configuration for some advanced scenarios, such as when there are dependencies on existing tools or workflows.

### Customize scope identifier format

By default, scope identifiers use the format `b-<10-character-string>`. To customize the scope identifier format, update the project file to a desired pattern:

```xml
<ItemGroup>
    <None Update="MyComponent.razor.css" CssScope="my-custom-scope-identifier" />
</ItemGroup>
```

In the preceding example, the CSS generated for `MyComponent.Razor.css` changes its scope identifier from `b-<10-character-string>` to `my-custom-scope-identifier`.

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
