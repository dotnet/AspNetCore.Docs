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

Use cascading style sheets (CSS) isolation to apply styles to only the current component. CSS isolation simplifies an app's CSS footprint by preventing dependencies on global styles, and also helps to avoid styling conflicts between other components or libraries.

## Enable CSS isolation 

In the `Pages` directory of your app, create a new file with the format `MyComponent.razor.css`. The `MyComponent` value must match the value of the component, and is *not* case-sensitive.

To add CSS isolation to the `Counter` component in the sample app, add a new file named `Counter.razor.css`, then add the following CSS:

```css
h1 { 
    color: brown;
    font-family: Tahoma, Geneva, Verdana, sans-serif;
}
```

The CSS defined in this file is only scoped to the `Counter` component. Any `h1` CSS declarations defined elsewhere will not conflict with the `Counter` component.

In order to guarantee style isolation when bundling occurs, `@import` blocks are not supported with scoped CSS files.

## Child component support

By default, CSS isolation only applies to the component you associate with `MyComponent.razor.css`. To apply changes to a child component, use the `::deep` combinator in the parent component's `razor.css` file.

The following example shows a parent component containing a child component, `CounterChild`, in `Pages/Counter.razor`:

```razor
@page "/counter"

<h1>Counter</h1>

<div>
    <p>Current count: @currentCount</p>

    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

    <CounterChild />
</div>
```

The `CounterChild` component contains an `h1` element, to be styled the same as `Counter`:

```razor
@page "/counter-child"

<h1>Child component</h1>
```

Update the `h1` declaration in `Counter.razor.css` with the `::deep` combinator to signify the `h1` style declaration must cascade to the child component.

```css
::deep h1 { 
    color: brown;
    font-family: Tahoma, Geneva, Verdana, sans-serif;
}

```

The `h1` style now applies to both the `Counter` and `CounterChild` without needing to create a separate `CounterChild.razor.css` file.

## CSS isolation bundling

CSS isolation occurs at build time. At build time, an app bundle is created. The app bundle is used when the application runs and is published. Assuming no additional configuration, the bundle is located in the deployed app under `framework/scoped.styles.css`. 

In your app, locate the reference inside the `<head>` tag of the generated HTML:

```html
<link href="_framework/scoped.styles.css" rel="stylesheet">
```

The bundle associates each component with a scope identifier. For each styled component, an HTML attribute is appended with the format `b-10-character-string`. For example, for the styled `h1` in the `Counter` component:

```html
<h1 b-3xxtam6d07>
```

The `scoped.styles.css` file associates the component in the identifier:

```css
/* /Pages/Counter.razor.rz.scp.css */
h1[b-3xxtam6d07] {
    color: brown;
    font-family: Tahoma, Geneva, Verdana, sans-serif;
}
```

Additionally, at build time a project bundle is created with the convention `StaticWebAssetsBasePath/MyProject.lib.scp.css`. This is referenced when projects are used for NuGet packages or a Razor Class Library, which both support CSS isolation.  

## CSS preprocessor support

CSS preprocessors are useful with improving CSS development by utilizing features like variables, nesting, modules, mixins, and inheritance. While CSS isolation does not *natively* support CSS preprocessors such as SASS or LESS, integrating them is seamless as long as preprocessor compilation occurs before the CSS isolation build step. 

Many third-party NuGet packages can work with these use cases. For example, if working with SASS, when you add a `MyComponent.razor.scss` file, these tools can compile SASS changes to `MyComponent.razor.css`. With that step complete, the isolation step is ready. 

## CSS isolation configuration

When working with isolated CSS, no configuration is required. However, configuration is available for advanced scenarios, or when there are dependencies on other existing tools or workflows.

### Customize scope identifier format

By default, scope identifiers use the format `b-10-character-string`. To customize the scope identifier format, update the project file to a desired pattern.

```xml
<ItemGroup>
    <None Update="MyComponent.razor.css" CopyToOutputDirectory="my-custom-scope-identifier" />
</ItemGroup>
```

### Change isolated CSS file format

By default, isolated CSS files follow the `MyComponent.styles.css` format. To customize the format, add the following to your project file:

```xml
<FigureThisOut>true</FigureThisOut>
```

### Change base path for static web assets

The `scoped.styles.css` file is generated under the root of your app. In your project file, use the `StaticWebAssetBasePath` property to change the default path. The following example places the `scoped.styles.css` file, and the rest of the app's assets, in a `_content` path instead.

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






