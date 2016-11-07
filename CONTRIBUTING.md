# Contributing to the ASP.NET Core documentation

The document covers the process for contributing to the articles and code samples that are hosted on the [ASP.NET Core documentation site](https://docs.asp.net). Contributions may be as simple as typo corrections or as complex as new articles.

## How to make a simple correction or suggestion

Articles are stored in the repository as Markdown files. Simple changes to the content of a Markdown file can be made in the browser by tapping the **Edit** link in the upper right corner of the browser window. (In narrow browser windows you might need to expand the **options** bar to see the **Edit** link.) Follow the directions to create a pull request (PR). The ASP.NET documentation team will review the PR and accept it or suggest changes.

## How to make a more complex submission

You'll need a basic understanding of [Git and GitHub.com](https://guides.github.com/activities/hello-world/).

* Open an [issue](https://github.com/aspnet/Docs/issues/new) describing what you want to do, such as change an existing article or create a new one. Wait for approval from the ASP.NET documentation team before you invest much time. 
* Fork the [aspnet/Docs](https://github.com/aspnet/Docs/) repo and create a branch for your changes.
* Submit a pull request (PR) to master with your changes.
* Respond to PR feedback.

## Markdown syntax

Articles are written in [DocFx-flavored Markdown](http://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html), which is a superset of [GitHub-flavored Markdown (GFM)](https://guides.github.com/features/mastering-markdown/). For examples of DFM syntax for UI features commonly used in the ASP.NET documentation, see [Metadata and Markdown Template](https://github.com/dotnet/docs/blob/master/styleguide/template.md) in the .NET Core repo style guide. 

## Folder structure conventions

For each Markdown file there may be a folder for images and a folder for sample code. For example, if the article is [fundamentals/configuration.md](https://github.com/aspnet/Docs/blob/master/aspnetcore/fundamentals/configuration.md), the images are in [fundamentals/configuration/\_static](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/configuration/_static) and the sample application project files are in [fundamentals/configuration/sample](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/configuration/sample).  An image in the *fundamentals/configuration.md* file is rendered by the following Markdown.

````none
![alt-text](configuration/_static/imagename.png)
````

## Code snippets

Articles frequently contain code snippets to illustrate points. DFM lets you copy code into the Markdown file or refer to a separate code file. We prefer to use separate code files whenever possible, to minimize the chance of errors in the code. The code files should be stored in the repo using the folder structure described above for sample projects. 

Here are some examples of [DFM code snippet syntax](http://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html#code-snippet) that would be used in a *configuration.md* file.

To render an entire code file as a snippet:

````none
[!code-csharp[Main](configuration/sample/Program.cs)]
````

To render a portion of a file as a snippet by using line numbers:

````none
[!code-csharp[Main](configuration/sample/Program.cs?range=1-10,20,30,40-50]
[!code-html[Main](configuration/sample/Views/Home/Index.cshtml?range=1-10,20,30,40-50]
[!code-javascript[Main](configuration/sample/Project.json?range=1-10,20,30,40-50]
````

For C# snippets, you can reference a [C# region](https://msdn.microsoft.com/en-us/library/9a1ybwek.aspx). Whenever possible, use regions rather than line numbers, because line numbers in a code file tend to change and get out of sync with line number references in Markdown. C# regions can be nested, and if you reference the outer region, the inner `#region` and `#endregion` directives are not rendered in a snippet. 

To render a C# region named "snippet_Example":

````none
[!code-csharp[Main](configuration/sample/Program.cs?name=snippet_Example)]
````

To highlight selected lines in a rendered snippet (usually renders as yellow background color):

````none
[!code-csharp[Main](configuration/sample/Program.cs?name=snippet_Example&highlight=1-3,10,20-25)]
[!code-csharp[Main](configuration/sample/Program.cs?range=10-20&highlight=1-3]
[!code-html[Main](configuration/sample/Views/Home/Index.cshtml?range=10-20&highlight=1-3]
[!code-javascript[Main](configuration/sample/Project.json?range=10-20&highlight=1-3]
````

## Test your changes with DocFX

Test your changes with the [DocFX command line tool](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool), which creates a locally hosted version of the site. 

DocFX requires the .NET Framework on Windows, or Mono for Linux or macOS. DocFX doesn't render style and site extensions created for docs.microsoft.com.

Follow these steps to build the site locally and view your changes:

* Download and unzip *docfx.zip* from [DocFX releases](https://github.com/dotnet/docfx/releases).
* Add DocFX to your PATH.
* In a command line window, navigate to the *aspnet* folder (which contains the *docfx.json* file) and run the following command:

   ```
   docfx -t default --serve
   ```
	
* In a browser, navigate to `http://localhost:8080`.

## Voice and tone

Our goal is to write documentation that is easily understandable by the widest possible audience. To that end we have established guidelines for writing style that we ask our contributors to follow. For more information, see [Voice and tone guidelines](https://github.com/dotnet/docs/blob/master/styleguide/voice-tone.md) in the .NET Core repo.
