## Create a Razor class library with static assets

Razor class libraries (RCL) frequently require companion static assets that can be referenced by the consuming app of the RCL. ASP.NET Core allows creating RCLs that include static assets that are available to a consuming app.

To include companion assets as part of a Razor class library, create a *wwwroot* folder in the class library and include any required files in that folder.

When packing a Razor class library, all companion assets in the *wwwroot* folder are included in the package automatically and are made available to apps referencing the package.

### Consume content from a referenced Razor class library

The files included in the *wwwroot* folder of the Razor class library are exposed to the consuming app under the prefix `_content/{LIBRARY NAME}/`. The consuming app references these assets via `<script>`, `<style>`, `<img>`, and other HTML tags.

### Multi-project development flow

When the app runs:

* The assets stay in their original folders.
* Any change within the class library *wwwroot* folder is reflected in the app without rebuilding.

At build time, a manifest is produced with all the static web asset locations. The manifest is read at runtime and allows the app to consume the assets from referenced projects and packages.

### Publish

When the app is published, the companion assets from all referenced projects and packages are copied into the *wwwroot* folder of the published app under `_content/{LIBRARY NAME}/`.
