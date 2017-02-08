[Back To Built In Tag Helpers List](../../builtin.md)


# Anchor Tag Helper

By [Peter Kellner](http://peterkellner.net) 


The Anchor Tag Helper enhances the html anchor (`<a ... ></a>`) tag. A new set of attributes are defined that work with the anchor tag. The link generated (on the `href` tag) is based on a combination of these new attributes that work together to form the final URL. That URL can include an optional protocol such as https.

The speaker controller used in attribute definitions below is shown here.

<br/>
**SpeakerController.cs** 

[!code-csharp[SpeakerController](../sample/TagHelpersBuiltInAspNetCore/src/TagHelpersBuiltInAspNetCore/Controllers/SpeakerController.cs)]


## Anchor Tag Helper Attributes

- - -

### asp-controller

`asp-controller` is used to associate which controller will be used to generate the final URL. The only valid choices are controllers that exist in the current project. To get to a list of all speakers specifying `asp-controller="Speaker"` is required. If only the `asp-controller` and no `asp-action` is specified, the default asp-action will be the name of the the controller method calling this view page.

- - -
  
### asp-action

`asp-action` is the name of the method in the controller that will be included in the final URL. That is, in the example, if the route to the Speaker Detail page is wanted, then the attribute should be set to `asp-action=Detail`. You should always set `asp-controller` when specifying `asp-action`. If no `asp-action` is specified then the default `asp-controller` will be the current executing controller.

- - -
  
### asp-route-{value}

`asp-route-` is a wild card route prefix. Any value you put after the trailing dash will be interpreted as the parameter to pass into the route. For example, if a tag is created as follows: 

`<a  asp-controller="Speaker" asp-action="Detail" asp-route-id-="11">Speaker 11</a>`

the `href` generated will be 

`<a href="/Speaker/11">Speaker 11</a>` 

This is because a route was found that matched a single parameter "id" in the ```SpeakerController``` method ```Detail```. If there was no parameter match, say for example you created the tag helper 

`<a  asp-controller="Speaker" asp-action="Detail" asp-route-name-="Ronald">Ronald</a>`

you would get generated the html 

`<a href="/Speaker/Detail?Name=Ronald">Ronald</a>`

This is because there was no route found that matched a controller that had a method named `Detail` with one string parameter titled `name`.

- - -

### asp-route

`asp-route` provides a way to create a URL that links directly to a named route. Using routing attributes, a route can be named as shown in the `SpeakerController` and used in its `Evaluations` method.

`Name = "speakerevals"` tells the Anchor Tag Helper to generate a route directly to that controller method using the URL `/Speaker/Evaluations`. If `asp-controller` or `asp-action` is specified in addition to `asp-route`, the route generated may not be what you expect.  `asp-route` should not be used with either of the attributes `asp-controller` or `asp-action` to avoid a route conflict.

- - -

### asp-all-route-data

`asp-all-route-data` allows creating on a .NET context (that is, the running C# associated with your Razor view) a dictionary of key value pairs where the key is the parameter name and the value is the value associated with that key. 

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

The code that this generates looks as follows:

```
http://localhost/Speaker/EvaluationsCurrent?speakerId=11&currentYear=true
```

When the link is clicked, this will call the controller method `EvaluationsCurrent` because that controller has two string parameters that match what has been created from the `asp-all-route-data` dictionary.

- - -

### asp-fragment

`asp-fragment` defines a URL fragment to append to the URL. The Anchor Tag Helper will add the hash character (#) automatically. If you create a tag:

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

`asp-area` sets the area name that ASP.NET Core uses to set the appropriate route. Below are examples of how the area attribute causes a remapping of routes.  Setting `asp-area` to Blogs prefixes the directory Areas/Blogs to the routes of the associated controllers and views for this anchor tag..

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

The `asp-protocol` is for specifying a particular protocol (such as `https`) in your URL. An example Anchor Tag Helper that includes the protocol will look as follows.

```<a asp-protocol="https" asp-action="About" asp-controller="Home">About</a>```

and will generate HTML as follows.

```<a href="https://localhost/Home/About">About</a>```

The domain in the example is localhost, but the Anchor Tag Helper uses the website's public domain when generating the URL.

- - -

## Additional Resources

* [Areas](../../../../controllers/areas.md)




