

WebHostBuilderWebListenerExtensions Class
=========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Server.WebListener

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions`








Syntax
------

.. code-block:: csharp

    public class WebHostBuilderWebListenerExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions.UseWebListener(Microsoft.AspNetCore.Hosting.IWebHostBuilder)
    
        
    
        
        Specify WebListener as the server to be used by the web host.
    
        
    
        
        :param hostBuilder: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseWebListener(this IWebHostBuilder hostBuilder)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions.UseWebListener(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.Action<Microsoft.AspNetCore.Server.WebListener.WebListenerOptions>)
    
        
    
        
        Specify WebListener as the server to be used by the web host.
    
        
    
        
        :param hostBuilder: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param options: 
            A callback to configure WebListener options.
        
        :type options: System.Action<System.Action`1>{Microsoft.AspNetCore.Server.WebListener.WebListenerOptions<Microsoft.AspNetCore.Server.WebListener.WebListenerOptions>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: 
            The Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseWebListener(this IWebHostBuilder hostBuilder, Action<WebListenerOptions> options)
    

