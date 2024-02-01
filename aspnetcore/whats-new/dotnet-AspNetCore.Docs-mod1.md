---
title: "ASP.NET Core docs: What's new for January 2024"
description: "What's new in the ASP.NET Core docs for January 2024."
ms.custom: January-2024
ms.date: 02/01/2024
---

# ASP.NET Core docs: What's new for January 2024

Welcome to what's new in the ASP.NET Core docs for January 2024. This article lists some of the major changes to docs during this period.

## Blazor

### New articles

- <xref:blazor/security/server/account-confirmation-and-password-recovery>

### Updated articles

- <xref:blazor/components/cascading-values-and-parameters>
  - Blazor 8.0 content updates
  - Cascading values updates
  - Move example code to sample apps
- <xref:blazor/components/js-spa-frameworks>
  - Blazor 8.0 content updates
  - Add component example
- <xref:blazor/components/prerender>
  - Blazor 8.0 content updates
  - Prerendering and interactive/enhanced routing
  - Move example code to sample apps
- <xref:blazor/components/render-modes>
  - Blazor 8.0 content updates
  - Clarification on prerendering and root components
  - Fine control of static SSR
  - Clarify Auto render mode behavior
  - Apply a render mode programmatically section
  - Client services during prerendering
- <xref:blazor/fundamentals/handle-errors>
  - Blazor 8.0 content updates
  - Content follow-up updates (8.0)
  - "Base address" clarifications for `HttpClient`
- <xref:blazor/fundamentals/startup>
  - Blazor 8.0 content updates
  - Custom Blazor WASM loading progress indicator
- <xref:blazor/security/server/index>
  - Blazor 8.0 content updates
  - Improve auth state provider guidance
  - Add Identity BWA template cross-links
- <xref:blazor/components/built-in-components> - Content follow-up updates (8.0)
- <xref:blazor/hybrid/security/index> - Content follow-up updates (8.0)
- <xref:blazor/security/index> - Content follow-up updates (8.0)
- <xref:blazor/security/server/additional-scenarios> - Content follow-up updates (8.0)
- <xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c> - Content follow-up updates (8.0)
- <xref:blazor/security/webassembly/hosted-with-microsoft-entra-id> - Content follow-up updates (8.0)
- <xref:blazor/security/webassembly/index> - Content follow-up updates (8.0)
- <xref:blazor/security/webassembly/meid-groups-roles>
  - Content follow-up updates (8.0)
  - Groups/roles article and Graph article updates
- <xref:blazor/security/webassembly/standalone-with-azure-active-directory-b2c> - Content follow-up updates (8.0)
- <xref:blazor/security/webassembly/standalone-with-microsoft-accounts> - Content follow-up updates (8.0)
- <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id> - Content follow-up updates (8.0)
- <xref:blazor/security/webassembly/standalone-with-identity> - Add troubleshooting guidance
- <xref:blazor/security/webassembly/graph-api>
  - Groups/roles article and Graph article updates
  - "Base address" clarifications for `HttpClient`
- <xref:blazor/call-web-api>
  - "Base address" clarifications for `HttpClient`
  - Client services during prerendering
- <xref:blazor/file-uploads> - "Base address" clarifications for `HttpClient`
- <xref:blazor/security/content-security-policy> - "Base address" clarifications for `HttpClient`
- <xref:blazor/security/webassembly/additional-scenarios>
  - "Base address" clarifications for `HttpClient`
  - Update save app state example
- <xref:blazor/project-structure> - Terminology updates
- <xref:blazor/progressive-web-app> - Update PWA guidance
- <xref:blazor/components/virtualization> - Clarify 'content items' (placeholder content)
- <xref:blazor/state-management> - Cascading values updates
- <xref:blazor/components/index>
  - Calling base class methods
  - Account conf and PW recovery article
- <xref:blazor/components/lifecycle>
  - Calling base class methods
  - Move example code to sample apps
- <xref:blazor/components/integration>
  - Integration article updates
  - RazorComponentResult rendering behavior
- <xref:blazor/forms/input-components>
  - Manage InputSelect form options for SSR
  - Move example code to sample apps
- <xref:blazor/components/quickgrid>
  - Blazor CRUD/Quickgrid scaffolder
  - Move example code to sample apps
