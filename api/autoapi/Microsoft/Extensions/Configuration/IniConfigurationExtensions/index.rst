

IniConfigurationExtensions Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.IniConfigurationExtensions`








Syntax
------

.. code-block:: csharp

   public class IniConfigurationExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.Ini/IniConfigurationExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.IniConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.IniConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        Adds the INI configuration provider at ``path`` to ``configurationBuilder``.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param path: Absolute path or path relative to  of
            .
        
        :type path: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddIniFile(IConfigurationBuilder configurationBuilder, string path)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String, System.Boolean)
    
        
    
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
    
           public static IConfigurationBuilder AddIniFile(IConfigurationBuilder configurationBuilder, string path, bool optional)
    

