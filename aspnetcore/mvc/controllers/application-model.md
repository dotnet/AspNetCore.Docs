---
title: Work with the application model in ASP.NET Core
author: ardalis
description: Learn how to read and manipulate the application model to modify how MVC elements behave in ASP.NET Core.
ms.author: riande
ms.date: 12/05/2019
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: mvc/controllers/application-model
---
# Work with the application model in ASP.NET Core

By [Steve Smith](https://ardalis.com/)

ASP.NET Core MVC defines an *application model* representing the components of an MVC app. You can read and manipulate this model to modify how MVC elements behave. By default, MVC follows certain conventions to determine which classes are considered to be controllers, which methods on those classes are actions, and how parameters and routing behave. You can customize this behavior to suit your app's needs by creating your own conventions and applying them globally or as attributes.

## Models and Providers

The ASP.NET Core MVC application model include both abstract interfaces and concrete implementation classes that describe an MVC application. This model is the result of MVC discovering the app's controllers, actions, action parameters, routes, and filters according to default conventions. By working with the application model, you can modify your app to follow different conventions from the default MVC behavior. The parameters, names, routes, and filters are all used as configuration data for actions and controllers.

The ASP.NET Core MVC Application Model has the following structure:

* ApplicationModel
  * Controllers (ControllerModel)
    * Actions (ActionModel)
      * Parameters (ParameterModel)

Each level of the model has access to a common `Properties` collection, and lower levels can access and overwrite property values set by higher levels in the hierarchy. The properties are persisted to the `ActionDescriptor.Properties` when the actions are created. Then when a request is being handled, any properties a convention added or modified can be accessed through `ActionContext.ActionDescriptor.Properties`. Using properties is a great way to configure your filters, model binders, etc. on a per-action basis.

> [!NOTE]
> The `ActionDescriptor.Properties` collection isn't thread safe (for writes) once app startup has finished. Conventions are the best way to safely add data to this collection.

### IApplicationModelProvider

ASP.NET Core MVC loads the application model using a provider pattern, defined by the [IApplicationModelProvider](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.iapplicationmodelprovider) interface. This section covers some of the internal implementation details of how this provider functions. This is an advanced topic - most apps that leverage the application model should do so by working with conventions.

Implementations of the `IApplicationModelProvider` interface "wrap" one another, with each implementation calling `OnProvidersExecuting` in ascending order based on its `Order` property. The `OnProvidersExecuted` method is then called in reverse order. The framework defines several providers:

First (`Order=-1000`):

* [`DefaultApplicationModelProvider`](/dotnet/api/microsoft.aspnetcore.mvc.internal.defaultapplicationmodelprovider)

Then (`Order=-990`):

* [`AuthorizationApplicationModelProvider`](/dotnet/api/microsoft.aspnetcore.mvc.internal.authorizationapplicationmodelprovider)
* [`CorsApplicationModelProvider`](/dotnet/api/microsoft.aspnetcore.mvc.cors.internal.corsapplicationmodelprovider)

> [!NOTE]
> The order in which two providers with the same value for `Order` are called is undefined, and therefore shouldn't be relied upon.

> [!NOTE]
> `IApplicationModelProvider` is an advanced concept for framework authors to extend. In general, apps should use conventions and frameworks should use providers. The key distinction is that providers always run before conventions.

The `DefaultApplicationModelProvider` establishes many of the default behaviors used by ASP.NET Core MVC. Its responsibilities include:

* Adding global filters to the context
* Adding controllers to the context
* Adding public controller methods as actions
* Adding action method parameters to the context
* Applying route and other attributes

Some built-in behaviors are implemented by the `DefaultApplicationModelProvider`. This provider is responsible for constructing the [`ControllerModel`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.controllermodel), which in turn references [`ActionModel`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.actionmodel), [`PropertyModel`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.propertymodel), and [`ParameterModel`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.parametermodel) instances. The `DefaultApplicationModelProvider` class is an internal framework implementation detail that can and will change in the future. 

The `AuthorizationApplicationModelProvider` is responsible for applying the behavior associated with the `AuthorizeFilter` and `AllowAnonymousFilter` attributes. [Learn more about these attributes](xref:security/authorization/simple).

The `CorsApplicationModelProvider` implements behavior associated with the `IEnableCorsAttribute` and `IDisableCorsAttribute`, and the `DisableCorsAuthorizationFilter`. [Learn more about CORS](xref:security/cors).

## Conventions

The application model defines convention abstractions that provide a simpler way to customize the behavior of the models than overriding the entire model or provider. These abstractions are the recommended way to modify your app's behavior. Conventions provide a way for you to write code that will dynamically apply customizations. While [filters](xref:mvc/controllers/filters) provide a means of modifying the framework's behavior, customizations let you control how the whole app works together.

The following conventions are available:

* [`IApplicationModelConvention`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.iapplicationmodelconvention)
* [`IControllerModelConvention`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.icontrollermodelconvention)
* [`IActionModelConvention`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.iactionmodelconvention)
* [`IParameterModelConvention`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.iparametermodelconvention)

Conventions are applied by adding them to MVC options or by implementing `Attribute`s and applying them to controllers, actions, or action parameters (similar to [`Filters`](xref:mvc/controllers/filters)). Unlike filters, conventions are only executed when the app is starting, not as part of each request.

### Sample: Modifying the ApplicationModel

The following convention is used to add a property to the application model. 

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/ApplicationDescription.cs)]

