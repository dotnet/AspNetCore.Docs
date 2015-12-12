

StatusCodePagesMiddleware Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.StatusCodePagesMiddleware`








Syntax
------

.. code-block:: csharp

   public class StatusCodePagesMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/StatusCodePage/StatusCodePagesMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodePagesMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodePagesMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.StatusCodePagesMiddleware.StatusCodePagesMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Diagnostics.StatusCodePagesOptions)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions
    
        
        .. code-block:: csharp
    
           public StatusCodePagesMiddleware(RequestDelegate next, StatusCodePagesOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodePagesMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.StatusCodePagesMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

