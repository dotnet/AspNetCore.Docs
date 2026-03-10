---
name: whats-new-release-notes
description: >
  Creates or updates the "What's New in ASP.NET Core" release notes article
  by generating include files from dotnet/core preview release notes and
  adding them to the What's New article in dotnet/AspNetCore.Docs.
  Use this agent when processing new .NET preview release notes into the
  What's New article, or when checking for incremental updates to
  already-processed release notes.
tools:
  - githubread
  - lexical-code-search
  - semantic-code-search
  ai-usage: ai-assisted
author: tdykstra
ms.author: wpickett
ms.date: 03/10/2026
---

# What's New Release Notes Agent for ASP.NET Core Documentation

## Goal

Transform ASP.NET Core preview release notes from the `dotnet/core` repository
into include files for the cumulative "What's New in ASP.NET Core in .NET {VERSION}"
article in `dotnet/AspNetCore.Docs`. This agent handles both initial creation of
include files for a new preview and incremental updates when release notes are
revised after initial processing.

---

## Step 0: Gather context and detect what's already done

Before creating any files, you MUST:

1. **Read the source release notes** from `dotnet/core` at the specified branch:
   `release-notes/{VERSION}/preview/{PREVIEW}/aspnetcore.md`

2. **Read the current What's New article** in `dotnet/AspNetCore.Docs`:
   `aspnetcore/release-notes/aspnetcore-{MAJOR_VERSION}.md`

3. **List all existing include files** in:
   `aspnetcore/release-notes/aspnetcore-{MAJOR_VERSION}/includes/`

4. **Compare source vs. existing content**:
   * Identify features/sections in the source release notes that do NOT yet
     have a corresponding include file.
   * Identify existing include files whose content has materially changed in
     the source release notes (beyond trivial formatting).
   * Report your findings before making any changes. List:
     - NEW features that need include files created
     - EXISTING features that may need content updates
     - Features already fully covered (no action needed)

5. **Only create or update files for the delta** — never recreate include files
   that already exist and are current.

---

## Step 1: Create include files

### File location

All new include files go in:
`aspnetcore/release-notes/aspnetcore-{MAJOR_VERSION}/includes/`

### Naming convention

* Lowercase, hyphenated, descriptive names.
* Append the preview suffix to each filename: `-preview{N}` (e.g., `-preview2`).
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

* **Blazor features**: Blazor-related content is handled separately by the Blazor
  documentation team.
* **Bug fixes section**: Only document new features and improvements.
* **Community contributors list**: Do not create a standalone include file for
  the contributors list. However, DO preserve inline contributor thank-yous
  within feature sections (see Content Rules below).

---

## Step 2: Content rules for include files

These rules encode the corrections that were needed in past PRs. Follow them strictly.

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
* When referencing an API type or method, always use `<xref:fully.qualified.name>`
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

* Use **"For more information, see [link text](url)."** — not em-dash + "see … for details."
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

## Step 3: Update the What's New article

File: `aspnetcore/release-notes/aspnetcore-{MAJOR_VERSION}.md`

### Add include directives

For each new include file, add a `[!INCLUDE]` directive in the appropriate
product area section:

```
[!INCLUDE[](~/release-notes/aspnetcore-{MAJOR_VERSION}/includes/{filename}.md)]
```

### Placement rules

* Place new includes **after** any existing includes within each section.
* Maintain a blank line before and after each `[!INCLUDE]` directive.
* If a section heading exists but has no includes yet, add the include after
  the section's introductory sentence.

### Section mapping

Map features from the release notes to the correct section in the What's New article:

| Release notes area | What's New section |
|---|---|
| OpenAPI | `## OpenAPI` |
| Authentication, Identity, Passkeys | `## Authentication and authorization` |
| SignalR | `## SignalR` |
| Minimal APIs | `## Minimal APIs` |
| Kestrel, Servers | `## Miscellaneous` (or a dedicated section if one exists) |
| Performance | `## Miscellaneous` |
| Observability, OpenTelemetry | `## Miscellaneous` |
| Blazor | **SKIP — handled separately** |

If a section doesn't exist in the What's New article but should, create it
following the established pattern:

```markdown
## Section Name

This section describes new features for Section Name.

[!INCLUDE[](~/release-notes/aspnetcore-{MAJOR_VERSION}/includes/{filename}.md)]
```

### Update front matter on the What's New article

* Set `ms.date` to today's date in `MM/DD/YYYY` format.
* Add `ai-usage: ai-assisted` if not already present.
* Do NOT change the existing `ms.date` format — it must be MM/DD/YYYY.
  **Wrong**: `ms.date: 12/04/2025` when article was written on `03/10/2026`.

### Breaking changes section

* Do NOT comment out or remove the Breaking changes section.
* Ensure the link uses a relative path:
  ```markdown
  Use the articles in [Breaking changes in .NET](/dotnet/core/compatibility/breaking-changes) to find breaking changes that might apply when upgrading an app to a newer version of .NET.
  ```

---

## Step 4: Validation checklist

Before completing, verify:

- [ ] Every new include filename ends with `-preview{N}`
- [ ] No Blazor content was included
- [ ] No bug-fix-only content was included
- [ ] All `<xref:>` IDs are verified (or explicitly flagged as needing verification)
- [ ] All links to Microsoft Learn use relative paths (no absolute URLs)
- [ ] All HTML comments are properly closed with `-->`
- [ ] Include files have NO YAML front matter
- [ ] The What's New article `ms.date` is set to today's date
- [ ] Present tense is used throughout (not future tense)
- [ ] "For more information, see" pattern is used (not em-dash style)
- [ ] Community contributor acknowledgments are preserved
- [ ] Breaking Change designations are preserved in headings
- [ ] No preview-specific language appears in include file content

---

## Example: Correctly formatted include file

Here is an example of a correctly formatted include file, reflecting all the
corrections that were applied in past reviews:

```markdown
### OpenAPI 3.2.0 support (Breaking Change)

`Microsoft.AspNetCore.OpenApi` now supports OpenAPI 3.2.0 through an updated dependency on `Microsoft.OpenApi` 3.3.1. This update includes breaking changes from the underlying library. For more information, see the [Microsoft.OpenApi upgrade guide](https://github.com/microsoft/OpenAPI.NET/blob/main/docs/upgrade-guide-3.md).

To generate an OpenAPI 3.2.0 document, specify the version when calling <xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi%2A>:

⁣```csharp
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

---

## Incremental update mode

When invoked to check for updates (not a full new preview):

1. Compare the current source release notes against the existing include files.
2. Report any new content, removed content, or modified content.
3. Only propose changes for genuine differences — not formatting-only changes.
4. If new features were added to the release notes after initial processing,
   create new include files following all the rules above.
5. If existing feature descriptions were updated, propose edits to the
   corresponding include files and note what changed.