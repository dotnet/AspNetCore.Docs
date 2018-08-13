Run the Identity scaffolder:

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on the project > **Add** > **New Scaffolded Item**.
* From the left pane of the **Add Scaffold** dialog, select **Identity** > **ADD**.
* In the **ADD Identity** dialog, select the options you want.
  * Select your existing layout page, or your layout file will be overwritten with incorrect markup. When an existing _Layout.cshtml file is selected, it is **not** overwritten.

 For example
  `~/Pages/Shared/_Layout.cshtml` for Razor Pages
  `~/Views/Shared/_Layout.cshtml` for MVC projects
* To use your existing data context, select at least one file to override. You must select at least one file to add your data context.
  * Select your data context class.
  * Select **ADD**.
* To create a new user context and possibly create a custom user class for Identity:
  * Select the **+** button to create a new **Data context class**.
  * Select **ADD**.

Note: If you're creating a new user context, you don't have to select a file to override.

# [.NET Core CLI](#tab/netcore-cli)

If you have not previously installed the ASP.NET scaffolder, install it now:

```cli
dotnet tool install -g dotnet-aspnet-codegenerator
```

Add a package reference to [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/) to the project (\*.csproj) file. Run the following command in the project directory:

```cli
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
```

Run the following command to list the Identity scaffolder options:

```cli
dotnet aspnet-codegenerator identity -h
```

In the project folder, run the Identity scaffolder with the options you want. For example, to setup identity with the default UI and the minimum number of files, run the following command. Use the correct fully qualified name for your DB context:

```cli
dotnet aspnet-codegenerator identity -dc MyWeb.Data.ApplicationDbContext --files Account.Register
```

Powershell uses semicolon as a command separator. When using powershell, escape the semi-colons in the file list or put the file list in double quotes. For example:

```cli
dotnet aspnet-codegenerator identity -dc MyWeb.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"
```
-------------
