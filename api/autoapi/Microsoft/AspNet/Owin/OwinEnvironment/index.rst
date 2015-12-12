

OwinEnvironment Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Owin.OwinEnvironment`








Syntax
------

.. code-block:: csharp

   public class OwinEnvironment : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Owin/OwinEnvironment.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment

Constructors
------------

.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.OwinEnvironment(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public OwinEnvironment(HttpContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Add(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Clear()
    
        
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<string, object>>.Clear()
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Contains(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<System.String, System.Object>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,System.Object}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Remove(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IDictionary<System.String, System.Object>.Add(System.String, System.Object)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           void IDictionary<string, object>.Add(string key, object value)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IDictionary<System.String, System.Object>.ContainsKey(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IDictionary<string, object>.ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IDictionary<System.String, System.Object>.Remove(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IDictionary<string, object>.Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IDictionary<System.String, System.Object>.TryGetValue(System.String, out System.Object)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IDictionary<string, object>.TryGetValue(string key, out object value)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMaps
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, OwinEnvironment.FeatureMap> FeatureMaps { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int ICollection<KeyValuePair<string, object>>.Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<KeyValuePair<string, object>>.IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IDictionary<System.String, System.Object>.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object IDictionary<string, object>.this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IDictionary<System.String, System.Object>.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           ICollection<string> IDictionary<string, object>.Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinEnvironment.System.Collections.Generic.IDictionary<System.String, System.Object>.Values
    
        
        :rtype: System.Collections.Generic.ICollection{System.Object}
    
        
        .. code-block:: csharp
    
           ICollection<object> IDictionary<string, object>.Values { get; }
    

