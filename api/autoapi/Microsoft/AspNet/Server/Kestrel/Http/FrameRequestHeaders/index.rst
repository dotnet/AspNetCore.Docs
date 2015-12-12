

FrameRequestHeaders Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameHeaders`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders`








Syntax
------

.. code-block:: csharp

   public class FrameRequestHeaders : FrameHeaders, IHeaderDictionary, IDictionary<string, StringValues>, ICollection<KeyValuePair<string, StringValues>>, IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/FrameRequestHeaders.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.AddValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           protected override void AddValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.Append(System.Byte[], System.Int32, System.Int32, System.String)
    
        
        
        
        :type keyBytes: System.Byte[]
        
        
        :type keyOffset: System.Int32
        
        
        :type keyLength: System.Int32
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Append(byte[] keyBytes, int keyOffset, int keyLength, string value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.ClearFast()
    
        
    
        
        .. code-block:: csharp
    
           protected override void ClearFast()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.CopyToFast(System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           protected override void CopyToFast(KeyValuePair<string, StringValues>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.GetCountFast()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           protected override int GetCountFast()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.GetEnumerator()
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.Enumerator
    
        
        .. code-block:: csharp
    
           public FrameRequestHeaders.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.GetEnumeratorFast()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}}
    
        
        .. code-block:: csharp
    
           protected override IEnumerator<KeyValuePair<string, StringValues>> GetEnumeratorFast()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.GetValueFast(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           protected override StringValues GetValueFast(string key)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.RemoveFast(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool RemoveFast(string key)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.SetValueFast(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           protected override void SetValueFast(string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.TryGetValueFast(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool TryGetValueFast(string key, out StringValues value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderAccept
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAccept { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderAcceptCharset
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAcceptCharset { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderAcceptEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAcceptEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderAcceptLanguage
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAcceptLanguage { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderAllow
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAllow { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderAuthorization
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderAuthorization { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderCacheControl
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderCacheControl { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderConnection
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderConnection { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderContentEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderContentLanguage
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentLanguage { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderContentLength
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderContentLocation
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentLocation { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderContentMD5
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentMD5 { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderContentRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentRange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderContentType
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderCookie
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderDate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderDate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderExpect
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderExpect { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderExpires
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderExpires { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderFrom
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderFrom { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderHost
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderHost { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderIfMatch
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderIfMatch { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderIfModifiedSince
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderIfModifiedSince { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderIfNoneMatch
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderIfNoneMatch { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderIfRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderIfRange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderIfUnmodifiedSince
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderIfUnmodifiedSince { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderKeepAlive
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderKeepAlive { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderLastModified
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderLastModified { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderMaxForwards
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderMaxForwards { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderPragma
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderPragma { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderProxyAuthorization
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderProxyAuthorization { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderRange
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderRange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderReferer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderReferer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderTE
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderTE { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderTrailer
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderTrailer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderTransferEncoding
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderTransferEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderTranslate
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderTranslate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderUpgrade
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderUpgrade { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderUserAgent
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderUserAgent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderVia
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderVia { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.HeaderWarning
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues HeaderWarning { get; set; }
    

