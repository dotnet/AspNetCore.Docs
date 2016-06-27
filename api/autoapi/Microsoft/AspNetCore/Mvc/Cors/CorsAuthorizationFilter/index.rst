

CorsAuthorizationFilter Class
=============================






A filter that applies the given :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` and adds appropriate response headers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Cors`
Assemblies
    * Microsoft.AspNetCore.Mvc.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter`








Syntax
------

.. code-block:: csharp

    public class CorsAuthorizationFilter : ICorsAuthorizationFilter, IAsyncAuthorizationFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter.CorsAuthorizationFilter(Microsoft.AspNetCore.Cors.Infrastructure.ICorsService, Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter`\.
    
        
    
        
        :param corsService: The :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsService`\.
        
        :type corsService: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService
    
        
        :param policyProvider: The :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider`\.
        
        :type policyProvider: Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider
    
        
        .. code-block:: csharp
    
            public CorsAuthorizationFilter(ICorsService corsService, ICorsPolicyProvider policyProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter.OnAuthorizationAsync(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task OnAuthorizationAsync(AuthorizationFilterContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter.PolicyName
    
        
    
        
        The policy name used to fetch a :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PolicyName { get; set; }
    

