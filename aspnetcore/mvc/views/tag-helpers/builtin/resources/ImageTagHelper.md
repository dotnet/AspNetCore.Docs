[Back To Built In Tag Helpers List](../../builtin.md)

# ImageTagHelper

By [Peter Kellner](http://peterkellner.net) 

The Image Tag Helper enhances the `img` (`<img>`) tag. It requires a `src` tag as well as the `boolean` attribute `asp-append-version`.

If the image source (`src`) is a static file on the host web server, a unique cache busting string is appended as a query parameter to the image source. This insures that if the file on the host web server changes, a unique request URL is generated that includes the updated request parameter. The cache busting string is a unique value representing the `SHA256` hash of the static image file.

If the image source (`src`) isn't a static file, possibly a remote URL or the file doesn't exist on the server, the `<img>` tag's `src` attribute is generated with no cache busting query string parameter.

## Image Tag Helper Attributes

- - -

### asp-append-version

`asp-append-version` is the only attribute available for the Image Tag Helper.  When specified along with a `src` attribute, this Image Tag Helper is invoked.

An example of a valid `img` tag helper is:

```html
<img src="~/images/asplogo.png" 
    asp-append-version="true"  />
```

If the static file exists on the web server, typically in the directory `..wwwroot/images/asplogo.png` the generated html is:

```html
<img 
    src="/images/asplogo.png?v=Kl_dqr9NVtnMdsM2MUg4qthUnWZm5T1fCEimBPWDNgM"/>
```

The value assigned to the parameter `v` is the hash value of the file on disk generated using the .NET library method `CryptographyAlgorithms.CreateSHA256().ComputeHash()`.  If the web server is unable to obtain read access to the static file referenced, `wwwroot/images/asplogo.png`, no `v` parameters is added to the `src` attribute, and the original src attribute is unchanged.

- - -

### src

To activate the Image Tag Helper, the src attribute is required on the `<img>` element. 

> [!NOTE]
>  The Image Tag Helper uses the `Cache` provider on the local web server to store the calculated `Sha512` of a given file. If the file is requested again the `Sha512` does not need to be recalculated.  The Cache is invalidated by a file watcher that is attached to the file when the file's `Sha512` is calculated.

## Additional Resource

* <xref:performance/caching/memory>


