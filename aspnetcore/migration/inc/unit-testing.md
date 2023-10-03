---
title: Unit Testing
description: Unit Testing 
author: afshinm
ms.author: amehrabani
monikerRange: '>= aspnetcore-6.0'
ms.date: 10/03/2023
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/unit-testing
---

# Unit Testing

In most cases, there's no need to set up additional components for running tests. But if the component being tested uses <xref:System.Web.HttpRuntime>, it might be necessary to start up the `SystemWebAdapters` service, as shown in the following example:

:::code language="csharp" source="~/migration/inc/samples/unit-testing/Program.cs" id="snippet_UnitTestingFixture" :::

The tests must be executed in sequence, not in parallel. The preceding example illustrates how to achieve this by setting [XUnit's `DisableParallelization` option](https://xunit.net/docs/running-tests-in-parallel#parallelism-in-test-frameworks) to `true`. This setting disables parallel execution for a specific test collection, ensuring that the tests within that collection run one after the other, without concurrency.
