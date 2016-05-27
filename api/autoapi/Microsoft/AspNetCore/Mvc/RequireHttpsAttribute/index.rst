

RequireHttpsAttribute Class
===========================






An authorization filter that confirms requests are received over HTTPS.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.RequireHttpsAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class RequireHttpsAttribute : Attribute, _Attribute, IAuthorizationFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.RequireHttpsAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.RequireHttpsAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.RequireHttpsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RequireHttpsAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.RequireHttpsAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RequireHttpsAttribute.HandleNonHttpsRequest(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        Called from :dn:meth:`Microsoft.AspNetCore.Mvc.RequireHttpsAttribute.OnAuthorization(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)` if the request is not received over HTTPS. Expectation is
        :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext.Result` will not be <code>null</code> after this method returns.
    
        
    
        
        :param filterContext: The :any:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext` to update.
        
        :type filterContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        .. code-block:: csharp
    
            protected virtual void HandleNonHttpsRequest(AuthorizationFilterContext filterContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RequireHttpsAttribute.OnAuthorization(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        Called early in the filter pipeline to confirm request is authorized. Confirms requests are received over
        HTTPS. Takes no action for HTTPS requests. Otherwise if it was a GET request, sets
        :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext.Result` to a result which will redirect the client to the HTTPS
        version of the request URI. Otherwise, sets :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext.Result` to a result
        which will set the status code to <code>403</code> (Forbidden).
    
        
    
        
        :type filterContext: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        .. code-block:: csharp
    
            public virtual void OnAuthorization(AuthorizationFilterContext filterContext)
    

