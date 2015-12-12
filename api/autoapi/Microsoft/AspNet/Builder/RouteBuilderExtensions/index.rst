

RouteBuilderExtensions Class
============================



.. contents:: 
   :local:



Summary
-------

Provides extension methods for :any:`Microsoft.AspNet.Routing.IRouteBuilder` to add routes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.RouteBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class RouteBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/RouteBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.RouteBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.RouteBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.RouteBuilderExtensions.MapRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String)
    
        
    
        Adds a route to the :any:`Microsoft.AspNet.Routing.IRouteBuilder` with the specified name and template.
    
        
        
        
        :param routeBuilder: The  to add the route to.
        
        :type routeBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :param name: The name of the route.
        
        :type name: System.String
        
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapRoute(IRouteBuilder routeBuilder, string name, string template)
    
    .. dn:method:: Microsoft.AspNet.Builder.RouteBuilderExtensions.MapRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String, System.Object)
    
        
    
        Adds a route to the :any:`Microsoft.AspNet.Routing.IRouteBuilder` with the specified name, template, and default values.
    
        
        
        
        :param routeBuilder: The  to add the route to.
        
        :type routeBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :param name: The name of the route.
        
        :type name: System.String
        
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
        
        
        :param defaults: An object that contains default values for route parameters. The object's properties represent the names and values of the default values.
        
        :type defaults: System.Object
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapRoute(IRouteBuilder routeBuilder, string name, string template, object defaults)
    
    .. dn:method:: Microsoft.AspNet.Builder.RouteBuilderExtensions.MapRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object)
    
        
    
        Adds a route to the :any:`Microsoft.AspNet.Routing.IRouteBuilder` with the specified name, template, default values, and constraints.
    
        
        
        
        :param routeBuilder: The  to add the route to.
        
        :type routeBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :param name: The name of the route.
        
        :type name: System.String
        
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
        
        
        :param defaults: An object that contains default values for route parameters. The object's properties represent the names and values of the default values.
        
        :type defaults: System.Object
        
        
        :param constraints: An object that contains constraints for the route. The object's properties represent the names and values of the constraints.
        
        :type constraints: System.Object
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapRoute(IRouteBuilder routeBuilder, string name, string template, object defaults, object constraints)
    
    .. dn:method:: Microsoft.AspNet.Builder.RouteBuilderExtensions.MapRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object, System.Object)
    
        
    
        Adds a route to the :any:`Microsoft.AspNet.Routing.IRouteBuilder` with the specified name, template, default values, and data tokens.
    
        
        
        
        :param routeBuilder: The  to add the route to.
        
        :type routeBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :param name: The name of the route.
        
        :type name: System.String
        
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
        
        
        :param defaults: An object that contains default values for route parameters. The object's properties represent the names and values of the default values.
        
        :type defaults: System.Object
        
        
        :param constraints: An object that contains constraints for the route. The object's properties represent the names and values of the constraints.
        
        :type constraints: System.Object
        
        
        :param dataTokens: An object that contains data tokens for the route. The object's properties represent the names and values of the data tokens.
        
        :type dataTokens: System.Object
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapRoute(IRouteBuilder routeBuilder, string name, string template, object defaults, object constraints, object dataTokens)
    

