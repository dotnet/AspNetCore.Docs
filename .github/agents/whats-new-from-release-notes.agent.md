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
ms.date: 03/11/2026
---

# What's New Release Notes Agent for ASP.NET Core Documentation

## Goal

Transform ASP.NET Core preview release notes from the `dotnet/core` repository
into include files for the cumulative "What's New in ASP.NET Core in .NET {VERSION}"
article in `dotnet/AspNetCore.Docs`. This agent handles both initial creation of
include files for a new preview and incremental updates when release notes are
revised after initial processing.

## Dependencies

* **Skill**: [whats-new-include-content-rules](../skills/whats-new-include-content-rules/SKILL.md) — content rules and formatting standards for include files.

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

Load and follow all rules from the
[whats-new-include-content-rules](../.github/skills/whats-new-include-content-rules/SKILL.md)
skill. That skill defines file naming, location, exclusions, content formatting,
xref usage, link rules, phrasing style, and the validation checklist.

Apply those rules to create one include file per feature from the source
release notes.

---

## Step 2: Update the What's New article

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

## Step 3: Validate

Run the validation checklist from the
[whats-new-include-content-rules](../.github/skills/whats-new-include-content-rules/SKILL.md)
skill. Additionally verify:

- [ ] The What's New article `ms.date` is set to today's date
- [ ] All `[!INCLUDE]` directives are correctly placed with blank lines around them
- [ ] Section mapping matches the table above

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