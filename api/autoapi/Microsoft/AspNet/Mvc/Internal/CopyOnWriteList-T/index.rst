

CopyOnWriteList<T> Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.CopyOnWriteList\<T>`








Syntax
------

.. code-block:: csharp

   public class CopyOnWriteList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/CopyOnWriteList.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.CopyOnWriteList(System.Collections.Generic.IReadOnlyList<T>)
    
        
        
        
        :type source: System.Collections.Generic.IReadOnlyList{{T}}
    
        
        .. code-block:: csharp
    
           public CopyOnWriteList(IReadOnlyList<T> source)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Add(T)
    
        
        
        
        :type item: {T}
    
        
        .. code-block:: csharp
    
           public void Add(T item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Contains(T)
    
        
        
        
        :type item: {T}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Contains(T item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.CopyTo(T[], System.Int32)
    
        
        
        
        :type array: {T}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(T[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{{T}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<T> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.IndexOf(T)
    
        
        
        
        :type item: {T}
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int IndexOf(T item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Insert(System.Int32, T)
    
        
        
        
        :type index: System.Int32
        
        
        :type item: {T}
    
        
        .. code-block:: csharp
    
           public void Insert(int index, T item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Remove(T)
    
        
        
        
        :type item: {T}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(T item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.RemoveAt(System.Int32)
    
        
        
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
           public void RemoveAt(int index)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Item[System.Int32]
    
        
        
        
        :type index: System.Int32
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T this[int index] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Readable
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{{T}}
    
        
        .. code-block:: csharp
    
           protected IReadOnlyList<T> Readable { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.CopyOnWriteList<T>.Writable
    
        
        :rtype: System.Collections.Generic.List{{T}}
    
        
        .. code-block:: csharp
    
           protected List<T> Writable { get; }
    

