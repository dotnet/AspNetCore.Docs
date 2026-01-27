---
title: "Breaking change: IFormFile parameters require anti-forgery checks"
description: Learn about the breaking change in ASP.NET Core 8.0 where minimal APIs that consume IFormFile or IFormFileCollection parameters require anti-forgery checks.
ms.date: 12/05/2023
ms.custom: https://github.com/aspnet/Announcements/issues/509
---
# Minimal APIs: IFormFile parameters require anti-forgery checks

Minimal API endpoints that consume an <xref:Microsoft.AspNetCore.Http.IFormFile> or <xref:Microsoft.AspNetCore.Http.IFormFileCollection> are now opted into requiring anti-forgery token validation using the new anti-forgery middleware.

## Version introduced

ASP.NET Core 8.0 RC 1

## Previous behavior

Minimal API endpoints that bound a parameter from the form via <xref:Microsoft.AspNetCore.Http.IFormFile> or <xref:Microsoft.AspNetCore.Http.IFormFileCollection> did not require anti-forgery validation.

## New behavior

Minimal API endpoints that bind a parameter from the form via <xref:Microsoft.AspNetCore.Http.IFormFile> or <xref:Microsoft.AspNetCore.Http.IFormFileCollection> require anti-forgery validation. An exception is thrown at startup if the anti-forgery middleware isn't registered for an API that defines these input types.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Anti-forgery token validation is a recommended security precaution for APIs that consume data from a form.

## Recommended action

Configure anti-forgery services and middleware for minimal API endpoints that bind <xref:Microsoft.AspNetCore.Http.IFormFile> or <xref:Microsoft.AspNetCore.Http.IFormFileCollection> parameters. Without this configuration, the application will fail at startup due to missing anti-forgery validation.

For detailed guidance on how to configure and use anti-forgery tokens in minimal APIs, see [Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core](/aspnet/core/security/anti-request-forgery). The article covers:

- How to resolve missing anti-forgery middleware exceptions at startup.
- How to register anti-forgery services and middleware.
- How to generate and validate anti-forgery tokens in Minimal APIs.
- How to use complete code examples for form handling with file uploads.
- How to troubleshoot token validation failures and common errors.
- How to apply security best practices for CSRF protection.

## Affected APIs

N/A
