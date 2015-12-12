

RequireHttpsAttribute Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.RequireHttpsAttribute`








Syntax
------

.. code-block:: csharp

   public class RequireHttpsAttribute : Attribute, _Attribute, IAuthorizationFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/RequireHttpsAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.RequireHttpsAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.RequireHttpsAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.RequireHttpsAttribute.HandleNonHttpsRequest(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type filterContext: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
    
        
        .. code-block:: csharp
    
           protected virtual void HandleNonHttpsRequest(AuthorizationContext filterContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.RequireHttpsAttribute.OnAuthorization(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type filterContext: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
    
        
        .. code-block:: csharp
    
           public virtual void OnAuthorization(AuthorizationContext filterContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.RequireHttpsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.RequireHttpsAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