Application model conventions are applied as options when MVC is added in `ConfigureServices` in `Startup`.

[!code-csharp[](./application-model/sample/src/AppModelSample/Startup.cs?name=ConfigureServices&highlight=5)]

Properties are accessible from the `ActionDescriptor` properties collection within controller actions:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/AppModelController.cs?name=AppModelController)]

### Sample: Modifying the ControllerModel Description

As in the previous example, the controller model can also be modified to include custom properties. These will override existing properties with the same name specified in the application model. The following convention attribute adds a description at the controller level:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/ControllerDescriptionAttribute.cs)]

This convention is applied as an attribute on a controller.

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/DescriptionAttributesController.cs?name=ControllerDescription&highlight=1)]

The "description" property is accessed in the same manner as in previous examples.

### Sample: Modifying the ActionModel Description

A separate attribute convention can be applied to individual actions, overriding behavior already applied at the application or controller level.

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/ActionDescriptionAttribute.cs)]

Applying this to an action within the previous example's controller demonstrates how it overrides the controller-level convention:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/DescriptionAttributesController.cs?name=DescriptionAttributesController&highlight=9)]

### Sample: Modifying the ParameterModel

The following convention can be applied to action parameters to modify their `BindingInfo`. The following convention requires that the parameter be a route parameter; other potential binding sources (such as query string values) are ignored.

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/MustBeInRouteParameterModelConvention.cs)]

The attribute may be applied to any action parameter:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/ParameterModelController.cs?name=ParameterModelController&highlight=5)]

### Sample: Modifying the ActionModel Name

The following convention modifies the `ActionModel` to update the *name* of the action to which it's applied. The new name is provided as a parameter to the attribute. This new name is used by routing, so it will affect the route used to reach this action method.

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/CustomActionNameAttribute.cs)]

This attribute is applied to an action method in the `HomeController`:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/HomeController.cs?name=ActionModelConvention&highlight=2)]

Even though the method name is `SomeName`, the attribute overrides the MVC convention of using the method name and replaces the action name with `MyCoolAction`. Thus, the route used to reach this action is `/Home/MyCoolAction`.

> [!NOTE]
> This example is essentially the same as using the built-in [ActionName](/dotnet/api/microsoft.aspnetcore.mvc.actionnameattribute) attribute.

### Sample: Custom Routing Convention

You can use an `IApplicationModelConvention` to customize how routing works. For example, the following convention will incorporate Controllers' namespaces into their routes, replacing `.` in the namespace with `/` in the route:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/NamespaceRoutingConvention.cs)]

The convention is added as an option in Startup.

