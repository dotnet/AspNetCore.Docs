

EvictionReason Enum
===================





Namespace
    :dn:ns:`Microsoft.Extensions.Caching.Memory`
Assemblies
    * Microsoft.Extensions.Caching.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum EvictionReason








.. dn:enumeration:: Microsoft.Extensions.Caching.Memory.EvictionReason
    :hidden:

.. dn:enumeration:: Microsoft.Extensions.Caching.Memory.EvictionReason

Fields
------

.. dn:enumeration:: Microsoft.Extensions.Caching.Memory.EvictionReason
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Capacity
    
        
    
        
        GC, overflow
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.EvictionReason
    
        
        .. code-block:: csharp
    
            Capacity = 5
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Expired
    
        
    
        
        Timed out
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.EvictionReason
    
        
        .. code-block:: csharp
    
            Expired = 3
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.None
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.EvictionReason
    
        
        .. code-block:: csharp
    
            None = 0
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Removed
    
        
    
        
        Manually
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.EvictionReason
    
        
        .. code-block:: csharp
    
            Removed = 1
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Replaced
    
        
    
        
        Overwritten
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.EvictionReason
    
        
        .. code-block:: csharp
    
            Replaced = 2
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.TokenExpired
    
        
    
        
        Event
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.EvictionReason
    
        
        .. code-block:: csharp
    
            TokenExpired = 4
    

