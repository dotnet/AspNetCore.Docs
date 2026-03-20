---
name: whats-new-include-content-rules
description: >
  Content rules and formatting standards for ASP.NET Core What's New include files.
  Use when creating or editing include files in aspnetcore/release-notes/*/includes/.
  Covers heading levels, xref API references, link formatting, phrasing style,
  breaking change designations, contributor acknowledgments, file naming, and exclusions.
  Use for: What's New include file, release notes include, xref format, include content rules,
  H3 heading level, relative link Microsoft Learn, include file naming convention.
---

# What's New Include File — Content Rules

These rules encode corrections from past PR reviews. Follow them strictly when
creating or editing include files under `aspnetcore/release-notes/aspnetcore-{MAJOR_VERSION}/includes/`.

## File creation rules

### File location

All include files go in:
`aspnetcore/release-notes/aspnetcore-{MAJOR_VERSION}/includes/`

### File naming convention

* Lowercase, hyphenated, descriptive names.
* Append the preview number suffix to each filename: `-preview{N}` (where `{N}` is the preview number, e.g., `-preview2`).
  **CRITICAL**: Every new file MUST include the preview suffix. This was a mistake
  in the initial automation — a file was created without the suffix and had to be
  corrected.
* Examples:
  - `native-otel-tracing-preview2.md`
  - `openapi-3-2-support-preview2.md`
  - `infer-passkey-display-name-preview2.md`
  - `performance-improvements-preview2.md`

### One file per feature

* Create one include file per feature or section.
* **Exception — Performance**: Combine all performance improvements into a
  single `performance-improvements-preview{N}.md` file.

### Exclusions — do NOT create include files for

* **Do not create include files for Blazor features**:
  * Blazor-related content is handled separately by the Blazor documentation team with separate PRs that merge into the What's New.
  * Do **NOT** create any new include files for Blazor content.
  * Do indicate in the PR description report which Blazor features are present in the release notes but not represented in the What's New article or includes.

* **Do not create include files for bug fixes**: The What's New article only covers new features and improvements, not bug fixes.
* **Community contributors list**:
  * Do not create a standalone include file for the contributors list.
  * DO preserve inline contributor thank-yous within feature sections (see below).

---

## Content rules

### Heading level

* Use `###` (H3) headings — never `#` or `##`. Include files are embedded inside
  a parent article that already uses `##` for section headings.

### Remove preview-specific references

* Do NOT mention the specific preview number in content (e.g., "In Preview 2…").
  The What's New article is cumulative for the entire .NET release.

### Use `<xref:>` for API references — not inline code

* **Wrong**: `` `AddOpenApi()` ``
* **Correct**: `<xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi%2A>`
* **Wrong**: `` `BadHttpRequestException` ``
* **Correct**: `<xref:Microsoft.AspNetCore.Http.BadHttpRequestException>`
* When referencing an API type or method, use `<xref:fully.qualified.name>`
  format. The xref ID must be verified from official dotnet-api-docs, not guessed.
* If the API is brand new in this preview and no xref exists yet, link to the
  source code on GitHub instead and add an HTML comment
  `<!-- TODO: Update to <xref:> once API docs are published -->` so it can be
  updated later.
  format. The xref ID must be verified from official dotnet-api-docs, not guessed.
* When referring to a dictionary/API concept (not a file), do NOT include file
  extensions. For example, write `PasskeyAuthenticators` dictionary, not
  `PasskeyAuthenticators.cs` dictionary.

### Links — use relative paths for Microsoft Learn

* **Wrong**: `[Breaking changes in .NET]([/dotnet/core/compatibility/breaking-changes](https://learn.microsoft.com/dotnet/core/compatibility/breaking-changes))`
* **Correct**: `[Breaking changes in .NET](/dotnet/core/compatibility/breaking-changes)`
* Never nest a relative path inside an absolute URL as the href target.
* For Microsoft Learn cross-references, use relative URLs starting with `/`.
  Do not include `https://learn.microsoft.com` or the `/en-us/` locale.

### Links — external sites

* For GitHub repository links, use full absolute URLs.
* For external non-Microsoft sites, use absolute URLs and strip locale segments.

### Phrasing and style (lessons from reviewer feedback)

* Use **"For more information, see [link text](url)."**, not "see [link text](url) for details."
   - **Wrong**: "ASP.NET Core now supports OpenAPI 3.2.0 — see [the upgrade guide](url) for details."
   - **Correct**: "For more information, see [the upgrade guide](url)."
* Use **present tense**, not future tense.
  - **Wrong**: "Subsequent updates **will take** advantage of…"
  - **Correct**: "Subsequent updates **take** advantage of…"
* Use **imperative voice** for instructions to readers.
  - **Wrong**: "Developers can extend the mappings by…"
  - **Correct**: "Extend the mappings by…"
* Move long lists of attributes/parameters to the **end** of the sentence for readability.
  - **Wrong**: "…populates semantic convention attributes like `a`, `b`, `c`, and `d` on the request activity."
  - **Correct**: "…populates semantic convention attributes on the request activity, such as `a`, `b`, `c`, and `d`."

### Preserve special designations

* If a section is marked as a **Breaking Change**, preserve that designation
  in the include file heading: `### Feature name (Breaking Change)`
* If a section thanks a **community contributor** inline, preserve the
  acknowledgment: `Thank you [@username](https://github.com/username) for this contribution!`

### HTML comments

* Properly close HTML comments with `-->`. Never leave an unclosed HTML comment.

### Include files have NO front matter

* Include files (in the `includes/` directory) do NOT get YAML front matter
  (no `---` block with title, ms.date, etc.). They are raw Markdown fragments.

---

## Validation checklist

Before completing, verify:

- [ ] Every new include filename ends with `-preview{N}`.
- [ ] No Blazor content was included.
- [ ] No bug-fix-only content was included.
- [ ] All `<xref:>` IDs are verified (or explicitly flagged as needing verification).
- [ ] All links to Microsoft Learn use relative paths (no absolute URLs).
- [ ] All HTML comments are properly closed with `-->`.
- [ ] Include files have NO YAML front matter.
- [ ] Present tense is used throughout (not future tense).
- [ ] "For more information, see" pattern is used (not em-dash style).
- [ ] Community contributor acknowledgments are preserved.
- [ ] Breaking Change designations are preserved in headings.
- [ ] No preview-specific language, such as a preview number, appears in include file content.

---

## Example: Correctly formatted include file

```markdown
### OpenAPI 3.2.0 support (Breaking Change)

`Microsoft.AspNetCore.OpenApi` now supports OpenAPI 3.2.0 through an updated dependency on `Microsoft.OpenApi` 3.3.1. This update includes breaking changes from the underlying library. For more information, see the [Microsoft.OpenApi upgrade guide](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-3.md).

To generate an OpenAPI 3.2.0 document, specify the version when calling <xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi%2A>:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_2;
});
⁣```

Subsequent updates take advantage of new capabilities in the 3.2.0 specification, such as item schema support for streaming events.

Thank you [@baywet](https://github.com/baywet) for this contribution!
```

### What this example demonstrates

* `###` heading (H3), not `##`
* Breaking Change designation preserved in heading
* "For more information, see" phrasing (not em-dash style)
* `<xref:>` used for API method reference
* Present tense ("take advantage" not "will take advantage")
* Community contributor thank-you preserved
* No preview number mentioned in the body text
* No YAML front matter
* Relative link would be used for any Microsoft Learn references
