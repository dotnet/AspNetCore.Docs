

HttpRequest Class
=================






Represents the incoming side of an individual HTTP request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HttpRequest`








Syntax
------

.. code-block:: csharp

    public abstract class HttpRequest








.. dn:class:: Microsoft.AspNetCore.Http.HttpRequest
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.HttpRequest

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.HttpRequest
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Body
    
        
    
        
        Gets or set the RequestBody Stream.
    
        
        :rtype: System.IO.Stream
        :return: The RequestBody Stream.
    
        
        .. code-block:: csharp
    
            public abstract Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.ContentLength
    
        
    
        
        Gets or sets the Content-Length header
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public abstract long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.ContentType
    
        
    
        
        Gets or sets the Content-Type header.
    
        
        :rtype: System.String
        :return: The Content-Type header.
    
        
        .. code-block:: csharp
    
            public abstract string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Cookies
    
        
    
        
        Gets the collection of Cookies for this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.IRequestCookieCollection
        :return: The collection of Cookies for this request.
    
        
        .. code-block:: csharp
    
            public abstract IRequestCookieCollection Cookies { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Form
    
        
    
        
        Gets or sets the request body as a form.
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormCollection
    
        
        .. code-block:: csharp
    
            public abstract IFormCollection Form { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.HasFormContentType
    
        
    
        
        Checks the content-type header for form types.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool HasFormContentType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Headers
    
        
    
        
        Gets the request headers.
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
        :return: The request headers.
    
        
        .. code-block:: csharp
    
            public abstract IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Host
    
        
    
        
        Gets or set the Host header. May include the port.
    
        
        :rtype: Microsoft.AspNetCore.Http.HostString
    
        
        .. code-block:: csharp
    
            public abstract HostString Host { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.HttpContext
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Http.HttpRequest.HttpContext` this request;
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public abstract HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.IsHttps
    
        
    
        
        Returns true if the RequestScheme is https.
    
        
        :rtype: System.Boolean
        :return: true if this request is using https; otherwise, false.
    
        
        .. code-block:: csharp
    
            public abstract bool IsHttps { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Method
    
        
    
        
        Gets or set the HTTP method.
    
        
        :rtype: System.String
        :return: The HTTP method.
    
        
        .. code-block:: csharp
    
            public abstract string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Path
    
        
    
        
        Gets or set the request path from RequestPath.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
        :return: The request path from RequestPath.
    
        
        .. code-block:: csharp
    
            public abstract PathString Path { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.PathBase
    
        
    
        
        Gets or set the RequestPathBase.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
        :return: The RequestPathBase.
    
        
        .. code-block:: csharp
    
            public abstract PathString PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Protocol
    
        
    
        
        Gets or set the RequestProtocol.
    
        
        :rtype: System.String
        :return: The RequestProtocol.
    
        
        .. code-block:: csharp
    
            public abstract string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Query
    
        
    
        
        Gets the query value collection parsed from Request.QueryString.
    
        
        :rtype: Microsoft.AspNetCore.Http.IQueryCollection
        :return: The query value collection parsed from Request.QueryString.
    
        
        .. code-block:: csharp
    
            public abstract IQueryCollection Query { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.QueryString
    
        
    
        
        Gets or set the raw query string used to create the query collection in Request.Query.
    
        
        :rtype: Microsoft.AspNetCore.Http.QueryString
        :return: The raw query string.
    
        
        .. code-block:: csharp
    
            public abstract QueryString QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpRequest.Scheme
    
        
    
        
        Gets or set the HTTP request scheme.
    
        
        :rtype: System.String
        :return: The HTTP request scheme.
    
        
        .. code-block:: csharp
    
            public abstract string Scheme { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.HttpRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HttpRequest.ReadFormAsync(System.Threading.CancellationToken)
    
        
    
        
        Reads the request body if it is a form.
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Http.IFormCollection<Microsoft.AspNetCore.Http.IFormCollection>}
    
        
        .. code-block:: csharp
    
            public abstract Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = null)
    

