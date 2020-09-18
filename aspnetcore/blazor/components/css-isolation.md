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

Use CSS isolation to apply styles to the current component only. CSS isolation simplifies an app's CSS footprint by preventing dependencies on global styles, and also helps to avoid styling conflicts between other components or libraries.

## Enable CSS isolation 

To enable CSS isolation, in the `Pages` directory of your app create a new file with the format `MyComponent.razor.css`. 

To add CSS isolation to the `Counter` component in the sample app, add a new file named `Counter.razor.css`, then add the following CSS:

```css
h1 { 
    color: brown;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana,sans-serif;
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

    < />
</div>
```

The `CounterChild` contains an `h1` that should be styled the same as `Counter`:

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

The `h1` style now applies to both the `Counter` and `CounterChild` without needing to create a separate `razor.css` file for `CounterChild`.

## CSS isolation bundling

CSS isolation occurs at build time. At build time, an app bundle is created. The app bundle is used when the application runs and is published. Assuming no additional configuration, the bundle is located in the deployed app under `framework/scoped.styles.css`. 

In your app, locate the reference inside the `<head>` tag of the generated HTML:

```html
<link href="_framework/scoped.styles.css" rel="stylesheet">
```

The bundle associates each component with a unique identifier. Each style declaration applies this identifier. For example, for the styled `h1` in the `Counter` component:

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

Additionally, at build time a project bundle is created with the convention `<<StaticWebAssetsBasePath>>/<<project>>.lib.scp.css`. 

## Discuss import order

Discuss import order here

## CSS preprocessor support

Include some stuff about preprocessor support here

## Configuration

To configure CSS isolation, add properties to your project file.

### Change isolated CSS file convention

By default, Blazor follows the `MyComponent.styles.css` convention. To customize the convention, add the following to your project file:

```xml
<FigureThisOut>true</FigureThisOut>
```

### Disable automatic bundling

To opt-out of how Blazor publishes and loads scoped files at runtime, use the `DisableScopedCssBundling` property. 

When specifying this property, you will grab the scoped CSS files from the obj directory and do the required steps to publish and load them during runtime.

```xml
<PropertyGroup>
  <DisableScopedCssBundling>true</DisableScopedCssBundling>
</PropertyGroup>
```






