---
title: Incremental ASP.NET to ASP.NET Core Migration Usage Guidance
description: Incremental ASP.NET to ASP.NET Core Migration Usage Guidance
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/usage_guidance
---

# Usage Guidance

`Microsoft.AspNetCore.SystemWebAdapters` provides an emulation layer to mimic behavior from ASP.NET framework on ASP.NET Core. Below are some guidelines for some of the considerations when using them:

## `HttpContext` lifetime

The adapters are backed by <xref:Microsoft.AspNetCore.Http.HttpContext> which cannot be used past the lifetime of a request. Thus, <xref:System.Web.HttpContext> when run on ASP.NET Core cannot be used past a request as well, while on ASP.NET Framework it would work at times. An <xref:System.ObjectDisposedException> will be thrown in cases where it is used past a request end.

**Recommendation**: Store the values needed into a POCO and hold onto that.

## Conversion to <xref:System.Web.HttpContext>

There are two ways to convert an <xref:Microsoft.AspNetCore.Http.HttpContext> to a <xref:System.Web.HttpContext>:

- Implicit casting
- Constructor usage

**Recommendation**: For the most cases, implicit casting should be preferred as this will cache the created instance and ensure only a single <xref:System.Web.HttpContext> per request.

## <xref:System.Globalization.CultureInfo.CurrentCulture> is not set by default

In ASP.NET Framework, <xref:System.Globalization.CultureInfo.CurrentCulture> was set for a request, but this is not done automatically in ASP.NET Core. Instead, you must add the appropriate middleware to your pipeline.

**Recommendation**: See [ASP.NET Core Localization](/aspnet/core/fundamentals/localization#localization-middleware) for details on how to enable this.

Simplest way to enable this with similar behavior as ASP.NET Framework would be to add the following to your pipeline:

```csharp
app.UseRequestLocalization();
```

## <xref:System.Threading.Thread.CurrentPrincipal>

In ASP.NET Framework, <xref:System.Threading.Thread.CurrentPrincipal> and <xref:System.Security.Claims.ClaimsPrincipal.Current> would be set to the current user. This is not available on ASP.NET Core out of the box. Support for this is available with these adapters by adding the `ISetThreadCurrentPrincipal` to the endpoint (available to controllers via the `SetThreadCurrentPrincipalAttribute`). However, it should only be used if the code cannot be refactored to remove usage.

**Recommendation**: If possible, use the property <xref:Microsoft.AspNetCore.Http.HttpContext.User> or <xref:System.Web.HttpContext.User> instead by passing it through to the call site. If not possible, enable setting the current user and also consider setting the request to be a logical single thread (see below for details).

## Request thread does not exist in ASP.NET Core

In ASP.NET Framework, a request had thread-affinity and <xref:System.Web.HttpContext.Current> would only be available if on that thread. ASP.NET Core does not have this guarantee so <xref:System.Web.HttpContext.Current> will be available within the same async context, but no guarantees about threads are made.

**Recommendation**: If reading/writing to the <xref:System.Web.HttpContext>, you must ensure you are doing so in a single-threaded way. You can force a request to never run concurrently on any async context by setting the `ISingleThreadedRequestMetadata`. This will have performance implications and should only be used if you can't refactor usage to ensure non-concurrent access. There is an implementation available to add to controllers with `SingleThreadedRequestAttribute`:

```csharp
[SingleThreadedRequest]
public class SomeController : Controller
{
    ...
} 
```

## <xref:System.Web.HttpContext.Request> may need to be prebuffered

By default, the incoming request is not always seekable nor fully available. In order to get behavior seen in .NET Framework, you can opt into prebuffering the input stream. This will fully read the incoming stream and buffer it to memory or disk (depending on settings). 

**Recommendation**: This can be enabled by applying endpoint metadata that implements the `IPreBufferRequestStreamMetadata` interface. This is available as an attribute `PreBufferRequestStreamAttribute` that can be applied to controllers or methods.

To enable this on all MVC endpoints, there is an extension method that can be used as follows:

```cs
app.MapDefaultControllerRoute()
    .PreBufferRequestStream();
```

## <xref:System.Web.HttpContext.Response> may require buffering

Some APIs on <xref:System.Web.HttpContext.Response> require that the output stream is buffered, such as <xref:System.Web.HttpResponse.Output>, <xref:System.Web.HttpResponse.End>, <xref:System.Web.HttpResponse.Clear>, and <xref:System.Web.HttpResponse.SuppressContent>.

**Recommendation**: In order to support behavior for <xref:System.Web.HttpContext.Response> that requires buffering the response before sending, endpoints must opt-into it with endpoint metadata implementing `IBufferResponseStreamMetadata`.

To enable this on all MVC endpoints, there is an extension method that can be used as follows:

```cs
app.MapDefaultControllerRoute()
    .BufferResponseStream();
```

## Shared session state

In order to support <xref:System.Web.HttpContext.Session>, endpoints must opt-into it via metadata implementing `ISessionMetadata`.

**Recommendation**: To enable this on all MVC endpoints, there is an extension method that can be used as follows:

```cs
app.MapDefaultControllerRoute()
    .RequireSystemWebAdapterSession();
```

This also requires some implementation of a session store. For details of options here, see [here](xref:migration/inc/session).

## Remote session exposes additional endpoint for application

The [remote session support](xref:migration/inc/remote-session) exposes an endpoint that allows the core app to retrieve session information. This may cause a potentially long-lived request to exist between the core app and the framework app, but will time out with the current request or the session timeout (by default is 20 minutes).

**Recommendation**: Ensure the API key used is a strong one and that the connection with the framework app is done over SSL.

## Virtual directories must be identical for framework and core applications

The virtual directory setup is used for route generation, authorization, and other services within the system. At this point, no reliable method has been found to enable different virtual directories due to how ASP.NET Framework works.

**Recomendation**: Ensure your two applications are on different sites (hosts and/or ports) with the same application/virtual directory layout.
