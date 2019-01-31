---
title: Get started with Razor Components
author: guardrex
description: Learn how to get started with the Razor Components framework.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/29/2019
uid: razor-components/get-started
---
# Get started with Razor Components

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

## Setup

Install the following:

1. [.NET Core 2.1 SDK](https://go.microsoft.com/fwlink/?linkid=873092) (2.1.500 or later).
1. [Visual Studio 2017](https://go.microsoft.com/fwlink/?linkid=873093) (15.9 or later) with the *ASP.NET and web development* workload selected.
1. The latest [Blazor Language Services extension](https://go.microsoft.com/fwlink/?linkid=870389) from the Visual Studio Marketplace.
1. The Blazor templates on the command-line:

   ```console
   dotnet new -i Microsoft.AspNetCore.Blazor.Templates
   ```

To create your first project from Visual Studio:

1. Select **File** > **New Project** > **Web** > **ASP.NET Core Web Application**.
1. Make sure **.NET Core** and **ASP.NET Core 2.1** are selected at the top.
1. Choose the Blazor template and select **OK**.

   ![New app dialog](https://msdnshared.blob.core.windows.net/media/2018/07/new-blazor-app-dialog-0.5.0.png)

1. Press **Ctrl-F5** to run the app *without the debugger*. Running with the debugger (**F5**) isn't supported at this time.

To create a new Blazor app from the command-line:

```console
dotnet new blazor -o BlazorApp1
cd BlazorApp1
dotnet run
```

Congrats! You just ran your first Blazor app!

![Blazor app home page](https://msdnshared.blob.core.windows.net/media/2018/04/blazor-bootstrap-4.png)

## Help & feedback

Your feedback is especially important to us during this experimental phase for Blazor. If you run into issues or have questions while trying out Blazor, please let us know!

* [File issues on GitHub](https://github.com/aspnet/AspNetCore/issues) for any problems you run into or to make suggestions for improvements.
* Chat with us and the Blazor community on [Gitter](https://gitter.im/aspnet/blazor) if you get stuck or to share how Blazor is working for you.

After you've tried out Blazor, please let us know what you think by taking our in-product survey. Just click the survey link shown on the app home page when running one of the Blazor project templates:

![Blazor survey](https://msdnshared.blob.core.windows.net/media/2018/05/blazor-survey-new.png)

## Next steps

<xref:tutorials/first-blazor-app>
