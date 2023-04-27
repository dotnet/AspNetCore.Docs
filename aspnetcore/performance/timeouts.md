---
title: Request timeout middleware in ASP.NET Core
description: Learn how to configure and use request timeout middleware in ASP.NET Core.
author: tdykstra
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 04/24/2023
uid: performance/timeouts
---
# Request timeouts middleware in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra)

:::moniker range=">= aspnetcore-8.0"

Apps can apply timeout limits selectively to requests. ASP.NET Core servers don't do this by default since request processing times vary widely by scenario. For example, WebSockets, static files, and calling expensive APIs would each require a different timeout limit. So ASP.NET Core provides middleware that configures timeouts per endpoint as well as a global timeout.

When a timeout limit is hit, a <xref:System.Threading.CancellationToken> in <xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted?displayProperty=nameWithType> has <xref:System.Threading.CancellationToken.IsCancellationRequested> set to `true`. The request is not aborted automatically. It's up to the app to check `RequestAborted` and decide how to handle the timeout.

This article explains how to configure the timeout middleware. The timeout middleware can be used in all types of ASP.NET Core apps: Minimal API, Web API with controllers, MVC, and Razor Pages. The sample app is a Minimal API, but every timeout feature it illustrates is also supported in the other app types.

Request timeouts are in the `Microsoft.AspNetCore.Http.Timeouts` namespace.

## Add the middleware to the app

Add the request timeouts middleware to the service collection by calling `AddRequestTimeouts`.

Add the middleware to the request processing pipeline by calling `UseRequestTimeouts`.

> [!NOTE]
> * In apps that explicitly call `UseRouting`, `UseRequestTimeouts` must be called after `UseRouting`.

Adding the middleware to the app doesn't automatically start triggering timeouts. Timeout limits have to be explicitly configured.

## Configure one endpoint or page

For minimal API apps, configure an endpoint to time out by calling `WithRequestTimeout`, or by applying the `[RequestTimeout]` attribute, as shown in the following example:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="oneendpoint" highlight="17,21":::

For apps with controllers, apply the `[RequestTimeout]` attribute to the action method or the controller class. For Razor Pages apps, apply the attribute to the Razor page class.

## Configure multiple endpoints or pages

Create named *policies* to specify timeout configuration that applies to multiple endpoints:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies" highlight="4":::

A timeout can be specified for an endpoint by policy name:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usepolicy" highlight="9":::

The `[RequestTimeout]` attribute can also be used to specify a named policy.

The named policies are in a dictionary that is managed by `AddPolicy`, `TryGetPolicy`, and `RemovePolicy` APIs.

### Set global default timeout policy

Specify a policy for the global default timeout configuration:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies" highlight="2-3":::

The default timeout applies to endpoints that don't have a timeout specified. The following endpoint code checks for a timeout although it doesn't call the extension method or apply the attribute. The global timeout configuration applies, so the code checks for a timeout:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usedefault" :::

## Specify the status code in a policy

The `RequestTimeoutPolicy` has a property that can automatically set the status code when a timeout is triggered.

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies2" highlight="4":::

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usedefault2" highlight="4":::

## Use a delegate in a policy

The `RequestTimeoutPolicy` has a `WriteTimeoutResponse` property that can be used to customize the response when a timeout is triggered.

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="definepolicies2" highlight="8-11":::

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="usepolicy2" highlight="4,7":::

## Disable timeouts

To disable all timeouts including the default global timeout, use the `[DisableRequestTimeout]` attribute or the `DisableRequestTimeout` extension method:

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="disablebyattr" highlight="1":::

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="disablebyext" highlight="5":::

## Cancel a timeout

To cancel a timeout that has already been started, use the `DisableTimeout` method on `IHttpRequestTimeoutFeature`. Timeouts cannot be canceled after they've expired.

:::code language="csharp" source="~/performance/timeouts/samples/8.x/Program.cs" id="canceltimeout" highlight="2-3":::

## See also

* <xref:fundamentals/middleware/index>

:::moniker-end
