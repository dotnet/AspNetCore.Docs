---
title: Filters in Minimal API applications
author: rick-anderson
description: Use filters in Minimal API applications
ms.author: riande
ms.date: 6/22/2022
uid: fundamentals/minimal-apis/min-api-filters
---
# Filters in Minimal API apps

:::moniker range=">= aspnetcore-7.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT)

HTTP is a stateless protocol. By default, HTTP requests are independent messages that don't retain user values. This article describes several approaches to preserve user data between requests.

## State management

State can be stored using several approaches. Each approach is described later in this topic.

