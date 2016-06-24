

RequestCookieCollection Class
=============================





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
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.RequestCookieCollection`








Syntax
------

.. code-block:: csharp

    public class RequestCookieCollection : IRequestCookieCollection, IEnumerable<KeyValuePair<string, string>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.RequestCookieCollection()
    
        
    
        
        .. code-block:: csharp
    
            public RequestCookieCollection()
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.RequestCookieCollection(System.Collections.Generic.Dictionary<System.String, System.String>)
    
        
    
        
        :type store: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public RequestCookieCollection(Dictionary<string, string> store)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.RequestCookieCollection(System.Int32)
    
        
    
        
        :type capacity: System.Int32
    
        
        .. code-block:: csharp
    
            public RequestCookieCollection(int capacity)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.ContainsKey(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.GetEnumerator()
    
        
    
        
        Returns an struct enumerator that iterates through a collection without boxing.
    
        
        :rtype: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator
        :return: An :any:`Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            public RequestCookieCollection.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Parse(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type values: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection
    
        
        .. code-block:: csharp
    
            public static RequestCookieCollection Parse(IList<string> values)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection, boxes in non-empty path.
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :return: An :any:`System.Collections.Generic.IEnumerator\`1` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection, boxes in non-empty path.
    
        
        :rtype: System.Collections.IEnumerator
        :return: An :any:`System.Collections.IEnumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.TryGetValue(System.String, out System.String)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(string key, out string value)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Empty
    
        
        :rtype: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection
    
        
        .. code-block:: csharp
    
            public static readonly RequestCookieCollection Empty
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Item[System.String]
    
        
    
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Keys
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Keys { get; }
    

