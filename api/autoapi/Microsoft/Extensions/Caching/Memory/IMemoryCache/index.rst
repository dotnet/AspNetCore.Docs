

IMemoryCache Interface
======================






Represents a local in-memory cache whose values are not serialized.


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

    public interface IMemoryCache : IDisposable








.. dn:interface:: Microsoft.Extensions.Caching.Memory.IMemoryCache
    :hidden:

.. dn:interface:: Microsoft.Extensions.Caching.Memory.IMemoryCache

Methods
-------

.. dn:interface:: Microsoft.Extensions.Caching.Memory.IMemoryCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IMemoryCache.CreateEntry(System.Object)
    
        
    
        
        Create or overwrite an entry in the cache.
    
        
    
        
        :param key: An object identifying the entry.
        
        :type key: System.Object
        :rtype: Microsoft.Extensions.Caching.Memory.ICacheEntry
        :return: The newly created :any:`Microsoft.Extensions.Caching.Memory.ICacheEntry` instance.
    
        
        .. code-block:: csharp
    
            ICacheEntry CreateEntry(object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IMemoryCache.Remove(System.Object)
    
        
    
        
        Removes the object associated with the given key.
    
        
    
        
        :param key: An object identifying the entry.
        
        :type key: System.Object
    
        
        .. code-block:: csharp
    
            void Remove(object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IMemoryCache.TryGetValue(System.Object, out System.Object)
    
        
    
        
        Gets the item associated with this key if present.
    
        
    
        
        :param key: An object identifying the requested entry.
        
        :type key: System.Object
    
        
        :param value: The located value or null.
        
        :type value: System.Object
        :rtype: System.Boolean
        :return: True if the key was found.
    
        
        .. code-block:: csharp
    
            bool TryGetValue(object key, out object value)
    

