---
title: Get started with the Data Protection APIs in ASP.NET Core
author: rick-anderson
description: Learn how to use the ASP.NET Core data protection APIs for protecting and unprotecting data in an app.
ms.author: riande
ms.date: 11/12/2019
uid: security/data-protection/using-data-protection
---
# Get started with the Data Protection APIs in ASP.NET Core

<a name="security-data-protection-getting-started"></a>

Basically, protecting data consists of the following steps:

1. Create a data protector from a data protection provider.
1. Call the `Protect` method with the data you want to protect.
1. Call the `Unprotect` method with the data you want to turn back into plain text.

Most frameworks and app models, such as ASP.NET Core or SignalR, already configure the data protection system and add it to a service container that is accessed via [dependency injection](xref:fundamentals/dependency-injection). The following sample demonstrates:

* Configuring a service container for dependency injection and registering the data protection stack.
* Receiving the data protection provider via DI.
* Creating a protector.
* Protecting then unprotecting data.

[!code-csharp[](../../security/data-protection/using-data-protection/samples/protectunprotect.cs?highlight=26,34,35,36,37,38,39,40)]

When you create a protector you must provide one or more [Purpose Strings](xref:security/data-protection/consumer-apis/purpose-strings). A purpose string provides isolation between consumers. For example, a protector created with a purpose string of "green" wouldn't be able to unprotect data provided by a protector with a purpose of "purple".

>[!TIP]
> Instances of `IDataProtectionProvider` and `IDataProtector` are thread-safe for multiple callers. It's intended that once a component gets a reference to an `IDataProtector` via a call to `CreateProtector`, it will use that reference for multiple calls to `Protect` and `Unprotect`.
>
>A call to `Unprotect` will throw CryptographicException if the protected payload cannot be verified or deciphered. Some components may wish to ignore errors during unprotect operations; a component which reads authentication cookies might handle this error and treat the request as if it had no cookie at all rather than fail the request outright. Components which want this behavior should specifically catch CryptographicException instead of swallowing all exceptions.

<a name="add-opt"></a>

## Use AddOptions to configure custom repository

Consider the following code which uses a service provider because the implementation of `IXmlRepository` has a dependency on a singleton service:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...

    var sp = services.BuildServiceProvider();
    services.AddDataProtection()
      .AddKeyManagementOptions(o => o.XmlRepository = sp.GetService<IXmlRepository>());
}
```

The preceding code logs the following warning:

  *Calling 'BuildServiceProvider' from application code results in an additional copy of singleton services being created. Consider alternatives such as dependency injecting services as parameters to 'Configure'.*

The following code provides the `IXmlRepository` implementation without having to build the service provider and therefore making additional copies of singleton services:

[!code-csharp[](~/security/data-protection/using-data-protection/samples/CustomXMLrepo/CustomXMLrepo/Startup.cs?name=snippet)]

The preceding code removes the call to `GetService` and hides `IConfigureOptions<T>`.

The following code shows the custom XML repository:

[!code-csharp[](~/security/data-protection/using-data-protection/samples/CustomXMLrepo/CustomXMLrepo/CustomXmlRepository.cs)]

The following code shows the XmlKey class:

[!code-csharp[](~/security/data-protection/using-data-protection/samples/CustomXMLrepo/CustomXMLrepo/XmlKey.cs?name=snippet)]