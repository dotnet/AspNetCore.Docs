

AttributeRouting Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.AttributeRouting`








Syntax
------

.. code-block:: csharp

    public class AttributeRouting








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AttributeRouting
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AttributeRouting

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AttributeRouting
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.AttributeRouting.CreateAttributeMegaRoute(Microsoft.AspNetCore.Routing.IRouter, System.IServiceProvider)
    
        
    
        
        Creates an attribute route using the provided services and provided target router.
    
        
    
        
        :param target: The router to invoke when a route entry matches.
        
        :type target: Microsoft.AspNetCore.Routing.IRouter
    
        
        :param services: The application services.
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Routing.IRouter
        :return: An attribute route.
    
        
        .. code-block:: csharp
    
            public static IRouter CreateAttributeMegaRoute(IRouter target, IServiceProvider services)
    

