

ItemsDictionary Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Internal.ItemsDictionary`








Syntax
------

.. code-block:: csharp

   public class ItemsDictionary : IDictionary<object, object>, ICollection<KeyValuePair<object, object>>, IEnumerable<KeyValuePair<object, object>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/ItemsDictionary.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.ItemsDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.ItemsDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.ItemsDictionary.ItemsDictionary()
    
        
    
        
        .. code-block:: csharp
    
           public ItemsDictionary()
    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.ItemsDictionary.ItemsDictionary(System.Collections.Generic.IDictionary<System.Object, System.Object>)
    
        
        
        
        :type items: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public ItemsDictionary(IDictionary<object, object> items)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.ItemsDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.Add(System.Collections.Generic.KeyValuePair<System.Object, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<object, object>>.Add(KeyValuePair<object, object> item)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.Clear()
    
        
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<object, object>>.Clear()
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.Contains(System.Collections.Generic.KeyValuePair<System.Object, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.Object,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<object, object>>.Contains(KeyValuePair<object, object> item)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<System.Object, System.Object>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.Object,System.Object}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<object, object>>.CopyTo(KeyValuePair<object, object>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.Remove(System.Collections.Generic.KeyValuePair<System.Object, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.Object,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<object, object>>.Remove(KeyValuePair<object, object> item)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IDictionary<System.Object, System.Object>.Add(System.Object, System.Object)
    
        
        
        
        :type key: System.Object
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           void IDictionary<object, object>.Add(object key, object value)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IDictionary<System.Object, System.Object>.ContainsKey(System.Object)
    
        
        
        
        :type key: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IDictionary<object, object>.ContainsKey(object key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IDictionary<System.Object, System.Object>.Remove(System.Object)
    
        
        
        
        :type key: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IDictionary<object, object>.Remove(object key)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IDictionary<System.Object, System.Object>.TryGetValue(System.Object, out System.Object)
    
        
        
        
        :type key: System.Object
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IDictionary<object, object>.TryGetValue(object key, out object value)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.Object,System.Object}}
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<object, object>> IEnumerable<KeyValuePair<object, object>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.ItemsDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ItemsDictionary.Items
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int ICollection<KeyValuePair<object, object>>.Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Object, System.Object>>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<object, object>>.IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IDictionary<System.Object, System.Object>.Item[System.Object]
    
        
        
        
        :type key: System.Object
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object IDictionary<object, object>.this[object key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IDictionary<System.Object, System.Object>.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.Object}
    
        
        .. code-block:: csharp
    
           ICollection<object> IDictionary<object, object>.Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.ItemsDictionary.System.Collections.Generic.IDictionary<System.Object, System.Object>.Values
    
        
        :rtype: System.Collections.Generic.ICollection{System.Object}
    
        
        .. code-block:: csharp
    
           ICollection<object> IDictionary<object, object>.Values { get; }
    

