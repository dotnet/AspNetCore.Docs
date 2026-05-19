Run the Identity scaffolder with the following procedures.

# [Visual Studio](#tab/visual-studio)

1. In **Solution Explorer**, right-click the project, and select **Add** > **New Scaffolded Item**.

1. In the left pane of the **Add New Scaffolded Item** dialog, select **Identity**.

1. In the center pane, select **Identity**, and then select **Add**.

1. In the **Add Identity** dialog, select your desired options:

   1. If you have an existing customized layout page for Identity (*_Layout.cshtml*), select the existing page to avoid overwriting your layout with incorrect markup by the scaffolder. For example, select either:

      - *Pages/Shared/_Layout.cshtml* for Razor Pages or Blazor Server projects with existing Razor Pages infrastructure.
      - *Views/Shared/_Layout.cshtml* for MVC projects or Blazor Server projects with existing MVC infrastructure.

   1. Select the plus icon (**+**) and add the database context class, **DbContext class**. You must select at least one file to add your data context.

      - To create a data context, select the plus icon (**+**). Accept the default value or specify a new class for Identity.
      
      - To create a new user class, select the plus icon (**+**) for **User class** and specify the class (for example, `ContosoUser` for a company named "Contoso").

   1. Select **Add** to run the scaffolder.

# [.NET CLI](#tab/net-cli)

1. If the ASP.NET Core scaffolder isn't already installed, run the following command to install it now:

   ```dotnetcli
   dotnet tool install -g dotnet-aspnet-codegenerator
   ```

   [!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

1. Add required NuGet package references to the project file (_.csproj_). Run the following commands in the project directory:

   ```dotnetcli
   dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
   dotnet add package Microsoft.AspNetCore.Identity.UI
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```

1. Run the following command to list the Identity scaffolder options:

   ```dotnetcli
   dotnet aspnet-codegenerator identity -h
   ```

   [!INCLUDE[](~/includes/scaffoldTFM.md)]

1. In the project folder, run the Identity scaffolder with the options you want.

   For example, to set up identity with the default UI and the minimum number of files, run the following command:

   ```dotnetcli
   dotnet aspnet-codegenerator identity --useDefaultUI
   ```

---
