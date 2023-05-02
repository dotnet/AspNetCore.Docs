The following table details the ASP.NET Core code generator parameters:

| Parameter               | Description|
| ----------------- | ------------ |
| -m  | The name of the model. |
| -dc  | The data context. |
| --relativeFolderPath | The relative output folder path to create the files. |
| --useDefaultLayout\|-udl | The default layout should be used for the views. |
| --referenceScriptLibraries | Adds `_ValidationScriptsPartial` to Edit and Create pages. |
| --databaseProvider sqlite | Specify `DbContext` should use SQLite instead of SQL Server. |

Use the `h` switch to get help on the `aspnet-codegenerator controller` command:

```dotnetcli
dotnet aspnet-codegenerator controller -h
```

For more information, see [dotnet aspnet-codegenerator](xref:fundamentals/tools/dotnet-aspnet-codegenerator)
