---
title: "Breaking change: Blazor: Updated validation logic for static web assets"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Blazor: Updated validation logic for static web assets"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/443
---
# Blazor: Updated validation logic for static web assets

There was an issue in conflict validation for static web assets in ASP.NET Core 3.1 and Blazor WebAssembly 3.2. The issue:

* Prevented proper conflict detection between the host assets and assets from Razor Class Libraries (RCLs) and Blazor WebAssembly apps.
* Mostly affects Blazor WebAssembly apps, since by default, static web assets in RCLs are served under the `_content/$(PackageId)` prefix.

## Version introduced

5.0

## Old behavior

During development, an RCL's static web assets could be silently overridden with host project assets on the same host path. Consider an RCL that has defined a static web asset to be served at */folder/file.txt*. If the host placed a file at *wwwroot/folder/file.txt*, the file on the server silently overrode the file on the RCL or Blazor WebAssembly app.

## New behavior

ASP.NET Core correctly detects when this issue happens. It informs you, the user, of the conflict so that you can take the appropriate action.

## Reason for change

Static web assets weren't intended to be overridable by files on the *wwwroot* host of the project. Allowing for the overriding of those files could lead to errors that are difficult to diagnose. The result could be undefined behavior changes in published apps.

## Recommended action

By default, there's no reason for an RCL file to conflict with a file on the host. RCL files are prefixed with `_content/${PackageId}`. Blazor WebAssembly files are placed at the root of the host URL space, which makes conflicts easier. For example, Blazor WebAssembly apps contain a *favicon.ico* file that the host might also include in its *wwwroot* folder.

If the conflict's source is an RCL file, it often means code is copying assets from the library into the project's *wwwroot* folder. Writing code to copy files defeats a primary goal of static web assets. This goal is fundamental to get updates on the browser when the contents are updated without having to trigger a new compilation.

You may choose to preserve this behavior and maintain the file on the host. To do so, remove the file from the list of static web assets with a custom MSBuild target.

To use the RCL's file or the Blazor WebAssembly app's file instead of the host project's file, remove the file from the host project.

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
