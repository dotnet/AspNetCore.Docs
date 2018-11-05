---
title: Using web API conventions
author: pranavkm
description: Learn about web API conventions
ms.author: pranavkm
ms.custom: mvc
ms.date: 11/05/2018
uid: web-api/api-conventions
monikerRange: '>= aspnetcore-2.2'
---
# Learn about web API conventions

ASP.NET Core 2.2 introduces a way to extract common [API documentation](xref:tutorials/web-api-help-pages-using-swagger) and apply it to multiple actions, controllers, or all controllers within an assembly. Web API conventions are a substitute for decorating individual actions with <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute>. It allows you to define the most common "conventional" return types and status codes that you return from your action with a way to select the convention method that applies to an action.

By default, ASP.NET Core MVC 2.2 ships with a set of default conventions, <xref:Microsoft.AspNetCore.Mvc.DefaultApiConventions>, that is based on the controller that ASP.NET Core scaffolds. If your actions follow the pattern that scaffolding produces, you should be successful using the default conventions.

At runtime, ApiExplorer understand conventions. ApiExplorer is MVC’s abstraction to communicate with Open API document generators. Attributes from the applied convention get associated with an action and will be included in action’s Swagger documentation. API analyzers also understand conventions. If your action is unconventional i.e. it returns a status code that is not documented by the applied convention, it will produce a warning, encouraging you to document it.

## Apply web API conventions

There are three ways to apply a convention. Conventions do not compose, each action may be associated with exactly one convention. More specific convention (detailed below) take precedence over less specific ones, and the selection is non deterministic when two or more conventions of the same priority apply to an action. Listed below are the ways to apply a convention to an action, from the most specific to the least specific:

1. <xref:Microsoft.AspNetCore.Mvc.ApiConventionMethodAttribute> - Applies to individual actions and specifies the convention type and the convention method that applies. In the sample below, the convention method <xref:Microsoft.AspNetCore.Mvc.DefaultApiConventions.Put> is applied to the `Update` action:

[!code-csharp[](api-conventions/sample/Controllers/ContactsConventionController.cs?name=apiconventionmethod&highlight=2-3)]

2. <xref:Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute> applied to a controller - Applies the convention type to all actions on the controller. Convention methods are decoarated with hints that determine which actions it would apply to (details as part of authoring conventions).

[!code-csharp[](api-conventions/sample/Controllers/ContactsConventionController.cs?name=apiconventiontypeattribute)]

3.. <xref:Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute> applied to an assembly - Applies the convention type to all controllers in the current assembly. For example:

[!code-csharp[](api-conventions/sample/Startup.cs?name=apiconventiontypeattribute)]


## Create web API conventions

A convention is a static type with methods. These methods are annotated with <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> or <xref:Microsoft.AspNetCore.Mvc.ProducesDefaultResponseTypeAttribute> attributes.

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

Applying this convention to an assembly would result in the convention method applying to any action with the name Find and having exactly one parameter named id, as long as they do not have other more specific metadata attributes.

In addition to ProducesResponseType and ProducesDefaultResponseType, two additional attributes – <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionNameMatchAttribute> and <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionTypeMatchAttribute> – can be applied to the convention method that determines the methods they apply to.

```csharp
[ProducesResponseType(200)]
[ProducesResponseType(404)]
[ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
public static void Find(
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
    int id)
{ }
```

* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionNameMatchBehavior.Prefix> option applied to the method, indicates that the convention can match any action as long as it starts with the prefix “Find”. This will include methods such as Find, FindPet, or FindById.

* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionNameMatchBehavior.Suffix> applied to the parameter, indicates that the convention can match methods with exactly one parameter that terminate in the suffix id. This will include parameters such as id, or petId. ApiConventionTypeMatch can be similarly applied to types to constrain the type of the parameter. A params[] arguments can be used to indicate remaining parameters that do not need not be explicitly matched.
