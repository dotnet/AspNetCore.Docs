

TempDataDictionary Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary`








Syntax
------

.. code-block:: csharp

    public class TempDataDictionary : ITempDataDictionary, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.TempDataDictionary(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary` class.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param provider: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider` used to Load and Save data.
        
        :type provider: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider
    
        
        .. code-block:: csharp
    
            public TempDataDictionary(HttpContext context, ITempDataProvider provider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Add(System.String, System.Object)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void Add(string key, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.ContainsKey(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.ContainsValue(System.Object)
    
        
    
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ContainsValue(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Keep()
    
        
    
        
        .. code-block:: csharp
    
            public void Keep()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Keep(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Keep(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Load()
    
        
    
        
        .. code-block:: csharp
    
            public void Load()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Peek(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Peek(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Remove(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Save()
    
        
    
        
        .. code-block:: csharp
    
            public void Save()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Add(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
    
        
        :type keyValuePair: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> keyValuePair)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Contains(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
    
        
        :type keyValuePair: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> keyValuePair)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<System.String, System.Object>[], System.Int32)
    
        
    
        
        :type array: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}[]
    
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
            void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int index)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Remove(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
    
        
        :type keyValuePair: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> keyValuePair)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.TryGetValue(System.String, out System.Object)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(string key, out object value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Item[System.String]
    
        
    
        
        :type key: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Keys
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Keys { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<KeyValuePair<string, object>>.IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ICollection<object> Values { get; }
    