- <xref:blazor/host-and-deploy/configure-trimmer> - Trimming complex framework types (JS interop)
- <xref:blazor/webassembly-lazy-load-assemblies> - Clarify lazy loading is only for dev assemblies
- <xref:blazor/host-and-deploy/index> - App base path enhancements
- <xref:blazor/fundamentals/dependency-injection> - Client services during prerendering
- <xref:blazor/forms/binding> - Move example code to sample apps
- <xref:blazor/forms/index> - Move example code to sample apps
- <xref:blazor/forms/validation> - Move example code to sample apps
- <xref:blazor/fundamentals/routing> - Prerendering and interactive/enhanced routing
- <xref:blazor/js-interop/index> - Update JS collocation guidance
- <xref:blazor/components/rendering> - Custom Blazor WASM loading progress indicator

## Client-side development

### Updated articles

- <xref:client-side/libman/libman-cli> - libMan limitations /8

## Fundamentals

### Updated articles

- <xref:fundamentals/host/web-host>
  - Update env var name
  - Fix default value of PreferHostingUrls
- <xref:fundamentals/host/generic-host> - Fix default value of PreferHostingUrls
- <xref:fundamentals/native-aot> - CreateSimBuilder is missing /7

## gRPC

### New articles

- <xref:grpc/error-handling>

### Updated articles

- <xref:grpc/interprocess-namedpipes> - Add note to IPC docs that it can't be combined with some channel features
- <xref:grpc/interprocess-uds> - Add note to IPC docs that it can't be combined with some channel features

## Hosting and deployment

### Updated articles

- <xref:host-and-deploy/linux-apache> - Update linux-apache.md
- <xref:host-and-deploy/azure-apps/index> - Update doc author note
- <xref:host-and-deploy/health-checks>
  - DelegateHealthCheck /8
  - sample prep /8

## Migration

### Updated articles

- <xref:migration/70-to-80> - Drop `[Parameter]` for query string params

## Performance

### Updated articles

- <xref:performance/caching/distributed> - Add Azure Cosmos DB

## Release notes

### Updated articles

- <xref:aspnetcore-8>
  - Add a note about certificate file watching
  - Drop `[Parameter]` for query string params

## Security

### Updated articles

- <xref:security/app-secrets>
  - Duplicate new section in the >6.0 moniker block
  - Updated app-secrets.md to show how to use user secrets in a console app
- <xref:security/docker-https> - Update env var name
- <xref:security/authentication/accconfirm> - Account conf and PW recovery article
- <xref:security/cors> - Move prior version include to end

## SignalR

### Updated articles

- <xref:signalr/hubs> - GH27996 - SignalR/hubs.md versioning to includes prework

## Testing

### Updated articles

- <xref:test/http-files> - Add secret handling and special variables to .http files doc
- <xref:test/middleware> - Add example with endpoints to middleware testing doc

## Tutorials

### Updated articles

- <xref:tutorials/get-started-with-swashbuckle> - Update getting-started-with-swashbuckle.md

## Community contributors

The following people contributed to the ASP.NET Core docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [ericmutta](https://github.com/ericmutta) - Eric Mutta ![7 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-7-green)
- [PSCourtney](https://github.com/PSCourtney) - Piers Courtney ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [Elanis](https://github.com/Elanis) - Axel ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [harry1911](https://github.com/harry1911) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [jposert](https://github.com/jposert) - Jakub ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [mahdikshk](https://github.com/mahdikshk) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [martincostello](https://github.com/martincostello) - Martin Costello ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [mganss](https://github.com/mganss) - Michael Ganss ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Nitzantomer1998](https://github.com/Nitzantomer1998) - Nitzan Tomer ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ptakpiotr](https://github.com/ptakpiotr) - Piotr Ptak ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [richstokoe](https://github.com/richstokoe) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [roxas0zero](https://github.com/roxas0zero) - Abdullah Hashim ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [serpent5](https://github.com/serpent5) - Kirk Larkin ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [steenbokdev](https://github.com/steenbokdev) - Lars ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Ususucsus](https://github.com/Ususucsus) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [yogyogi](https://github.com/yogyogi) - Yogi ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
