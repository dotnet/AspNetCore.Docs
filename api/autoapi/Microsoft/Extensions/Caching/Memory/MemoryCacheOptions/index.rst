

MemoryCacheOptions Class
========================





Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Memory

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Memory.MemoryCacheOptions`








Syntax
------

.. code-block:: csharp

    public class MemoryCacheOptions : IOptions<MemoryCacheOptions>








.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions
    :hidden:

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.Clock
    
        
        :rtype: Microsoft.Extensions.Internal.ISystemClock
    
        
        .. code-block:: csharp
    
            public ISystemClock Clock { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.CompactOnMemoryPressure
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CompactOnMemoryPressure { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.ExpirationScanFrequency
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan ExpirationScanFrequency { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Caching.Memory.MemoryCacheOptions>.Value
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.MemoryCacheOptions
    
        
        .. code-block:: csharp
    
            MemoryCacheOptions IOptions<MemoryCacheOptions>.Value { get; }
    

