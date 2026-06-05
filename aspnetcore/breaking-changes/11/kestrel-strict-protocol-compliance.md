---
title: "Breaking change: Kestrel tightens HTTP protocol compliance"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where Kestrel rejects additional HTTP/2 and HTTP/3 connection-specific headers and closes HTTP/1.1 connections after a request with both Content-Length and Transfer-Encoding."
ms.date: 06/04/2026
---
# Kestrel tightens HTTP protocol compliance

Kestrel in ASP.NET Core 11 makes two HTTP-protocol-compliance changes:

- HTTP/2 and HTTP/3 reject more connection-specific request headers, per RFC 9113 §8.2.2 and RFC 9114 §4.2.
- HTTP/1.1 closes the connection after a request that included both `Content-Length` and `Transfer-Encoding`, per the updated wording of RFC 9112.

Both changes are stricter conformance to the HTTP specifications. Compliant clients are unaffected. Misbehaving clients or older proxies that don't fix up these headers might see new errors or extra connection re-handshakes.

## Version introduced

.NET 11

## Previous behavior

**HTTP/2 and HTTP/3.** Kestrel rejected requests that included the `Connection` or `TE` header (where `TE` had a value other than `trailers`), but it accepted requests that included the other connection-specific headers called out by the RFCs: `Proxy-Connection`, `Keep-Alive`, `Transfer-Encoding`, and `Upgrade`.

**HTTP/1.1.** When a request included both `Content-Length` and `Transfer-Encoding` headers, Kestrel ignored `Content-Length`, honored `Transfer-Encoding: chunked`, processed the request, and then kept the connection alive for subsequent requests.

## New behavior

**HTTP/2 and HTTP/3.** Kestrel now treats a request as malformed and resets the stream (HTTP/2) or fails the request (HTTP/3) if it includes any of the following connection-specific headers:

- `Connection`
- `Proxy-Connection`
- `Keep-Alive`
- `TE` (with a value other than `trailers`)
- `Transfer-Encoding`
- `Upgrade`

**HTTP/1.1.** When a request includes both `Content-Length` and `Transfer-Encoding`, Kestrel still strips `Content-Length` and processes the request, but it now closes the connection after sending the response instead of keeping it alive. This mitigates a known HTTP request-smuggling vector.

> [!NOTE]
> The HTTP/1.1 connection-close behavior for requests that include both `Content-Length` and `Transfer-Encoding` is also being shipped in servicing updates to earlier supported versions of Kestrel and to IIS and HTTP.sys.

## Type of breaking change

These changes are [behavioral changes](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

Per RFC 9113 §8.2.2 (HTTP/2) and RFC 9114 §4.2 (HTTP/3), endpoints must treat any message that contains connection-specific header fields as malformed. The previous Kestrel implementation only rejected `Connection` and `TE`, leaving four other RFC-listed headers unenforced.

Per the updated RFC 9112, a server must close the connection after processing a request that contained both `Content-Length` and `Transfer-Encoding`. Closing the connection prevents a class of HTTP request-smuggling attacks that exploit the ambiguity between the two framing headers.

For more information, see [dotnet/aspnetcore#66669](https://github.com/dotnet/aspnetcore/pull/66669) and [dotnet/aspnetcore#66671](https://github.com/dotnet/aspnetcore/pull/66671).

## Recommended action

For the HTTP/2 and HTTP/3 change, audit any clients, gateways, or HTTP/1.1-to-HTTP/2 translating proxies that forward requests to Kestrel and make sure they strip the connection-specific headers when upgrading the protocol. Compliant HTTP/2 and HTTP/3 clients don't send these headers.

For the HTTP/1.1 change, audit any client that emits both `Content-Length` and `Transfer-Encoding` and update it to send only one. Sending only `Transfer-Encoding: chunked` (and omitting `Content-Length`) is the simplest fix. Clients that send only `Content-Length` are unaffected.

## Affected APIs

None directly. The change is enforced at the protocol layer by Kestrel; no public API surface is changed. For more information, see the [Kestrel documentation](/aspnet/core/fundamentals/servers/kestrel).
