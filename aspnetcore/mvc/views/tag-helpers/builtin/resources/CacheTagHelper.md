[Back To Built In Tag Helpers List](../../builtin.md)


# CacheTagHelper

By [Peter Kellner](http://peterkellner.net) 


The ```CacheTagHelper``` provides the ability to dramatically improve the performance of your ASP.NET core app by caching its content to the internal ASP.NET core cache provider.

A simple example that shows the ```CacheTagHelper``` in action set's the current time in the content area of the Cache Tag Helper. The Razor View Engine sets the default of ```expires-after``` to be 20 minutes (this is the default if you specify no attributes).

Here is an example of the code you would include in your cshtml page to achieve the 20 minute cache of the current system date and time.

```<Cache>@DateTime.Now<Cache>```

You can get much more control of the cache duration by setting any of the following attributes.

<br/>
All attributes are defined as follows:

## vary-by
x

## vary-by-header
x

##vary-by-query
x

##vary-by-route

##vary-by-cookie

##vary-by-user

##expires-on

##expires-sliding

##enabled


>[!NOTE]
>The ```CacheTagHelper``` is dependent on the built in Memory Cache service being included in the ```startup.cs``` ConfigureServices method.  Adding this service is not necessary because the built in Tag Helper extensions take care of this in the AddMvc() method call.

REFERENCES:

AFTER CHECKING BELOW REFERENCE REMOVE THESE TWO LINES
https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory


* [In memory caching](../../../../performance/caching/memory.md)
