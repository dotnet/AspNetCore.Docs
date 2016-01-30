

IEntryLink Interface
====================



.. contents:: 
   :local:



Summary
-------

Used to flow expiration information from one entry to another. :any:`Microsoft.Extensions.Primitives.IChangeToken` instances and minimum absolute
expiration will be copied from the dependent entry to the parent entry. The parent entry will not expire if the
dependent entry is removed manually, removed due to memory pressure, or expires due to sliding expiration.











Syntax
------

.. code-block:: csharp

   public interface IEntryLink : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Abstractions/IEntryLink.cs>`_





.. dn:interface:: Microsoft.Extensions.Caching.Memory.IEntryLink

Methods
-------

.. dn:interface:: Microsoft.Extensions.Caching.Memory.IEntryLink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IEntryLink.AddExpirationTokens(System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
    
        Adds :any:`Microsoft.Extensions.Primitives.IChangeToken` instances from a dependent entries.
    
        
        
        
        :param expirationTokens: instances from dependent entries.
        
        :type expirationTokens: System.Collections.Generic.IList{Microsoft.Extensions.Primitives.IChangeToken}
    
        
        .. code-block:: csharp
    
           void AddExpirationTokens(IList<IChangeToken> expirationTokens)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.IEntryLink.SetAbsoluteExpiration(System.DateTimeOffset)
    
        
    
        Sets the absolute expiration for from a dependent entry. The minimum value across all dependent entries
        will be used.
    
        
        
        
        :type absoluteExpiration: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           void SetAbsoluteExpiration(DateTimeOffset absoluteExpiration)
    

Properties
----------

.. dn:interface:: Microsoft.Extensions.Caching.Memory.IEntryLink
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.IEntryLink.AbsoluteExpiration
    
        
    
        Gets the minimum absolute expiration for all dependent entries, or null if not set.
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           DateTimeOffset? AbsoluteExpiration { get; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.IEntryLink.ExpirationTokens
    
        
    
        Gets all the :any:`Microsoft.Extensions.Primitives.IChangeToken` instances from the dependent entries.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Primitives.IChangeToken}
    
        
        .. code-block:: csharp
    
           IEnumerable<IChangeToken> ExpirationTokens { get; }
    

