

IHttpRequestFeature Interface
=============================






Contains the details of a given request. These properties should all be mutable.
None of these properties should ever be set to null.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpRequestFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Body
    
        
    
        
        A :any:`System.IO.Stream` representing the request body, if any. Stream.Null may be used
        to represent an empty request body.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Headers
    
        
    
        
        Headers included in the request, aggregated by header name. The values are not split
        or merged across header lines. E.g. The following headers:
        HeaderA: value1, value2
        HeaderA: value3
        Result in Headers["HeaderA"] = { "value1, value2", "value3" }
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Method
    
        
    
        
        The request method as defined in RFC 7230. E.g. "GET", "HEAD", "POST", etc..
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Path
    
        
    
        
        The portion of the request path that identifies the requested resource. The value
        is un-escaped. The value may be string.Empty if :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.PathBase` contains the
        full path.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.PathBase
    
        
    
        
        The first portion of the request path associated with application root. The value
        is un-escaped. The value may be string.Empty.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Protocol
    
        
    
        
        The HTTP-version as defined in RFC 7230. E.g. "HTTP/1.1"
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.QueryString
    
        
    
        
        The query portion of the request-target as defined in RFC 7230. The value
        may be string.Empty. If not empty then the leading '?' will be included. The value
        is in its original form, without un-escaping.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.RawTarget
    
        
    
        
        The request target as it was sent in the HTTP request. This property contains the
        raw path and full query, as well as other request targets such as * for OPTIONS
        requests (https://tools.ietf.org/html/rfc7230#section-5.3).
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string RawTarget { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Scheme
    
        
    
        
        The request uri scheme. E.g. "http" or "https". Note this value is not included
        in the original request, it is inferred by checking if the transport used a TLS
        connection or not.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Scheme { get; set; }
    

