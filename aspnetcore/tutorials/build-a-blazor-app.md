---
title: Build a Blazor todo list app
author: guardrex
description: Build a Blazor app step-by-step.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/22/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/build-a-blazor-app
---
# Build a Blazor todo list app

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

This tutorial shows you how to build and modify a Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a todo list Blazor app project
> * Modify Razor components
> * Use event handling and data binding in components
> * Use routing in a Blazor app

At the end of this tutorial, you'll have a working todo list app.

## Prerequisites

[!INCLUDE[](~/includes/3.1-SDK.md)]

## Create a todo list Blazor app

1. Create a new Blazor app named `TodoList` in a command shell:

   ```dotnetcli
   dotnet new blazorserver -o TodoList
   ```

   The preceding command creates a folder named `TodoList` to hold the app. The `TodoList` folder is the *root folder* of the project. Change directories to the `TodoList` folder with the following command:

   ```dotnetcli
   cd TodoList
   ```

1. Add a new `Todo` Razor component to the app in the `Pages` folder using the following command:

   ```dotnetcli
   dotnet new razorcomponent -n Todo -o Pages
   ```

   > [!IMPORTANT]
   > Razor component file names require a capitalized first letter. Open the `Pages` folder and confirm that the `Todo` component file name starts with a capital letter `T`. The file name should be `Todo.razor`.

1. In `Pages/Todo.razor` provide the initial markup for the component:

   ```razor
   @page "/todo"

   <h3>Todo</h3>
   ```

1. Add the `Todo` component to the navigation bar.

   The `NavMenu` component (`Shared/NavMenu.razor`) is used in the app's layout. Layouts are components that allow you to avoid duplication of content in the app.

   Add a `<NavLink>` element for the `Todo` component by adding the following list item markup below the existing list items in the `Shared/NavMenu.razor` file:

   ```razor
   <li class="nav-item px-3">
       <NavLink class="nav-link" href="todo">
           <span class="oi oi-list-rich" aria-hidden="true"></span> Todo
       </NavLink>
   </li>
   ```

1. Build and run the app by executing the `dotnet run` command in the command shell from the `TodoList` folder. Visit the new Todo page to confirm that the link to the `Todo` component works.

1. Add a `TodoItem.cs` file to the root of the project (the `TodoList` folder) to hold a class that represents a todo item. Use the following C# code for the `TodoItem` class:

   [!code-csharp[](build-a-blazor-app/samples_snapshot/3.x/TodoItem.cs)]

1. Return to the `Todo` component (`Pages/Todo.razor`):

   * Add a field for the todo items in an `@code` block. The `Todo` component uses this field to maintain the state of the todo list.
   * Add unordered list markup and a `foreach` loop to render each todo item as a list item (`<li>`).

   [!code-razor[](build-a-blazor-app/samples_snapshot/3.x/ToDo4.razor?highlight=5-10,12-14)]

1. The app requires UI elements for adding todo items to the list. Add a text input (`<input>`) and a button (`<button>`) below the unordered list (`<ul>...</ul>`):

   [!code-razor[](build-a-blazor-app/samples_snapshot/3.x/ToDo5.razor?highlight=12-13)]

1. Stop the running app in the command shell. Many command shells accept the keyboard command <kbd>Ctrl</kbd>+<kbd>c</kbd> to stop an app. Rebuild and run the app with the `dotnet run` command. When the **`Add todo`** button is selected, nothing happens because an event handler isn't wired up to the button.

1. Add an `AddTodo` method to the `Todo` component and register it for button selections using the `@onclick` attribute. The `AddTodo` C# method is called when the button is selected:

   [!code-razor[](build-a-blazor-app/samples_snapshot/3.x/ToDo6.razor?highlight=2,7-10)]

1. To get the title of the new todo item, add a `newTodo` string field at the top of the `@code` block and bind it to the value of the text input using the `bind` attribute in the `<input>` element:

   [!code-razor[](build-a-blazor-app/samples_snapshot/3.x/ToDo7.razor?highlight=2)]

   ```razor
   <input placeholder="Something todo" @bind="newTodo" />
   ```

1. Update the `AddTodo` method to add the `TodoItem` with the specified title to the list. Clear the value of the text input by setting `newTodo` to an empty string:

   [!code-razor[](build-a-blazor-app/samples_snapshot/3.x/ToDo8.razor?highlight=19-26)]

1. Stop the running app in the command shell. Rebuild and run the app with the `dotnet run` command. Add some todo items to the todo list to test the new code.

1. The title text for each todo item can be made editable, and a check box can help the user keep track of completed items. Add a check box input for each todo item and bind its value to the `IsDone` property. Change `@todo.Title` to an `<input>` element bound to `@todo.Title`:

   [!code-razor[](build-a-blazor-app/samples_snapshot/3.x/ToDo9.razor?highlight=5-6)]

1. To verify that these values are bound, update the `<h3>` header to show a count of the number of todo items that aren't complete (`IsDone` is `false`).

   ```razor
   <h3>Todo (@todos.Count(todo => !todo.IsDone))</h3>
   ```

1. The completed `Todo` component (`Pages/Todo.razor`):

   [!code-razor[](build-a-blazor-app/samples_snapshot/3.x/Todo.razor)]

1. Stop the running app in the command shell. Rebuild and run the app with the `dotnet run` command. Add todo items to test the new code.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a todo list Blazor app project
> * Modify Razor components
> * Use event handling and data binding in components
> * Use routing in a Blazor app

Learn about tooling for ASP.NET Core Blazor:

> [!div class="nextstepaction"]
> <xref:blazor/tooling>
