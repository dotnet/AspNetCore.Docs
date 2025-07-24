---
author: wadepickett
ms.author: wpickett
ms.date: 07-23-2025
---

# Copilot Instructions for `dotnet/AspNetCore.Docs`

## Quick Command Reference for Human Users

> - By default, Copilot follows all instructions in this document when responding
> - **Optional:** Use these commands in GitHub PR comments or issues when you want to focus on specific aspects only
> - Format: `@copilot Review PR with sections: [comma-separated section names]`
> - Example: `@copilot Review PR with sections: Code Snippets, Accessibility Considerations`
> - See [Selective Instruction Application](#selective-instruction-application) section for complete details

## Introduction

This document contains comprehensive instructions for GitHub Copilot to follow when assisting with the `dotnet/AspNetCore.Docs` repository. These guidelines help ensure consistent, high-quality documentation that follows Microsoft's standards and best practices. **Unless otherwise specified, all ".NET" references refer to modern .NET, not .NET Framework.**

## General Writing and Editing Guidelines

- **Follow the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/).**
- **Headings:**
  - Use sentence case (not Title Case).
  - Do not use gerunds in titles.
- **Voice & Tone:**
  - Use active voice whenever possible.
  - Address the reader directly (second person).
  - Use a conversational tone with contractions.
  - Be concise and break up long sentences.
  - Use present tense for instructions and descriptions.  
    _Example: "The method returns a value."_
  - Do **not** use "we" or "our" for documentation authors.
  - Use imperative mood for instructions.  
    _Example: "Call the method."_
  - Use "might" instead of "may" to indicate possibility.
  - **Avoid unnecessary second-person pronouns:**
    - Prefer direct statements that focus on the subject rather than addressing the reader as "you"
    - Instead of "You need to navigate to the project folder," use "Navigate to the project folder, which contains the `.csproj` file"
    - Instead of "When you configure routing," use "When configuring routing"
    - Only use "you" when alternative phrasing would be awkward or unclear
    - For action statements, use imperative mood without "you" (Example: "Add the package" rather than "You should add the package")
- **Lists and Formatting:**
  - Use the Oxford comma in lists of three or more items.
  - Number ordered lists as "1." for every item.
  - Use bullets for unordered lists.
  - Use **bold** for UI elements.
  - Use `code style` for file names, folders, custom types, and other text that should never be localized.
  - Write raw URLs in angle brackets.

## Human-Copilot Collaboration

