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
| [AzureAD.UI and AzureADB2C.UI APIs obsolete](./5/authentication-aad-packages-obsolete.md) | ✔️ | ❌ |
| [BinaryFormatter serialization methods are obsolete](/dotnet/core/compatibility/serialization/5.0/binaryformatter-serialization-obsolete) | ✔️ | ❌ |
| [Resource in endpoint routing is HttpContext](./5/authorization-resource-in-endpoint-routing.md) | ✔️ | ❌ |
| [Microsoft-prefixed Azure integration packages removed](./5/azure-integration-packages-removed.md) | ❌ | ✔️ |
| [Blazor: Route precedence logic changed in Blazor apps](./5/blazor-routing-logic-changed.md) | ✔️ | ❌ |
| [Blazor: Updated browser support](./5/blazor-browser-support-updated.md) | ✔️ | ✔️ |
| [Blazor: Insignificant whitespace trimmed by compiler](./5/blazor-components-trim-insignificant-whitespace.md) | ✔️ | ❌ |
| [Blazor: JSObjectReference and JSInProcessObjectReference types are internal](./5/blazor-jsobjectreference-to-internal.md) | ✔️ | ❌ |
| [Blazor: Target framework of NuGet packages changed](./5/blazor-packages-target-framework-changed.md) | ❌ | ✔️ |
| [Blazor: ProtectedBrowserStorage feature moved to shared framework](./5/blazor-protectedbrowserstorage-moved.md) | ✔️ | ❌ |
| [Blazor: RenderTreeFrame readonly public fields are now properties](./5/blazor-rendertreeframe-fields-become-properties.md) | ❌ | ✔️ |
| [Blazor: Updated validation logic for static web assets](./5/blazor-static-web-assets-validation-logic-updated.md) | ❌ | ✔️ |
| [Cryptography APIs not supported on browser](/dotnet/core/compatibility/cryptography/5.0/cryptography-apis-not-supported-on-blazor-webassembly) | ❌ | ✔️ |
| [Extensions: Package reference changes](./5/extensions-package-reference-changes.md) | ❌ | ✔️ |
| [Kestrel and IIS BadHttpRequestException types are obsolete](./5/http-badhttprequestexception-obsolete.md) | ✔️ | ❌ |
| [HttpClient instances created by IHttpClientFactory log integer status codes](./5/http-httpclient-instances-log-integer-status-codes.md) | ✔️ | ❌ |
| [HttpSys: Client certificate renegotiation disabled by default](./5/httpsys-client-certificate-renegotiation-disabled-by-default.md) | ✔️ | ❌ |
| [IIS: UrlRewrite middleware query strings are preserved](./5/iis-urlrewrite-middleware-query-strings-are-preserved.md) | ✔️ | ❌ |
| [Kestrel: Configuration changes detected by default](./5/kestrel-configuration-changes-at-run-time-detected-by-default.md) | ✔️ | ❌ |
| [Kestrel: Default supported TLS protocol versions changed](./5/kestrel-default-supported-tls-protocol-versions-changed.md) | ✔️ | ❌ |
| [Kestrel: HTTP/2 disabled over TLS on incompatible Windows versions](./5/kestrel-disables-http2-over-tls.md) | ✔️ | ✔️ |
| [Kestrel: Libuv transport marked as obsolete](./5/kestrel-libuv-transport-obsolete.md) | ✔️ | ❌ |
| [Obsolete properties on ConsoleLoggerOptions](/dotnet/core/compatibility/core-libraries/5.0/obsolete-consoleloggeroptions-properties) | ✔️ | ❌ |
| [ResourceManagerWithCultureStringLocalizer class and WithCulture interface member removed](./5/localization-members-removed.md) | ✔️ | ❌ |
| [Pubternal APIs removed](./5/localization-pubternal-apis-removed.md) | ✔️ | ❌ |
| [Obsolete constructor removed in request localization middleware](./5/localization-requestlocalizationmiddleware-constructor-removed.md) | ✔️ | ❌ |
| [Middleware: Database error page marked as obsolete](./5/middleware-database-error-page-obsolete.md) | ✔️ | ❌ |
| [Exception handler middleware throws original exception](./5/middleware-exception-handler-throws-original-exception.md) | ✔️ | ✔️ |
| [ObjectModelValidator calls a new overload of Validate](./5/mvc-objectmodelvalidator-calls-new-overload.md) | ✔️ | ❌ |
| [Cookie name encoding removed](./5/security-cookie-name-encoding-removed.md) | ✔️ | ❌ |
| [IdentityModel NuGet package versions updated](./5/security-identitymodel-nuget-package-versions-updated.md) | ❌ | ✔️ |
| [SignalR: MessagePack Hub Protocol options type changed](./5/signalr-messagepack-hub-protocol-options-changed.md) | ✔️ | ❌ |
| [SignalR: MessagePack Hub Protocol moved](./5/signalr-messagepack-package.md) | ✔️ | ❌ |
| [UseSignalR and UseConnections methods removed](./5/signalr-usesignalr-useconnections-removed.md) | ✔️ | ❌ |
| [CSV content type changed to standards-compliant](./5/static-files-csv-content-type-changed.md) | ✔️ | ❌ |
