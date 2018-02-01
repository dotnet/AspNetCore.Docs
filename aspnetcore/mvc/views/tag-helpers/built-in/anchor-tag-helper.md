---
title: Anchor Tag Helper
author: pkellner
description: Discover the ASP.NET Core Anchor Tag Helper attributes and the role each attribute plays in extending behavior of the HTML anchor tag.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 01/31/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: mvc/views/tag-helpers/builtin-th/anchor-tag-helper
---
# Anchor Tag Helper

By [Peter Kellner](http://peterkellner.net) and [Scott Addie](https://github.com/scottaddie)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/views/tag-helpers/built-in/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The [Anchor Tag Helper](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper) enhances the standard HTML anchor (`<a ... ></a>`) tag by adding new attributes. By convention, the attribute names are prefixed with `asp-`. The rendered anchor element's `href` attribute value is determined by the values of the `asp-` attributes.

*SpeakerController* is used in samples throughout this document:

[!code-csharp[](samples/TagHelpersBuiltInAspNetCore/Controllers/SpeakerController.cs?name=snippet_SpeakerController)]

An inventory of the `asp-` attributes follows.

## asp-controller

The [asp-controller](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.controller) attribute assigns the controller used for generating the URL. The following markup lists all speakers:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspController)]

The generated HTML:

```html
<a href="/Speaker">All Speakers</a>
```

If the `asp-controller` attribute is specified and `asp-action` isn't, the default `asp-action` value is the controller action associated with the currently executing view. If `asp-action` is omitted from the preceding markup, and the Anchor Tag Helper is used in *HomeController*'s *Index* view (*/Home*), the generated HTML is:

```html
<a href="/Home">All Speakers</a>
```

## asp-action

The [asp-action](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.action) attribute value represents the controller action name included in the generated `href` attribute. The following markup sets the generated `href` attribute value to the speaker evaluations page:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspAction)]

The generated HTML:

```html
<a href="/Speaker/Evaluations">Speaker Evaluations</a>
```

If no `asp-controller` attribute is specified, the default controller calling the view executing the current view is used.

If the `asp-action` attribute value is `Index`, then no action is appended to the URL, leading to the invocation of the default `Index` action. The action specified (or defaulted), must exist in the controller referenced in `asp-controller`.

## asp-route-{value}

The [asp-route-{value}](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.routevalues) attribute enables a wildcard route prefix. Any value occupying the `{value}` placeholder is interpreted as a potential route parameter. If a default route isn't found, this route prefix is appended to the generated `href` attribute as a request parameter and value. Otherwise, it's substituted in the route template.

Consider the following controller action:

[!code-csharp[](samples/TagHelpersBuiltInAspNetCore/Controllers/BuiltInTagController.cs?name=snippet_AnchorTagHelperAction)]

With a default route template defined in *Startup.Configure*:

[!code-csharp[](samples/TagHelpersBuiltInAspNetCore/Startup.cs?name=snippet_UseMvc&highlight=8-10)]

The MVC view uses the model, provided by the action, as follows:

```cshtml
@model Speaker
<!DOCTYPE html>
<html>
<body>
    <a asp-controller="Speaker"
       asp-action="Detail" 
       asp-route-id="@Model.SpeakerId">SpeakerId: @Model.SpeakerId</a>
</body>
</html>
```

The default route's `{id?}` placeholder was matched. The generated HTML:

```html
<a href="/Speaker/Detail/12">SpeakerId: 12</a>
```

Assume the route prefix isn't part of the matching routing template, as with the following MVC view:

```cshtml
@model Speaker
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
<a href="/Speaker/Detail?speakerid=12">SpeakerId: 12</a>
```

If either `asp-controller` or `asp-action` aren't specified, then the same default processing is followed as is in the `asp-route` attribute.

## asp-route

The [asp-route](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.route) attribute is used for creating a URL linking directly to a named route. Using [routing attributes](xref:mvc/controllers/routing#attribute-routing), a route can be named as shown in the `SpeakerController` and used in its `Evaluations` action:

[!code-csharp[](samples/TagHelpersBuiltInAspNetCore/Controllers/SpeakerController.cs?range=22-24)]

In the following markup, the `asp-route` attribute references the named route:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspRoute)]

The Anchor Tag Helper generates a route directly to that controller action using the URL */Speaker/Evaluations*. The generated HTML:

```html
<a href="/Speaker/Evaluations">Speaker Evaluations</a>
```

If `asp-controller` or `asp-action` is specified in addition to `asp-route`, the route generated may not be what you expect. To avoid a route conflict, `asp-route` shouldn't be used with the `asp-controller` and `asp-action` attributes.

## asp-all-route-data

