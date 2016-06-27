

IConfiguration Interface
========================






Represents a set of key/value application configuration properties.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IConfiguration








.. dn:interface:: Microsoft.Extensions.Configuration.IConfiguration
    :hidden:

.. dn:interface:: Microsoft.Extensions.Configuration.IConfiguration

Methods
-------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfiguration.GetChildren()
    
        
    
        
        Gets the immediate descendant configuration sub-sections.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Configuration.IConfigurationSection<Microsoft.Extensions.Configuration.IConfigurationSection>}
        :return: The configuration sub-sections.
    
        
        .. code-block:: csharp
    
            IEnumerable<IConfigurationSection> GetChildren()
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfiguration.GetReloadToken()
    
        
    
        
        Returns a :any:`Microsoft.Extensions.Primitives.IChangeToken` that can be used to observe when this configuration is reloaded.
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
        :return: A :any:`Microsoft.Extensions.Primitives.IChangeToken`\.
    
        
        .. code-block:: csharp
    
            IChangeToken GetReloadToken()
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfiguration.GetSection(System.String)
    
        
    
        
        Gets a configuration sub-section with the specified key.
    
        
    
        
        :param key: The key of the configuration section.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationSection
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationSection`\.
    
        
        .. code-block:: csharp
    
            IConfigurationSection GetSection(string key)
    

Properties
----------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfiguration
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfiguration.Item[System.String]
    
        
    
        
        Gets or sets a configuration value.
    
        
    
        
        :param key: The configuration key.
        
        :type key: System.String
        :rtype: System.String
        :return: The configuration value.
    
        
        .. code-block:: csharp
    
            string this[string key] { get; set; }
    

