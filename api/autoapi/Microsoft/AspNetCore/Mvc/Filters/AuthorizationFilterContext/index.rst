

AuthorizationFilterContext Class
================================






A context for authorization filters i.e. :any:`Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter` and 
:any:`Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter` implementations.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext`








Syntax
------

.. code-block:: csharp

    public class AuthorizationFilterContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext.AuthorizationFilterContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext` instance.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: All applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public AuthorizationFilterContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext.Result
    
        
    
        
        Gets or sets the result of the request. Setting :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext.Result` to a non-<code>null</code> value inside
        an authorization filter will short-circuit the remainder of the filter pipeline.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result { get; set; }
    

