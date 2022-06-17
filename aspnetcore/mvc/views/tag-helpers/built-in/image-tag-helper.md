---
title: Image Tag Helper in ASP.NET Core
author: pkellner
description: Shows how to work with Image Tag Helper.
ms.author: riande
ms.custom: mvc
ms.date: 04/06/2019
uid: mvc/views/tag-helpers/builtin-th/image-tag-helper
---
# Image Tag Helper in ASP.NET Core

By [Peter Kellner](https://peterkellner.net)

The Image Tag Helper enhances the `<img>` tag to provide cache-busting behavior for static image files.

A cache-busting string is a unique value representing the hash of the static image file appended to the asset's URL. The unique string prompts clients (and some proxies) to reload the image from the host web server and not from the client's cache.

If the image source (`src`) is a static file on the host web server:

* A unique cache-busting string is appended as a query parameter to the image source.
* If the file on the host web server changes, a unique request URL is generated that includes the updated request parameter.

For an overview of Tag Helpers, see <xref:mvc/views/tag-helpers/intro>.

## Image Tag Helper Attributes

### src

To activate the Image Tag Helper, the `src` attribute is required on the `<img>` element.

The image source (`src`) must point to a physical static file on the server. If the `src` is a remote URI, the cache-busting query string parameter isn't generated.

### asp-append-version

When `asp-append-version` is specified with a `true` value along with a `src` attribute, the Image Tag Helper is invoked.

The following example uses an Image Tag Helper:

```cshtml
<img src="~/images/asplogo.png" asp-append-version="true">
```

If the static file exists in the directory */wwwroot/images/*, the generated HTML is similar to the following (the hash will be different):

```html
<img src="/images/asplogo.png?v=Kl_dqr9NVtnMdsM2MUg4qthUnWZm5T1fCEimBPWDNgM">
```

The value assigned to the parameter `v` is the hash value of the `asplogo.png` file on disk. If the web server is unable to obtain read access to the static file, no `v` parameter is added to the `src` attribute in the rendered markup.

[!INCLUDE[](~/includes/th_version.md)]

## Hash caching behavior

The Image Tag Helper uses the cache provider on the local web server to store the calculated `Sha512` hash of a given file. If the file is requested multiple times, the hash isn't recalculated. The cache is invalidated by a file watcher that's attached to the file when the file's `Sha512` hash is calculated. When the file changes on disk, a new hash is calculated and cached.

## Additional resources

* <xref:performance/caching/memory>
