---
title: Anchor Tag Helper | Microsoft Docs
author: pkellner
description: Shows how to work with Anchor Tag Helper
keywords: ASP.NET Core,tag helper
ms.author: riande
manager: wpickett
ms.date: 02/14/2017
ms.topic: article
ms.assetid: c045d485-d1dc-4cea-a675-46be83b7a011
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/views/tag-helpers/builtin-th/AnchorTagHelper
---
# Anchor Tag Helper

By [Peter Kellner](http://peterkellner.net) 

The Anchor Tag Helper enhances the HTML anchor (`<a ... ></a>`) tag by adding new attributes. The link generated (on the `href` tag) is created using the new attributes. That URL can include an optional protocol such as https.

The speaker controller below is used in samples in this document.

<br/>
**SpeakerController.cs** 

[!code-csharp[SpeakerController](sample/TagHelpersBuiltInAspNetCore/src/TagHelpersBuiltInAspNetCore/Controllers/SpeakerController.cs)]


## Anchor Tag Helper Attributes

- - -

### asp-controller

`asp-controller` is used to associate which controller will be used to generate the URL. The controllers specified must exist in the current project. The following code lists all speakers: 

```cshtml
<a asp-controller="Speaker" asp-action="Index">All Speakers</a>
```

The generated markup will be:

```html
<a href="/Speaker">All Speakers</a>
```

If the `asp-controller` is specified and `asp-action` is not, the default `asp-action` will be the default controller method of the currently executing view. That is, in the above example, if `asp-action` is left out, and this Anchor Tag Helper is generated from *HomeController*'s `Index` view (**/Home**), the generated markup will be:


```html
<a href="/Home">All Speakers</a>
```

- - -
  
### asp-action

`asp-action` is the name of the action method in the controller that will be included in the generated `href`. For example, the following code set the generated `href` to point to the speaker detail page:

```html
<a asp-controller="Speaker" asp-action="Detail">Speaker Detail</a>
```

The generated markup will be:

```html
<a href="/Speaker/Detail">Speaker Detail</a>
```

If no `asp-controller` attribute is specified, the default controller calling the view executing the current view will be used.  
 
If the attribute `asp-action` is `Index`, then no action is appended to the URL, leading to the default `Index` method being called. The action specified (or defaulted), must exist in the controller referenced in `asp-controller`.

- - -
  
<a name="route"></a>
### asp-route-{value}

`asp-route-` is a wild card route prefix. Any value you put after the trailing dash will be interpreted as a potential route parameter. If a default route is not found, this route prefix will be appended to the generated href as a request parameter and value. Otherwise it will be substituted in the route template.

Assuming you have a controller method defined as follows:

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

And have the default route template defined in your *Startup.cs* as follows:

```csharp
app.UseMvc(routes =>
{
   routes.MapRoute(
    name: "default",
    template: "{controller=Home}/{action=Index}/{id?}");
});

```

The **cshtml** file that contains the Anchor Tag Helper necessary to use the **speaker** model parameter passed in from the controller to the view is as follows:

```cshtml
@model SpeakerData
<!DOCTYPE html>
<html><body>
<a asp-controller='Speaker' asp-action='Detail' asp-route-id=@Model.SpeakerId>SpeakerId: @Model.SpeakerId</a>
<body></html>
```

The generated HTML will then be as follows because **id** was found in the default route.

```html
<a href='/Speaker/Detail/12'>SpeakerId: 12</a>
```

If the route prefix is not part of the routing template found, which is the case with the following **cshtml** file:

```cshtml
@model SpeakerData
<!DOCTYPE html>
<html><body>
<a asp-controller='Speaker' asp-action='Detail' asp-route-speakerid=@Model.SpeakerId>SpeakerId: @Model.SpeakerId</a>
<body></html>
```

The generated HTML will then be as follows because **speakerid** was not found in the route matched:


```html
<a href='/Speaker/Detail?speakerid=12'>SpeakerId: 12</a>
```

If either `asp-controller` or `asp-action` are not specified, then the same default processing is followed as is in the `asp-route` attribute.

- - -

### asp-route

`asp-route` provides a way to create a URL that links directly to a named route. Using routing attributes, a route can be named as shown in the `SpeakerController` and used in its `Evaluations` method.

`Name = "speakerevals"` tells the Anchor Tag Helper to generate a route directly to that controller method using the URL `/Speaker/Evaluations`. If `asp-controller` or `asp-action` is specified in addition to `asp-route`, the route generated may not be what you expect. `asp-route` should not be used with either of the attributes `asp-controller` or `asp-action` to avoid a route conflict.

- - -

### asp-all-route-data

`asp-all-route-data` allows creating a dictionary of key value pairs where the key is the parameter name and the value is the value associated with that key.

As the example below shows, an inline dictionary is created and the data is passed to the razor view. As an alternative, the data could also be passed in with your model.

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

The code above generates the following URL: http://localhost/Speaker/EvaluationsCurrent?speakerId=11&currentYear=true

When the link is clicked, the controller method `EvaluationsCurrent` is called. It is called because that controller has two string parameters that match what has been created from the `asp-all-route-data` dictionary.

If any keys in the dictionary match route parameters, those values will be substituted in the route as appropriate and the other non-matching values will be generated as request parameters.

- - -

### asp-fragment

`asp-fragment` defines a URL fragment to append to the URL. The Anchor Tag Helper will add the hash character (#). If you create a tag:

```cshtml
<a asp-action="Evaluations" asp-controller="Speaker"  
   asp-fragment="SpeakerEvaluations">About Speaker Evals</a>
```

The generated URL will be: http://localhost/Speaker/Evaluations#SpeakerEvaluations

Hash tags are useful when building client-side applications. They can be used for easy marking and searching in JavaScript, for example.

- - -

### asp-area

`asp-area` sets the area name that ASP.NET Core uses to set the appropriate route. Below are examples of how the area attribute causes a remapping of routes. Setting `asp-area` to Blogs prefixes the directory `Areas/Blogs` to the routes of the associated controllers and views for this anchor tag.

* Project name

  * *wwwroot*

  * *Areas*

    * *Blogs*

      * *Controllers*

        * *HomeController.cs*

      * *Views*

        * *Home*

          * *Index.cshtml*
          
          * *AboutBlog.cshtml*
          
  * *Controllers*
  

        
Specifying an area tag that is valid, such as ```area="Blogs"``` when referencing the ```AboutBlog.cshtml``` file will look like the following using the Anchor Tag Helper.

```cshtml
<a asp-action="AboutBlog" asp-controller="Home" asp-area="Blogs">Blogs About</a>
```

The generated HTML will include the areas segment and will be as follows:

```html
<a href="/Blogs/Home/AboutBlog">Blogs About</a>
```

> [!TIP]
> For MVC areas to work in a web application, the route template must include a reference to the area if it exists. That template, which is the second parameter of the `routes.MapRoute` method call, will appear as: `template: '"{area:exists}/{controller=Home}/{action=Index}"'`

- - -

### asp-protocol

The `asp-protocol` is for specifying a protocol (such as `https`) in your URL. An example Anchor Tag Helper that includes the protocol will look as follows:

```<a asp-protocol="https" asp-action="About" asp-controller="Home">About</a>```

and will generate HTML as follows:

```<a href="https://localhost/Home/About">About</a>```

The domain in the example is localhost, but the Anchor Tag Helper uses the website's public domain when generating the URL.

- - -

## Additional resources

* [Areas](xref:mvc/controllers/areas)