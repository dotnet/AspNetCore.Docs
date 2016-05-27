

MapWhenMiddleware Class
=======================






Respresents a middleware that runs a sub-request pipeline when a given predicate is matched.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware`








Syntax
------

.. code-block:: csharp

    public class MapWhenMiddleware








.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware.MapWhenMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware`\.
    
        
    
        
        :param next: The delegate representing the next middleware in the request pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param options: The middleware options.
        
        :type options: Microsoft.AspNetCore.Builder.Extensions.MapWhenOptions
    
        
        .. code-block:: csharp
    
            public MapWhenMiddleware(RequestDelegate next, MapWhenOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Executes the middleware.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the execution of this middleware.
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

