---
title: Host and deploy ASP.NET Core standalone Blazor WebAssembly with GitHub Pages
author: guardrex
description: Learn how to host and deploy standalone Blazor WebAssembly using GitHub Pages.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 03/31/2025
uid: blazor/host-and-deploy/webassembly/github-pages
---
# Host and deploy ASP.NET Core standalone Blazor WebAssembly with GitHub Pages

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy standalone Blazor WebAssembly using [GitHub Pages](https://pages.github.com/).

The following guidance for GitHub Pages deployments of Blazor WebAssembly apps demonstrates concepts with a live tool deployed to GitHub Pages. The tool is used by the ASP.NET Core documentation authors to create cross-reference (XREF) links to API documentation for article markdown:

* [`BlazorWebAssemblyXrefGenerator` sample app (`blazor-samples/BlazorWebAssemblyXrefGenerator`)](https://github.com/dotnet/blazor-samples/tree/main/BlazorWebAssemblyXrefGenerator)
* [Live Xref Generator website](https://dotnet.github.io/blazor-samples/)

## GitHub Pages settings

* **Actions** > **General**
  * **Actions permissions**
    * **Allow enterprise actions, and select non-enterprise, actions and reusable workflows** > Enabled (selected)
    * **Allow actions created by GitHub** > Enabled (selected)
    * **Allow actions and reusable workflows** > `stevesandersonms/ghaction-rewrite-base-href@{SHA HASH},`&dagger;
  * **Workflow permissions** > **Read repository contents and packages permissions**
* **Pages** > **Build and deployment**
  * **Source** > **GitHub Actions**
  * Selected workflow: **Static HTML** and base your static deployment Action script on the [Xref Generator `static.yml` file](https://github.com/dotnet/blazor-samples/blob/main/.github/workflows/static.yml) for the Xref Generator tool. The configuration in the file is described in the next section.
  * **Custom domain**: Set if you intend to use a custom domain, which isn't covered by this guidance. For more information, see [Configuring a custom domain for your GitHub Pages site](https://docs.github.com/pages/configuring-a-custom-domain-for-your-github-pages-site).
  * **Enforce HTTPS** > Enabled (selected)
 
&dagger;The SHA hash (`{SHA HASH}` placeholder) represents the SHA hash for the latest `stevesandersonms/ghaction-rewrite-base-href` GitHub Action release version. By pinning to a specific version, there's less risk that a compromised latest release using a version moniker, such as `v1`, can jeopardize the deployment. Periodically, update the SHA to the latest release for the latest features and bug fixes.

To obtain the SHA hash:

1. Navigate to the [`SteveSandersonMS/ghaction-rewrite-base-href` Action GitHub repository](https://github.com/SteveSandersonMS/ghaction-rewrite-base-href).
1. Select the release on the right-side of the page under **Releases**.
1. Locate and select the short SHA hash (for example, `5b54862`).
1. Either:
   * Take the full SHA from the URL in the browser's address bar.
   * Select the copy button on the right side of page ![Copy button](~/blazor/host-and-deploy/index/copy-button.svg) to put the SHA on your clipboard.

For more information, see [Using pre-written building blocks in your workflow: Using SHAs (GitHub documentation)](https://docs.github.com/actions/writing-workflows/choosing-what-your-workflow-does/using-pre-written-building-blocks-in-your-workflow#using-shas).

## Static deployment script configuration

[Xref Generator `static.yml` file](https://github.com/dotnet/blazor-samples/blob/main/.github/workflows/static.yml)

Configure the following entries in the script for your deployment:

* Publish directory (`PUBLISH_DIR`): Use the path to the repository's folder where the Blazor WebAssembly app is published. The app is compiled for a specific .NET version, and the path segment for the version must match. Example: `BlazorWebAssemblyXrefGenerator/bin/Release/net9.0/publish/wwwroot` is the path for an app that adopts the `net9.0` [Target Framework Moniker (TFM)](/dotnet/standard/frameworks) for the .NET 9 SDK.
* Push path (`on:push:paths`): Set the push path to match the app's repo folder with a `**` wildcard. Example: `BlazorWebAssemblyXrefGenerator/**`.
* .NET SDK version (`dotnet-version` via the [`actions/setup-dotnet` Action](https://github.com/actions/setup-dotnet)): Currently, there's no way to set the version to "latest" (see [Allow specifying 'latest' as dotnet-version (`actions/setup-dotnet` #497)](https://github.com/actions/setup-dotnet/issues/497) to up-vote the feature request). Set the SDK version at least as high as the app's framework version.
* Publish path (`dotnet publish` command): Set the publish folder path to the app's repo folder. Example: `dotnet publish BlazorWebAssemblyXrefGenerator -c Release`.
* Base HREF (`base_href` for the [`SteveSandersonMS/ghaction-rewrite-base-href` Action](https://github.com/SteveSandersonMS/ghaction-rewrite-base-href)): Set the SHA hash for the latest version of the Action (see the guidance in the [*GitHub Pages settings*](#github-pages-settings) section for instructions). Set the base href for the app to the repository's name. Example: The Blazor sample's repository owner is `dotnet`. The Blazor sample's repository's name is `blazor-samples`. When the Xref Generator tool is deployed to GitHub Pages, its web address is based on the repository's name (`https://dotnet.github.io/blazor-samples/`). The base href of the app is `/blazor-samples/`, which is set into `base_href` for the `ghaction-rewrite-base-href` Action to write into the app's `wwwroot/index.html` `<base>` tag when the app is deployed. For more information, see <xref:blazor/host-and-deploy/app-base-path>.

The GitHub-hosted Ubuntu (latest) server has a version of the .NET SDK pre-installed. You can remove the [`actions/setup-dotnet` Action](https://github.com/actions/setup-dotnet) step from the `static.yml` script if the pre-installed .NET SDK is sufficient to compile the app. To determine the .NET SDK installed for `ubuntu-latest`:

1. Go to the [**Available Images** section of the `actions/runner-images` GitHub repository](https://github.com/actions/runner-images?tab=readme-ov-file#available-images).
1. Locate the `ubuntu-latest` image, which is the first table row.
1. Select the link in the `Included Software` column.
1. Scroll down to the *.NET Tools* section to see the .NET SDK installed with the image.

## Deployment notes

The default GitHub Action, which deploys pages, skips deployment of folders starting with underscore, the `_framework` folder for example. To deploy folders starting with underscore, add an empty `.nojekyll` file to the root of the app's repository. Example: [Xref Generator `.nojekyll` file](https://github.com/dotnet/blazor-samples/blob/main/BlazorWebAssemblyXrefGenerator/.nojekyll)

***Perform this step before the first app deployment:*** Git treats JavaScript (JS) files, such as `blazor.webassembly.js`, as text and converts line endings from CRLF (carriage return-line feed) to LF (line feed) in the deployment pipeline. These changes to JS files produce different file hashes than Blazor sends to the client. The mismatches result in integrity check failures on the client. One approach to solving this problem is to add a `.gitattributes` file with `*.js binary` line before adding the app's assets to the Git branch. The `*.js binary` line configures Git to treat JS files as binary files, which avoids processing the files in the deployment pipeline and results in client-side integrity checks passing. For more information, see <xref:blazor/host-and-deploy/webassembly/bundle-caching-and-integrity-check-failures>. Example: [Xref Generator `.gitattributes` file](https://github.com/dotnet/blazor-samples/blob/main/BlazorWebAssemblyXrefGenerator/.gitattributes)

To handle URL rewrites based on [Single Page Apps for GitHub Pages (`rafrex/spa-github-pages` GitHub repository)](https://github.com/rafrex/spa-github-pages):

* Add a `wwwroot/404.html` file with a script that handles redirecting the request to the `index.html` page. Example: [Xref Generator `404.html` file](https://github.com/dotnet/blazor-samples/blob/main/BlazorWebAssemblyXrefGenerator/wwwroot/404.html)
* In `wwwroot/index.html`, add the script to `<head>` content. Example: [Xref Generator `index.html` file](https://github.com/dotnet/blazor-samples/blob/main/BlazorWebAssemblyXrefGenerator/wwwroot/index.html)

GitHub Pages doesn't natively support using Brotli-compressed resources. To use Brotli:

* Add the `wwwroot/decode.js` script to the app's `wwwroot` folder. Example: [Xref Generator `decode.js` file](https://github.com/dotnet/blazor-samples/blob/main/BlazorWebAssemblyXrefGenerator/wwwroot/decode.js)
* Add the `<script>` tag to load the `decode.js` script in the `wwwroot/index.html` file immediately above the `<script>` tag that loads the Blazor script. Example: [Xref Generator `index.html` file](https://github.com/dotnet/blazor-samples/blob/main/BlazorWebAssemblyXrefGenerator/wwwroot/index.html)
  * Set `autostart="false"` for the Blazor WebAssembly script.
  * Add the `loadBootResource` script after the `<script>` tag that loads the Blazor WebAssembly script. Example: [Xref Generator `index.html` file](https://github.com/dotnet/blazor-samples/blob/main/BlazorWebAssemblyXrefGenerator/wwwroot/index.html)

* Add `robots.txt` and `sitemap.txt` files to improve SEO. Examples: [Xref Generator `robots.txt` file](https://github.com/dotnet/blazor-samples/tree/main/BlazorWebAssemblyXrefGenerator/wwwroot/robots.txt), [Xref Generator `sitemap.txt` file](https://github.com/dotnet/blazor-samples/tree/main/BlazorWebAssemblyXrefGenerator/wwwroot/sitemap.txt)
