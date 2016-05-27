

RuntimeInfoMiddleware Class
===========================






Displays information about the packages used by the application at runtime


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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware`








Syntax
------

.. code-block:: csharp

    public class RuntimeInfoMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware.RuntimeInfoMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware` class
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions<Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions>}
    
        
        .. code-block:: csharp
    
            public RuntimeInfoMiddleware(RequestDelegate next, IOptions<RuntimeInfoPageOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.RuntimeInfoMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Process an individual request.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

