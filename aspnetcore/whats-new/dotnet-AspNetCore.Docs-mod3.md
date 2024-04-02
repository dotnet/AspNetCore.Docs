---
title: "ASP.NET Core docs: What's new for March 2024"
description: "What's new in the ASP.NET Core docs for March 2024."
ms.custom: March-2024
ms.date: 04/01/2024
---

# ASP.NET Core docs: What's new for March 2024

Welcome to what's new in the ASP.NET Core docs for March 2024. This article lists some of the major changes to docs during this period.

## Blazor

### Updated articles

- <xref:blazor/host-and-deploy/server> - Update Azure SignalR Service remarks
- <xref:blazor/security/index>
  - Improve authorization opening remarks
  - Add coverage on antiforgery services and middleware
  - Server-side behaviors during static SSR
  - WebSocket compression/CSP and security guidance
  - WASM+Identity same-site & antiforgery updates
- <xref:blazor/js-interop/index>
  - Updates to compression warning content
  - Surface warning on compression for interactive SSR
- <xref:blazor/security/blazor-web-app-oidc>
  - Add remark on ME-ID authority in server API config
  - Update scope/authority guidance in BWA+OIDC article
  - Add VS prerequisite version
  - Nonce update for token refresh
- <xref:blazor/forms/index> - Add coverage on antiforgery services and middleware
- <xref:blazor/components/control-head-content> - Control <head> content and migration updates
- <xref:blazor/fundamentals/configuration>
  - Clarify app settings file locations
  - Remove article front matter
- <xref:blazor/project-structure> - Improved Project Structure article WASM headings
- <xref:blazor/components/lifecycle>
  - [Blazor] Lifecycle - AfterRender.razor sample update + console output added
  - Graph scopes clarification and addl updates
  - [Blazor] Lifecycle - clear formulation for conditions when rendering is avoided
- <xref:blazor/security/webassembly/additional-scenarios> - Graph scopes clarification and addl updates
- <xref:blazor/security/webassembly/graph-api> - Graph scopes clarification and addl updates
- <xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c> - Graph scopes clarification and addl updates
- <xref:blazor/security/webassembly/hosted-with-microsoft-entra-id> - Graph scopes clarification and addl updates
- <xref:blazor/security/webassembly/standalone-with-azure-active-directory-b2c> - Graph scopes clarification and addl updates
- <xref:blazor/security/webassembly/standalone-with-microsoft-accounts> - Graph scopes clarification and addl updates
- <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id> - Graph scopes clarification and addl updates
- <xref:blazor/components/js-spa-frameworks> - Add sample app cross-links to JS/SPA article
- <xref:blazor/components/event-handling>
  - [Blazor] Event handling - ParentChild2.razor without Task.Yield()
  - [Blazor] Event handling - first InvokeAsync example with args
- <xref:blazor/security/server/index> - Dependency on DBContext for Blazor Identity UI
- <xref:blazor/components/render-modes>
  - Updates to 'click'-based remarks
  - Server-side behaviors during static SSR
  - WebSocket compression/CSP and security guidance
- <xref:blazor/fundamentals/static-files> - Static files article updates
- <xref:blazor/fundamentals/signalr>
  - Harden API options
  - Improve SignalR idle timeout example
  - Update Blazor release notes for Preview 2
  - WebSocket compression/CSP and security guidance
- <xref:blazor/components/layouts> - Server-side behaviors during static SSR
- <xref:blazor/fundamentals/routing> - Server-side behaviors during static SSR
- <xref:blazor/security/server/additional-scenarios> - Temporarily surface PU issue for access tokens
- <xref:blazor/call-web-api>
  - Blazor WASM cookie security for web APIs
  - PATCH section and other updates
  - Drop prop and field in examples
  - Call (web) API security updates
  - Additional Call web API article updates
  - Call web API article updates
  - Drop pivots and sample code
- <xref:blazor/hybrid/tutorials/windows-forms> - Add Bootstrap to Blazor Hybrid tutorials
- <xref:blazor/components/overwriting-parameters> - [Blazor] OverridingParameters - ShowMoreExpander, ToggleExpander
- <xref:blazor/blazor-ef-core>
  - Blazor-specific 'how to download' guidance
  - Clarify sample location
  - Remove article front matter
- <xref:blazor/fundamentals/dependency-injection> - Blazor-specific 'how to download' guidance
- <xref:blazor/fundamentals/index> - Blazor-specific 'how to download' guidance
- <xref:blazor/components/data-binding> - Blazor - data-binding - event fix
- <xref:blazor/security/server/interactive-server-side-rendering> - WebSocket compression/CSP and security guidance
- <xref:blazor/globalization-localization> - Add BWA global Auto approach
- <xref:blazor/security/webassembly/standalone-with-identity> - WASM+Identity same-site & antiforgery updates

## Fundamentals

### Updated articles

- <xref:fundamentals/middleware/index> - Fix typo
- <xref:fundamentals/logging/index> - Update index.md

## Migration

### New articles

- <xref:migration/inc/http-modules>

### Updated articles

- <xref:migration/70-to-80>
  - Add coverage on antiforgery services and middleware
  - Control <head> content and migration updates
  - Blazor Server script fallback policy authorization
- <xref:migration/inc/http-modules>
  - move snippets to code sample
  - Add doc for incrementally migration IHttpModule implementations

## Performance

### Updated articles

- <xref:performance/response-compression> - Update API Testing tool references

## Release notes

### Updated articles

- <xref:aspnetcore-9> - Add preview 2 features

## Security

### Updated articles

- <xref:security/authentication/identity/spa> - Convert inline code to snippet references

## Tutorials

### Updated articles

- <xref:tutorials/min-web-api> - Min API tutorial: rewrite to Swagger

## Web API

### Updated articles

- <xref:web-api/advanced/formatting> - Update API Testing tool references

## Community contributors

The following people contributed to the ASP.NET Core docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [hakenr](https://github.com/hakenr) - Robert Haken ![21 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-21-green)
- [BusHero](https://github.com/BusHero) - Cervac Petru ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [danespinosa](https://github.com/danespinosa) - Dan Espinosa ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [drewnoakes](https://github.com/drewnoakes) - Drew Noakes ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [fbaptista](https://github.com/fbaptista) - Fabian ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [fredrikcarlbom](https://github.com/fredrikcarlbom) - Fredrik C ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Jessuhh](https://github.com/Jessuhh) - Jesse Brand ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [markharwood101](https://github.com/markharwood101) - Mark Harwood ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [reyang](https://github.com/reyang) - Reiley Yang ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [StefanOssendorf](https://github.com/StefanOssendorf) - Stefan Ossendorf ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [timdeschryver](https://github.com/timdeschryver) - Tim Deschryver ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
