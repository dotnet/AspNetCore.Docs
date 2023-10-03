---
title: Unit Testing
description: Unit Testing 
author: afshinm
ms.author: amehrabani
monikerRange: '>= aspnetcore-6.0'
ms.date: 02/10/2023
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/unit-testing
---

# Unit Testing

In most cases, there is no need to set up additional components for running tests, but if the subject under test makes use of `HttpRuntime`, you may need to start up the `SystemWebAdapters` service as outlined below:

:::code language="csharp" source="~/migration/inc/samples/unit-testing/Program.cs" id="snippet_UnitTestingFixture" :::

It's important to emphasize that the tests must be executed in a sequential manner. In the above example, we've illustrated how you can achieve this by configuring the [XUnit's `DisableParallelization` option](https://xunit.net/docs/running-tests-in-parallel#parallelism-in-test-frameworks), setting it to `true`. This particular setting is designed to disable parallel execution for a specific test collection, ensuring that the tests within that collection run one after the other, without concurrency.