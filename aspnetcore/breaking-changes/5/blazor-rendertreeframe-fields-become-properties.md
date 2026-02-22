---
title: "Breaking change: Blazor: RenderTreeFrame readonly public fields have become properties"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Blazor: RenderTreeFrame readonly public fields have become properties"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/438
---
# Blazor: RenderTreeFrame readonly public fields have become properties

In ASP.NET Core 3.0 and 3.1, the <xref:Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrame> struct exposed various `readonly public` fields, including <xref:Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrame.FrameType>, <xref:Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrame.Sequence>, and others. In ASP.NET Core 5.0 RC1 and later versions, all the `readonly public` fields changed to `readonly public` properties.

This change won't affect many developers because:

* Any app or library that simply uses `.razor` files (or even manual <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> calls) to define its components wouldn't be referencing this type directly.
* The `RenderTreeFrame` type itself is regarded as an implementation detail, not intended for use outside of the framework. ASP.NET Core 3.0 and later includes an analyzer that issues compiler warnings if the type is being used directly.
* Even if you reference `RenderTreeFrame` directly, this change is binary-breaking but not source-breaking. That is, your existing source code will compile and behave properly. You'll only encounter an issue if compiling against a .NET Core 3.x framework and then running those binaries against the .NET 5 or a later framework.

For discussion, see GitHub issue [dotnet/aspnetcore#25727](https://github.com/dotnet/aspnetcore/issues/25727).

## Version introduced

5.0 RC1

## Old behavior

Public members on `RenderTreeFrame` are defined as fields. For example, `renderTreeFrame.Sequence` and `renderTreeFrame.ElementName`.

## New behavior

Public members on `RenderTreeFrame` are defined as properties with the same names as before. For example, `renderTreeFrame.Sequence` and `renderTreeFrame.ElementName`.

If older precompiled code hasn't been recompiled since this change, it may throw an exception similar to *MissingFieldException: Field not found: 'Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrame.FrameType'*.

## Reason for change

This change was necessary to implement high-impact performance improvements in Razor component rendering in ASP.NET Core 5.0. The same levels of safety and encapsulation are maintained.

## Recommended action

Most Blazor developers are unaffected by this change. The change is more likely to affect library and package authors, but only in rare cases. Specifically, if you're developing:

* An app and using ASP.NET Core 3.x or upgrading to 5.0 RC1 or later, you don't need to change your own code. However, if you depend on a library that upgraded to account for this change, then you need to update to a newer version of that library.
* A library and want to support only ASP.NET Core 5.0 RC1 or later, no action is needed. Just ensure that your project file declares a `<TargetFramework>` value of `net5.0` or a later version.
* A library and want to support both ASP.NET Core 3.x *and* 5.0, determine whether your code reads any `RenderTreeFrame` members. For example, evaluating `someRenderTreeFrame.FrameType`.
  * Most libraries won't read `RenderTreeFrame` members, including libraries that contain `.razor` components. In this case, no action is needed.
  * However, if your library does that, you'll need to multi-target to support both `netstandard2.1` and `net5.0`. Apply the following changes in your project file:
    * Replace the existing `<TargetFramework>` element with `<TargetFrameworks>netstandard2.0;net5.0</TargetFrameworks>`.
    * Use a conditional `Microsoft.AspNetCore.Components` package reference to account for both versions you wish to support. For example:

        ```xml
        <PackageReference Include="Microsoft.AspNetCore.Components" Version="3.0.0" Condition="'$(TargetFramework)' == 'netstandard2.0'" />
        <PackageReference Include="Microsoft.AspNetCore.Components" Version="5.0.0-rc.1.*" Condition="'$(TargetFramework)' != 'netstandard2.0'" />
        ```

For further clarification, see this [diff showing how @jsakamoto already upgraded the `Toolbelt.Blazor.HeadElement` library](https://github.com/jsakamoto/Toolbelt.Blazor.HeadElement/commit/090df430ba725f9420d412753db8104e8c32bf51).

## Affected APIs

<xref:Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrame?displayProperty=nameWithType>

<!--

### Category

ASP.NET Core

### Affected APIs

`T:Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrame`

-->
