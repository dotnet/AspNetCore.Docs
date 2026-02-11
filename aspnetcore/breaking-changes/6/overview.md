---
title: Breaking changes in ASP.NET Core 6
titleSuffix: ""
description: Navigate to the breaking changes in ASP.NET Core 6.
ms.date: 07/28/2023
no-loc: [Blazor, Razor, Kestrel]
---
# Breaking changes in ASP.NET Core 6

If you're migrating an app to ASP.NET Core 6, the breaking changes listed here might affect you.

[!INCLUDE [binary-source-compat](../includes/binary-source-compat.md)]

| Title | Binary compatible | Source compatible |
| - | :-: | :-: |
| [ActionResult\<T> sets StatusCode to 200](actionresult-statuscode.md) | ✔️ | ❌ |
| [AddDataAnnotationsValidation method made obsolete](adddataannotationsvalidation-obsolete.md) | ✔️ | ❌ |
| [Assemblies removed from Microsoft.AspNetCore.App shared framework](assemblies-removed-from-shared-framework.md) | ❌ | ✔️ |
| [Blazor: Parameter name changed in RequestImageFileAsync method](blazor-parameter-name-changed-in-method.md) | ✔️ | ❌ |
| [Blazor: WebEventDescriptor.EventArgsType property replaced](blazor-eventargstype-property-replaced.md) | ❌ | ❌ |
| [Blazor: Byte array interop](byte-array-interop.md) | ✔️ | ❌ |
| [Changed MessagePack library in @microsoft/signalr-protocol-msgpack](messagepack-library-change.md) | ❌ | ✔️ |
| [ClientCertificate property doesn't trigger renegotiation for HttpSys](clientcertificate-doesnt-trigger-renegotiation.md) | ✔️ | ❌ |
| [EndpointName metadata not set automatically](endpointname-metadata.md) | ✔️ | ❌ |
| [Identity: Default Bootstrap version of UI changed](identity-bootstrap4-to-5.md) | ❌ | ❌  |
| [Kestrel: Log message attributes changed](kestrel-log-message-attributes-changed.md) | ✔️ | ❌ |
| [Microsoft.AspNetCore.Http.Features split](microsoft-aspnetcore-http-features-package-split.md) | ❌ | ✔️ |
| [Middleware: HTTPS Redirection Middleware throws exception on ambiguous HTTPS ports](middleware-ambiguous-https-ports-exception.md) | ✔️ | ❌ |
| [Middleware: New Use overload](middleware-new-use-overload.md) | ✔️ | ❌ |
| [Minimal API renames in RC 1](rc1-minimal-api-renames.md) | ❌ | ❌ |
| [Minimal API renames in RC 2](rc2-minimal-api-renames.md) | ❌ | ❌ |
| [MVC doesn't buffer IAsyncEnumerable types when using System.Text.Json](iasyncenumerable-not-buffered-by-mvc.md) | ✔️ | ❌ |
| [Nullable reference type annotations changed](nullable-reference-type-annotations-changed.md) | ✔️ | ❌ |
| [Obsoleted and removed APIs](obsolete-removed-apis.md) | ✔️ | ❌ |
| [PreserveCompilationContext not configured by default](preservecompilationcontext-not-set-by-default.md) | ❌ | ✔️ |
| [Razor: Compiler no longer produces a Views assembly](razor-compiler-doesnt-produce-views-assembly.md) | ✔️ | ❌ |
| [Razor: Logging ID changes](razor-pages-logging-ids.md) | ❌ | ✔️ |
| [Razor: RazorEngine APIs marked obsolete](razor-engine-apis-obsolete.md) | ✔️ | ❌ |
| [SignalR: Java Client updated to RxJava3](signalr-java-client-updated.md) | ❌ | ✔️ |
| [TryParse and BindAsync methods are validated](tryparse-bindasync-validation.md) | ❌ | ❌ |
