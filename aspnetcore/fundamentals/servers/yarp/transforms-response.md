---
uid: fundamentals/servers/yarp/transforms-response
title: YARP Response and Response Trailer Transforms
description: YARP Response and Response Trailer Transforms
author: samsp-msft
ms.author: samsp
$104/04/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---

# Response and Response Trailers

All response headers and trailers are copied from the proxied response to the outgoing client response by default. Response and response trailer transforms may specify if they should be applied only for successful responses or for all responses.

In code these are implemented as derivations of the abstract classes [ResponseTransform](xref:Yarp.ReverseProxy.Transforms.ResponseTransform) and [ResponseTrailersTransform](xref:Yarp.ReverseProxy.Transforms.ResponseTrailersTransform).

## ResponseHeadersCopy

**Sets whether destination response headers are copied to the client**

| Key                 | Value      | Default | Required |
| ------------------- | ---------- | ------- | -------- |
| ResponseHeadersCopy | true/false | true    | yes      |

Config:
```json
{ "ResponseHeadersCopy": "false" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformCopyResponseHeaders(copy: false);
```
```csharp
transformBuilderContext.CopyResponseHeaders = false;
```

This sets if all proxy response headers are copied to the client response. This setting is enabled by default and can be disabled by configuring the transform with a `false` value. Transforms that reference specific headers will still be run if this is disabled.

## ResponseHeader

**Adds or replaces response headers**

| Key            | Value                  | Default | Required |
| -------------- | ---------------------- | ------- | -------- |
| ResponseHeader | The header name        | (none)  | yes      |
| Set/Append     | The header value       | (none)  | yes      |
| When           | Success/Always/Failure | Success | no       |

Config:
```json
{
  "ResponseHeader": "HeaderName",
  "Append": "value",
  "When": "Success"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformResponseHeader(headerName: "HeaderName", value: "value", append: true, ResponseCondition.Success);
```
```csharp
transformBuilderContext.AddResponseHeader(headerName: "HeaderName", value: "value", append: true, always: ResponseCondition.Success);
```
Example:
```
HeaderName: value
```

This sets or appends the value for the named response header. Set replaces any existing header. Append adds an additional header with the given value.
Note: setting "" as a header value is not recommended and can cause an undefined behavior.

`When` specifies if the response header should be included for all, successful, or failure responses. Any response with a status code less than 400 is considered a success.

## ResponseHeaderRemove

**Removes response headers**

| Key                  | Value                  | Default | Required |
| -------------------- | ---------------------- | ------- | -------- |
| ResponseHeaderRemove | The header name        | (none)  | yes      |
| When                 | Success/Always/Failure | Success | no       |

Config:
```json
{
  "ResponseHeaderRemove": "HeaderName",
  "When": "Success"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformResponseHeaderRemove(headerName: "HeaderName", ResponseCondition.Success);
```
```csharp
transformBuilderContext.AddResponseHeaderRemove(headerName: "HeaderName", ResponseCondition.Success);
```
Example:
```
HeaderName: value
AnotherHeader: another-value
```

This removes the named response header.

`When` specifies if the response header should be removed for all, successful, or failure responses. Any response with a status code less than 400 is considered a success.

## ResponseHeadersAllowed

| Key                    | Value                                               | Required |
| ---------------------- | --------------------------------------------------- | -------- |
| ResponseHeadersAllowed | A semicolon separated list of allowed header names. | yes      |

Config:
```json
{
  "ResponseHeadersAllowed": "Header1;header2"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformResponseHeadersAllowed("Header1", "header2");
```
```csharp
transformBuilderContext.AddResponseHeadersAllowed("Header1", "header2");
```

