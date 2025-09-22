---
author: tdykstra
ms.author: wpickett
ms.date: 09-21-2025
---

# Copilot Instructions for `dotnet/AspNetCore.Docs`

## Introduction
This document contains general and repository-specific instructions for GitHub Copilot when assisting with the `dotnet/AspNetCore.Docs` repository. **Unless otherwise specified, all ".NET" references refer to modern .NET, not .NET Framework.**

## General Guidelines

### 1. Issue Handling
When creating a PR for an issue:
- [ ] Read the full issue and all linked references
- [ ] Study code samples from linked PRs that demonstrate features in the latest .NET pre-release version (e.g., .NET 10 Preview) to ensure that guidance and documentation reflect the latest upcoming changes and best practices.
- [ ] For labeled issues that have the following labels, follow these guidelines:
  - [ ] **new-feature:** State which version introduced the feature
  - [ ] **bug:** Focus on correcting technical inaccuracies
- [ ] When you're assigned an issue, after you've completed your work and the workflows (status checks) have run, ensure there are no build warnings under the OpenPublishing.Build status check. If there are, open the build report (under View Details) and resolve any build warnings you introduced.
- [ ] Provide an overview of the project you're working on, including its purpose, goals, and any relevant background information.
- [ ] Include the folder structure of the repository, including any important directories or files that are relevant to the project.

### 2. Issue Discussion Analysis
When working on an issue:
- [ ] **Read the complete issue discussion** - Don't rely solely on the initial issue description
- [ ] **Prioritize maintainer guidance** - Comments from repository maintainers (especially those with "MEMBER" association) should take precedence over the original issue description
- [ ] **Look for updated analysis** - Later comments may contain revised understanding, additional context, or modified resolution approaches
- [ ] **Check for explicit instructions** - Look for phrases like "Action required by GitHub Copilot" or direct "@copilot" mentions that provide specific guidance
- [ ] **Validate your understanding** - If the discussion seems to contradict the initial issue description, follow the most recent maintainer guidance

### 3. Markdown File Naming and Organization
- [ ] If you're adding a new Markdown file, it should be named in all lowercase with hyphens separating words. Also, omit any filler words such as "the" or "a" from the file name.

### 4. API References and Verification
  - [ ] Use `<xref:api-doc-ID>` for API cross-references. 
  - [ ] The API documentation ID must be verified and sourced from the official XML documentation in dotnet-api-docs, never just infer API documentation IDs by looking for similar patterns.
  - [ ] If you cannot verify, state that explicitly in your output.

### 5. Links and References
- [ ] For cross-references to other articles within the AspNetCore.Docs repository:
  - [ ] Use the xref syntax: `<xref:target-uid>`
  - [ ] The "target-uid" of the xref syntax is obtained from the `uid` property value in the YAML front matter of the article's markdown file
  - [ ] Examples
    - [ ] For a target article `uid` value of `aspnetcore/mvc/overview`, the xref cross-link is `<xref:aspnetcore/mvc/overview>`
    - [ ] For a target article `uid` value of `blazor/index`, the xref cross-link is `<xref:blazor/index>`

