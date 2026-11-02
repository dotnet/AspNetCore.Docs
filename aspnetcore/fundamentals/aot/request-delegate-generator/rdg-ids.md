---
title: ASP.NET Core Request Delegate Generator (RDG) diagnostics
description: Provides a list of diagnostic emitted by the ASP.NET Core Request Delegate Generator (RDG) for Native AOT
monikerRange: '>= aspnetcore-8.0'
content_well_notification: AI-contribution
ms.date: 9/23/2023
ms.topic: concept-article
ai-usage: ai-assisted
---
# ASP.NET Core Request Delegate Generator (RDG) diagnostics

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

The ASP.NET Core Request Delegate Generator (RDG) is a tool that generates request delegates for ASP.NET Core apps. The RDG is used by the native ahead-of-time (AOT) compiler to generate request delegates for the app's `Map` methods.

[!INCLUDE[](~/fundamentals/aot/includes/aot_preview.md)]

The following list contains the <!--keep--> [RDG diagnostics](https://source.dot.net/#Microsoft.AspNetCore.Http.RequestDelegateGenerator/DiagnosticDescriptors.cs,44128aef6daa9b5e) for ASP.NET Core:

<!--
* [RDG001: Unable to resolve route pattern](diagnostics/rdg001.md)
-->
* [RDG002: Unable to resolve endpoint handler](diagnostics/rdg002.md)
<!--
* [RDG003: Unable to resolve parameter](diagnostics/rdg003.md)
-->
* [RDG004: Unable to resolve anonymous type](diagnostics/rdg004.md)
* [RDG005: Invalid abstract type](diagnostics/rdg005.md)
* [RDG006: Invalid constructor parameters](diagnostics/rdg006.md)
* [RDG007: No valid constructor found](diagnostics/rdg007.md)
* [RDG008: Multiple public constructors](diagnostics/rdg008.md)
* [RDG009: Invalid nested AsParameters](diagnostics/rdg009.md)
* [RDG010:  InvalidAsParameters Nullable](diagnostics/rdg010.md)
* [RDG011: Type parameters not supported](diagnostics/rdg011.md)
* [RDG012: Unable to resolve inaccessible type](diagnostics/rdg012.md)
* [RDG013: Invalid source attributes](diagnostics/rdg013.md)
<!--
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg014>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg015>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg016>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg017>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg018>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg019>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg020>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg021>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg022>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg023>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg024>
* <xref:fundamentals/aot/request-delegate-generator/diagnostics/rdg025> -->
