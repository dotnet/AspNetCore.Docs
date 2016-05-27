

IAsyncAuthorizationFilter Interface
===================================






A filter that asynchronously confirms request authorization.


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

    public interface IAsyncAuthorizationFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter.OnAuthorizationAsync(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        Called early in the filter pipeline to confirm request is authorized.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
        :rtype: System.Threading.Tasks.Task
        :return: 
            A :any:`System.Threading.Tasks.Task` that on completion indicates the filter has executed.
    
        
        .. code-block:: csharp
    
            Task OnAuthorizationAsync(AuthorizationFilterContext context)
    

