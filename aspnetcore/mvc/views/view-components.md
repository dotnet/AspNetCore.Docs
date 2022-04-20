---
title: View components in ASP.NET Core
author: rick-anderson
description: Learn how view components are used in ASP.NET Core and how to add them to apps.
ms.author: riande
ms.custom: mvc
ms.date: 04/20/2022
monikerRange: '>= aspnetcore-3.1'
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: mvc/views/view-components
---
# View components in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

## View components

View components are similar to partial views, but they're much more powerful. View components don't use model binding, they depend on the data passed when calling the view component. This article was written using controllers and views, but view components work with [Razor Pages](https://www.learnrazorpages.com/razor-pages/view-components).

A view component:

* Renders a chunk rather than a whole response.
* Includes the same separation-of-concerns and testability benefits found between a controller and view.
* Can have parameters and business logic.
* Is typically invoked from a layout page.

View components are intended anywhere reusable rendering logic that's too complex for a partial view, such as:

* Dynamic navigation menus
* Tag cloud, where it queries the database
* Sign in panel
* Shopping cart
* Recently published articles
* Sidebar content on a blog
* A sign in panel that would be rendered on every page and show either the links to sign out or sign in, depending on the sign in state of the user

A view component consists of two parts:

* The class, typically derived from <xref:Microsoft.AspNetCore.Mvc.ViewComponent>
* The result it returns, typically a view.

Like controllers, a view component can be a POCO, but most developers take advantage of the methods and properties available by deriving from <xref:Microsoft.AspNetCore.Mvc.ViewComponent>.

When considering if view components meet an app's specifications, consider using Razor components instead. Razor components also combine markup with C# code to produce reusable UI units. Razor components are designed for developer productivity when providing client-side UI logic and composition. For more information, see <xref:blazor/components/index>. For information on how to incorporate Razor components into an MVC or Razor Pages app, see <xref:blazor/components/prerendering-and-integration?pivots=server>.

## Create a view component

This section contains the high-level requirements to create a view component. Later in the article, we'll examine each step in detail and create a view component.

### The view component class

A view component class can be created by any of the following:

* Deriving from <xref:Microsoft.AspNetCore.Mvc.ViewComponent>
* Decorating a class with the [`[ViewComponent]`](xref:Microsoft.AspNetCore.Mvc.ViewComponentAttribute) attribute, or deriving from a class with the `[ViewComponent]` attribute
* Creating a class where the name ends with the suffix [`ViewComponent`](xref:Microsoft.AspNetCore.Mvc.ViewComponents)

Like controllers, view components must be public, non-nested, and non-abstract classes. The view component name is the class name with the `ViewComponent` suffix removed. It can also be explicitly specified using the <xref:Microsoft.AspNetCore.Mvc.ViewComponentAttribute.Name%2A> property.

A view component class:

* Supports constructor [dependency injection](../../fundamentals/dependency-injection.md)
* Doesn't take part in the controller lifecycle, therefore [filters](../controllers/filters.md) can't be used in a view component

To prevent a class that has a case-insensitive `ViewComponent` suffix from being treated as a view component, decorate the class with the [`[NonViewComponent]`](xref:Microsoft.AspNetCore.Mvc.NonViewComponentAttribute) attribute:

[!code-csharp[](view-components/sample6.x/ViewComponentSample/ReviewComponent.cs?name=snippet&highlight=3)]

### View component methods

A view component defines its logic in an:

* `InvokeAsync` method that returns `Task<IViewComponentResult>`.
* `Invoke` synchronous method that returns an <xref:Microsoft.AspNetCore.Mvc.IViewComponentResult>.

Parameters come directly from invocation of the view component, not from model binding. A view component never directly handles a request. Typically, a view component initializes a model and passes it to a view by calling the `View` method. In summary, view component methods:

* Define an `InvokeAsync` method that returns a `Task<IViewComponentResult>` or a synchronous `Invoke` method that returns an `IViewComponentResult`.
* Typically initializes a model and passes it to a view by calling the [ViewComponent.View](xref:Microsoft.AspNetCore.Mvc.ViewComponent.View) method.
* Parameters come from the calling method, not HTTP. There's no model binding.
* Aren't reachable directly as an HTTP endpoint. They're typically invoked in a view. A view component never handles a request.
* Are overloaded on the signature rather than any details from the current HTTP request.

### View search path

The runtime searches for the view in the following paths:

* /Views/{Controller Name}/Components/{View Component Name}/{View Name}
* /Views/Shared/Components/{View Component Name}/{View Name}
* /Pages/Shared/Components/{View Component Name}/{View Name}

The search path applies to projects using controllers + views and Razor Pages.

The default view name for a view component is `Default`, which means view files will typically be named `Default.cshtml`. A different view name can be specified when creating the view component result or when calling the `View` method.

We recommend naming the view file `Default.cshtml` and using the *Views/Shared/Components/{View Component Name}/{View Name}* path. The `PriorityList` view component used in this sample uses `Views/Shared/Components/PriorityList/Default.cshtml` for the view component view.

### Customize the view search path

To customize the view search path, modify Razor's <xref:Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.ViewLocationFormats> collection. For example, to search for views within the path `/Components/{View Component Name}/{View Name}`, add a new item to the collection:

[!code-csharp[](view-components/sample6.x/ViewComponentSample/Program.cs?name=snippet&highlight=7-10)]

In the preceding code, the placeholder `{0}` represents the path `Components/{View Component Name}/{View Name}`.

## Invoke a view component

To use the view component, call the following inside a view:

```cshtml
@await Component.InvokeAsync("Name of view component",
                             {Anonymous Type Containing Parameters})
```

The parameters are passed to the `InvokeAsync` method. The `PriorityList` view component developed in the article is invoked from the `Views/ToDo/Index.cshtml` view file. In the following code, the `InvokeAsync` method is called with two parameters:

[!code-cshtml[](view-components/sample6.x/ViewCompFinal/Views/ToDo/Index.cshtml?name=snippet2&highlight=6-10)]

## Invoke a view component as a Tag Helper

A View Component can be invoked as a [Tag Helper](xref:mvc/views/tag-helpers/intro):

[!code-cshtml[](view-components/sample6.x/ViewComponentSample/Views/ToDo/IndexTagHelper.cshtml?name=snippet&highlight=8-9)]

Pascal-cased class and method parameters for Tag Helpers are translated into their [kebab case](https://stackoverflow.com/questions/11273282/whats-the-name-for-dash-separated-case/12273101). The Tag Helper to invoke a view component uses the `<vc></vc>` element. The view component is specified as follows:

```cshtml
<vc:[view-component-name]
  parameter1="parameter1 value"
  parameter2="parameter2 value">
</vc:[view-component-name]>
```

To use a view component as a Tag Helper, register the assembly containing the view component using the `@addTagHelper` directive. If the view component is in an assembly called `MyWebApp`, add the following directive to the `_ViewImports.cshtml` file:

```cshtml
@addTagHelper *, MyWebApp
```

A view component can be registered as a Tag Helper to any file that references the view component. See [Managing Tag Helper Scope](xref:mvc/views/tag-helpers/intro#managing-tag-helper-scope) for more information on how to register Tag Helpers.

The `InvokeAsync` method used in this tutorial:

[!code-cshtml[](view-components/sample6.x/ViewComponentSample/Views/ToDo/IndexPP.cshtml?name=snippet)]

In the preceding markup, the `PriorityList` view component becomes `priority-list`. The parameters to the view component are passed as attributes in kebab case.

### Invoke a view component directly from a controller

View components are typically invoked from a view, but they can be invoked directly from a controller method. While view components don't define endpoints like controllers, a controller action that returns the content of a `ViewComponentResult` can be implemented.

In the following example, the view component is called directly from the controller:

[!code-csharp[](view-components/sample6.x/ViewComponentSample/Controllers/ToDoController.cs?name=snippet_IndexVC)]

## Create a basic view component

[Download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/views/view-components/sample6.x), build and test the starter code. It's a basic project with a `ToDo` controller that displays a list of *ToDo* items.

![List of ToDos](view-components/_static/2dos.png)

### Update the controller to pass in priority and completion status

Update the `Index` method to use priority and completion status parameters:

[!code-csharp[](view-components/sample6.x/ViewCompFinal/Controllers/ToDoController.cs?highlight=15-21&name=snippet)]

### Add a ViewComponent class

Add a ViewComponent class to `ViewComponents/PriorityListViewComponent.cs`:

[!code-csharp[](view-components/sample6.x/ViewCompFinal/ViewComponents/PriorityListViewComponent1.cs?name=snippet1)]

Notes on the code:

* View component classes can be contained in **any** folder in the project.
* Because the class name PriorityList**ViewComponent** ends with the suffix **ViewComponent**, the runtime uses the string `PriorityList` when referencing the class component from a view.
* The  [`[ViewComponent]`](xref:Microsoft.AspNetCore.Mvc.ViewComponentAttribute) attribute can change the name used to reference a view component. For example, the class could have been named `XYZ` with the following `[ViewComponent]` attribute:

  ```csharp
  [ViewComponent(Name = "PriorityList")]
     public class XYZ : ViewComponent
     ```

* The `[ViewComponent]` attribute in the preceding code tells the view component selector to use:
  * The name `PriorityList` when looking for the views associated with the component
  * The string "PriorityList" when referencing the class component from a view. 
* The component uses [dependency injection](../../fundamentals/dependency-injection.md) to make the data context available.
* `InvokeAsync` exposes a method that can be called from a view, and it can take an arbitrary number of arguments.
* The `InvokeAsync` method returns the set of `ToDo` items that satisfy the `isDone` and `maxPriority` parameters.

### Create the view component Razor view

* Create the *Views/Shared/Components* folder. This folder **must** be named *Components*.
* Create the *Views/Shared/Components/PriorityList* folder. This folder name must match the name of the view component class, or the name of the class minus the suffix. If the `ViewComponent` attribute is used, the class name would need to match the attribute designation.
* Create a `Views/Shared/Components/PriorityList/Default.cshtml` Razor view:

  [!code-cshtml[](view-components/sample6.x/ViewComponentSample/Views/Shared/Components/PriorityList/Default1.cshtml)]

   The Razor view takes a list of `TodoItem` and displays them. If the view component `InvokeAsync` method doesn't pass the name of the view, *Default* is used for the view name by convention. To override the default styling for a specific controller, add a view to the controller-specific view folder (for example *Views/ToDo/Components/PriorityList/Default.cshtml)*.

    If the view component is controller-specific, it can be added it to the controller-specific folder. For example, `Views/ToDo/Components/PriorityList/Default.cshtml` is controller-specific.
* Add a `div` containing a call to the priority list component to the bottom of the `Views/ToDo/index.cshtml` file:

    [!code-cshtml[](view-components/sample6.x/ViewCompFinal/Views/ToDo/Index.cshtml?name=snippet2)]

The markup `@await Component.InvokeAsync` shows the syntax for calling view components. The first argument is the name of the component we want to invoke or call. Subsequent parameters are passed to the component. `InvokeAsync` can take an arbitrary number of arguments.

Test the app. The following image shows the ToDo list and the priority items:

![todo list and priority items](view-components/_static/pi.png)

The view component can be called directly from the controller:

[!code-csharp[](view-components/sample6.x/ViewComponentSample/Controllers/ToDoController.cs?name=snippet_IndexVC)]

![priority items from IndexVC action](view-components/_static/indexvc.png)

### Specify a view component name

A complex view component might need to specify a non-default view under some conditions. The following code shows how to specify the "PVC" view  from the `InvokeAsync` method. Update the `InvokeAsync` method in the `PriorityListViewComponent` class.

[!code-csharp[](view-components/sample6.x/ViewCompFinal/ViewComponents/PriorityListViewComponentFinal.cs?name=snippet1)]

Copy the `Views/Shared/Components/PriorityList/Default.cshtml` file to a view named `Views/Shared/Components/PriorityList/PVC.cshtml`. Add a heading to indicate the PVC view is being used.

[!code-cshtml[](../../mvc/views/view-components/sample6.x/ViewComponentSample/Views/Shared/Components/PriorityList/PVC.cshtml?highlight=3)]

<!-- TODO zz delete me 
Update `Views/ToDo/Index.cshtml`:

[!code-cshtml[](view-components/sample6.x/ViewComponentSample/Views/ToDo/IndexFinal.cshtml?name=snippet)]

-->

Run the app and verify PVC view.

![Priority View Component](view-components/_static/pvc.png)

If the PVC view isn't rendered, verify the view component with a priority of 4 or higher is called.

### Examine the view path

* Change the priority parameter to three or less so the priority view isn't returned.
* Temporarily rename the `Views/ToDo/Components/PriorityList/Default.cshtml` to `1Default.cshtml`.
* Test the app, the following error occurs:

   ```txt
   An unhandled exception occurred while processing the request.
   InvalidOperationException: The view 'Components/PriorityList/Default' wasn't found. The following locations were searched:
   /Views/ToDo/Components/PriorityList/Default.cshtml
   /Views/Shared/Components/PriorityList/Default.cshtml
   ```

* Copy `Views/ToDo/Components/PriorityList/1Default.cshtml` to `Views/Shared/Components/PriorityList/Default.cshtml`.
* Add some markup to the *Shared* ToDo view component view to indicate the view is from the *Shared* folder.
* Test the **Shared** component view.

![ToDo output with Shared component view](view-components/_static/shared.png)

### Avoid hard-coded strings

For compile time safety, replace the hard-coded view component name with the class name. Update the *PriorityListViewComponent.cs* file to not use the "ViewComponent" suffix:

[!code-csharp[](view-components/sample6.x/ViewCompFinal/ViewComponents/Components/PriorityList.cs?highlight=7)]

The view file:

[!code-cshtml[](view-components/sample6.x/ViewCompFinal/Views/ToDo/IndexNameOf.cshtml?name=snippet&highlight=8)]

An overload of `Component.InvokeAsync` method that takes a CLR type uses the `typeof` operator:

[!code-cshtml[](view-components/sample6.x/ViewCompFinal/Views/ToDo/IndexTypeof.cshtml?name=snippet&highlight=8)]

## Perform synchronous work

The framework handles invoking a synchronous `Invoke` method if asynchronous work isn't required. The following method creates a synchronous `Invoke` view component:

[!code-csharp[](view-components/sample6.x/ViewCompFinal/ViewComponents/Components/PriorityListSync.cs)]

The view component's Razor file:

[!code-cshtml[](view-components/sample6.x/ViewCompFinal/Views/ToDo/IndexSync.cshtml?name=snippet)]

The view component is invoked in a Razor file (for example, `Views/Home/Index.cshtml`) using one of the following approaches:

* <xref:Microsoft.AspNetCore.Mvc.IViewComponentHelper>
* [Tag Helper](xref:mvc/views/tag-helpers/intro)

To use the <xref:Microsoft.AspNetCore.Mvc.IViewComponentHelper> approach, call `Component.InvokeAsync`:

```cshtml
@await Component.InvokeAsync(nameof(PriorityList),
                             new { maxPriority = 4, isDone = true })
```

To use the Tag Helper, register the assembly containing the View Component using the `@addTagHelper` directive (the view component is in an assembly called `MyWebApp`):

```cshtml
@addTagHelper *, MyWebApp
```

Use the view component Tag Helper in the Razor markup file:

```cshtml
<vc:priority-list max-priority="999" is-done="false">
</vc:priority-list>
```

The method signature of `PriorityList.Invoke` is synchronous, but Razor finds and calls the method with `Component.InvokeAsync` in the markup file.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/views/view-components/sample6.x) ([how to download](xref:index#how-to-download-a-sample))
* [Dependency injection into views](xref:mvc/views/dependency-injection)
* [View Components in Razor Pages](https://www.learnrazorpages.com/razor-pages/view-components)
* [Why You Should Use View Components, not Partial Views, in ASP.NET Core](https://www.telerik.com/blogs/why-you-should-use-view-components-not-partial-views-aspnet-core)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/views/view-components/sample) ([how to download](xref:index#how-to-download-a-sample))

## View components

View components are similar to partial views, but they're much more powerful. View components don't use model binding, and only depend on the data provided when calling into it. This article was written using controllers and views, but view components also work with Razor Pages.

A view component:

* Renders a chunk rather than a whole response.
* Includes the same separation-of-concerns and testability benefits found between a controller and view.
* Can have parameters and business logic.
* Is typically invoked from a layout page.

View components are intended anywhere you have reusable rendering logic that's too complex for a partial view, such as:

* Dynamic navigation menus
* Tag cloud (where it queries the database)
* Login panel
* Shopping cart
* Recently published articles
* Sidebar content on a typical blog
* A login panel that would be rendered on every page and show either the links to log out or log in, depending on the log in state of the user

A view component consists of two parts: the class (typically derived from <xref:Microsoft.AspNetCore.Mvc.ViewComponent>) and the result it returns (typically a view). Like controllers, a view component can be a [POCO](https://stackoverflow.com/questions/250001/poco-definition), but most developers take advantage of the methods and properties available by deriving from `ViewComponent`.

When considering if view components meet an app's specifications, consider using Razor components instead. Razor components also combine markup with C# code to produce reusable UI units. Razor components are designed for developer productivity when providing client-side UI logic and composition. For more information, see <xref:blazor/components/index>. For information on how to incorporate Razor components into an MVC or Razor Pages app, see <xref:blazor/components/prerendering-and-integration?pivots=server>.

## Creating a view component

This section contains the high-level requirements to create a view component. Later in the article, we'll examine each step in detail and create a view component.

### The view component class

A view component class can be created by any of the following:

* Deriving from *ViewComponent*
* Decorating a class with the `[ViewComponent]` attribute, or deriving from a class with the `[ViewComponent]` attribute
* Creating a class where the name ends with the suffix *ViewComponent*

Like controllers, view components must be public, non-nested, and non-abstract classes. The view component name is the class name with the "ViewComponent" suffix removed. It can also be explicitly specified using the `ViewComponentAttribute.Name` property.

A view component class:

* Fully supports constructor [dependency injection](../../fundamentals/dependency-injection.md)
* Doesn't take part in the controller lifecycle, which means you can't use [filters](../controllers/filters.md) in a view component

To stop a class that has a case-insensitive *ViewComponent* suffix from being treated as a view component, decorate the class with the [[NonViewComponent]](xref:Microsoft.AspNetCore.Mvc.NonViewComponentAttribute) attribute:
 
```csharp
[NonViewComponent]
public class ReviewComponent
{
    // ...
```

### View component methods

A view component defines its logic in an `InvokeAsync` method that returns a `Task<IViewComponentResult>` or in a synchronous `Invoke` method that returns an `IViewComponentResult`. Parameters come directly from invocation of the view component, not from model binding. A view component never directly handles a request. Typically, a view component initializes a model and passes it to a view by calling the `View` method. In summary, view component methods:

* Define an `InvokeAsync` method that returns a `Task<IViewComponentResult>` or a synchronous `Invoke` method that returns an `IViewComponentResult`.
* Typically initializes a model and passes it to a view by calling the `ViewComponent` `View` method.
* Parameters come from the calling method, not HTTP. There's no model binding.
* Are not reachable directly as an HTTP endpoint. They're invoked from your code (usually in a view). A view component never handles a request.
* Are overloaded on the signature rather than any details from the current HTTP request.

### View search path

The runtime searches for the view in the following paths:

* /Views/{Controller Name}/Components/{View Component Name}/{View Name}
* /Views/Shared/Components/{View Component Name}/{View Name}
* /Pages/Shared/Components/{View Component Name}/{View Name}

The search path applies to projects using controllers + views and Razor Pages.

The default view name for a view component is *Default*, which means your view file will typically be named `Default.cshtml`. You can specify a different view name when creating the view component result or when calling the `View` method.

We recommend you name the view file `Default.cshtml` and use the *Views/Shared/Components/{View Component Name}/{View Name}* path. The `PriorityList` view component used in this sample uses `Views/Shared/Components/PriorityList/Default.cshtml` for the view component view.

### Customize the view search path

To customize the view search path, modify Razor's <xref:Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.ViewLocationFormats> collection. For example, to search for views within the path "/Components/{View Component Name}/{View Name}", add a new item to the collection:

[!code-csharp[](view-components/samples_snapshot/2.x/Startup.cs?name=snippet_ViewLocationFormats&highlight=4)]

In the preceding code, the placeholder "{0}" represents the path "Components/{View Component Name}/{View Name}".

## Invoking a view component

To use the view component, call the following inside a view:

```cshtml
@await Component.InvokeAsync("Name of view component", {Anonymous Type Containing Parameters})
```

The parameters will be passed to the `InvokeAsync` method. The `PriorityList` view component developed in the article is invoked from the `Views/ToDo/Index.cshtml` view file. In the following, the `InvokeAsync` method is called with two parameters:

[!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexFinal.cshtml?range=35)]

## Invoking a view component as a Tag Helper

For ASP.NET Core 1.1 and higher, you can invoke a view component as a [Tag Helper](xref:mvc/views/tag-helpers/intro):

[!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexTagHelper.cshtml?range=37-38)]

Pascal-cased class and method parameters for Tag Helpers are translated into their [kebab case](https://stackoverflow.com/questions/11273282/whats-the-name-for-dash-separated-case/12273101). The Tag Helper to invoke a view component uses the `<vc></vc>` element. The view component is specified as follows:

```cshtml
<vc:[view-component-name]
  parameter1="parameter1 value"
  parameter2="parameter2 value">
</vc:[view-component-name]>
```

To use a view component as a Tag Helper, register the assembly containing the view component using the `@addTagHelper` directive. If your view component is in an assembly called `MyWebApp`, add the following directive to the `_ViewImports.cshtml` file:

```cshtml
@addTagHelper *, MyWebApp
```

You can register a view component as a Tag Helper to any file that references the view component. See [Managing Tag Helper Scope](xref:mvc/views/tag-helpers/intro#managing-tag-helper-scope) for more information on how to register Tag Helpers.

The `InvokeAsync` method used in this tutorial:

[!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexFinal.cshtml?range=35)]

In Tag Helper markup:

[!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexTagHelper.cshtml?range=37-38)]

In the sample above, the `PriorityList` view component becomes `priority-list`. The parameters to the view component are passed as attributes in kebab case.

### Invoking a view component directly from a controller

View components are typically invoked from a view, but you can invoke them directly from a controller method. While view components don't define endpoints like controllers, you can easily implement a controller action that returns the content of a `ViewComponentResult`.

In this example, the view component is called directly from the controller:

[!code-csharp[](view-components/sample/ViewCompFinal/Controllers/ToDoController.cs?name=snippet_IndexVC)]

## Walkthrough: Creating a simple view component

[Download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/views/view-components/sample6.x), build and test the starter code. It's a simple project with a `ToDo` controller that displays a list of *ToDo* items.

![List of ToDos](view-components/_static/2dos.png)

### Add a ViewComponent class

Create a *ViewComponents* folder and add the following `PriorityListViewComponent` class:

[!code-csharp[](view-components/sample/ViewCompFinal/ViewComponents/PriorityListViewComponent1.cs?name=snippet1)]

Notes on the code:

* View component classes can be contained in **any** folder in the project.
* Because the class name PriorityList**ViewComponent** ends with the suffix **ViewComponent**, the runtime uses the string `PriorityList` when referencing the class component from a view.
* The `[ViewComponent]` attribute can change the name used to reference a view component. For example, the class could have been named `XYZ` with the `ViewComponent` attribute:

  ```csharp
  [ViewComponent(Name = "PriorityList")]
     public class XYZ : ViewComponent
     ```

* The `[ViewComponent]` attribute in the preceding code tells the view component selector to use:
  * The name `PriorityList` when looking for the views associated with the component
  * The string "PriorityList" when referencing the class component from a view. 
* The component uses [dependency injection](../../fundamentals/dependency-injection.md) to make the data context available.
* `InvokeAsync` exposes a method which can be called from a view, and it can take an arbitrary number of arguments.
* The `InvokeAsync` method returns the set of `ToDo` items that satisfy the `isDone` and `maxPriority` parameters.

### Create the view component Razor view

* Create the *Views/Shared/Components* folder. This folder ***must*** be named `Components`.

* Create the *Views/Shared/Components/PriorityList* folder. This folder name must match the name of the view component class, or the name of the class minus the suffix (if we followed convention and used the *ViewComponent* suffix in the class name). If you used the `ViewComponent` attribute, the class name would need to match the attribute designation.

* Create a `Views/Shared/Components/PriorityList/Default.cshtml` Razor view:

  [!code-cshtml[](view-components/sample/ViewCompFinal/Views/Shared/Components/PriorityList/Default1.cshtml)]

   The Razor view takes a list of `TodoItem` and displays them. If the view component `InvokeAsync` method doesn't pass the name of the view (as in our sample), *Default* is used for the view name by convention. Later in the tutorial, I'll show you how to pass the name of the view. To override the default styling for a specific controller, add a view to the controller-specific view folder (for example *Views/ToDo/Components/PriorityList/Default.cshtml)*.

    If the view component is controller-specific, you can add it to the controller-specific folder (`Views/ToDo/Components/PriorityList/Default.cshtml`).

* Add a `div` containing a call to the priority list component to the bottom of the `Views/ToDo/index.cshtml` file:

    [!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexFirst.cshtml?range=34-38)]

The markup `@await Component.InvokeAsync` shows the syntax for calling view components. The first argument is the name of the component we want to invoke or call. Subsequent parameters are passed to the component. `InvokeAsync` can take an arbitrary number of arguments.

Test the app. The following image shows the ToDo list and the priority items:

![todo list and priority items](view-components/_static/pi.png)

You can also call the view component directly from the controller:

[!code-csharp[](view-components/sample/ViewCompFinal/Controllers/ToDoController.cs?name=snippet_IndexVC)]

![priority items from IndexVC action](view-components/_static/indexvc.png)

### Specifying a view name

A complex view component might need to specify a non-default view under some conditions. The following code shows how to specify the "PVC" view  from the `InvokeAsync` method. Update the `InvokeAsync` method in the `PriorityListViewComponent` class.

[!code-csharp[](../../mvc/views/view-components/sample/ViewCompFinal/ViewComponents/PriorityListViewComponentFinal.cs?highlight=4,5,6,7,8,9&range=28-39)]

Copy the `Views/Shared/Components/PriorityList/Default.cshtml` file to a view named `Views/Shared/Components/PriorityList/PVC.cshtml`. Add a heading to indicate the PVC view is being used.

[!code-cshtml[](../../mvc/views/view-components/sample/ViewCompFinal/Views/Shared/Components/PriorityList/PVC.cshtml?highlight=3)]

Update `Views/ToDo/Index.cshtml`:

<!-- Views/ToDo/Index.cshtml is never imported, so change to test tutorial -->

[!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexFinal.cshtml?range=35)]

Run the app and verify PVC view.

![Priority View Component](view-components/_static/pvc.png)

If the PVC view isn't rendered, verify you are calling the view component with a priority of 4 or higher.

### Examine the view path

* Change the priority parameter to three or less so the priority view isn't returned.
* Temporarily rename the `Views/ToDo/Components/PriorityList/Default.cshtml` to `1Default.cshtml`.
* Test the app, you'll get the following error:

   ```
   An unhandled exception occurred while processing the request.
   InvalidOperationException: The view 'Components/PriorityList/Default' wasn't found. The following locations were searched:
   /Views/ToDo/Components/PriorityList/Default.cshtml
   /Views/Shared/Components/PriorityList/Default.cshtml
   EnsureSuccessful
   ```

* Copy `Views/ToDo/Components/PriorityList/1Default.cshtml` to `Views/Shared/Components/PriorityList/Default.cshtml`.
* Add some markup to the *Shared* ToDo view component view to indicate the view is from the *Shared* folder.
* Test the **Shared** component view.

![ToDo output with Shared component view](view-components/_static/shared.png)

### Avoiding hard-coded strings

If you want compile time safety, you can replace the hard-coded view component name with the class name. Create the view component without the "ViewComponent" suffix:

[!code-csharp[](../../mvc/views/view-components/sample/ViewCompFinal/ViewComponents/PriorityList.cs?highlight=10&range=5-35)]

Add a `using` statement to your Razor view file, and use the `nameof` operator:

[!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexNameof.cshtml?range=1-6,35-)]

You can use an overload of `Component.InvokeAsync` method that takes a CLR type. Remember to use the `typeof` operator in this case:

[!code-cshtml[](view-components/sample/ViewCompFinal/Views/ToDo/IndexTypeof.cshtml?range=1-6,35-)]

## Perform synchronous work

The framework handles invoking a synchronous `Invoke` method if you don't need to perform asynchronous work. The following method creates a synchronous `Invoke` view component:

```csharp
public class PriorityList : ViewComponent
{
    public IViewComponentResult Invoke(int maxPriority, bool isDone)
    {
        var items = new List<string> { $"maxPriority: {maxPriority}", $"isDone: {isDone}" };
        return View(items);
    }
}
```

The view component's Razor file lists the strings passed to the `Invoke` method (`Views/Home/Components/PriorityList/Default.cshtml`):

```cshtml
@model List<string>

<h3>Priority Items</h3>
<ul>
    @foreach (var item in Model)
    {
        <li>@item</li>
    }
</ul>
```

The view component is invoked in a Razor file (for example, `Views/Home/Index.cshtml`) using one of the following approaches:

* <xref:Microsoft.AspNetCore.Mvc.IViewComponentHelper>
* [Tag Helper](xref:mvc/views/tag-helpers/intro)

To use the <xref:Microsoft.AspNetCore.Mvc.IViewComponentHelper> approach, call `Component.InvokeAsync`:

```cshtml
@await Component.InvokeAsync(nameof(PriorityList), new { maxPriority = 4, isDone = true })
```

To use the Tag Helper, register the assembly containing the View Component using the `@addTagHelper` directive (the view component is in an assembly called `MyWebApp`):

```cshtml
@addTagHelper *, MyWebApp
```

Use the view component Tag Helper in the Razor markup file:

```cshtml
<vc:priority-list max-priority="999" is-done="false">
</vc:priority-list>
```

The method signature of `PriorityList.Invoke` is synchronous, but Razor finds and calls the method with `Component.InvokeAsync` in the markup file.

## All view component parameters are required

Each parameter in a view component is a required attribute. See [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/5011). If any  parameter is omitted:

* The `InvokeAsync` method signature won't match, therefore the method won't execute.
* The ViewComponent won't render any markup.
* No errors will be thrown.

## Additional resources

* [Dependency injection into views](xref:mvc/views/dependency-injection)

:::moniker-end
