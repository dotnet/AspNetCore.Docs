

MvcCoreRouteOptionsSetup Class
==============================



.. contents:: 
   :local:



Summary
-------

Sets up MVC default options for :any:`Microsoft.AspNet.Routing.RouteOptions`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Routing.RouteOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.MvcCoreRouteOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class MvcCoreRouteOptionsSetup : ConfigureOptions<RouteOptions>, IConfigureOptions<RouteOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Internal/MvcCoreRouteOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.MvcCoreRouteOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.MvcCoreRouteOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.MvcCoreRouteOptionsSetup.MvcCoreRouteOptionsSetup()
    
        
    
        
        .. code-block:: csharp
    
           public MvcCoreRouteOptionsSetup()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.MvcCoreRouteOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.MvcCoreRouteOptionsSetup.ConfigureRouting(Microsoft.AspNet.Routing.RouteOptions)
    
        
    
        Configures the :any:`Microsoft.AspNet.Routing.RouteOptions`\.
    
        
        
        
        :param options: The .
        
        :type options: Microsoft.AspNet.Routing.RouteOptions
    
        
        .. code-block:: csharp
    
           public static void ConfigureRouting(RouteOptions options)
    

