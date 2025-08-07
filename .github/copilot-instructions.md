---
author: wadepickett
ms.author: wpickett
ms.date: 07-31-2025
---

# Copilot Instructions for `dotnet/AspNetCore.Docs`

## Introduction
This document contains general and repository-specific instructions for GitHub Copilot when assisting with the `dotnet/AspNetCore.Docs` repository. **Unless otherwise specified, all ".NET" references refer to modern .NET, not .NET Framework.**

## General Guidelines

### Issue Handling
When creating a PR for an issue:
1. Read the full issue and all linked references
2. Study code samples from linked PRs that demonstrate features in the latest .NET pre-release version (e.g., .NET 10 Preview) to ensure that guidance and documentation reflect the latest upcoming changes and best practices.
3. For labeled issues that have the following labels, follow these guidelines:
 - **new-feature:** State which version introduced the feature
 - **bug:** Focus on correcting technical inaccuracies
4. When you're assigned an issue, after you've completed your work and the workflows (status checks) have run, ensure there are no build warnings under the OpenPublishing.Build status check. If there are, open the build report (under View Details) and resolve any build warnings you introduced.
5. Provide an overview of the project you're working on, including its purpose, goals, and any relevant background information.
6. Include the folder structure of the repository, including any important directories or files that are relevant to the project.

### Markdown File Naming and Organization
- If you're adding a new Markdown file, it should be named in all lowercase with hyphens separating words. Also, omit any filler words such as "the" or "a" from the file name.

### API References and Verification
  - Use `<xref:api-doc-ID>` for API cross-references. 
  - The API documentation ID must be verified and sourced from the official XML documentation in dotnet-api-docs, never just infer API documentation IDs by looking for similar patterns.
  - If you cannot verify, state that explicitly in your output.

### Links and References
- Use relative links (for example, `../folder/file.md` or `./file.md`) when referencing files within this repository. Do not use absolute URLs or GitHub web links for internal content.
- For external links, always remove any language or culture segment from the URL path (such as `/en-us/`, `/fr-fr/`, `/en/`, etc.).
  - Example (Microsoft Learn):
    - Original: `https://learn.microsoft.com/en-us/aspnet/core/blazor/`
    - Correct: `https://learn.microsoft.com/aspnet/core/blazor/`
  - Example (Wikipedia):  
    - Original: `https://en.wikipedia.org/wiki/ASP.NET_Core`
    - Correct: `https://wikipedia.org/wiki/ASP.NET_Core`
- For Microsoft Learn links, also strip the base domain (`https://learn.microsoft.com/en-us`) so only the path remains.
  - Example:  
    - Original: `https://learn.microsoft.com/en-us/aspnet/core/blazor/`
    - Correct: `/aspnet/core/blazor/`

## Repository-Specific Guidelines
- Follow the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/)
- **Repository Exceptions**:
  - Number ordered lists as "1." for every item (don't use sequential numbers)
  - Use backticks around content specifically for file names (`file.txt`), folders (`folder`), file paths (`folder/file.txt`), custom types (`myVariable`, `MyClass`), raw URLs in the text (`https://www.contoso.com`), URL segments (`/product/id/199`), file extensions (`.razor`), NuGet packages (`Microsoft.AspNetCore.SignalR.Client`), and code that should never be localized
  - For Blazor's Razor components mentioned in article text, use backticks around the name of the component (example: `Counter` component)
  - For any new or updated .md file, ensure the standard frontmatter (metadata) is included as specified in [Metadata for Microsoft Learn documentation.](https://learn.microsoft.com/en-us/contribute/content/metadata)
  - For any new or updated .md file added to the repository, ensure the following frontmatter (metadata) is included:
    - Metadata `ai-usage: ai-assisted` if any AI assistance was used
    - Place the title metadata first, followed by the remaining metadata lines in alphabetical order. Example: `title`, `author`, `description`, `monikerRange`, `ms.author`, `ms.custom`, `ms.date`, `uid`, `zone_pivot_groups`
    - Metadata `ms.date: <today's date>` with a format of MM-DD-YYYY.  If the file already has a `ms.date` metadata, update it to today's date if more than 50 characters are changed in the file.
    
### Version Targeting Common Range Patterns
- Fixed Range: `>= aspnetcore-7.0 <= aspnetcore-9.0`
- Open Upper Bound: `>= aspnetcore-7.0`
- Open Lower Bound: `<= aspnetcore-9.0`
- Specific Version: `== aspnetcore-9.0`

### Code Snippets
- For code snippets longer than 6 lines:
  1. Create a subfolder named after the document the snippet supports.
  1. Create a `snippets` folder inside that subfolder.
  1. For the code file:
     - If the snippet is not version-specific, place the code in a file with the appropriate extension (for example, `.cs` for C#) in the `snippets` folder.
     - If the snippet is version-specific:
        1. Create a subfolder inside the `snippets` folder named for the version (for example, `9.0` for .NET 9 or ASP.NET Core 9).
        1. Place the code in a file with the correct extension inside the version subfolder.
        1. Add a project file (`.csproj`) to the version subfolder targeting the matching .NET version, if necessary to run or build the snippet.
- Reference snippets using triple-colon syntax:
  - **Use file-relative paths** for snippets located in the same file as the articles that refer to it.
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
- Use the following language code and indentation standards for markdown code blocks or the `language` attribute of code snippets:

  Content of the snippet | Language code | Indentation in spaces
  :---: | :---: | :---:
  C# | csharp | 4
  HTML | html | 4
  CSS | css | 4
  JavaScript | javascript | 2 spaces (use 4 spaces for line continuation)
  XML | xml | 2
  JSON | json | 2
  Console | console | 2
  Text | - | 2

### ASP.NET Core Specific Guidelines
- Use the latest supported version for examples unless otherwise specified
- Title and section header casing is sentence case (capitalize the first word and any proper nouns)
- For parts of a title or section header that normally use code style in article text (backticks around the content), also use code style in the title or section header (example H1 header: "# Modify the `Program.cs` file")
- Use code style for any words that shouldn't be localized
- For bullet lists, use an asterisk as the bullet marker
- Bullet lists should have two or more entries at the same level in the list. If there is only one item under a bullet, remove its bullet marker and roll that item into its parent bullet.
- Lead with Microsoft-recommended approaches
- Include differences between Minimal API and controller-based approaches when relevant
- For middleware content and examples, use the middleware class approach
