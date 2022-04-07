---
title: Localization test doc
author: guardrex
description: This is a localization test doc.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/07/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/no-loc-test
---
# Localization test doc (TEST 3)

`The third test tries a wildcard fileMetadata to see if it MERGES WITH a topic-specific no-loc array.`

`This topic has our standard no-loc metadata entry:`

```
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
```

`There's also a wildcard fileMetadata no-loc entry in the docfx.json file for some words that aren't found anywhere in the docs and that should normally localize:`

```json
"no-loc": {
  "**/**.md": [ "toaster", "bowl", "toothbrush", "magnet", "oak" ]
},
```

`Entries from the topic's no-loc array should be prevented from localization:`

* .NET MAUI
* Mac Catalyst
* Blazor Hybrid
* Home
* Privacy
* Kestrel
* appsettings.json
* ASP.NET Core Identity
* cookie
* Cookie
* Blazor
* Blazor Server
* Blazor WebAssembly
* Identity
* Let's Encrypt
* Razor
* SignalR

`Entries in the docfx.json wildcard fileMetadata no-loc array should also be prevented from localization`:

* toaster
* bowl
* toothbrush
* magnet
* oak

`Sentences`:

* The toaster is broken.
* The cat ate from the bowl.
* The toothbrush should be replaced.
* A magnet is in the motor.
* My desk is made of oak.
