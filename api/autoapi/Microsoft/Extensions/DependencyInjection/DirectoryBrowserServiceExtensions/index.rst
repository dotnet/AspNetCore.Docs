

DirectoryBrowserServiceExtensions Class
=======================================






Extension methods for adding directory browser services.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions`








Syntax
------

.. code-block:: csharp

    public class DirectoryBrowserServiceExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds directory browser middleware services.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddDirectoryBrowser(IServiceCollection services)
    

