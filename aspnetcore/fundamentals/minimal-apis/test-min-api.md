---
title: Test Minimal API apps
author: wadepickett
description: Unit and integration tests in Minimal API apps
ms.author: wpickett
ms.date: 09/15/2025
monikerRange: '>= aspnetcore-7.0'
uid: fundamentals/minimal-apis/test-min-api
---

# Unit and integration tests in Minimal API apps

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Fiyaz Bin Hasan](https://github.com/fiyazbinhasan), and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[](~/includes/integrationTests.md)]

The [sample code on GitHub](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample) provides an example of unit and integration tests on a Minimal API app.

<a name="iit7"></a>

## Unit test IResult implementation types

The following example shows how to unit test minimal route handlers that return <xref:Microsoft.AspNetCore.Http.IResult> using the [xUnit](https://github.com/xunit/xunit/) testing framework. The external database is replaced with an in-memory database during testing, the implementation of the `MockDb` can be found in the [sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/minimal-apis/samples/MinApiTestsSample/UnitTests/Helpers/MockDb.cs).

Public <xref:Microsoft.AspNetCore.Http.IResult> implementation types in the <xref:Microsoft.AspNetCore.Http.HttpResults?displayProperty=fullName> namespace can be used to unit test minimal route handlers when using named methods instead of lambdas.

The following code uses the <xref:Microsoft.AspNetCore.Http.HttpResults.NotFound%601> class:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MinApiTestsSample/UnitTests/TodoInMemoryTests.cs" id="snippet_" highlight="8":::

The following code uses the <xref:Microsoft.AspNetCore.Http.HttpResults.Ok%601> class:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MinApiTestsSample/UnitTests/TodoInMemoryTests.cs" id="snippet_1" highlight="18":::

## Additional Resources

* [Basic authentication tests](https://github.com/blowdart/idunno.Authentication/tree/dev/test/idunno.Authentication.Basic.Test) is not a .NET repository but was written by a member of the .NET team. It provides examples of basic authentication testing.
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample)
* <xref:fundamentals/minimal-apis/security>
* [Use port tunneling Visual Studio to debug web APIs](/connectors/custom-connectors/port-tunneling)
* <xref:mvc/controllers/testing>
* <xref:test/razor-pages-tests>
