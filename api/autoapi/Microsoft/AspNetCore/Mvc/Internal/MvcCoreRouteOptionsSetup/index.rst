

MvcCoreRouteOptionsSetup Class
==============================






Sets up MVC default options for :any:`Microsoft.AspNetCore.Routing.RouteOptions`\.


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
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Routing.RouteOptions}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcCoreRouteOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcCoreRouteOptionsSetup : ConfigureOptions<RouteOptions>, IConfigureOptions<RouteOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreRouteOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreRouteOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreRouteOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreRouteOptionsSetup.MvcCoreRouteOptionsSetup()
    
        
    
        
        .. code-block:: csharp
    
            public MvcCoreRouteOptionsSetup()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreRouteOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreRouteOptionsSetup.ConfigureRouting(Microsoft.AspNetCore.Routing.RouteOptions)
    
        
    
        
        Configures the :any:`Microsoft.AspNetCore.Routing.RouteOptions`\.
    
        
    
        
        :param options: The :any:`Microsoft.AspNetCore.Routing.RouteOptions`\.
        
        :type options: Microsoft.AspNetCore.Routing.RouteOptions
    
        
        .. code-block:: csharp
    
            public static void ConfigureRouting(RouteOptions options)
    

