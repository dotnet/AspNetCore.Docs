

FrameResponseHeaders Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameHeaders`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders`








Syntax
------

.. code-block:: csharp

   public class FrameResponseHeaders : FrameHeaders, IHeaderDictionary, IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/FrameResponseHeaders.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.AddValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           protected override void AddValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.Append(System.Byte[], System.Int32, System.Int32, System.String)
    
        
        
        
        :type keyBytes: System.Byte[]
        
        
        :type keyOffset: System.Int32
        
        
        :type keyLength: System.Int32
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Append(byte[] keyBytes, int keyOffset, int keyLength, string value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.ClearFast()
    
        
    
        
        .. code-block:: csharp
    
           protected override void ClearFast()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.CopyToFast(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           protected override void CopyToFast(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.GetCountFast()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           protected override int GetCountFast()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.GetEnumerator()
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.Enumerator
    
        
        .. code-block:: csharp
    
           public FrameResponseHeaders.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.GetEnumeratorFast()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}}
    
        
        .. code-block:: csharp
    
           protected override IEnumerator<KeyValuePair<string, StringValues>> GetEnumeratorFast()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.GetValueFast(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           protected override StringValues GetValueFast(string key)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.RemoveFast(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool RemoveFast(string key)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.SetValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           protected override void SetValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.TryGetValueFast(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool TryGetValueFast(string key, out StringValues value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderAcceptRanges
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAcceptRanges { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderAge
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAge { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderAllow
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAllow { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderCacheControl
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderCacheControl { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderConnection
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderConnection { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderContentEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderContentLanguage
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentLanguage { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderContentLength
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderContentLocation
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentLocation { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderContentMD5
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentMD5 { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderContentRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentRange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderContentType
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderDate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderDate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderETag
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderETag { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderExpires
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderExpires { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderKeepAlive
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderKeepAlive { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderLastModified
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderLastModified { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderLocation
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderLocation { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderPragma
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderPragma { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderProxyAutheticate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderProxyAutheticate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderRetryAfter
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderRetryAfter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderServer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderServer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderSetCookie
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderSetCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderTrailer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderTrailer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderTransferEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderTransferEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderUpgrade
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderUpgrade { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderVary
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderVary { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderVia
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderVia { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderWWWAuthenticate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderWWWAuthenticate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.HeaderWarning
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderWarning { get; set; }
    

