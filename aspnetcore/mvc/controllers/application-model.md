---
title: 🔧 Working with the Application Model | Microsoft Docs
author: ardalis
description: 
keywords: ASP.NET Core, ASP.NET Core MVC, application model
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 4eb7e52f-5665-41a4-a3e3-e348d07237f2
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/controllers/application-model
---
# Working with the Application Model

By [Steve Smith](http://ardalis.com)

ASP.NET Core MVC defines an *application model* representing the components your MVC app. You can read and manipulate this model to modify how MVC elements behave.

## Models and Providers

The ASP.NET Core MVC application models include both abstract interfaces and concrete implementations that define how MVC behaves. This behavior includes how MVC determines and uses controller names, action names, action parameters, routes, and filters. By working with the application model, you can modify your app to follow different conventions from the default MVC behavior.

ASP.NET Core MVC loads the application model using a provider pattern, defined by the [`IApplicationModelProvider`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.iapplicationmodelprovider) interface. Implementations of this interface "wrap" one another, with each implementation calling `OnProvidersExecuting` in ascending order based on its `Order` property. The `OnProvidersExecuted` method is then called in reverse order. The framework defines several providers:

First (`Order=-1000`):

* [`DefaultApplicationModelProvider`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.internal.defaultapplicationmodelprovider)

Then (`Order=-990`):

* [`AuthorizationApplicationModelProvider`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.internal.authorizationapplicationmodelprovider)
* [`CorsApplicationModelProvider`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.cors.internal.corsapplicationmodelprovider)

> [!NOTE]
> The order in which two providers with the same value for `Order` are called is undefined, and therefore should not be relied upon.

The `DefaultApplicationModelProvider` establishes many of the default behaviors used by ASP.NET Core MVC. Its responsibilities include:

* Adding global filters to the context
* Adding controllers to the context
* Adding appropriate controller methods as actions
* Adding action method parameters to the context
* Applying route and other attributes

Certain built-in MVC behaviors, such as ignoring static methods on controllers when discovering actions, are implemented in the `DefaultApplicationModelProvider` and can be overridden by replacing its behavior (for example, its virtual `IsAction` method). This provider is also responsible for constructing the [`ControllerModel`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.controllermodel), which in turn references [`ActionModel`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.actionmodel#Microsoft_AspNetCore_Mvc_ApplicationModels_ActionModel), [`PropertyModel`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.propertymodel), and [`ParameterModel`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.parametermodel#Microsoft_AspNetCore_Mvc_ApplicationModels_ParameterModel) instances.

The `AuthorizationApplicationModelProvider` is responsible for applying the behavior associated with the `AuthorizeFilter` and `AllowAnonymousFilter` attributes. [Learn more about these attributes](https://docs.microsoft.com/aspnet/core/security/authorization/simple).

The `CorsApplicationModelProvider` implements behavior associated with the `IEnableCorsAttribute` and `IDisableCorsAttribute`, and the `DisableCorsAuthorizationFilter`. [Learn more about CORS](https://docs.microsoft.com/aspnet/core/security/cors).

## Conventions

In addition to defining providers and models, the application model defines a variety of convention abstractions. These conventions provide a simpler way to customize the behavior of the models than overriding the entire model or provider, and are the recommended way to modify your app's behavior.

The following conventions are available:

* [`IActionModelConvention`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.iactionmodelconvention)
* [`IApplicationModelConvention`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.iapplicationmodelconvention)
* [`IControllerModelConvention`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.icontrollermodelconvention)
* [`IParameterModelConvention`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.applicationmodels.iparametermodelconvention)

Conventions are applied by implementing `Attribute`s and applying them to controllers or actions (similar to [`Filters`](https://docs.microsoft.com/aspnet/core/mvc/controllers/filters)).

## Sample: Modifying the ActionModel

The following convention modifies the `ActionModel` to update the *name* of the action to which it is applied. The new name is provided as a parameter to the attribute. This new name is used by routing, so it will affect the route used to reach this action method.

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Conventions/CustomActionNameAttribute.cs)]

This attribute is applied to an action method in the `HomeController`:

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Controllers/HomeController.cs?name=ActionModelConvention&highlight=2)]

Even though the method name is `SomeName`, the attribute overrides the MVC convention of using the method name and replaces the action name with `MyCoolAction`. Thus, the route used to reach this action is `/Home/MyCoolAction`.

## Sample: Modifying the ApplicationModel

The following convention is used to add a property to the application model. 

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Conventions/ApplicationDescription.cs)]

Application model conventions are applied as options when MVC is added in `ConfigureServices` in `Startup`.

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Startup.cs?name=ConfigureServices)]

Properties are accessible from the `ActionDescriptor` properties collection within controller actions:

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Controllers/AppModelController.cs?name=AppModelController)]

## Sample: Modifying the ControllerModel

As in the previous example, the controller model can also be modified to include custom properties. These will override existing properties with the same name specified in the application model. The following convention attribute adds a description at the controller level:

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Conventions/ControllerDescriptionAttribute.cs)]

This convention is applied as an attribute at the controller level.

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Controllers/DescriptionAttributesController.cs?name=ControllerDescription&highlight=1)]

The `description` property is still accessed in the same manner as in previous examples.

## Sample: Modifying the ActionModel

A separate attribute convention can be applied to individual actions, overriding behavior already applied at the application or contoller level.

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Conventions/ActionDescriptionAttribute.cs)]

Applying this to an action within the previous example's controller demonstrates how it overrides the controller-level convention:

[!code-csharp[Main](./application-model/sample/src/AppModelSample/Controllers/DescriptionAttributesController.cs?name=DescriptionAttributesController&highlight=5)]