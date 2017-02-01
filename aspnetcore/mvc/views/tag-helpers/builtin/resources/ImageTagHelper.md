[Back To Built In Tag Helpers List](../../builtin.md)


# ImageTagHelper

By [Peter Kellner](http://peterkellner.net) 


The `ImageTagHelper` enhances the html `img` (```<img ... ></img>```) tag. It requires a `src` tag be present as well as the `boolean` attribute `asp-append-version` be included.

If the image source (```src```) is a static file on the host web server, a unique cache bursting string is appended as a parameter to the image source.  This insures that if the file on the host web server changes, a unique request url will be generated that includes the updated request parameter. The cache bursting string is a unique value representing the `Sha512` value of the static image file.

If the image source (```src```) is not a static file (possibly a remote url or the file does not exist on the server) then no unique parameter will be generated and the `img` tag will be generated with no additional cache bursting parameter.

## The attributes are defined as follows: 

- - -

### asp-append-version

`asp-append-version` is the only attribute available for the Image Tag Helper.  When specified along with a `src` attribute, this `Image` tag helper is invoked.

An example of a valid `img` tag helper is as follows

```<img src="~/images/asplogo.png" asp-append-version="true"  />```

If the static file exists on the web server, typically in the directory `..wwwroot/images/asplogo.png` the generated html will be

```<img src="/images/asplogo.png?v=Kl_dqr9NVtnMdsM2MUg4qthUnWZm5T1fCEimBPWDNgM">```

The value assigned to the parameter `v` is the hash value of the file on disk generated using the .net library method ```CryptographyAlgorithms.CreateSHA256().ComputeHash()```.  If the web server is unable to get read access to the static file referenced (in our case ```..wwwroot/images/asplogo.png```) no v parameters is added to the src attribute and the original src attribute used is unchanged.

- - -

### src

The `src` attribute is required on the `img` html element.  For the `ImageTagHelper` to be activated, this `src` attribute must be included as one of the tag helper attributes.

> [!NOTE]
>  The Image Tag Helper uses the `Cache` provider on the local web server to store the calculated `Sha512` of a given file. If the file is requested again the `Sha512` does not need to be recalculated.  The Cache is invalidated by a file watcher that is attached to the file when the file's `Sha512` is calculated.

## Additional Resources

* [In Memory Caching](../../../../../performance/caching/memory.md) 