- **Clear Communication in GitHub Conversations:**
  - Begin responses with a concise summary of your understanding of the task
  - Use headers (## or ###) to organize complex responses
  - For ASP.NET Core technical questions, cite relevant documentation or code examples
  - When multiple stakeholders are involved, address specific questions to individuals using @ mentions

- **Status Updates in PR Comments:**
  - **[To reviewer]** Provide clear status updates when working on multi-step tasks
  - **[To reviewer]** Format: "**Status**: [Working on/Completed/Need input] - [Brief description]"
  - **[To reviewer]** For complex documentation changes, list affected files with current status
  - **[To reviewer]** Example: "**Status**: Working on middleware documentation - Completed intro and configuration sections, need input on security best practices"

- **Requesting Technical Clarification:**
  - **[To reviewer]** When documentation requirements are ambiguous, list specific technical questions
  - **[To reviewer]** Format questions as numbered lists for easy reference in replies
  - **[To reviewer]** For ASP.NET Core version questions, always specify the current assumption
  - **[To reviewer]** Example: "1. Which authentication methods should this example cover? I'm assuming Microsoft Entra ID (formerly Azure AD) integration for cloud-native applications with .NET Aspire, ASP.NET Core Identity for traditional web applications, or JWT for dedicated API scenarios."

- **Providing Draft Documentation:**
  - **[To reviewer]** Clearly mark draft content in GitHub comments with "**DRAFT**:" prefix
  - **[In documentation]** For complex ASP.NET Core concepts, provide simplified explanations first, followed by technical details
  - **[In documentation]** Use code blocks with syntax highlighting for all code examples
  - **[To reviewer]** Highlight areas needing subject matter expert review with: <!-- SME Review: [specific question] -->
  - **[In documentation]** For new features, explicitly note where example code is based on preview builds

- **Handling Technical Feedback:**
  - **[To reviewer]** Acknowledge all technical feedback with specific references
  - **[To reviewer]** When implementing feedback on ASP.NET Core concepts, cite relevant documentation or API references
  - **[To reviewer]** For conflicting technical guidance, summarize the different approaches and request clarification
  - **[To reviewer]** Always defer to ASP.NET Core team members on implementation details for pre-release features

- **Documentation Handoff Protocol:**
  - **[To reviewer]** When transitioning draft documentation to authors, provide:
    - Summary of documentation structure and scope
    - List of any unresolved technical questions
    - References to related documentation that may need updating
    - Suggestions for additional code examples if appropriate
    - Version-specific considerations, especially for cross-version compatibility

## Verification Protocols for Uncertain Content

When you encounter situations requiring specific knowledge that may not be in your training data:

### API Reference Verification

- **Never guess** at API documentation IDs for `<xref>` tags
- When uncertain about an API reference:
  1. **[To reviewer]** Explicitly state: "I need to verify the correct API reference ID for [API name]"
  2. **[To reviewer]** Provide the most likely namespace and class/method name
  3. **[To reviewer]** Suggest searching dotnet-api-docs for the correct ID
  4. **[In PR code]** If creating a PR, add a comment: `<!-- TODO: Verify API reference ID for [API name] -->`

### Version Compatibility Verification

- For any code example where version compatibility isn't explicitly known:
  1. Check if the feature was introduced after .NET Core 3.1
  2. Review the API documentation for version availability notes
  3. When uncertain, default to the most compatible syntax and:
     - **[In documentation]** Add a note in the documentation stating: "This example uses syntax compatible with .NET [version] and later versions."
     - **[To reviewer]** Add a comment to the PR: "<!-- Note to reviewers: Used syntax compatible with earliest known version (.NET X.Y). Please verify if this works with earlier versions. -->"
  4. For new APIs with unknown compatibility:
     - **[In documentation]** Include version information: "This API is available in .NET [known version]."
     - **[To reviewer]** Add a comment to the PR: "<!-- Note to reviewers: Availability of this API in versions prior to .NET X.Y needs verification. -->"

### Template Selection

- When selecting document templates:
  1. Check repository for similar document types first
  2. Look for template files in the `.github/ISSUE_TEMPLATE/` or `docs-template` directories
  3. When uncertain:
     - **[In documentation]** Use the most minimal template format that fits the content type
     - **[To reviewer]** Add a comment: "<!-- Template selection needs verification. Used minimal format based on [reference document]. -->"
  4. For specialized content types (migration guides, samples, tutorials), always check for existing examples

### Breaking Change Identification

When evaluating if a change is breaking, use this checklist approach rather than guessing:
- [ ] Changes default behavior of existing API
- [ ] Removes or renames public API elements
- [ ] Changes method signatures or return types
- [ ] Modifies serialization format
- [ ] Alters dependency requirements
- [ ] Changes configuration schema

If ANY box would be checked:
- **[In documentation]** Include a breaking change warning box
- **[To reviewer]** Add a comment: "<!-- Identified as potential breaking change because [specific reason]. Please verify. -->"

### Questions to Flag for Human Review

ALWAYS flag these scenarios for human review rather than guessing:
- Security implications of code examples
- Licensing considerations
- Product roadmap questions
- Comparisons with competing technologies
- Political or controversial technical decisions
- Performance claims without benchmarks

**[To reviewer]** Use this format for flagging: "**Requires Human Review**: [specific reason] - This aspect should be verified by the ASP.NET Core team because [explanation]."

## Version Targeting

- **Version Range Detection - Priority Order:**
  1. **Explicit PR or Issue Instructions** - Always prioritize explicit version ranges mentioned in the current PR or issue description
     - Examples: "Update for .NET 8-9 compatibility" or "Add examples for .NET 7 through 9"
  
  2. **File Metadata** - Check for version specifications in YAML frontmatter
     - Look for: `monikerRange:`, `ms.version`, or similar metadata fields
     - Example: `monikerRange: '>= aspnetcore-7.0 <= aspnetcore-9.0'`

  3. **Inline Moniker Tags** - Look for version range specifications using moniker tags within the document
     - Examples: `::: moniker range=">= aspnetcore-7.0 <= aspnetcore-9.0"`
     - Pay attention to end moniker tags (`::: moniker-end`) that might indicate nested version ranges

  4. **Repository Branch Context** - Consider the branch where the PR will be merged
     - Example: if working in a `release/8.0` branch, content likely targets .NET 8.0
  
  5. **Directory Structure** - Check if the file exists in a version-specific directory
     - Example: Files under `/aspnetcore/mvc/9.0/` target .NET 9.0

- **Handling Version Ranges in Content:**
  - **[In documentation]** Explicitly state version range in the first paragraph of a document or section with version-specific content
    - Example: "This feature is available in ASP.NET Core 7.0 through 9.0."
  
  - **[In documentation]** Use conditional content for significant version differences within a range:
    ```
    ::: moniker range=">= aspnetcore-9.0"
    // .NET 9.0+ content
    ::: moniker-end

    ::: moniker range=">= aspnetcore-7.0 < aspnetcore-9.0"
    // .NET 7.0-8.0 content
    ::: moniker-end
    ```
  
  - **[In documentation]** Use version tables for features with subtle differences across versions
    - Example: Create a table with columns for .NET 7.0, 8.0, and 9.0 and rows for different aspects of the feature
  
  - **[In documentation]** For code examples with version ranges:
    - Use conditional compilation with appropriate `#if` directives
    - Create separate snippet files for different versions when behavior varies significantly
    - Include version folders for snippets (e.g., `snippets/my-doc/7.x-9.x/` for shared examples)
    - Use clear naming patterns that indicate version support (e.g., `Program.Net7-9.cs`)

- **Version Range Documentation Patterns:**
  - **[In documentation]** Begin with a clear statement of supported versions
    - Example: "Starting with ASP.NET Core 7.0, with additional options in 9.0, you can..."
  
  - **[In documentation]** Use clear labels for version-specific content:
    - "Added in ASP.NET Core 8.0:" or "Changed in 9.0:"
    - For version differences within a paragraph, use parenthetical clarifications: "(In ASP.NET Core 9.0+, this behavior changes to...)"
  
  - **[In documentation]** For features evolving across versions:
    - Document the progression clearly
    - Highlight deprecation warnings for features that may change in future versions
    - Use tables to show property availability across version ranges

- **Common Version Range Patterns:**
  - **Fixed Range:** `>= aspnetcore-7.0 <= aspnetcore-9.0` (7.0 through 9.0)
  - **Open Upper Bound:** `>= aspnetcore-7.0` (7.0 and later)
  - **Open Lower Bound:** `<= aspnetcore-9.0` (9.0 and earlier)
  - **Specific Version:** `== aspnetcore-9.0` (9.0 only)
  - **Exclusion:** `>= aspnetcore-7.0 != aspnetcore-8.0` (7.0 and later except 8.0)

- **If the version range is unclear:**
  - **[To reviewer]** State that the version range is not specified
  - **[To reviewer]** Request clarification while providing a default assumption based on context
  - **[To reviewer]** Example: "The issue doesn't specify a version range. Based on the repository structure and referenced APIs, I'm assuming this applies to ASP.NET Core 7.0 through 9.0. Please confirm if this is correct."

## Accessibility Considerations

- **Document Structure:**
  - **[In documentation]** Use proper heading hierarchy (H1 > H2 > H3) without skipping levels
  - **[In documentation]** Create descriptive headings that clearly convey the section's content
  - **[In documentation]** Use HTML tables with proper header cells (`<th>`) and scope attributes for data tables
  - **[In documentation]** Add a summary of complex tables in the preceding text
  - **[In documentation]** For Blazor and ASP.NET Core UI component documentation, include keyboard navigation instructions

- **Code Examples:**
  - **[In documentation]** Provide text explanations before code blocks that describe their purpose
  - **[In documentation]** Use descriptive variable names in code samples rather than single letters or abbreviations
  - **[In documentation]** Include comments in code explaining complex logic or accessibility considerations
  - **[In documentation]** For accessibility-specific examples (like ARIA attributes in Razor views), clearly explain their purpose
  - **[In documentation]** When documenting UI components, include accessibility properties and their recommended values

- **Links and Navigation:**
  - **[In documentation]** Use descriptive link text that makes sense out of context (avoid "click here" or "learn more")
  - **[In documentation]** For API references, include the method/class name in the link text
  - **[In documentation]** When linking to external resources, indicate if they open in a new window/tab
  - **[In documentation]** Ensure documentation navigation patterns are consistent across related topics

- **Images and Visual Content:**
  - **[In documentation]** Always include alternative text for images that convey their purpose and content
  - **[In documentation]** For screenshots of ASP.NET Core UIs or Blazor components, describe key elements shown
  - **[In documentation]** For diagrams illustrating architecture or data flow, provide text descriptions of the relationships
  - **[In documentation]** For code screenshots, always include the actual code in a text code block as well
  - **[In documentation]** Use high contrast and colorblind-friendly color schemes in diagrams
  - **[In documentation]** Avoid using color alone to convey meaning in diagrams or screenshots

- **Inclusive Language:**
  - **[In documentation]** Use person-first language when discussing accessibility features
  - **[In documentation]** Avoid ableist terminology or metaphors (e.g., "see below" or "heard from users")
  - **[In documentation]** Reference assistive technologies accurately and by their current names
  - **[In documentation]** When discussing keyboard navigation, use standard key naming conventions

- **Specialized Content:**
  - **[In documentation]** For documenting ASP.NET Core accessibility features:
    - Include WCAG success criteria being addressed where relevant
    - Provide both basic and advanced implementation examples
    - Reference the accessibility standards and guidelines being followed
    - Include testing approaches for the feature being documented
  - **[In documentation]** For Blazor components:
    - Document ARIA roles, states, and properties supported
    - Include keyboard interaction patterns
    - Explain focus management techniques where applicable

- **Testing Recommendations:**
  - **[In documentation]** When documenting UI components, include accessibility testing guidance
  - **[In documentation]** Mention relevant tools for testing ASP.NET Core applications for accessibility
  - **[In documentation]** Include examples of automated and manual testing approaches
  - **[In documentation]** Document common accessibility issues to watch for in specific component types

## Localization-Friendly Content

- **General Principles:**
  - **[In documentation]** Keep sentences short and direct to facilitate translation
  - **[In documentation]** Use articles ("the", "a", "an") consistently to help machine translation
  - **[In documentation]** Avoid ambiguous pronouns where the referent isn't clear
  - **[In documentation]** Use consistent terminology throughout related documents

- **Technical Terminology:**
  - **[In documentation]** Establish and maintain a clear glossary of ASP.NET Core terms
  - **[In documentation]** Always surround code elements with backticks (`) in markdown text
    - Example: The `aspnetcore.components.navigate` metric tracks route changes
    - Include all properties, classes, methods, file names, folder paths, and code fragments
    - This applies to inline code references, even when brief: use `JsonOptions` not JsonOptions
  - **[In documentation]** Use code formatting for all code elements to maintain consistency
  - **[In documentation]** Explain acronyms on first use within each document

- **Cultural Considerations:**
  - **[In documentation]** Avoid culturally-specific metaphors or examples
  - **[In documentation]** Use international date formats (YYYY-MM-DD) in code examples
  - **[In documentation]** Avoid directional language assuming left-to-right reading
  - **[In documentation]** Use universal examples rather than region-specific ones

- **Code Examples:**
  - **[In documentation]** Add sufficient comments to explain logic, which helps translators understand context
  - **[In documentation]** Keep variable names in English as per programming conventions
  - **[In documentation]** Include explanatory comments for complex regex patterns or LINQ expressions
  - **[In documentation]** For configuration examples, explain each setting's purpose

- **UI References:**
  - **[In documentation]** When referring to UI elements, use descriptive text rather than relying solely on appearance
  - **[In documentation]** Example: "Select **Save** button at the bottom of the form" rather than "Click the green button"
  - **[In documentation]** Include UI element paths for complex navigation steps

- **Images and Diagrams:**
  - **[In documentation]** Minimize text embedded in images to reduce localization burden
  - **[In documentation]** Design diagrams with space for text expansion (translations often require more space)
  - **[In documentation]** For essential text in diagrams, provide text alternatives that can be localized

- **Documentation Structure:**
  - **[In documentation]** Use standard document structures that work across languages
  - **[In documentation]** Implement clear heading hierarchies to maintain document organization
  - **[In documentation]** Keep content modular so sections can be translated independently
  - **[In documentation]** Use numbered steps for procedures to maintain clarity across languages

## Effective Issue and PR Collaboration

### Issue Triage Protocol

When evaluating new issues in this repository:

1. **Issue Classification:**
   - **Documentation Bug:** Incorrect or outdated technical information
   - **Content Enhancement:** Request to expand existing documentation
   - **New Feature Documentation:** Documentation for newly implemented features
   - **Localization Issue:** Problems with translated content
   - **Accessibility Issue:** Content that doesn't meet accessibility standards

2. **Priority Assessment:**
   - **P0 (Critical):** Incorrect information that could cause serious problems for users
   - **P1 (High):** Missing key information about a core feature or incorrect examples
   - **P2 (Medium):** Improvements to existing documentation or minor inaccuracies
   - **P3 (Low):** Style improvements, typos, or enhancement requests

3. **Initial Response Templates:**
   - **[To issue reporter]** For questions: "Thanks for your question. To help you most effectively, could you please share: [specific details needed]?"
   - **[To issue reporter]** For bug reports: "I've reviewed this documentation issue. I can confirm this is [accurate/needs investigation]. I'll [action plan]."
   - **[To issue reporter]** For enhancement requests: "Thank you for suggesting this enhancement. This is intended to improve the documentation by [benefit]. I'll prepare a draft PR that [specific approach]."

### PR Comment Templates

When providing feedback on PRs:

1. **[To PR author]** Approval with Minor Changes:
   ```
   The changes look good overall! I have a few minor suggestions to align with our documentation standards:
   
   ## Style and Format
   - [Specific style feedback with examples]
   
   ## Technical Accuracy
   - [Any technical concerns or questions]
   
   These are relatively minor - feel free to address them and merge when ready.
   ```

2. **[To PR author]** Requesting Significant Changes:
   ```
   Thank you for your contribution! There are some areas that need revision before this is ready to merge:
   
   ## Required Changes
   - [List of must-fix issues with specific examples]
   
   ## Suggestions for Improvement
   - [Optional enhancements that would strengthen the PR]
   
   Please let me know if you'd like any clarification or assistance with these changes.
   ```

3. **[To PR author]** Technical Question Format:
   ```
   I have a technical question about this implementation:
   
   In [file/line reference], you're documenting [feature/approach]. However, this appears to [describe concern].
   
   According to [reference/standard/guidance], we should [alternative approach]. Could you clarify your implementation choice or consider updating this section?
   ```

### PR Comment Location References

- **[To PR author]** When commenting on a PR with multiple files, always include:
  - The exact file path (e.g., `docs/core/middleware/example.md`)
  - The specific line number(s) or range (e.g., `Line 42` or `Lines 42-47`)
  - Code snippets showing the problematic content when appropriate
  - Example format: "In `docs/core/middleware/example.md` at line 42, the API reference appears to be incorrect..."
- **[To PR author]** For multi-file issues that span across files, list all affected files with their respective line numbers
- **[To PR author]** When suggesting fixes, clearly indicate which file and location each suggestion applies to
- **[To PR author]** For GitHub web UI inline comments on specific lines, additional location references are not needed as the comment is already tied to the specific location

### Human-Copilot Handoff Protocol

- **Scenarios Requiring Human Intervention:**
  - Inconsistent or conflicting technical information that can't be resolved through available documentation
  - Political or controversial topics related to technology choices or approaches
  - Legal or licensing questions beyond basic MIT/Apache guidance
  - Security vulnerabilities or sensitive content disclosures
  - Complex architectural decisions requiring deep ASP.NET Core team knowledge

- **Handoff Process:**
  1. **[To reviewer]** Clearly state why human expertise is needed: "This requires team discussion because..."
  2. **[To reviewer]** Summarize what you've already determined and what remains uncertain
  3. **[To reviewer]** Provide specific questions for human reviewers to address
  4. **[To reviewer]** Suggest possible approaches while acknowledging the need for human judgment
  5. **[To reviewer]** Tag appropriate team members based on the topic area

- **Progress Preservation:**
  - **[To reviewer]** When handing off, provide a summary of completed work
  - **[To reviewer]** Format partially completed work in a way that's easy to continue
  - **[To reviewer]** Identify decision points clearly so humans know exactly where input is needed

### Documentation Release Coordination

- **[In documentation]** Preview/RC Documentation:
  - Include installation instructions specific to preview packages
  - Note any known limitations
  
- **[In documentation]** Deprecation Documentation:
  - Use consistent warning format for deprecated features
  - Include timeline for removal when known
  - Provide migration path with concrete examples
  - Link to replacement APIs or approaches

## Selective Instruction Application

> **Note for human users:** The following section describes commands that can be used to selectively apply sections of the copilot-instructions.md document. This information is for human reference only; Copilot will not interpret this as an instruction to selectively apply rules unless you explicitly use the command format in your requests.

When working with Copilot, you may want to focus on specific aspects of these instructions rather than applying all guidelines. You can use the command format below in PR comments, issue comments, or direct conversations with Copilot to specify which instruction sections should be applied.

### Example Commands

**Full review with all sections:**
```
@copilot Review PR #123
```
or explicitly listing all sections:
```
@copilot Review PR #123 with sections: all
```

**Targeted review focusing on specific aspects:**
```
@copilot Review PR #123 with sections: Accessibility Considerations, Code Snippets, Version Targeting
```

**PR creation with focused guidelines:**
```
@copilot Create a PR for issue #456 with sections: General Writing and Editing Guidelines, ASP.NET Core Specific Guidance, Code Snippets
```

### Available Section Names

When selecting specific sections, use these exact names:
- General Writing and Editing Guidelines
- Human-Copilot Collaboration
- Verification Protocols for Uncertain Content
- Version Targeting
- Accessibility Considerations
- Localization-Friendly Content
- Effective Issue and PR Collaboration
- Linking and References
- Code Snippets
- Markdown File Naming
- Pull Request Review Guidelines
- Issue Handling
- ASP.NET Core Specific Guidance

## Linking and References

- **[In documentation]** Include links to related topics/resources where relevant.
  - Use **relative links** for files within this repo.
  - For learn.microsoft.com links, **remove** `https://learn.microsoft.com/en-us` from the URL.
- **[In documentation]** For APIs, use cross-references: `<xref:api-doc-ID>`.
  - Use the `Value` attribute from the relevant XML doc in [dotnet-api-docs](https://github.com/dotnet/dotnet-api-docs).
  - For types, get the doc ID from `<TypeSignature Language="DocId">`.
  - For members, get it from `<MemberSignature Language="DocId">`.
  - Omit the first two characters of the doc ID.
  - Example: `<xref:System.String>`

## Code Snippets

- **[In documentation]** For code snippets **longer than 6 lines**:
  - Place them in a separate `.cs` file in a `snippets` folder next to the Markdown file.
  - Within `snippets`, create a subfolder named after the document (e.g., `my-doc/snippets/`).
  - For version-specific code, include a version folder (e.g., `9.x` for .NET 9, `10.x` for .NET 10 for a path like `my-doc/snippets/9.x/`).
  - Add a simple `.csproj` file targeting the appropriate .NET version in the same directory.

- **[In documentation]** Reference snippets using the triple-colon syntax:
  - **Use file-relative paths** when snippets are specific to a single doc file and would move with it:
    ```
    :::code language="csharp" source="../snippets/my-doc/Program.cs":::
    ```
    This approach is better when:
    - The snippet is only used by one document
    - The document and its snippets would be moved together during reorganization
    - The snippets folder is closely tied to the doc's location
  
  - **Use repository root-relative paths** with `~/` for shared snippets or standardized locations:
    ```
    :::code language="csharp" source="~/tutorials/min-web-api/samples/9.x/todoGroup/TodoDb.cs":::
    ```
    This approach is better when:
    - The snippet is shared across multiple documents
    - The snippet location is standardized and unlikely to move with any specific doc
    - The snippet is in a completely different section of the repository
  
  - Include the version folder in the path when applicable (e.g., `9.x`, `10.x`)
  - Specify the language using the `language=` parameter

- **[In documentation]** For code snippets longer than 10 lines, highlight the specific lines that are being discussed by:
  - Adding line numbers in comments or descriptive text
  - Using bold formatting to emphasize specific lines in the explanatory text
  - Including "focus on lines X-Y" callouts before the snippet
  - Use the range syntax to highlight specific lines:
    ```
    :::code language="csharp" source="~/path/to/file.cs" range="5-10" highlight="2-3":::
    ```
- **[In documentation]** Ensure all code examples are up-to-date with the latest ASP.NET Core versions.
- **[In documentation]** Include proper XML comments for any public API code examples.
- **[In documentation]** Always use modern C# coding patterns and best practices in examples.

## Markdown File Naming

- **[When creating files]** Name new Markdown files in **lowercase with hyphens** (no spaces or underscores).
- **[When creating files]** **Omit** filler words like "the" or "a" from file names.

**Example:**
- **Bad:** `The-Quick-Start-Guide.md`
- **Good:** `quick-start-guide.md`

## Pull Request Review Guidelines

When asked to review PRs for this repository:

1. **[To PR author]** Verify technical accuracy of ASP.NET Core content.
2. **[To PR author]** Check code consistency with latest ASP.NET Core practices and patterns.
3. **[To PR author]** Confirm style guide adherence including heading case, voice, tone, and formatting.
4. **[To PR author]** Validate links to ensure they're formatted correctly and point to valid resources.
5. **[To PR author]** Review file structure to ensure snippets are properly organized and named.
6. **[To PR author]** Check for inclusive language and adherence to Microsoft's style guide.
7. **[To PR author]** Suggest improvements for clarity, conciseness, and technical accuracy.
8. **[To PR author]** Highlight any concerns about breaking changes or version compatibility.

## Issue Handling

When asked to create a PR for an issue:

1. **Read the full issue description** and any comments for context.
   - **Always check any linked references** in the issue (PRs, other issues, or external links)
   - **Pay special attention to linked PRs or issues** that contain implementation details about unreleased features
   - If the issue mentions "check PR #xyz for details" or similar instructions, prioritize examining that content first
   - For features not yet publicly released, rely on information in linked development PRs rather than public documentation

2. **Understand the specific ASP.NET Core technology** being documented.
   - For pre-release features, study any available code samples from linked development PRs
   - Consider the version context (which ASP.NET Core version the feature targets)
   - Examine test cases in linked PRs to understand intended behavior

3. **Follow these steps:**
   - **[When creating PR]** Create appropriate file(s) in the correct location.
   - **[When creating PR]** Adhere to all style guidelines above.
   - **[When creating PR]** Include proper metadata and front matter if required.
   - **[When creating PR]** Create any necessary code snippets in the appropriate snippets folder.
   - **[When creating PR]** Add relevant links to other documentation.
   - **[When creating PR]** Include appropriate cross-references to API documentation.

4. **Special handling for labeled issues:**
   - **[In documentation]** If labeled **breaking-change**, include directions from `.github/prompts/breaking-change.md`.
   - **[In documentation]** If labeled **new-feature**, ensure documentation explicitly states which version introduced the feature.
   - **[In documentation]** If labeled **bug**, focus on correcting the specific technical inaccuracy noted.

5. **Issue Template Adherence:**
   - **[When responding to issues]** For **doc-issue** template: Address version information and include reference to the original document URL
   - **[When responding to issues]** For **doc-request** template: Follow the structure for new topic proposals, including TOC placement and outline
   - **[When responding to issues]** For **customer-feedback** issues: Pay special attention to the Document ID and URL to maintain connection to the source document
   - **[To reviewer]** Note that most document issues should be opened using the "Open a documentation issue" link at the bottom of articles
   - **[When responding to issues]** Preserve all metadata fields from templates in your responses to maintain traceability

6. **Issue Prioritization:**
   **[When handling multiple issues]** Consider these factors when selecting issues to address:
   - **User Impact**: Issues affecting many users or blocking scenarios
   - **Documentation Completeness**: Missing critical information vs. minor improvements
   - **Issue Age**: Older issues may need attention to maintain community trust
   - **Prerequisites**: Some issues may depend on others being resolved first
   - **Resource Requirements**: Balance quick wins with more complex tasks

7. **Issue Resolution Criteria:**
   An issue can be considered resolved when:
   - **[In documentation]** The documentation accurately reflects current behavior
   - **[In documentation]** All requested features or clarifications are documented
   - **[In documentation]** Code examples are verified to work as described
   - **[In documentation]** Appropriate cross-references to related documentation exist
   - **[In documentation]** The specific concern in the issue description is explicitly addressed

   **[When closing issues]** When closing an issue:
   - Summarize what was changed to address it
   - Link to the PR that contains the changes
   - Invite feedback if the resolution needs further refinement

## ASP.NET Core Specific Guidance

[In documentation] Use the latest supported version for examples unless specifically documenting version differences or the document specifies a different version. A version specified in the PR or issue description takes precedence.
[In documentation] Favor leading with the Microsoft recommended approach rather than showing all possible options side-by-side.
[In documentation] Include relevant differences between minimal API and controller-based approaches when appropriate for the scope and focus of the topic. The minimal API approach is usually the favored recommendation otherwise.
[In documentation] When documenting middleware, lead with the middleware class approach followed by its extension method registration. Only include alternative middleware implementation approaches when the scope and focus of the topic requires it.
[In documentation] For Blazor content, clearly distinguish between Server and WebAssembly hosting models.

---

> **Note:** If you have questions, refer to the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/) or ask in the project's discussions.