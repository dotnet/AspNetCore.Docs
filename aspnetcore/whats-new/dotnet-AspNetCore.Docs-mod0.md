---
title: "ASP.NET Core docs: What's new for June 2024"
description: "What's new in the ASP.NET Core docs for June 2024."
ms.custom: June-2024
ms.date: 07/01/2024
---

# ASP.NET Core docs: What's new for June 2024

Welcome to what's new in the ASP.NET Core docs for June 2024. This article lists some of the major changes to docs during this period.

## Blazor

### Updated articles

- <xref:blazor/components/quickgrid>
  - QuickGrid display name support
  - Scaffolding tool doc overhaul with added generators
- <xref:blazor/components/event-handling>
  - Document reserved event names
  - Clarify interactive requirement for event handlers in BWAs
- <xref:blazor/file-downloads> - Downloading files with static SSR
- <xref:blazor/forms/index>
  - Mitigate overposting attacks
  - BWA client-side validation requires a circuit
- <xref:blazor/forms/validation> - BWA client-side validation requires a circuit
- <xref:blazor/components/render-modes>
  - Prerendering behavior updates
  - Interactive SSR RCs in global WASM/Auto projects
  - Detect the current render mode at runtime
- <xref:blazor/fundamentals/signalr> - Blazor Server reconnection coverage
- <xref:blazor/fundamentals/static-files> - Map Static Assets Blazor-specific coverage
- <xref:blazor/security/webassembly/additional-scenarios> - Update RemoteAuthenticatorView param value
- <xref:blazor/hybrid/tutorials/maui-blazor-web-app>
  - Place code for sample cross-link in MAUI project
  - Article updates
  - .NET MAUI BH BWA tutorial updates
  - Update .NET MAUI BH BWA tutorial
  - Clarify per-page/component scenario
  - Patch the Pre5 .NET MAUI Blazor Hybrid BWA coverage (PR 2)
  - Patch the Pre5 .NET MAUI Blazor Hybrid BWA coverage (PR 1)
  - New .NET MAUI Blazor Hybrid template
- <xref:blazor/host-and-deploy/configure-trimmer> - Clarify Blazor trim mode
- <xref:blazor/debug> - Blazor CLI commands moving to `dotnet watch`
- <xref:blazor/host-and-deploy/index> - Blazor CLI commands moving to `dotnet watch`
- <xref:blazor/host-and-deploy/webassembly>
  - Blazor CLI commands moving to `dotnet watch`
  - Update Apache coverage (drop CentOS mentions)
  - Fix spacing in Apache configuration example
- <xref:blazor/js-interop/import-export-interop> - Import-Export interop: collocated JS with RCL
- <xref:blazor/components/prerendering-and-integration> - Use 'reconnection UI' for all references
- <xref:blazor/security/blazor-web-app-oidc> - Interactive SSR RCs in global WASM/Auto projects
- <xref:blazor/security/server/index> - Simplified auth state serialization for BWAs
- <xref:blazor/tooling> - Change Tooling article content layout
- <xref:blazor/tutorials/signalr-blazor>
  - Blazor CLI commands moving to `dotnet watch`
  - Blazor SignalR tutorial updates
  - Blazor SignalR tutorial refactor

## Client-side development

### Updated articles

- <xref:client-side/using-browserlink> - Package installation no longer needed
- <xref:client-side/dotnet-interop> - .NET JS interop article updates

## Fundamentals

### Updated articles

- <xref:fundamentals/tools/dotnet-aspnet-codegenerator> - Scaffolding tool doc overhaul with added generators
- <xref:fundamentals/error-handling> - May Content Health - freshness review
- <xref:fundamentals/minimal-apis/responses> - Inline code --> snippet references
- <xref:fundamentals/minimal-apis/handle-errors> - May Content Health - freshness review
- <xref:fundamentals/static-files> - moniker prep:

## Getting started

### Updated articles

- <xref:getting-started> - May Content Health - freshness review

## gRPC

### Updated articles

- <xref:grpc/client> - Dispose gRPC streaming calls
- <xref:grpc/performance> - Add gRPC perf docs around gracefully completing and disposing streaming calls

## Hosting and deployment

### New articles

- <xref:host-and-deploy/azure-iis-errors-reference>

### Updated articles

- <xref:host-and-deploy/azure-apps/index>
  - Revert "refactor azure troubleshooting/1"
  - Update index.md
- <xref:host-and-deploy/iis/index> - Revert "refactor azure troubleshooting/1"

## Migration

### Updated articles

- <xref:migration/70-to-80> - Follow-up .NET 8 updates

## Mobile development

### Updated articles

- <xref:mobile/native-mobile-backend> - Lowercase the code name

## Performance

### Updated articles

- <xref:performance/caching/hybrid> - Add serialization sample app
- <xref:performance/caching/output> - Note about code sample

## Release notes

### Updated articles

- <xref:aspnetcore-9>
  - Render mode detection, static web asset delivery, dynamic compression
  - Add three Blazor What's New sections

## Security

### Updated articles

- <xref:security/authentication/windowsauth> - Fix broken links
- <xref:security/enforcing-ssl> - May Content Health - freshness review
- <xref:security/authentication/otherlogins> - Scaffolding tool doc overhaul with added generators

## Testing

### Updated articles

- <xref:test/troubleshoot-azure-iis>
  - refactor azure troubleshooting/1

## Tutorials

### Updated articles

- <xref:tutorials/get-started-with-swashbuckle> - mon split
- <xref:tutorials/razor-pages/model> - .NET 9 update: Prep RP tutorial series
- <xref:tutorials/razor-pages/page> - .NET 9 update: Prep RP tutorial series
- <xref:tutorials/razor-pages/sql> - .NET 9 update: Prep RP tutorial series
- <xref:tutorials/razor-pages/da1> - .NET 9 update: Prep RP tutorial series
- <xref:tutorials/razor-pages/search> - .NET 9 update: Prep RP tutorial series
- <xref:tutorials/razor-pages/new-field> - .NET 9 update: Prep RP tutorial series
- <xref:tutorials/razor-pages/validation> - .NET 9 update: Prep RP tutorial series
- <xref:tutorials/first-mvc-app/validation> - First MVC: Validation: Clear old null values
- <xref:tutorials/min-web-api>
  - v9 Update: Min Web API Tutorial
  - Prework-Min Web API .NET 9 update
- <xref:tutorials/razor-pages/razor-pages-start> - .NET 9 update: Prep RP tutorial series

## Web API

### Updated articles

- <xref:web-api/handle-errors> - May Content Health - freshness review

## Community contributors

The following people contributed to the ASP.NET Core docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [hakenr](https://github.com/hakenr) - Robert Haken ![5 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-5-green)
- [aidmsu](https://github.com/aidmsu) - Andrey Dorokhov ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [DickBaker](https://github.com/DickBaker) - Dick Baker ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Marjani](https://github.com/Marjani) - AmirHossein ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [saborrie](https://github.com/saborrie) - Steven Borrie ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [waedi](https://github.com/waedi) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
