

MvcAreaRouteBuilderExtensions Class
===================================






Extension methods for :any:`Microsoft.AspNetCore.Routing.IRouteBuilder`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcAreaRouteBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.String)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the given MVC area with the specified
        <em>name</em>, <em>areaName</em> and <em>template</em>.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param areaName: The MVC area name.
        
        :type areaName: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapAreaRoute(this IRouteBuilder routeBuilder, string name, string areaName, string template)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.String, System.Object)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the given MVC area with the specified
        <em>name</em>, <em>areaName</em>, <em>template</em>, and
        <em>defaults</em>.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param areaName: The MVC area name.
        
        :type areaName: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
    
        
        :param defaults: 
            An object that contains default values for route parameters. The object's properties represent the
            names and values of the default values.
        
        :type defaults: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapAreaRoute(this IRouteBuilder routeBuilder, string name, string areaName, string template, object defaults)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the given MVC area with the specified
        <em>name</em>, <em>areaName</em>, <em>template</em>, 
        <em>defaults</em>, and <em>constraints</em>.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param areaName: The MVC area name.
        
        :type areaName: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
    
        
        :param defaults: 
            An object that contains default values for route parameters. The object's properties represent the
            names and values of the default values.
        
        :type defaults: System.Object
    
        
        :param constraints: 
            An object that contains constraints for the route. The object's properties represent the names and
            values of the constraints.
        
        :type constraints: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapAreaRoute(this IRouteBuilder routeBuilder, string name, string areaName, string template, object defaults, object constraints)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.String, System.Object, System.Object, System.Object)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the given MVC area with the specified
        <em>name</em>, <em>areaName</em>, <em>template</em>, 
        <em>defaults</em>, <em>constraints</em>, and <em>dataTokens</em>.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param areaName: The MVC area name.
        
        :type areaName: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
    
        
        :param defaults: 
            An object that contains default values for route parameters. The object's properties represent the
            names and values of the default values.
        
        :type defaults: System.Object
    
        
        :param constraints: 
            An object that contains constraints for the route. The object's properties represent the names and
            values of the constraints.
        
        :type constraints: System.Object
    
        
        :param dataTokens: 
            An object that contains data tokens for the route. The object's properties represent the names and
            values of the data tokens.
        
        :type dataTokens: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapAreaRoute(this IRouteBuilder routeBuilder, string name, string areaName, string template, object defaults, object constraints, object dataTokens)
    

