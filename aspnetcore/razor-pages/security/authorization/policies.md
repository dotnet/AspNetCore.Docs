---
title: Policy-based authorization in ASP.NET Core Razor Pages
ai-usage: ai-assisted
author: wadepickett
description: Learn how to create and use authorization policy handlers for enforcing authorization requirements in an ASP.NET Core Razor Pages app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 07/08/2026
uid: razor-pages/security/authorization/policies
---
# Policy-based authorization in ASP.NET Core Razor Pages

This article provides additional Razor Pages policy-based authorization scenarios following <xref:security/authorization/policies>, which should be read before this article when learning about policy-based authorization.

## Apply policies to Razor Pages

Apply policies to Razor Pages using the `[Authorize]` attribute with the policy name:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Pages/AtLeast21.cshtml.cs" highlight="6":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp2/Pages/AlcoholPurchase.cshtml.cs" id="snippet_AlcoholPurchaseModelClass" highlight="4":::

:::moniker-end

Policies can't be applied at the page handler level, they must be applied to the <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class.

Policies can also be applied to pages using an [authorization convention](xref:razor-pages/security/authorization/conventions).
