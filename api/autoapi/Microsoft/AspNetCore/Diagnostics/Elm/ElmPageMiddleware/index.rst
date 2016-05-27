

ElmPageMiddleware Class
=======================






Enables viewing logs captured by the :any:`Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware`\.


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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware`








Syntax
------

.. code-block:: csharp

    public class ElmPageMiddleware








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware.ElmPageMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>, Microsoft.AspNetCore.Diagnostics.Elm.ElmStore)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>}
    
        
        :type store: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore
    
        
        .. code-block:: csharp
    
            public ElmPageMiddleware(RequestDelegate next, IOptions<ElmOptions> options, ElmStore store)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

