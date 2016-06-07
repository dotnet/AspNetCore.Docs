

StatusCodePagesExtensions Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.StatusCodePagesExtensions`








Syntax
------

.. code-block:: csharp

    public class StatusCodePagesExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds a StatusCodePages middleware with a default response handler that checks for responses with status codes 
        between 400 and 599 that do not have a body.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStatusCodePages(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.StatusCodePagesOptions)
    
        
    
        
        Adds a StatusCodePages middleware with the given options that checks for responses with status codes 
        between 400 and 599 that do not have a body.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.StatusCodePagesOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStatusCodePages(IApplicationBuilder app, StatusCodePagesOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a StatusCodePages middleware to the pipeline with the specified alternate middleware pipeline to execute 
        to generate the response body.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type configuration: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStatusCodePages(IApplicationBuilder app, Action<IApplicationBuilder> configuration)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Func<Microsoft.AspNetCore.Diagnostics.StatusCodeContext, System.Threading.Tasks.Task>)
    
        
    
        
        Adds a StatusCodePages middleware with the specified handler that checks for responses with status codes 
        between 400 and 599 that do not have a body.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type handler: System.Func<System.Func`2>{Microsoft.AspNetCore.Diagnostics.StatusCodeContext<Microsoft.AspNetCore.Diagnostics.StatusCodeContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStatusCodePages(IApplicationBuilder app, Func<StatusCodeContext, Task> handler)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePages(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String, System.String)
    
        
    
        
        Adds a StatusCodePages middleware with the specified response body to send. This may include a '{0}' placeholder for the status code.
        The middleware checks for responses with status codes between 400 and 599 that do not have a body.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type contentType: System.String
    
        
        :type bodyFormat: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStatusCodePages(IApplicationBuilder app, string contentType, string bodyFormat)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithReExecute(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Adds a StatusCodePages middleware to the pipeline. Specifies that the response body should be generated by 
        re-executing the request pipeline using an alternate path. This path may contain a '{0}' placeholder of the status code.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type pathFormat: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStatusCodePagesWithReExecute(IApplicationBuilder app, string pathFormat)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StatusCodePagesExtensions.UseStatusCodePagesWithRedirects(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Adds a StatusCodePages middleware to the pipeline. Specifies that responses should be handled by redirecting 
        with the given location URL template. This may include a '{0}' placeholder for the status code. URLs starting 
        with '~' will have PathBase prepended, where any other URL will be used as is.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type locationFormat: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStatusCodePagesWithRedirects(IApplicationBuilder app, string locationFormat)
    

