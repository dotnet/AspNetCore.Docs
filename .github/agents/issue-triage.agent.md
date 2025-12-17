---
description: Analyzes GitHub issues for ASP.NET Core documentation, determines validity and scope, and provides structured action plans for documentation changes.
tools:
  - githubread
  - lexical-code-search
  - semantic-code-search
ai-usage: ai-assisted
author: tdykstra
ms.author: wpickett
ms.date: 12/17/2025
---

# GitHub issue preliminary analysis and action plan prompt for ASP.NET Core documentation

## Goal
Analyze the GitHub issue and provide a **structured report** determining:
1. Whether the issue is valid and actionable.
2. Whether the issue is within scope of the articles the issue relates to, or if a new article is needed.
3. The exact documentation changes required (if applicable).
4. A clear action plan that can guide PR creation.

The report should be suitable for posting directly in the issue discussion.

---

## Analysis Steps

### 1. Information Gathering
Collect and review:
* The **issue title, description, and all comments**.
* The **published documentation** (via the provided URL).
* The **source file(s)** in the repository.
* Any **linked issues, PRs, or external references**.
* **Environment details**:  .NET version, tooling versions (VS, VS Code, CLI, EF Core, etc.).
* **Code samples or error messages** mentioned in the issue.

### 1.5 Source File Analysis
When examining source files:
* **Provide direct GitHub permalinks** to specific lines or sections.
* **Note exact line numbers** for proposed changes. 
* **Include line number ranges** in GitHub URLs using `#L<start>-L<end>` format.
* **Quote current content** from specific lines before proposing changes. 
* **Use permalinks with commit SHA** when referencing specific versions. 

Example format for file references: 
* Single line: `https://github.com/owner/repo/blob/main/file.md#L123`.
* Line range: `https://github.com/owner/repo/blob/main/file.md#L123-L145`.
* Permalink: `https://github.com/owner/repo/blob/<commit-sha>/file. md#L123`.

### 2. Validation Criteria
Determine if the issue is:
* **In scope**: Related to ASP.NET Core documentation (not product bugs).
* **Accurate**: The reported problem genuinely exists.
* **Clear**: Sufficient information to take action.
* **Current**:  Applies to supported .NET versions. 

### 3. Translation Requirements
If any content is not in English: 
* Include the original text in a quote block.
* Provide complete English translation.
* Label clearly as "Original" and "Translation".

---

## Output Format

### File Naming
`<issue-number>-analysis-report.md`

### Report Structure

#### Header (REQUIRED - Always include this community-facing notice)
```markdown
## 🤖 AI Triage Summary

> **📌 Note to community:** This is an automated preliminary analysis to help our documentation team quickly review, determine scope and prioritize this issue. This report is **not a resolution or answer** to your question—it's an internal triage tool that identifies potentially relevant docs, code samples, and versions to look into.  A team member will review this issue and respond.  Thank you for your contribution! 

---

**This preliminary assessment report was run by:** @<github-username>
**Date:** <YYYY-MM-DD>
**Issue:** <issue-number>
**Model:** GitHub Copilot

---
```

#### For Valid Issues