[!code-csharp[](./application-model/sample/src/AppModelSample/Startup.cs?name=ConfigureServices&highlight=6)]

> [!TIP]
> You can add conventions to your [middleware](xref:fundamentals/middleware/index) by accessing `MvcOptions` using `services.Configure<MvcOptions>(c => c.Conventions.Add(YOURCONVENTION));`

This sample applies this convention to routes that are not using attribute routing where the controller has  "Namespace" in its name. The following controller demonstrates this convention:

[!code-csharp[](./application-model/sample/src/AppModelSample/Controllers/NamespaceRoutingController.cs?highlight=7-8)]

## Application Model Usage in WebApiCompatShim

ASP.NET Core MVC uses a different set of conventions from ASP.NET Web API 2. Using custom conventions, you can modify an ASP.NET Core MVC app's behavior to be consistent with that of a Web API app. Microsoft ships the [WebApiCompatShim](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.WebApiCompatShim/) specifically for this purpose.

> [!NOTE]
> Learn more about [migration from ASP.NET Web API](xref:migration/webapi).

To use the Web API Compatibility Shim, you need to add the package to your project and then add the conventions to MVC by calling `AddWebApiConventions` in `Startup`:

```csharp
services.AddMvc().AddWebApiConventions();
```

The conventions provided by the shim are only applied to parts of the app that have had certain attributes applied to them. The following four attributes are used to control which controllers should have their conventions modified by the shim's conventions:

* [UseWebApiActionConventionsAttribute](/dotnet/api/microsoft.aspnetcore.mvc.webapicompatshim.usewebapiactionconventionsattribute)
* [UseWebApiOverloadingAttribute](/dotnet/api/microsoft.aspnetcore.mvc.webapicompatshim.usewebapioverloadingattribute)
* [UseWebApiParameterConventionsAttribute](/dotnet/api/microsoft.aspnetcore.mvc.webapicompatshim.usewebapiparameterconventionsattribute)
* [UseWebApiRoutesAttribute](/dotnet/api/microsoft.aspnetcore.mvc.webapicompatshim.usewebapiroutesattribute)

### Action Conventions

The `UseWebApiActionConventionsAttribute` is used to map the HTTP method to actions based on their name (for instance, `Get` would map to `HttpGet`). It only applies to actions that don't use attribute routing.

### Overloading

The `UseWebApiOverloadingAttribute` is used to apply the `WebApiOverloadingApplicationModelConvention` convention. This convention adds an `OverloadActionConstraint` to the action selection process, which limits candidate actions to those for which the request satisfies all non-optional parameters.

### Parameter Conventions

The `UseWebApiParameterConventionsAttribute` is used to apply the `WebApiParameterConventionsApplicationModelConvention` action convention. This convention specifies that simple types used as action parameters are bound from the URI by default, while complex types are bound from the request body.

### Routes

The `UseWebApiRoutesAttribute` controls whether the `WebApiApplicationModelConvention` controller convention is applied. When enabled, this convention is used to add support for [areas](xref:mvc/controllers/areas) to the route.

In addition to a set of conventions, the compatibility package includes a `System.Web.Http.ApiController` base class that replaces the one provided by Web API. This allows your controllers written for Web API and inheriting from its `ApiController` to work as they were designed, while running on ASP.NET Core MVC. All of the `UseWebApi*` attributes listed earlier are applied to the base controller class. The `ApiController` exposes properties, methods, and result types that are compatible with those found in Web API.

## Using ApiExplorer to Document Your App

The application model exposes an [`ApiExplorer`](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.apiexplorermodel) property at each level that can be used to traverse the app's structure. This can be used to [generate help pages for your Web APIs using tools like Swagger](xref:tutorials/web-api-help-pages-using-swagger). The `ApiExplorer` property exposes an `IsVisible` property that can be set to specify which parts of your app's model should be exposed. You can configure this setting using a convention:

[!code-csharp[](./application-model/sample/src/AppModelSample/Conventions/EnableApiExplorerApplicationConvention.cs)]

Using this approach (and additional conventions if required), you can enable or disable API visibility at any level within your app. 
