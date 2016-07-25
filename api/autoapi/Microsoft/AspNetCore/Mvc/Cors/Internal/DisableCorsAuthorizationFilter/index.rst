

DisableCorsAuthorizationFilter Class
====================================






An :any:`Microsoft.AspNetCore.Mvc.Cors.Internal.ICorsAuthorizationFilter` which ensures that an action does not run for a pre-flight request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Cors.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter`








Syntax
------

.. code-block:: csharp

    public class DisableCorsAuthorizationFilter : ICorsAuthorizationFilter, IAsyncAuthorizationFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter.OnAuthorizationAsync(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task OnAuthorizationAsync(AuthorizationFilterContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

