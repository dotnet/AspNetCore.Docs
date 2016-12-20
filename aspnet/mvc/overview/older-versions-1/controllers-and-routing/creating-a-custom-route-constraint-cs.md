---
title: "Creating a Custom Route Constraint (C#) | Microsoft Docs"
author: StephenWalther
description: "Stephen Walther demonstrates how you can create a custom route constraint. We implement a simple custom constraint that prevents a route from being matched w..."
ms.author: riande
manager: wpickett
ms.date: 02/16/2009
ms.topic: article
ms.assetid: 
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions-1/controllers-and-routing/creating-a-custom-route-constraint-cs
---
Creating a Custom Route Constraint (C#)
====================
by [Stephen Walther](https://github.com/StephenWalther)

> Stephen Walther demonstrates how you can create a custom route constraint. We implement a simple custom constraint that prevents a route from being matched when a browser request is made from a remote computer.


The goal of this tutorial is to demonstrate how you can create a custom route constraint. A custom route constraint enables you to prevent a route from being matched unless some custom condition is matched.

In this tutorial, we create a Localhost route constraint. The Localhost route constraint only matches requests made from the local computer. Remote requests from across the Internet are not matched.

You implement a custom route constraint by implementing the IRouteConstraint interface. This is an extremely simple interface which describes a single method:

    bool Match(
        HttpContextBase httpContext,
        Route route,
        string parameterName,
        RouteValueDictionary values,
        RouteDirection routeDirection
    )

The method returns a Boolean value. If you return false, the route associated with the constraint won't match the browser request.

The Localhost constraint is contained in Listing 1.

**Listing 1 - LocalhostConstraint.cs**

    using System.Web;
    using System.Web.Routing;
    namespace MvcApplication1.Constraints
    {
        public class LocalhostConstraint : IRouteConstraint
        {
            public bool Match
                (
                    HttpContextBase httpContext, 
                    Route route, 
                    string parameterName, 
                    RouteValueDictionary values, 
                    RouteDirection routeDirection
                )
            {
                return httpContext.Request.IsLocal;
            }
        }
    }

The constraint in Listing 1 takes advantage of the IsLocal property exposed by the HttpRequest class. This property returns true when the IP address of the request is either 127.0.0.1 or when the IP of the request is the same as the server's IP address.

You use a custom constraint within a route defined in the Global.asax file. The Global.asax file in Listing 2 uses the Localhost constraint to prevent anyone from requesting an Admin page unless they make the request from the local server. For example, a request for /Admin/DeleteAll will fail when made from a remote server.

**Listing 2 - Global.asax**

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcApplication1.Constraints;
    namespace MvcApplication1
    {
        public class MvcApplication : System.Web.HttpApplication
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRoute(
                    "Admin",
                    "Admin/{action}",
                    new {controller="Admin"},
                    new {isLocal=new LocalhostConstraint()}
                );
                //routes.MapRoute(
                //    "Default",                                              // Route name
                //    "{controller}/{action}/{id}",                           // URL with parameters
                //    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                //);
            }
            protected void Application_Start()
            {
                RegisterRoutes(RouteTable.Routes);
            }
        }
    }

The Localhost constraint is used in the definition of the Admin route. This route won't be matched by a remote browser request. Realize, however, that other routes defined in Global.asax might match the same request. It is important to understand that a constraint prevents a particular route from matching a request and not all routes defined in the Global.asax file.

Notice that the Default route has been commented out from the Global.asax file in Listing 2. If you include the Default route, then the Default route would match requests for the Admin controller. In that case, remote users could still invoke actions of the Admin controller even though their requests wouldn't match the Admin route.

>[!div class="step-by-step"] [Previous](creating-a-route-constraint-cs.md) [Next](asp-net-mvc-controller-overview-vb.md)