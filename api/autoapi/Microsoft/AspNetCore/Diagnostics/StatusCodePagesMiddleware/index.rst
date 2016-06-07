

StatusCodePagesMiddleware Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware`








Syntax
------

.. code-block:: csharp

    public class StatusCodePagesMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware.StatusCodePagesMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.StatusCodePagesOptions>)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.StatusCodePagesOptions<Microsoft.AspNetCore.Builder.StatusCodePagesOptions>}
    
        
        .. code-block:: csharp
    
            public StatusCodePagesMiddleware(RequestDelegate next, IOptions<StatusCodePagesOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.StatusCodePagesMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

