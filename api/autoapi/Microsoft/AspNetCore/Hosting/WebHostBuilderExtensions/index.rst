

WebHostBuilderExtensions Class
==============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class WebHostBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.Configure(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Specify the startup method to be used to configure the web application.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param configureApp: The delegate that configures the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type configureApp: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder Configure(this IWebHostBuilder hostBuilder, Action<IApplicationBuilder> configureApp)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup(Microsoft.AspNetCore.Hosting.IWebHostBuilder, System.Type)
    
        
    
        
        Specify the startup type to be used by the web host. 
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        :param startupType: The :any:`System.Type` to be used.
        
        :type startupType: System.Type
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseStartup(this IWebHostBuilder hostBuilder, Type startupType)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup<TStartup>(Microsoft.AspNetCore.Hosting.IWebHostBuilder)
    
        
    
        
        Specify the startup type to be used by the web host.
    
        
    
        
        :param hostBuilder: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder` to configure.
        
        :type hostBuilder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :return: The :any:`Microsoft.AspNetCore.Hosting.IWebHostBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseStartup<TStartup>(this IWebHostBuilder hostBuilder)where TStartup : class
    

