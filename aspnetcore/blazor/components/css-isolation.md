---
title: ASP.NET Core Blazor CSS isolation
author: daveabrock
description: Learn how CSS isolation allows you to scope CSS to your components, which can simplify your CSS and avoid collisions with other components or libraries.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/17/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/css-isolation
---
# ASP.NET Core Blazor CSS isolation

By [Dave Brock](https://twitter.com/daveabrock)

Use cascading style sheets (CSS) isolation to only apply styles to the current component. CSS isolation simplifies an app's CSS footprint by preventing dependencies on global styles, and also helps to avoid styling conflicts between other components or libraries.

## Enable CSS isolation 

To define component-specific styles, create a `razor.css` file matching the name of the `.razor` file for the component. This `razor.css` file is a *scoped CSS file*. 

For a `MyComponent` that has a `MyComponent.razor` file, create a file in the `Pages` folder called `MyComponent.razor.css`. The `MyComponent` value in the `razor.css` filename is **not** case-sensitive.

For example, to add CSS isolation to the `Counter` component in the sample app, add a new file named `Counter.razor.css`, then add the following CSS:

```css
h1 { 
    color: brown;
    font-family: Tahoma, Geneva, Verdana, sans-serif;
}
```

The styles defined in `Counter.razor.css` are only applied to the rendered output of the `Counter` component. Any `h1` CSS declarations defined elsewhere do not conflict with `Counter` styles.

> [!NOTE]
> In order to guarantee style isolation when bundling occurs, `@import` blocks are not supported with scoped CSS files.

## CSS isolation bundling

CSS isolation occurs at build time. During this process, Blazor rewrites CSS selectors to only match markup rendered by the component. These rewritten CSS styles are bundled together and produced as a static web asset at `_framework/scoped.styles.css`.

In the app, reference the bundled file by inspecting the reference inside the `<head>` tag of the generated HTML:

```html
<link href="_framework/scoped.styles.css" rel="stylesheet">
```

The bundle associates each component with a scope identifier. For each styled component, an HTML attribute is appended with the format `b-<10-character-string>`. For example, in the rendered `Counter` component, Blazor appends a scope identifier to the `h1` (the identifier is unique and different for each app):

```html
<h1 b-3xxtam6d07>
```

The `scoped.styles.css` file uses the scope identifier to group a style declaration with its component.

```css
/* /Pages/Counter.razor.rz.scp.css */
h1[b-3xxtam6d07] {
    color: brown;
}
```

Additionally, at build time a project bundle is created with the convention `StaticWebAssetsBasePath/MyProject.lib.scp.css`. This is referenced when projects are used for NuGet packages or a Razor Class Library, which both support CSS isolation. This `lib.scp.css` file is not published as a static web asset.

## Child component support

By default, CSS isolation only applies to the component you associate with `MyComponent.razor.css`. To apply changes to a child component, use the `::deep` combinator to any descendant elements in the parent component's `razor.css` file. The `::deep` combinator selects elements that are *descendants* of an element's generated scope identifier. 

The following example shows a parent component, called `ChildExample` in a file called `Pages/ChildExample.razor`, with a child component called `MyChild`:

`ChildExample.razor`:
```razor
@page "/child-example"

<div>
    <h1>Child Example</h1>
    <MyChild />
</div>
```

`MyChild.razor`:
```razor
@page "/first-child"

<h1>A Child Component</h1>
```

Update the `h1` declaration in `MyComponent.razor.css` with the `::deep` combinator to signify the `h1` style declaration must apply to the parent component and its children.

```css
::deep h1 { 
    color: red;
}
```

The `h1` style now applies to the `ChildExample` and `FirstChild` components without the need to create separate scoped CSS files for the child components.

> [!NOTE]
> The `::deep` combinator works only with descendant elements. The following HTML structure applies the `h2` styles to components as expected:
> 
>```razor
><div>
>    <h1>Child Example</h1>
>    <MyChild />
></div>
>```
> In this scenario, ASP.NET Core applies the parent component's scope identifier to the `div` element, so it knows to inherit styles from the parent component.
>
>However, excluding the `div` element removes the descendant relationship, and the style will *not* be applied to the child component. 
>
>```razor
><h1>Child Example</h1>
><MyChild />
>```

## CSS preprocessor support

CSS preprocessors are useful with improving CSS development by utilizing features like variables, nesting, modules, mixins, and inheritance. While CSS isolation does not *natively* support CSS preprocessors such as Sass or Less, integrating them is seamless as long as preprocessor compilation occurs before Blazor rewrites the CSS selectors during the build process.

For example, in the Visual Studio Task Runner Explorer, configure existing preprocessor compilation as a **Before Build** task.

Many third-party NuGet packages, such as [Delegate.SassBuilder](https://www.nuget.org/packages/Delegate.SassBuilder/), can compile SASS/SCSS files at the beginning of the build process before CSS isolation occurs—preventing any additional configuration.

For example, when you add a `MyComponent.razor.scss` file, these tools can compile SASS changes to `MyComponent.razor.css` at the beginning of the build process. With that step complete, the isolation step is ready. 

## CSS isolation configuration

When working with isolated CSS, no configuration is required. However, configuration is available for advanced scenarios or when there are dependencies on other existing tools or workflows.

### Customize scope identifier format

By default, scope identifiers use the format `b-<10-character-string>`. To customize the scope identifier format, update the project file to a desired pattern.

```xml
<ItemGroup>
    <None Update="MyComponent.razor.css" CssScope="my-custom-scope-identifier" />
</ItemGroup>
```

In this example, the scope identifier changes from `b-<10-character-string>` to `my-custom-scope-identifier`.

### Change base path for static web assets

The `scoped.styles.css` file gets generated under the root of your app. In your project file, use the `StaticWebAssetBasePath` property to change the default path. The following example places the `scoped.styles.css` file, and the rest of the app's assets, in a `_content` path instead.

```xml
<PropertyGroup>
  <StaticWebAssetBasePath>_content/$(PackageId)</StaticWebAssetBasePath>
</PropertyGroup>
```

### Disable automatic bundling

To opt out of how Blazor publishes and loads scoped files at runtime, use the `DisableScopedCssBundling` property. When using this property, it means other tools or processes are responsible for taking the isolated CSS files from the `obj` directory and publishing and loading them at runtime.

```xml
<PropertyGroup>
  <DisableScopedCssBundling>true</DisableScopedCssBundling>
</PropertyGroup>
```
