

RequestCookiesCollection Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.RequestCookiesCollection`








Syntax
------

.. code-block:: csharp

   public class RequestCookiesCollection : IReadableStringCollection, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/RequestCookiesCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.RequestCookiesCollection()
    
        
    
        
        .. code-block:: csharp
    
           public RequestCookiesCollection()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.ContainsKey(System.String)
    
        
    
        Determines whether the collection contains an element with the specified key.
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.Get(System.String)
    
        
    
        Get the associated value from the collection.  Multiple values will be merged.
        Returns null if the key is not present.
    
        
        
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Get(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.GetValues(System.String)
    
        
    
        Get the associated values from the collection in their original format.
        Returns null if the key is not present.
    
        
        
        
        :type key: System.String
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> GetValues(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.Reparse(System.Collections.Generic.IList<System.String>)
    
        
        
        
        :type values: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public void Reparse(IList<string> values)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.Count
    
        
    
        Gets the number of elements contained in the collection.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.RequestCookiesCollection.Keys
    
        
    
        Gets a collection containing the keys.
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Keys { get; }
    

