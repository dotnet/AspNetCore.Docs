---
author: wadepickett
ms.author: wpickett
ms.date: 07-28-2025
---

# Copilot Instructions for `dotnet/AspNetCore.Docs`

## Introduction

This document contains repository-specific instructions for GitHub Copilot when assisting with the `dotnet/AspNetCore.Docs` repository. **Unless otherwise specified, all ".NET" references refer to modern .NET, not .NET Framework.**

## Repository-Specific Guidelines

- Follow the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/)
- **Repository Exceptions**:
  - Number ordered lists as "1." for every item (don't use sequential numbers)
  - Use backticks, also called backquotes or graves, around content specifically for file names (`file.txt`), folders (`folder`), file paths (`folder/file.txt`), custom types (`myVariable`, `MyClass`), raw URLs in the text (`https://www.contoso.com`), URL segments (`/product/id/199`), file extensions (`.razor`), NuGet packages (`Microsoft.AspNetCore.SignalR.Client`), and code that should never be localized
  - For Blazor's Razor components mentioned in article text, use backticks around the name of the component (example: `Counter` component)
  - For any new .md file added to the repository or any updated .md file ensure the standaerd frontmatter (meta data) specified by the Style Guide is included.
  - For any new .md file added to the repository or any updated .md file ensure the following frontmatter (meta data) is included.
    - Metadata `ai-usage: ai-assisted` if any AI assistance was used
    - The correct order of metadata lines is to place the title (`title`) first and the rest of the metadata lines in alphabetical order. Example: `title`, `author`, `description`, `monikerRange`, `ms.author`, `ms.custom`, `ms.date`, `uid`, `zone_pivot_groups`
    - Metadata `ms.date: <today's date>` with a format of MM-DD-YYYY.  If the file already has a `ms.date` metadata, update it to today's date if more than 50 characters are changed in the file.
    
## Version Targeting

### Detection Priority Order
1. **Explicit PR/Issue Instructions** - Prioritize explicit version ranges mentioned
2. **File Metadata** - Check YAML frontmatter for specifications
3. **Inline Moniker Tags** - Look for version range specifications
4. **Repository Branch Context** - Consider branch where PR will be merged
5. **Directory Structure** - Check for version-specific directories

### Common Range Patterns
- Fixed Range: `>= aspnetcore-7.0 <= aspnetcore-9.0`
- Open Upper Bound: `>= aspnetcore-7.0`
- Open Lower Bound: `<= aspnetcore-9.0`
- Specific Version: `== aspnetcore-9.0`

## API References and Verification

- Never guess API documentation IDs, always verify. If unable to verfy, say so.
- Check if features were introduced after .NET Core 3.1
- Default to most compatible syntax when uncertain
- For breaking changes, check:
  - Changes to default behavior of existing APIs
  - Removed or renamed public API elements
  - Modified method signatures or return types
  - Changed serialization formats
  - Altered dependency requirements
  - Changes to configuration schema

## Links and References

- Use relative links for files within this repo
- When adding external links into a document, strip out the language/culture segment of the URL if present (example: remove the `en-us` or `en` part of links to English versions of webpages)
- For learn.microsoft.com links, remove `https://learn.microsoft.com/en-us` from URLs
- Use cross-references for APIs: `<xref:api-doc-ID>`
- Get doc ID from the relevant XML doc in dotnet-api-docs
- Omit first two characters of the doc ID

## Markdown File Naming and Organization

- If you're adding a new Markdown file, it should be named in all lowercase with hyphens separating words. Also, omit any filler words such as "the" or "a" from the file name.
  
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
  ```
  :::code language="csharp" source="~/path/to/file.cs" range="5-10" highlight="2-3":::
  ```
- Use the latest, non-preview C# coding patterns in non-preview code examples
- Use the latest preview C# coding patterns in preview code examples

The following table indicates the code language to use for markdown code blocks or the `language` attribute of a code snippet and the amount of indentation to use.

Content of the snippet | Code language | Indentation in spaces
:---: | :---: | :---:
C# | csharp | 4
HTML | html | 4
CSS | css | 4
JavaScript | javascript | 2 (4 spaces for line continuation)
XML | xml | 2
JSON | json | 2
Console | console | 2
Text | - | 2

## ASP.NET Core Specific Guidelines

- Use the latest supported version for examples unless otherwise specified
- Title and section header casing is sentence case (capitalize the first word and any proper nouns)
- For parts of a title or section header that normally use code style in article text (backticks around the content), also use code style in the title or section header (example H1 header: "# Modify the `Program.cs` file")
- Use code style for any words that shouldn't be localized
- For bullet lists, use an asterisk as the bullet marker
- Bullet lists should have two or more entries at the same level in the list. If there is only one item under a bullet, remove its bullet marker and roll that item into its parent bullet.
- Lead with Microsoft recommended approaches
- Include differences between Minimal API and controller-based approaches when relevant
- For middleware content and examples, use the middleware class approach
- For Blazor, clearly distinguish between Server and WebAssembly hosting models

## Issue Handling

When creating a PR for an issue:
1. Read the full issue and all linked references
2. Study code samples from linked PRs for pre-release features
3. For labeled issues:
 - **breaking-change:** For general .NET breaking changes, reference [Breaking changes in .NET](../dotnet/core/compatibility/breaking-changes). For ASP.NET Core-specific breaking changes, add details to the "What's new" release notes file for the corresponding .NET version in this repo (using includes if appropriate), and cross-link to the main .NET breaking changes page. If no content is needed for a given release, ensure the release notes still link to the main breaking changes resource.
 - **new-feature:** State which version introduced the feature
 - **bug:** Focus on correcting technical inaccuracies
4. When you're assigned an issue, after you've completed your work and the workflows (status checks) have run, check to make sure there are no build warnings under the OpenPublishing.Build status check. If there are, open the build report (under View Details) and resolve any build warnings you introduced.

