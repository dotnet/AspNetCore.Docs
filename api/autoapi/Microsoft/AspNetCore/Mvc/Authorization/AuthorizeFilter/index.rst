

AuthorizeFilter Class
=====================






An implementation of :any:`Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter` which applies a specific
:any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy`\. MVC recognizes the :any:`Microsoft.AspNetCore.Authorization.AuthorizeAttribute` and adds an instance of
this filter to the associated action or controller.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Authorization`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter`








Syntax
------

.. code-block:: csharp

    public class AuthorizeFilter : IAsyncAuthorizationFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter.Policy
    
        
    
        
        Gets the authorization policy to be used.
    
        
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicy Policy
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter.AuthorizeFilter(Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        Initialize a new :any:`Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter` instance.
    
        
    
        
        :param policy: Authorization policy to be used.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public AuthorizeFilter(AuthorizationPolicy policy)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter.OnAuthorizationAsync(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task OnAuthorizationAsync(AuthorizationFilterContext context)
    

