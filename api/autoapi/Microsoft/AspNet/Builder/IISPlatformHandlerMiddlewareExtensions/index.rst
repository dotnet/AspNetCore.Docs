

IISPlatformHandlerMiddlewareExtensions Class
============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.IISPlatformHandlerMiddlewareExtensions`








Syntax
------

.. code-block:: csharp

   public class IISPlatformHandlerMiddlewareExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/iisintegration/blob/master/src/Microsoft.AspNet.IISPlatformHandler/IISPlatformHandlerMiddlewareExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.IISPlatformHandlerMiddlewareExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.IISPlatformHandlerMiddlewareExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.IISPlatformHandlerMiddlewareExtensions.UseIISPlatformHandler(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Adds middleware for interacting with the IIS HttpPlatformHandler reverse proxy module.
        This will handle forwarded Windows Authentication, request scheme, remote IPs, etc..
    
        
        
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseIISPlatformHandler(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNet.Builder.IISPlatformHandlerMiddlewareExtensions.UseIISPlatformHandler(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions)
    
        
    
        Adds middleware for interacting with the IIS HttpPlatformHandler reverse proxy module.
        This will handle forwarded Windows Authentication, request scheme, remote IPs, etc..
    
        
        
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseIISPlatformHandler(IApplicationBuilder app, IISPlatformHandlerOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.IISPlatformHandlerMiddlewareExtensions.UseIISPlatformHandler(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions>)
    
        
    
        Adds middleware for interacting with the IIS HttpPlatformHandler reverse proxy module.
        This will handle forwarded Windows Authentication, request scheme, remote IPs, etc..
    
        
        
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type configureOptions: System.Action{Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseIISPlatformHandler(IApplicationBuilder app, Action<IISPlatformHandlerOptions> configureOptions)
    

