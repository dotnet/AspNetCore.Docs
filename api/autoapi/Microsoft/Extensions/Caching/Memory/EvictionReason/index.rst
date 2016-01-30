

EvictionReason Enum
===================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public enum EvictionReason





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Abstractions/EvictionReason.cs>`_





.. dn:enumeration:: Microsoft.Extensions.Caching.Memory.EvictionReason

Fields
------

.. dn:enumeration:: Microsoft.Extensions.Caching.Memory.EvictionReason
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Capacity
    
        
    
        GC, overflow
    
        
    
        
        .. code-block:: csharp
    
           Capacity = 5
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Expired
    
        
    
        Timed out
    
        
    
        
        .. code-block:: csharp
    
           Expired = 3
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.None
    
        
    
        
        .. code-block:: csharp
    
           None = 0
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Removed
    
        
    
        Manually
    
        
    
        
        .. code-block:: csharp
    
           Removed = 1
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.Replaced
    
        
    
        Overwritten
    
        
    
        
        .. code-block:: csharp
    
           Replaced = 2
    
    .. dn:field:: Microsoft.Extensions.Caching.Memory.EvictionReason.TokenExpired
    
        
    
        Event
    
        
    
        
        .. code-block:: csharp
    
           TokenExpired = 4
    

