---
title: System.Web adapters
description: System.Web adapters
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
uid: migration/inc/adapters
---

# System.Web adapters

The main use case of the adapters in the [dotnet/systemweb-adapters](https://github.com/dotnet/systemweb-adapters) repository is to help developers who have taken a reliance on `System.Web` types within their class libraries as they want to move to ASP.NET Core.

An important feature of the adapters is the adapters allow the library to be used from ***both*** ASP.NET Framework and ASP.NET Core projects. Updating multiple ASP.NET Framework apps to ASP.NET Core often involves intermediate states where not all the apps have been fully updated. By using the `System.Web` adapters, the library can be used both from ASP.NET Core callers and ASP.NET Framework callers that haven't been upgraded.

Let's take a look at an example using the adapters moving from .NET Framework to ASP.NET Core.

### ASP.NET Framework
Consider a controller that does something such as:

```cs
public class SomeController : Controller
{
  public ActionResult Index()
  {
    SomeOtherClass.SomeMethod(HttpContext.Current);
  }
}
```

which then has logic in a separate assembly passing that <xref:System.Web.HttpContext> around until finally, some inner method does some logic on it such as:

```cs
public class Class2
{
  public bool PerformSomeCheck(HttpContext context)
  {
    return context.Request.Headers["SomeHeader"] == "ExpectedValue";
  }
}
```

### ASP.NET Core

In order to run the above logic in ASP.NET Core, a developer will need to add the `Microsoft.AspNetCore.SystemWebAdapters` package, that will enable the projects to work on both platforms.

The libraries would need to be updated to understand the adapters, but it will be as simple as adding the package and recompiling. If these are the only dependencies a system has on `System.Web.dll`, then the libraries will be able to target [.NET Standard 2.0](/dotnet/standard/net-standard?tabs=net-standard-2-0) to facilitate a simpler building process while migrating.

The controller in ASP.NET Core will now look like this:

```cs
public class SomeController : Controller
{
  [Route("/")]
  public IActionResult Index()
  {
    SomeOtherClass.SomeMethod(HttpContext);
  }
}
```

Notice that since there's a <xref:Microsoft.AspNetCore.Mvc.ControllerBase.HttpContext> property, they can pass that through, but it generally looks the same. Using implicit conversions, the <xref:Microsoft.AspNetCore.Http.HttpContext> can be converted into the adapter that could then be passed around through the levels utilizing the code in the same way.

## See also

* <xref:migration/inc/unit-testing>
