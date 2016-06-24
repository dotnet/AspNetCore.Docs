

MapWhenOptions Class
====================






Options for the :any:`Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware`\.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions`








Syntax
------

.. code-block:: csharp

    public class MapWhenOptions








.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions.Branch
    
        
    
        
        The branch taken for a positive match.
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate Branch { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions.Predicate
    
        
    
        
        The user callback that determines if the branch should be taken.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.HttpContext<Microsoft.AspNetCore.Http.HttpContext>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<HttpContext, bool> Predicate { get; set; }
    

