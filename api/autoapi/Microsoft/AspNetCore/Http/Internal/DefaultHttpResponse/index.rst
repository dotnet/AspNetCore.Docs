

DefaultHttpResponse Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Http.HttpResponse`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse`








Syntax
------

.. code-block:: csharp

    public class DefaultHttpResponse : HttpResponse








.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.DefaultHttpResponse(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public DefaultHttpResponse(HttpContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public override Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.ContentLength
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public override long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.Cookies
    
        
        :rtype: Microsoft.AspNetCore.Http.IResponseCookies
    
        
        .. code-block:: csharp
    
            public override IResponseCookies Cookies { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool HasStarted { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public override IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public override HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int StatusCode { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.Initialize(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public virtual void Initialize(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public override void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public override void OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.Redirect(System.String, System.Boolean)
    
        
    
        
        :type location: System.String
    
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
            public override void Redirect(string location, bool permanent)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultHttpResponse.Uninitialize()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Uninitialize()
    

