---
title: Pass root component parameters in ASP.NET Core Blazor Hybrid
author: guardrex
description: Learn how to pass an optional dictionary of parameters to the root component in an ASP.NET Core Blazor Hybrid app.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 01/30/2023
uid: blazor/hybrid/pass-root-component-parameters
---
# Pass root component parameters in ASP.NET Core Blazor Hybrid

This article explains how to pass root component parameters in a Blazor Hybrid app. Although this article's example focuses on .NET MAUI Blazor apps, the concepts are the same for Windows Forms-Blazor and WPF-Blazor apps.

The <xref:Microsoft.AspNetCore.Components.WebView.Maui.RootComponent> class of a <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> defines a <xref:Microsoft.AspNetCore.Components.WebView.Maui.RootComponent.Parameters> property of type `IDictionary<string, object?>?`, which represents an optional dictionary of parameters to pass to the root component.

The following example passes a view model to the root component, which further passes the view model as a cascading type to a Razor component in the Blazor portion of the app. The example is based on the Keypad example in the .NET MAUI documentation:

* [Data binding and MVVM: Commanding (.NET MAUI documentation)](/dotnet/maui/xaml/fundamentals/mvvm#commanding)
* [.NET MAUI Samples](https://github.com/dotnet/maui-samples): Provides sample code for `KeypadViewModel.cs` and `KeypadPage.xaml`/`KeypadPage.xaml.cs`, which are required for the following example to work. At the time of writing, namespaces in these examples don't include the folder name. In future versions of the sample app, namespaces may include the folder names `ViewModels` and `Views`. If namespaces change in the .NET MAUI sample app, modify the examples in this article to match the updates.

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
* Permits character deletion by calling the `KeypadViewModel.DeleteCharCommand` command if the display string length is greater than 0 (zero), which is checked by a call to <xref:System.Windows.Input.ICommand.CanExecute%2A?displayProperty=nameWithType>.
* Permits adding characters by calling `KeypadViewModel.AddCharCommand` with the key pressed in the UI.

`Pages/Keypad.razor`:

```razor
@page "/keypad"

<h1>Keypad</h1>

<table class="table">
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

## Additional resources

* [Host a Blazor web app in a .NET MAUI app using BlazorWebView](/dotnet/maui/user-interface/controls/blazorwebview)
* [Data binding and MVVM: Commanding (.NET MAUI documentation)](/dotnet/maui/xaml/fundamentals/mvvm#commanding)
* <xref:blazor/components/cascading-values-and-parameters>
