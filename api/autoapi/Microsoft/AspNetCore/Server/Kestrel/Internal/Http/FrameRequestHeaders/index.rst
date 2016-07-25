

FrameRequestHeaders Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders`








Syntax
------

.. code-block:: csharp

    public class FrameRequestHeaders : FrameHeaders, IHeaderDictionary, IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.AddValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected override void AddValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.Append(System.Byte[], System.Int32, System.Int32, System.String)
    
        
    
        
        :type keyBytes: System.Byte<System.Byte>[]
    
        
        :type keyOffset: System.Int32
    
        
        :type keyLength: System.Int32
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public void Append(byte[] keyBytes, int keyOffset, int keyLength, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.ClearFast()
    
        
    
        
        .. code-block:: csharp
    
            protected override void ClearFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.CopyToFast(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
    
        
        :type array: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            protected override void CopyToFast(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.GetCountFast()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected override int GetCountFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.GetEnumerator()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.Enumerator
    
        
        .. code-block:: csharp
    
            public FrameRequestHeaders.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.GetEnumeratorFast()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
    
        
        .. code-block:: csharp
    
            protected override IEnumerator<KeyValuePair<string, StringValues>> GetEnumeratorFast()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.GetValueFast(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected override StringValues GetValueFast(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.RemoveFast(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool RemoveFast(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.SetValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            protected override void SetValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.TryGetValueFast(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool TryGetValueFast(string key, out StringValues value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAccept
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccept { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAcceptCharset
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAcceptCharset { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAcceptEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAcceptEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAcceptLanguage
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAcceptLanguage { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAccessControlRequestHeaders
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlRequestHeaders { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAccessControlRequestMethod
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAccessControlRequestMethod { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAllow
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAllow { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderAuthorization
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderAuthorization { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderCacheControl
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderCacheControl { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderConnection
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderConnection { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderContentEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderContentLanguage
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentLanguage { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderContentLength
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderContentLocation
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentLocation { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderContentMD5
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentMD5 { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderContentRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentRange { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderContentType
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderCookie
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderDate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderDate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderExpect
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderExpect { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderExpires
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderExpires { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderFrom
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderFrom { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderHost
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderHost { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderIfMatch
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderIfMatch { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderIfModifiedSince
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderIfModifiedSince { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderIfNoneMatch
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderIfNoneMatch { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderIfRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderIfRange { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderIfUnmodifiedSince
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderIfUnmodifiedSince { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderKeepAlive
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderKeepAlive { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderLastModified
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderLastModified { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderMaxForwards
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderMaxForwards { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderOrigin
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderOrigin { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderPragma
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderPragma { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderProxyAuthorization
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderProxyAuthorization { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderRange { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderReferer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderReferer { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderTE
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderTE { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderTrailer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderTrailer { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderTransferEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderTransferEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderTranslate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderTranslate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderUpgrade
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderUpgrade { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderUserAgent
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderUserAgent { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderVia
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderVia { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.FrameRequestHeaders.HeaderWarning
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public StringValues HeaderWarning { get; set; }
    

