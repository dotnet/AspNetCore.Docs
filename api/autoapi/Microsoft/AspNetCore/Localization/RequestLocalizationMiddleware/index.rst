

RequestLocalizationMiddleware Class
===================================






Enables automatic setting of the culture for :any:`Microsoft.AspNetCore.Http.HttpRequest`\s based on information
sent by the client in headers and logic provided by the application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Localization`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware`








Syntax
------

.. code-block:: csharp

    public class RequestLocalizationMiddleware








.. dn:class:: Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware.RequestLocalizationMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.RequestLocalizationOptions>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware`\.
    
        
    
        
        :param next: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` representing the next middleware in the pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param options: The :any:`Microsoft.AspNetCore.Builder.RequestLocalizationOptions` representing the options for the 
            :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware`\.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.RequestLocalizationOptions<Microsoft.AspNetCore.Builder.RequestLocalizationOptions>}
    
        
        .. code-block:: csharp
    
            public RequestLocalizationMiddleware(RequestDelegate next, IOptions<RequestLocalizationOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Invokes the logic of the middleware.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that completes when the middleware has completed processing.
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

