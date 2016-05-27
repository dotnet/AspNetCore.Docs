

ElmCaptureMiddleware Class
==========================






Enables the Elm logging service.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware`








Syntax
------

.. code-block:: csharp

    public class ElmCaptureMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware.ElmCaptureMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>}
    
        
        .. code-block:: csharp
    
            public ElmCaptureMiddleware(RequestDelegate next, ILoggerFactory factory, IOptions<ElmOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

