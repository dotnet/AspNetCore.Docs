---
title: "Breaking change: Blazor custom event registration throws when name matches a browser event"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where Blazor.registerCustomEventType throws when eventName equals browserEventName."
ms.date: 06/04/2026
---
# Blazor custom event registration throws when name matches a browser event

The Blazor JavaScript API `Blazor.registerCustomEventType` now throws an error when the custom event name matches its `browserEventName` option. Registering a custom event with the same name as the underlying browser event caused the event to fire twice for each user action.

## Version introduced

.NET 11

## Previous behavior

Previously, you could call `Blazor.registerCustomEventType` with an `eventName` equal to the `browserEventName` option. The call succeeded silently, but every browser event of that name caused two `EventCallback` invocations on the .NET side: one for the native browser event and one for the custom event wrapper that re-fired the same name.

```javascript
// This used to silently double-fire the event.
Blazor.registerCustomEventType('scrolltop', {
    browserEventName: 'scrolltop'
});
```

## New behavior

Starting in ASP.NET Core 11, `Blazor.registerCustomEventType` throws when `eventName` equals `options.browserEventName`:

```javascript
// This now throws synchronously.
Blazor.registerCustomEventType('scrolltop', {
    browserEventName: 'scrolltop'
});
```

To wrap a browser event in a custom event without the collision, give the custom event a different name:

```javascript
Blazor.registerCustomEventType('customscroll', {
    browserEventName: 'scrolltop'
});
```

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

Calling `Blazor.registerCustomEventType` with the same name for the custom and browser events was almost always a mistake that produced silently incorrect double-firing. The new validation surfaces the mistake at registration time. For more information, see [dotnet/aspnetcore#64774](https://github.com/dotnet/aspnetcore/pull/64774).

## Recommended action

If your code calls `Blazor.registerCustomEventType` with a custom name that's the same as the underlying browser event, rename the custom event to anything else (a common convention is to add a prefix such as `custom` or your component-library name):

```javascript
Blazor.registerCustomEventType('lib-scroll', {
    browserEventName: 'scrolltop'
});
```

Then update the corresponding `[EventHandler]` attribute or `@on*` directive on the .NET side to use the new name.

## Affected APIs

None. `Blazor.registerCustomEventType` is a JavaScript API; it isn't surfaced through the .NET object model. For more information, see [custom events in Blazor](/aspnet/core/blazor/components/event-handling#custom-event-arguments).
