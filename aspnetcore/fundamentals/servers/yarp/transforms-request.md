---
uid: fundamentals/servers/yarp/transforms-request
title: YARP Request Transforms
description: YARP Request Transforms
author: tdykstra
ms.author: tdykstra
ms.date: 2/6/2025
ms.topic: concept-article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---

# Request transforms

Request transforms include the request path, query, HTTP version, method, and headers. In code these are represented by the [RequestTransformContext](xref:Yarp.ReverseProxy.Transforms.RequestTransformContext) object and processed by implementations of the abstract class [RequestTransform](xref:Yarp.ReverseProxy.Transforms.RequestTransform).

Notes:

* The proxy request scheme (http/https), authority, and path base, are taken from the destination server address (`https://localhost:10001/Path/Base` in the example above) and should not be modified by transforms.
* The Host header can be overridden by transforms independent of the authority, see [RequestHeader](#requestheader) below.
* The request's original PathBase property is not used when constructing the proxy request, see [X-Forwarded](#x-forwarded).
* All incoming request headers are copied to the proxy request by default with the exception of the Host header (see `Defaults`<!-- fix ](#defaults--> [Defaults](xref:fundamentals/servers/yarp/timeouts#defaults)). [X-Forwarded](#x-forwarded) headers are also added by default. These behaviors can be configured using the following transforms. Additional request headers can be specified, or request headers can be excluded by setting them to an empty value.

The following are built in transforms identified by their primary config key. These transforms are applied in the order they are specified in the route configuration.

## PathPrefix

**Modifies the request path adding a prefix value**

| Key        | Value                      | Required |
| ---------- | -------------------------- | -------- |
| PathPrefix | A path starting with a '/' | yes      |

Config:
```json
{ "PathPrefix": "/prefix" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformPathPrefix(prefix: "/prefix");
```
```csharp
transformBuilderContext.AddPathPrefix(prefix: "/prefix");
```
Example:<br/>
`/request/path` becomes `/prefix/request/path`

This will prefix the request path with the given value.

## PathRemovePrefix

**Modifies the request path removing a prefix value**

| Key              | Value                      | Required |
| ---------------- | -------------------------- | -------- |
| PathRemovePrefix | A path starting with a '/' | yes      |

Config:
```json
{ "PathRemovePrefix": "/prefix" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformPathRemovePrefix(prefix: "/prefix");
```
```csharp
transformBuilderContext.AddPathRemovePrefix(prefix: "/prefix");
```
Example:<br/>
`/prefix/request/path` becomes `/request/path`<br/>
`/prefix2/request/path` is not modified<br/>

This will remove the matching prefix from the request path. Matches are made on path segment boundaries (`/`). If the prefix does not match then no changes are made.

## PathSet

**Replaces the request path with the specified value**

| Key     | Value                      | Required |
| ------- | -------------------------- | -------- |
| PathSet | A path starting with a '/' | yes      |

Config:
```json
{ "PathSet": "/newpath" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformPathSet(path: "/newpath");
```
```csharp
transformBuilderContext.AddPathSet(path: "/newpath");
```
Example:<br/>
`/request/path` becomes `/newpath`

This will set the request path with the given value.

## PathPattern

**Replaces the request path using a pattern template**

| Key         | Value                               | Required |
| ----------- | ----------------------------------- | -------- |
| PathPattern | A path template starting with a '/' | yes      |

Config:
```json
{ "PathPattern": "/my/{plugin}/api/{**remainder}" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformPathRouteValues(
    pattern: new PathString("/my/{plugin}/api/{**remainder}"));
```
```csharp
transformBuilderContext.AddPathRouteValues(
    pattern: new PathString("/my/{plugin}/api/{**remainder}"));
```

This will set the request path with the given value and replace any `{}` segments with the associated route value. `{}` segments without a matching route value are removed. The final `{}` segment can be marked as `{**remainder}` to indicate this is a catch-all segment that may contain multiple path segments. See ASP.NET Core's [routing docs](/aspnet/core/fundamentals/routing#route-template-reference) for more information about route templates.

Example:

| Step             | Value                               |
| ---------------- | ----------------------------------- |
| Route definition | `/api/{plugin}/stuff/{**remainder}` |
| Request path     | `/api/v1/stuff/more/stuff`          |
| Plugin value     | `v1`                                |
| Remainder value  | `more/stuff`                        |
| PathPattern      | `/my/{plugin}/api/{**remainder}`    |
| Result           | `/my/v1/api/more/stuff`             |

## QueryValueParameter

**Adds or replaces parameters in the request query string**

| Key                 | Value                            | Required |
| ------------------- | -------------------------------- | -------- |
| QueryValueParameter | Name of a query string parameter | yes      |
| Set/Append          | Static value                     | yes      |

Config:
```json
{
  "QueryValueParameter": "foo",
  "Append": "bar"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformQueryValue(
    queryKey: "foo", value: "bar", append: true);
```
```csharp
transformBuilderContext.AddQueryValue(
    queryKey: "foo", value: "bar", append: true);
```

This will add a query string parameter with the name `foo` and sets it to the static value `bar`.

Example:

| Step                | Value                |
| ------------------- | -------------------- |
| Query               | `?a=b`               |
| QueryValueParameter | `foo`                |
| Append              | `remainder`          |
| Result              | `?a=b&foo=remainder` |

## QueryRouteParameter

**Adds or replaces a query string parameter with a value from the route configuration**

| Key                 | Value                            | Required |
| ------------------- | -------------------------------- | -------- |
| QueryRouteParameter | Name of a query string parameter | yes      |
| Set/Append          | The name of a route value        | yes      |

Config:
```json
{
  "QueryRouteParameter": "foo",
  "Append": "remainder"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformQueryRouteValue(
    queryKey: "foo", routeValueKey: "remainder", append: true);
```
```csharp
transformBuilderContext.AddQueryRouteValue(
    queryKey: "foo", routeValueKey: "remainder", append: true);
```

This will add a query string parameter with the name `foo` and sets it to the value of the associated route value.

Example:

| Step                | Value               |
| ------------------- | ------------------- |
| Route definition    | `/api/{*remainder}` |
| Request path        | `/api/more/stuff`   |
| Remainder value     | `more/stuff`        |
| QueryRouteParameter | `foo`               |
| Append              | `remainder`         |
| Result              | `?foo=more/stuff`   |

## QueryRemoveParameter

**Removes the specified parameter from the request query string**

| Key                  | Value                            | Required |
| -------------------- | -------------------------------- | -------- |
| QueryRemoveParameter | Name of a query string parameter | yes      |

Config:
```json
{ "QueryRemoveParameter": "foo" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformQueryRemoveKey(queryKey: "foo");
```
```csharp
transformBuilderContext.AddQueryRemoveKey(queryKey: "foo");
```

This will remove a query string parameter with the name `foo` if present on the request.

Example:

| Step                 | Value        |
| -------------------- | ------------ |
| Request path         | `?a=b&foo=c` |
| QueryRemoveParameter | `foo`        |
| Result               | `?a=b`       |

## HttpMethodChange

**Changes the http method used in the request**

| Key              | Value                      | Required |
| ---------------- | -------------------------- | -------- |
| HttpMethodChange | The http method to replace | yes      |
| Set              | The new http method        | yes      |

Config:
```json
{
  "HttpMethodChange": "PUT",
  "Set": "POST"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformHttpMethodChange(
    fromHttpMethod: HttpMethods.Put, toHttpMethod: HttpMethods.Post);
```

```csharp
transformBuilderContext.AddHttpMethodChange(
    fromHttpMethod: HttpMethods.Put, toHttpMethod: HttpMethods.Post);
```

This will change PUT requests to POST.

## RequestHeadersCopy

**Sets whether incoming request headers are copied to the outbound request**

| Key                | Value      | Default | Required |
| ------------------ | ---------- | ------- | -------- |
| RequestHeadersCopy | true/false | true    | yes      |

Config:
```json
{ "RequestHeadersCopy": "false" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformCopyRequestHeaders(copy: false);
```
```csharp
transformBuilderContext.CopyRequestHeaders = false;
```

This sets if all incoming request headers are copied to the proxy request. This setting is enabled by default and can by disabled by configuring the transform with a `false` value. Transforms that reference specific headers will still be run if this is disabled.

## RequestHeaderOriginalHost

**Specifies if the incoming request Host header should be copied to the proxy request**

| Key                       | Value      | Default | Required |
| ------------------------- | ---------- | ------- | -------- |
| RequestHeaderOriginalHost | true/false | false   | yes      |

Config:
```json
{ "RequestHeaderOriginalHost": "true" }
```
```csharp
routeConfig = routeConfig.WithTransformUseOriginalHostHeader(useOriginal: true);
```
```csharp
transformBuilderContext.AddOriginalHost(true);
```

This specifies if the incoming request Host header should be copied to the proxy request. This setting is disabled by default and can be enabled by configuring the transform with a `true` value. Transforms that directly reference the `Host` header will override this transform.

## RequestHeader

**Adds or replaces request headers**

| Key           | Value            | Required |
| ------------- | ---------------- | -------- |
| RequestHeader | The header name  | yes      |
| Set/Append    | The header value | yes      |

Config:
```json
{
  "RequestHeader": "MyHeader",
  "Set": "MyValue"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformRequestHeader(
    headerName: "MyHeader", value: "MyValue", append: false);
```
```csharp
transformBuilderContext.AddRequestHeader(
    headerName: "MyHeader", value: "MyValue", append: false);
```

Example:
```
MyHeader: MyValue
```

This sets or appends the value for the named header. Set replaces any existing header. Append adds an additional header with the given value.
Note: setting "" as a header value is not recommended and can cause an undefined behavior.

## RequestHeaderRouteValue

**Adds or replaces a header with a value from the route configuration**

| Key           | Value                            | Required |
| ------------- | -------------------------------- | -------- |
| RequestHeader | Name of a query string parameter | yes      |
| Set/Append    | The name of a route value        | yes      |

Config:
```json
{
  "RequestHeaderRouteValue": "MyHeader",
  "Set": "MyRouteKey"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformRequestHeaderRouteValue(
    headerName: "MyHeader", routeValueKey: "key", append: false);
```
```csharp
transformBuilderContext.AddRequestHeaderRouteValue(
    headerName: "MyHeader", routeValueKey: "key", append: false);
```

Example:

| Step                   | Value               |
| ---------------------- | ------------------- |
| Route definition       | `/api/{*remainder}` |
| Request path           | `/api/more/stuff`   |
| Remainder value        | `more/stuff`        |
| RequestHeaderFromRoute | `foo`               |
| Append                 | `remainder`         |
| Result                 | `foo: more/stuff`   |

This sets or appends the value for the named header with a value from the route configuration. Set replaces any existing header. Append adds an additional header with the given value.
Note: setting "" as a header value is not recommended and can cause an undefined behavior.

## RequestHeaderRemove

**Removes request headers**

| Key                 | Value           | Required |
| ------------------- | --------------- | -------- |
| RequestHeaderRemove | The header name | yes      |

Config:
```json
{
  "RequestHeaderRemove": "MyHeader"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformRequestHeaderRemove(headerName: "MyHeader");
```
```csharp
transformBuilderContext.AddRequestHeaderRemove(headerName: "MyHeader");
```

Example:
```
MyHeader: MyValue
AnotherHeader: AnotherValue
```

This removes the named header.

## RequestHeadersAllowed

| Key                   | Value                                               | Required |
| --------------------- | --------------------------------------------------- | -------- |
| RequestHeadersAllowed | A semicolon separated list of allowed header names. | yes      |

Config:
```json
{
  "RequestHeadersAllowed": "Header1;header2"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformRequestHeadersAllowed("Header1", "header2");
```
```csharp
transformBuilderContext.AddRequestHeadersAllowed("Header1", "header2");
```

YARP copies most request headers to the proxy request by default (see [RequestHeadersCopy](xref:fundamentals/servers/yarp/transforms#requestheaderscopy)). Some security models only allow specific headers to be proxied. This transform disables RequestHeadersCopy and only copies the given headers. Other transforms that modify or append to existing headers may be affected if not included in the allow list.

Note that there are some headers YARP does not copy by default since they are connection specific or otherwise security sensitive (e.g. `Connection`, `Alt-Svc`). Putting those header names in the allow list will bypass that restriction but is strongly discouraged as it may negatively affect the functionality of the proxy or cause security vulnerabilities.

Example:
```
Header1: value1
Header2: value2
AnotherHeader: AnotherValue
```

Only header1 and header2 are copied to the proxy request.

## X-Forwarded

**Adds headers with information about the original client request**

| Key          | Value                                                                                | Default           | Required |
| ------------ | ------------------------------------------------------------------------------------ | ----------------- | -------- |
| X-Forwarded  | Default action (Set, Append, Remove, Off) to apply to all X-Forwarded-* listed below | Set               | yes      |
| For          | Action to apply to this header                                                       | * See X-Forwarded | no       |
| Proto        | Action to apply to this header                                                       | * See X-Forwarded | no       |
| Host         | Action to apply to this header                                                       | * See X-Forwarded | no       |
| Prefix       | Action to apply to this header                                                       | * See X-Forwarded | no       |
| HeaderPrefix | The header name prefix                                                               | "X-Forwarded-"    | no       |

Action "Off" completely disables the transform.

Config:
```json
{
  "X-Forwarded": "Set",
  "For": "Remove",
  "Proto": "Append",
  "Prefix": "Off",
  "HeaderPrefix": "X-Forwarded-"
}
```
Code:
```csharp
routeConfig = routeConfig.WithTransformXForwarded(
  headerPrefix = "X-Forwarded-",
  ForwardedTransformActions xDefault = ForwardedTransformActions.Set,
  ForwardedTransformActions? xFor = null,
  ForwardedTransformActions? xHost = null,
  ForwardedTransformActions? xProto = null,
  ForwardedTransformActions? xPrefix = null);
```
```csharp
transformBuilderContext.AddXForwarded(ForwardedTransformActions.Set);
transformBuilderContext.AddXForwardedFor(headerName: "X-Forwarded-For", ForwardedTransformActions.Append);
transformBuilderContext.AddXForwardedHost(headerName: "X-Forwarded-Host", ForwardedTransformActions.Append);
transformBuilderContext.AddXForwardedProto(headerName: "X-Forwarded-Proto", ForwardedTransformActions.Off);
transformBuilderContext.AddXForwardedPrefix(headerName: "X-Forwarded-Prefix", ForwardedTransformActions.Remove);
```

Example:
```
X-Forwarded-For: 5.5.5.5
X-Forwarded-Proto: https
X-Forwarded-Host: IncomingHost:5000
X-Forwarded-Prefix: /path/base
```
Disable default headers:
```json
{ "X-Forwarded": "Off" }
```
```csharp
transformBuilderContext.UseDefaultForwarders = false;
```

When the proxy connects to the destination server, the connection is independent from the one the client made to the proxy. The destination server likely needs original connection information for security checks and to properly generate absolute URIs for links and redirects. To enable information about the client connection to be passed to the destination a set of extra headers can be added. Until the `Forwarded` standard was created, a common solution is to use `X-Forwarded-*` headers. There is no official standard that defines the `X-Forwarded-*` headers and implementations vary, check your destination server for support.

This transform is enabled by default even if not specified in the route config.

Set the `X-Forwarded` value to a comma separated list containing the headers you need to enable. All for headers are enabled by default. All can be disabled by specifying the value `"Off"`.


The Prefix specifies the header name prefix to use for each header. With the default `X-Forwarded-` prefix the resulting headers will be `X-Forwarded-For`, `X-Forwarded-Proto`, `X-Forwarded-Host`, and `X-Forwarded-Prefix`.

Transform action specifies how each header should be combined with an existing header of the same name. It can be "Set", "Append", "Remove, or "Off" (completely disable the transform). A request traversing multiple proxies may accumulate a list of such headers and the destination server will need to evaluate the list to determine the original value. If action is "Set" and the associated value is not available on the request (e.g. RemoteIpAddress is null), any existing header is still removed to prevent spoofing.

The {Prefix}For header value is taken from `HttpContext.Connection.RemoteIpAddress` representing the prior caller's IP address. The port is not included. IPv6 addresses do not include the bounding `[]` brackets.

The {Prefix}Proto header value is taken from `HttpContext.Request.Scheme` indicating if the prior caller used HTTP or HTTPS.

The {Prefix}Host header value is taken from the incoming request's Host header. This is independent of RequestHeaderOriginalHost specified above. Unicode/IDN hosts are punycode encoded.

The {Prefix}Prefix header value is taken from `HttpContext.Request.PathBase`. The PathBase property is not used when generating the proxy request so the destination server will need the original value to correctly generate links and directs. The value is in the percent encoded Uri format.

## Forwarded

**Adds a header with information about the original client request**

| Key       | Value                                                                                                             | Default | Required |
| --------- | ----------------------------------------------------------------------------------------------------------------- | ------- | -------- |
| Forwarded | A comma separated list containing any of these values: for,by,proto,host                                          | (none)  | yes      |
| ForFormat | Random/RandomAndPort/RandomAndRandomPort/Unknown/UnknownAndPort/UnknownAndRandomPort/Ip/IpAndPort/IpAndRandomPort | Random  | no       |
| ByFormat  | Random/RandomAndPort/RandomAndRandomPort/Unknown/UnknownAndPort/UnknownAndRandomPort/Ip/IpAndPort/IpAndRandomPort | Random  | no       |
| Action    | Action to apply to this header (Set, Append, Remove, Off)                                                         | Set     | no       |

Config:
```json
{
  "Forwarded": "by,for,host,proto",
  "ByFormat": "Random",
  "ForFormat": "IpAndPort",
  "Action": "Append"
},
```
Code:
```csharp
routeConfig = routeConfig.WithTransformForwarded(
    useHost: true, useProto: true, forFormat: NodeFormat.IpAndPort, 
    ByFormat: NodeFormat.Random, action: ForwardedTransformAction.Append);
```
```csharp
transformBuilderContext.AddForwarded(
    useHost: true, useProto: true, forFormat: NodeFormat.IpAndPort, 
    ByFormat: NodeFormat.Random, action: ForwardedTransformAction.Append);
```
Example:
```
Forwarded: proto=https;host="localhost:5001";for="[::1]:20173";by=_YQuN68tm6
```

The `Forwarded` header is defined by [RFC 7239](https://tools.ietf.org/html/rfc7239). It consolidates many of the same functions as the unofficial X-Forwarded headers, flowing information to the destination server that would otherwise be obscured by using a proxy.

Enabling this transform will disable the default X-Forwarded transforms as they carry similar information in another format. The X-Forwarded transforms can still be explicitly enabled.

Action: This specifies how the transform should handle an existing Forwarded header. It can be "Set", "Append", "Remove, or "Off" (completely disable the transform). A request traversing multiple proxies may accumulate a list of such headers and the destination server will need to evaluate the list to determine the original value.

Proto: This value is taken from `HttpContext.Request.Scheme` indicating if the prior caller used HTTP or HTTPS.

Host: This value is taken from the incoming request's Host header. This is independent of RequestHeaderOriginalHost specified above. Unicode/IDN hosts are punycode encoded.

For: This value identifies the prior caller. IP addresses are taken from `HttpContext.Connection.RemoteIpAddress`. See ByFormat and ForFormat below for details.

By: This value identifies where the proxy received the request. IP addresses are taken from `HttpContext.Connection.LocalIpAddress`. See ByFormat and ForFormat below for details.

ByFormat and ForFormat:

The RFC allows a [variety of formats](https://tools.ietf.org/html/rfc7239#section-6) for the By and For fields. It requires that the default format uses an obfuscated identifier identified here as Random.

| Format | Description | Example |
|--------|-------------|---------|
| Random | An obfuscated identifier that is generated randomly per request. This allows for diagnostic tracing scenarios while limiting the flow of uniquely identifying information for privacy reasons. | `by=_YQuN68tm6` |
| RandomAndPort | The Random identifier plus the port. | `by="_YQuN68tm6:80"` |
| RandomAndRandomPort | The Random identifier plus another random identifier for the port. | `by="_YQuN68tm6:_jDw5Cf3tQ"` |
| Unknown | This can be used when the identity of the preceding entity is not known, but the proxy server still wants to signal that the request was forwarded. | `by=unknown` |
| UnknownAndPort | The Unknown identifier plus the port if available. | `by="unknown:80"` |
| UnknownAndRandomPort | The Unknown identifier plus random identifier for the port. | `by="unknown:_jDw5Cf3tQ"` |
| Ip | An IPv4 address or an IPv6 address including brackets. | `by="[::1]"` |
| IpAndPort | The IP address plus the port. | `by="[::1]:80"` |
| IpAndRandomPort | The IP address plus random identifier for the port. | `by="[::1]:_jDw5Cf3tQ"` |

## ClientCert

**Forwards the client cert used on the inbound connection as a header to destination**

| Key        | Value           | Required |
| ---------- | --------------- | -------- |
| ClientCert | The header name | yes      |

Config:
```json
{ "ClientCert": "X-Client-Cert" }
```
Code:
```csharp
routeConfig = routeConfig.WithTransformClientCertHeader(headerName: "X-Client-Cert");
```
```csharp
transformBuilderContext.AddClientCertHeader(headerName: "X-Client-Cert");
```
Example:
```
X-Client-Cert: SSdtIGEgY2VydGlmaWNhdGU...
```
As the inbound and outbound connections are independent, there needs to be a way to pass any inbound client certificate to the destination server. This transform causes the client certificate taken from `HttpContext.Connection.ClientCertificate` to be Base64 encoded and set as the value for the given header name. The destination server may need that certificate to authenticate the client. There is no standard that defines this header and implementations vary, check your destination server for support.

Servers do minimal validation on the incoming client certificate by default. The certificate should be validated either in the proxy or the destination, see the [client certificate auth](/aspnet/core/security/authentication/certauth) docs for details.

This transform will only apply if the client certificate is already present on the connection. See the [optional certs doc](/aspnet/core/security/authentication/certauth#optional-client-certificates) if it needs to be requested from the client on a per-route basis.
