The default template creates **RazorPagesMovie**, **Home**, **About** and **Contact** links and pages. Depending on the size of your browser window, you might need to click the navigation icon to show the links.

![Home or Index page](~/tutorials/razor-pages/razor-pages-start/_static/home2.png)

Test the links. The **RazorPagesMovie** and **Home** links go to the Index page. The **About** and **Contact** links go to the `About` and `Contact` pages, respectively.

## Project files and folders

The following table lists the files and folders in the project. For this tutorial, the *Startup.cs* file is the most important to understand. You don't need to review each link provided below. The links are provided as a reference when you need more information on a file or folder in the project.

| File or folder | Purpose |
| -------------- | ------- |
| *wwwroot* | Contains static assets. See [Static files](xref:fundamentals/static-files). |
| *Pages* | Folder for [Razor Pages](xref:razor-pages/index). |
| *appsettings.json* | [Configuration](xref:fundamentals/configuration/index) |
| *Program.cs* | Configures the [host](xref:fundamentals/index#host) of the ASP.NET Core app. |
| *Startup.cs* | Configures services and the request pipeline. See [Startup](xref:fundamentals/startup). |

### The Pages/Shared folder

The *_Layout.cshtml* file contains common HTML elements (script and stylesheet links) and sets the layout for the app. For example when you select **RazorPagesMovie**, **Home**, **About** or **Contact**, a common set of elements appears in the webpage. The common elements include the navigation menu at the top and the header at the bottom of the window. For more information, see [Layout](xref:mvc/views/layout).

The *_ValidationScriptsPartial.cshtml* file provides a reference to [jQuery](https://jquery.com/) validation scripts. When the `Create` and `Edit` pages are added later in the tutorial, the *_ValidationScriptsPartial.cshtml* file is used.

The *_CookieConsentPartial.cshtml* file provides a navigation bar and content to summarize the privacy and cookie use policy. For more information on the GDPR assets included in the project, see [EU General Data Protection Regulation (GDPR) support in ASP.NET Core)](xref:security/gdpr).

### The Pages folder

The *_ViewStart.cshtml* sets the Razor Pages `Layout` property to use the *_Layout.cshtml* file. See [Layout](xref:mvc/views/layout) for more information.

The *_ViewImports.cshtml* file contains Razor directives that are imported into each Razor Page. See [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives) for more information.

The `About`, `Contact` and `Index` pages are basic pages you can use to start an app. The `Error` page is used to display error information.
