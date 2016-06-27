

HeaderDictionary Class
======================






Represents a wrapper for RequestHeaders and ResponseHeaders.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HeaderDictionary`








Syntax
------

.. code-block:: csharp

    public class HeaderDictionary : IHeaderDictionary, IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.HeaderDictionary.HeaderDictionary()
    
        
    
        
        .. code-block:: csharp
    
            public HeaderDictionary()
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.HeaderDictionary.HeaderDictionary(System.Collections.Generic.Dictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        :type store: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public HeaderDictionary(Dictionary<string, StringValues> store)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.HeaderDictionary.HeaderDictionary(System.Int32)
    
        
    
        
        :type capacity: System.Int32
    
        
        .. code-block:: csharp
    
            public HeaderDictionary(int capacity)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.Add(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        Adds a new list of items to the collection.
    
        
    
        
        :param item: The item to add.
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public void Add(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.Add(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        Adds the given header and values to the collection.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
    
        
        :param value: The header values.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public void Add(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.Clear()
    
        
    
        
        Clears the entire list of objects.
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.Contains(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        Returns a value indicating whether the specified object occurs within this collection.
    
        
    
        
        :param item: The item.
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
        :rtype: System.Boolean
        :return: true if the specified object occurs within this collection; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool Contains(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.ContainsKey(System.String)
    
        
    
        
        Determines whether the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains a specific key.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: true if the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains a specific key; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.CopyTo(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
    
        
        Copies the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` elements to a one-dimensional Array instance at the specified index.
    
        
    
        
        :param array: The one-dimensional Array that is the destination of the specified objects copied from the :any:`Microsoft.AspNetCore.Http.HeaderDictionary`\.
        
        :type array: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}[]
    
        
        :param arrayIndex: The zero-based index in <em>array</em> at which copying begins.
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            public void CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: Microsoft.AspNetCore.Http.HeaderDictionary.Enumerator
        :return: An :any:`Microsoft.AspNetCore.Http.HeaderDictionary.Enumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            public HeaderDictionary.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.Remove(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        Removes the given item from the the collection.
    
        
    
        
        :param item: The item.
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
        :rtype: System.Boolean
        :return: true if the specified object was removed from the collection; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool Remove(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.Remove(System.String)
    
        
    
        
        Removes the given header from the collection.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: true if the specified object was removed from the collection; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
        :return: An :any:`System.Collections.IEnumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, StringValues>> IEnumerable<KeyValuePair<string, StringValues>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: System.Collections.IEnumerator
        :return: An :any:`System.Collections.IEnumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionary.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        Retrieves a value from the dictionary.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
    
        
        :param value: The value.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
        :return: true if the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains the key; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(string key, out StringValues value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.HeaderDictionary.Count
    
        
    
        
        Gets the number of elements contained in the :any:`Microsoft.AspNetCore.Http.HeaderDictionary`\;.
    
        
        :rtype: System.Int32
        :return: The number of elements contained in the :any:`Microsoft.AspNetCore.Http.HeaderDictionary`\.
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HeaderDictionary.IsReadOnly
    
        
    
        
        Gets a value that indicates whether the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` is in read-only mode.
    
        
        :rtype: System.Boolean
        :return: true if the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` is in read-only mode; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HeaderDictionary.Item[System.String]
    
        
    
        
        Get or sets the associated value from the collection as a single string.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: the associated value from the collection as a StringValues or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
            public StringValues this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HeaderDictionary.Keys
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Keys { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HeaderDictionary.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Item[System.String]
    
        
    
        
        Throws KeyNotFoundException if the key is not present.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            StringValues IDictionary<string, StringValues>.this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HeaderDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public ICollection<StringValues> Values { get; }
    

