---
title: ASP.NET Core load/stress testing
author: Jeremy-Meng
description: Learn about several tools and approaches for load testing and stress testing ASP.NET Core apps.
ms.author: riande
ms.custom: mvc
ms.date: 4/05/2019
uid: test/loadtests
---
# ASP.NET Core load/stress testing

Load testing and stress testing are important to ensure a web app is performant and scalable. Load and stress testing have different goals even though they often share similar tests.

**Load tests**: Test whether the app can handle a specified load of users for a certain scenario while still satisfying the response goal. The app is run under normal conditions.

**Stress tests**: Test app stability when running under extreme conditions, often for a long period of time. The tests place high user load, either spikes or gradually increasing load on the app, or they limit the app's computing resources.

Stress tests determine if an app under stress can recover from failure and gracefully return to expected behavior. Under stress, the app is run at abnormally high stress.

[Azure Load Testing](/azure/load-testing/overview-what-is-azure-load-testing) is a fully managed load-testing service that enables you to generate high-scale load. The service simulates traffic for apps, regardless of where they're hosted. Azure Load Testing Preview enables you to use existing Apache JMeter scripts to generate high-scale load.

[Visual Studio 2019 load testing](https://devblogs.microsoft.com/devops/cloud-based-load-testing-service-eol/) has been deprecated. The corresponding Azure DevOps cloud-based load testing service has been closed.

## Third-party tools

The following list contains third-party web performance tools with various feature sets:

* [Apache JMeter](https://jmeter.apache.org/)
* [ApacheBench (ab)](https://httpd.apache.org/docs/2.4/programs/ab.html)
* [Gatling](https://gatling.io/)
* [jmeter-dotnet-dsl.net](https://abstracta.github.io/jmeter-dotnet-dsl/)
* [k6](https://k6.io)
* [Locust](https://locust.io/)
* [West Wind WebSurge](https://websurge.west-wind.com/)
* [Netling](https://github.com/hallatore/Netling)
* [Vegeta](https://github.com/tsenart/vegeta)
* [NBomber](https://github.com/PragmaticFlow/NBomber)

## Load and stress test with release builds

Load and stress tests should be done in release and [production](xref:fundamentals/environments) mode and not in debug and development mode. [Release configurations](/visualstudio/debugger/how-to-set-debug-and-release-configurations) are fully optimized with minimal logging. Debug configuration is not optimized. [Development](xref:fundamentals/environments) mode enables more information logging that can impact performance.
