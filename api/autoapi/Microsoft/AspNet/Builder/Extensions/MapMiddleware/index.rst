

MapMiddleware Class
===================



.. contents:: 
   :local:



Summary
-------

Respresents a middleware that maps a request path to a sub-request pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.Extensions.MapMiddleware`








Syntax
------

.. code-block:: csharp

   public class MapMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/Extensions/MapMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Builder.Extensions.MapMiddleware.MapMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Builder.Extensions.MapOptions)
    
        
    
        Creates a new instace of :any:`Microsoft.AspNet.Builder.Extensions.MapMiddleware`\.
    
        
        
        
        :param next: The delegate representing the next middleware in the request pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param options: The middleware options.
        
        :type options: Microsoft.AspNet.Builder.Extensions.MapOptions
    
        
        .. code-block:: csharp
    
           public MapMiddleware(RequestDelegate next, MapOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.Extensions.MapMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.Extensions.MapMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Executes the middleware.
    
        
        
        
        :param context: The  for the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the execution of this middleware.
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

