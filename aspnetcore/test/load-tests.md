---
title: ASP.NET Core load/stress testing
author: Jeremy-Meng
description: Learn about several notable tools and approaches for load testing and stress testing ASP.NET Core apps.
ms.author: riande
ms.custom: mvc
ms.date: 4/05/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: test/loadtests
---
# ASP.NET Core load/stress testing

Load testing and stress testing are important to ensure a web app is performant and scalable. Their goals are different even though they often share similar tests.

**Load tests**: Test whether the app can handle a specified load of users for a certain scenario while still satisfying the response goal. The app is run under normal conditions.

**Stress tests**: Test app stability when running under extreme conditions, often for a long period of time. The tests place high user load, either spikes or gradually increasing load, on the app, or they limit the app's computing resources.

Stress tests determine if an app under stress can recover from failure and gracefully return to expected behavior. Under stress, the app isn't run under normal conditions.

Visual Studio 2019 is the last version of Visual Studio with load test features. For customers requiring load testing tools in the future, we recommend alternate tools, such as Apache JMeter, Akamai CloudTest, and BlazeMeter. For more information, see the [Visual Studio 2019 Release Notes](/visualstudio/releases/2019/release-notes-v16.0#test-tools).

## Visual Studio tools

Visual Studio allows users to create, develop, and debug web performance and load tests. An option is available to create tests by recording actions in a web browser.

For information on how to create, configure, and run a load test projects using Visual Studio 2017, see [Quickstart: Create a load test project](/visualstudio/test/quickstart-create-a-load-test-project?view=vs-2017).

Load tests can be configured to run on-premise or run in the cloud using Azure DevOps.

## Third-party tools

The following list contains third-party web performance tools with various feature sets:

* [Apache JMeter](https://jmeter.apache.org/)
* [ApacheBench (ab)](https://httpd.apache.org/docs/2.4/programs/ab.html)
* [Gatling](https://gatling.io/)
* [k6](https://k6.io)
* [Locust](https://locust.io/)
* [West Wind WebSurge](https://websurge.west-wind.com/)
* [Netling](https://github.com/hallatore/Netling)
* [Vegeta](https://github.com/tsenart/vegeta)

