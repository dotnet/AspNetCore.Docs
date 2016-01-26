

IMemoryCache Interface
======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IMemoryCache : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Abstractions/IMemoryCache.cs>`_





.. dn:interface:: Microsoft.Extensions.Caching.Memory.IMemoryCache

Methods
-------

.. dn:interface:: Microsoft.Extensions.Caching.Memory.IMemoryCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IMemoryCache.CreateLinkingScope()
    
        
    
        Creates an entry link scope.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IEntryLink
        :return: The <see cref="T:Microsoft.Extensions.Caching.Memory.IEntryLink" />.
    
        
        .. code-block:: csharp
    
           IEntryLink CreateLinkingScope()
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IMemoryCache.Remove(System.Object)
    
        
    
        Removes the object associated with the given key.
    
        
        
        
        :param key: An object identifying the entry.
        
        :type key: System.Object
    
        
        .. code-block:: csharp
    
           void Remove(object key)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IMemoryCache.Set(System.Object, System.Object, Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions)
    
        
    
        Create or overwrite an entry in the cache.
    
        
        
        
        :param key: An object identifying the entry.
        
        :type key: System.Object
        
        
        :param value: The value to be cached.
        
        :type value: System.Object
        
        
        :param options: The .
        
        :type options: Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions
        :rtype: System.Object
        :return: The object that was cached.
    
        
        .. code-block:: csharp
    
           object Set(object key, object value, MemoryCacheEntryOptions options)
    
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
    

