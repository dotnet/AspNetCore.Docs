---
title: "Breaking change: Middleware: New Use overload"
description: "Learn about the breaking change in ASP.NET Core 6.0 where a new overload of Use middleware was introduced."
ms.date: 05/06/2021
ms.custom: https://github.com/aspnet/Announcements/issues/461
---
# Middleware: New Use overload

A new overload of `app.Use` has been introduced. If you call `app.Use` but never call the `next` middleware, you'll now get compiler error CS0121:

**The call is ambiguous between the following methods or properties: 'UseExtensions.Use(IApplicationBuilder, Func<HttpContext, Func, Task>)' and 'UseExtensions.Use(IApplicationBuilder, Func<HttpContext, RequestDelegate, Task>)'**

To resolve the error, use `app.Run` instead of `app.Use`.

For discussion, see GitHub issue [dotnet/aspnetcore#32020](https://github.com/dotnet/aspnetcore/issues/32020).

## Version introduced

ASP.NET Core 6.0

## Old behavior

```csharp
app.Use(async (context, next) =>
{
    await next();
});
```

or

```csharp
app.Use(async (context, next) =>
{
    await SomeAsyncWork();
    // next not called...
});
```

## New behavior

You can now pass `context` to the `next` delegate:

```csharp
app.Use(async (context, next) =>
{
    await next(context);
});
```

Use `app.Run` when your middleware never calls `next`:

```csharp
app.Run(async (context) =>
{
    await SomeAsyncWork();
    // next never called
});
```

## Reason for change

The previous `Use` method allocates two objects per request. The new overload avoids these allocations with a small change to how you invoke the `next` middleware.

## Recommended action

If you get a compile error, it means you are calling `app.Use` without using the `next` delegate. Switch to `app.Run` to fix the error.

## Affected APIs

None.

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectible via API analysis.

-->
