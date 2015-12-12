

RequestLocalizationMiddleware Class
===================================



.. contents:: 
   :local:



Summary
-------

Enables automatic setting of the culture for :any:`Microsoft.AspNet.Http.HttpRequest`\s based on information
sent by the client in headers and logic provided by the application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware`








Syntax
------

.. code-block:: csharp

   public class RequestLocalizationMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.AspNet.Localization/RequestLocalizationMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.RequestLocalizationMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Localization.RequestLocalizationMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Localization.RequestLocalizationMiddleware.RequestLocalizationMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Localization.RequestLocalizationOptions, Microsoft.AspNet.Localization.RequestCulture)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware`\.
    
        
        
        
        :param next: The  representing the next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param options: The  representing the options for the
            .
        
        :type options: Microsoft.AspNet.Localization.RequestLocalizationOptions
        
        
        :param defaultRequestCulture: The default  to use if none of the
            requested cultures match supported cultures.
        
        :type defaultRequestCulture: Microsoft.AspNet.Localization.RequestCulture
    
        
        .. code-block:: csharp
    
           public RequestLocalizationMiddleware(RequestDelegate next, RequestLocalizationOptions options, RequestCulture defaultRequestCulture)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Localization.RequestLocalizationMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Localization.RequestLocalizationMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Invokes the logic of the middleware.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that completes when the middleware has completed processing.
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