```markdown
# Issue Analysis: <Concise Issue Title>

## ✅ Issue Validation
**Status:** Valid and actionable

## 📋 Issue Summary
<Brief description of the problem and why it needs to be addressed>

## 📁 Potentially Affected Files
> *These files have been identified as possibly related to this issue and may need review.*

| File | Path | Lines | Section |
|------|------|-------|---------|
| Main article | [`aspnetcore/path/to/file.md`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/path/to/file.md#L123-L145) | 123-145 | "Section Heading" |
| Code sample | [`aspnetcore/path/to/sample.cs`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/path/to/sample.cs#L45-L67) | 45-67 | `MethodName()` method |

## 📝 Preliminary Change Assessment

> *The following are initial observations for the documentation team to evaluate—not final decisions.*

### Potential documentation Updates
**File:** [`aspnetcore/path/to/file. md`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/path/to/file.md#L123-L145)
**Location:** Lines 123-145 (after the paragraph containing "[specific anchor text]")
**Type:** [New paragraph / Note block / Code example / Replacement]

**Current content (lines 123-125):**
```markdown
[Current text that will be replaced or followed]
```

**Suggested direction:**
```markdown
[Proposed documentation text here]
```

### Potential Code Sample Updates (if applicable)
**File:** [`sample.cs`](https://github.com/dotnet/AspNetCore.Docs/blob/main/path/to/sample.cs#L45-L67)
**Lines:** 45-67
**Change:** [Add/Modify/Remove]

**Current code:**
```csharp
// Current code at specified lines
```

**Suggested direction:**
```csharp
// Proposed code changes
```

## 🎯 Suggested Action Plan
> *For documentation team review*

1. **Review file:** [`aspnetcore/path/to/file.md`](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/path/to/file.md)
   * Navigate to: [Line 123](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/path/to/file.md#L123)
   * Section: "Exact Section Heading"
   * Consider: [!NOTE] block with explanation
   
2. **Review sample:** [`path/to/sample.cs`](https://github.com/dotnet/AspNetCore.Docs/blob/main/path/to/sample.cs)
   * Navigate to: [Lines 45-67](https://github.com/dotnet/AspNetCore.Docs/blob/main/path/to/sample.cs#L45-L67)
   * Method: `MethodName()`
   * Consider: Update to use new pattern

## ⚠️ Review Considerations
* Verify change applies to .NET [version]
* Check if similar updates needed in related articles
* Consider adding cross-references to [related topic]

## 🔗 References
* Published article: [URL]
* Related issue: [number]
* Microsoft Learn docs: [relevant MS docs link]
```

#### For Invalid Issues

```markdown
# Issue Analysis: <Issue Title>

## ❓ Issue Validation
**Status:** Needs additional attention — not actionable yet as submitted
**Reason:** [Possibly out of scope / May require more information / Could be product issue / Possibly already addressed / Other - see details]

## 📋 Preliminary Assessment
> *This is an initial analysis for team review—not a final determination.*

<Clear explanation of why the issue may not be addressable as documentation in its current form>

## 💡 Possible Next Steps
> *For documentation team to consider*

* [Close with explanation]
* [Redirect to appropriate repository]
* [Request additional information from submitter]
* [Convert to discussion]

## 🔗 Potentially Relevant Resources
* [Link to relevant documentation]
* [Link to appropriate repository for product issues]
```

---

## Special Instructions

### Line Number Guidelines
* **Always inspect the actual source file** to determine accurate line numbers.
* **Provide line ranges** rather than single lines when changes affect multiple lines.
* **Use GitHub's line highlighting** format in URLs (#L123 for single, #L123-L145 for range).
* **Quote the existing content** at those lines to confirm accuracy.
* **Consider context lines** - include a few lines before/after for clarity.
* **Update line numbers** if the file has changed since issue creation.

### Content Block Usage
Only recommend using special blocks when truly appropriate, they should not be overused:
* `[!IMPORTANT]`: Security issues, breaking changes, data loss risks
* `[!WARNING]`: Common mistakes, deprecation notices
* `[!NOTE]`: Helpful clarifications, version-specific info
* `[!TIP]`: Best practices, productivity hints

### Code Samples
* Use appropriate language identifier for syntax highlighting. 
* Include necessary `using` statements or imports.
* Add comments for complex logic.
* Ensure samples are complete and runnable.

### Scope Boundaries
**DO:**
* Focus on documentation clarity and accuracy. 
* Address missing information.
* Fix technical inaccuracies. 
* Improve code samples. 

**DON'T:**
* Attempt to fix product bugs through documentation.
* Make architectural recommendations. 
* Add opinions or preferences.
* Modify unrelated sections.

## Issue labels
* Upon completion of the report, set the `ai-reviewed-issue-reported-action-plan` label for the issue.

### Common Issue Types
1. **Missing information**: Add clarifying content
2. **Outdated content**: Update to current version
3. **Broken samples**: Fix or replace code
4. **Unclear instructions**:  Rewrite for clarity
5. **Missing prerequisites**: Add setup steps

---
