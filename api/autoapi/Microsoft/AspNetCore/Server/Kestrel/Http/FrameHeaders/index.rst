

FrameHeaders Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders`








Syntax
------

.. code-block:: csharp

    public abstract class FrameHeaders : IHeaderDictionary, IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.Microsoft.AspNetCore.Http.IHeaderDictionary.Item[System.String]
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            StringValues IHeaderDictionary.this[string key]
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int ICollection<KeyValuePair<string, StringValues>>.Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<KeyValuePair<string, StringValues>>.IsReadOnly
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Item[System.String]
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            StringValues IDictionary<string, StringValues>.this[string key]
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Keys
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            ICollection<string> IDictionary<string, StringValues>.Keys
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Values
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            ICollection<StringValues> IDictionary<string, StringValues>.Values
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.Unknown
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            protected Dictionary<string, StringValues> Unknown
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.AddValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected virtual void AddValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.AppendValue(Microsoft.Extensions.Primitives.StringValues, System.String)
    
        
    
        
        :type existing: Microsoft.Extensions.Primitives.StringValues
    
        
        :type append: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected static StringValues AppendValue(StringValues existing, string append)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.BitCount(System.Int64)
    
        
    
        
        :type value: System.Int64
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected static int BitCount(long value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.ClearFast()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void ClearFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.CopyToFast(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
    
        
        :type array: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            protected virtual void CopyToFast(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.GetCountFast()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected virtual int GetCountFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.GetEnumeratorFast()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
    
        
        .. code-block:: csharp
    
            protected virtual IEnumerator<KeyValuePair<string, StringValues>> GetEnumeratorFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.GetValueFast(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected virtual StringValues GetValueFast(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.RemoveFast(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual bool RemoveFast(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.SetReadOnly()
    
        
    
        
        .. code-block:: csharp
    
            public void SetReadOnly()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.SetValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected virtual void SetValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.Add(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            void ICollection<KeyValuePair<string, StringValues>>.Add(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.Clear()
    
        
    
        
        .. code-block:: csharp
    
            void ICollection<KeyValuePair<string, StringValues>>.Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.Contains(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<KeyValuePair<string, StringValues>>.Contains(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.CopyTo(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
    
        
        :type array: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            void ICollection<KeyValuePair<string, StringValues>>.CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.Remove(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>)
    
        
    
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<KeyValuePair<string, StringValues>>.Remove(KeyValuePair<string, StringValues> item)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Add(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            void IDictionary<string, StringValues>.Add(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.ContainsKey(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IDictionary<string, StringValues>.ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.Remove(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IDictionary<string, StringValues>.Remove(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IDictionary<string, StringValues>.TryGetValue(string key, out StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, StringValues>> IEnumerable<KeyValuePair<string, StringValues>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.ThrowArgumentException()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowArgumentException()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.ThrowDuplicateKeyException()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowDuplicateKeyException()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.ThrowKeyNotFoundException()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowKeyNotFoundException()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.ThrowReadOnlyException()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowReadOnlyException()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.TryGetValueFast(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual bool TryGetValueFast(string key, out StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.ValidateHeaderCharacters(Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type headerValues: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public static void ValidateHeaderCharacters(StringValues headerValues)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.ValidateHeaderCharacters(System.String)
    
        
    
        
        :type headerCharacters: System.String
    
        
        .. code-block:: csharp
    
            public static void ValidateHeaderCharacters(string headerCharacters)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders.MaybeUnknown
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            protected Dictionary<string, StringValues> MaybeUnknown
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameHeaders._isReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool _isReadOnly
    

