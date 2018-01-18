<a name="scaffold"></a>
### Scaffold the Movie model

* Run the following command from the command line (in the project directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).

  ```console
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages/Movies --referenceScriptLibraries
  ```

If you get the error:
  ```
No executable found matching command "dotnet-aspnet-codegenerator"
  ```

Open a command window in the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).
