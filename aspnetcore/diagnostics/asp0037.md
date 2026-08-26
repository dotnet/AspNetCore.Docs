---
title: "ASP0037: ValidatableType cannot be used in generated code"
description: "Learn about analysis rule ASP0037: ValidatableType can't be used in generated code."
monikerRange: '>= aspnetcore-11.0'
ms.date: 08/25/2026
author: snemeckayova
ms.author: snemeckayova
uid: diagnostics/asp0037
---
# ASP0037: `[ValidatableType]` cannot be used in generated code

|              | Value   |
| -            | -       |
| **Rule ID**  | ASP0037 |
| **Category** | Usage   |
| **Severity** | Warning |

## Cause

The <xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> attribute is applied to a type declared in generated code, such as code generated from a Razor (`.razor`) file.

## Rule description

The validation source generator can't inspect another source generator's output. Applying `[ValidatableType]` to a type in generated code has no effect, so the type isn't included in generated validation metadata.

For example, declaring the following model in a Razor component's `@code` block produces this diagnostic:

```razor
@code {
    [ValidatableType]
    public class Order
    {
        [Required]
        public string? CustomerName { get; set; }
    }
}
```

## How to fix violations

Move the type to a regular C# (`.cs`) file and apply `[ValidatableType]` there:

```csharp
[ValidatableType]
public class Order
{
    [Required]
    public string? CustomerName { get; set; }
}
```

For more information, see <xref:fundamentals/validation>.