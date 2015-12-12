

MemoryConfigurationProvider Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider`








Syntax
------

.. code-block:: csharp

   public class MemoryConfigurationProvider : ConfigurationProvider, IConfigurationProvider, IEnumerable<KeyValuePair<string, string>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration/MemoryConfigurationProvider.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.MemoryConfigurationProvider()
    
        
    
        
        .. code-block:: csharp
    
           public MemoryConfigurationProvider()
    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.MemoryConfigurationProvider(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
        
        
        :type initialData: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}}
    
        
        .. code-block:: csharp
    
           public MemoryConfigurationProvider(IEnumerable<KeyValuePair<string, string>> initialData)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.Add(System.String, System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Add(string key, string value)
    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,System.String}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

