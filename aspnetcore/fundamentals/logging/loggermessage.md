---
title: High-performance logging with LoggerMessage in ASP.NET Core
author: guardrex
description: Learn how to use LoggerMessage features to create cacheable delegates that require fewer object allocations than logger extension methods for high-performance logging scenarios.
ms.author: riande
manager: wpickett
ms.date: 11/03/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/logging/loggermessage
---
# High-performance logging with LoggerMessage in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

[LoggerMessage](/dotnet/api/microsoft.extensions.logging.loggermessage) features create cacheable delegates that require fewer object allocations and reduced computational overhead than [logger extension methods](/dotnet/api/Microsoft.Extensions.Logging.LoggerExtensions), such as `LogInformation`, `LogDebug`, and `LogError`. For high-performance logging scenarios, use the `LoggerMessage` pattern.

`LoggerMessage` provides the following performance advantages over Logger extension methods:

* Logger extension methods require "boxing" (converting) value types, such as `int`, into `object`. The `LoggerMessage` pattern avoids boxing by using static `Action` fields and extension methods with strongly-typed parameters.
* Logger extension methods must parse the message template (named format string) every time a log message is written. `LoggerMessage` only requires parsing a template once when the message is defined.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/logging/loggermessage/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app demonstrates `LoggerMessage` features with a basic quote tracking system. The app adds and deletes quotes using an in-memory database. As these operations occur, log messages are generated using the `LoggerMessage` pattern.

## LoggerMessage.Define

[Define(LogLevel, EventId, String)](/dotnet/api/microsoft.extensions.logging.loggermessage.define) creates an `Action` delegate for logging a message. `Define` overloads permit passing up to six type parameters to a named format string (template).

## LoggerMessage.DefineScope

[DefineScope(String)](/dotnet/api/microsoft.extensions.logging.loggermessage.definescope) creates a `Func` delegate for defining a [log scope](xref:fundamentals/logging/index#log-scopes). `DefineScope` overloads permit passing up to three type parameters to a named format string (template).

## Message template (named format string)

The string provided to the `Define` and `DefineScope` methods is a template and not an interpolated string. Placeholders are filled in the order that the types are specified. Placeholder names in the template should be descriptive and consistent across templates. They serve as property names within structured log data. We recommend [Pascal casing](/dotnet/standard/design-guidelines/capitalization-conventions) for placeholder names. For example, `{Count}`, `{FirstName}`.

## Implementing LoggerMessage.Define

Each log message is an `Action` held in a static field created by `LoggerMessage.Define`. For example, the sample app creates a field to describe a log message for a GET request for the Index page (*Internal/LoggerExtensions.cs*):

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet1)]

For the `Action`, specify:

* The log level.
* A unique event identifier ([EventId](/dotnet/api/microsoft.extensions.logging.eventid)) with the name of the static extension method.
* The message template (named format string). 

A request for the Index page of the sample app sets the:

* Log level to `Information`.
* Event id to `1` with the name of the `IndexPageRequested` method.
* Message template (named format string) to a string.

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet5)]

Structured logging stores may use the event name when it's supplied with the event id to enrich logging. For example, [Serilog](https://github.com/serilog/serilog-extensions-logging) uses the event name.

The `Action` is invoked through a strongly-typed extension method. The `IndexPageRequested` method logs a message for an Index page GET request in the sample app:

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet9)]

`IndexPageRequested` is called on the logger in the `OnGetAsync` method in *Pages/Index.cshtml.cs*:

[!code-csharp[Main](loggermessage/sample/Pages/Index.cshtml.cs?name=snippet2&highlight=3)]

Inspect the app's console output:

```console
info: LoggerMessageSample.Pages.IndexModel[1]
      => RequestId:0HL90M6E7PHK4:00000001 RequestPath:/ => /Index
      GET request for Index page
```

To pass parameters to a log message, define up to six types when creating the static field. The sample app logs a string when adding a quote by defining a `string` type for the `Action` field:

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet2)]

The delegate's log message template receives its placeholder values from the types provided. The sample app defines a delegate for adding a quote where the quote parameter is a `string`:

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet6)]

The static extension method for adding a quote, `QuoteAdded`, receives the quote argument value and passes it to the `Action` delegate:

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet10)]

In the Index page's page model (*Pages/Index.cshtml.cs*), `QuoteAdded` is called to log the message:

[!code-csharp[Main](loggermessage/sample/Pages/Index.cshtml.cs?name=snippet3&highlight=6)]

Inspect the app's console output:

```console
info: LoggerMessageSample.Pages.IndexModel[2]
      => RequestId:0HL90M6E7PHK5:0000000A RequestPath:/ => /Index
      Quote added (Quote = 'You can avoid reality, but you cannot avoid the consequences of avoiding reality. - Ayn Rand')
```

