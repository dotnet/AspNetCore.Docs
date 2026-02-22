---
title: "Breaking change: Razor: RazorEngine APIs marked obsolete"
description: "Learn about the breaking change in ASP.NET Core 6.0 titled Razor: RazorEngine APIs marked obsolete"
no-loc: [ Razor ]
ms.author: scaddie
ms.date: 02/09/2021
ms.custom: https://github.com/aspnet/Announcements/issues/446
---
# Razor: RazorEngine APIs marked obsolete

Types related to the `Microsoft.AspNetCore.Razor.Language.RazorEngine` type in Blazor have been marked as obsolete.

## Version introduced

ASP.NET Core 6.0

## Old behavior

The `RazorEngine` APIs weren't obsolete.

## New behavior

The `RazorEngine` APIs are obsolete.

## Reason for change

The `RazorEngine` type has been deprecated as compatibility can't be guaranteed.

## Recommended action

Don't use `RazorEngine` APIs in your code.

## Affected APIs

- `Microsoft.AspNetCore.Mvc.Razor.Extensions.InjectDirective.Register`
- `Microsoft.AspNetCore.Mvc.Razor.Extensions.ModelDirective.Register`
- `Microsoft.AspNetCore.Mvc.Razor.Extensions.PageDirective.Register`
- `Microsoft.AspNetCore.Razor.Language.Extensions.FunctionsDirective.Register`
- `Microsoft.AspNetCore.Razor.Language.Extensions.InheritsDirective.Register`
- `Microsoft.AspNetCore.Razor.Language.Extensions.SectionDirective.Register`
- `Microsoft.AspNetCore.Razor.Language.IRazorEngineBuilder`
