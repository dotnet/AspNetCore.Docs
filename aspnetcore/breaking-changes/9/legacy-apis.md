---
title: "Legacy Mono and Emscripten JavaScript APIs not exported to global namespace in Blazor WebAssembly apps"
description: Learn about the breaking change in ASP.NET Core 9 where legacy Mono and Emscripten APIs are now accessible through the Blazor.runtime object instead of the global namespace.
ms.date: 12/4/2024
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/516
---

# Legacy Mono and Emscripten JavaScript APIs not exported to global namespace

Blazor WebAssembly no longer exports legacy Mono and Emscripten APIs to the global namespace. These APIs are now accessible through the `Blazor.runtime` object.

## Version introduced

.NET 9 GA

## Previous behavior

Legacy Mono APIs (`MONO` and `BINDING`) and the Emscripten `Module` object were exported to the global `window` object. For example, `window.Module.FS` returned the Emscripten virtual filesystem.

## New behavior

The Emscripten `Module` object is now exported to the `Blazor.runtime` object. For example, `Blazor.runtime.Module.FS` returns the Emscripten virtual filesystem. The legacy Mono API for interop (`MONO` and `BINDING`) is removed completely and replaced with `JSImport`/`JSExport`.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was made to avoid polluting the global namespace and keep all the APIs accessible from a single Blazor object.

## Recommended action

Instead of accessing Emscripten APIs from the `window` object, access them from the `Blazor.runtime` object.

## Affected APIs

- `window.MONO.*`
- `window.BINDING.*`
- `window.Module.*`
