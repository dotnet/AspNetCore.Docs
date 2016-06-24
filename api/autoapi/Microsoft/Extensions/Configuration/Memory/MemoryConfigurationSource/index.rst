

MemoryConfigurationSource Class
===============================






Represents in-memory data as an :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.


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
* :dn:cls:`Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource`








Syntax
------

.. code-block:: csharp

    public class MemoryConfigurationSource : IConfigurationSource








.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource.Build(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Builds the :any:`Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider` for this source.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationProvider
        :return: A :any:`Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider`
    
        
        .. code-block:: csharp
    
            public IConfigurationProvider Build(IConfigurationBuilder builder)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource.InitialData
    
        
    
        
        The initial key value configuration pairs.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
    
        
        .. code-block:: csharp
    
            public IEnumerable<KeyValuePair<string, string>> InitialData { get; set; }
    

