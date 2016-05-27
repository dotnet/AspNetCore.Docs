

MemoryConfigurationProvider Class
=================================





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
    
        
    
        
        :type source: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource
    
        
        .. code-block:: csharp
    
            public MemoryConfigurationProvider(MemoryConfigurationSource source)
    

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
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
    
        
        .. code-block:: csharp
    
            public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

