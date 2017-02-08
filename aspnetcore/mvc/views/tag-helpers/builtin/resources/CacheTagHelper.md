[Back To Built In Tag Helpers List](../../builtin.md)

# Cache Tag Helper

By [Peter Kellner](http://peterkellner.net) 


The  Cache Tag Helper provides the ability to dramatically improve the performance of your ASP.NET Core app by caching its content to the internal ASP.NET Core cache provider.

A simple example that shows the Cache Tag Helper in action sets the current time in its content area. The Razor View Engine sets the default `expires-after` to twenty minutes, which is the default if you specify no additional attributes.

Here is an example of the code you include in your `cshtml` page to achieve the default cache behavior described above.

```html
<Cache>@DateTime.Now<Cache>
```

If you repeatedly refresh the page that contains `CacheTagHelper`, the first time the current`DateTime`will be shown. Repeated refreshes of the page will continue to show the first `DateTime` shown until the cache expires (which is likely to be twenty minutes unless server memory pressure evicts the cache sooner).

You can achieve more control of the cache duration of the content by setting any of the following attributes:

## Cache Tag Helper Attributes

- - -

### enabled    


| Attribute Type 	| Valid Values   	|
|----------------	|----------------	|
| boolean         	| "true" (default) 	|
|               	| "false"	|


The attribute `enabled` determines whether any caching is performed of the content inside the Cache Tag Helper. The default is `true`, which results in all other attributes being valid.  The default value is `true`.  If set to `false`, regardless of what other attributes are specified, this Cache Tag Helper will have no caching effect on the rendered output.
Usage Example:

```html
<Cache enabled="true">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-on 

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| DateTimeOffset    | "@new DateTime(2025,1,29,17,02,0)" 	|


The attribute `expires-on` sets a deterministic expiration date for caching the content of the Cache Tag Helper when it is first rendered. The example below will cache the contents of the Cache Tag Helper until 5:02 PM on January 29, 2025.

Usage Example:

```html
<Cache expires-on="@new DateTime(2025,1,29,17,02,0)">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-after

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| TimeSpan    | "@TimeSpan.FromSeconds(120)" 	|


The attribute `expires-after` sets a specific amount of time from the current `DateTime` to cache the contents of the Cache Tag Helper. This value is set when it is first rendered.  The example below caches the contents of the Cache Tag Helper for one hundred twenty seconds. If there is memory pressure on the server, the cache may be evicted sooner.

Usage Example:

```html
<Cache expires-on="@TimeSpan.FromSeconds(5)">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-sliding

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| TimeSpan    | "@TimeSpan.FromSeconds(5)" 	|


The attribute `expires-after` sets a specific amount of time from the current `DateTime` that the contents of the `Cache` tag helper will be kept in cache.  This value is set when the `Cache` tag helper is first rendered.

Usage Example:

```html
<Cache expires-on="@TimeSpan.FromSeconds(5)">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### vary-by-header

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String            | "User-Agent"   	            |
|                   | "User-Agent,content-encoding" |

The attribute `vary-by-header` accepts a single header value or a comma-separated list of header values that trigger a cache refresh when they change. The example below looks at the header value `User-Agent`, which will cache the content for every different `User-Agent` presented to the web server.

Usage Example:

```html
<Cache vary-by-header="User-Agent">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### vary-by-query

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String            | "Make"   	            |
|                   | "Make,Model" |

The attribute `vary-by-query` accepts a single header value or a comma-separated list of header values that trigger a cache refresh when they change. The example below looks at the values of `Make` and `Model`; and when either or both change, the content of the Cache Tag Helper is rendered again, and the cache is reset.

Usage Example:

```
html
<Cache vary-by-query="Make,Model">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### vary-by-route

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String            | "Make"   	            |
|                   | "Make,Model" |

The attribute `vary-by-route` accepts a single header value or a comma-separated list of header values that trigger a cache refresh when they change. The example below looks at the values of `Make` and `Model`. When either or both change, the content of the Cache Tag Helper is rendered again, and the cache is reset.

Usage Example:

*Startup.cs* 

```csharp
routes.MapRoute(
    name: "default",
    template: "{controller=Home}/{action=Index}/{Make?}/{Model?}");
```
  
*Index.cshtml*

```html
<Cache vary-by-route="Make,Model">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### vary-by-cookie

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String            | ".AspNetCore.Identity.Application"   	            |
|                   | ".AspNetCore.Identity.Application,HairColor" |

The attribute `vary-by-cookie` accepts a single header value or a comma-separated list of header values that trigger a cache refresh when they change. The example below looks at the cookie associated with asp.net Identity. When a user is authenticated causing the request cookie to be set, The content of the Cache Tag Helper is rendered again, and the cache is reset.  

Usage Example:

```html
<Cache vary-by-cookie=".AspNetCore.Identity.Application">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
````

- - -

### vary-by-user

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| Boolean             | "true"   	            |
|                     | "false" (default) |

The attribute `vary-by-user` specifies whether or not the cache should reset when the logged-in user (or Context Principal) changes. The current user is also known as the  Request Context Principal and can be viewed in a Razor view by referencing `@User.Identity.Name`.

The example below looks at the current logged in user. When a different user is found, The content of the Cache Tag Helper is rendered again, and the cache is reset.  

Usage Example:

```html
<Cache vary-by-user="true">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

> [!NOTE]
>  Using the attribute `vary-by-user` maintains the contents in cache through a log-in and log-out cycle.  When using `vary-by-cookie` which references the `.AspNetCore.Identity.Application` as shown above, a log-in and log-out action invalidates the cache for the same authenticated user because a new cookie value is generated. If no user is authenticated, that state is considered a valid cache state, which means that no logged-in user is one cache state, and the contents will be maintained for that condition as well.

- - -

### vary-by

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String             | "@Model"  	            |


The attribute `vary-by` allows for customization of what data gets cached. When the object referenced by the attribute's string value changes, the content of the Cache Tag Helper is updated. Often a string-concatenation of model values are assigned to this attribute.  Effectively, that means any update to any of the concatenated values invalidates the cache.

The example below assumes the controller method rendering the view sums the integer value of the two route parameters, `myParam1` and `myParam2`, and returns that as the single model property. When this sum changes, the content of the Cache Tag Helper is rendered again, and the cache is reset.  

Usage Example:


*Controller*

```csharp
public IActionResult Index(string myParam1,string myParam2,string myParam3)
{
    int num1;
    int num2;
    int.TryParse(myParam1, out num1);
    int.TryParse(myParam2, out num2);
    return View(viewName, num1 + num2);
}
```

*Index.cshtml*

```html
<Cache vary-by="@Model"">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### priority

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| CacheItemPriority  | "High"   	            |
|                    | "Low" |
|                    | "NeverRemove" |
|                    | "Normal" |

The attribute `priority` provides cache ejection guidance to the built-in cache provider. If the web server experiences memory pressure and evicts one or more of your cached entities, it will evict Low priority cache entities first.

Usage Example:

```html
<Cache priority="High">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

> [!WARNING]
>  using the `priority` attribute does not guarantee any specific level of cache retention. It is simply a suggestion to the Cache Provider. To be extra clear, setting this attribute to `NeverRemove` does not guarantee that the cache will not be evicted.  More details can be found in the additional resources listed below.

- - -


>[!NOTE]
> The Cache Tag Helper is dependent on the built in Memory Cache service being included in the `startup.cs` ConfigureServices method.  Adding this service is not necessary because the built in Tag Helper extensions take care of this in the `AddMvc` method call.

## Additional Resources

* <xref:performance/caching/memory>
* <xref:security/authentication/identity>