The [asp-all-route-data](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.routevalues) attribute supports the creation of a dictionary of key-value pairs. The key is the parameter name, and the value is the parameter value.

In the following example, a dictionary is initialized and passed to a Razor view. Alternatively, the data could be passed in with your model.

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspAllRouteData)]

The preceding code generates the following HTML:

```html
<a href="/Speaker/EvaluationsCurrent?speakerId=11&currentYear=true">Speaker Evaluations</a>
```

The `asp-all-route-data` dictionary is flattened to produce a querystring meeting the requirements of the overloaded `Evaluations` action:

[!code-csharp[](samples/TagHelpersBuiltInAspNetCore/Controllers/SpeakerController.cs?range=26-30)]

If any keys in the dictionary match route parameters, those values are substituted in the route as appropriate. The other non-matching values are generated as request parameters.

## asp-fragment

The [asp-fragment](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.fragment) attribute defines a URL fragment to append to the URL. The Anchor Tag Helper adds the hash character (#). Consider the following markup:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspFragment)]

The generated HTML:

```html
<a href="/Speaker/Evaluations#SpeakerEvaluations">Speaker Evaluations</a>
```

Hash tags are useful when building client-side apps. They can be used for easy marking and searching in JavaScript, for example.

## asp-area

The [asp-area](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.area) attribute sets the area name used to set the appropriate route. The following example depicts how the area attribute causes a remapping of routes. Setting `asp-area` to "Blogs" prefixes the directory *Areas/Blogs* to the routes of the associated controllers and views for this anchor tag.

* **<Project name\>**
  * **wwwroot**
  * **Areas**
    * **Blogs**
      * **Controllers**
        * *HomeController.cs*
      * **Views**
        * **Home**
          * *AboutBlog.cshtml*
          * *Index.cshtml*
        * *_ViewStart.cshtml*
  * **Controllers**

Given the preceding directory hierarchy, the markup to reference the *AboutBlog.cshtml* file is:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspArea)]

The generated HTML:

```html
<a href="/Blogs/Home/AboutBlog">About Blog</a>
```

> [!TIP]
> For areas to work in an MVC app, the route template must include a reference to the area, if it exists. That template is represented by the second parameter of the `routes.MapRoute` method call in *Startup.Configure*:
[!code-csharp[](samples/TagHelpersBuiltInAspNetCore/Startup.cs?name=snippet_UseMvc&highlight=5)]

## asp-protocol

The [asp-protocol](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.protocol) attribute is for specifying a protocol (such as `https`) in your URL. For example:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspProtocol)]

The generated HTML:

```html
<a href="https://localhost/Home/About">About</a>
```

The host name in the example is localhost, but the Anchor Tag Helper uses the website's public domain when generating the URL.

## asp-host

The [asp-host](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.host) attribute is for specifying a host name in your URL. For example:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspHost)]

The generated HTML:

```html
<a href="https://microsoft.com/Home/About">About</a>
```

## asp-page

The [asp-page](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.page) attribute is used with Razor Pages. Use it to set an anchor tag's `href` attribute value to a specific page. Prefixing the page name with a forward slash ("/") creates the URL.

The following sample points to the attendee Razor Page:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspPage)]

The generated HTML:

```html
<a href="/Attendee">All Attendees</a>
```

The `asp-page` attribute is mutually exclusive with the `asp-route`, `asp-controller`, and `asp-action` attributes. However, `asp-page` can be used with `asp-route-{value}` to control routing, as the following markup demonstrates:

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspPageAspRouteId)]

The generated HTML:

```html
<a href="/Attendee?attendeeid=10">View Attendee</a>
```

## asp-page-handler

The [asp-page-handler](/dotnet/api/microsoft.aspnetcore.mvc.taghelpers.anchortaghelper.pagehandler) attribute is used with Razor Pages. It's intended for linking to specific page handlers.

Consider the following page handler:

[!code-csharp[](samples/TagHelpersBuiltInAspNetCore/Pages/Attendee.cshtml.cs?name=snippet_OnGetProfileHandler)]

The page model's associated markup links to the `OnGetProfile` page handler. Note that the `On<Verb>` prefix of the page handler method name is omitted in the `asp-page-handler` attribute value. If this were an asynchronous method, the `Async` suffix would be omitted too.

[!code-cshtml[](samples/TagHelpersBuiltInAspNetCore/Views/Home/Index.cshtml?name=snippet_AspPageHandler)]

The generated HTML:

```html
<a href="/Attendee?attendeeid=12&handler=Profile">Attendee Profile</a>
```

## Additional resources

* [Areas](xref:mvc/controllers/areas)
* [Intro to Razor Pages](xref:mvc/razor-pages/index)
