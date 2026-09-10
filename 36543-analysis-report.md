## 🤖 AI Triage Summary

> **📌 Note to community:** This is an automated preliminary analysis to help our documentation team quickly review, determine scope and prioritize this issue. This report is **not a resolution or answer** to your question—it's an internal triage tool that identifies potentially relevant docs, code samples, and versions to look into. A team member will review this issue and respond. Thank you for your contribution!

---

**This preliminary assessment report was run by:** @meaghanlewis
**Date:** 2026-09-10
**Issue:** 36543
**Model:** GitHub Copilot

---

# Issue Analysis

## ✅ Issue Validation

**Status:** Valid and actionable documentation issue.

The issue was opened by a repository member and points to the published ASP.NET Core 10.0 article section for TypeScript integration in Razor class libraries. The current repository source for that published section includes guidance to remove TypeScript outputs from `Content`, but it only removes a configured path statically and doesn't include the requested target that removes deleted `.js` and `.map` outputs from the evaluated `Content` item group after TypeScript deletes compiler output.

The issue has no discussion comments as of this analysis. The most relevant linked/reference history is issue #34165 and PR #34175, which previously updated the same section and sample for TypeScript/static web assets integration.

## 📋 Issue Summary

The current TypeScript integration guidance for RCLs tells readers to:

* Reference `Microsoft.TypeScript.MSBuild`.
* Put `.ts` files outside `wwwroot`.
* Configure TypeScript output for `wwwroot`.
* Add TypeScript output/publishing targets to `PrepareForBuildDependsOn`.
* Remove output from the `Content` item group with `<Content Remove="wwwroot\{path-to-typescript-outputs}" />`.

The issue requests adding this target:

```xml
<Target Name="RemoveDeletedTypeScriptOutputsFromContent" AfterTargets="TypeScriptDeleteCompilerOutput">
  <ItemGroup>
    <Content Remove="@(Content)" Condition="!Exists('%(FullPath)') And ('%(Extension)' == '.js' Or '%(Extension)' == '.map')" />
  </ItemGroup>
</Target>
```

This appears intended to handle stale `Content` items for TypeScript-generated `.js` and `.map` files that are deleted by the TypeScript clean/delete target but still remain in the evaluated `Content` item group.

## 📁 Potentially Affected Files

| File | Source lines | Current role | GitHub permalink |
| --- | --- | --- | --- |
| `aspnetcore/razor-pages/ui-class.md` | 120-134 | Published article section that introduces TypeScript integration and includes `remove.xml`. | https://github.com/dotnet/AspNetCore.Docs/blob/eaf6ae2d3795f1576d6e0b423ecad318cdbde182/aspnetcore/razor-pages/ui-class.md#L120-L134 |
| `aspnetcore/razor-pages/ui-class/remove.xml` | 1-16 | XML snippet rendered in the TypeScript integration section for ASP.NET Core 7.0 and later, including 10.0. | https://github.com/dotnet/AspNetCore.Docs/blob/eaf6ae2d3795f1576d6e0b423ecad318cdbde182/aspnetcore/razor-pages/ui-class/remove.xml#L1-L16 |
| `aspnetcore/razor-pages/ui-class/includes/ui-class6.md` | 109-131, 269-291, 664-686 | Older moniker include has separate TypeScript integration content for earlier versions. It may not be in scope for the 10.0 issue, but should be checked if the guidance is meant to apply across monikers. | https://github.com/dotnet/AspNetCore.Docs/blob/eaf6ae2d3795f1576d6e0b423ecad318cdbde182/aspnetcore/razor-pages/ui-class/includes/ui-class6.md#L109-L131 |

## 📝 Preliminary Change Assessment

### Current published/source section text

**File:** `aspnetcore/razor-pages/ui-class.md`
**Lines:** 120-134
**Permalink:** https://github.com/dotnet/AspNetCore.Docs/blob/eaf6ae2d3795f1576d6e0b423ecad318cdbde182/aspnetcore/razor-pages/ui-class.md#L120-L134

Current quoted content:

```markdown
### Typescript integration

To include TypeScript files in an RCL:

* Reference the [`Microsoft.TypeScript.MSBuild`](https://www.nuget.org/packages/Microsoft.TypeScript.MSBuild) NuGet package in the project.

   [!INCLUDE[](~/includes/package-reference.md)]

* Place the TypeScript files (`.ts`) outside of the `wwwroot` folder. For example, place the files in a `Client` folder.
* Add the following markup to the project file:
  * Configure the TypeScript build output for the `wwwroot` folder with the `TypescriptOutDir` property.
  * Include the TypeScript target as a dependency of the `PrepareForBuildDependsOn` target.
  * Remove the output in the `wwwroot folder`.

[!code-xml[](~/razor-pages/ui-class/remove.xml?highlight=5-9,13)]
```

**Assessment:** The section already has a bullet for removing TypeScript output from `Content`, but the wording and included snippet don't cover removing deleted compiler outputs from the evaluated `Content` item group after `TypeScriptDeleteCompilerOutput` runs. There's also a minor typo: `` `wwwroot folder` `` should probably be `` `wwwroot` folder `` if this text is edited.

### Current XML snippet

**File:** `aspnetcore/razor-pages/ui-class/remove.xml`
**Lines:** 1-16
**Permalink:** https://github.com/dotnet/AspNetCore.Docs/blob/eaf6ae2d3795f1576d6e0b423ecad318cdbde182/aspnetcore/razor-pages/ui-class/remove.xml#L1-L16

