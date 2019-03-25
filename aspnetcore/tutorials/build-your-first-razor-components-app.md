---
title: Build your first Razor Components app
author: guardrex
description: Build a Razor Components app step-by-step and learn basic Razor Components concepts.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 03/24/2019
uid: tutorials/first-razor-components-app
---
# Build your first Razor Components app

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/razor-components-preview-notice.md)]

This tutorial shows you how to build an app with Razor Components and demonstrates basic Razor Components concepts. You can enjoy this tutorial using either a Razor Components-based project (supported in .NET Core 3.0 or later) or using a Blazor-based project (supported in a future release of .NET Core).

For an experience using ASP.NET Core Razor Components (*recommended*):

* Follow the guidance in <xref:razor-components/get-started> to create a Razor Components-based project.
* Name the project `RazorComponents`.

For an experience using Blazor:

* Follow the guidance in <xref:spa/blazor/get-started> to create a Blazor-based project.
* Name the project `Blazor`.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/build-your-first-razor-components-app/samples/) ([how to download](xref:index#how-to-download-a-sample)). See the following topics for prerequisites:

## Build components

1. Browse to each of the app's three pages in the *Components/Pages* folder (*Pages* in Blazor): Home, Counter, and Fetch data. These pages are implemented by Razor Component files: *Index.razor*, *Counter.razor*, and *FetchData.razor*. (Blazor continues to use the *.cshtml* file extension: *Index.cshtml*, *Counter.cshtml*, and *FetchData.cshtml*.)

1. On the Counter page, select the **Click me** button to increment the counter without a page refresh. Incrementing a counter in a webpage normally requires writing JavaScript, but Razor Components provides a better approach using C#.

1. Examine the implementation of the Counter component in the *Counter.razor* file.

   *Components/Pages/Counter.razor* (*Pages/Counter.cshtml* in Blazor):

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/Counter1.razor)]

   The UI of the Counter component is defined using HTML. Dynamic rendering logic (for example, loops, conditionals, expressions) is added using an embedded C# syntax called [Razor](xref:mvc/views/razor). The HTML markup and C# rendering logic are converted into a component class at build time. The name of the generated .NET class matches the file name.

   Members of the component class are defined in a `@functions` block. In the `@functions` block, component state (properties, fields) and methods are specified for event handling or for defining other component logic. These members are then used as part of the component's rendering logic and for handling events.

   When the **Click me** button is selected:

   * The Counter component's registered `onclick` handler is called (the `IncrementCount` method).
   * The Counter component regenerates its render tree.
   * The new render tree is compared to the previous one.
   * Only modifications to the Document Object Model (DOM) are applied. The displayed count is updated.

1. Modify the C# logic of the Counter component to make the count increment by two instead of one.

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/Counter2.razor?highlight=14)]

1. Rebuild and run the app to see the changes. Select the **Click me** button, and the counter increments by two.

## Use components

Include a component into another component using an HTML-like syntax.

1. Add the Counter component to the app's Index (Home) component by adding a `<Counter />` element to the Index component.

   If you're using Blazor for this experience, a Survey Prompt component (`<SurveyPrompt>` element) is in the Index component. Replace the `<SurveyPrompt>` element with the `<Counter>` element.

   *Components/Pages/Index.razor* (*Pages/Index.cshtml* in Blazor):

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/Index.razor?highlight=7)]

1. Rebuild and run the app. The Home page has its own counter.

## Component parameters

Components can also have parameters. Component parameters are defined using non-public properties on the component class decorated with `[Parameter]`. Use attributes to specify arguments for a component in markup.

1. Update the component's `@functions` C# code:

   * Add a `IncrementAmount` property decorated with the `[Parameter]` attribute.
   * Change the `IncrementCount` method to use the `IncrementAmount` when increasing the value of `currentCount`.

   *Components/Pages/Counter.razor* (*Pages/Counter.cshtml* in Blazor):

   [!code-cshtml[](build-your-first-razor-components-app/samples/3.x/RazorComponents/Components/Pages/Counter.razor?highlight=12,16)]

<!-- Add back when supported.
   > [!NOTE]
   > From Visual Studio, you can quickly add a component parameter by using the `para` snippet. Type `para` and press the `Tab` key twice.
-->

1. Specify an `IncrementAmount` parameter in the Home component's `<Counter>` element using an attribute. Set the value to increment the counter by ten.

   *Components/Pages/Index.razor* (*Pages/Index.cshtml* in Blazor):

   [!code-cshtml[](build-your-first-razor-components-app/samples/3.x/RazorComponents/Components/Pages/Index.razor?highlight=7)]

1. Reload the Home page. The counter increments by ten each time the **Click me** button is selected. The counter on the Counter page increments by one.

## Route to components

The `@page` directive at the top of the *Counter.razor* file specifies that this component is a routing endpoint. The Counter component handles requests sent to `/Counter`. Without the `@page` directive, the component doesn't handle routed requests, but the component can still be used by other components.

## Dependency injection

