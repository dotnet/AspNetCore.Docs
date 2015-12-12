

FileConfigurationExtensions Class
=================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration.FileExtensions/FileConfigurationExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationExtensions.GetBasePath(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        Gets the base path to discover files in for file-based providers.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: System.String
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static string GetBasePath(IConfigurationBuilder configurationBuilder)
    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        Sets the base path to discover files in for file-based providers.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param basePath: The absolute path of file-based providers.
        
        :type basePath: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder SetBasePath(IConfigurationBuilder configurationBuilder, string basePath)
    

