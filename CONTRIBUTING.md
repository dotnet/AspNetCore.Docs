Contributing
============

The document covers the basic process for adding or updating content to the [ASP.NET Core documentation site](https://docs.asp.net). See the [ASP.NET Core contributing guide](https://github.com/aspnet/Home/blob/dev/CONTRIBUTING.md) for information on contributing to ASP.NET Core source.

## Contributing process

Small changes to one *.MD* file can be made in the browser by tapping the **Edit on GitHub** link in the upper right corner of the browser window. For new articles and changes involving more than one file:

**1:** Open an issue describing the article you wish to write or update. Get approval before you invest too much time.
**2:** Fork the [aspnet/docs](https://github.com/aspnet/Docs/) repo and create a branch for your article.
**4:** Write or update your article using [DocFX](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool) in [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/). Images go in the *<article-name>/_static* folder. Code goest in the *<article-name>/samples* folder. It's often helful to review an exiting article to use as an example.
**5:** Submit a Pull Request from your branch to `aspnet/docs/master`.
**6:** Respond to PR feedback.


## Building the docs

**Note:** Currently DocFX requires the .NET Framework on Windows or Mono (for Linux or macOS). We hope to port it to .NET Core in the future. 

Build and preview the resulting site with [DocFX](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool). Navigate to the aspnet folder (which contains the *docfx.json* file) and enter the following in a command prompt:

```
docfx -t default --serve```
	
The command above starts the preview on localhost:8080 where you can view the updated content in your browser.

**Note:** the local preview currently doesn't contain any themes or render table correctly; the view will differ slighlty from the published site.
