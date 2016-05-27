

RouteOptions Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteOptions`








Syntax
------

.. code-block:: csharp

    public class RouteOptions








.. dn:class:: Microsoft.AspNetCore.Routing.RouteOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteOptions.AppendTrailingSlash
    
        
    
        
        Gets or sets a value indicating whether a trailing slash should be appended to the generated URLs.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AppendTrailingSlash
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteOptions.ConstraintMap
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Type<System.Type>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, Type> ConstraintMap
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteOptions.LowercaseUrls
    
        
    
        
        Gets or sets a value indicating whether all generated URLs are lower-case.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool LowercaseUrls
            {
                get;
                set;
            }
    

