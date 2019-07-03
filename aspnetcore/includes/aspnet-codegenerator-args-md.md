<!-- Options common to Razor Pages and Controller -->
| Option               | Description|
| ----------------- | ------------ |
| --model or -m  | Model class to use. |
| --dataContext or -dc  | The `DbContext` class to use. |
| --bootstrapVersion or -b  | Specifies the bootstrap version. Valid values are `3` or `4`. Default is `4`. If needed and not present, a *wwwroot* directory is created that includes the bootstrap files of the specified version. |
| --referenceScriptLibraries or -scripts |  Reference script libraries in the generated views. Adds `_ValidationScriptsPartial` to Edit and Create pages. |
| --layout or -l | Custom Layout page to use. |
| --useDefaultLayout or -udl | Use the default layout for the views. |
| --force or -f | Overwrite existing files. |
| --relativeFolderPath or -outDir | The relative output folder path from project where the file are generated. If not specified, files are generated in the project folder. |