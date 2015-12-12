

FileProviderExtensions Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.FileProviderExtensions`








Syntax
------

.. code-block:: csharp

   public class FileProviderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.FileProviderExtensions/ConfigurationRootExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.FileProviderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.FileProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.FileProviderExtensions.ReloadOnChanged(Microsoft.Extensions.Configuration.IConfigurationRoot, Microsoft.AspNet.FileProviders.IFileProvider, System.String)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfigurationRoot
        
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
        
        
        :type filename: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationRoot
    
        
        .. code-block:: csharp
    
           public static IConfigurationRoot ReloadOnChanged(IConfigurationRoot config, IFileProvider fileProvider, string filename)
    
    .. dn:method:: Microsoft.Extensions.Configuration.FileProviderExtensions.ReloadOnChanged(Microsoft.Extensions.Configuration.IConfigurationRoot, System.String)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfigurationRoot
        
        
        :type filename: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationRoot
    
        
        .. code-block:: csharp
    
           public static IConfigurationRoot ReloadOnChanged(IConfigurationRoot config, string filename)
    
    .. dn:method:: Microsoft.Extensions.Configuration.FileProviderExtensions.ReloadOnChanged(Microsoft.Extensions.Configuration.IConfigurationRoot, System.String, System.String)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfigurationRoot
        
        
        :type basePath: System.String
        
        
        :type filename: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationRoot
    
        
        .. code-block:: csharp
    
           public static IConfigurationRoot ReloadOnChanged(IConfigurationRoot config, string basePath, string filename)
    

