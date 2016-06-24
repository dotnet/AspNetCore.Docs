

MemoryConfigurationProvider Class
=================================






In-memory implementation of :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration.Memory`
Assemblies
    * Microsoft.Extensions.Configuration

----

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








.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.MemoryConfigurationProvider(Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource)
    
        
    
        
        Initialize a new instance from the source.
    
        
    
        
        :param source: The source settings.
        
        :type source: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource
    
        
        .. code-block:: csharp
    
            public MemoryConfigurationProvider(MemoryConfigurationSource source)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.Add(System.String, System.String)
    
        
    
        
        Add a new key and value pair.
    
        
    
        
        :param key: The configuration key.
        
        :type key: System.String
    
        
        :param value: The configuration value.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public void Add(string key, string value)
    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through the collection.
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :return: An enumerator that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through the collection.
    
        
        :rtype: System.Collections.IEnumerator
        :return: An enumerator that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

