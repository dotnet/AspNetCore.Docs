---
title: Image Tag Helper | Microsoft Docs
author: pkellner
description: Shows how to work with Image Tag Helper
keywords: ASP.NET Core,tag helper
ms.author: riande
manager: wpickett
ms.date: 02/14/2017
ms.topic: article
ms.assetid: c045d485-d1dc-4cea-a675-46be83b7a013
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/views/tag-helpers/builtin-th/ImageTagHelper
---
# ImageTagHelper

By [Peter Kellner](http://peterkellner.net) 

The Image Tag Helper enhances the `img` (`<img>`) tag. It requires a `src` tag as well as the `boolean` attribute `asp-append-version`.

If the image source (`src`) is a static file on the host web server, a unique cache busting string is appended as a query parameter to the image source. This ensures that if the file on the host web server changes, a unique request URL is generated that includes the updated request parameter. The cache busting string is a unique value representing the hash of the static image file.

If the image source (`src`) isn't a static file (for example a remote URL or the file doesn't exist on the server), the `<img>` tag's `src` attribute is generated with no cache busting query string parameter.

## Image Tag Helper Attributes


### asp-append-version

When specified along with a `src` attribute, the Image Tag Helper is invoked.

An example of a valid `img` tag helper is:

```cshtml
<img src="~/images/asplogo.png" 
    asp-append-version="true"  />
```

If the static file exists in the directory *..wwwroot/images/asplogo.png* the generated html is similar to the following (the hash will be different):

```html
<img 
    src="/images/asplogo.png?v=Kl_dqr9NVtnMdsM2MUg4qthUnWZm5T1fCEimBPWDNgM"/>
```

The value assigned to the parameter `v` is the hash value of the file on disk. If the web server is unable to obtain read access to the static file referenced,  no `v` parameters is added to the `src` attribute.

- - -

### src

To activate the Image Tag Helper, the src attribute is required on the `<img>` element. 

> [!NOTE]
> The Image Tag Helper uses the `Cache` provider on the local web server to store the calculated `Sha512` of a given file. If the file is requested again the `Sha512` does not need to be recalculated. The Cache is invalidated by a file watcher that is attached to the file when the file's `Sha512` is calculated.

## Additional resources

* <xref:performance/caching/memory>