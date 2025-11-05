# Obsolete APIs in AspNetCore.Docs Repository

**Generated:** November 5, 2025  
**Repository:** dotnet/AspNetCore.Docs

## Overview

This report documents all API members that have the `[Obsolete]` attribute or are documented as obsolete in the ASP.NET Core documentation repository.

**Important Note:** This is a documentation repository, not a source code repository. The APIs documented here are defined in the actual ASP.NET Core framework repositories. This report identifies obsolete APIs mentioned in the documentation.

## Summary

- **Total C# files searched:** 5,883
- **Total Markdown files with obsolete references:** 28
- **`[Obsolete]` attributes in code samples:** 0
- **Documented obsolete API groups:** 7

## Documented Obsolete APIs

### 1. CompatibilityVersion Enum Values

**Namespace:** `Microsoft.AspNetCore.Mvc`  
**File:** `aspnetcore/mvc/compatibility-version.md`  
**Status:** Marked `[Obsolete(...)]`

- `CompatibilityVersion.Version_2_0`
- `CompatibilityVersion.Version_2_1`
- `CompatibilityVersion.Version_2_2`

**Note:** The `SetCompatibilityVersion` method is a no-op for ASP.NET Core 3.0+ apps.

**Reference:** [Compatibility version documentation](aspnetcore/mvc/compatibility-version.md#L20)

---

### 2. SPA Services Packages

**Package:** `Microsoft.AspNetCore.SpaServices`  
**Package:** `Microsoft.AspNetCore.NodeServices`  
**File:** `aspnetcore/client-side/spa-services.md`  
**Status:** Obsolete as of ASP.NET Core 3.0

**Replacement:** `Microsoft.AspNetCore.SpaServices.Extensions`

**Reference:** [[Announcement] Obsoleting Microsoft.AspNetCore.SpaServices and Microsoft.AspNetCore.NodeServices](https://github.com/dotnet/AspNetCore/issues/12890)

---

### 3. IJSUnmarshalledRuntime Interface

**Full Name:** `Microsoft.JSInterop.IJSUnmarshalledRuntime`  
**Files:**
- `aspnetcore/blazor/javascript-interoperability/import-export-interop.md`
- `aspnetcore/blazor/javascript-interoperability/call-javascript-from-dotnet.md`

**Status:** Obsolete in .NET 7 or later

**Replacement:** JavaScript `[JSImport]`/`[JSExport]` interop

**Documentation References:**
- Line 31: `aspnetcore/blazor/javascript-interoperability/import-export-interop.md`
- Line 1762: `aspnetcore/blazor/javascript-interoperability/call-javascript-from-dotnet.md`

---

### 4. UseDatabaseErrorPage Method

**Full Name:** `Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage`  
**Files:**
- `aspnetcore/migration/31-to-50.md`
- `aspnetcore/migration/31-to-60.md`

**Status:** Obsolete

**Replacement:** Combination of `AddDatabaseDeveloperPageExceptionFilter` and `UseMigrationsEndPoint`

**Migration Example:**
```csharp
// Before (obsolete)
app.UseDatabaseErrorPage();

// After
services.AddDatabaseDeveloperPageExceptionFilter();
// ...
app.UseMigrationsEndPoint();
```

**Documentation References:**
- Line 727: `aspnetcore/migration/31-to-50.md`
- Line 171: `aspnetcore/migration/31-to-60.md`

---

### 5. IHostingEnvironment Interface

**Full Name:** `Microsoft.AspNetCore.Hosting.IHostingEnvironment`  
**File:** `aspnetcore/fundamentals/target-aspnetcore.md`  
**Status:** Marked obsolete in ASP.NET Core 3.1

**Replacement:** `Microsoft.AspNetCore.Hosting.IWebHostEnvironment`

**Documentation Reference:** Line 236: `aspnetcore/fundamentals/target-aspnetcore.md`

---

### 6. SignOutSessionStateManager Class

**Full Name:** `Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutSessionStateManager`  
**File:** `aspnetcore/migration/60-70.md`  
**Status:** Obsolete in .NET 7 or later

**Replacement:** `Microsoft.AspNetCore.Components.WebAssembly.Authentication.NavigationManagerExtensions.NavigateToLogout`

**Documentation Reference:** Line 157: `aspnetcore/migration/60-70.md`

---

### 7. RouteContext Type

**Full Name:** `RouteContext`  
**Files:**
- `aspnetcore/fundamentals/routing.md`
- `aspnetcore/fundamentals/routing/includes/routing3-7.md`

**Status:** Will be marked obsolete in a future release

**Documentation References:**
- Line 295: `aspnetcore/fundamentals/routing.md`
- Lines 274, 1291, 2294: `aspnetcore/fundamentals/routing/includes/routing3-7.md`

---

### 8. ComplexTypeModelBinderProvider Class

**Full Name:** `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinderProvider`  
**File:** `aspnetcore/migration/31-to-50.md`  
**Status:** Annotated as obsolete, no longer registered by default

**Replacement:** `ComplexObjectModelBinderProvider`

**Documentation Reference:** Line 715: `aspnetcore/migration/31-to-50.md`

---

## Additional Context

### API References Found in Obsolete Documentation Contexts

The following xref API references were found in documentation sections discussing obsolete APIs:

- `<xref:Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage%2A>`
- `<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.NavigationManagerExtensions.NavigateToLogout%2A>`
- `<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutSessionStateManager>`
- `<xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment>`
- `<xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment>`
- `<xref:Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinderProvider>`
- `<xref:Microsoft.AspNetCore.Routing.RouteContext.RouteData%2A?displayProperty=nameWithType>`
- `<xref:Microsoft.JSInterop.IJSUnmarshalledRuntime>`

### Obsolete Package References

The migration guide `aspnetcore/migration/22-to-30.md` documents packages that are no longer produced for ASP.NET Core 3.0+. While not marked with `[Obsolete]` attributes, these packages are effectively obsolete:

**Section:** "Remove obsolete package references"  
**Reference:** Line 55: `aspnetcore/migration/22-to-30.md`

See the full list in the migration documentation.

---

## Methodology

This report was generated by:

1. Searching all C# files (`.cs`) for `[Obsolete` attributes
2. Searching all Razor/CSHTML files for `[Obsolete` attributes
3. Searching all Markdown files (`.md`) for obsolete API references
4. Analyzing context around obsolete mentions to identify specific APIs
5. Extracting xref cross-references in obsolete contexts
6. Manually reviewing documentation to confirm API details

---

## Notes

- This repository contains documentation and sample code, not the ASP.NET Core framework itself
- No sample code files contain `[Obsolete]` attributes
- All obsolete APIs are properly documented with migration guidance
- The documentation correctly explains which APIs are obsolete and their replacements
- Some APIs are marked as "will be obsolete in a future release" (e.g., `RouteContext`)

---

## Related Documentation

- [Breaking API changes in Antiforgery, CORS, Diagnostics, Mvc, and Routing](https://github.com/aspnet/Announcements/issues/387)
- [ASP.NET Core 2.2 to 3.0 Migration Guide](aspnetcore/migration/22-to-30.md)
- [ASP.NET Core 3.1 to 5.0 Migration Guide](aspnetcore/migration/31-to-50.md)
- [ASP.NET Core 3.1 to 6.0 Migration Guide](aspnetcore/migration/31-to-60.md)
- [ASP.NET Core 6.0 to 7.0 Migration Guide](aspnetcore/migration/60-70.md)
