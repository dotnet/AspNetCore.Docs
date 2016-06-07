

RouteDirection Enum
===================






Indicates whether ASP.NET routing is processing a URL from an HTTP request or generating a URL.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum RouteDirection








.. dn:enumeration:: Microsoft.AspNetCore.Routing.RouteDirection
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Routing.RouteDirection

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Routing.RouteDirection
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Routing.RouteDirection.IncomingRequest
    
        
    
        
        A URL from a client is being processed.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteDirection
    
        
        .. code-block:: csharp
    
            IncomingRequest = 0
    
    .. dn:field:: Microsoft.AspNetCore.Routing.RouteDirection.UrlGeneration
    
        
    
        
        A URL is being created based on the route definition.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteDirection
    
        
        .. code-block:: csharp
    
            UrlGeneration = 1
    

