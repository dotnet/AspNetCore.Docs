

MapMiddleware Class
===================






Respresents a middleware that maps a request path to a sub-request pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder.Extensions`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.Extensions.MapMiddleware`








Syntax
------

.. code-block:: csharp

    public class MapMiddleware








.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.Extensions.MapMiddleware.MapMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Builder.Extensions.MapOptions)
    
        
    
        
        Creates a new instace of :any:`Microsoft.AspNetCore.Builder.Extensions.MapMiddleware`\.
    
        
    
        
        :param next: The delegate representing the next middleware in the request pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param options: The middleware options.
        
        :type options: Microsoft.AspNetCore.Builder.Extensions.MapOptions
    
        
        .. code-block:: csharp
    
            public MapMiddleware(RequestDelegate next, MapOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.Extensions.MapMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Executes the middleware.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the execution of this middleware.
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

