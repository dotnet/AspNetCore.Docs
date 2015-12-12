

DefaultHttpRequest Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HttpRequest`
* :dn:cls:`Microsoft.AspNet.Http.Internal.DefaultHttpRequest`








Syntax
------

.. code-block:: csharp

   public class DefaultHttpRequest : HttpRequest, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/DefaultHttpRequest.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.DefaultHttpRequest(Microsoft.AspNet.Http.Internal.DefaultHttpContext, Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Internal.DefaultHttpContext
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public DefaultHttpRequest(DefaultHttpContext context, IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.ReadFormAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Http.IFormCollection}
    
        
        .. code-block:: csharp
    
           public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public override Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.ContentLength
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public override long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Cookies
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public override IReadableStringCollection Cookies { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Form
    
        
        :rtype: Microsoft.AspNet.Http.IFormCollection
    
        
        .. code-block:: csharp
    
           public override IFormCollection Form { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.HasFormContentType
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool HasFormContentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public override IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Host
    
        
        :rtype: Microsoft.AspNet.Http.HostString
    
        
        .. code-block:: csharp
    
           public override HostString Host { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public override HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.IsHttps
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsHttps { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Path
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public override PathString Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.PathBase
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public override PathString PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Query
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public override IReadableStringCollection Query { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.QueryString
    
        
        :rtype: Microsoft.AspNet.Http.QueryString
    
        
        .. code-block:: csharp
    
           public override QueryString QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpRequest.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string Scheme { get; set; }
    