Current quoted content:

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

  <PropertyGroup>
    // Markup removed for brevity.
    <TypescriptOutDir>wwwroot</TypescriptOutDir>
    <PrepareForBuildDependsOn>
      CompileTypeScriptWithTSConfig;
      GetTypeScriptOutputForPublishing;$(PrepareForBuildDependsOn)
    </PrepareForBuildDependsOn>
  </PropertyGroup>

  <ItemGroup>
    <Content Remove="wwwroot\{path-to-typescript-outputs}" />
  </ItemGroup>

</Project>
```

**Assessment:** The snippet doesn't include the target requested in issue #36543. If the requested target is accepted as the correct product guidance, `remove.xml` is the most direct source file to update.

### Related prior guidance

**Issue:** #34165
**Comment permalink:** https://github.com/dotnet/AspNetCore.Docs/issues/34165#issuecomment-2485494186

Current quoted comment from @javiercn:

```text
We also need this target instead of  `<Content Remove="wwwroot\<<path-to-typescript-outputs>>" />` and both `CompileTypeScript` and `CompileTypeScriptWithTSConfig` are needed, I believe.

```diff
+    <Target Name="RemoveDuplicateTypeScriptOutputs" BeforeTargets="GetTypeScriptOutputForPublishing">
+      <ItemGroup>
+        <Content Remove="@(GeneratedJavaScript)" />
+      </ItemGroup>
+    </Target>
```
```

**Assessment:** Prior maintainer guidance for #34165 suggested a target-based approach rather than a static `Content Remove` path. The current source now has `CompileTypeScriptWithTSConfig` and a static `Content Remove`, but it doesn't include either the earlier `RemoveDuplicateTypeScriptOutputs` target or the new `RemoveDeletedTypeScriptOutputsFromContent` target requested in #36543. The docs team should confirm whether the new issue supersedes, complements, or replaces the previous guidance.

## 🎯 Suggested Action Plan

1. **Confirm product guidance with the issue author or ASP.NET Core/static web assets owner.**
   * Verify whether `RemoveDeletedTypeScriptOutputsFromContent` should be added in addition to, or instead of, the current `<Content Remove="wwwroot\{path-to-typescript-outputs}" />` guidance.
   * Confirm whether the snippet should also include `CompileTypeScript` in `PrepareForBuildDependsOn`, because prior #34165 discussion said both `CompileTypeScript` and `CompileTypeScriptWithTSConfig` might be needed.

1. **Update the XML sample if confirmed.**
   * Primary target file: `aspnetcore/razor-pages/ui-class/remove.xml`.
   * Add the requested target with `AfterTargets="TypeScriptDeleteCompilerOutput"`.
   * Adjust the `[!code-xml]` highlight range in `aspnetcore/razor-pages/ui-class.md` to include the new target lines.

1. **Update the prose in the TypeScript integration section.**
   * Clarify that the markup removes generated TypeScript output from `Content` and removes stale/deleted generated `.js` and `.map` items after TypeScript cleanup.
   * Fix the existing wording typo from `` `wwwroot folder` `` to `` `wwwroot` folder `` if the file is edited.
   * Consider changing the heading from "Typescript integration" to "TypeScript integration" for product-name casing if maintainers agree.

1. **Check moniker applicability.**
   * The issue URL is for `view=aspnetcore-10.0`, which uses `ui-class.md` lines 120-134 and `remove.xml`.
   * If the same MSBuild behavior applies to older supported versions, review `aspnetcore/razor-pages/ui-class/includes/ui-class6.md` before limiting the change to the current section.

1. **Validate rendering.**
   * Ensure the published section renders the full updated XML snippet correctly.
   * Confirm the highlight range doesn't omit the new target.

## ⚠️ Review Considerations

* The issue is a docs request, not evidence of a product defect in ASP.NET Core.
* The author is a repository member, so the requested snippet should be treated as high-signal product guidance, but the final exact XML should still be reviewed for current TypeScript/MSBuild behavior.
* `TypeScriptDeleteCompilerOutput`, `GeneratedJavaScript`, and `GeneratedJavascript` item-name casing should be verified against the current supported `Microsoft.TypeScript.MSBuild` targets before making the final sample change.
* The current published page couldn't be fetched from this runner because DNS resolution for `learn.microsoft.com` failed. The issue's published URL and current repository source were still checked, and the source file is the article backing the referenced page/document ID.
* If more than 50 characters are changed in `ui-class.md`, update `ms.date` to `09/10/2026` and add `ai-usage: ai-assisted` metadata if required by repository policy.

## 🔗 References

* Issue #36543: https://github.com/dotnet/AspNetCore.Docs/issues/36543
* Published article URL from issue: https://learn.microsoft.com/en-us/aspnet/core/razor-pages/ui-class?view=aspnetcore-10.0&tabs=visual-studio#typescript-integration
* Source article: https://github.com/dotnet/AspNetCore.Docs/blob/eaf6ae2d3795f1576d6e0b423ecad318cdbde182/aspnetcore/razor-pages/ui-class.md#L120-L134
* Source XML snippet: https://github.com/dotnet/AspNetCore.Docs/blob/eaf6ae2d3795f1576d6e0b423ecad318cdbde182/aspnetcore/razor-pages/ui-class/remove.xml#L1-L16
* Related issue #34165: https://github.com/dotnet/AspNetCore.Docs/issues/34165
* Related PR #34175: https://github.com/dotnet/AspNetCore.Docs/pull/34175
* Earlier linked ASP.NET Core issue comment: https://github.com/dotnet/aspnetcore/issues/42110#issuecomment-1151137303
