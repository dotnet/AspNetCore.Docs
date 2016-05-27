

DefaultHttpRequest Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HttpRequest`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest`








Syntax
------

.. code-block:: csharp

    public class DefaultHttpRequest : HttpRequest








.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public override Stream Body
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.ContentLength
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public override long ? ContentLength
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ContentType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Cookies
    
        
        :rtype: Microsoft.AspNetCore.Http.IRequestCookieCollection
    
        
        .. code-block:: csharp
    
            public override IRequestCookieCollection Cookies
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Form
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormCollection
    
        
        .. code-block:: csharp
    
            public override IFormCollection Form
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.HasFormContentType
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool HasFormContentType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public override IHeaderDictionary Headers
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Host
    
        
        :rtype: Microsoft.AspNetCore.Http.HostString
    
        
        .. code-block:: csharp
    
            public override HostString Host
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public override HttpContext HttpContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.IsHttps
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsHttps
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Method
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Path
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public override PathString Path
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.PathBase
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public override PathString PathBase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Protocol
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Query
    
        
        :rtype: Microsoft.AspNetCore.Http.IQueryCollection
    
        
        .. code-block:: csharp
    
            public override IQueryCollection Query
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.QueryString
    
        
        :rtype: Microsoft.AspNetCore.Http.QueryString
    
        
        .. code-block:: csharp
    
            public override QueryString QueryString
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Scheme
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.DefaultHttpRequest(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public DefaultHttpRequest(HttpContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Initialize(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public virtual void Initialize(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.ReadFormAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Http.IFormCollection<Microsoft.AspNetCore.Http.IFormCollection>}
    
        
        .. code-block:: csharp
    
            public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest.Uninitialize()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Uninitialize()
    

