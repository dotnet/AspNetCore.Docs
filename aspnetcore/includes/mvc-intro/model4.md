The following table details the ASP.NET Core code generator parameters:

| Parameter               | Description|
| ----------------- | ------------ |
| -m  | The name of the model. |
| -dc  | The data context. |
| -udl | Use the default layout. |
| --relativeFolderPath | The relative output folder path to create the views. |
| --useDefaultLayout | The default layout should be used for the views. |
| --referenceScriptLibraries | Adds `_ValidationScriptsPartial` to Edit and Create pages |

Use the `h` switch to get help on the `aspnet-codegenerator controller` command:

```console
dotnet aspnet-codegenerator controller -h
```