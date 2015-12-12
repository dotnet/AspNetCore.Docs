

MapWhenOptions Class
====================



.. contents:: 
   :local:



Summary
-------

Options for the :any:`Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.Extensions.MapWhenOptions`








Syntax
------

.. code-block:: csharp

   public class MapWhenOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/Extensions/MapWhenOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapWhenOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapWhenOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Builder.Extensions.MapWhenOptions.Branch
    
        
    
        The branch taken for a positive match.
    
        
        :rtype: Microsoft.AspNet.Builder.RequestDelegate
    
        
        .. code-block:: csharp
    
           public RequestDelegate Branch { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Builder.Extensions.MapWhenOptions.Predicate
    
        
    
        The user callback that determines if the branch should be taken.
    
        
        :rtype: System.Func{Microsoft.AspNet.Http.HttpContext,System.Boolean}
    
        
        .. code-block:: csharp
    
           public Func<HttpContext, bool> Predicate { get; set; }
    

