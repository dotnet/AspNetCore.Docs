

AttributeRouting Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRouting`








Syntax
------

.. code-block:: csharp

   public class AttributeRouting





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Routing/AttributeRouting.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRouting

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRouting
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.AttributeRouting.CreateAttributeMegaRoute(Microsoft.AspNet.Routing.IRouter, System.IServiceProvider)
    
        
    
        Creates an attribute route using the provided services and provided target router.
    
        
        
        
        :param target: The router to invoke when a route entry matches.
        
        :type target: Microsoft.AspNet.Routing.IRouter
        
        
        :param services: The application services.
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNet.Routing.IRouter
        :return: An attribute route.
    
        
        .. code-block:: csharp
    
           public static IRouter CreateAttributeMegaRoute(IRouter target, IServiceProvider services)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRouting
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Routing.AttributeRouting.RouteGroupKey
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string RouteGroupKey
    

