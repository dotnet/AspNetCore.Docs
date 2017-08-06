---
title: Cache Tag Helper in ASP.NET Core MVC
author: pkellner
description: Shows how to work with Cache Tag Helper
keywords: ASP.NET Core,tag helper
ms.author: riande
manager: wpickett
ms.date: 02/14/2017
ms.topic: article
ms.assetid: c045d485-d1dc-4cea-a675-46be83b7a012
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/views/tag-helpers/builtin-th/CacheTagHelper
---
# Cache Tag Helper in ASP.NET Core MVC

By [Peter Kellner](http://peterkellner.net) 


The  Cache Tag Helper provides the ability to dramatically improve the performance of your ASP.NET Core app by caching its content to the internal ASP.NET Core cache provider.

The Razor View Engine sets the default `expires-after` to twenty minutes.

The following Razor markup caches the date/time:

```cshtml
<Cache>@DateTime.Now<Cache>
```

The first request to the page that contains `CacheTagHelper` will display the current date/time. Additional requests will show the cached value until the cache expires (default 20 minutes) or is evicted by memory pressure.

You can set the cache duration with the following attributes:

## Cache Tag Helper Attributes

- - -

### enabled    


| Attribute Type 	| Valid Values   	|
|----------------	|----------------	|
| boolean         	| "true" (default) 	|
|               	| "false"	|


Determines whether the content enclosed by the Cache Tag Helper is cached. The default is `true`.  If set to `false` this Cache Tag Helper will have no caching effect on the rendered output.

Example:

```cshtml
<Cache enabled="true">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-on 

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| DateTimeOffset    | "@new DateTime(2025,1,29,17,02,0)" 	|


Sets an absolute expiration date. The following example will cache the contents of the Cache Tag Helper until 5:02 PM on January 29, 2025.

Example:

```cshtml
<Cache expires-on="@new DateTime(2025,1,29,17,02,0)">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-after

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| TimeSpan    | "@TimeSpan.FromSeconds(120)" 	|


Sets the length of time from the first request time to cache the contents. 

Example:

```cshtml
<Cache expires-on="@TimeSpan.FromSeconds(120)">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### expires-sliding

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| TimeSpan    | "@TimeSpan.FromSeconds(60)" 	|


Sets the time that a cache entry should be evicted if it has not been accessed.

Example:

```cshtml
<Cache expires-sliding="@TimeSpan.FromSeconds(60)">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### vary-by-header

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String            | "User-Agent"   	            |
|                   | "User-Agent,content-encoding" |

Accepts a single header value or a comma-separated list of header values that trigger a cache refresh when they change. The following example monitors the header value `User-Agent`. The example will cache the content for every different `User-Agent` presented to the web server.

Example:

```cshtml
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

Accepts a single header value or a comma-separated list of header values that trigger a cache refresh when the header value changes. The following example looks at the values of `Make` and `Model`.

Example:

```cshtml
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

Accepts a single header value or a comma-separated list of header values that trigger a cache refresh when the route data parameter value(s) change. 
Example:

*Startup.cs* 

```csharp
routes.MapRoute(
    name: "default",
    template: "{controller=Home}/{action=Index}/{Make?}/{Model?}");
```
  
*Index.cshtml*

```cshtml
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

Accepts a single header value or a comma-separated list of header values that trigger a cache refresh when the header values(s) change. The following example looks at the cookie associated with ASP.NET Identity. When a user is authenticated the request cookie to be set which triggers a cache refresh.

Example:

```cshtml
<Cache vary-by-cookie=".AspNetCore.Identity.Application">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

- - -

### vary-by-user

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| Boolean             | "true"   	            |
|                     | "false" (default) |

Specifies whether or not the cache should reset when the logged-in user (or Context Principal) changes. The current user is also known as the Request Context Principal and can be viewed in a Razor view by referencing `@User.Identity.Name`.

The following example looks at the current logged in user.  

Example:

```cshtml
<Cache vary-by-user="true">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

Using this attribute maintains the contents in cache through a log-in and log-out cycle.  When using `vary-by-user="true"`, a log-in and log-out action invalidates the cache for the authenticated user.  The cache is invalidated because a new unique cookie value is generated on login. Cache is maintained for the anonymous state when no cookie is present or has expired. This means if no user is logged in, the cache will be maintained.

- - -

### vary-by

| Attribute Type 	| Example Values            	|
|----------------	|----------------             	|
| String             | "@Model"  	            |


Allows for customization of what data gets cached. When the object referenced by the attribute's string value changes, the content of the Cache Tag Helper is updated. Often a string-concatenation of model values are assigned to this attribute.  Effectively, that means an update to any of the concatenated values invalidates the cache.

The following example assumes the controller method rendering the view sums the integer value of the two route parameters, `myParam1` and `myParam2`, and returns that as the single model property. When this sum changes, the content of the Cache Tag Helper is rendered and cached again.  

Example:

Action:

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

```cshtml
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

Provides cache eviction guidance to the built-in cache provider. The web server will evict `Low` cache entries first when it's under memory pressure.

Example:

```cshtml
<Cache priority="High">
    Current Time Inside Cache Tag Helper: @DateTime.Now
</Cache>
```

The `priority` attribute does not guarantee a specific level of cache retention. `CacheItemPriority` is only a suggestion. Setting this attribute to `NeverRemove` does not guarantee that the cache will always be retained. See [Additional Resources](#additional-resources) for more information.

The Cache Tag Helper is dependent on the [memory cache service](xref:performance/caching/memory). The Cache Tag Helper adds the service if it has not been added.

## Additional resources

* <xref:performance/caching/memory>
* <xref:security/authentication/identity>