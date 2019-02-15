---
title: Compatibility version for ASP.NET Core MVC
author: rick-anderson
description: Discover how the Startup class in ASP.NET Core configures services and the app's request pipeline.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 12/10/2018
uid: mvc/compatibility-version
---
# Compatibility version for ASP.NET Core MVC

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion*> method allows an app to opt-in or opt-out of potentially breaking behavior changes introduced in ASP.NET Core MVC 2.1 or later. These potentially breaking behavior changes are generally in how the MVC subsystem behaves and how **your code** is called by the runtime. By opting in, you get the latest behavior, and the long-term behavior of ASP.NET Core.

The following code sets the compatibility mode to ASP.NET Core 2.2:

[!code-csharp[Main](compatibility-version/samples/2.x/CompatibilityVersionSample/Startup.cs?name=snippet1)]

We recommend you test your app using the latest version (`CompatibilityVersion.Version_2_2`). We anticipate that most apps won't have breaking behavior changes using the latest version.

Apps that call `SetCompatibilityVersion(CompatibilityVersion.Version_2_0)` are protected from potentially breaking behavior changes introduced in the ASP.NET Core 2.1 MVC and later 2.x versions. This protection:

* Does not apply to all 2.1 and later changes, it's targeted to potentially breaking ASP.NET Core runtime behavior changes in the MVC subsystem.
* Does not extend to the next major version.

The default compatibility for ASP.NET Core 2.1 and later 2.x apps that do **not** call `SetCompatibilityVersion` is 2.0 compatibility. That is, not calling `SetCompatibilityVersion` is the same as calling `SetCompatibilityVersion(CompatibilityVersion.Version_2_0)`.

The following code sets the compatibility mode to ASP.NET Core 2.2, except for the following behaviors:

* [AllowCombiningAuthorizeFilters](https://docs.microsoft.com/en-gb/dotnet/api/microsoft.aspnetcore.mvc.mvcoptions?view=aspnetcore-2.2#properties)
* [InputFormatterExceptionPolicy](https://docs.microsoft.com/en-gb/dotnet/api/microsoft.aspnetcore.mvc.mvcoptions?view=aspnetcore-2.2#properties)

[!code-csharp[Main](compatibility-version/samples/2.x/CompatibilityVersionSample/Startup2.cs?name=snippet1)]

For apps that encounter breaking behavior changes, using the appropriate compatibility switches:

* Allows you to use the latest release and opt out of specific breaking behavior changes.
* Gives you time to update your app so it works with the latest changes.

The [MvcOptions](https://github.com/aspnet/AspNetCore/blob/release/2.2/src/Mvc/Mvc.Core/src/MvcOptions.cs) class source comments have a good explanation of what changed and why the changes are an improvement for most users.

At some future date, there will be an [ASP.NET Core 3.0 version](https://github.com/aspnet/Home/wiki/Roadmap). Old behaviors supported by compatibility switches will be removed in the 3.0 version. We feel these are positive changes benefitting nearly all users. By introducing these changes now, most apps can benefit now, and the others will have time to update their apps.
