---
title: Work with the application model in ASP.NET Core
author: rick-anderson
description: Learn how to read and manipulate the application model to modify how MVC elements behave in ASP.NET Core.
ms.author: riande
ms.date: 04/05/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: mvc/controllers/application-model
---
# Work with the application model in ASP.NET Core

By [Steve Smith](https://ardalis.com/)

ASP.NET Core MVC defines an *application model* representing the components of an MVC app. Read and manipulate this model to modify how MVC elements behave. By default, MVC follows certain conventions to determine which classes are considered controllers, which methods on those classes are actions, and how parameters and routing behave. Customize this behavior to suit an app's needs by creating custom conventions and applying them globally or as attributes.

## Models and Providers (`IApplicationModelProvider`)

The ASP.NET Core MVC application model includes both abstract interfaces and concrete implementation classes that describe an MVC application. This model is the result of MVC discovering the app's controllers, actions, action parameters, routes, and filters according to default conventions. By working with the application model, modify an app to follow different conventions from the default MVC behavior. The parameters, names, routes, and filters are all used as configuration data for actions and controllers.

The ASP.NET Core MVC Application Model has the following structure:

* ApplicationModel
  * Controllers (ControllerModel)
    * Actions (ActionModel)
      * Parameters (ParameterModel)

Each level of the model has access to a common `Properties` collection, and lower levels can access and overwrite property values set by higher levels in the hierarchy. The properties are persisted to the <xref:Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties?displayProperty=nameWithType> when the actions are created. Then when a request is being handled, any properties a convention added or modified can be accessed through <xref:Microsoft.AspNetCore.Mvc.ActionContext.ActionDescriptor?displayProperty=nameWithType>. Using properties is a great way to configure filters, model binders, and other app model aspects on a per-action basis.

> [!NOTE]
> The <xref:Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties?displayProperty=nameWithType> collection isn't thread safe (for writes) after app startup. Conventions are the best way to safely add data to this collection.

ASP.NET Core MVC loads the application model using a provider pattern, defined by the <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider> interface. This section covers some of the internal implementation details of how this provider functions. Use of the provider pattern is an advanced subject, primarily for framework use. Most apps should use conventions, not the provider pattern.

Implementations of the <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider> interface "wrap" one another, where each implementation calls <xref:Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider.OnProvidersExecuting%2A> in ascending order based on its <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider.Order> property. The <xref:Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider.OnProvidersExecuted%2A> method is then called in reverse order. The framework defines several providers:

First (`Order=-1000`):

* `DefaultApplicationModelProvider`

Then (`Order=-990`):

* `AuthorizationApplicationModelProvider`
* `CorsApplicationModelProvider`

> [!NOTE]
> The order in which two providers with the same value for `Order` are called is undefined and shouldn't be relied upon.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider> is an advanced concept for framework authors to extend. In general, apps should use conventions, and frameworks should use providers. The key distinction is that providers always run before conventions.

The `DefaultApplicationModelProvider` establishes many of the default behaviors used by ASP.NET Core MVC. Its responsibilities include:

* Adding global filters to the context
* Adding controllers to the context
* Adding public controller methods as actions
* Adding action method parameters to the context
* Applying route and other attributes

Some built-in behaviors are implemented by the `DefaultApplicationModelProvider`. This provider is responsible for constructing the <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel>, which in turn references <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel>, <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel>, and <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel> instances. The `DefaultApplicationModelProvider` class is an internal framework implementation detail that may change in the future.

The `AuthorizationApplicationModelProvider` is responsible for applying the behavior associated with the <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> and <xref:Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter> attributes. For more information, see <xref:security/authorization/simple>.

The `CorsApplicationModelProvider` implements behavior associated with <xref:Microsoft.AspNetCore.Cors.Infrastructure.IEnableCorsAttribute> and <xref:Microsoft.AspNetCore.Cors.Infrastructure.IDisableCorsAttribute>. For more information, see <xref:security/cors>.

Information on the framework's internal providers described in this section aren't available via the [.NET API browser](/dotnet/api/). However, the providers may be inspected in the [ASP.NET Core reference source (dotnet/aspnetcore GitHub repository)](https://github.com/dotnet/aspnetcore). Use GitHub search to find the providers by name and select the version of the source with the **Switch branches/tags** dropdown list.

## Conventions

The application model defines convention abstractions that provide a simpler way to customize the behavior of the models than overriding the entire model or provider. These abstractions are the recommended way to modify an app's behavior. Conventions provide a way to write code that dynamically applies customizations. While [filters](xref:mvc/controllers/filters) provide a means of modifying the framework's behavior, customizations permit control over how the whole app works together.

The following conventions are available:

* <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>
* <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention>
* <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention>
* <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IParameterModelConvention>

Conventions are applied by adding them to MVC options or by implementing attributes and applying them to controllers, actions, or action parameters (similar to [filters](xref:mvc/controllers/filters)).Unlike filters, conventions are only executed when the app is starting, not as part of each request.

> [!NOTE]
> For information on Razor Pages route and application model provider conventions, see <xref:razor-pages/razor-pages-conventions>.

## Modify the `ApplicationModel`

The following convention is used to add a property to the application model:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/ApplicationDescription.cs)]

