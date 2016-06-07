

IAuthorizationFilter Interface
==============================






A filter that confirms request authorization.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthorizationFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter.OnAuthorization(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        Called early in the filter pipeline to confirm request is authorized.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
    
        
        .. code-block:: csharp
    
            void OnAuthorization(AuthorizationFilterContext context)
    

