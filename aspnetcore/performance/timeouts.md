---
title: Request timeouts middleware in ASP.NET Core
description: Learn how to configure and use request timeout middleware in ASP.NET Core.
author: tdykstra
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 09/25/2023
uid: performance/timeouts
---
# Request timeouts middleware in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra)

:::moniker range=">= aspnetcore-8.0"

Apps can apply timeout limits selectively to requests. ASP.NET Core servers don't do this by default since request processing times vary widely by scenario. For example, WebSockets, static files, and calling expensive APIs would each require a different timeout limit. So ASP.NET Core provides middleware that configures timeouts per endpoint as well as a global timeout.

When a timeout limit is hit, a <xref:System.Threading.CancellationToken> in <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> has <xref:System.Threading.CancellationToken.IsCancellationRequested> set to `true`. <xref:Microsoft.AspNetCore.Http.HttpContext.Abort> isn't automatically called on the request, so the application may still produce a success or failure response. The default behavior if the app doesn't handle the exception and produce a response is to return status code 504.

This article explains how to configure the timeout middleware. The timeout middleware can be used in all types of ASP.NET Core apps: Minimal API, Web API with controllers, MVC, and Razor Pages. The sample app is a Minimal API, but every timeout feature it illustrates is also supported in the other app types.

Request timeouts are in the <xref:Microsoft.AspNetCore.Http.Timeouts> namespace.

***Note:*** When an app is running in debug mode, the timeout middleware doesn't trigger. This behavior is the same as for [Kestrel timeouts](xref:fundamentals/servers/kestrel#behavior-with-debugger-attached). To test timeouts, run the app without the debugger attached.

## Add the middleware to the app

Add the request timeouts middleware to the service collection by calling <xref:Microsoft.Extensions.DependencyInjection.RequestTimeoutsIServiceCollectionExtensions.AddRequestTimeouts%2A>.

Add the middleware to the request processing pipeline by calling <xref:Microsoft.AspNetCore.Builder.RequestTimeoutsIApplicationBuilderExtensions.UseRequestTimeouts%2A>.

> [!NOTE]
> * In apps that explicitly call <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>, `UseRequestTimeouts` must be called after `UseRouting`.

Adding the middleware to the app doesn't automatically start triggering timeouts. Timeout limits have to be explicitly configured.

## Configure one endpoint or page

For minimal API apps, configure an endpoint to time out by calling <xref:Microsoft.AspNetCore.Builder.RequestTimeoutsIEndpointConventionBuilderExtensions.WithRequestTimeout%2A>, or by applying the [`[RequestTimeout]`](xref:Microsoft.AspNetCore.Http.Timeouts.RequestTimeoutAttribute) attribute, as shown in the following example:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="oneendpoint" highlight="20,24":::

For apps with controllers, apply the `[RequestTimeout]` attribute to the action method or the controller class. For Razor Pages apps, apply the attribute to the Razor page class.

## Configure multiple endpoints or pages

Create named *policies* to specify timeout configuration that applies to multiple endpoints. Add a policy by calling <xref:Microsoft.AspNetCore.Http.Timeouts.RequestTimeoutOptions.AddPolicy%2A>:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies" highlight="4":::

A timeout can be specified for an endpoint by policy name:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usepolicy" highlight="12":::

The `[RequestTimeout]` attribute can also be used to specify a named policy.

### Set global default timeout policy

Specify a policy for the global default timeout configuration:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies" highlight="2-3":::

The default timeout applies to endpoints that don't have a timeout specified. The following endpoint code checks for a timeout although it doesn't call the extension method or apply the attribute. The global timeout configuration applies, so the code checks for a timeout:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usedefault" :::

## Specify the status code in a policy

The <xref:Microsoft.AspNetCore.Http.Timeouts.RequestTimeoutPolicy> class has a property that can automatically set the status code when a timeout is triggered.

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies2" highlight="4":::

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usedefault2" :::

## Use a delegate in a policy

The `RequestTimeoutPolicy` class has a <xref:Microsoft.AspNetCore.Http.Timeouts.RequestTimeoutPolicy.WriteTimeoutResponse> property that can be used to customize the response when a timeout is triggered.

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies2" highlight="8-11":::

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usepolicy2" highlight="12":::

## Disable timeouts

To disable all timeouts including the default global timeout, use the [`[DisableRequestTimeout]`](xref:Microsoft.AspNetCore.Http.Timeouts.DisableRequestTimeoutAttribute) attribute or the <xref:Microsoft.AspNetCore.Builder.RequestTimeoutsIEndpointConventionBuilderExtensions.DisableRequestTimeout%2A> extension method:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="disablebyattr" highlight="1":::

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="disablebyext" highlight="12":::

## Cancel a timeout

To cancel a timeout that has already been started, use the <xref:Microsoft.AspNetCore.Http.Timeouts.IHttpRequestTimeoutFeature.DisableTimeout> method on <xref:Microsoft.AspNetCore.Http.Timeouts.IHttpRequestTimeoutFeature>. Timeouts cannot be canceled after they've expired.

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="canceltimeout" highlight="2-3":::

## See also

* <xref:Microsoft.AspNetCore.Http.Timeouts>
* <xref:fundamentals/middleware/index>

:::moniker-end
