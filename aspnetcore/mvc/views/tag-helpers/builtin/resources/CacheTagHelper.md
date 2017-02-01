[Back To Built In Tag Helpers List](../../builtin.md)


# CacheTagHelper

By [Peter Kellner](http://peterkellner.net) 


The `CacheTagHelper` provides the ability to dramatically improve the performance of your ASP.NET core app by caching its content to the internal ASP.NET core cache provider.

A simple example that shows the `CacheTagHelper` in action sets the current time in the content area of the Cache Tag Helper. The Razor View Engine sets the default of `expires-after` to be 20 minutes (this is the default if you specify no addional attributes).

Here is an example of the code you would include in your `cshtml` page to achieve the default cache behavior described above.

```HTML
<Cache>@DateTime.Now<Cache>
```

If you repeatedly refresh the page that contains the`Cache`tag above, the first time the current`DateTime`will be shown.  Then, repeated refreshes of the page will continue to show the first`DateTime` shown until the cache expires (which is likely 20 minutes in this example).

You can achieve more control of the cache duration of the content by setting any of the following attributes.



## The attributes are defined as follows

- - -

### enabled    


| Attribute Type 	| Valid Values   	|
|----------------	|----------------	|
| boolean         	| "true","false" 	|


The attribute`enabled` determines whether any caching is performed of the content inside the `Cache` tag helper.  The default is `true` which means that all other attributes will be active.  It also means that if this attribute is left out, its default value will be set to true.  If set to `false` then regardless of what other attributes are specified, this cache tag will have no caching effect on the rendered output.

Usage Example:

```HTML
<Cache enabled="true">
  Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-on 

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| DateTimeOffset    | "@new DateTime(2025,1,29,17,02,0)" 	|


The attribute `expires-on` sets a deterministic expiration date for caching the content of the `Cache` tag helper when the tag helper is first rendered.  The example below will cache the contents of the `Cache` tag helper until 5:02 PM on January 29, 2025.

Usage Example:

```HTML
<Cache expires-on="@new DateTime(2025,1,29,17,02,0)">
  Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-after

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| TimeSpan    | "@TimeSpan.FromSeconds(5)" 	|


The attribute `expires-after` sets a specific amount of time from the current `DateTime` that the contents of the `Cache` tag helper will be kept.  This value is set when the `Cache` tag helper is first rendered.  The example below will likely cache the contents of the `Cache` tag for 5 seconds.

Usage Example:

```HTML
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

```HTML
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

The attribute `vary-by-header` allows for either a single header or a comma separated list of headers to be identified that will cause a cache refresh when changed.  That is, when any header in the `vary-by-header` list is seen for the first time or changed, the content of the `Cache` tag helper will be updated.  The example below looks at the header value `User-Agent` which will effectively cache the content for every different `User-Agent` presented to the web server.

Usage Example:

<Cache vary-by-header="User-Agent">
  Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>

- - -

### vary-by-query

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String            | "Make"   	            |
|                   | "Make,Model" |

The attribute `vary-by-query` allows for either a single query parameter or a comma separated list of query parameters to be identified that will cause a cache refresh when the passed in query value or values change.  That is, when any query parameter in the `vary-by-query` list is seen for the first time or changed, the content of the `Cache` tag helper will be updated.  The example below looks at the values of Make and Model and when either or both change, the content of the `Cache` tag helper will be rendered again and the cache is reset to that new value.  

Usage Example:


<Cache vary-by-query="Make,Model">
  Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>

- - -

### vary-by-route

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String            | "Make"   	            |
|                   | "Make,Model" |

The attribute `vary-by-route` allows for either a single route parameter or a comma separated list of route parameters to be identified that will cause a cache refresh when the passed in route value or values change.  That is, when any request causes one or more of the route parameters to change, the content of the `Cache` tag helper will be updated.  The example below looks at the values of Make and Model. When either or both change, the content of the `Cache` tag helper will be rendered again and the cache is reset.

Usage Example:

Startup.cs 

```C#
routes.MapRoute(
  name: "default",
  template: "{controller=Home}/{action=Index}/{Make?}/{Model?}");
```
  

Index.cshtml

```HTML
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

The attribute `vary-by-cookie` allows for either a single request cookie or a comma separated list of request cookies to be identified that will cause a cache refresh when the current request's cookie value or values change.  That is, when any cookie parameter in the vary-by-cookie list is seen for the first time or changed, the content of the `Cache` tag helper will be updated.  The example below looks at the cookie associated with asp.net Identity. When a user is authenticated causing the request cookie to be set, The content of the `Cache` tag helper will be rendered again and the cache is reset.  

Usage Example:

<Cache vary-by-cookie=".AspNetCore.Identity.Application">
  Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>

- - -

### vary-by-user

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| Boolean             | "true"   	            |
|                     | "false" |

The attribute `vary-by-user` allows for the logged in user (or Context Principal) changes to cause a cache refresh. That is, when the authenticated user changes, the content of the `Cache` tag helper will be updated.  The current user is also known as the  Request Context Principal and can be viewed on a razor cshtml page by referencing `@User.Identity.Name`.


The example below looks at the current logged in user. When a different user is found, The content of the `Cache` tag helper will be rendered again and the cache is reset.  

Usage Example:

<Cache vary-by-user="true">
  Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>

> [!NOTE]
>  using the attribute `vary-by-user` will maintain the contents in cache through a log in and log out cycle.  When using `vary-by-cookie` which references the `.AspNetCore.Identity.Application` as shown above, a log in and log out action will invalidate the cache for the same authenticated user because a new cookie value will be generated.  Also, if no user is authenticated (or logged in), that state is considered a valid cache state which means that no logged in user is one cache state and the contents will be maintained for that condition as well.

- - -

### vary-by

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String             | "@Model"  	            |


The attribute `vary-by` allows for customization of what data gets cached.  When the string value changes of what is assigned to the attribute 'vary-by', the content of the `Cache` tag helper will be updated. Often a model value or combination of model values are assigned to this attribute.  Otherwise, the value will never change and the cache will be updated only by the inclusion of other attributes in the `Cache` tag helper.

The example below assumes the controller method rendering the view sums the integer value of the two route parameters, myParam1 and myParam2, and returns that as the single model property. When this sum changes, the content of the `Cache` tag helper will be rendered again and the cache is reset.  

Usage Example:


Controller

```C#
public IActionResult Index
    (string myParam1,string myParam2,string myParam3)
{
   int num1;
    int num2;
    int.TryParse(myParam1, out num1);
    int.TryParse(myParam2, out num2);
    return View(viewName, num1 + num2);
}
```

Index.cshtml

```HTML
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

The attribute `priority` is used to give guidance to the built in cache provider on what priority to assign to the cache contents stored.  That is, there is no guarantee of the cache not being invalidated prior to the expected expiration.  If for example you set one `Cache` tag helper to have its priority `High` and another to `Low`, it is likely that if the web server experiences memory pressure and needs to evict one of your cached content values, it will evict the `Low` priority first.

Usage Example:

<Cache priority="High">
  Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>

> [!WARNING]
>  using the `priority` attribute does not guarantee any specific level of cache retention. It is simply a suggestion to the Cache Provider. To be extra clear, setting this attribute to `NeverRemove` does not guarantee that the cache will not be evicted.  More details can be found in the additional resources listed below.

- - -


>[!NOTE]
>The ```CacheTagHelper``` is dependent on the built in Memory Cache service being included in the ```startup.cs``` ConfigureServices method.  Adding this service is not necessary because the built in Tag Helper extensions take care of this in the AddMvc() method call.

## Additional Resources

* [In Memory Caching](../../../../../performance/caching/memory.md) 
* [ASP.NET Core Identity (Authentication)](../../../../../security/authentication/identity.md)
