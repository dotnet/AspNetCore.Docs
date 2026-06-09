---
title: "Breaking change: ASP.NET Core hosting emits OpenTelemetry HTTP semantic-convention tags by default"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where the HTTP server Activity emits OpenTelemetry HTTP semantic-convention tags by default, the http.route tag uses literal default values for conventional routes, and Activity.StatusDescription is no longer set on exceptions."
ms.date: 06/04/2026
---
# ASP.NET Core hosting emits OpenTelemetry HTTP semantic-convention tags by default

The HTTP server <xref:System.Diagnostics.Activity> created by `Microsoft.AspNetCore.Hosting` now emits the OpenTelemetry HTTP server-span semantic-convention tags by default, and its `http.route` tag uses the resolved values of conventional-route default parameters. <xref:System.Diagnostics.Activity.StatusDescription> is no longer set when an unhandled exception occurs. Together, these changes bring the built-in `Microsoft.AspNetCore.Hosting` activity into line with the metadata produced by `OpenTelemetry.Instrumentation.AspNetCore`.

## Version introduced

.NET 11

## Previous behavior

Previously:

- The `Microsoft.AspNetCore.Hosting.SuppressActivityOpenTelemetryData` `AppContext` switch defaulted to `true`, so the framework's HTTP server `Activity` didn't carry OpenTelemetry HTTP server-span tags. Apps that wanted those tags used `OpenTelemetry.Instrumentation.AspNetCore` to add them, or set the switch to `false` explicitly.
- The `http.route` tag on the activity used the raw route template. For conventional routes such as `{controller=Home}/{action=Index}/{id?}`, every endpoint that resolved through the conventional pipeline reported the same `http.route` value.
- When an unhandled exception escaped the request pipeline, the framework set `Activity.Status` to `Error` and also set `Activity.StatusDescription` to the exception message.

## New behavior

Starting in ASP.NET Core 11:

- `Microsoft.AspNetCore.Hosting.SuppressActivityOpenTelemetryData` defaults to `false`. The framework's HTTP server `Activity` now carries the OpenTelemetry HTTP [server-span](https://opentelemetry.io/docs/specs/semconv/http/http-spans/#http-server-span) tags out of the box. The added tags include `http.request.method`, `http.response.status_code`, `http.route`, `network.protocol.version`, `url.path`, `url.scheme`, `server.address`, `server.port`, and `user_agent.original`. See the [OpenTelemetry HTTP server span spec](https://opentelemetry.io/docs/specs/semconv/http/http-spans/#http-server-span) for the full set of attributes.
- The HTTP request duration metric (`http.server.request.duration`) carries an additional `error.type` dimension for `5xx` responses.
- For conventional routes, the `http.route` tag has the `{controller}`, `{action}`, `{area}`, and `{page}` parameters replaced by their resolved values. For example, a request to `Store/Checkout` matched by the conventional route `{controller=Home}/{action=Index}/{id?}` now reports `http.route = "Store/Checkout/{id?}"` instead of `"{controller=Home}/{action=Index}/{id?}"`.
- When an unhandled exception escapes the request pipeline, the framework sets `Activity.Status` to `Error` but does *not* set `Activity.StatusDescription`. The exception is still recorded as an `Activity` event with the standard `exception.type`, `exception.message`, and `exception.stacktrace` tags, and the exception type is reflected in the `error.type` metric dimension.

## Type of breaking change

This is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

Aligning the built-in hosting activity with the OpenTelemetry HTTP server-span specification lets apps observe their HTTP behavior without taking an extra dependency on `OpenTelemetry.Instrumentation.AspNetCore`. Using resolved route values in `http.route` matches the OpenTelemetry guidance for that tag and produces more useful aggregations in dashboards. Not setting `Activity.StatusDescription` on exceptions aligns with `OpenTelemetry.Instrumentation.AspNetCore` (which already left it unset) and avoids putting potentially sensitive exception messages in places that aren't designed to receive them.

For more information, see [dotnet/aspnetcore#64851](https://github.com/dotnet/aspnetcore/pull/64851), [dotnet/aspnetcore#64854](https://github.com/dotnet/aspnetcore/pull/64854), and [dotnet/aspnetcore#65825](https://github.com/dotnet/aspnetcore/pull/65825).

## Recommended action

Most apps don't need to do anything—the new defaults match what `OpenTelemetry.Instrumentation.AspNetCore` already produced.

If you observe **duplicate tags** because both the framework and `OpenTelemetry.Instrumentation.AspNetCore` add the same set, upgrade the instrumentation package to the latest version, which detects the built-in tags and skips adding them.

If you have a custom span enricher or exporter that depended on the *absence* of these tags, on the previous `http.route` format, or on `Activity.StatusDescription` being populated, update it. The `error.type` metric dimension also grows the cardinality of the duration metric for 5xx responses; review your metrics backend's cardinality budget if you previously aggregated by status code only.

To restore the pre-11 behavior (no OpenTelemetry semantic-convention tags from the framework), set the `AppContext` switch back to `true` early in app startup:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Hosting.SuppressActivityOpenTelemetryData", true);
```

The switch only controls the OpenTelemetry tags. The `http.route` value-substitution change and the `Activity.StatusDescription` change can't be reverted independently.

## Affected APIs

- `Microsoft.AspNetCore.Hosting.HostingHostBuilderExtensions`
- <xref:System.Diagnostics.Activity.StatusDescription?displayProperty=fullName>
- The OpenTelemetry [HTTP server span semantic conventions](https://opentelemetry.io/docs/specs/semconv/http/http-spans/#http-server-span).
