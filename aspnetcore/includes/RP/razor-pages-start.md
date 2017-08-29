The default template creates **RazorPagesMovie**, **Home**, **About** and **Contact** links and pages. Depending on the size of your browser window, you might need to click the navigation icon to show the links.

![Home or Index page](../../tutorials/razor-pages/razor-pages-start/_static/home2.png)

Test the links. The **RazorPagesMovie** and **Home** links go to the Index page. The **About** and **Contact** links go to the `About` and `Contact` pages, respectively.

## Project files and folders

The following table lists the files and folders in the project. For this tutorial, the *Startup.cs* file is the most important to understand. You don't need to review each link provided below. The links are provided as a reference when you need more information on a file or folder in the project.

| File or folder              | Purpose |
| ----------------- | ------------ | 
| wwwroot | Contains static files. See [Working with static files](xref:fundamentals/static-files). |
| Pages | Folder for [Razor Pages](xref:mvc/razor-pages/index). | 
| *appsettings.json* | [Configuration](xref:fundamentals/configuration) |
| *bower.json* | Client-side package management. See [Bower](xref:client-side/bower).|
| *Program.cs* | [Hosts](xref:fundamentals/hosting) the ASP.NET Core app.|
| *Startup.cs* | Configures services and the request pipeline. See [Startup](xref:fundamentals/startup).|

### The Pages folder

The *_Layout.cshtml* file contains common HTML elements (scripts and stylesheets) and sets the layout for the application. For example, when you click on **RazorPagesMovie**, **Home**, **About** or **Contact**, you see the same elements. The common elements include the navigation menu on the top and the header on the bottom of the window. See [Layout](xref:mvc/views/layout) for more information.

The *_ViewStart.cshtml* sets the Razor Pages `Layout` property to use the *_Layout.cshtml* file. See [Layout](xref:mvc/views/layout) for more information.

The *_ViewImports.cshtml* file contains Razor directives that are imported into each Razor Page. See [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives) for more information.

The *_ValidationScriptsPartial.cshtml* file provides a reference to [jQuery](https://jquery.com/) validation scripts. When we add `Create` and `Edit` pages later in the tutorial, the *_ValidationScriptsPartial.cshtml* file will be used.

The `About`, `Contact` and `Index` pages are basic pages you can use to start an app. The `Error` page is used to display error information.