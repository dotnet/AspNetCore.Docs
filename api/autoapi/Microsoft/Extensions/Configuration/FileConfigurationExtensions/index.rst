

FileConfigurationExtensions Class
=================================






Extension methods for :any:`Microsoft.Extensions.Configuration.FileConfigurationProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.FileExtensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationExtensions`








Syntax
------

.. code-block:: csharp

    public class FileConfigurationExtensions








.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationExtensions.GetFileProvider(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Gets the default :any:`Microsoft.Extensions.FileProviders.IFileProvider` to be used for file-based providers.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IFileProvider GetFileProvider(this IConfigurationBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        
        Sets the FileProvider for file-based providers to a PhysicalFileProvider with the base path.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param basePath: The absolute path of file-based providers.
        
        :type basePath: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder SetBasePath(this IConfigurationBuilder builder, string basePath)
    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetFileProvider(Microsoft.Extensions.Configuration.IConfigurationBuilder, Microsoft.Extensions.FileProviders.IFileProvider)
    
        
    
        
        Sets the default :any:`Microsoft.Extensions.FileProviders.IFileProvider` to be used for file-based providers.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param fileProvider: The default file provider instance.
        
        :type fileProvider: Microsoft.Extensions.FileProviders.IFileProvider
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder SetFileProvider(this IConfigurationBuilder builder, IFileProvider fileProvider)
    

