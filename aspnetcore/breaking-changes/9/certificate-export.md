---
title: "Breaking change: Dev cert export no longer creates folder"
description: Learn about the breaking change in ASP.NET Core 9 where exporting the development certificate no longer creates the target directory if it doesn't exist.
ms.date: 11/6/2024
ms.custom: https://github.com/aspnet/Announcements/issues/515
---

# Dev cert export no longer creates folder

When you export the ASP.NET Core development certificate (which is used to enable HTTPS in local development), it no longer creates the directory into which the certificate is being exported if that directory doesn't exist.

This change first appears in .NET 8.0.10 and .NET 9 RC 1.

## Version introduced

.NET 9 RC 1

## Previous behavior

Previously, if the destination directory didn't exist when the `dotnet dev-certs` command was run, it was created (with permissions inherited from the containing directory). For example, *C:\\NonExistent\\* would have been created given the following command:

```dotnetcli
dotnet dev-certs https -ep C:\NonExistent\cert.pfx
```

## New behavior

Starting in .NET 9, if target directory doesn't exist, the export fails with a message like:

> There was an error exporting the HTTPS developer certificate to a file.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

The development certificate is exported with its private key, so unauthorized access can be problematic. It might, nevertheless, be necessary to make it readable to multiple accounts, for example, if the consuming process won't be run as the current user. Rather than attempting to determine (and securely establish) permissions for the target directory, `dotnet dev-certs` requires that it already exist.

## Recommended action

Create the target directory (with appropriate permissions) before invoking `dotnet dev-certs`.

## Affected APIs

N/A
