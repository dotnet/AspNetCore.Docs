:::moniker range=">= aspnetcore-6.0"

Run the Identity scaffolder:

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add New Scaffolded Item** dialog, select **Identity**. Select **Identity** in the center pane. Select the **Add** button.
* In the **Add Identity** dialog, select the options you want.
  * If you have an existing, customized layout page for Identity, select your existing layout page to avoid overwriting your layout with incorrect markup by the scaffolder. When an existing `_Layout.cshtml` file is selected, it is **not** overwritten. For example:
    * `~/Pages/Shared/_Layout.cshtml` for Razor Pages or Blazor Server projects with existing Razor Pages infrastructure
    * `~/Views/Shared/_Layout.cshtml` for MVC projects or Blazor Server projects with existing MVC infrastructure
  * Data context:
    * Select your data context class. You must select at least one file to add your data context.
    * To create a new user context and possibly create a custom user class for Identity, select the **+** button to create a new **Data context class**. Accept the default value or specify a class (for example, `MyApplication.Data.ApplicationDbContext`). If you're creating a new user context, you aren't required to select a file to override.
  * Select the **Add** button.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET Core scaffolder, install it now:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

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

In the project folder, run the Identity scaffolder with the options you want. For example, to setup identity with the default UI and the minimum number of files, run the following command. Use the correct fully qualified name for your DB context:

```dotnetcli
dotnet aspnet-codegenerator identity -dc MyApplication.Data.ApplicationDbContext --files "Account.Register;Account.Login"
```

PowerShell uses semicolon as a command separator. When using PowerShell, escape the semi-colons in the file list or put the file list in double quotes. For example:

```dotnetcli
dotnet aspnet-codegenerator identity -dc MyApplication.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"
```

If you run the Identity scaffolder without specifying the `--files` flag or the `--useDefaultUI` flag, all the available Identity UI pages will be created in your project.

---

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Run the Identity scaffolder:

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add Scaffold** dialog, select **Identity** > **Add**.
* In the **Add Identity** dialog, select the options you want:
  * If you have an existing, customized layout page for Identity, select your existing layout page to avoid overwriting your layout with incorrect markup by the scaffolder. When an existing `_Layout.cshtml` file is selected, it is **not** overwritten. For example:
    * `~/Pages/Shared/_Layout.cshtml` for Razor Pages or Blazor Server projects with existing Razor Pages infrastructure
    * `~/Views/Shared/_Layout.cshtml` for MVC projects or Blazor Server projects with existing MVC infrastructure
  * Data context:
    * Select your data context class. You must select at least one file to add your data context.
    * To create a new user context and possibly create a custom user class for Identity, select the **+** button to create a new **Data context class**. Accept the default value or specify a class (for example, `MyApplication.Data.ApplicationDbContext`). If you're creating a new user context, you aren't required to select a file to override.
  * Select the **Add** button.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET Core scaffolder, install it now:

```dotnetcli
dotnet tool install -g dotnet-aspnet-codegenerator
```

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

In the project folder, run the Identity scaffolder with the options you want. For example, to setup identity with the default UI and the minimum number of files, run the following command. Use the correct fully qualified name for your DB context:

```dotnetcli
dotnet aspnet-codegenerator identity -dc MyApplication.Data.ApplicationDbContext --files "Account.Register;Account.Login"
```

PowerShell uses semicolon as a command separator. When using PowerShell, escape the semi-colons in the file list or put the file list in double quotes. For example:

```dotnetcli
dotnet aspnet-codegenerator identity -dc MyApplication.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"
```

If you run the Identity scaffolder without specifying the `--files` flag or the `--useDefaultUI` flag, all the available Identity UI pages will be created in your project.

---

:::moniker-end
