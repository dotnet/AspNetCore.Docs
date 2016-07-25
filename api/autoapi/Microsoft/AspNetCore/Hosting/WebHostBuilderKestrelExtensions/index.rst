

WebHostBuilderKestrelExtensions Class
=====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions`








Syntax
------

.. code-block:: csharp

    public class WebHostBuilderKestrelExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel(Microsoft.AspNetCore.Hosting.IWebHostBuilder)
    
        
    
        
        Specify Kestrel as the server to be used by the web host.
    
        
    
        
        :param hostBuilder: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseKestrel(this IWebHostBuilder hostBuilder)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.Action<Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions>)
    
        
    
        
        Specify Kestrel as the server to be used by the web host.
    
        
    
        
        :param hostBuilder: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param options: 
            A callback to configure Kestrel options.
        
        :type options: System.Action<System.Action`1>{Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions<Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseKestrel(this IWebHostBuilder hostBuilder, Action<KestrelServerOptions> options)
    