Application model conventions are applied as options when MVC is added in `Startup.ConfigureServices`:

[!code-csharp[](./application-model/sample/src/AppModelSample/Startup.cs?name=ConfigureServices&highlight=5)]

Properties are accessible from the <xref:Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties?displayProperty=nameWithType> collection within controller actions:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/AppModelController.cs?name=AppModelController)]

## Modify the `ControllerModel` description

The controller model can also include custom properties. Custom properties override existing properties with the same name specified in the application model. The following convention attribute adds a description at the controller level:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/ControllerDescriptionAttribute.cs)]

This convention is applied as an attribute on a controller:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/DescriptionAttributesController.cs?name=ControllerDescription&highlight=1)]

## Modify the `ActionModel` description

A separate attribute convention can be applied to individual actions, overriding behavior already applied at the application or controller level:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/ActionDescriptionAttribute.cs)]

Applying this to an action within the controller demonstrates how it overrides the controller-level convention:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/DescriptionAttributesController.cs?name=DescriptionAttributesController&highlight=9)]

## Modify the `ParameterModel`

The following convention can be applied to action parameters to modify their <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo>. The following convention requires that the parameter be a route parameter. Other potential binding sources, such as query string values, are ignored:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/MustBeInRouteParameterModelConvention.cs)]

The attribute may be applied to any action parameter:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/ParameterModelController.cs?name=ParameterModelController&highlight=5)]

To apply the convention to all action parameters, add the `MustBeInRouteParameterModelConvention` to <xref:Microsoft.AspNetCore.Mvc.MvcOptions> in `Startup.ConfigureServices`:

```csharp
options.Conventions.Add(new MustBeInRouteParameterModelConvention());
```

## Modify the `ActionModel` name

The following convention modifies the <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel> to update the *name* of the action to which it's applied. The new name is provided as a parameter to the attribute. This new name is used by routing, so it affects the route used to reach this action method:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/CustomActionNameAttribute.cs)]

This attribute is applied to an action method in the `HomeController`:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/HomeController.cs?name=ActionModelConvention&highlight=2)]

Even though the method name is `SomeName`, the attribute overrides the MVC convention of using the method name and replaces the action name with `MyCoolAction`. Thus, the route used to reach this action is `/Home/MyCoolAction`.

> [!NOTE]
> This example in this section is essentially the same as using the built-in <xref:Microsoft.AspNetCore.Mvc.ActionNameAttribute>.

## Custom routing convention

Use an <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention> to customize how routing works. For example, the following convention incorporates controllers' namespaces into their routes, replacing `.` in the namespace with `/` in the route:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/NamespaceRoutingConvention.cs)]

