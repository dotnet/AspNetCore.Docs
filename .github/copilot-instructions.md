---
author: wadepickett
ms.author: wpickett
ms.date: 07-24-2025
---

# Copilot Instructions for `dotnet/AspNetCore.Docs`

## Introduction

This document contains instructions for GitHub Copilot when assisting with the `dotnet/AspNetCore.Docs` repository. **Unless otherwise specified, all ".NET" references refer to modern .NET, not .NET Framework.**

## General Writing Guidelines

- **Follow the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/).**
- Additionally for this repository:
  - Number ordered lists as "1." for every item (don't use sequential numbers)
  - Use `code style` specifically for file names, folders, custom types, and code that should never be localized

## Collaboration Guidelines

### Status Updates and Technical Clarification
- Begin responses with a concise summary of your understanding
- Use headers to organize complex responses
- Provide clear status updates for multi-step tasks
- Format: "**Status**: [Working on/Completed/Need input] - [Brief description]"
- List specific technical questions in numbered format when seeking clarification
- For ASP.NET Core version questions, always specify current assumptions

### Draft Documentation
- Mark draft content with "**DRAFT**:" prefix
- For complex concepts, provide simplified explanations first
- Use code blocks with syntax highlighting
- Highlight areas needing expert review with comments
- Ensure ms.date is set to the current date

### Handling Feedback and Handoffs
- Acknowledge technical feedback with specific references
- For conflicting guidance, summarize approaches and request clarification
- When transitioning documentation:
  - Provide structure and scope summary
  - List unresolved questions
  - Reference related documentation
  - Include version-specific considerations

## Verification Protocols

When uncertain about content:

### API References
- Never guess API documentation IDs
- State when verification is needed
- Provide likely namespace and class/method name
- Add TODO comments when creating PRs

### Version Compatibility
- Check if feature was introduced after .NET Core 3.1
- Default to most compatible syntax when uncertain
- Add version information for new APIs
- Include reviewer comments when verification is needed

### Breaking Changes
Use this checklist:
- Changes default behavior of existing API
- Removes or renames public API elements
- Changes method signatures or return types
- Modifies serialization format
- Alters dependency requirements
- Changes configuration schema

### Always Flag for Human Review
- Security implications
- Licensing considerations
- Product roadmap questions
- Comparisons with competing technologies
- Political or controversial technical decisions

## Version Targeting

### Detection Priority Order
1. **Explicit PR/Issue Instructions** - Prioritize explicit version ranges mentioned
2. **File Metadata** - Check YAML frontmatter for specifications
3. **Inline Moniker Tags** - Look for version range specifications
4. **Repository Branch Context** - Consider branch where PR will be merged
5. **Directory Structure** - Check for version-specific directories

### Content Patterns
- State version range in first paragraph of version-specific content
- Use conditional content for significant version differences
- Use version tables for subtle differences across versions
- For code examples with version ranges, use conditional compilation or separate files
- Begin with clear version support statements
- Use consistent labels for version-specific content

### Common Range Patterns
- Fixed Range: `>= aspnetcore-7.0 <= aspnetcore-9.0`
- Open Upper Bound: `>= aspnetcore-7.0`
- Open Lower Bound: `<= aspnetcore-9.0`
- Specific Version: `== aspnetcore-9.0`

## Localization Guidelines

- Keep sentences short and direct
- Use articles consistently
- Avoid ambiguous pronouns
- Establish and maintain a clear glossary of terms
- Always surround code elements with backticks (`)
- Explain acronyms on first use
- Avoid culturally-specific metaphors or examples
- Use international date formats (YYYY-MM-DD) in code
- Add sufficient comments in code to explain logic
- Describe UI elements by function rather than appearance
- Minimize text embedded in images
- Use standard document structures that work across languages

## Issue and PR Collaboration

### Issue Classification
- **Documentation Bug:** Incorrect or outdated technical information
- **Content Enhancement:** Request to expand existing documentation
- **New Feature Documentation:** Documentation for newly implemented features
- **Localization Issue:** Problems with translated content
- **Accessibility Issue:** Content that doesn't meet accessibility standards

### Priority Levels
- **P0 (Critical):** Incorrect information that could cause serious problems
- **P1 (High):** Missing key information or incorrect examples
- **P2 (Medium):** Improvements to existing documentation or minor inaccuracies
- **P3 (Low):** Style improvements, typos, or enhancement requests

### PR Comments
- Always include specific file paths and line numbers in comments
- Clearly indicate which file each suggestion applies to
- For multi-file issues, list all affected files
- Format feedback with clear section headers (Style/Format, Technical Accuracy)
- For technical questions, reference specific implementation concerns
- When suggesting changes, distinguish between required changes and optional improvements

### Human-Copilot Handoff
Scenarios requiring human intervention:
- Inconsistent or conflicting technical information
- Political or controversial topics
- Legal or licensing questions
- Security vulnerabilities
- Complex architectural decisions

## Links and References

- Use **relative links** for files within this repo
- For learn.microsoft.com links, **remove** `https://learn.microsoft.com/en-us` from URLs
- Use cross-references for APIs: `<xref:api-doc-ID>`
- Get doc ID from the relevant XML doc in dotnet-api-docs
- Omit first two characters of the doc ID

## Code Snippets

- For snippets **longer than 6 lines**:
  - Place in separate `.cs` file in a `snippets` folder next to the Markdown file
  - Create a subfolder named after the document
  - For version-specific code, include a version folder
  - Add a simple `.csproj` file targeting the appropriate .NET version

- Reference snippets using triple-colon syntax:
  - **Use file-relative paths** for snippets specific to a single doc file:
    ```
    :::code language="csharp" source="../snippets/my-doc/Program.cs":::
    ```
  - **Use repository root-relative paths** for shared snippets:
    ```
    :::code language="csharp" source="~/tutorials/min-web-api/samples/9.x/todoGroup/TodoDb.cs":::
    ```

- For longer snippets, highlight specific lines:
