

ExceptionHandlerExtensions Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.ExceptionHandlerExtensions`








Syntax
------

.. code-block:: csharp

   public class ExceptionHandlerExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/ExceptionHandler/ExceptionHandlerExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.ExceptionHandlerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.ExceptionHandlerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
    
        Adds a middleware to the pipeline that will catch exceptions, log them, and re-execute the request in an alternate pipeline.
        The request will not be re-executed if the response has already started.
    
        
        
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type configure: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseExceptionHandler(IApplicationBuilder app, Action<IApplicationBuilder> configure)
    
    .. dn:method:: Microsoft.AspNet.Builder.ExceptionHandlerExtensions.UseExceptionHandler(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
    
        Adds a middleware to the pipeline that will catch exceptions, log them, reset the request path, and re-execute the request.
        The request will not be re-executed if the response has already started.
    
        
        
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type errorHandlingPath: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseExceptionHandler(IApplicationBuilder app, string errorHandlingPath)
    

