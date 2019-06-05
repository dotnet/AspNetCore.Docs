# Include content from referenced project and packages in your application

There are many situations in which when creating a Razor Class Library, for the library to work properly, some companion static assets need to be referenced by the consuming application using the library. ASP.NET Core allows creating Razor Class Libraries that include static assets that are readily available for consuming applications.

## Create a razor class library with content
To include companion assets as part of a razor class library, simply create a wwwroot folder in the class library and include any required file within that folder.
When packing a razor class library, all companion assets within the wwwroot folder are included in the package automatically and are made available to applications referencing the package.

## Consume content from a referenced razor class library
The files you include under the wwwroot folder of the razor class library will be exposed on the consuming app under the prefix `_content/<<libraryname>>/`. The consuming app can then reference those assets within script, style, img, etc tags.

## Multi-project development flow
When the application runs, the assets stay in their original folders and any change within the class library wwwroot folder is reflected on the running application without having to rebuild it.
At build time, we produce a manifest with all the available static web assets locations that we read at runtime to allow the application to consume the assets from referenced projects and packages.

## Publish
When the application gets published, the companion assets from all referenced projects and packages get copied into the wwwroot folder of the published application under `_content/<<libraryname>>/`.
