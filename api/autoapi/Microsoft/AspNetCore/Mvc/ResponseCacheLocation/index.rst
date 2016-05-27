

ResponseCacheLocation Enum
==========================






Determines the value for the "Cache-control" header in the response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum ResponseCacheLocation








.. dn:enumeration:: Microsoft.AspNetCore.Mvc.ResponseCacheLocation
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.ResponseCacheLocation

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.ResponseCacheLocation
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any
    
        
    
        
        Cached in both proxies and client.
        Sets "Cache-control" header to "public".
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ResponseCacheLocation
    
        
        .. code-block:: csharp
    
            Any = 0
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Client
    
        
    
        
        Cached only in the client.
        Sets "Cache-control" header to "private".
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ResponseCacheLocation
    
        
        .. code-block:: csharp
    
            Client = 1
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ResponseCacheLocation.None
    
        
    
        
        "Cache-control" and "Pragma" headers are set to "no-cache".
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ResponseCacheLocation
    
        
        .. code-block:: csharp
    
            None = 2
    

