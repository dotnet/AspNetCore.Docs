

ExceptionHandlerExtensions Class
================================





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
* :dn:cls:`Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions`








Syntax
------

.. code-block:: csharp

    public class ExceptionHandlerExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds a middleware to the pipeline that will catch exceptions, log them, and re-execute the request in an alternate pipeline.
        The request will not be re-executed if the response has already started.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.ExceptionHandlerOptions)
    
        
    
        
        Adds a middleware to the pipeline that will catch exceptions, log them, and re-execute the request in an alternate pipeline.
        The request will not be re-executed if the response has already started.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.ExceptionHandlerOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app, ExceptionHandlerOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Adds a middleware to the pipeline that will catch exceptions, log them, and re-execute the request in an alternate pipeline.
        The request will not be re-executed if the response has already started.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type configure: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app, Action<IApplicationBuilder> configure)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Adds a middleware to the pipeline that will catch exceptions, log them, reset the request path, and re-execute the request.
        The request will not be re-executed if the response has already started.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type errorHandlingPath: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app, string errorHandlingPath)
    

