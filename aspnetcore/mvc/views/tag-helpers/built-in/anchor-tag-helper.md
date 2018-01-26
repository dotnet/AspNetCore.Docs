---
title: Anchor Tag Helper
author: pkellner
description: Learn how to work with the ASP.NET Core Anchor Tag Helper
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 01/26/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: mvc/views/tag-helpers/builtin-th/anchor-tag-helper
---
# Anchor Tag Helper

By [Peter Kellner](http://peterkellner.net)

The Anchor Tag Helper enhances the HTML anchor (`<a ... ></a>`) tag by adding new attributes. The link generated (as seen in the `href` attribute) is created using the new attributes. That URL can include an optional protocol such as "https".

The following controller, *SpeakerController.cs*, is used in samples throughout this document:

[!code-csharp[SpeakerController](sample/TagHelpersBuiltInAspNetCore/src/TagHelpersBuiltInAspNetCore/Controllers/SpeakerController.cs)]

## Anchor Tag Helper attributes

### asp-controller

The `asp-controller` attribute assigns the controller used for generating the URL. The controller must exist in the current project. The following markup lists all speakers:

```cshtml
<a asp-controller="Speaker" 
   asp-action="Index">All Speakers</a>
```

The generated HTML is:

```html
<a href="/Speaker">All Speakers</a>
```

If the `asp-controller` attribute is specified and `asp-action` isn't, the default `asp-action` value is the controller action associated with the currently executing view. In the preceding example, if `asp-action` is omitted, and this Anchor Tag Helper is generated from *HomeController*'s *Index* view (*/Home*), the generated HTML is:

```html
<a href="/Home">All Speakers</a>
```

### asp-action

The `asp-action` attribute value represents the name of the controller action included in the generated `href` attribute. The following markup sets the generated `href` attribute value to the speaker detail page:

```cshtml
<a asp-controller="Speaker" 
   asp-action="Detail">Speaker Detail</a>
```

The generated HTML is:

```html
<a href="/Speaker/Detail">Speaker Detail</a>
```

If no `asp-controller` attribute is specified, the default controller calling the view executing the current view is used.

If the `asp-action` attribute value is `Index`, then no action is appended to the URL, leading to the invocation of the default `Index` action. The action specified (or defaulted), must exist in the controller referenced in `asp-controller`.

### asp-page

Use the `asp-page` attribute in an anchor tag to set its URL to a specific page. Prefixing the page name with a forward slash ("/") creates the URL. The URL in the following sample points to the "Speakers" page of the current directory.

```cshtml
<a asp-page="/Speakers">All Speakers</a>
```

The generated HTML is:

```html
<a href="/items?page=%2FSpeakers">Speakers</a>
```

The `asp-page` attribute is mutually exclusive with the `asp-route`, `asp-controller`, and `asp-action` attributes. However, `asp-page` can be used with `asp-route-id` to control routing, as the following markup demonstrates:

```cshtml
<a asp-page="/Speaker" 
   asp-route-id="@speaker.Id">View Speaker</a>
```

The `asp-route-id` produces the following output:

```html
https://localhost:44399/Speakers/Index/2?page=%2FSpeaker
```

> [!NOTE]
> To use an `asp-page` attribute in Razor Pages, the URL must be a relative path (for example, `"./Speaker"`). Relative paths in the `asp-page` attribute are unavailable in MVC views. Use the "/" syntax for MVC views instead.

### asp-route-{value}

The `asp-route-` attribute is a wildcard route prefix. Any value after the trailing dash is interpreted as a potential route parameter. If a default route isn't found, this route prefix is appended to the generated `href` attribute as a request parameter and value. Otherwise, it's substituted in the route template.

Consider the following controller action:

```csharp
public IActionResult AnchorTagHelper(string id)
{
    var speaker = new SpeakerData()
    {
        SpeakerId = 12
    };
    return View(viewName, speaker);
}
```

With a default route template defined in *Startup.cs*:

```csharp
app.UseMvc(routes =>
{
   routes.MapRoute(
    name: "default",
    template: "{controller=Home}/{action=Index}/{id?}");
});
```

The MVC view uses the `speaker` model parameter, provided by the `AnchorTagHelper` action, as follows:

```cshtml
@model SpeakerData
<!DOCTYPE html>
<html>
<body>
    <a asp-controller="Speaker"
       asp-action="Detail" 
       asp-route-id="@Model.SpeakerId">SpeakerId: @Model.SpeakerId</a>
</body>
</html>
```

The default route's `{id?}` placeholder was matched. The generated HTML is:

```html
<a href='/Speaker/Detail/12'>SpeakerId: 12</a>
```

If the route prefix isn't part of the routing template found, which is the case with the following MVC view:

```cshtml
@model SpeakerData
<!DOCTYPE html>
<html>
<body>
    <a asp-controller="Speaker" 
       asp-action="Detail" 
       asp-route-speakerid="@Model.SpeakerId">SpeakerId: @Model.SpeakerId</a>
<body>
</html>
```

The following HTML is generated because `speakerid` wasn't found in the matching route:

```html
<a href='/Speaker/Detail?speakerid=12'>SpeakerId: 12</a>
```

If either `asp-controller` or `asp-action` aren't specified, then the same default processing is followed as is in the `asp-route` attribute.

### asp-route

The `asp-route` attribute is used for creating a URL linking directly to a named route. Using [routing attributes](xref:mvc/controllers/routing#attribute-routing), a route can be named as shown in the `SpeakerController` and used in its `Evaluations` action.

The [route name](xref:mvc/controllers/routing#route-name) `Name = "speakerevals"` tells the Anchor Tag Helper to generate a route directly to that controller action using the URL */Speaker/Evaluations*. If `asp-controller` or `asp-action` is specified in addition to `asp-route`, the route generated may not be what you expect. To avoid a route conflict, `asp-route` shouldn't be used with the `asp-controller` and `asp-action` attributes.

### asp-all-route-data

The `asp-all-route-data` attribute supports the creation of a dictionary of key-value pairs. The key is the parameter name, and the value is the parameter value.

In the following example, a dictionary is created inline and passed to a Razor view. Alternatively, the data could be passed in with your model.

```cshtml
@{
    var dict =
        new Dictionary<string, string>
        {
            {"speakerId", "11"},
            {"currentYear", "true"}
        };
}

<a asp-route="speakerevalscurrent"
   asp-all-route-data="dict">SpeakerEvals</a>
```

The preceding code generates the following URL: http://localhost/Speaker/EvaluationsCurrent?speakerId=11&currentYear=true

When the link is clicked, the controller's `EvaluationsCurrent` action is called. It's called because that controller has two string parameters matching what has been created from the `asp-all-route-data` dictionary.

If any keys in the dictionary match route parameters, those values are substituted in the route as appropriate. The other non-matching values are generated as request parameters.

### asp-fragment

The `asp-fragment` attribute defines a URL fragment to append to the URL. The Anchor Tag Helper adds the hash character (#). Consider the following markup:

```cshtml
<a asp-action="Evaluations" 
   asp-controller="Speaker"  
   asp-fragment="SpeakerEvaluations">About Speaker Evals</a>
```

The generated URL is http://localhost/Speaker/Evaluations#SpeakerEvaluations.

Hash tags are useful when building client-side apps. They can be used for easy marking and searching in JavaScript, for example.

### asp-area

The `asp-area` attribute sets the area name used to set the appropriate route. The following example depicts how the area attribute causes a remapping of routes. Setting `asp-area` to "Blogs" prefixes the directory *Areas/Blogs* to the routes of the associated controllers and views for this anchor tag.

* **<Project name\>**
  * **wwwroot**
  * **Areas**
    * **Blogs**
      * **Controllers**
        * *HomeController.cs*
      * **Views**
        * **Home**
          * *Index.cshtml*
          * *AboutBlog.cshtml*
  * **Controllers**

Given the preceding directory hierarchy, the markup to reference the *AboutBlog.cshtml* file is:

```cshtml
<a asp-action="AboutBlog" 
   asp-controller="Home"
   asp-area="Blogs">Blogs About</a>
```

The generated HTML includes the areas segment:

```html
<a href="/Blogs/Home/AboutBlog">Blogs About</a>
```

> [!TIP]
> For MVC areas to work in a web app, the route template must include a reference to the area, if it exists. That template, which is the second parameter of the `routes.MapRoute` method call, appears as `template: '"{area:exists}/{controller=Home}/{action=Index}"'`.

### asp-protocol

The `asp-protocol` attribute is for specifying a protocol (such as `https`) in your URL. For example:

```cshtml
<a asp-protocol="https" 
   asp-action="About"
   asp-controller="Home">About</a>
```

The preceding markup generates the following HTML:

```html
<a href="https://localhost/Home/About">About</a>
```

The domain in the example is localhost, but the Anchor Tag Helper uses the website's public domain when generating the URL.

## Additional resources

* [Areas](xref:mvc/controllers/areas)
