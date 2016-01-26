

CorsAuthorizationFilter Class
=============================



.. contents:: 
   :local:



Summary
-------

A filter which applies the given :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicy` and adds appropriate response headers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter`








Syntax
------

.. code-block:: csharp

   public class CorsAuthorizationFilter : ICorsAuthorizationFilter, IAsyncAuthorizationFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Cors/CorsAuthorizationFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter.CorsAuthorizationFilter(Microsoft.AspNet.Cors.Infrastructure.ICorsService, Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter`\.
    
        
        
        
        :param corsService: The .
        
        :type corsService: Microsoft.AspNet.Cors.Infrastructure.ICorsService
        
        
        :param policyProvider: The .
        
        :type policyProvider: Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider
    
        
        .. code-block:: csharp
    
           public CorsAuthorizationFilter(ICorsService corsService, ICorsPolicyProvider policyProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter.OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task OnAuthorizationAsync(AuthorizationContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Cors.CorsAuthorizationFilter.PolicyName
    
        
    
        The policy name used to fetch a :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicy`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PolicyName { get; set; }
    

