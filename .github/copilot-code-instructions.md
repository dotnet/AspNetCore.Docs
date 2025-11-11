---
author: tdykstra
ms.author: wpickett
ms.date: 09-22-2025
---

# Copilot Code Instructions for `dotnet/AspNetCore.Docs`

## Introduction
This document contains code-specific instructions for GitHub Copilot when assisting with the `dotnet/AspNetCore.Docs` repository. For general instructions and documentation guidelines, please refer to the [copilot-instructions.md](./copilot-instructions.md) file.

## Code-Related Guidelines

### 1. Code Snippets
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
  - [ ] Mixing old [!code-csharp[]] syntax with new triple-colon syntax.  Use triple-colon syntax.
  - [ ] Using absolute line numbers in highlight="" instead of relative to snippet
  - [ ] Using #region/#endregion in .cs files instead of // <snippet_name> format
- [ ] Version-Specific Considerations:
  - [ ] Create separate snippet files for different .NET versions (3.x, 6.0, 8.0, 9.0+)
  - [ ] Ensure examples use appropriate syntax for the target version
  - [ ] Reference the correct version-specific snippet file in markdown

### 2. Code Build and Testing Requirements
- [ ] Ensure all code samples build successfully against the targeted .NET version
- [ ] Include necessary using statements in code samples
- [ ] When you're assigned an issue involving code changes, after you've completed your work and the workflows (status checks) have run, ensure there are no build warnings under the OpenPublishing.Build status check
- [ ] Use `#nullable enable` in C# code samples that use nullable reference types
- [ ] For Minimal API examples, use the latest patterns including group-based routing where appropriate
- [ ] For code samples targeting preview versions:
  - [ ] Clearly indicate in comments or surrounding documentation that the code targets a preview version
  - [ ] Provide fallback examples for current stable versions when possible

### 3. ASP.NET Core Code-Specific Guidelines
- [ ] Use the latest supported version for examples unless otherwise specified
- [ ] Include differences between Minimal API and controller-based approaches when relevant
- [ ] For middleware content and examples, use the middleware class approach
- [ ] Code examples should be concise and focused on demonstrating a specific concept
- [ ] Include error handling in code examples where appropriate
- [ ] Ensure all code is accessible and follows best practices for ASP.NET Core applications