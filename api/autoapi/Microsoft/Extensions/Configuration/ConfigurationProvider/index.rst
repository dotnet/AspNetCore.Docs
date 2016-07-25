

ConfigurationProvider Class
===========================






Base helper class for implementing an :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`


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
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`








Syntax
------

.. code-block:: csharp

    public abstract class ConfigurationProvider : IConfigurationProvider








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.ConfigurationProvider.ConfigurationProvider()
    
        
    
        
        Initializes a new :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`
    
        
    
        
        .. code-block:: csharp
    
            protected ConfigurationProvider()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationProvider.Data
    
        
    
        
        The configuration key value pairs for this provider.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            protected IDictionary<string, string> Data { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.GetChildKeys(System.Collections.Generic.IEnumerable<System.String>, System.String)
    
        
    
        
        Returns the list of keys that this provider has.
    
        
    
        
        :param earlierKeys: The earlier keys that other providers contain.
        
        :type earlierKeys: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        :param parentPath: The path for the parent IConfiguration.
        
        :type parentPath: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :return: The list of keys for this provider.
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.GetReloadToken()
    
        
    
        
        Returns a :any:`Microsoft.Extensions.Primitives.IChangeToken` that can be used to listen when this provider is reloaded.
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken GetReloadToken()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.Load()
    
        
    
        
        Loads (or reloads) the data for this provider.
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Load()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.OnReload()
    
        
    
        
        Triggers the reload change token and creates a new one.
    
        
    
        
        .. code-block:: csharp
    
            protected void OnReload()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.Set(System.String, System.String)
    
        
    
        
        Sets a value for a given key.
    
        
    
        
        :param key: The configuration key to set.
        
        :type key: System.String
    
        
        :param value: The value to set.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public virtual void Set(string key, string value)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.TryGet(System.String, out System.String)
    
        
    
        
        Attempts to find a value with the given key, returns true if one is found, false otherwise.
    
        
    
        
        :param key: The key to lookup.
        
        :type key: System.String
    
        
        :param value: The value found at key if one is found.
        
        :type value: System.String
        :rtype: System.Boolean
        :return: True if key has a value, false otherwise.
    
        
        .. code-block:: csharp
    
            public virtual bool TryGet(string key, out string value)
    

