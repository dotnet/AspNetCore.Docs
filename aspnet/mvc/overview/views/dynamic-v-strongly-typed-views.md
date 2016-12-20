---
title: "Dynamic v. Strongly Typed Views | Microsoft Docs"
author: Rick-Anderson
description: ""
ms.author: riande
manager: wpickett
ms.date: 01/27/2011
ms.topic: article
ms.assetid: 
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/views/dynamic-v-strongly-typed-views
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\mvc\overview\views\dynamic-v-strongly-typed-views.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/24733) | [View dev content](http://docs.aspdev.net/tutorials/mvc/overview/views/dynamic-v-strongly-typed-views.html) | [View prod content](http://www.asp.net/mvc/overview/views/dynamic-v-strongly-typed-views) | Picker: 33035

Dynamic v. Strongly Typed Views
====================
by [Rick Anderson](https://github.com/Rick-Anderson)

There are three ways to pass information from a controller to a view in ASP.NET MVC 3:

1. As a strongly typed model object.
2. As a dynamic type (using @model dynamic)
3. Using the ViewBag

I've written a simple MVC 3 Top Blog application to compare and contrast dynamic and strongly typed views. The controller starts out with a simple list of blogs:

    using System.Collections.Generic;
    using System.Web.Mvc;
    
    namespace Mvc3ViewDemo.Controllers {
    
        public class Blog {
            public string Name;
            public string URL;
        }
    
        public class HomeController : Controller {
    
            List<Blog> topBlogs = new List<Blog>
          { 
              new Blog { Name = "ScottGu", URL = "https://weblogs.asp.net/scottgu/"},
              new Blog { Name = "Scott Hanselman", URL = "http://www.hanselman.com/blog/"},
              new Blog { Name = "Jon Galloway", URL = "https://www.asp.net/mvc"}
          };
    
            public ActionResult IndexNotStonglyTyped() {
                return View(topBlogs);
            }
    
            public ActionResult About() {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
                return View();
            }
        }
    }

Right click in the IndexNotStonglyTyped() method and add a Razor view.

[![8475.NotStronglyTypedView[1]](dynamic-v-strongly-typed-views/_static/image2.png)](dynamic-v-strongly-typed-views/_static/image1.png)

Make sure the **Create a strongly-typed view** box is not checked. The resulting view doesn't contain much:

    @{
        ViewBag.Title = "IndexNotStonglyTyped";
    }
    
    <h2>IndexNotStonglyTyped</h2>
    
    On the first line of the Views\Home\IndexNotStonglyTyped.cshtml file, add the model directive and the dynamic keyword.

    @model dynamic

Because we're using a dynamic and not a strongly typed view, intellisense doesn't help us. The completed code is shown below:

    @model dynamic
               
    @{
        ViewBag.Title = "IndexNotStonglyTyped";
    }
    
    <h2>Index Not Stongly Typed</h2>
    
    <p>
     <ul>
    @foreach (var blog in Model) {
       <li>
        <a href="@blog.URL">@blog.Name</a>
       </li>   
    }
     </ul>
    </p>

[![6646.NotStronglyTypedView_5F00_IE[1]](dynamic-v-strongly-typed-views/_static/image4.png)](dynamic-v-strongly-typed-views/_static/image3.png)

Now we'll add a strongly typed view. Add the following code to the controller:

    public ActionResult StonglyTypedIndex() {
        return View(topBlogs);
    }


Notice it's exactly the same return View(topBlogs); call as the non-strongly typed view. Right click inside of *StonglyTypedIndex()* and select **Add View**. This time select the **Blog** Model class and select **List** as the Scaffold template.

[![5658.StrongView[1]](dynamic-v-strongly-typed-views/_static/image6.png)](dynamic-v-strongly-typed-views/_static/image5.png)

Inside the new view template we get intellisense support.

[![7002.intellesince[1]](dynamic-v-strongly-typed-views/_static/image8.png)](dynamic-v-strongly-typed-views/_static/image7.png)

The c# project can be downloaded [here](https://blogs.msdn.com/cfs-file.ashx/__key/CommunityServer-Blogs-Components-WeblogFiles/00-00-01-11-73-SSMS/1817.Mvc3ViewDemo.zip).