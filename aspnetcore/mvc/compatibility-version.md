---
title: Compatibility version for ASP.NET Core MVC
author: rick-anderson
description: Discover how the Startup class in ASP.NET Core configures services and the app's request pipeline.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 9/25/2019
uid: mvc/compatibility-version
---
# Compatibility version for ASP.NET Core MVC

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-3.0"

The <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion*> method is a no-op for ASP.NET Core 3.0 apps. That is, calling `SetCompatibilityVersion` with any value of <xref:Microsoft.AspNetCore.Mvc.CompatibilityVersion> has no impact on the application.

* The next minor version of ASP.NET Core may provide a new `CompatibilityVersion` value.
* `CompatibilityVersion` values `Version_2_0` through `Version_2_2` are marked `[Obsolete(...)]`.
* See [Breaking API changes in Antiforgery, CORS, Diagnostics, Mvc, and Routing](https://github.com/aspnet/Announcements/issues/387). This list includes breaking changes for compatibility switches.

To see how `SetCompatibilityVersion` works with ASP.NET Core 2.x apps, select the [ASP.NET Core 2.2 version of this article](?view=aspnetcore-2.2&preserve-view=true).

:::moniker-end

:::moniker range="< aspnetcore-3.0"

The <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion*> method allows an ASP.NET Core 2.x app to opt-in or opt-out of potentially breaking behavior changes introduced in ASP.NET Core MVC 2.1 or 2.2. These potentially breaking behavior changes are generally in how the MVC subsystem behaves and how **your code** is called by the runtime. By opting in, you get the latest behavior, and the long-term behavior of ASP.NET Core.

The following code sets the compatibility mode to ASP.NET Core 2.2:

[!code-csharp[Main](compatibility-version/samples/2.x/CompatibilityVersionSample/Startup.cs?name=snippet1)]

We recommend you test your app using the latest version (`CompatibilityVersion.Latest`). We anticipate that most apps won't have breaking behavior changes using the latest version.

Apps that call `SetCompatibilityVersion(CompatibilityVersion.Version_2_0)` are protected from potentially breaking behavior changes introduced in the ASP.NET Core 2.1/2.2 MVC versions. This protection:

* Does not apply to all 2.1 and later changes, it's targeted to potentially breaking ASP.NET Core runtime behavior changes in the MVC subsystem.
* Does not extend to ASP.NET Core 3.0.

The default compatibility for ASP.NET Core 2.1 and 2.2 apps that do **not** call `SetCompatibilityVersion` is 2.0 compatibility. That is, not calling `SetCompatibilityVersion` is the same as calling `SetCompatibilityVersion(CompatibilityVersion.Version_2_0)`.

The following code sets the compatibility mode to ASP.NET Core 2.2, except for the following behaviors:

* <xref:Microsoft.AspNetCore.Mvc.MvcOptions.AllowCombiningAuthorizeFilters>
* <xref:Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatterExceptionPolicy>

[!code-csharp[Main](compatibility-version/samples/2.x/CompatibilityVersionSample/Startup2.cs?name=snippet1)]

For apps that encounter breaking behavior changes, using the appropriate compatibility switches:

* Allows you to use the latest release and opt out of specific breaking behavior changes.
* Gives you time to update your app so it works with the latest changes.

The <xref:Microsoft.AspNetCore.Mvc.MvcOptions> documentation has a good explanation of what changed and why the changes are an improvement for most users.

With ASP.NET Core 3.0, old behaviors supported by compatibility switches have been removed. We feel these are positive changes benefitting nearly all users. By introducing these changes in 2.1 and 2.2, most apps can benefit, while others have time to update.
:::moniker-end
