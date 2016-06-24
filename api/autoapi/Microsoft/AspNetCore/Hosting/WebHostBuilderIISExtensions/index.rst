

WebHostBuilderIISExtensions Class
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Server.IISIntegration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions`








Syntax
------

.. code-block:: csharp

    public class WebHostBuilderIISExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions.UseIISIntegration(Microsoft.AspNetCore.Hosting.IWebHostBuilder)
    
        
    
        
        Configures the port and base path the server should listen on when running behind AspNetCoreModule.
        The app will also be configured to capture startup errors.
    
        
    
        
        :type app: Microsoft.AspNetCore.Hosting.IWebHostBuilder
        :rtype: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        .. code-block:: csharp
    
            public static IWebHostBuilder UseIISIntegration(this IWebHostBuilder app)
    

