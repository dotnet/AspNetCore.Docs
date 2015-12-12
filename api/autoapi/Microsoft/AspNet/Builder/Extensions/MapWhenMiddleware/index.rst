

MapWhenMiddleware Class
=======================



.. contents:: 
   :local:



Summary
-------

Respresents a middleware that runs a sub-request pipeline when a given predicate is matched.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware`








Syntax
------

.. code-block:: csharp

   public class MapWhenMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/Extensions/MapWhenMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware.MapWhenMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Builder.Extensions.MapWhenOptions)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware`\.
    
        
        
        
        :param next: The delegate representing the next middleware in the request pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param options: The middleware options.
        
        :type options: Microsoft.AspNet.Builder.Extensions.MapWhenOptions
    
        
        .. code-block:: csharp
    
           public MapWhenMiddleware(RequestDelegate next, MapWhenOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Executes the middleware.
    
        
        
        
        :param context: The  for the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the execution of this middleware.
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

