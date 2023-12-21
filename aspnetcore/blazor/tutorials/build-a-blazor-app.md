---
title: Build a Blazor todo list app
author: guardrex
description: Build a Blazor app step-by-step.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/tutorials/build-a-blazor-app
---
# Build a Blazor todo list app

[!INCLUDE[](~/includes/not-latest-version.md)]

This tutorial provides a basic working experience for building and modifying a Blazor app. For detailed Blazor guidance, see the [Blazor reference documentation](xref:blazor/index).

Learn how to:

> [!div class="checklist"]
> * Create a todo list Blazor app project
> * Modify Razor components
> * Use event handling and data binding in components
> * Use routing in a Blazor app

At the end of this tutorial, you'll have a working todo list app.

## Prerequisites

[Download and install .NET](https://dotnet.microsoft.com/download/dotnet) if it isn't already installed on the system or if the system doesn't have the latest version installed.

## Create a Blazor app

:::moniker range=">= aspnetcore-8.0"

Create a new Blazor Web App named `TodoList` in a command shell:

```dotnetcli
dotnet new blazor -o TodoList
```

The `-o|--output` option creates a folder for the project. If you've created a folder for the project and the command shell is open in that folder, omit the `-o|--output` option and value to create the project.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Use either of the following hosting models to create a new Blazor app named `TodoList` in a command shell:

* For an experience with Blazor Server, create the app with the following command:

  ```dotnetcli
  dotnet new blazorserver -o TodoList
  ```

* For an experience with Blazor WebAssembly, create the app with the following command:

  ```dotnetcli
  dotnet new blazorwasm -o TodoList
  ```

:::moniker-end

The preceding command creates a folder named `TodoList` with the `-o|--output` option to hold the app. The `TodoList` folder is the *root folder* of the project. Change directories to the `TodoList` folder with the following command:

```dotnetcli
cd TodoList
```

## Build a todo list Blazor app

Add a new `Todo` Razor component to the app using the following command:

:::moniker range=">= aspnetcore-8.0"

```dotnetcli
dotnet new razorcomponent -n Todo -o Components/Pages
```

The `-n|--name` option in the preceding command specifies the name of the new Razor component. The new component is created in the project's `Components/Pages` folder with the `-o|--output` option.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```dotnetcli
dotnet new razorcomponent -n Todo -o Pages
```

The `-n|--name` option in the preceding command specifies the name of the new Razor component. The new component is created in the project's `Pages` folder with the `-o|--output` option.

:::moniker-end

> [!IMPORTANT]
> Razor component file names require a capitalized first letter. Open the `Pages` folder and confirm that the `Todo` component file name starts with a capital letter `T`. The file name should be `Todo.razor`.

:::moniker range=">= aspnetcore-8.0"

Open the `Todo` component in any file editor and make the following changes at the top of the file:

* Add an `@page` Razor directive with a relative URL of `/todo`.
* Enable interactivity on the page so that it isn't just statically rendered. The Interactive Server render mode enables the component to handle UI events from the server.
* Add a page title with the `PageTitle` component, which enables adding an HTML `<title>` element to the page.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Open the `Todo` component in any file editor and make the following changes at the top of the file:

* Add an `@page` Razor directive with a relative URL of `/todo`.
* Add a page title with the `PageTitle` component, which enables adding an HTML `<title>` element to the page.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Open the `Todo` component in any file editor and add an `@page` Razor directive with a relative URL of `/todo`.

:::moniker-end

`Todo.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/8.0/Todo0.razor" highlight="1-4":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/7.0/Todo0.razor" highlight="1-3":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="build-a-blazor-app/6.0/Todo0.razor" highlight="1-3":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="build-a-blazor-app/5.0/Todo0.razor" highlight="1":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="build-a-blazor-app/3.1/Todo0.razor" highlight="1":::

:::moniker-end

Save the `Todo.razor` file.

Add the `Todo` component to the navigation bar.

The `NavMenu` component is used in the app's layout. Layouts are components that allow you to avoid duplication of content in an app. The `NavLink` component provides a cue in the app's UI when the component URL is loaded by the app.

In the navigation element (`<nav>`) content of the `NavMenu` component, add the following `<div>` element for the `Todo` component.

:::moniker range=">= aspnetcore-8.0"

In `Components/Layout/NavMenu.razor`:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

In `Shared/NavMenu.razor`:

:::moniker-end

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="todo">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Todo
    </NavLink>
</div>
```

Save the `NavMenu.razor` file.

Build and run the app by executing the [`dotnet watch run`](xref:tutorials/dotnet-watch) command in the command shell from the `TodoList` folder. After the app is running, visit the new Todo page by selecting the **`Todo`** link in the app's navigation bar, which loads the page at `/todo`.

Leave the app running the command shell. Each time a file is saved, the app is automatically rebuilt, and the page in the browser is automatically reloaded.

Add a `TodoItem.cs` file to the root of the project (the `TodoList` folder) to hold a class that represents a todo item. Use the following C# code for the `TodoItem` class.

`TodoItem.cs`:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_WebAssembly/TodoItem.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/build-a-blazor-app/TodoItem.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/build-a-blazor-app/TodoItem.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/build-a-blazor-app/TodoItem.cs":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/build-a-blazor-app/TodoItem.cs":::

:::moniker-end

> [!NOTE]
> If using Visual Studio to create the `TodoItem.cs` file and `TodoItem` class, use ***either*** of the following approaches:
>
> * Remove the namespace that Visual Studio generates for the class.
> * Use the **Copy** button in the preceding code block and replace the entire contents of the file that Visual Studio generates.

Return to the `Todo` component and perform the following tasks:

* Add a field for the todo items in the `@code` block. The `Todo` component uses this field to maintain the state of the todo list.
* Add unordered list markup and a `foreach` loop to render each todo item as a list item (`<li>`).

:::moniker range=">= aspnetcore-8.0"

`Components/Pages/Todo.razor`:

:::code language="razor" source="build-a-blazor-app/8.0/Todo2.razor" highlight="8-13,16":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`Pages/Todo.razor`:

:::code language="razor" source="build-a-blazor-app/7.0/Todo2.razor" highlight="7-12,15":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`Pages/Todo.razor`:

:::code language="razor" source="build-a-blazor-app/6.0/Todo2.razor" highlight="7-12,15":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`Pages/Todo.razor`:

:::code language="razor" source="build-a-blazor-app/5.0/Todo2.razor" highlight="7-12,15":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`Pages/Todo.razor`:

:::code language="razor" source="build-a-blazor-app/3.1/Todo2.razor" highlight="7-12,15":::

:::moniker-end

The app requires UI elements for adding todo items to the list. Add a text input (`<input>`) and a button (`<button>`) below the unordered list (`<ul>...</ul>`):

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/8.0/Todo3.razor" highlight="15-16":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/7.0/Todo3.razor" highlight="14-15":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="build-a-blazor-app/6.0/Todo3.razor" highlight="14-15":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="build-a-blazor-app/5.0/Todo3.razor" highlight="14-15":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="build-a-blazor-app/3.1/Todo3.razor" highlight="14-15":::

:::moniker-end

Save the `TodoItem.cs` file and the updated `Todo.razor` file. In the command shell, the app is automatically rebuilt when the files are saved. The browser reloads the page.

When the **`Add todo`** button is selected, nothing happens because an event handler isn't attached to the button.

Add an `AddTodo` method to the `Todo` component and register the method for the button using the `@onclick` attribute. The `AddTodo` C# method is called when the button is selected:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/8.0/Todo4.razor" highlight="2,7-10":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/7.0/Todo4.razor" highlight="2,7-10":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="build-a-blazor-app/6.0/Todo4.razor" highlight="2,7-10":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="build-a-blazor-app/5.0/Todo4.razor" highlight="2,7-10":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="build-a-blazor-app/3.1/Todo4.razor" highlight="2,7-10":::

:::moniker-end

To get the title of the new todo item, add a `newTodo` string field at the top of the `@code` block:

:::moniker range=">= aspnetcore-6.0"

```csharp
private string? newTodo;
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
private string newTodo;
```

:::moniker-end

Modify the text `<input>` element to bind `newTodo` with the `@bind` attribute:

```razor
<input placeholder="Something todo" @bind="newTodo" />
```

Update the `AddTodo` method to add the `TodoItem` with the specified title to the list. Clear the value of the text input by setting `newTodo` to an empty string:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/8.0/Todo6.razor" highlight="22-29":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="build-a-blazor-app/7.0/Todo6.razor" highlight="21-28":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="build-a-blazor-app/6.0/Todo6.razor" highlight="21-28":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="build-a-blazor-app/5.0/Todo6.razor" highlight="21-28":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="build-a-blazor-app/3.1/Todo6.razor" highlight="21-28":::

:::moniker-end

Save the `Todo.razor` file. The app is automatically rebuilt in the command shell, and the page reloads in the browser.

The title text for each todo item can be made editable, and a checkbox can help the user keep track of completed items. Add a checkbox input for each todo item and bind its value to the `IsDone` property. Change `@todo.Title` to an `<input>` element bound to `todo.Title` with `@bind`:

```razor
<ul>
      @foreach (var todo in todos)
      {
         <li>
            <input type="checkbox" @bind="todo.IsDone" />
            <input @bind="todo.Title" />
         </li>
      }
</ul>
```

Update the `<h3>` header to show a count of the number of todo items that aren't complete (`IsDone` is `false`). The Razor expression in the following header evaluates each time Blazor rerenders the component.

```razor
<h3>Todo (@todos.Count(todo => !todo.IsDone))</h3>
```

The completed `Todo` component:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_WebAssembly/Pages/Todo.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/build-a-blazor-app/Todo.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/build-a-blazor-app/Todo.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/build-a-blazor-app/Todo.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/build-a-blazor-app/Todo.razor":::

:::moniker-end

Save the `Todo.razor` file. The app is automatically rebuilt in the command shell, and the page reloads in the browser.

Add items, edit items, and mark todo items done to test the component.

When finished, shut down the app in the command shell. Many command shells accept the keyboard command <kbd>Ctrl</kbd>+<kbd>C</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>C</kbd> (macOS) to stop an app.

## Publish to Azure

For information on deploying to Azure, see [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore).

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a todo list Blazor app project
> * Modify Razor components
> * Use event handling and data binding in components
> * Use routing in a Blazor app

Learn about tooling for ASP.NET Core Blazor:

> [!div class="nextstepaction"]
> <xref:blazor/index>
