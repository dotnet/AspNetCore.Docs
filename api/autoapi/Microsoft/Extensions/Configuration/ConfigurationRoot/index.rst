

ConfigurationRoot Class
=======================






The root node for a configuration.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationRoot`








Syntax
------

.. code-block:: csharp

    public class ConfigurationRoot : IConfigurationRoot, IConfiguration








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.ConfigurationRoot.ConfigurationRoot(System.Collections.Generic.IList<Microsoft.Extensions.Configuration.IConfigurationProvider>)
    
        
    
        
        Initializes a Configuration root with a list of providers.
    
        
    
        
        :param providers: The :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\s for this configuration.
        
        :type providers: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Configuration.IConfigurationProvider<Microsoft.Extensions.Configuration.IConfigurationProvider>}
    
        
        .. code-block:: csharp
    
            public ConfigurationRoot(IList<IConfigurationProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.GetChildren()
    
        
    
        
        Gets the immediate children sub-sections.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Configuration.IConfigurationSection<Microsoft.Extensions.Configuration.IConfigurationSection>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IConfigurationSection> GetChildren()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.GetReloadToken()
    
        
    
        
        Returns a :any:`Microsoft.Extensions.Primitives.IChangeToken` that can be used to observe when this configuration is reloaded.
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken GetReloadToken()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.GetSection(System.String)
    
        
    
        
        Gets a configuration sub-section with the specified key.
    
        
    
        
        :param key: The key of the configuration section.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationSection
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationSection`\.
    
        
        .. code-block:: csharp
    
            public IConfigurationSection GetSection(string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.Reload()
    
        
    
        
        Force the configuration values to be reloaded from the underlying sources.
    
        
    
        
        .. code-block:: csharp
    
            public void Reload()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationRoot.Item[System.String]
    
        
    
        
        Gets or sets the value corresponding to a configuration key.
    
        
    
        
        :param key: The configuration key.
        
        :type key: System.String
        :rtype: System.String
        :return: The configuration value.
    
        
        .. code-block:: csharp
    
            public string this[string key] { get; set; }
    

