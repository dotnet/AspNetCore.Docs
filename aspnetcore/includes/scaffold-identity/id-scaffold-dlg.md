Run the Identity scaffolder:

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add New Scaffolded Item** dialog, select **Identity**. Select **Identity** in the center pane. Select the **Add** button.
* In the **Add Identity** dialog, select the options you want.
  * If you have an existing, customized layout page for Identity (`_Layout.cshtml`), select your existing layout page to avoid overwriting your layout with incorrect markup by the scaffolder. For example, select either:
    * `Pages/Shared/_Layout.cshtml` for Razor Pages or Blazor Server projects with existing Razor Pages infrastructure.
    * `Views/Shared/_Layout.cshtml` for MVC projects or Blazor Server projects with existing MVC infrastructure.
  * For the data context (**DbContext class**):
    * Select your data context class. You must select at least one file to add your data context.
    * To create a data context and possibly create a new user class for Identity, select the **+** button. Accept the default value or specify a class (for example, `Contoso.Data.ApplicationDbContext` for a company named "Contoso"). To create a new user class, select the **+** button for **User class** and specify the class (for example, `ContosoUser` for a company named "Contoso").
  * Select the **Add** button to run the scaffolder.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET Core scaffolder, install it now:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

Add required NuGet package references to the project file (`.csproj`). Run the following commands in the project directory:

```dotnetcli
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Run the following command to list the Identity scaffolder options:

```dotnetcli
dotnet aspnet-codegenerator identity -h
```

[!INCLUDE[](~/includes/scaffoldTFM.md)]

In the project folder, run the Identity scaffolder with the options you want. For example, to setup identity with the default UI and the minimum number of files, run the following command:

```dotnetcli
dotnet aspnet-codegenerator identity --useDefaultUI
```

---
