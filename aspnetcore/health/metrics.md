---
title: ASP.NET Core metrics
description: Metrics for ASP.NET Core apps
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 6/30/2023
ms.topic: article
ms.prod: aspnet-core
uid: health/metrics
---

# ASP.NET Core metrics

Metrics are numerical measurements reported over time. They are typically used to monitor the health of an app and generate alerts. For example, a web service might track how many:

* Requests it received per second.
* Milliseconds it took to respond.
* Responses sent an error.

These metrics can be reported to a monitoring system at regular intervals. If the web service is intended to respond to requests within 400 ms and starts responding in 600 ms, the monitoring system can notify engineers that the app response is slower than normal.

## Using metrics

There are two parts to using metrics in a .NET app:

* **Instrumentation:** Code in .NET libraries takes measurements and associates these measurements with a metric name.
* **Collection:** A .NET app configures named metrics to be transmitted from the app for external storage and analysis. Some tools may perform configuration outside the app using configuration files or a UI tool.

