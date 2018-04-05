The following table details the ASP.NET Core code generators` parameters:

| Parameter               | Description|
| ----------------- | ------------ |
| -m  | The name of the model. |
| -dc  | The data context. |
| -udl | Use the default layout. |
| -outDir | The relative output folder path to create the views. |
| --referenceScriptLibraries | Adds `_ValidationScriptsPartial` to Edit and Create pages |

Use the `h` switch to get help on the `aspnet-codegenerator razorpage` command:

```console
dotnet aspnet-codegenerator razorpage -h
```
<a name="test"></a>
### Test the app

* Run the app and append `/Movies` to the URL in the browser (`http://localhost:port/movies`).
* Test the **Create** link.

 ![Create page](../../tutorials/razor-pages/model/_static/conan.png)

<a name="scaffold"></a>

* Test the **Edit**, **Details**, and **Delete** links.

If you get the error similar to the following, verify you have run migrations and updated the database:

```
An unhandled exception occurred while processing the request.
'no such table: Movie'.
```
