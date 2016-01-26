

AuthorizationFilterAttribute Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute`








Syntax
------

.. code-block:: csharp

   public abstract class AuthorizationFilterAttribute : Attribute, _Attribute, IAsyncAuthorizationFilter, IAuthorizationFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Filters/AuthorizationFilterAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute.Fail(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
    
        
        .. code-block:: csharp
    
           protected virtual void Fail(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute.HasAllowAnonymous(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual bool HasAllowAnonymous(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute.OnAuthorization(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
    
        
        .. code-block:: csharp
    
           public virtual void OnAuthorization(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute.OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task OnAuthorizationAsync(AuthorizationContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.AuthorizationFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

