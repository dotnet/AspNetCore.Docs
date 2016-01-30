

HeaderCollection Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.HeaderCollection`








Syntax
------

.. code-block:: csharp

   public class HeaderCollection : IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/weblistener/blob/master/src/Microsoft.Net.Http.Server/RequestProcessing/HeaderCollection.cs>`_





.. dn:class:: Microsoft.Net.Http.Server.HeaderCollection

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Server.HeaderCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Server.HeaderCollection.HeaderCollection()
    
        
    
        
        .. code-block:: csharp
    
           public HeaderCollection()
    
    .. dn:constructor:: Microsoft.Net.Http.Server.HeaderCollection.HeaderCollection(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
        
        
        :type store: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public HeaderCollection(IDictionary<string, StringValues> store)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.HeaderCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.Add(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public void Add(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.Add(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public void Add(string key, StringValues value)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.Append(System.String, System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Append(string key, string value)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.Contains(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Contains(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.ContainsKey(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.CopyTo(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator()
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.GetValues(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> GetValues(string key)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.Remove(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.Remove(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(string key)
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.Net.Http.Server.HeaderCollection.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(string key, out StringValues value)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.HeaderCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.HeaderCollection.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.HeaderCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.HeaderCollection.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues this[string key] { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.HeaderCollection.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Keys { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.HeaderCollection.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           StringValues IDictionary<string, StringValues>.this[string key] { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.HeaderCollection.Values
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public ICollection<StringValues> Values { get; }
    

