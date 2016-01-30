

RouteOptions Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteOptions`








Syntax
------

.. code-block:: csharp

   public class RouteOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/RouteOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.RouteOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.RouteOptions.AppendTrailingSlash
    
        
    
        Gets or sets a value indicating whether a trailing slash should be appended to the generated URLs.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AppendTrailingSlash { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteOptions.ConstraintMap
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Type}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, Type> ConstraintMap { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteOptions.LowercaseUrls
    
        
    
        Gets or sets a value indicating whether all generated URLs are lower-case.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool LowercaseUrls { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteOptions.UseBestEffortLinkGeneration
    
        
    
        Gets or sets the value that enables best-effort link generation.
        
        
        If enabled, link generation will use allow link generation to succeed when the set of values provided
        cannot be validated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool UseBestEffortLinkGeneration { get; set; }
    

