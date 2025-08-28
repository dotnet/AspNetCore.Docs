---
title: .NET 10 validation package information
ai-usage: ai-assisted
ms.author: wpickett
ms.date: 08/28/2025
---

<!-- USED in validation docs for .NET 10 -->

## Validation in .NET 10

In .NET 10, the unified validation APIs have been moved to the `Microsoft.Extensions.Validation` NuGet package. This change makes the validation APIs available outside of ASP.NET Core HTTP scenarios.

To use the `Microsoft.Extensions.Validation` APIs:

* Add the following package reference:

  ```xml
  <PackageReference Include="Microsoft.Extensions.Validation" Version="10.0.0" />
  ```

  The functionality remains the same but now requires an explicit package reference.

* Register validation services with dependency injection:

    ```csharp
    builder.Services.AddValidation();
    ```