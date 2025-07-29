---
title: Get started with ASP.NET Core
author: tdykstra
description: A short tutorial using the .NET CLI to create and run a basic Hello World app using ASP.NET Core Blazor.
monikerRange: ">= aspnetcore-3.1"
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/23/2025
uid: get-started
---
# Get started with ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

This tutorial shows how to create, run, and modify an ASP.NET Core Blazor Web App using the .NET CLI. *Blazor* is a .NET frontend web framework that supports both server-side rendering and client interactivity in a single programming model.

You'll learn how to:

> [!div class="checklist"]
> * Create a Blazor Web App.
> * Run the app.
> * Change the app.
> * Shut the app down.

## Prerequisites

Obtain and install the latest .NET SDK at [Download .NET](https://dotnet.microsoft.com/download/dotnet).

## Create a Blazor Web App

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

:::image source="get-started/static/blazor-web-app-running.png" alt-text="Blazor Web App running in Microsoft Edge with the homepage rendered in the UI.":::

Using the app's sidebar navigation, visit the Counter page, where you can select the **:::no-loc text="Click me":::** button to increment the counter.

:::image source="get-started/static/blazor-web-app-counter-page-incremented-to-one.png" alt-text="Counter page rendered after the 'Click me' button is selected once, showing the counter incremented to a value of one.":::

## Change the app

Leave the browser open with the Counter page loaded. By using the `dotnet watch` command to run the app, you can make changes to the app's markup and code without having to rebuild the app to reflect the changes in the browser.

The `Counter` Razor component that renders the Counter web page is located at `Components/Pages/Counter.razor` in the project. *Razor* is a syntax for combining HTML markup with C# code designed for developer productivity.

Open the `Counter.razor` file in a text editor and note a few interesting lines that render content and make the component's counter feature work.

`Components/Pages/Counter.razor`:

```razor
@page "/counter"

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

The file starts with a line that indicates the component's relative path (`/counter`):

```razor
@page "/counter"
```

The title of the page is set by `<PageTitle>` tags:

```razor
<PageTitle>Counter</PageTitle>
```

An H1 heading is displayed:

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

The `@code` block contains C# code that the component executes:

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

As soon as you save the file, the running app is updated automatically because you used the `dotnet watch` command. Go back to the app in the browser and select the **:::no-loc text="Click me":::** button in the Counter page. Witness how the counter now increments from its existing value of one to a value of eleven. Each time the button is selected the value increments by ten.

:::image source="get-started/static/blazor-web-app-counter-page-incremented-to-eleven.png" alt-text="Counter page rendered after the 'Click me' button is selected once, showing the counter incremented to a value of eleven.":::

## Shut the app down

Follow these steps:

* Close the browser window.
* To shut down the app, press <kbd>Ctrl</kbd>+<kbd>C</kbd> in the command shell.

*Congratulations!* You've successfully completed this tutorial.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Blazor Web App.
> * Run the app.
> * Change the app.
> * Shut the app down.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

This tutorial shows how to create and run an ASP.NET Core web app using the .NET CLI.

For Blazor tutorials, see <xref:blazor/tutorials/index>.

You'll learn how to:

> [!div class="checklist"]
> * Create a Razor Pages app.
> * Run the app.
> * Change the app.
> * Shut the app down.

## Prerequisites

Obtain and install the latest .NET SDK at [Download .NET](https://dotnet.microsoft.com/download/dotnet).

## Create Razor Pages app

Open a command shell to a suitable location for the sample app and use the following command to create a Razor Pages app. The `-o|--output` option creates a folder for the project and names the project `RazorPagesSample`:

```dotnetcli
dotnet new webapp -o RazorPagesSample
```

## Run the app

Change the directory to the `RazorPagesSample` folder with the following command:

```dotnetcli
cd RazorPagesSample
```

The `dotnet watch` command runs the app and opens your default browser to the app's landing page:

```dotnetcli
dotnet watch
```

:::image source="get-started/static/razor-pages-app-running.png" alt-text="Web app home page":::

## Change the app

Open the `Pages/Index.cshtml` file in a text editor.

After the line with the ":::no-loc text="Welcome":::" greeting, add the following line to display the local system date and time:

```cshtml
<p>The time on the server is @DateTime.Now</p>
```

Save the changes.

As soon as you save the file, the running app is updated automatically because you used the `dotnet watch` command.

Refresh the page in the browser to see the result:

:::image source="get-started/static/razor-pages-app-date-time-display.png" alt-text="Web app home page showing the change that was made.":::

## Shut the app down

To shut down the app:

* Close the browser window.
* Press <kbd>Ctrl</kbd>+<kbd>C</kbd> in the command shell.

*Congratulations!* You've successfully completed this tutorial.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Razor Pages app.
> * Run the app.
> * Change the app.
> * Shut the app down.

:::moniker-end

To learn more the fundamentals of ASP.NET Core, see the following:

> [!div class="nextstepaction"]
> <xref:fundamentals/index>

## Additional tutorials

:::moniker range=">= aspnetcore-6.0"

App type | Scenario | Tutorial
-------- | -------- | --------
Web app | New server and client web development with Blazor | <xref:blazor/tutorials/build-a-blazor-app> and <xref:blazor/tutorials/movie-database-app/index>
Web API | Server-based data processing with Minimal APIs | <xref:tutorials/min-web-api>
Remote Procedure Call (RPC) app | Contract-first services using Protocol Buffers | <xref:tutorials/grpc/grpc-start>
Real-time app | Server/client bidirectional communication | <xref:tutorials/signalr>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

App type | Scenario | Tutorial
-------- | -------- | --------
Web app | New server and client web development with Blazor | <xref:blazor/tutorials/build-a-blazor-app> and <xref:blazor/tutorials/movie-database-app/index>
Web API | Server-based data processing | <xref:tutorials/first-web-api>
Remote Procedure Call (RPC) app | Contract-first services using Protocol Buffers | <xref:tutorials/grpc/grpc-start>
Real-time app | Server/client bidirectional communication | <xref:tutorials/signalr>

:::moniker-end

## Additional resources

* [Introduction to .NET](/dotnet/core/introduction)
* [Visual Studio](https://visualstudio.microsoft.com/)
* [Visual Studio Code](https://code.visualstudio.com/)
* [.NET Developer Community](https://dotnet.microsoft.com/platform/community)
* [.NET Live TV](https://live.dot.net)
