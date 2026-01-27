---
title: "Breaking change: API controller actions try to infer parameters from DI"
description: Learn about the breaking change in ASP.NET Core 7.0 where API controller actions try to infer parameters from DI.
ms.date: 03/04/2022
ms.custom: https://github.com/aspnet/Announcements/issues/480
---

# API controller actions try to infer parameters from DI

The mechanism to infer binding sources of API controller action parameters now marks parameters to be bound from the Dependency Injection (DI) container when the type is registered in the container. In rare cases, this can break apps that have a type in DI that is also accepted in API controller action methods.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

If you wanted to bind a type registered in the DI container, it must be explicitly decorated using an attribute that implements <xref:Microsoft.AspNetCore.Http.Metadata.IFromServiceMetadata>, such as <xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute>:

```csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    public ActionResult Get([FromServices]SomeCustomType service) => Ok();
}
```

If the attribute wasn't specified, the parameter was resolved from the request body sent by the client:

```csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    // Bind from the request body
    [HttpPost]
    public ActionResult Post(SomeCustomType service) => Ok();
}
```

## New behavior

Types in DI are checked at app startup using <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> to determine if an argument in an API controller action comes from DI or from other sources.

In the following example, which assumes you're using the default DI container, `SomeCustomType` comes from the DI container:

``` csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    // Bind from DI
    [HttpPost]
    public ActionResult Post(SomeCustomType service) => Ok();
}
```

The mechanism to infer binding sources of API controller action parameters follows the following rules:

1. A previously specified <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingSource%2A?displayProperty=nameWithType> is never overwritten.
1. A complex type parameter registered in the DI container is assigned <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Services?displayProperty=nameWithType>.
1. A complex type parameter not registered in the DI container is assigned <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Body?displayProperty=nameWithType>.
1. A parameter with a name that appears as a route value in *any* route template is assigned <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Path?displayProperty=nameWithType>.
1. All other parameters are assigned <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Query?displayProperty=nameWithType>.

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This same behavior is already implemented in minimal APIs.

The likelihood of breaking apps is low as it isn't common to have a type in DI and as an argument in your API controller action at the same time.

## Recommended action

If you're broken by this change, you can disable the feature by setting `DisableImplicitFromServicesParameters` to true:

```csharp
Services.Configure<ApiBehaviorOptions>(options =>
{
     options.DisableImplicitFromServicesParameters = true;
});
```

If you're broken by the change, but you want to bind from DI for specific API controller action parameters, you can disable the feature as shown above and use an attribute that implements <xref:Microsoft.AspNetCore.Http.Metadata.IFromServiceMetadata>, such as <xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute>:

``` csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    // Bind from DI
    [HttpPost]
    public ActionResult Post([FromServices]SomeCustomType service) => Ok();
}
```

## Affected APIs

API controller actions
