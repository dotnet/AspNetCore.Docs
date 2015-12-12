

ConfigurationBuilder Class
==========================



.. contents:: 
   :local:



Summary
-------

Used to build key/value based configuration settings for use in an application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationBuilder`








Syntax
------

.. code-block:: csharp

   public class ConfigurationBuilder : IConfigurationBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration/ConfigurationBuilder.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBuilder

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Add(Microsoft.Extensions.Configuration.IConfigurationProvider)
    
        
    
        Adds a new configuration provider.
    
        
        
        
        :param provider: The configuration provider to add.
        
        :type provider: Microsoft.Extensions.Configuration.IConfigurationProvider
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The same <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public IConfigurationBuilder Add(IConfigurationProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Add(Microsoft.Extensions.Configuration.IConfigurationProvider, System.Boolean)
    
        
    
        Adds a new provider to obtain configuration values from.
        This method is intended only for test scenarios.
    
        
        
        
        :param provider: The configuration provider to add.
        
        :type provider: Microsoft.Extensions.Configuration.IConfigurationProvider
        
        
        :param load: If true, the configuration provider's  method will
            be called.
        
        :type load: System.Boolean
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The same <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public IConfigurationBuilder Add(IConfigurationProvider provider, bool load)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Build()
    
        
    
        Builds an :any:`Microsoft.Extensions.Configuration.IConfiguration` with keys and values from the set of providers registered in 
        :dn:prop:`Microsoft.Extensions.Configuration.ConfigurationBuilder.Providers`\.
    
        
        :rtype: Microsoft.Extensions.Configuration.IConfigurationRoot
        :return: An <see cref="T:Microsoft.Extensions.Configuration.IConfigurationRoot" /> with keys and values from the registered providers.
    
        
        .. code-block:: csharp
    
           public IConfigurationRoot Build()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Properties
    
        
    
        Gets a key/value collection that can be used to share data between the :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`
        and the registered :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\s.
    
        
        :rtype: System.Collections.Generic.Dictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public Dictionary<string, object> Properties { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Providers
    
        
    
        Returns the providers used to obtain configuation values.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Configuration.IConfigurationProvider}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IConfigurationProvider> Providers { get; }
    

