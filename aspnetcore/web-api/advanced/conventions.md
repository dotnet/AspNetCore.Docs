---
title: Use web API conventions
author: pranavkm
description: Learn about web API conventions in ASP.NET Core.
monikerRange: '>= aspnetcore-2.2'
ms.author: pranavkm
ms.custom: mvc
ms.date: 11/13/2018
uid: web-api/advanced/conventions
---
# Use web API conventions

ASP.NET Core 2.2 introduces a way to extract common [API documentation](xref:tutorials/web-api-help-pages-using-swagger) and apply it to multiple actions, controllers, or all controllers within an assembly. Web API conventions are a substitute for decorating individual actions with [[ProducesResponseType]](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute). It allows you to define the most common "conventional" return types and status codes that you return from your action with a way to select the convention method that applies to an action.

By default, ASP.NET Core MVC 2.2 ships with a set of default conventions, `Microsoft.AspNetCore.Mvc.DefaultApiConventions`. The conventions are based on the controller that ASP.NET Core scaffolds. If your actions follow the pattern that scaffolding produces, you should be successful using the default conventions.

At runtime, <xref:Microsoft.AspNetCore.Mvc.ApiExplorer> understands conventions. `ApiExplorer` is MVC's abstraction to communicate with Open API document generators. Attributes from the applied convention get associated with an action and are included in the action's Swagger documentation. API analyzers also understand conventions. If your action is unconventional (for example, it returns a status code that isn't documented by the applied convention), it produces a warning, encouraging you to document it.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/advanced/conventions/sample) ([how to download](xref:index#how-to-download-a-sample))

## Apply web API conventions

There are three ways to apply a convention. Conventions don't compose. Each action may be associated with exactly one convention. More specific conventions (detailed below) take precedence over less specific ones. The selection is non-deterministic when two or more conventions of the same priority apply to an action. The following options exist to apply a convention to an action, from the most specific to the least specific:

1. `Microsoft.AspNetCore.Mvc.ApiConventionMethodAttribute` &mdash; Applies to individual actions and specifies the convention type and the convention method that applies. In the following sample, the convention method `Microsoft.AspNetCore.Mvc.DefaultApiConventions.Put` is applied to the `Update` action:

    [!code-csharp[](conventions/sample/Controllers/ContactsConventionController.cs?name=apiconventionmethod&highlight=2-3)]

1. `Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute` applied to a controller &mdash; Applies the convention type to all actions on the controller. Convention methods are decorated with hints that determine which actions it would apply to (details as part of authoring conventions). For example:

    [!code-csharp[](conventions/sample/Controllers/ContactsConventionController.cs?name=apiconventiontypeattribute)]

1. `Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute` applied to an assembly &mdash; Applies the convention type to all controllers in the current assembly. For example:

    [!code-csharp[](conventions/sample/Startup.cs?name=apiconventiontypeattribute)]

## Create web API conventions

A convention is a static type with methods. These methods are annotated with `[ProducesResponseType]` or `[ProducesDefaultResponseType]` attributes.

```csharp
public static class MyAppConventions
{
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public static void Find(int id)
    {
    }
}
```

Applying this convention to an assembly results in the convention method applying to any action with the name `Find` and having exactly one parameter named `id`, as long as they don't have other more specific metadata attributes.

In addition to `[ProducesResponseType]` and `[ProducesDefaultResponseType]`, `[ApiConventionNameMatch]` and `[ApiConventionTypeMatch]` can be applied to the convention method that determines the methods they apply to. For example:

```csharp
[ProducesResponseType(200)]
[ProducesResponseType(404)]
[ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
public static void Find(
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
    int id)
{ }
```

* The `Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionNameMatchBehavior.Prefix` option applied to the method, indicates that the convention can match any action as long as it's prefixed with "Find". This includes methods such as `Find`, `FindPet`, or `FindById`.
* The `Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionNameMatchBehavior.Suffix` applied to the parameter indicates that the convention can match methods with exactly one parameter ending in the suffix identifier. This includes parameters such as `id` or `petId`. `ApiConventionTypeMatch` can be similarly applied to types to constrain the type of the parameter. A `params[]` argument can be used to indicate remaining parameters that don't need to be explicitly matched.