The convention is added as an option in `Startup.ConfigureServices`:

[!code-csharp[](./application-model/sample/src/AppModelSample/Startup.cs?name=ConfigureServices&highlight=6)]

> [!TIP]
> Add conventions to [middleware](xref:fundamentals/middleware/index) via <xref:Microsoft.AspNetCore.Mvc.MvcOptions> using the following approach. The `{CONVENTION}` placeholder is the convention to add:
>
> ```csharp
> services.Configure<MvcOptions>(c => c.Conventions.Add({CONVENTION}));
> ```

The following example applies a convention to routes that aren't using attribute routing where the controller has  `Namespace` in its name:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/NamespaceRoutingController.cs?highlight=7-8)]

:::moniker range="<= aspnetcore-2.2"

## Application model usage in `WebApiCompatShim`

ASP.NET Core MVC uses a different set of conventions from ASP.NET Web API 2. Using custom conventions, you can modify an ASP.NET Core MVC app's behavior to be consistent with that of a web API app. Microsoft ships the [`WebApiCompatShim` NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.WebApiCompatShim) specifically for this purpose.

> [!NOTE]
> For more information on migration from ASP.NET Web API, see <xref:migration/webapi>.

To use the Web API Compatibility Shim:

* Add the `Microsoft.AspNetCore.Mvc.WebApiCompatShim` package to the project.
* Add the conventions to MVC by calling <xref:Microsoft.Extensions.DependencyInjection.WebApiCompatShimMvcBuilderExtensions.AddWebApiConventions%2A> in `Startup.ConfigureServices`:

```csharp
services.AddMvc().AddWebApiConventions();
```

The conventions provided by the shim are only applied to parts of the app that have had certain attributes applied to them. The following four attributes are used to control which controllers should have their conventions modified by the shim's conventions:

* <xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiActionConventionsAttribute>
* <xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiOverloadingAttribute>
* <xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiParameterConventionsAttribute>
* <xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiRoutesAttribute>

### Action conventions

<xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiActionConventionsAttribute> is used to map the HTTP method to actions based on their name (for instance, `Get` would map to `HttpGet`). It only applies to actions that don't use attribute routing.

### Overloading

<xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiOverloadingAttribute> is used to apply the <xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiOverloadingApplicationModelConvention> convention. This convention adds an <xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint> to the action selection process, which limits candidate actions to those for which the request satisfies all non-optional parameters.

### Parameter conventions

<xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiParameterConventionsAttribute> is used to apply the <xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiParameterConventionsApplicationModelConvention> action convention. This convention specifies that simple types used as action parameters are bound from the URI by default, while complex types are bound from the request body.

### Routes

<xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiRoutesAttribute> controls whether the `WebApiApplicationModelConvention` controller convention is applied. When enabled, this convention is used to add support for [areas](xref:mvc/controllers/areas) to the route and indicates the controller is in the `api` area.

In addition to a set of conventions, the compatibility package includes a <xref:System.Web.Http.ApiController?displayProperty=fullName> base class that replaces the one provided by web API. This allows your web API controllers written for web API and inheriting from its `ApiController` to work while running on ASP.NET Core MVC. All of the [`UseWebApi*`](xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim) attributes listed earlier are applied to the base controller class. The `ApiController` exposes properties, methods, and result types that are compatible with those found in web API.

:::moniker-end

## Use `ApiExplorer` to document an app

The application model exposes an <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel> property at each level that can be used to traverse the app's structure. This can be used to [generate help pages for web APIs using tools like Swagger](xref:tutorials/web-api-help-pages-using-swagger). The `ApiExplorer` property exposes an <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel.IsVisible> property that can be set to specify which parts of the app's model should be exposed. Configure this setting using a convention:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/EnableApiExplorerApplicationConvention.cs)]

Using this approach (and additional conventions if required), API visibility is enabled or disabled at any level within an app.
