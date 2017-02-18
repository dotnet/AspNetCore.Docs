---
title: Anchor Tag Helper | Microsoft Docs
author: Peter Kellner
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


The Anchor Tag Helper enhances the html anchor (`<a ... ></a>`) tag by adding new attributes. The link generated (on the `href` tag) is created using the new attributes. That URL can include an optional protocol such as https.

The speaker controller below is used in samples in this document.

<br/>
**SpeakerController.cs** 

[!code-csharp[SpeakerController](sample/TagHelpersBuiltInAspNetCore/src/TagHelpersBuiltInAspNetCore/Controllers/SpeakerController.cs)]


## Anchor Tag Helper Attributes

- - -

### asp-controller

`asp-controller` is used to associate which controller will be used to generate the URL. The controllers specified must exist in the current project. The following code lists all speakers: [TODO complete markup]
`asp-controller="Speaker"` is required.

If the `asp-controller` is specifed and `asp-action` is not, the default asp-action will be the controller method calling the view.

- - -
  
### asp-action

`asp-action` is the name of the action method in the controller that will be included in the final URL. For example, the folowing code gets the route to the Speaker Detail page:
TODO Complete markup `asp-action=Detail`. 
 `asp-controller` is required when specifying `asp-action`.
- - -
  
### asp-route-{value}

`asp-route-` is a wild card route prefix. Any value you put after the trailing dash will be interpreted as the parameter to pass into the route. The following code:
[REVIEW - Doesn't this depend on the default route? ]
`<a  asp-controller="Speaker" asp-action="Detail" asp-route-id-="11">Speaker 11</a>`

[REVIEW - consider passing in @model.SpeakerID rather than hard coded values]

generates the following HTML:

`<a href="/Speaker/11">Speaker 11</a>` 

A route was found that matched a single parameter "id" in the ```SpeakerController``` method ```Detail```. 

In the following example, there is no matching parameter:

`<a  asp-controller="Speaker" asp-action="Detail" asp-route-name-="Ronald">Ronald</a>`

Which generates the following HTML:

`<a href="/Speaker/Detail?Name=Ronald">Ronald</a>`

There was no route found that matched a controller that had a method named `Detail` with one string parameter titled `name`.

- - -

### asp-route

`asp-route` provides a way to create a URL that links directly to a named route. Using routing attributes, a route can be named as shown in the `SpeakerController` and used in its `Evaluations` method.

`Name = "speakerevals"` tells the Anchor Tag Helper to generate a route directly to that controller method using the URL `/Speaker/Evaluations`. If `asp-controller` or `asp-action` is specified in addition to `asp-route`, the route generated may not be what you expect.  `asp-route` should not be used with either of the attributes `asp-controller` or `asp-action` to avoid a route conflict.

- - -

### asp-all-route-data

`asp-all-route-data` allows creating on a .NET context (that is, the running C# associated with your Razor view) a dictionary of key value pairs where the key is the parameter name and the value is the value associated with that key. 

Can't you just say:
`asp-all-route-data` allows creating a dictionary of key value pairs where the key is the parameter name and the value is the value associated with that key.

[If not you need to explain that better in shorter sentences.]

As the example below shows, an inline dictionary is created and the data is passed to the razor view. The data could also be passed in with your model to keep the Razor view simpler.

```
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

The code above generates the following HTML:

```
http://localhost/Speaker/EvaluationsCurrent?speakerId=11&currentYear=true
```

When the link is clicked, the controller method `EvaluationsCurrent`is called: It is called because that controller has two string parameters that match what has been created from the `asp-all-route-data` dictionary.

- - -

### asp-fragment

`asp-fragment` defines a URL fragment to append to the URL. The Anchor Tag Helper will add the hash character (#). If you create a tag:

```
<a asp-action="Evaluations" asp-controller="Speaker"  
   asp-fragment="SpeakerEvaluations">About Speaker Evals</a>
```

The generated URL will be


```
http://localhost/Speaker/Evaluations#SpeakerEvaluations
```

Hash tags are useful when doing client side applications. They can be used for easy marking and searching in JavaScript for example.

- - -

### asp-area

`asp-area` sets the area name that ASP.NET Core uses to set the appropriate route. Below are examples of how the area attribute causes a remapping of routes.  Setting `asp-area` to Blogs prefixes the directory `Areas/Blogs` to the routes of the associated controllers and views for this anchor tag.

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

```
<a asp-action="AboutBlog" asp-controller="Home" asp-area="Blogs">Blogs About</a>
```

The generated HTML will include the areas segment and will be as follows:

```
<a href="/Blogs/Home/AboutBlog">Blogs About</a>
```

> [!TIP]
> For MVC areas to work in a web application, the route template must include a reference to the area if it exists. That template, which is the second parameter of the `routes.MapRoute` method call, will appear as: template: '"{area:exists}/{controller=Home}/{action=Index}"'

- - -

### asp-protocol

The `asp-protocol` is for specifying a  protocol (such as `https`) in your URL. An example Anchor Tag Helper that includes the protocol will look as follows.

```<a asp-protocol="https" asp-action="About" asp-controller="Home">About</a>```

and will generate HTML as follows.

```<a href="https://localhost/Home/About">About</a>```

The domain in the example is localhost, but the Anchor Tag Helper uses the website's public domain when generating the URL.

- - -

## Additional resources

* [Areas](xref:mvc/controllers/areas)




