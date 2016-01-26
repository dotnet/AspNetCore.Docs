

ReadableStringCollection Class
==============================



.. contents:: 
   :local:



Summary
-------

Accessors for query, forms, etc.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.ReadableStringCollection`








Syntax
------

.. code-block:: csharp

   public class ReadableStringCollection : IReadableStringCollection, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/ReadableStringCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.ReadableStringCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.ReadableStringCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.ReadableStringCollection(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        Create a new wrapper
    
        
        
        
        :type store: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public ReadableStringCollection(IDictionary<string, StringValues> store)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.ReadableStringCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.ContainsKey(System.String)
    
        
    
        Determines whether the collection contains an element with the specified key.
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Http.Internal.ReadableStringCollection
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.Empty
    
        
    
        
        .. code-block:: csharp
    
           public static readonly IReadableStringCollection Empty
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.ReadableStringCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.Count
    
        
    
        Gets the number of elements contained in the collection.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.Item[System.String]
    
        
    
        Get the associated value from the collection.  Multiple values will be merged.
        Returns StringValues.Empty if the key is not present.
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ReadableStringCollection.Keys
    
        
    
        Gets a collection containing the keys.
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Keys { get; }
    

