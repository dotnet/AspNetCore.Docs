

JsonConfigurationExtensions Class
=================================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.JsonConfigurationExtensions`








Syntax
------

.. code-block:: csharp

   public class JsonConfigurationExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.Json/JsonConfigurationExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        Adds the JSON configuration provider at ``path`` to ``configurationBuilder``.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param path: Absolute path or path relative to  of
            .
        
        :type path: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddJsonFile(IConfigurationBuilder configurationBuilder, string path)
    
    .. dn:method:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String, System.Boolean)
    
        
    
        Adds the JSON configuration provider at ``path`` to ``configurationBuilder``.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param path: Absolute path or path relative to  of
            .
        
        :type path: System.String
        
        
        :param optional: Determines if loading the configuration provider is optional.
        
        :type optional: System.Boolean
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddJsonFile(IConfigurationBuilder configurationBuilder, string path, bool optional)
    

