

ConfigurationRoot Class
=======================





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

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationRoot.Item[System.String]
    
        
    
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string this[string key]
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.ConfigurationRoot.ConfigurationRoot(System.Collections.Generic.IList<Microsoft.Extensions.Configuration.IConfigurationProvider>)
    
        
    
        
        :type providers: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Configuration.IConfigurationProvider<Microsoft.Extensions.Configuration.IConfigurationProvider>}
    
        
        .. code-block:: csharp
    
            public ConfigurationRoot(IList<IConfigurationProvider> providers)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationRoot
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.GetChildren()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Configuration.IConfigurationSection<Microsoft.Extensions.Configuration.IConfigurationSection>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IConfigurationSection> GetChildren()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.GetReloadToken()
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken GetReloadToken()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.GetSection(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationSection
    
        
        .. code-block:: csharp
    
            public IConfigurationSection GetSection(string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationRoot.Reload()
    
        
    
        
        .. code-block:: csharp
    
            public void Reload()
    

