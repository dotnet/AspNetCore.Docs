

MapOptions Class
================






Options for the :any:`Microsoft.AspNetCore.Builder.Extensions.MapMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder.Extensions`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.Extensions.MapOptions`








Syntax
------

.. code-block:: csharp

    public class MapOptions








.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.Extensions.MapOptions.Branch
    
        
    
        
        The branch taken for a positive match.
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate Branch { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.Extensions.MapOptions.PathMatch
    
        
    
        
        The path to match.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString PathMatch { get; set; }
    

