

IISPlatformHandlerMiddleware Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerMiddleware`








Syntax
------

.. code-block:: csharp

   public class IISPlatformHandlerMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/iisintegration/src/Microsoft.AspNet.IISPlatformHandler/IISPlatformHandlerMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerMiddleware.IISPlatformHandlerMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions
    
        
        .. code-block:: csharp
    
           public IISPlatformHandlerMiddleware(RequestDelegate next, IISPlatformHandlerOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext httpContext)
    

