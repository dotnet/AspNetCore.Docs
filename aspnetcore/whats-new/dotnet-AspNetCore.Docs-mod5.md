---
title: "ASP.NET Core docs: What's new for May 2024"
description: "What's new in the ASP.NET Core docs for May 2024."
ms.custom: May-2024
ms.date: 06/01/2024
---

# ASP.NET Core docs: What's new for May 2024

Welcome to what's new in the ASP.NET Core docs for May 2024. This article lists some of the major changes to docs during this period.

## Blazor

### New articles

- <xref:blazor/hybrid/tutorials/maui-blazor-web-app>

### Updated articles

- <xref:blazor/components/quickgrid> - Add OverscanCount to ref article
- <xref:blazor/security/index> - Update cascading auth state service requirements
- <xref:blazor/components/data-binding> - Bound field or property expression convention
- <xref:blazor/file-uploads> - Maximum parallel invocations per client remark
- <xref:blazor/fundamentals/index>
  - More hints on interactivity for doc components
  - New .NET MAUI BWA with shared UI article
- <xref:blazor/globalization-localization> - Location override using the "Sensors" pane
- <xref:blazor/hybrid/tutorials/index> - Surface new tutorial in tutorial list
- <xref:blazor/components/render-modes>
  - More hints on interactivity for doc components
  - Static SSR pages in a globally-interactive app
- <xref:blazor/fundamentals/signalr>
  - Maximum parallel invocations per client remark
  - Inform readers on support status of stateful reconnect
- <xref:blazor/components/index> - More hints on interactivity for doc components
- <xref:blazor/components/class-libraries> - RCLs for Blazor apps that support pages+views
- <xref:blazor/host-and-deploy/server>
  - Azure Container Apps updates
  - Inform readers on support status of stateful reconnect
- <xref:blazor/hybrid/reuse-razor-components>
  - Add OverscanCount to ref article
  - Add cross-link to new guidance
- <xref:blazor/security/webassembly/hosted-with-microsoft-entra-id> - Remark on ownership of service API registration
- <xref:blazor/security/blazor-web-app-oidc>
  - BlazorWebAppOidcBff Aspire article updates
  - Add product unit issue cross-link
- <xref:blazor/security/server/index> - Update ref source links to Blazor security API
- <xref:blazor/hybrid/class-libraries> - Add OverscanCount to ref article
- <xref:blazor/tooling> - More hints on interactivity for doc components
- <xref:blazor/tutorials/signalr-blazor> - Update "CLI" tab controls

## Data access

### Updated articles

- <xref:data/ef-rp/intro> - Update "CLI" tab controls

## Fundamentals

### New articles

- <xref:fundamentals/openapi/aspnetcore-openapi>

### Updated articles

- <xref:fundamentals/openapi/aspnetcore-openapi>
  - Update install package instructions.
  - Bring back OpenAPI package installation instructions
  - Move up ## Customize OpenAPI endpoints with endpoint metadata
  - Edit OpenAPI doc
  - Update docs on OpenAPI-related metadata
  - Bump Swashbuckle versions
  - Update Scalar docs to use Scalar.AspNetCore package
  - Update Swashbuckle documentation
  - Add content on endpoint customization and Scalar docs
  - Post-PR review.
  - Add docs on Microsoft.AspNetCore.OpenApi
- <xref:fundamentals/error-handling> - Document the Preview 4 developer exception page
- <xref:fundamentals/troubleshoot-aspnet-core-localization> - Location override using the "Sensors" pane
- <xref:fundamentals/aot/rdg> - Add publishtrimmed note
- <xref:fundamentals/native-aot-tutorial> - Update "CLI" tab controls

## gRPC

### Updated articles

- <xref:grpc/health-checks> - gRPC Health Checks: Add client factory example

## Hosting and deployment

### Updated articles

- <xref:host-and-deploy/iis/advanced> - Document ShutdownDelay
- <xref:host-and-deploy/proxy-load-balancer> - Add doc about X-Forwarded-Prefix/X-Original-Prefix
- <xref:host-and-deploy/azure-apps/index> - Update "CLI" tab controls
- <xref:host-and-deploy/docker/building-net-docker-images> - Update building-net-docker-images.md
- <xref:host-and-deploy/visual-studio-publish-profiles> - Update "CLI" tab controls

## Migration

### Updated articles

- <xref:migration/70-to-80> - Hosted WASM to BWA migration updates

## Performance

### New articles

- <xref:performance/caching/hybrid>

### Updated articles

- <xref:performance/caching/overview>
  - Document .NET 9 new feature - HybridCache
  - Moniker prep for 9.0 content

## Release notes

### Updated articles

- <xref:aspnetcore-8> - SignalR:H ubConnectionBuild: Update to withServerTimeout and withKeepAlive
- <xref:aspnetcore-9>
  - What's new OpenAPI
  - HybridCache in What's new doc

## Security

### Updated articles

- <xref:security/authentication/add-user-data> - Update "CLI" tab controls
- <xref:security/authentication/individual> - Update "CLI" tab controls
- <xref:security/data-protection/introduction>
  - Mon prep
  - content health
- <xref:security/key-vault-configuration> - Update key-vault-configuration.md
- <xref:security/data-protection/configuration/overview> - DataProtection Blob warning
- <xref:security/authentication/windowsauth> - Update "CLI" tab controls
- <xref:security/enforcing-ssl>
  - move up  linux-dev-certs
  - linux-dev-certs easy
- <xref:security/authentication/identity/spa> - Implement IEmailSender to customize emails
- <xref:security/authentication/customize_identity_model> - Update "CLI" tab controls
- <xref:security/authentication/identity> - Update "CLI" tab controls
- <xref:security/authorization/simple> - Add a Prerequisites section

## SignalR

### Updated articles

- <xref:signalr/configuration> - SignalR:H ubConnectionBuild: Update to withServerTimeout and withKeepAlive

## Tutorials

### Updated articles

- <xref:tutorials/dotnet-watch> - Update "CLI" tab controls
- <xref:tutorials/first-mvc-app/start-mvc> - First MVC: Clarify project location has no restriction
- <xref:tutorials/get-started-with-nswag> - Update "CLI" tab controls
- <xref:tutorials/get-started-with-swashbuckle>
  - Update "CLI" tab controls
  - Bump Swashbuckle versions
  - Update Swashbuckle documentation
- <xref:tutorials/first-web-api>
  - First Web API: Linux: Add tools path
  - First Web API: no loc correction for New Scaffolded Item menu

## Community contributors

The following people contributed to the ASP.NET Core docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [martincostello](https://github.com/martincostello) - Martin Costello ![3 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-3-green)
- [hakenr](https://github.com/hakenr) - Robert Haken ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [joegoldman2](https://github.com/joegoldman2) -  ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [kevinchalet](https://github.com/kevinchalet) - Kévin Chalet ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [azarboon](https://github.com/azarboon) - Mahdi Azarboon ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [capdiem](https://github.com/capdiem) - capdiem ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [JonathanBout](https://github.com/JonathanBout) - Jonathan Bout ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [jpbulman](https://github.com/jpbulman) - JP Bulman ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [MrXhh](https://github.com/MrXhh) - 小辉辉 ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [tuhlaajapoika](https://github.com/tuhlaajapoika) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
