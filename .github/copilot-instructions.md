---
author: wadepickett
ms.author: wpickett
ms.date: 07-25-2025
---

# Copilot Instructions for `dotnet/AspNetCore.Docs`

## Introduction

This document contains repository-specific instructions for GitHub Copilot when assisting with the `dotnet/AspNetCore.Docs` repository. **Unless otherwise specified, all ".NET" references refer to modern .NET, not .NET Framework.**

## Repository-Specific Guidelines

- Follow the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/)
- **Repository Exceptions**:
  - Number ordered lists as "1." for every item (don't use sequential numbers)
  - Use `code style` specifically for file names, folders, custom types, and code that should never be localized

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

- Never guess API documentation IDs
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

- Use **relative links** for files within this repo
- For learn.microsoft.com links, **remove** `https://learn.microsoft.com/en-us` from URLs
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
- Use modern C# coding patterns in all examples

## ASP.NET Core Specific Guidelines

- Use the latest supported version for examples unless otherwise specified
- Lead with Microsoft recommended approaches
- Include differences between minimal API and controller-based approaches when relevant
- For middleware, lead with the middleware class approach
- For Blazor, clearly distinguish between Server and WebAssembly hosting models

## Issue Handling

When creating a PR for an issue:
1. Read the full issue and all linked references
2. Study code samples from linked PRs for pre-release features
3. For labeled issues:
 - **breaking-change:** Include breaking change guidance
 - **new-feature:** State which version introduced the feature
 - **bug:** Focus on correcting technical inaccuracies
4. When you're assigned an issue, after you've completed your work and the workflows (status checks) have run, check to make sure there are no build warnings under the OpenPublishing.Build status check. If there are, open the build report (under View Details) and resolve any build warnings you introduced.
