

RouteDirection Enum
===================



.. contents:: 
   :local:



Summary
-------

Indicates whether ASP.NET routing is processing a URL from an HTTP request or generating a URL.











Syntax
------

.. code-block:: csharp

   public enum RouteDirection





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/RouteDirection.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Routing.RouteDirection

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Routing.RouteDirection
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Routing.RouteDirection.IncomingRequest
    
        
    
        A URL from a client is being processed.
    
        
    
        
        .. code-block:: csharp
    
           IncomingRequest = 0
    
    .. dn:field:: Microsoft.AspNet.Routing.RouteDirection.UrlGeneration
    
        
    
        A URL is being created based on the route definition.
    
        
    
        
        .. code-block:: csharp
    
           UrlGeneration = 1
    

