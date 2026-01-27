---
title: Breaking changes in ASP.NET Core 6
titleSuffix: ""
description: Navigate to the breaking changes in ASP.NET Core 6.
ms.date: 07/28/2023
no-loc: [Blazor, Razor, Kestrel]
---
# Breaking changes in ASP.NET Core 6

If you're migrating an app to ASP.NET Core 6, the breaking changes listed here might affect you.

[!INCLUDE [binary-source-compat](includes/binary-source-compat.md)]

| Title | Binary compatible | Source compatible |
| - | :-: | :-: |
| [ActionResult\<T> sets StatusCode to 200](./6/actionresult-statuscode.md) | ✔️ | ❌ |
| [AddDataAnnotationsValidation method made obsolete](./6/adddataannotationsvalidation-obsolete.md) | ✔️ | ❌ |
| [Assemblies removed from Microsoft.AspNetCore.App shared framework](./6/assemblies-removed-from-shared-framework.md) | ❌ | ✔️ |
| [Blazor: Parameter name changed in RequestImageFileAsync method](./6/blazor-parameter-name-changed-in-method.md) | ✔️ | ❌ |
| [Blazor: WebEventDescriptor.EventArgsType property replaced](./6/blazor-eventargstype-property-replaced.md) | ❌ | ❌ |
| [Blazor: Byte array interop](./6/byte-array-interop.md) | ✔️ | ❌ |
| [Changed MessagePack library in @microsoft/signalr-protocol-msgpack](./6/messagepack-library-change.md) | ❌ | ✔️ |
| [ClientCertificate property doesn't trigger renegotiation for HttpSys](./6/clientcertificate-doesnt-trigger-renegotiation.md) | ✔️ | ❌ |
| [EndpointName metadata not set automatically](./6/endpointname-metadata.md) | ✔️ | ❌ |
| [Identity: Default Bootstrap version of UI changed](./6/identity-bootstrap4-to-5.md) | ❌ | ❌  |
| [Kestrel: Log message attributes changed](./6/kestrel-log-message-attributes-changed.md) | ✔️ | ❌ |
| [Microsoft.AspNetCore.Http.Features split](./6/microsoft-aspnetcore-http-features-package-split.md) | ❌ | ✔️ |
| [Middleware: HTTPS Redirection Middleware throws exception on ambiguous HTTPS ports](./6/middleware-ambiguous-https-ports-exception.md) | ✔️ | ❌ |
| [Middleware: New Use overload](./6/middleware-new-use-overload.md) | ✔️ | ❌ |
| [Minimal API renames in RC 1](./6/rc1-minimal-api-renames.md) | ❌ | ❌ |
| [Minimal API renames in RC 2](./6/rc2-minimal-api-renames.md) | ❌ | ❌ |
| [MVC doesn't buffer IAsyncEnumerable types when using System.Text.Json](./6/iasyncenumerable-not-buffered-by-mvc.md) | ✔️ | ❌ |
| [Nullable reference type annotations changed](./6/nullable-reference-type-annotations-changed.md) | ✔️ | ❌ |
| [Obsoleted and removed APIs](./6/obsolete-removed-apis.md) | ✔️ | ❌ |
| [PreserveCompilationContext not configured by default](./6/preservecompilationcontext-not-set-by-default.md) | ❌ | ✔️ |
| [Razor: Compiler no longer produces a Views assembly](./6/razor-compiler-doesnt-produce-views-assembly.md) | ✔️ | ❌ |
| [Razor: Logging ID changes](./6/razor-pages-logging-ids.md) | ❌ | ✔️ |
| [Razor: RazorEngine APIs marked obsolete](./6/razor-engine-apis-obsolete.md) | ✔️ | ❌ |
| [SignalR: Java Client updated to RxJava3](./6/signalr-java-client-updated.md) | ❌ | ✔️ |
| [TryParse and BindAsync methods are validated](./6/tryparse-bindasync-validation.md) | ❌ | ❌ |
