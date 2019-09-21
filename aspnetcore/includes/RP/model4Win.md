<a name="scaffold"></a>

### Scaffold the Movie model

* Run the following from the command line (in the project directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files):

  ```dotnetcli
  dotnet restore
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages\Movies --referenceScriptLibraries
  ```

If you get the error:

  ```
  No executable found matching command "dotnet-aspnet-codegenerator"
  ```

The preceding error happens when you are in the wrong directory. Open a command shell to the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files), and then run the preceding command.

If you get the error:

  ```
  The process cannot access the file
 'RazorPagesMovie/bin/Debug/netcoreapp2.0/RazorPagesMovie.dll'
  because it is being used by another process.
  ```

Exit Visual Studio and run the command again.
