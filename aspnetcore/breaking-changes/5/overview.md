---
title: Breaking changes in ASP.NET Core 5
description: Navigate to the breaking changes in ASP.NET Core 5.
ms.date: 12/14/2020
---
# Breaking changes in ASP.NET Core 5

If you're migrating an app to ASP.NET Core 5, the breaking changes listed here might affect you. Changes are grouped by technology area, such as ASP.NET Core or cryptography.

[!INCLUDE [binary-source-compat](includes/binary-source-compat.md)]

| Title | Binary compatible | Source compatible |
| - | - | - |
| [ASP.NET Core apps deserialize quoted numbers](/dotnet/core/compatibility/serialization/5.0/jsonserializer-allows-reading-numbers-as-strings) | ✔️ | ❌ |
| [AzureAD.UI and AzureADB2C.UI APIs obsolete](authentication-aad-packages-obsolete.md) | ✔️ | ❌ |
| [BinaryFormatter serialization methods are obsolete](/dotnet/core/compatibility/serialization/5.0/binaryformatter-serialization-obsolete) | ✔️ | ❌ |
| [Resource in endpoint routing is HttpContext](authorization-resource-in-endpoint-routing.md) | ✔️ | ❌ |
| [Microsoft-prefixed Azure integration packages removed](azure-integration-packages-removed.md) | ❌ | ✔️ |
| [Blazor: Route precedence logic changed in Blazor apps](blazor-routing-logic-changed.md) | ✔️ | ❌ |
| [Blazor: Updated browser support](blazor-browser-support-updated.md) | ✔️ | ✔️ |
| [Blazor: Insignificant whitespace trimmed by compiler](blazor-components-trim-insignificant-whitespace.md) | ✔️ | ❌ |
| [Blazor: JSObjectReference and JSInProcessObjectReference types are internal](blazor-jsobjectreference-to-internal.md) | ✔️ | ❌ |
| [Blazor: Target framework of NuGet packages changed](blazor-packages-target-framework-changed.md) | ❌ | ✔️ |
| [Blazor: ProtectedBrowserStorage feature moved to shared framework](blazor-protectedbrowserstorage-moved.md) | ✔️ | ❌ |
| [Blazor: RenderTreeFrame readonly public fields are now properties](blazor-rendertreeframe-fields-become-properties.md) | ❌ | ✔️ |
| [Blazor: Updated validation logic for static web assets](blazor-static-web-assets-validation-logic-updated.md) | ❌ | ✔️ |
| [Cryptography APIs not supported on browser](/dotnet/core/compatibility/cryptography/5.0/cryptography-apis-not-supported-on-blazor-webassembly) | ❌ | ✔️ |
| [Extensions: Package reference changes](extensions-package-reference-changes.md) | ❌ | ✔️ |
| [Kestrel and IIS BadHttpRequestException types are obsolete](http-badhttprequestexception-obsolete.md) | ✔️ | ❌ |
| [HttpClient instances created by IHttpClientFactory log integer status codes](http-httpclient-instances-log-integer-status-codes.md) | ✔️ | ❌ |
| [HttpSys: Client certificate renegotiation disabled by default](httpsys-client-certificate-renegotiation-disabled-by-default.md) | ✔️ | ❌ |
| [IIS: UrlRewrite middleware query strings are preserved](iis-urlrewrite-middleware-query-strings-are-preserved.md) | ✔️ | ❌ |
| [Kestrel: Configuration changes detected by default](kestrel-configuration-changes-at-run-time-detected-by-default.md) | ✔️ | ❌ |
| [Kestrel: Default supported TLS protocol versions changed](kestrel-default-supported-tls-protocol-versions-changed.md) | ✔️ | ❌ |
| [Kestrel: HTTP/2 disabled over TLS on incompatible Windows versions](kestrel-disables-http2-over-tls.md) | ✔️ | ✔️ |
| [Kestrel: Libuv transport marked as obsolete](kestrel-libuv-transport-obsolete.md) | ✔️ | ❌ |
| [Obsolete properties on ConsoleLoggerOptions](/dotnet/core/compatibility/core-libraries/5.0/obsolete-consoleloggeroptions-properties) | ✔️ | ❌ |
| [ResourceManagerWithCultureStringLocalizer class and WithCulture interface member removed](localization-members-removed.md) | ✔️ | ❌ |
| [Pubternal APIs removed](localization-pubternal-apis-removed.md) | ✔️ | ❌ |
| [Obsolete constructor removed in request localization middleware](localization-requestlocalizationmiddleware-constructor-removed.md) | ✔️ | ❌ |
| [Middleware: Database error page marked as obsolete](middleware-database-error-page-obsolete.md) | ✔️ | ❌ |
| [Exception handler middleware throws original exception](middleware-exception-handler-throws-original-exception.md) | ✔️ | ✔️ |
| [ObjectModelValidator calls a new overload of Validate](mvc-objectmodelvalidator-calls-new-overload.md) | ✔️ | ❌ |
| [Cookie name encoding removed](security-cookie-name-encoding-removed.md) | ✔️ | ❌ |
| [IdentityModel NuGet package versions updated](security-identitymodel-nuget-package-versions-updated.md) | ❌ | ✔️ |
| [SignalR: MessagePack Hub Protocol options type changed](signalr-messagepack-hub-protocol-options-changed.md) | ✔️ | ❌ |
| [SignalR: MessagePack Hub Protocol moved](signalr-messagepack-package.md) | ✔️ | ❌ |
| [UseSignalR and UseConnections methods removed](signalr-usesignalr-useconnections-removed.md) | ✔️ | ❌ |
| [CSV content type changed to standards-compliant](static-files-csv-content-type-changed.md) | ✔️ | ❌ |
