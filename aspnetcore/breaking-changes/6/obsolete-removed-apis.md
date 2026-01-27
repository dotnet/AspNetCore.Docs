---
title: "Breaking change: Obsoleted and removed APIs"
description: "Learn about the breaking change in ASP.NET Core 6.0 titled Obsoleted and removed APIs"
ms.author: scaddie
ms.date: 02/16/2021
ms.custom: https://github.com/aspnet/Announcements/issues/450
---
# Obsoleted and removed APIs

Several APIs have been either removed or marked as obsolete.

## Version introduced

ASP.NET Core 6.0

## Old behavior

In ASP.NET Core 5.0 and previous versions, the APIs weren't removed or obsolete.

## New behavior

The APIs are removed or obsoleted.

## Reason for change

The APIs are either no longer used or don't function anymore.

## Recommended action

Use the recommended replacement APIs.

## Affected APIs

* Removed [Microsoft.AspNetCore.Http.Connections.NegotiateProtocol.ParseResponse](/dotnet/api/microsoft.aspnetcore.http.connections.negotiateprotocol.parseresponse?view=aspnetcore-3.1&preserve-view=true#Microsoft_AspNetCore_Http_Connections_NegotiateProtocol_ParseResponse_System_IO_Stream_). Use <xref:Microsoft.AspNetCore.Http.Connections.NegotiateProtocol.ParseResponse(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> instead.
* Removed [Microsoft.AspNetCore.SignalR.HubInvocationContext](/dotnet/api/microsoft.aspnetcore.signalr.hubinvocationcontext.-ctor?view=aspnetcore-5.0&preserve-view=true#Microsoft_AspNetCore_SignalR_HubInvocationContext__ctor_Microsoft_AspNetCore_SignalR_HubCallerContext_System_String_System_Object___). Use <xref:Microsoft.AspNetCore.SignalR.HubInvocationContext.%23ctor(Microsoft.AspNetCore.SignalR.HubCallerContext,System.IServiceProvider,Microsoft.AspNetCore.SignalR.Hub,System.Reflection.MethodInfo,System.Collections.Generic.IReadOnlyList{System.Object})?displayProperty=nameWithType> instead.
* Removed [Microsoft.AspNetCore.Http.Features.IHttpBufferingFeature](/dotnet/api/microsoft.aspnetcore.http.features.ihttpbufferingfeature?view=aspnetcore-3.1&preserve-view=true). Use <xref:Microsoft.AspNetCore.Http.Features.IHttpResponseBodyFeature?displayProperty=nameWithType> instead.
* Removed [Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature](/dotnet/api/microsoft.aspnetcore.http.features.ihttpsendfilefeature?view=aspnetcore-3.1&preserve-view=true). Use <xref:Microsoft.AspNetCore.Http.Features.IHttpResponseBodyFeature?displayProperty=nameWithType> instead.
* Removed argument-less constructor of [Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext](/dotnet/api/microsoft.aspnetcore.staticfiles.staticfileresponsecontext.-ctor?view=aspnetcore-3.1&preserve-view=true#Microsoft_AspNetCore_StaticFiles_StaticFileResponseContext__ctor). Use <xref:Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext.%23ctor(Microsoft.AspNetCore.Http.HttpContext,Microsoft.Extensions.FileProviders.IFileInfo)?displayProperty=nameWithType> instead.
* Removed the constructor [Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor](/dotnet/api/microsoft.aspnetcore.mvc.infrastructure.objectresultexecutor.-ctor?view=aspnetcore-3.1&preserve-view=true#Microsoft_AspNetCore_Mvc_Infrastructure_ObjectResultExecutor__ctor_Microsoft_AspNetCore_Mvc_Infrastructure_OutputFormatterSelector_Microsoft_AspNetCore_Mvc_Infrastructure_IHttpResponseStreamWriterFactory_Microsoft_Extensions_Logging_ILoggerFactory_). Use <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor.%23ctor(Microsoft.AspNetCore.Mvc.Infrastructure.OutputFormatterSelector,Microsoft.AspNetCore.Mvc.Infrastructure.IHttpResponseStreamWriterFactory,Microsoft.Extensions.Logging.ILoggerFactory,Microsoft.Extensions.Options.IOptions{Microsoft.AspNetCore.Mvc.MvcOptions})?displayProperty=nameWithType> instead.
* Removed [Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor.AllowShortCircuitingValidationWhenNoValidatorsArePresent](/dotnet/api/microsoft.aspnetcore.mvc.modelbinding.validation.validationvisitor.allowshortcircuitingvalidationwhennovalidatorsarepresent?view=aspnetcore-3.1&preserve-view=true#Microsoft_AspNetCore_Mvc_ModelBinding_Validation_ValidationVisitor_AllowShortCircuitingValidationWhenNoValidatorsArePresent).
* Removed [Microsoft.AspNetCore.Mvc.ViewFeatures.ViewComponentResultExecutor](/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.viewcomponentresultexecutor.-ctor?view=aspnetcore-3.1&preserve-view=true#Microsoft_AspNetCore_Mvc_ViewFeatures_ViewComponentResultExecutor__ctor_Microsoft_Extensions_Options_IOptions_Microsoft_AspNetCore_Mvc_MvcViewOptions__Microsoft_Extensions_Logging_ILoggerFactory_System_Text_Encodings_Web_HtmlEncoder_Microsoft_AspNetCore_Mvc_ModelBinding_IModelMetadataProvider_Microsoft_AspNetCore_Mvc_ViewFeatures_ITempDataDictionaryFactory_). Use <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ViewComponentResultExecutor.%23ctor(Microsoft.Extensions.Options.IOptions{Microsoft.AspNetCore.Mvc.MvcViewOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.HtmlEncoder,Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider,Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory,Microsoft.AspNetCore.Mvc.Infrastructure.IHttpResponseStreamWriterFactory)?displayProperty=nameWithType> instead.
* Obsoleted [CompatibilityVersion](/dotnet/api/microsoft.aspnetcore.mvc.compatibilityversion?view=aspnetcore-3.1&preserve-view=true).

<!--

## Category

ASP.NET Core

## Affected APIs

- `M:Microsoft.AspNetCore.Http.Connections.NegotiateProtocol.ParseResponse(System.IO.Stream)`
- `M:Microsoft.AspNetCore.SignalR.HubInvocationContext.#ctor(Microsoft.AspNetCore.SignalR.HubCallerContext,System.String,System.Object[])`
- `T:Microsoft.AspNetCore.Http.Features.IHttpBufferingFeature`
- `T:Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature`
- `M:Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext.#ctor`
- `M:Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor.#ctor(Microsoft.AspNetCore.Mvc.Infrastructure.OutputFormatterSelector,Microsoft.AspNetCore.Mvc.Infrastructure.IHttpResponseStreamWriterFactory,Microsoft.Extensions.Logging.ILoggerFactory)`
- `Overload:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor.AllowShortCircuitingValidationWhenNoValidatorsArePresent`
- `M:Microsoft.AspNetCore.Mvc.ViewFeatures.ViewComponentResultExecutor.#ctor(Microsoft.Extensions.Options.IOptions{Microsoft.AspNetCore.Mvc.MvcViewOptions},Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.HtmlEncoder,Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider,Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory)`
- `T:Microsoft.AspNetCore.Mvc.CompatibilityVersion`

-->