The sample app implements a `try`&ndash;`catch` pattern for quote deletion. An informational message is logged for a successful delete operation. An error message is logged for a delete operation when an exception is thrown. The log message for the unsuccessful delete operation includes the exception stack trace (*Internal/LoggerExtensions.cs*):

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet3)]

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet7)]

Note how the exception is passed to the delegate in `QuoteDeleteFailed`:

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet11)]

In the page model for the Index page, a successful quote deletion calls the `QuoteDeleted` method on the logger. When a quote isn't found for deletion, an `ArgumentNullException` is thrown. The exception is trapped by the `try`&ndash;`catch` statement and logged by calling the `QuoteDeleteFailed` method on the logger in the `catch` block (*Pages/Index.cshtml.cs*):

[!code-csharp[Main](loggermessage/sample/Pages/Index.cshtml.cs?name=snippet5&highlight=14,18)]

When a quote is successfully deleted, inspect the app's console output:

```console
info: LoggerMessageSample.Pages.IndexModel[4]
      => RequestId:0HL90M6E7PHK5:00000016 RequestPath:/ => /Index
      Quote deleted (Quote = 'You can avoid reality, but you cannot avoid the consequences of avoiding reality. - Ayn Rand' Id = 1)
```

When quote deletion fails, inspect the app's console output. Note that the exception is included in the log message:

```console
fail: LoggerMessageSample.Pages.IndexModel[5]
      => RequestId:0HL90M6E7PHK5:00000010 RequestPath:/ => /Index
      Quote delete failed (Id = 999)
System.ArgumentNullException: Value cannot be null.
Parameter name: entity
   at Microsoft.EntityFrameworkCore.Utilities.Check.NotNull[T](T value, String parameterName)
   at Microsoft.EntityFrameworkCore.DbContext.Remove[TEntity](TEntity entity)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Remove(TEntity entity)
   at LoggerMessageSample.Pages.IndexModel.<OnPostDeleteQuoteAsync>d__14.MoveNext() in 
      <PATH>\sample\Pages\Index.cshtml.cs:line 87
```

## Implementing LoggerMessage.DefineScope

Define a [log scope](xref:fundamentals/logging/index#log-scopes) to apply to a series of log messages using the [DefineScope(String)](/dotnet/api/microsoft.extensions.logging.loggermessage.definescope) method.

The sample app has a **Clear All** button for deleting all of the quotes in the database. The quotes are deleted by removing them one at a time. Each time a quote is deleted, the `QuoteDeleted` method is called on the logger. A log scope is added to these log messages.

Enable `IncludeScopes` in the console logger options:

[!code-csharp[Main](loggermessage/sample/Program.cs?name=snippet1&highlight=22)]

Setting `IncludeScopes` is required in ASP.NET Core 2.0 apps to enable log scopes. Setting `IncludeScopes` via *appsettings* configuration files is a feature that's planned for the ASP.NET Core 2.1 release.

The sample app clears other providers and adds filters to reduce the logging output. This makes it easier to see the sample's log messages that demonstrate `LoggerMessage` features.

To create a log scope, add a field to hold a `Func` delegate for the scope. The sample app creates a field called `_allQuotesDeletedScope` (*Internal/LoggerExtensions.cs*):

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet4)]

Use `DefineScope` to create the delegate. Up to three types can be specified for use as template arguments when the delegate is invoked. The sample app uses a message template that includes the number of deleted quotes (an `int` type):

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet8)]

Provide a static extension method for the log message. Include any type parameters for named properties that appear in the message template. The sample app takes in a `count` of quotes to delete and returns `_allQuotesDeletedScope`:

[!code-csharp[Main](loggermessage/sample/Internal/LoggerExtensions.cs?name=snippet12)]

The scope wraps the logging extension calls in a `using` block:

[!code-csharp[Main](loggermessage/sample/Pages/Index.cshtml.cs?name=snippet4&highlight=5-6,14)]

Inspect the log messages in the app's console output. The following result shows three quotes deleted with the log scope message included:

```console
info: LoggerMessageSample.Pages.IndexModel[4]
      => RequestId:0HL90M6E7PHK5:0000002E RequestPath:/ => /Index => All quotes deleted (Count = 3)
      Quote deleted (Quote = 'Quote 1' Id = 2)
info: LoggerMessageSample.Pages.IndexModel[4]
      => RequestId:0HL90M6E7PHK5:0000002E RequestPath:/ => /Index => All quotes deleted (Count = 3)
      Quote deleted (Quote = 'Quote 2' Id = 3)
info: LoggerMessageSample.Pages.IndexModel[4]
      => RequestId:0HL90M6E7PHK5:0000002E RequestPath:/ => /Index => All quotes deleted (Count = 3)
      Quote deleted (Quote = 'Quote 3' Id = 4)
```

## See also

* [Logging](xref:fundamentals/logging/index)
