---
title: ASP.NET Docs Style Guide
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: bd1505c4-d46e-4df2-b6ce-5fe8f5991fe8
ms.prod: aspnet-core
﻿uid: contribute/style-guide
---
# ASP.NET Core documentation style guide

<a name=style-guide></a>

By [Rick Anderson](https://twitter.com/RickAndMSFT)

# Style guide checklist

- Spell and grammar check the document
- Use short and simple sentences, they are easier to understand and more easily translated. Split up long sentences if you can do it without being too redundant or sounding unnatural
- Use everyday words. Use natural language, be less formal but not less technical.
- Use a screenshot when it can save words or simplify the section
- Add code comments to help explain a step, especially in code snippets you import
- Don't copy/paste code into the *.md* file (except for small code segments). Use code snippets (see next section)
- Use a casual and friendly voice, like you are talking to another person
- Remove unnecessary words. Reread your topic out loud and look for words you can remove. Most people are surprised at how many extra words they use 
- Use "sign-in", not "log-in"
- Include the words "following" or "as follows" in sentences that precede a list or code snippet
- Minimize Note, Tip and Warning boxes
- Make the document easy to scan. Put the most important things first. 
- Use sentence casing for titles. Don't capitalize words in a title except for the first word and proper nouns
- Prefer app over application

## Images

Images go in the *\<article-name>/_static* folder. Code goes in the *\<article-name>/samples* folder. For example, this document is named *style-guide.md*, so images go in  *style-guide/_static* folder and code goes in the *style-guide/sample* folder.

The following markup includes the *asp-net.png* image:

`![image](style-guide/_static/asp-net.png)`

The code above renders as:

![image](style-guide/_static/asp-net.png)

<a name="Code_snippets"></a> 

## Code snippets

We strongly prefer referencing code files over copying and pasting of code. Code goes in the *\<article-name>/samples* folder. For example, this document is named *style-guide.md** and the code snippets are in the *style-guide/sample* folder.

Use the following syntax to include an entire file:

`[!code[Main](style-guide/sample/Program1.cs)]`

Which renders the following:

[!code[Main](style-guide/sample/Program1.cs)]

C# files should use `#region snippet` to reference snippets:

[!code[Main](style-guide/sample/Program2.cs?highlight=5,10)]

Use the following syntax to import `snippet1`:

`[!code[Main](style-guide/sample/Program2.cs?name=snippet1)]`

which renders:

[!code[Main](style-guide/sample/Program2.cs?name=snippet1)]

Use the following syntax to highlight lines:

`[!code[Main](style-guide/sample/Program2.cs?name=snippet1&highlight=3)]`

which renders:

[!code[Main](style-guide/sample/Program2.cs?name=snippet1&highlight=3)]

Snippets can only be referenced in c# files. Use `range`` in other file types:

`[!code[Main](style-guide/sample/About.cshtml?range=1-4,7&highlight=1-3,5)]`

Which renders

[!code[Main](style-guide/sample/About.cshtml?range=1-4,7&highlight=1-3,5)]

C# snippets can be nested, and the `#region` directive is not rendered. See the *style-guide/sample/startup.cs* for a sample.

See [DocFX code snippet](http://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html#code-snippet) for more information.


