---
title: HttpRepl telemetry
author: tdykstra
description: Learn about the telemetry collected by the HttpRepl.
monikerRange: '>= aspnetcore-3.1'
ms.author: scaddie
ms.date: 11/11/2020
uid: web-api/http-repl/telemetry
---
# HttpRepl telemetry

The [HttpRepl](xref:web-api/http-repl) includes a telemetry feature that collects usage data. It's important that the HttpRepl team understands how the tool is used so it can be improved.

## How to opt out

The HttpRepl telemetry feature is enabled by default. To opt out of the telemetry feature, set the `DOTNET_HTTPREPL_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

## Disclosure

The HttpRepl displays text similar to the following when you first run the tool. Text may vary slightly depending on the version of the tool you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
Telemetry
---------
The .NET tools collect usage data in order to help us improve your experience. It is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_HTTPREPL_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.
```

To suppress the "first run" experience text, set the `DOTNET_HTTPREPL_SKIP_FIRST_TIME_EXPERIENCE` environment variable to `1` or `true`.

## Data points

The telemetry feature doesn't:

* Collect personal data, such as usernames, email addresses, or URLs.
* Scan your HTTP requests or responses.

The data is sent securely to Microsoft servers and held under restricted access.

Protecting your privacy is important to us. If you suspect the telemetry feature is collecting sensitive data or the data is being insecurely or inappropriately handled, take one of the following actions:

* File an issue in the [dotnet/httprepl](https://github.com/dotnet/httprepl/issues) repository.
* Send an email to [dotnet@microsoft.com](mailto:dotnet@microsoft.com) for investigation.

The telemetry feature collects the following data.

| .NET SDK versions | Data |
|--------------|------|
| >=5.0        | Timestamp of invocation. |
| >=5.0        | Three-octet IP address used to determine the geographical location. |
| >=5.0        | Operating system and version. |
| >=5.0        | Runtime ID (RID) the tool is running on. |
| >=5.0        | Whether the tool is running in a container. |
| >=5.0        | Hashed Media Access Control (MAC) address: a cryptographically (SHA256) hashed and unique ID for a machine. |
| >=5.0        | Kernel version. |
| >=5.0        | HttpRepl version. |
| >=5.0        | Whether the tool was started with `help`, `run`, or `connect` arguments. Actual argument values aren't collected. |
| >=5.0        | Command invoked (for example, `get`) and whether it succeeded. |
| >=5.0        | For the `connect` command, whether the `root`, `base`, or `openapi` arguments were supplied. Actual argument values aren't collected. |
| >=5.0        | For the `pref` command, whether a `get` or `set` was issued and which preference was accessed. If not a well-known preference, the name is hashed. The value isn't collected. |
| >=5.0        | For the `set header` command, the header name being set. If not a well-known header, the name is hashed. The value isn't collected. |
| >=5.0        | For the `connect` command, whether a special case for `dotnet new webapi` was used and, whether it was bypassed via preference. |
| >=5.0        | For all HTTP commands (for example, GET, POST, PUT), whether each of the options was specified. The values of the options aren't collected. |

## Additional resources

* [.NET Core SDK telemetry](/dotnet/core/tools/telemetry)
* [.NET Core CLI telemetry data](https://dotnet.microsoft.com/platform/telemetry)
