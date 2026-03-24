---
author: wpickett
description: >
  Generates a freshness review report for an ASP.NET Core doc article.
  Usage: Open a GitHub issue, open Copilot Chat, and paste:
  "Read and follow all instructions in .github/prompts/article-freshness-review.prompt.md.
  Use this issue as context. Generate the freshness review report."
  Then copy the report into the issue discussion. Does NOT create a PR.
ms.author: wpickett
ms.date: 03/24/2026
---

# ASP.NET Core Article Freshness Review

> **Usage**: Attach this prompt file in Copilot Chat, then type the article URL
> (e.g., `Review https://learn.microsoft.com/aspnet/core/web-api/action-return-types`).
> Paste the resulting report into the GitHub issue discussion.
> **This prompt does NOT create a PR or modify any files.**

## Instructions

You are reviewing an ASP.NET Core documentation article for freshness and accuracy.

### Step 1: Load Context

Read the repository's copilot instruction file for conventions and rules:
[copilot-instructions.md](../copilot-instructions.md)

And read the dotnet/docs repository editing instructions:
https://raw.githubusercontent.com/dotnet/docs/refs/heads/main/.github/agents/docseditor.agent.md

### Step 2: Review the Article

Review the article provided by the user.

Evaluate it against ALL of the following criteria:

**A. Moniker Range & Versioning**
* Are there newer APIs, packages, or approaches that supersede what the article describes?
* If so: Is the monikerRange in the frontmatter still appropriate?
* If the article covers a version that is no longer the latest, does it include guidance directing readers to the current version's documentation?

**B. Frontmatter & Metadata**
* Is ms.date in MM/DD/YYYY format?
* If ms.date is older than 6 months, flag it as a Minor metadata-only update.
  An old ms.date does NOT by itself indicate the article content is stale — the
  content may still be accurate and current. Classify a stale ms.date as Minor
  severity. It must never contribute to a "Needs Updating" verdict on its own.
* Is the title field listed first, with remaining fields in alphabetical order?
* Are all required metadata fields present? (Check only for presence, not for 
  cross-field value consistency. For example: The `author` and `ms.author` fields are 
  independent and are not required to match.)

**C. Content Accuracy**
* Are code samples correct for the targeted framework version(s)?
* Are NuGet package names and namespaces still valid?
* Are referenced APIs still available and not deprecated in the targeted version?
* Do xref links (xref:) resolve to valid UIDs?

**D. Style & Conventions (per copilot-instructions.md)**
* Placeholders in code/commands use {UPPER CASE WITH SPACES} format with descriptions in surrounding text.
* Section headers do NOT end with periods.
* Bullet markers use * (not -).
* Links follow the documented conventions (relative for MS Learn, full URL for external).
* Code blocks use :::code snippet references where appropriate.

**E. External Links**
* Are external URLs likely still valid? (Flag any that point to known-sunset services or archived repos.)

### Step 3: Produce the Report

Output a single Markdown report with this EXACT structure:

```
# Freshness Review Report

**File:** `{FILE PATH}`
**Repository:** `dotnet/AspNetCore.Docs`
**Reviewed:** {REVIEW DATE}
**Reviewer:** @{REVIEWER}
**Article URL:** {ARTICLE URL}
**Source URL:** {SOURCE URL}

---

## Verdict: **{Needs Updating | Current — No Changes Needed}**

A verdict of "Needs Updating" requires at least one Critical or Moderate issue.

---

## Critical Issues

{Issues that affect correctness, reader confusion, or discoverability.
Each issue should include:
- **Issue title**
- **Location:** file path and line number(s)
- **Current content:** (quoted)
- **Recommended fix:** (exact replacement text)
- **Rationale:** why this matters}

## Moderate Issues

{Issues that affect style compliance or minor accuracy.
Same sub-structure as Critical.}

## Minor Issues

{Cosmetic or convention-based issues.
Same sub-structure as Critical.}

---

## Copilot Feasibility Assessment

**Can Copilot handle this freshness update?** {Yes | Likely | Partial | No}

**Justification:**
{Explain why Copilot can or cannot be expected to handle the full update
correctly with minimal PR review corrections. Consider:
* Are the changes primarily mechanical (metadata, formatting, link fixes)?
* Do any changes require deep domain knowledge of ASP.NET Core APIs or architecture?
* Are there judgment calls about content restructuring or technical accuracy?
* Would the update require testing code samples against a running application?}

**Recommendation:**
{One of:
* "Assign to Copilot" — Changes are mechanical and well-defined
* "Assign to Copilot with human review of [specific areas]" — Mostly mechanical but some areas need expert judgment
* "Assign to a human author" — Changes require domain expertise, significant rewriting, or code verification that Copilot cannot reliably perform}

## Summary of Recommended Changes

{A numbered checklist of ALL changes, in order of priority, that can be
used directly as a task list for the PR author.}
```

## Rules

* Do NOT invent issues. If something is correct, say so.
* Do NOT suggest changes outside the scope of the copilot-instructions.md rules and current ASP.NET Core documentation standards.
* If recommending a NOTE or callout, provide the EXACT Markdown to insert including moniker-range fencing if applicable.
* Flag the issue title if it doesn't match the actual file name or path.
* Every recommended change must include the exact "before" and "after" text.
