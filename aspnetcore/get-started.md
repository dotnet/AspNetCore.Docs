---
title: Get started with ASP.NET Core
author: tdykstra
description: A short tutorial using the .NET CLI to create and run a basic Hello World app using ASP.NET Core Blazor.
monikerRange: ">= aspnetcore-3.1"
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/21/2025
uid: get-started
---
# Get started with ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

This tutorial shows how to create, run, and modify an ASP.NET Core Blazor Web App using the .NET CLI.

You'll learn how to:

> [!div class="checklist"]
> * Create a Blazor Web App.
> * Run the app.
> * Change the app.
> * Shut the app down.

At the end, you'll have a working web app running on your local machine.

## Prerequisites

Obtain and install the latest .NET SDK at [Download .NET](https://dotnet.microsoft.com/download/dotnet).

## Create a web app project

Open a command shell to a suitable location for the sample app and use the following command to create a Blazor Web App. The `-o|--output` option creates a folder for the project and names the project `BlazorSample`:

```dotnetcli
dotnet new blazor -o BlazorSample
```

## Run the app

Change the directory to the `BlazorSample` folder with the following command:

```dotnetcli
cd BlazorSample
```

The `dotnet watch` command runs the app and opens your default browser to the app's landing page:

```dotnetcli
dotnet watch
```

Using the app's sidebar navigation, visit the Counter page, where you can select the **:::no-loc text="Click me":::** button to increment the counter.

## Edit a Razor component

Leave the browser open with the Counter page loaded. By using the `dotnet watch` command to run the app, you can make changes to the app's markup and code and see the changes immediately reflected in the browser.

The `Counter` Razor component that renders the Counter web page is located at `Components/Pages/Counter.razor` in the project.

Open the `Counter.razor` file in a text editor and note a few interesting lines that render content and make the component's counter feature work.

The file starts with a line that indicates the component's relative path (`/counter`):

```razor
@page "/counter"
```

The title of the page is set by `<PageTitle>` tags:

```razor
<PageTitle>Counter</PageTitle>
```

An H1 heading is displayed to the user:

```razor
<h1>Counter</h1>
```

A paragraph element (`<p>`) displays the current count, which is stored in a variable named `currentCount`:

```razor
<p role="status">Current count: @currentCount</p>
```

A button (`<button>`) allows the user to increment the counter, which occurs when a button click executes a C# method named `IncrementCount`:

```razor
<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
```

C# code is present in the `@code` block:

```razor
@code {
    ...
}
```

Within the `@code` block:

* The counter variable `currentCount` is established with an initial value of zero.
* The `IncrementCount` method is defined. The code within the method increments the `currentCount` variable by one each time the method is invoked.

```csharp
private int currentCount = 0;

private void IncrementCount()
{
    currentCount++;
}
```

Let's change the increment of the counter in the `IncrementCount` method.

Change the line so that `currentCount` is incremented by a value of ten each time `IncrementCount` is called:

```diff
- currentCount++;
+ currentCount += 10;
```

Save the file.

As soon as you save the file, the running app is updated automatically because you used the `dotnet watch` command. Go back to the app in the browser and select the **:::no-loc text="Click me":::** button in the Counter page. Witness how the counter now increments by ten.

To shut down the app:

* Close the browser window.
* Press <kbd>Ctrl</kbd>+<kbd>C</kbd> in the command shell.

*Congratulations!* You've successfully completed this tutorial.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Blazor Web App.
> * Run the app.
> * Change the app.
> * Shut the app down.

To learn more about ASP.NET Core, see the following:

> [!div class="nextstepaction"]
> <xref:index#recommended-learning-path>

## Additional resources

[Additional Blazor tutorials](xref:blazor/tutorials/index)
