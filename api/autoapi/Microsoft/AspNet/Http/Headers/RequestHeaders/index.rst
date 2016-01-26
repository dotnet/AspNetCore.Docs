

RequestHeaders Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Headers.RequestHeaders`








Syntax
------

.. code-block:: csharp

   public class RequestHeaders





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Extensions/RequestHeaders.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Headers.RequestHeaders

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Headers.RequestHeaders
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Headers.RequestHeaders.RequestHeaders(Microsoft.AspNet.Http.IHeaderDictionary)
    
        
        
        
        :type headers: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public RequestHeaders(IHeaderDictionary headers)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Headers.RequestHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Headers.RequestHeaders.Append(System.String, System.Object)
    
        
        
        
        :type name: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Append(string name, object value)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.RequestHeaders.AppendList<T>(System.String, System.Collections.Generic.IList<T>)
    
        
        
        
        :type name: System.String
        
        
        :type values: System.Collections.Generic.IList{{T}}
    
        
        .. code-block:: csharp
    
           public void AppendList<T>(string name, IList<T> values)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.RequestHeaders.GetList<T>(System.String)
    
        
        
        
        :type name: System.String
        :rtype: System.Collections.Generic.IList{{T}}
    
        
        .. code-block:: csharp
    
           public IList<T> GetList<T>(string name)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.RequestHeaders.Get<T>(System.String)
    
        
        
        
        :type name: System.String
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T Get<T>(string name)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.RequestHeaders.Set(System.String, System.Object)
    
        
        
        
        :type name: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Set(string name, object value)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.RequestHeaders.SetList<T>(System.String, System.Collections.Generic.IList<T>)
    
        
        
        
        :type name: System.String
        
        
        :type values: System.Collections.Generic.IList{{T}}
    
        
        .. code-block:: csharp
    
           public void SetList<T>(string name, IList<T> values)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Headers.RequestHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.Accept
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<MediaTypeHeaderValue> Accept { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.AcceptCharset
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.StringWithQualityHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<StringWithQualityHeaderValue> AcceptCharset { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.AcceptEncoding
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.StringWithQualityHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<StringWithQualityHeaderValue> AcceptEncoding { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.AcceptLanguage
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.StringWithQualityHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<StringWithQualityHeaderValue> AcceptLanguage { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.CacheControl
    
        
        :rtype: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    
        
        .. code-block:: csharp
    
           public CacheControlHeaderValue CacheControl { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.ContentDisposition
    
        
        :rtype: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    
        
        .. code-block:: csharp
    
           public ContentDispositionHeaderValue ContentDisposition { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.ContentLength
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.ContentRange
    
        
        :rtype: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
    
        
        .. code-block:: csharp
    
           public ContentRangeHeaderValue ContentRange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.ContentType
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.Cookie
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.CookieHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<CookieHeaderValue> Cookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.Date
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? Date { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.Expires
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? Expires { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.Host
    
        
        :rtype: Microsoft.AspNet.Http.HostString
    
        
        .. code-block:: csharp
    
           public HostString Host { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.IfMatch
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.EntityTagHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<EntityTagHeaderValue> IfMatch { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.IfModifiedSince
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? IfModifiedSince { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.IfNoneMatch
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.EntityTagHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<EntityTagHeaderValue> IfNoneMatch { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.IfRange
    
        
        :rtype: Microsoft.Net.Http.Headers.RangeConditionHeaderValue
    
        
        .. code-block:: csharp
    
           public RangeConditionHeaderValue IfRange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.IfUnmodifiedSince
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? IfUnmodifiedSince { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.LastModified
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? LastModified { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.RequestHeaders.Range
    
        
        :rtype: Microsoft.Net.Http.Headers.RangeHeaderValue
    
        
        .. code-block:: csharp
    
           public RangeHeaderValue Range { get; set; }
    

