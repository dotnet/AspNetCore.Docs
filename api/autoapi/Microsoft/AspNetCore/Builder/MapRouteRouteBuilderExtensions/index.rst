

MapRouteRouteBuilderExtensions Class
====================================






Provides extension methods for :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add routes.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MapRouteRouteBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions.MapRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the specified name and template.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapRoute(this IRouteBuilder routeBuilder, string name, string template)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions.MapRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.Object)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the specified name, template, and default values.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
    
        
        :param defaults: 
            An object that contains default values for route parameters. The object's properties represent the names 
            and values of the default values.
        
        :type defaults: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapRoute(this IRouteBuilder routeBuilder, string name, string template, object defaults)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions.MapRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the specified name, template, default values, and
        constraints.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
    
        
        :param defaults: 
            An object that contains default values for route parameters. The object's properties represent the names
            and values of the default values.
        
        :type defaults: System.Object
    
        
        :param constraints: 
            An object that contains constraints for the route. The object's properties represent the names and values
            of the constraints.
        
        :type constraints: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapRoute(this IRouteBuilder routeBuilder, string name, string template, object defaults, object constraints)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions.MapRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object, System.Object)
    
        
    
        
        Adds a route to the :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` with the specified name, template, default values, and
        data tokens.
    
        
    
        
        :param routeBuilder: The :any:`Microsoft.AspNetCore.Routing.IRouteBuilder` to add the route to.
        
        :type routeBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :param name: The name of the route.
        
        :type name: System.String
    
        
        :param template: The URL pattern of the route.
        
        :type template: System.String
    
        
        :param defaults: 
            An object that contains default values for route parameters. The object's properties represent the names
            and values of the default values.
        
        :type defaults: System.Object
    
        
        :param constraints: 
            An object that contains constraints for the route. The object's properties represent the names and values
            of the constraints.
        
        :type constraints: System.Object
    
        
        :param dataTokens: 
            An object that contains data tokens for the route. The object's properties represent the names and values
            of the data tokens.
        
        :type dataTokens: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapRoute(this IRouteBuilder routeBuilder, string name, string template, object defaults, object constraints, object dataTokens)
    

