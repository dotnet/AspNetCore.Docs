

HttpRequest Class
=================



.. contents:: 
   :local:



Summary
-------

Represents the incoming side of an individual HTTP request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HttpRequest`








Syntax
------

.. code-block:: csharp

   public abstract class HttpRequest





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/HttpRequest.cs>`_





.. dn:class:: Microsoft.AspNet.Http.HttpRequest

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.HttpRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.HttpRequest.ReadFormAsync(System.Threading.CancellationToken)
    
        
    
        Reads the request body if it is a form.
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Http.IFormCollection}
    
        
        .. code-block:: csharp
    
           public abstract Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = null)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.HttpRequest
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Body
    
        
    
        Gets or set the owin.RequestBody Stream.
    
        
        :rtype: System.IO.Stream
        :return: The owin.RequestBody Stream.
    
        
        .. code-block:: csharp
    
           public abstract Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.ContentLength
    
        
    
        Gets or sets the Content-Length header
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public abstract long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.ContentType
    
        
    
        Gets or sets the Content-Type header.
    
        
        :rtype: System.String
        :return: The Content-Type header.
    
        
        .. code-block:: csharp
    
           public abstract string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Cookies
    
        
    
        Gets the collection of Cookies for this request.
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
        :return: The collection of Cookies for this request.
    
        
        .. code-block:: csharp
    
           public abstract IReadableStringCollection Cookies { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Form
    
        
    
        Gets or sets the request body as a form.
    
        
        :rtype: Microsoft.AspNet.Http.IFormCollection
    
        
        .. code-block:: csharp
    
           public abstract IFormCollection Form { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.HasFormContentType
    
        
    
        Checks the content-type header for form types.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool HasFormContentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Headers
    
        
    
        Gets the request headers.
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
        :return: The request headers.
    
        
        .. code-block:: csharp
    
           public abstract IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Host
    
        
    
        Gets or set the Host header. May include the port.
    
        
        :rtype: Microsoft.AspNet.Http.HostString
    
        
        .. code-block:: csharp
    
           public abstract HostString Host { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.HttpContext
    
        
    
        Gets the :dn:prop:`Microsoft.AspNet.Http.HttpRequest.HttpContext` this request;
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public abstract HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.IsHttps
    
        
    
        Returns true if the owin.RequestScheme is https.
    
        
        :rtype: System.Boolean
        :return: true if this request is using https; otherwise, false.
    
        
        .. code-block:: csharp
    
           public abstract bool IsHttps { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Method
    
        
    
        Gets or set the HTTP method.
    
        
        :rtype: System.String
        :return: The HTTP method.
    
        
        .. code-block:: csharp
    
           public abstract string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Path
    
        
    
        Gets or set the request path from owin.RequestPath.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
        :return: The request path from owin.RequestPath.
    
        
        .. code-block:: csharp
    
           public abstract PathString Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.PathBase
    
        
    
        Gets or set the owin.RequestPathBase.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
        :return: The owin.RequestPathBase.
    
        
        .. code-block:: csharp
    
           public abstract PathString PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Protocol
    
        
    
        Gets or set the owin.RequestProtocol.
    
        
        :rtype: System.String
        :return: The owin.RequestProtocol.
    
        
        .. code-block:: csharp
    
           public abstract string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Query
    
        
    
        Gets the query value collection parsed from owin.RequestQueryString.
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
        :return: The query value collection parsed from owin.RequestQueryString.
    
        
        .. code-block:: csharp
    
           public abstract IReadableStringCollection Query { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.QueryString
    
        
    
        Gets or set the query string from owin.RequestQueryString.
    
        
        :rtype: Microsoft.AspNet.Http.QueryString
        :return: The query string from owin.RequestQueryString.
    
        
        .. code-block:: csharp
    
           public abstract QueryString QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpRequest.Scheme
    
        
    
        Gets or set the HTTP request scheme from owin.RequestScheme.
    
        
        :rtype: System.String
        :return: The HTTP request scheme from owin.RequestScheme.
    
        
        .. code-block:: csharp
    
           public abstract string Scheme { get; set; }
    

