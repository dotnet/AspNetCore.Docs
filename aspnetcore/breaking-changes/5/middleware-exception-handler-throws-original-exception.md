---
title: "Breaking change: Middleware: Exception Handler Middleware throws original exception if handler not found"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Middleware: Exception Handler Middleware throws original exception if handler not found"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/434
---
# Middleware: Exception Handler Middleware throws original exception if handler not found

Before ASP.NET Core 5.0, the [Exception Handler Middleware](xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A) executes the configured exception handler when an exception has occurred. If the exception handler, configured via <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerOptions.ExceptionHandlingPath>, can't be found, an HTTP 404 response is produced. The response is misleading in that it:

* Seems to be a user error.
* Obscures the fact that an exception occurred on the server.

To address the misleading error in ASP.NET Core 5.0, the `ExceptionHandlerMiddleware` throws the original exception if the exception handler can't be found. As a result, an HTTP 500 response is produced by the server. The response will be easier to examine in the server logs when debugging the error that occurred.

For discussion, see GitHub issue [dotnet/aspnetcore#25288](https://github.com/dotnet/aspnetcore/issues/25288).

## Version introduced

5.0 RC 1

## Old behavior

The Exception Handler Middleware produces an HTTP 404 response if the configured exception handler can't be found.

## New behavior

The Exception Handler Middleware throws the original exception if the configured exception handler can't be found.

## Reason for change

The HTTP 404 error doesn't make it obvious that an exception occurred on the server. This change produces an HTTP 500 error to make it obvious that:

* The problem isn't caused by a user error.
* An exception was encountered on the server.

## Recommended action

There are no API changes. All existing apps will continue to compile and run. The exception thrown is handled by the server. For example, the exception is converted to an HTTP 500 error response by [Kestrel](/aspnet/core/fundamentals/servers/kestrel) or [HTTP.sys](/aspnet/core/fundamentals/servers/httpsys).

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
