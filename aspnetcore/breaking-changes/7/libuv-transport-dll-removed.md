---
title: "Breaking change: Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and libuv.dll removed"
description: Learn about the breaking change in ASP.NET Core 7.0 where Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and libuv.dll have been removed.
ms.date: 01/17/2022
ms.custom: https://github.com/aspnet/Announcements/issues/476
---

# Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and libuv.dll removed

Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and libuv.dll have been removed.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv was obsoleted in ASP.NET Core 5.0. Its functionality was replaced by the Sockets transport.

## New behavior

Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and its libuv.dll dependency have been removed.

## Type of breaking change

This change affects [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility) and [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

To eliminate ongoing maintenance costs associated with this obsolete component.

## Recommended action

Remove project references to Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv. Remove code from *Program.cs* that calls `UseLibuv`. The Sockets transport will be used by default.

## Affected APIs

* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions.UseLibuv%2A?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions?displayProperty=fullName>
