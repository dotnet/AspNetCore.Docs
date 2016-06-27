

ResponseHeaders Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Headers`
Assemblies
    * Microsoft.AspNetCore.Http.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Headers.ResponseHeaders`








Syntax
------

.. code-block:: csharp

    public class ResponseHeaders








.. dn:class:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.ResponseHeaders(Microsoft.AspNetCore.Http.IHeaderDictionary)
    
        
    
        
        :type headers: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public ResponseHeaders(IHeaderDictionary headers)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.Append(System.String, System.Object)
    
        
    
        
        :type name: System.String
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void Append(string name, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.AppendList<T>(System.String, System.Collections.Generic.IList<T>)
    
        
    
        
        :type name: System.String
    
        
        :type values: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{T}
    
        
        .. code-block:: csharp
    
            public void AppendList<T>(string name, IList<T> values)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.GetList<T>(System.String)
    
        
    
        
        :type name: System.String
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{T}
    
        
        .. code-block:: csharp
    
            public IList<T> GetList<T>(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.Get<T>(System.String)
    
        
    
        
        :type name: System.String
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T Get<T>(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.Set(System.String, System.Object)
    
        
    
        
        :type name: System.String
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void Set(string name, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.SetList<T>(System.String, System.Collections.Generic.IList<T>)
    
        
    
        
        :type name: System.String
    
        
        :type values: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{T}
    
        
        .. code-block:: csharp
    
            public void SetList<T>(string name, IList<T> values)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.CacheControl
    
        
        :rtype: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    
        
        .. code-block:: csharp
    
            public CacheControlHeaderValue CacheControl { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.ContentDisposition
    
        
        :rtype: Microsoft.Net.Http.Headers.ContentDispositionHeaderValue
    
        
        .. code-block:: csharp
    
            public ContentDispositionHeaderValue ContentDisposition { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.ContentLength
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.ContentRange
    
        
        :rtype: Microsoft.Net.Http.Headers.ContentRangeHeaderValue
    
        
        .. code-block:: csharp
    
            public ContentRangeHeaderValue ContentRange { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.ContentType
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.Date
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? Date { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.ETag
    
        
        :rtype: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    
        
        .. code-block:: csharp
    
            public EntityTagHeaderValue ETag { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.Expires
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? Expires { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.LastModified
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? LastModified { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.Location
    
        
        :rtype: System.Uri
    
        
        .. code-block:: csharp
    
            public Uri Location { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Headers.ResponseHeaders.SetCookie
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.SetCookieHeaderValue<Microsoft.Net.Http.Headers.SetCookieHeaderValue>}
    
        
        .. code-block:: csharp
    
            public IList<SetCookieHeaderValue> SetCookie { get; set; }
    

