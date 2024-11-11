---
title: dotnet-scaffold telemetry
author: tdykstra
description: Learn about the telemetry collected by the dotnet-scaffold CLI tool.
monikerRange: '>= aspnetcore-8.0'
ms.author: tdykstra
ms.date: 11/06/2024
uid: fundamentals/dotnet-scaffold-telemetry
---
# dotnet-scaffold telemetry

The `dotnet-scaffold` command includes a telemetry feature that collects usage data. This feature helps the `dotnet-scaffold` team understand how the tool is used so it can be improved.

## How to opt out

The `dotnet-scaffold` telemetry feature is enabled by default. To opt out of the telemetry feature, set the `DOTNET_SCAFFOLD_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

## Disclosure

When you run the `dotnet-scaffold` tool the first time, it displays output similar to the following example. The text may vary slightly depending on the version of the tool you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
dotnet-scaffold collects usage data in order to help us improve your experience. The data is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_SCAFFOLD_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about dotnet-scaffold telemetry:
https://aka.ms/dotnet-scaffold/telemetry
Read more about .NET CLI Tools telemetry:
https://aka.ms/dotnet-cli-telemetry
```

To suppress the "first run" experience text, set the `DOTNET_SCAFFOLD_SKIP_FIRST_TIME_EXPERIENCE` environment variable to `1` or `true`.

## Data points

The telemetry feature doesn't collect:

* Personal data, such as usernames, email addresses, or URLs.
* Any project data.

The data is sent securely to Microsoft servers and held under restricted access.

Protecting your privacy is important to us. If you suspect the telemetry feature is collecting sensitive data or the data is being insecurely or inappropriately handled, take one of the following actions:

* File an issue in the [dotnet/scaffolding](https://github.com/dotnet/scaffolding/issues) repository.
* Send an email to [dotnet@microsoft.com](mailto:dotnet@microsoft.com) for investigation.

The telemetry feature collects the following data.

| .NET SDK versions | Data |
|--------------|------|
| >=8.0        | Timestamp of invocation. |
| >=8.0        | Three-octet IP address used to determine the geographical location. |
| >=8.0        | Operating system and version. |
| >=8.0        | Runtime ID (RID) the tool is running on. |
| >=8.0        | Whether the tool is running in a container. |
| >=8.0        | Hashed Media Access Control (MAC) address: a cryptographically (SHA256) hashed and unique ID for a machine. |
| >=8.0        | Kernel version. |
| >=8.0        | dotnet-scaffold version. |
| >=8.0        | Hashed tool information (tool name, tool version, tool package name, tool package version, chosen scaffolder category, related scaffolding categories) |
| >=8.0        | Tool level (global or local tool) |
| >=8.0        | Hashed command invoked (for example, `mvccontroller`) and whether it succeeded. |
| >=8.0        | dotnet-scaffold-aspnet scaffolder name, step names, and whether they succeeded. |
| >=8.0        | dotnet-scaffold-aspire scaffolder name and whether it succeeded. |
| >=8.0        | dotnet-scaffold aspnet scaffolder validation method name and whether they succeed. |
| >=8.0        | dotnet-scaffold aspire scaffolder validation method name and whether they succeed. |

## Additional resources

* [.NET Core SDK telemetry](/dotnet/core/tools/telemetry)
* [.NET CLI telemetry data](https://dotnet.microsoft.com/platform/telemetry)
