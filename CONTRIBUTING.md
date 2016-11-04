Contributing
============

The document covers the basic process for contributing to the [ASP.NET Core documentation site](https://docs.asp.net). For information on contributing to ASP.NET Core source, see [ASP.NET Core contributing guide](https://github.com/aspnet/Home/blob/dev/CONTRIBUTING.md) .

## Contributing process

Small changes to one *.md* file can be made in the browser by tapping the **Edit** link in the upper right corner of the browser window (you might need to expand the **options** in small browser windows). For new articles and changes involving more than one file:

* Open an issue describing the article you wish to write or update. Get approval before you invest too much time.
* Fork the [aspnet/docs](https://github.com/aspnet/Docs/) repo and create a branch for your article.
* Write or update your article using [DocFX](http://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html#code-snippet) in [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/). Images go in the *\<article-name>/_static* folder. Code goes in the *\<article-name>/samples* folder. It's often helpful to review an existing article to use as an template (for example, *tutorials\first-web-api.md* and the assets in *tutorials\first-web-api*). See the [style guide](./aspnetcore/contribute/style-guide.md) for more details.
* Submit a pull request (PR) from your branch to `aspnet/docs/master` and respond to PR feedback.

## Build and test your article with DocFX

* Download and unzip *docfx.zip* from [DocFX releases](https://github.com/dotnet/docfx/releases). Add DocFX to your PATH.
* Build and preview your changes with [DocFX command line](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool). Navigate to the aspnet folder (which contains the *docfx.json* file) and enter the following in a command prompt:

   ```
   docfx -t default --serve
   ```
	
   The command above starts the preview on localhost:8080 where you can view the updated content in your browser.

Notes:

* Currently DocFX requires the .NET Framework on Windows or Mono (for Linux or macOS)
* The local preview currently doesn't contain themes or render table correctly; the view will differ slightly from the published site

