<a name="codegenerator"></a>
The following table details the ASP.NET Core code generator parameters:

| Parameter               | Description|
| ----------------- | ------------ |
| -m  | The name of the model. |
| -dc  | The `DbContext` class to use. |
| -udl | Use the default layout. |
| -outDir | The relative output folder path to create the views. |
| --referenceScriptLibraries | Adds `_ValidationScriptsPartial` to Edit and Create pages |

Use the `h` switch to get help on the `aspnet-codegenerator razorpage` command:

```dotnetcli
dotnet aspnet-codegenerator razorpage -h
```

For more information, see [dotnet aspnet-codegenerator](xref:fundamentals/tools/dotnet-aspnet-codegenerator).
