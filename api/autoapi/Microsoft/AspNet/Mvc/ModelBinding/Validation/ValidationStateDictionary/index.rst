

ValidationStateDictionary Class
===============================



.. contents:: 
   :local:



Summary
-------

Used for tracking validation state to customize validation behavior for a model object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary`








Syntax
------

.. code-block:: csharp

   public class ValidationStateDictionary : IDictionary<object, ValidationStateEntry>, ICollection<KeyValuePair<object, ValidationStateEntry>>, IReadOnlyDictionary<object, ValidationStateEntry>, IReadOnlyCollection<KeyValuePair<object, ValidationStateEntry>>, IEnumerable<KeyValuePair<object, ValidationStateEntry>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ValidationStateDictionary.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.ValidationStateDictionary()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary`\.
    
        
    
        
        .. code-block:: csharp
    
           public ValidationStateDictionary()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Add(System.Collections.Generic.KeyValuePair<System.Object, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.Object,Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry}
    
        
        .. code-block:: csharp
    
           public void Add(KeyValuePair<object, ValidationStateEntry> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Add(System.Object, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry)
    
        
        
        
        :type key: System.Object
        
        
        :type value: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry
    
        
        .. code-block:: csharp
    
           public void Add(object key, ValidationStateEntry value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Contains(System.Collections.Generic.KeyValuePair<System.Object, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.Object,Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Contains(KeyValuePair<object, ValidationStateEntry> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.ContainsKey(System.Object)
    
        
        
        
        :type key: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(object key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.CopyTo(System.Collections.Generic.KeyValuePair<System.Object, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.Object,Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(KeyValuePair<object, ValidationStateEntry>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.Object,Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<object, ValidationStateEntry>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Remove(System.Collections.Generic.KeyValuePair<System.Object, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.Object,Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(KeyValuePair<object, ValidationStateEntry> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Remove(System.Object)
    
        
        
        
        :type key: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(object key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.TryGetValue(System.Object, out Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry)
    
        
        
        
        :type key: System.Object
        
        
        :type value: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(object key, out ValidationStateEntry value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Item[System.Object]
    
        
        
        
        :type key: System.Object
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry
    
        
        .. code-block:: csharp
    
           public ValidationStateEntry this[object key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.Object}
    
        
        .. code-block:: csharp
    
           public ICollection<object> Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.System.Collections.Generic.IReadOnlyDictionary<System.Object, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry>.Keys
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Object}
    
        
        .. code-block:: csharp
    
           IEnumerable<object> IReadOnlyDictionary<object, ValidationStateEntry>.Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.System.Collections.Generic.IReadOnlyDictionary<System.Object, Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry>.Values
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry}
    
        
        .. code-block:: csharp
    
           IEnumerable<ValidationStateEntry> IReadOnlyDictionary<object, ValidationStateEntry>.Values { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry}
    
        
        .. code-block:: csharp
    
           public ICollection<ValidationStateEntry> Values { get; }
    

