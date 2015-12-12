

HeaderDictionary Class
======================



.. contents:: 
   :local:



Summary
-------

Represents a wrapper for owin.RequestHeaders and owin.ResponseHeaders.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.HeaderDictionary`








Syntax
------

.. code-block:: csharp

   public class HeaderDictionary : IHeaderDictionary, IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/HeaderDictionary.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.HeaderDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.HeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.HeaderDictionary.HeaderDictionary()
    
        
    
        
        .. code-block:: csharp
    
           public HeaderDictionary()
    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.HeaderDictionary.HeaderDictionary(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        Initializes a new instance of the :any:`Microsoft.Owin.HeaderDictionary` class.
    
        
        
        
        :param store: The underlying data store.
        
        :type store: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public HeaderDictionary(IDictionary<string, StringValues> store)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.HeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Add(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        Adds a new list of items to the collection.
    
        
        
        
        :param item: The item to add.
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public void Add(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Add(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        Adds the given header and values to the collection.
    
        
        
        
        :param key: The header name.
        
        :type key: System.String
        
        
        :param value: The header values.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public void Add(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Clear()
    
        
    
        Clears the entire list of objects.
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Contains(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        Returns a value indicating whether the specified object occurs within this collection.
    
        
        
        
        :param item: The item.
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}
        :rtype: System.Boolean
        :return: true if the specified object occurs within this collection; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool Contains(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.ContainsKey(System.String)
    
        
    
        Determines whether the :any:`Microsoft.Owin.HeaderDictionary` contains a specific key.
    
        
        
        
        :param key: The key.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: true if the <see cref="T:Microsoft.Owin.HeaderDictionary" /> contains a specific key; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.CopyTo(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
    
        Copies the :any:`Microsoft.Owin.HeaderDictionary` elements to a one-dimensional Array instance at the specified index.
    
        
        
        
        :param array: The one-dimensional Array that is the destination of the specified objects copied from the .
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}[]
        
        
        :param arrayIndex: The zero-based index in  at which copying begins.
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Remove(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        Removes the given item from the the collection.
    
        
        
        
        :param item: The item.
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}
        :rtype: System.Boolean
        :return: true if the specified object was removed from the collection; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool Remove(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Remove(System.String)
    
        
    
        Removes the given header from the collection.
    
        
        
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: true if the specified object was removed from the collection; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.GetEnumerator()
    
        
    
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}}
        :return: An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<string, StringValues>> IEnumerable<KeyValuePair<string, StringValues>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: System.Collections.IEnumerator
        :return: An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.HeaderDictionary.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        Retrieves a value from the dictionary.
    
        
        
        
        :param key: The header name.
        
        :type key: System.String
        
        
        :param value: The value.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
        :return: true if the <see cref="T:Microsoft.Owin.HeaderDictionary" /> contains the key; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(string key, out StringValues value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.HeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Count
    
        
    
        Gets the number of elements contained in the :any:`Microsoft.Owin.HeaderDictionary`\;.
    
        
        :rtype: System.Int32
        :return: The number of elements contained in the <see cref="T:Microsoft.Owin.HeaderDictionary" />.
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.HeaderDictionary.IsReadOnly
    
        
    
        Gets a value that indicates whether the :any:`Microsoft.Owin.HeaderDictionary` is in read-only mode.
    
        
        :rtype: System.Boolean
        :return: true if the <see cref="T:Microsoft.Owin.HeaderDictionary" /> is in read-only mode; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Item[System.String]
    
        
    
        Get or sets the associated value from the collection as a single string.
    
        
        
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: the associated value from the collection as a StringValues or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
           public StringValues this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Keys
    
        
    
        Gets an :any:`System.Collections.ICollection` that contains the keys in the :any:`Microsoft.Owin.HeaderDictionary`\;.
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
        :return: An <see cref="T:System.Collections.ICollection" /> that contains the keys in the <see cref="T:Microsoft.Owin.HeaderDictionary" />.
    
        
        .. code-block:: csharp
    
           public ICollection<string> Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.HeaderDictionary.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Item[System.String]
    
        
    
        Throws KeyNotFoundException if the key is not present.
    
        
        
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           StringValues IDictionary<string, StringValues>.this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.HeaderDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public ICollection<StringValues> Values { get; }
    