YARP copies most response headers from the proxy response by default (see [ResponseHeadersCopy](xref:fundamentals/servers/yarp/transforms#responseheaderscopy)). Some security models only allow specific headers to be proxied. This transform disables ResponseHeadersCopy and only copies the given headers. Other transforms that modify or append to existing headers may be affected if not included in the allow list.

Note that there are some headers YARP does not copy by default since they are connection specific or otherwise security sensitive (e.g. `Connection`, `Alt-Svc`). Putting those header names in the allow list will bypass that restriction but is strongly discouraged as it may negatively affect the functionality of the proxy or cause security vulnerabilities.

Example:
```
Header1: value1
Header2: value2
AnotherHeader: AnotherValue
```

Only header1 and header2 are copied from the proxy response.

## ResponseTrailersCopy

**Sets whether destination trailing response headers are copied to the client**

| Key                  | Value      | Default | Required |
| -------------------- | ---------- | ------- | -------- |
| ResponseTrailersCopy | true/false | true    | yes      |

Config:
```json
{ "ResponseTrailersCopy": "false" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformCopyResponseTrailers(copy: false);
```
```csharp
transformBuilderContext.CopyResponseTrailers = false;
```

This sets if all proxy response trailers are copied to the client response. This setting is enabled by default and can be disabled by configuring the transform with a `false` value. Transforms that reference specific headers will still be run if this is disabled.

## ResponseTrailer

**Adds or replaces trailing response headers**

| Key             | Value                  | Default | Required |
| --------------- | ---------------------- | ------- | -------- |
| ResponseTrailer | The header name        | (none)  | yes      |
| Set/Append      | The header value       | (none)  | yes      |
| When            | Success/Always/Failure | Success | no       |

Config:
```json
{
  "ResponseTrailer": "HeaderName",
  "Append": "value",
  "When": "Success"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformResponseTrailer(headerName: "HeaderName", value: "value", append: true, ResponseCondition.Success);
```
```csharp
transformBuilderContext.AddResponseTrailer(headerName: "HeaderName", value: "value", append: true, ResponseCondition.Success);
```
Example:
```
HeaderName: value
```

Response trailers are headers sent at the end of the response body. Support for trailers is uncommon in HTTP/1.1 implementations but is becoming common in HTTP/2 implementations. Check your client and server for support.

ResponseTrailer follows the same structure and guidance as [ResponseHeader](xref:fundamentals/servers/yarp/transforms#responseheader).

## ResponseTrailerRemove

**Removes trailing response headers**

| Key                   | Value                  | Default | Required |
| --------------------- | ---------------------- | ------- | -------- |
| ResponseTrailerRemove | The header name        | (none)  | yes      |
| When                  | Success/Always/Failure | Success | no       |

Config:
```json
{
  "ResponseTrailerRemove": "HeaderName",
  "When": "Success"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformResponseTrailerRemove(headerName: "HeaderName", ResponseCondition.Success);
```
```csharp
transformBuilderContext.AddResponseTrailerRemove(headerName: "HeaderName", ResponseCondition.Success);
```
Example:
```
HeaderName: value
AnotherHeader: another-value
```

This removes the named trailing header.

ResponseTrailerRemove follows the same structure and guidance as [ResponseHeaderRemove](xref:fundamentals/servers/yarp/transforms#responseheaderremove).

## ResponseTrailersAllowed

| Key                     | Value                                               | Required |
| ----------------------- | --------------------------------------------------- | -------- |
| ResponseTrailersAllowed | A semicolon separated list of allowed header names. | yes      |

Config:
```json
{
  "ResponseTrailersAllowed": "Header1;header2"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformResponseTrailersAllowed("Header1", "header2");
```
```csharp
transformBuilderContext.AddResponseTrailersAllowed("Header1", "header2");
```

YARP copies most response trailers from the proxy response by default (see [ResponseTrailersCopy](xref:fundamentals/servers/yarp/transforms#responsetrailerscopy)). Some security models only allow specific headers to be proxied. This transform disables ResponseTrailersCopy and only copies the given headers. Other transforms that modify or append to existing headers may be affected if not included in the allow list.

Note that there are some headers YARP does not copy by default since they are connection specific or otherwise security sensitive (e.g. `Connection`, `Alt-Svc`). Putting those header names in the allow list will bypass that restriction but is strongly discouraged as it may negatively affect the functionality of the proxy or cause security vulnerabilities.

Example:
```
Header1: value1
Header2: value2
AnotherHeader: AnotherValue
```

Only header1 and header2 are copied from the proxy response.