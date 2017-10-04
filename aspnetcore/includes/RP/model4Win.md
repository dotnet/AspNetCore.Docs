<a name="scaffold"></a>
### Scaffold the Movie model

* Open a command window in the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).
* Run the following command:

  ```console
  dotnet aspnet-codegenerator razorpage -m Movie -dc MovieContext -udl -outDir Pages\Movies --referenceScriptLibraries
  ```

Build the project and you get 7 errors of the form:

Error	CS1061	'MovieContext' does not contain a definition for 'Movie' and no extension method 'Movie' accepting a first argument of type 'MovieContext' could be found (are you missing a using directive or an assembly reference?)	RazorPagesMovie	

Globally change `_context.Movie` to `_context.Movies` (that is, add an "s" to `Movie`). 7 occurrences are found and updated. We hope to fix [this bug](https://github.com/aspnet/Scaffolding/issues/633) in the next release.

If you get the error:
  ```
  The process cannot access the file 
 'RazorPagesMovie/bin/Debug/netcoreapp2.0/RazorPagesMovie.dll' 
  because it is being used by another process.
  ```

Exit Visual Studio and run the command again.
