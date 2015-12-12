

IConfigurationProvider Interface
================================



.. contents:: 
   :local:



Summary
-------

Represents a source of configuration key/values for an application.











Syntax
------

.. code-block:: csharp

   public interface IConfigurationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.Abstractions/IConfigurationProvider.cs>`_





.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationProvider

Methods
-------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationProvider.GetChildKeys(System.Collections.Generic.IEnumerable<System.String>, System.String, System.String)
    
        
    
        Returns the immediate descendant configuration keys for a given parent path based on this 
        :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\'s data and the set of keys returned by all the preceding 
        :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\s.
    
        
        
        
        :param earlierKeys: The child keys returned by the preceding providers for the same parent path.
        
        :type earlierKeys: System.Collections.Generic.IEnumerable{System.String}
        
        
        :param parentPath: The parent path.
        
        :type parentPath: System.String
        
        
        :param delimiter: The delimiter to use to identify keys in the 's data.
        
        :type delimiter: System.String
        :rtype: System.Collections.Generic.IEnumerable{System.String}
        :return: The child keys.
    
        
        .. code-block:: csharp
    
           IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath, string delimiter)
    
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
        :return: <c>True</c> if a value for the specified key was found, otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           bool TryGet(string key, out string value)
    

