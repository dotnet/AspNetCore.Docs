

FrameResponseHeaders Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameHeaders`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders`








Syntax
------

.. code-block:: csharp

    public class FrameResponseHeaders : FrameHeaders, IHeaderDictionary, IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.AddValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected override void AddValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.ClearFast()
    
        
    
        
        .. code-block:: csharp
    
            protected override void ClearFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.CopyTo(ref Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type output: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public void CopyTo(ref MemoryPoolIterator output)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.CopyToFast(ref Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type output: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            protected void CopyToFast(ref MemoryPoolIterator output)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.CopyToFast(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
    
        
        :type array: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            protected override void CopyToFast(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.GetCountFast()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected override int GetCountFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.GetEnumerator()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.Enumerator
    
        
        .. code-block:: csharp
    
            public FrameResponseHeaders.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.GetEnumeratorFast()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
    
        
        .. code-block:: csharp
    
            protected override IEnumerator<KeyValuePair<string, StringValues>> GetEnumeratorFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.GetValueFast(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected override StringValues GetValueFast(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.RemoveFast(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool RemoveFast(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.SetRawConnection(Microsoft.Extensions.Primitives.StringValues, System.Byte[])
    
        
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        :type raw: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public void SetRawConnection(StringValues value, byte[] raw)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.SetRawContentLength(Microsoft.Extensions.Primitives.StringValues, System.Byte[])
    
        
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        :type raw: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public void SetRawContentLength(StringValues value, byte[] raw)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.SetRawDate(Microsoft.Extensions.Primitives.StringValues, System.Byte[])
    
        
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        :type raw: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public void SetRawDate(StringValues value, byte[] raw)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.SetRawServer(Microsoft.Extensions.Primitives.StringValues, System.Byte[])
    
        
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        :type raw: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public void SetRawServer(StringValues value, byte[] raw)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.SetRawTransferEncoding(Microsoft.Extensions.Primitives.StringValues, System.Byte[])
    
        
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        :type raw: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public void SetRawTransferEncoding(StringValues value, byte[] raw)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.SetValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected override void SetValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.TryGetValueFast(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool TryGetValueFast(string key, out StringValues value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HasConnection
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasConnection { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HasContentLength
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasContentLength { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HasDate
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasDate { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HasServer
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasServer { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HasTransferEncoding
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasTransferEncoding { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAcceptRanges
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAcceptRanges { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAccessControlAllowCredentials
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlAllowCredentials { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAccessControlAllowHeaders
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlAllowHeaders { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAccessControlAllowMethods
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlAllowMethods { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAccessControlAllowOrigin
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlAllowOrigin { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAccessControlExposeHeaders
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlExposeHeaders { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAccessControlMaxAge
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlMaxAge { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAge
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAge { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderAllow
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAllow { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderCacheControl
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderCacheControl { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderConnection
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderConnection { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderContentEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderContentLanguage
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentLanguage { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderContentLength
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderContentLocation
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentLocation { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderContentMD5
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentMD5 { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderContentRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentRange { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderContentType
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderDate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderDate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderETag
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderETag { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderExpires
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderExpires { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderKeepAlive
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderKeepAlive { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderLastModified
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderLastModified { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderLocation
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderLocation { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderPragma
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderPragma { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderProxyAutheticate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderProxyAutheticate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderRetryAfter
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderRetryAfter { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderServer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderServer { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderSetCookie
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderSetCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderTrailer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderTrailer { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderTransferEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderTransferEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderUpgrade
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderUpgrade { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderVary
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderVary { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderVia
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderVia { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderWWWAuthenticate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderWWWAuthenticate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameResponseHeaders.HeaderWarning
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderWarning { get; set; }
    

