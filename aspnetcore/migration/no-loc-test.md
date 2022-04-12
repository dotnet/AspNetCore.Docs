---
title: Localization test doc
author: guardrex
description: This is a localization test doc.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/09/2022
uid: migration/no-loc-test
---
# Localization test doc (TEST 4)

`The fourth test is just to confirm that a wildcard fileMetadata works.`

`This topic doesn't have a no-loc metadata entry.`

`There's a wildcard fileMetadata no-loc entry in the docfx.json file for some words that aren't found anywhere in the docs and that should normally localize:`

```json
"no-loc": {
  "**/**.md": [ "toaster", "bowl", "toothbrush", "magnet", "oak" ]
},
```

`Entries in the docfx.json wildcard fileMetadata no-loc array should be prevented from localization`:

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
