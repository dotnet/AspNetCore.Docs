

IConfigurationProvider Interface
================================






Provides configuration key/values for an application.


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

    public interface IConfigurationProvider








.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationProvider
    :hidden:

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationProvider

Methods
-------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationProvider.GetChildKeys(System.Collections.Generic.IEnumerable<System.String>, System.String)
    
        
    
        
        Returns the immediate descendant configuration keys for a given parent path based on this 
        :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\'s data and the set of keys returned by all the preceding 
        :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\s.
    
        
    
        
        :param earlierKeys: The child keys returned by the preceding providers for the same parent path.
        
        :type earlierKeys: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        :param parentPath: The parent path.
        
        :type parentPath: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :return: The child keys.
    
        
        .. code-block:: csharp
    
            IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationProvider.GetReloadToken()
    
        
    
        
        Returns a change token if this provider supports change tracking, null otherwise.
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            IChangeToken GetReloadToken()
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationProvider.Load()
    
        
    
        
        Loads configuration values from the source represented by this :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\.
    
        
    
        
        .. code-block:: csharp
    
            void Load()
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationProvider.Set(System.String, System.String)
    
        
    
        
        Sets a configuration value for the specified key.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
    
        
        :param value: The value.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            void Set(string key, string value)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationProvider.TryGet(System.String, out System.String)
    
        
    
        
        Tries to get a configuration value for the specified key.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
    
        
        :param value: The value.
        
        :type value: System.String
        :rtype: System.Boolean
        :return: <code>True</code> if a value for the specified key was found, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            bool TryGet(string key, out string value)
    

