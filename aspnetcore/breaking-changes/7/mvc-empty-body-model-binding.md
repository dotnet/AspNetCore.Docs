---
title: "Breaking change: MVC's detection of an empty body in model binding changed"
description: Learn about the breaking change in ASP.NET Core 7.0 where MVC's detection of an empty body in model binding changed.
ms.date: 04/04/2022
ms.custom: https://github.com/aspnet/Announcements/issues/484
---

# MVC's detection of an empty body in model binding changed

The mechanism to detect an empty request body during MVC model binding now uses <xref:Microsoft.AspNetCore.Http.Features.IHttpRequestBodyDetectionFeature.CanHaveBody%2A?displayProperty=nameWithType>. This property is set to:

* `true`:
  * For `HTTP/1.x` requests with a non-zero `Content-Length` request header or a `Transfer-Encoding: chunked` request header.
  * For `HTTP/2` requests that don't set the `END_STREAM` flag on the initial header's frame.

* `false`:
  * For `HTTP/1.x` requests with no `Content-Length` or `Transfer-Encoding: chunked` request headers, or if the `Content-Length` request header is `0`.
  * For `HTTP/1.x` requests with a `Connection: Upgrade` request header, such as for WebSockets requests. There's no HTTP request body for such requests, so no data should be received until after the upgrade.
  * For `HTTP/2` requests that set the `END_STREAM` flag on the initial header's frame.

The previous behavior performed a minimal validation of `Content-Length = 0`. In some scenarios, when requests don't include all required HTTP headers and flags, request bodies can now be detected as having an empty body and report a failure to the client.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

If a controller action binds a parameter from the request body and the client request doesn't include a `Content-Length` request header, the framework throws an internal exception during deserialization of the request body. For example, the `System.Text.Json`-based input formatter throws an exception similar to the following:

```
System.Text.Json.JsonException: 'The input does not contain any JSON tokens.
Expected the input to start with a valid JSON token, when isFinalBlock is true.
Path: $ | LineNumber: 0 | BytePositionInLine: 0.'
```

The following example JSON shows the previous exception formatted as a <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> response:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-34e98b5841b88bfb5476965efd9d9c8c-5bb16bc50dfbabb7-00",
  "errors": {
    "$": [
      "The input does not contain any JSON tokens. Expected the input to start with a valid JSON token, when isFinalBlock is true. Path: $ | LineNumber: 0 | BytePositionInLine: 0."
    ],
    "value": [
      "The value field is required."
    ]
  }
}
```

## New behavior

Deserialization is no longer attempted if <xref:Microsoft.AspNetCore.Http.Features.IHttpRequestBodyDetectionFeature.CanHaveBody%2A?displayProperty=nameWithType> is `false`. The following example <xref:Microsoft.AspNetCore.Mvc.ProblemDetails> response shows how the error message returned to clients indicates that the request body is empty:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-0f87920dc675fdfdf8d7638d3be66577-bd6bdbf32d21b714-00",
  "errors": {
    "": [
      "A non-empty request body is required."
    ],
    "value": [
      "The value field is required."
    ]
  }
}
```

## Type of breaking change

This change affects [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

To align with other parts of the framework that use <xref:Microsoft.AspNetCore.Http.Features.IHttpRequestBodyDetectionFeature.CanHaveBody%2A?displayProperty=nameWithType> and to fix [Optional `[FromBody]` Model Binding is not working (dotnet/aspnetcore #29570)](https://github.com/dotnet/aspnetcore/issues/29570).

## Recommended action

No changes are required. However, if you're seeing unexpected behavior, ensure that client requests send the appropriate HTTP headers.

## Affected APIs

MVC controller actions
