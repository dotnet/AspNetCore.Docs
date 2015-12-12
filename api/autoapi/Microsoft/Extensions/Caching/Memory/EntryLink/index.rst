

EntryLink Class
===============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Caching.Memory.EntryLink`








Syntax
------

.. code-block:: csharp

   public class EntryLink : IEntryLink, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Memory/EntryLink.cs>`_





.. dn:class:: Microsoft.Extensions.Caching.Memory.EntryLink

Constructors
------------

.. dn:class:: Microsoft.Extensions.Caching.Memory.EntryLink
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Caching.Memory.EntryLink.EntryLink()
    
        
    
        
        .. code-block:: csharp
    
           public EntryLink()
    
    .. dn:constructor:: Microsoft.Extensions.Caching.Memory.EntryLink.EntryLink(Microsoft.Extensions.Caching.Memory.EntryLink)
    
        
        
        
        :type parent: Microsoft.Extensions.Caching.Memory.EntryLink
    
        
        .. code-block:: csharp
    
           public EntryLink(EntryLink parent)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Caching.Memory.EntryLink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.EntryLink.AddExpirationTokens(System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
        
        
        :type expirationTokens: System.Collections.Generic.IList{Microsoft.Extensions.Primitives.IChangeToken}
    
        
        .. code-block:: csharp
    
           public void AddExpirationTokens(IList<IChangeToken> expirationTokens)
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.EntryLink.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.Extensions.Caching.Memory.EntryLink.SetAbsoluteExpiration(System.DateTimeOffset)
    
        
        
        
        :type absoluteExpiration: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           public void SetAbsoluteExpiration(DateTimeOffset absoluteExpiration)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Caching.Memory.EntryLink
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.EntryLink.AbsoluteExpiration
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? AbsoluteExpiration { get; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.EntryLink.ExpirationTokens
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Primitives.IChangeToken}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IChangeToken> ExpirationTokens { get; }
    
    .. dn:property:: Microsoft.Extensions.Caching.Memory.EntryLink.Parent
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.EntryLink
    
        
        .. code-block:: csharp
    
           public EntryLink Parent { get; }
    