Services registered in the app's service container are available to components via [dependency injection (DI)](xref:fundamentals/dependency-injection). Inject services into a component using the `@inject` directive.

Examine the directives of the FetchData component in the sample app.

In the Razor Components sample app, the `WeatherForecastService` service is registered as a [singleton](xref:fundamentals/dependency-injection#service-lifetimes), so one instance of the service is available throughout the app. The `@inject` directive is used to inject the instance of the `WeatherForecastService` service into the component.

*Components/Pages/FetchData.razor*:

[!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/FetchData1.razor?highlight=3)]

The FetchData component uses the injected service, as `ForecastService`, to retrieve an array of `WeatherForecast` objects:

[!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/FetchData2.razor?highlight=6)]

In the Blazor version of the sample app, `HttpClient` is injected to obtain weather forecast data from the *weather.json* file in the *wwwroot/sample-data* folder:

*Pages/FetchData.cshtml*:

[!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/FetchData1.cshtml?highlight=7)]

In both sample apps, a [@foreach](/dotnet/csharp/language-reference/keywords/foreach-in) loop is used to render each forecast instance as a row in the table of weather data:

[!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/FetchData3.razor?highlight=11-19)]

## Build a todo list

Add a new component to the app that implements a simple todo list.

1. Add an empty file to the sample app:

   * For the Razor Components experience, add a *Todo.razor* file to the *Components/Pages* folder.
   * For the Blazor experience, add a *Todo.cshtml* file to the *Pages* folder.

1. Provide the initial markup for the component:

   ```cshtml
   @page "/todo"

   <h1>Todo</h1>
   ```

1. Add the Todo component to the navigation bar.

   The NavMenu component (*Components/Shared/NavMenu.razor* or *Shared/NavMenu.cshtml* in Blazor) is used in the app's layout. Layouts are components that allow you to avoid duplication of content in the app. For more information, see <xref:razor-components/layouts>.

   Add a `<NavLink>` for the Todo component by adding the following list item markup below the existing list items in the *Components/Shared/NavMenu.razor* (*Shared/NavMenu.cshtml* in Blazor) file:

   ```cshtml
   <li class="nav-item px-3">
       <NavLink class="nav-link" href="todo">
           <span class="oi oi-list-rich" aria-hidden="true"></span> Todo
       </NavLink>
   </li>
   ```

1. Rebuild and run the app. Visit the new Todo page to confirm that the link to the Todo component works.

1. Add a *TodoItem.cs* file to the root of the project to hold a class that represents a todo item. Use the following C# code for the `TodoItem` class:

   [!code-cshtml[](build-your-first-razor-components-app/samples/3.x/RazorComponents/TodoItem.cs)]

1. Return to the Todo component (*Components/Pages/Todo.razor* or *Pages/Todo.cshtml* in Blazor):

   * Add a field for the todos in an `@functions` block. The Todo component uses this field to maintain the state of the todo list.
   * Add unordered list markup and a `foreach` loop to render each todo item as a list item.

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/ToDo4.razor?highlight=5-10,12-14)]

1. The app requires UI elements for adding todos to the list. Add a text input and a button below the list:

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/ToDo5.razor?highlight=12-13)]

1. Rebuild and run the app. When the **Add todo** button is selected, nothing happens because an event handler isn't wired up to the button.

1. Add an `AddTodo` method to the Todo component and register it for button clicks using the `onclick` attribute:

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/ToDo6.razor?highlight=2,7-10)]

   The `AddTodo` C# method is called when the button is selected.

1. To get the title of the new todo item, add a `newTodo` string field and bind it to the value of the text input using the `bind` attribute:

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/ToDo7.razor?highlight=2)]

   ```cshtml
   <input placeholder="Something todo" bind="@newTodo" />
   ```

1. Update the `AddTodo` method to add the `TodoItem` with the specified title to the list. Clear the value of the text input by setting `newTodo` to an empty string:

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/ToDo8.razor?highlight=19-26)]

1. Rebuild and run the app. Add some todos to the todo list to test the new code.

1. The title text for each todo item can be made editable and a check box can help the user keep track of completed items. Add a check box input for each todo item and bind its value to the `IsDone` property. Change `@todo.Title` to an `<input>` element bound to `@todo.Title`:

   [!code-cshtml[](build-your-first-razor-components-app/samples_snapshot/3.x/ToDo9.razor?highlight=5-6)]

1. To verify that these values are bound, update the `<h1>` header to show a count of the number of todo items that aren't complete (`IsDone` is `false`).

   ```cshtml
   <h1>Todo (@todos.Count(todo => !todo.IsDone))</h1>
   ```

1. The completed Todo component (*Components/Pages/Todo.razor* or *Pages/Todo.cshtml* in Blazor):

   [!code-cshtml[](build-your-first-razor-components-app/samples/3.x/RazorComponents/Components/Pages/Todo.razor)]

1. Rebuild and run the app. Add todo items to test the new code.

## Publish and deploy the app

To publish the app, see <xref:host-and-deploy/razor-components/index#publish-the-app>.