- [ ] For non-markdown files (files that don't have the `.md` file extension) within this repository, such as PowerShell scripts and code files:
  - [ ] Use relative links with the appropriate file extension
  - [ ] Example: `../build-tools/build.ps1` or `./sample.json`

- [ ] For external links to non-Microsoft sites (MDN, W3C, etc.):
  - [ ] Use absolute URLs
  - [ ] Remove any language or culture segment from the URL path (such as `/en-us/`, `/fr-fr/`, `/en/`, etc.)
  - [ ] Example (MDN):  
    - [ ] Original: `https://developer.mozilla.org/en-US/docs/Web/API/Element/click_event`
    - [ ] Correct: `https://developer.mozilla.org/docs/Web/API/Element/click_event`

- [ ] For links to GitHub repositories:
  - [ ] Use the full URL path
    - [ ] Example: `https://github.com/maraf/blazor-wasm-react/blob/main/blazor/Counter.razor`
    - [ ] Example: `https://github.com/dotnet/blazor-samples/blob/main/10.0/BlazorWebAssemblyReact/blazor/Counter.razor`
  - [ ] For other Git hosting services or non-Microsoft domains, use the full URL
    - [ ] Example: `https://gitlab.com/username/repo-name`

- [ ] For links to Microsoft Learn content in other repositories:
  - [ ] Use the relative URL starting with a forward slash
  - [ ] Don't include the scheme and the host (example: `https://learn.microsoft.com`) and don't include the locale (example: `en-us`)
  - [ ] Example: For the target Learn website URL `https://learn.microsoft.com/en-us/dotnet/core/introduction`, use the relative URL `/dotnet/core/introduction` for the link destination

- [ ] Never use physical .md file paths in published content
  - [ ] Wrong: `../blazor/index.md` or `/aspnet/core/blazor/index.md`
  - [ ] Correct: `<xref:blazor/index>`
  - [ ] Exception: GitHub-only content (such as README files, contributing guidelines, and other repository documentation that isn't published to learn.microsoft.com) should use an absolute URL to the markdown file (`.md` file extension)

## Repository-Specific Guidelines
- [ ] Follow the [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/)
- [ ] **Repository Exceptions**:
  - [ ] Number ordered lists as "1." for every item (don't use sequential numbers)
  - [ ] Use backticks around content specifically for file names (`file.txt`), folders (`folder`), file paths (`folder/file.txt`), custom types (`myVariable`, `MyClass`), raw URLs in the text (`https://www.contoso.com`), URL segments (`/product/id/199`), file extensions (`.razor`), NuGet packages (`Microsoft.AspNetCore.SignalR.Client`), and code that should never be localized
  - [ ] For Blazor's Razor components mentioned in article text, use backticks around the name of the component (example: `Counter` component)
  - [ ] For any new or updated .md file, ensure the standard frontmatter (metadata) is included as specified in [Metadata for Microsoft Learn documentation.](https://learn.microsoft.com/en-us/contribute/content/metadata)
  - [ ] For any new or updated .md file added to the repository, ensure the following frontmatter (metadata) is included:
    - [ ] Metadata `ai-usage: ai-assisted` if any AI assistance was used
    - [ ] Place the title metadata first, followed by the remaining metadata lines in alphabetical order. Example: `title`, `author`, `description`, `monikerRange`, `ms.author`, `ms.custom`, `ms.date`, `uid`, `zone_pivot_groups`
    - [ ] Metadata `ms.date: <today's date>` with a format of MM/DD/YYYY. If the file already has a `ms.date` metadata, update it to today's date if more than 50 characters are changed in the file.
      

### 1. Metadata and Date Requirements
- [ ] CRITICAL: Set ms.date to the actual current date in MM/DD/YYYY format.  Do not infer the date based on existing dates in files.  Use today's date.
- [ ] Add ai-usage: ai-assisted metadata if any AI assistance was used
- [ ] Place title metadata first, followed by remaining metadata in alphabetical order
- [ ] Update ms.date if more than 50 characters are changed in existing files
  - [ ] When updating ms.date always use <today's date> in the format MM/DD/YYYY.  Examples:
    - [ ] MM: Two digits, leading zero if needed (01-12)
    - [ ] DD: Two digits, leading zero if needed (01-31)
    - [ ] YYYY: Four digits (2025)   
    - [ ] Example: `ms.date: 08/07/2025`
### 2. Version Targeting Common Range Patterns
- [ ] Fixed Range: `>= aspnetcore-7.0 <= aspnetcore-9.0`
- [ ] Open Upper Bound: `>= aspnetcore-7.0`
- [ ] Open Lower Bound: `<= aspnetcore-9.0`
- [ ] Specific Version: `== aspnetcore-9.0`

### 3. Handling File Redirections
- [ ] When a Markdown (.md) article file (this does not apply to includes) is deleted in a PR, create a redirection entry.
- [ ] Redirections ensure users following existing links aren't left with broken links
- [ ] To add a redirection:
     - [ ] Update the `.openpublishing.redirection.json` file at the repository root
     - [ ] Follow this format for new entries:
     ```json
     {
         "source_path": "aspnetcore/path/to/deleted-file.md",
         "redirect_url": "/aspnet/core/path/to/target-file",
         "redirect_document_id": false
     }
     ```
     - [ ] Use relative URLs for redirection to pages in the `learn.microsoft.com` domain
        - [ ] Example: `/aspnet/core/path/to/target-file`
     - [ ] For URLs in a different domain, use absolute URLs including the domain.
        - [ ] Example: `https://learn.microsoft.com/dotnet/core/introduction`
     - [ ] Set `redirect_document_id` to `false` unless specifically instructed otherwise
     - [ ] Maintain alphabetical order of the `source_path` entries for better organization
     - [ ] Ensure proper JSON formatting with correct commas between entries
- [ ] When selecting a redirect target, choose the most relevant existing content that would serve the user's original intent
- [ ] If no direct replacement exists, redirect to a parent category page or related topic
    
### 4. Code Snippets
- [ ] For code snippets longer than 6 lines:
  - [ ] Create a subfolder named after the document the snippet supports.
  - [ ] Create a `snippets` folder inside that subfolder.
  - [ ] For the code file:
     - [ ] If the snippet is not version-specific, place the code in a file with the appropriate extension (for example, `.cs` for C#) in the `snippets` folder.
     - [ ] If the snippet is version-specific:
        - [ ] Create a subfolder inside the `snippets` folder named for the version (for example, `9.0` for .NET 9 or ASP.NET Core 9).
        - [ ] Place the code in a file with the correct extension inside the version subfolder.
        - [ ] Add a project file (`.csproj`) to the version subfolder targeting the matching .NET version, if necessary to run or build the snippet.
- [ ] Reference snippets using triple-colon syntax:
  - [ ] **Use file-relative paths** for snippets located in the same file as the articles that refer to it.
    ```
    :::code language="csharp" source="../snippets/my-doc/Program.cs":::
    ```
  - [ ] **Use repository root-relative paths** for shared snippets:
    ```
    :::code language="csharp" source="~/tutorials/min-web-api/samples/9.x/todoGroup/TodoDb.cs":::
    ```
- [ ] For longer snippets, highlight specific lines:
  ```
  :::code language="csharp" source="~/path/to/file.cs" range="5-10" highlight="2-3":::
  ```
- [ ] Use the latest, non-preview C# coding patterns in non-preview code examples
- [ ] Use the latest preview C# coding patterns in preview code examples
- [ ] Use the following language code and indentation standards for markdown code blocks or the `language` attribute of code snippets:

  Content of the snippet | Language code | Indentation in spaces
  :--------------------: | :-----------: | :-------------------:
  C#                     | csharp        | 4
  HTML                   | html          | 4
  CSS                    | css           | 4
  JavaScript             | javascript    | 2 spaces (use 4 spaces for line continuation)
  XML                    | xml           | 2
  JSON                   | json          | 2
  Console                | console       | 2
  Text                   | -             | 2
- [ ] Triple-Colon Syntax Requirements:
  - [ ] NEVER use [!code-csharp[]] syntax - this is incorrect and will cause build errors
  - [ ] ALWAYS use triple-colon syntax: :::code language="csharp" source="path" id="snippet_name" highlight="lines":::
  - [ ] NEVER use `name="snippet_name"` attribute - this is unsupported and causes build errors
  - [ ] ALWAYS use `id="snippet_name"` to reference named snippets
  - [ ] Use `highlight=` when needed and make sure the line numbers are relative to the snippet content, not absolute file line numbers.
  - [ ] Example of correct  triple colon syntax with example highlight line number:
    ```
    :::code language="csharp" source="~/path/to/file.cs" id="snippet_policy" highlight="3-5,9":::
    ```
- [ ] Code Snippet Folder Structure Requirements:
  - [ ] For code snippets longer than 6 lines, create proper folder structure: article-name/snippets/version/filename.cs (e.g., cookie/snippets/6.0/Program.cs)
  - [ ] Create version-specific subfolders: 3.x, 6.0, 8.0, 9.0, etc.
  - [ ] Use file-relative paths for snippets in same article folder
  - [ ] Use repository root-relative paths (~/) for shared snippets
- [ ] Code Snippet Markers in .cs Files - CRITICAL:
  - [ ] NEVER use #region snippet_name and #endregion syntax in .cs files
  - [ ] ALWAYS use // <snippet_name> and // </snippet_name> format (all lowercase)
  - [ ] Examples of correct .cs file snippet markers:
    ```csharp
    // <snippet_policy>
    var cookiePolicyOptions = new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.Strict,
    };
    app.UseCookiePolicy(cookiePolicyOptions);
    // </snippet_policy>
    ```
  - [ ] INCORRECT format to avoid:
    ```csharp
    #region snippet_policy
    // code here
    #endregion
    ```
- [ ] Code Comments and Localization:
  - [ ] NEVER add explanatory code comments like `// Configure cookie policy options` in .cs snippet files
  - [ ] NEVER add comments like `// Add Cookie Policy Middleware` - these prevent proper localization
  - [ ] Rely on markdown prose before/after code snippets for explanations instead of inline comments
  - [ ] Only keep comments that are essential to the code's functionality
- [ ] Common Syntax Errors to Avoid:
  - [ ] Using `range="5-10"` instead of `id="snippet_name"`
  - [ ] Using `name="snippet_name"` instead of `id="snippet_name"`
  - [ ] Mixing old [!code-csharp[]] syntax with new triple-colon syntax
  - [ ] Using absolute line numbers in highlight="" instead of relative to snippet
  - [ ] Using #region/#endregion in .cs files instead of // <snippet_name> format
- [ ] Version-Specific Considerations:
  - [ ] Create separate snippet files for different .NET versions (3.x, 6.0, 8.0, 9.0+)
  - [ ] Ensure examples use appropriate syntax for the target version
  - [ ] Reference the correct version-specific snippet file in markdown

### 5. ASP.NET Core Specific Guidelines
- [ ] Use the latest supported version for examples unless otherwise specified
- [ ] Title and section header casing is sentence case (capitalize the first word and any proper nouns)
- [ ] For parts of a title or section header that normally use code style in article text (backticks around the content), also use code style in the title or section header (example H1 header: "# Modify the `Program.cs` file")
- [ ] Use code style for any words that shouldn't be localized
- [ ] For bullet lists, use an asterisk as the bullet marker
- [ ] Bullet lists should have two or more entries at the same level in the list. If there is only one item under a bullet, remove its bullet marker and roll that item into its parent bullet.
- [ ] Lead with Microsoft-recommended approaches
- [ ] Include differences between Minimal API and controller-based approaches when relevant
- [ ] For middleware content and examples, use the middleware class approach

### 6. Content Writing Guidelines
- [ ] Introductory paragraph:
  - [ ] When drafting the first paragraph of any new article, or when significantly updating an existing article:
  - [ ] Explain why and when the topic matters in practical ASP.NET Core development scenarios.
  - [ ] Give a concise summary of what the article covers or enables, so readers know what to expect.
  - [ ] When significantly updating, revise the introductory paragraph to match the new scope and content.

### 7. PR Description Requirements
- [ ] ALWAYS include "Fixes #[issue-number]" in the PR description, at the first line of the description to link back to the original issue
- [ ] Include a clear summary of changes made
- [ ] List all files that were modified with brief descriptions

