

DisableCorsAuthorizationFilter Class
====================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Filters.ICorsAuthorizationFilter` which ensures that an action does not run for a pre-flight request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Cors.DisableCorsAuthorizationFilter`








Syntax
------

.. code-block:: csharp

   public class DisableCorsAuthorizationFilter : ICorsAuthorizationFilter, IAsyncAuthorizationFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Cors/DisableCorsAuthorizationFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Cors.DisableCorsAuthorizationFilter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.DisableCorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Cors.DisableCorsAuthorizationFilter.OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task OnAuthorizationAsync(AuthorizationContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.DisableCorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Cors.DisableCorsAuthorizationFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

