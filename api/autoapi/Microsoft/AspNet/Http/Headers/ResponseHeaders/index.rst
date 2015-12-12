

ResponseHeaders Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Headers.ResponseHeaders`








Syntax
------

.. code-block:: csharp

   public class ResponseHeaders





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Extensions/ResponseHeaders.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Headers.ResponseHeaders

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Headers.ResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Headers.ResponseHeaders.ResponseHeaders(Microsoft.AspNet.Http.IHeaderDictionary)
    
        
        
        
        :type headers: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public ResponseHeaders(IHeaderDictionary headers)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Headers.ResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Headers.ResponseHeaders.Append(System.String, System.Object)
    
        
        
        
        :type name: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Append(string name, object value)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.ResponseHeaders.AppendList<T>(System.String, System.Collections.Generic.IList<T>)
    
        
        
        
        :type name: System.String
        
        
        :type values: System.Collections.Generic.IList{{T}}
    
        
        .. code-block:: csharp
    
           public void AppendList<T>(string name, IList<T> values)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.ResponseHeaders.GetList<T>(System.String)
    
        
        
        
        :type name: System.String
        :rtype: System.Collections.Generic.IList{{T}}
    
        
        .. code-block:: csharp
    
           public IList<T> GetList<T>(string name)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.ResponseHeaders.Get<T>(System.String)
    
        
        
        
        :type name: System.String
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T Get<T>(string name)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.ResponseHeaders.Set(System.String, System.Object)
    
        
        
        
        :type name: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Set(string name, object value)
    
    .. dn:method:: Microsoft.AspNet.Http.Headers.ResponseHeaders.SetList<T>(System.String, System.Collections.Generic.IList<T>)
    
        
        
        
        :type name: System.String
        
        
        :type values: System.Collections.Generic.IList{{T}}
    
        
        .. code-block:: csharp
    
           public void SetList<T>(string name, IList<T> values)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Headers.ResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.CacheControl
    
        
        :rtype: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    
        
        .. code-block:: csharp
    
           public CacheControlHeaderValue CacheControl { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.ContentDisposition
    
        
        :rtype: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    
        
        .. code-block:: csharp
    
           public ContentDispositionHeaderValue ContentDisposition { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.ContentLength
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.ContentRange
    
        
        :rtype: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
    
        
        .. code-block:: csharp
    
           public ContentRangeHeaderValue ContentRange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.ContentType
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.Date
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? Date { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.ETag
    
        
        :rtype: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    
        
        .. code-block:: csharp
    
           public EntityTagHeaderValue ETag { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.Expires
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? Expires { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.LastModified
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? LastModified { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.Location
    
        
        :rtype: System.Uri
    
        
        .. code-block:: csharp
    
           public Uri Location { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Headers.ResponseHeaders.SetCookie
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.SetCookieHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<SetCookieHeaderValue> SetCookie { get; set; }
    

