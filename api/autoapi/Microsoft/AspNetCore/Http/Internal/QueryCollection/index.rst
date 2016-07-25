

QueryCollection Class
=====================






The HttpRequest query string collection


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.QueryCollection`








Syntax
------

.. code-block:: csharp

    public class QueryCollection : IQueryCollection, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Http.Internal.QueryCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.QueryCollection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.QueryCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.QueryCollection.QueryCollection()
    
        
    
        
        .. code-block:: csharp
    
            public QueryCollection()
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.QueryCollection.QueryCollection(Microsoft.AspNetCore.Http.Internal.QueryCollection)
    
        
    
        
        :type store: Microsoft.AspNetCore.Http.Internal.QueryCollection
    
        
        .. code-block:: csharp
    
            public QueryCollection(QueryCollection store)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.QueryCollection.QueryCollection(System.Collections.Generic.Dictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        :type store: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public QueryCollection(Dictionary<string, StringValues> store)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.QueryCollection.QueryCollection(System.Int32)
    
        
    
        
        :type capacity: System.Int32
    
        
        .. code-block:: csharp
    
            public QueryCollection(int capacity)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.QueryCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.QueryCollection.ContainsKey(System.String)
    
        
    
        
        Determines whether the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains a specific key.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: true if the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains a specific key; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.QueryCollection.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: Microsoft.AspNetCore.Http.Internal.QueryCollection.Enumerator
        :return: An :any:`Microsoft.AspNetCore.Http.Internal.QueryCollection.Enumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            public QueryCollection.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.QueryCollection.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
        :return: An :any:`System.Collections.Generic.IEnumerator\`1` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, StringValues>> IEnumerable<KeyValuePair<string, StringValues>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.QueryCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection.
    
        
        :rtype: System.Collections.IEnumerator
        :return: An :any:`System.Collections.IEnumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.QueryCollection.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        Retrieves a value from the dictionary.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
    
        
        :param value: The value.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
        :return: true if the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains the key; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(string key, out StringValues value)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.QueryCollection
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.Internal.QueryCollection.Empty
    
        
        :rtype: Microsoft.AspNetCore.Http.Internal.QueryCollection
    
        
        .. code-block:: csharp
    
            public static readonly QueryCollection Empty
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.QueryCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.QueryCollection.Count
    
        
    
        
        Gets the number of elements contained in the :any:`Microsoft.AspNetCore.Http.HeaderDictionary`\;.
    
        
        :rtype: System.Int32
        :return: The number of elements contained in the :any:`Microsoft.AspNetCore.Http.HeaderDictionary`\.
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.QueryCollection.Item[System.String]
    
        
    
        
        Get or sets the associated value from the collection as a single string.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: the associated value from the collection as a StringValues or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
            public StringValues this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.QueryCollection.Keys
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Keys { get; }
    

