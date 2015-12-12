

RouteValueDictionary Class
==========================



.. contents:: 
   :local:



Summary
-------

An :any:`System.Collections.Generic.IDictionary\`2` type for route values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteValueDictionary`








Syntax
------

.. code-block:: csharp

   public class RouteValueDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IReadOnlyDictionary<string, object>, IReadOnlyCollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/RouteValueDictionary.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteValueDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.RouteValueDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.RouteValueDictionary.RouteValueDictionary()
    
        
    
        Creates an empty :any:`Microsoft.AspNet.Routing.RouteValueDictionary`\.
    
        
    
        
        .. code-block:: csharp
    
           public RouteValueDictionary()
    
    .. dn:constructor:: Microsoft.AspNet.Routing.RouteValueDictionary.RouteValueDictionary(System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Routing.RouteValueDictionary` initialized with the specified ``values``.
    
        
        
        
        :param values: An object to initialize the dictionary. The value can be of type
            or
            or an object with public properties as key-value pairs.
        
        :type values: System.Object
    
        
        .. code-block:: csharp
    
           public RouteValueDictionary(object values)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.RouteValueDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.Add(System.String, System.Object)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Add(string key, object value)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.ContainsKey(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.Dictionary{System.String,System.Object}.Enumerator
    
        
        .. code-block:: csharp
    
           public Dictionary<string, object>.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.Remove(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Add(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Contains(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<System.String, System.Object>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,System.Object}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Remove(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteValueDictionary.TryGetValue(System.String, out System.Object)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(string key, out object value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.RouteValueDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.Comparer
    
        
    
        Gets the comparer for this dictionary.
    
        
        :rtype: System.Collections.Generic.IEqualityComparer{System.String}
    
        
        .. code-block:: csharp
    
           public IEqualityComparer<string> Comparer { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.Keys
    
        
        :rtype: System.Collections.Generic.Dictionary{System.String,System.Object}.KeyCollection
    
        
        .. code-block:: csharp
    
           public Dictionary<string, object>.KeyCollection Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<string, object>>.IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.IDictionary<System.String, System.Object>.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           ICollection<string> IDictionary<string, object>.Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.IDictionary<System.String, System.Object>.Values
    
        
        :rtype: System.Collections.Generic.ICollection{System.Object}
    
        
        .. code-block:: csharp
    
           ICollection<object> IDictionary<string, object>.Values { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.IReadOnlyDictionary<System.String, System.Object>.Keys
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           IEnumerable<string> IReadOnlyDictionary<string, object>.Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.System.Collections.Generic.IReadOnlyDictionary<System.String, System.Object>.Values
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Object}
    
        
        .. code-block:: csharp
    
           IEnumerable<object> IReadOnlyDictionary<string, object>.Values { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.RouteValueDictionary.Values
    
        
        :rtype: System.Collections.Generic.Dictionary{System.String,System.Object}.ValueCollection
    
        
        .. code-block:: csharp
    
           public Dictionary<string, object>.ValueCollection Values { get; }
    

