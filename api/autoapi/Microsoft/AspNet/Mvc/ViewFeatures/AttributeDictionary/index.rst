

AttributeDictionary Class
=========================



.. contents:: 
   :local:



Summary
-------

A dictionary for HTML attributes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary`








Syntax
------

.. code-block:: csharp

   public class AttributeDictionary : IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IReadOnlyDictionary<string, string>, IReadOnlyCollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/AttributeDictionary.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Add(System.Collections.Generic.KeyValuePair<System.String, System.String>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public void Add(KeyValuePair<string, string> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Add(System.String, System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Add(string key, string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Contains(System.Collections.Generic.KeyValuePair<System.String, System.String>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.String}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Contains(KeyValuePair<string, string> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.ContainsKey(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.CopyTo(System.Collections.Generic.KeyValuePair<System.String, System.String>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,System.String}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.GetEnumerator()
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    
        
        .. code-block:: csharp
    
           public AttributeDictionary.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Remove(System.Collections.Generic.KeyValuePair<System.String, System.String>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.String}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(KeyValuePair<string, string> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Remove(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,System.String}}
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.TryGetValue(System.String, out System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(string key, out string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.System.Collections.Generic.IReadOnlyDictionary<System.String, System.String>.Keys
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           IEnumerable<string> IReadOnlyDictionary<string, string>.Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.System.Collections.Generic.IReadOnlyDictionary<System.String, System.String>.Values
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           IEnumerable<string> IReadOnlyDictionary<string, string>.Values { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Values { get; }
    

