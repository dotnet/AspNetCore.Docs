

AuthorizeFilter Class
=====================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter`





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.AuthorizeFilter`








Syntax
------

.. code-block:: csharp

   public class AuthorizeFilter : IAsyncAuthorizationFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Filters/AuthorizeFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizeFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizeFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.AuthorizeFilter.AuthorizeFilter(Microsoft.AspNet.Authorization.AuthorizationPolicy)
    
        
    
        Authorize filter for a specific policy.
    
        
        
        
        :param policy: Authorization policy to be used.
        
        :type policy: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public AuthorizeFilter(AuthorizationPolicy policy)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizeFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.AuthorizeFilter.OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task OnAuthorizationAsync(AuthorizationContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizeFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.AuthorizeFilter.Policy
    
        
    
        Authorization policy to be used.
    
        
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicy Policy { get; }
    

