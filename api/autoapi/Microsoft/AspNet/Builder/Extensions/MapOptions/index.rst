

MapOptions Class
================



.. contents:: 
   :local:



Summary
-------

Options for the :any:`Microsoft.AspNet.Builder.Extensions.MapMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.Extensions.MapOptions`








Syntax
------

.. code-block:: csharp

   public class MapOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/Extensions/MapOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Builder.Extensions.MapOptions.Branch
    
        
    
        The branch taken for a positive match.
    
        
        :rtype: Microsoft.AspNet.Builder.RequestDelegate
    
        
        .. code-block:: csharp
    
           public RequestDelegate Branch { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Builder.Extensions.MapOptions.PathMatch
    
        
    
        The path to match.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString PathMatch { get; set; }
    

