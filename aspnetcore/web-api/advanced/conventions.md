---
title: Use web API conventions
author: tdykstra
description: Learn about web API conventions in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
uid: web-api/advanced/conventions
---
# Use web API conventions

Common [API documentation](xref:tutorials/web-api-help-pages-using-swagger) can be extracted and applied to multiple actions, controllers, or all controllers within an assembly. Web API conventions are a substitute for decorating individual actions with [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute).

A convention allows you to:

* Define the most common return types and status codes returned from a specific type of action.
* Identify actions that deviate from the defined standard.

Default conventions are available from <xref:Microsoft.AspNetCore.Mvc.DefaultApiConventions?displayProperty=fullName>. The conventions are demonstrated with the `ValuesController.cs` added to an **API** project template:

[!code-csharp[](conventions/ValuesController.cs)]

Actions that follow the patterns in the `ValuesController.cs` work with the default conventions. If the default conventions don't meet your needs, see [Create web API conventions](#create-web-api-conventions).

At runtime, <xref:Microsoft.AspNetCore.Mvc.ApiExplorer> understands conventions. `ApiExplorer` is MVC's abstraction to communicate with [OpenAPI](https://www.openapis.org/) (also known as Swagger) document generators. Attributes from the applied convention are associated with an action and are included in the action's OpenAPI documentation. [API analyzers](xref:web-api/advanced/analyzers) also understand conventions. If your action is unconventional (for example, it returns a status code that isn't documented by the applied convention), a warning encourages you to document the status code.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/conventions/sample) ([how to download](xref:index#how-to-download-a-sample))

## Apply web API conventions

Conventions don't compose; each action may be associated with exactly one convention. More specific conventions take precedence over less specific conventions. The selection is non-deterministic when two or more conventions of the same priority apply to an action. The following options exist to apply a convention to an action, from the most specific to the least specific:

1. `Microsoft.AspNetCore.Mvc.ApiConventionMethodAttribute` &mdash; Applies to individual actions and specifies the convention type and the convention method that applies.

    In the following example, the default convention type's `Microsoft.AspNetCore.Mvc.DefaultApiConventions.Put` convention method is applied to the `Update` action:

    [!code-csharp[](conventions/sample/Controllers/ContactsConventionController.cs?name=snippet_ApiConventionMethod&highlight=3)]

    The `Microsoft.AspNetCore.Mvc.DefaultApiConventions.Put` convention method applies the following attributes to the action:

    ```csharp
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    ```

    For more information on `[ProducesDefaultResponseType]`, see [Default Response](https://swagger.io/docs/specification/describing-responses/#default).

1. `Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute` applied to a controller &mdash; Applies the specified convention type to all actions on the controller. A convention method is marked with hints that determine the actions to which the convention method applies. For more information on hints, see [Create web API conventions](#create-web-api-conventions)).

    In the following example, the default set of conventions is applied to all actions in *ContactsConventionController*:

    [!code-csharp[](conventions/sample/Controllers/ContactsConventionController.cs?name=snippet_ApiConventionTypeAttribute&highlight=2)]

1. `Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute` applied to an assembly &mdash; Applies the specified convention type to all controllers in the current assembly. As a recommendation, apply assembly-level attributes in the `Startup.cs` file.

    In the following example, the default set of conventions is applied to all controllers in the assembly:

    [!code-csharp[](conventions/sample/Startup.cs?name=snippet_ApiConventionTypeAttribute&highlight=1)]

## Create web API conventions

If the default API conventions don't meet your needs, create your own conventions. A convention is:

* A static type with methods.
* Capable of defining [response types](#response-types) and [naming requirements](#naming-requirements) on actions.

### Response types

These methods are annotated with `[ProducesResponseType]` or `[ProducesDefaultResponseType]` attributes. For example:

```csharp
public static class MyAppConventions
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static void Find(int id)
    {
    }
}
```

If more specific metadata attributes are absent, applying this convention to an assembly enforces that:

* The convention method applies to any action named `Find`.
* A parameter named `id` is present on the `Find` action.

### Naming requirements

The `[ApiConventionNameMatch]` and `[ApiConventionTypeMatch]` attributes can be applied to the convention method that determines the actions to which they apply. For example:

```csharp
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
public static void Find(
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
    int id)
{ }
```

In the preceding example:

* The `Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionNameMatchBehavior.Prefix` option applied to the method indicates that the convention matches any action prefixed with "Find". Examples of matching actions include `Find`, `FindPet`, and `FindById`.
* The `Microsoft.AspNetCore.Mvc.ApiExplorer.ApiConventionNameMatchBehavior.Suffix` applied to the parameter indicates that the convention matches methods with exactly one parameter ending in the suffix identifier. Examples include parameters such as `id` or `petId`. `ApiConventionTypeMatch` can be similarly applied to types to constrain the parameter type. A `params[]` argument indicates remaining parameters that don't need to be explicitly matched.

## Additional resources

* [Video: Create metadata for NSwagClient](/shows/beginners-series-to-web-apis/generating-api-clients-17-of-18--beginners-series-to-web-apis)
* [Video: Beginner's Series to: Web APIs](/shows/beginners-series-to-web-apis/)
* <xref:web-api/advanced/analyzers>
* <xref:tutorials/web-api-help-pages-using-swagger>
