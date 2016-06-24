

FormCollection Class
====================






Contains the parsed form values.


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
* :dn:cls:`Microsoft.AspNetCore.Http.FormCollection`








Syntax
------

.. code-block:: csharp

    public class FormCollection : IFormCollection, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Http.FormCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.FormCollection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.FormCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.FormCollection.FormCollection(System.Collections.Generic.Dictionary<System.String, Microsoft.Extensions.Primitives.StringValues>, Microsoft.AspNetCore.Http.IFormFileCollection)
    
        
    
        
        :type fields: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        :type files: Microsoft.AspNetCore.Http.IFormFileCollection
    
        
        .. code-block:: csharp
    
            public FormCollection(Dictionary<string, StringValues> fields, IFormFileCollection files = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.FormCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.ContainsKey(System.String)
    
        
    
        
        Determines whether the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains a specific key.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: true if the :any:`Microsoft.AspNetCore.Http.HeaderDictionary` contains a specific key; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.GetEnumerator()
    
        
    
        
        Returns an struct enumerator that iterates through a collection without boxing and is also used via the :any:`Microsoft.AspNetCore.Http.IFormCollection` interface.
    
        
        :rtype: Microsoft.AspNetCore.Http.FormCollection.Enumerator
        :return: An :any:`Microsoft.AspNetCore.Http.FormCollection.Enumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            public FormCollection.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection, boxes in non-empty path.
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
        :return: An :any:`System.Collections.IEnumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, StringValues>> IEnumerable<KeyValuePair<string, StringValues>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through a collection, boxes in non-empty path.
    
        
        :rtype: System.Collections.IEnumerator
        :return: An :any:`System.Collections.IEnumerator` object that can be used to iterate through the collection.
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
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

.. dn:class:: Microsoft.AspNetCore.Http.FormCollection
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.FormCollection.Empty
    
        
        :rtype: Microsoft.AspNetCore.Http.FormCollection
    
        
        .. code-block:: csharp
    
            public static readonly FormCollection Empty
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.FormCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.FormCollection.Count
    
        
    
        
        Gets the number of elements contained in the :any:`Microsoft.AspNetCore.Http.HeaderDictionary`\;.
    
        
        :rtype: System.Int32
        :return: The number of elements contained in the :any:`Microsoft.AspNetCore.Http.HeaderDictionary`\.
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.FormCollection.Files
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormFileCollection
    
        
        .. code-block:: csharp
    
            public IFormFileCollection Files { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.FormCollection.Item[System.String]
    
        
    
        
        Get or sets the associated value from the collection as a single string.
    
        
    
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: the associated value from the collection as a StringValues or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
            public StringValues this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.FormCollection.Keys
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Keys { get; }
    

