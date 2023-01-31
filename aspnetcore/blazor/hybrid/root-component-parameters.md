---
title: Pass root component parameters in ASP.NET Core Blazor Hybrid
author: guardrex
description: Learn how to pass an optional dictionary of parameters to the root component in an ASP.NET Core Blazor Hybrid app.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 01/31/2023
uid: blazor/hybrid/root-component-parameters
---
# Pass root component parameters in ASP.NET Core Blazor Hybrid

This article explains how to pass root component parameters in a Blazor Hybrid app.

The `RootComponent` class of a `BlazorWebView` defines a `Parameters` property of type `IDictionary<string, object?>?`, which represents an optional dictionary of parameters to pass to the root component:

* .NET MAUI: <xref:Microsoft.AspNetCore.Components.WebView.Maui.RootComponent?displayProperty=nameWithType>
* WPF: <xref:Microsoft.AspNetCore.Components.WebView.Wpf.RootComponent?displayProperty=nameWithType>
* Windows Forms: <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms.RootComponent?displayProperty=nameWithType>

The following example passes a view model to the root component, which further passes the view model as a cascading type to a Razor component in the Blazor portion of the app. The example is based on the keypad example in the .NET MAUI documentation:

* [Data binding and MVVM: Commanding (.NET MAUI documentation)](/dotnet/maui/xaml/fundamentals/mvvm#commanding): Explains data binding with MVVM using a keypad example.
* [.NET MAUI Samples](https://github.com/dotnet/maui-samples): Provides sample code for `KeypadViewModel.cs`, which is required for this article's example. Implement the `Views/KeypadPage.xaml`/`Views/KeypadPage.xaml.cs` in the app if you wish to see the view model used in a content page.

Although the keypad example focuses on implementing the MVVM pattern in .NET MAUI Blazor apps:

* The dictionary of objects passed to root components can include any type for any purpose where you need to pass one or more parameters to the root component for use by Razor components in the app.
* The concepts demonstrated by the following .NET MAUI Blazor example are the same for Windows Forms Blazor apps and WPF Blazor apps.

Place the view model into the .NET MAUI Blazor app. The view model is available from the .NET MAUI sample app:

[`KeypadViewModel.cs` (`dotnet/maui-samples` GitHub repository)](https://github.com/dotnet/maui-samples/blob/main/6.0/XAML/Fundamentals/XamlSamples/ViewModels/KeypadViewModel.cs)

Change the namespace of `KeypadViewModel.cs` file to match the app's root namespace. In the following example, the app's root namespace is `MauiBlazor`:

```csharp
namespace MauiBlazor;
```

> [!NOTE]
> At the time the `KeypadViewModel` view model was created for the .NET MAUI sample app and the .NET MAUI documentation, view models were placed in a folder named `ViewModels`, but the namespace was set to the root of the app and didn't include the folder name. If you wish to update the namespace to include the folder in the `KeypadViewModel.cs` file, modify the example code in this article to match. Add `using` (C#) and `@using` (Razor) statements to the following files or fully-qualify the references to the view model type as `{APP NAMESPACE}.ViewModels.KeypadViewModel`, where the `{APP NAMESPACE}` placeholder is the app's root namespace.

Although you can set `Parameters` directly in XAML, the following example names the root component (`rootComponent`) in the XAML file and sets the parameter dictionary in the code-behind file.

In `MainPage.xaml`:

```xaml
<RootComponent x:Name="rootComponent" 
               Selector="#app" 
               ComponentType="{x:Type local:Main}" />
```

In the code-behind file (`MainPage.xaml.cs`), assign the view model in the constructor:

```csharp
public MainPage()
{
    InitializeComponent();

    rootComponent.Parameters = 
        new Dictionary<string, object>
        {
            { "KeypadViewModel", new KeypadViewModel() }
        };
}
```

In the `Main` component (`Main.razor`), add a parameter matching the type of the object passed to the root component:

```razor
@code {
    [Parameter]
    public KeypadViewModel KeypadViewModel { get; set; }
}
```

The following example [cascades](xref:blazor/components/cascading-values-and-parameters) the object (`KeypadViewModel`) down component hierarchies in the Blazor portion of the app as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component).

In the `MainLayout` component (`MainLayout.razor`), add an `@code` block with a field for the type, which is `KeypadViewModel` in this example:

```razor
@code {
    private KeypadViewModel keypadViewModel = new();
}
```

Wrap the `<article>` element of `MainLayout` with a [`CascadingValue` component](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) for the view model:

```razor
<CascadingValue Value="@keypadViewModel">
    <article class="content px-4">
        @Body
    </article>
</CascadingValue>
```

At this point, the cascaded type is available to Razor components throughout the app as a [`CascadingParameter`](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute).

The following `Keypad` component example:

* Displays the current value of `KeypadViewModel.DisplayText`.
* Permits character deletion by calling the `KeypadViewModel.DeleteCharCommand` command if the display string length is greater than 0 (zero), which is checked by the call to <xref:System.Windows.Input.ICommand.CanExecute%2A?displayProperty=nameWithType>.
* Permits adding characters by calling `KeypadViewModel.AddCharCommand` with the key pressed in the UI.

`Pages/Keypad.razor`:

```razor
@page "/keypad"

<h1>Keypad</h1>

<table id="keypad">
    <thead>
        <tr>
            <th colspan="2">@KeypadViewModel.DisplayText</th>
            <th><button @onclick="DeleteChar">&#x21E6;</button></th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><button @onclick="@(e => AddChar("1"))">1</button></td>
            <td><button @onclick="@(e => AddChar("2"))">2</button></td>
            <td><button @onclick="@(e => AddChar("3"))">3</button></td>
        </tr>
        <tr>
            <td><button @onclick="@(e => AddChar("4"))">4</button></td>
            <td><button @onclick="@(e => AddChar("5"))">5</button></td>
            <td><button @onclick="@(e => AddChar("6"))">6</button></td>
        </tr>
        <tr>
            <td><button @onclick="@(e => AddChar("7"))">7</button></td>
            <td><button @onclick="@(e => AddChar("8"))">8</button></td>
            <td><button @onclick="@(e => AddChar("9"))">9</button></td>
        </tr>
        <tr>
            <td><button @onclick="@(e => AddChar("*"))">*</button></td>
            <td><button @onclick="@(e => AddChar("0"))">0</button></td>
            <td><button @onclick="@(e => AddChar("#"))">#</button></td>
        </tr>
    </tbody>
</table>

@code {
    [CascadingParameter]
    protected KeypadViewModel KeypadViewModel { get; set; }

    private void DeleteChar()
    {
        if (KeypadViewModel.DeleteCharCommand.CanExecute(null))
        {
            KeypadViewModel.DeleteCharCommand.Execute(null);
        }
    }

    private void AddChar(string key)
    {
        KeypadViewModel.AddCharCommand.Execute(key);
    }
}
```

Purely for demonstration purposes, style the buttons by placing the following CSS styles in the `wwwroot/index.html` file's `<head>` content:

```html
<style>
    #keypad button {
        border: 1px solid black;
        border-radius:6px;
        height: 35px;
        width:80px;
    }
</style>
```

Create a sidebar navigation entry in the [`NavMenu` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (`Shared/NavMenu.razor`) with the following markup:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="keypad">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Keypad
    </NavLink>
</div>
```

## Additional resources

* [Host a Blazor web app in a .NET MAUI app using BlazorWebView](/dotnet/maui/user-interface/controls/blazorwebview)
* [Data binding and MVVM: Commanding (.NET MAUI documentation)](/dotnet/maui/xaml/fundamentals/mvvm#commanding)
* <xref:blazor/components/cascading-values-and-parameters>
