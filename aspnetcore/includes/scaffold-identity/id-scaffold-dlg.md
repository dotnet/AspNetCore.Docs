Run the Identity scaffolder:

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add Scaffold** dialog, select **Identity** > **ADD**.
* In the **ADD Identity** dialog, select the options you want.
  * Select your existing layout page, or your layout file will be overwritten with incorrect markup. For example
  `~/Pages/Shared/_Layout.cshtml` for Razor Pages
  `~/Views/Shared/_Layout.cshtml` for MVC projects
  * Select the **+** button to create a new **Data context class**.
* Select **ADD**.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET Core scaffolder, install it now:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

Add required NuGet package references to the project (\*.csproj) file. Run the following command in the project directory:

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
