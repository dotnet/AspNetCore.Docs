

ResponseCacheLocation Enum
==========================



.. contents:: 
   :local:



Summary
-------

Determines the value for the "Cache-control" header in the response.











Syntax
------

.. code-block:: csharp

   public enum ResponseCacheLocation





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ResponseCacheLocation.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Mvc.ResponseCacheLocation

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Mvc.ResponseCacheLocation
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ResponseCacheLocation.Any
    
        
    
        Cached in both proxies and client.
        Sets "Cache-control" header to "public".
    
        
    
        
        .. code-block:: csharp
    
           Any = 0
    
    .. dn:field:: Microsoft.AspNet.Mvc.ResponseCacheLocation.Client
    
        
    
        Cached only in the client.
        Sets "Cache-control" header to "private".
    
        
    
        
        .. code-block:: csharp
    
           Client = 1
    
    .. dn:field:: Microsoft.AspNet.Mvc.ResponseCacheLocation.None
    
        
    
        "Cache-control" and "Pragma" headers are set to "no-cache".
    
        
    
        
        .. code-block:: csharp
    
           None = 2
    

