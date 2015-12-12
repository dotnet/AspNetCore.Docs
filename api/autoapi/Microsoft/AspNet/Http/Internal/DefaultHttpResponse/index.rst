

DefaultHttpResponse Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HttpResponse`
* :dn:cls:`Microsoft.AspNet.Http.Internal.DefaultHttpResponse`








Syntax
------

.. code-block:: csharp

   public class DefaultHttpResponse : HttpResponse, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/DefaultHttpResponse.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.DefaultHttpResponse(Microsoft.AspNet.Http.Internal.DefaultHttpContext, Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Internal.DefaultHttpContext
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public DefaultHttpResponse(DefaultHttpContext context, IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public override void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public override void OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.Redirect(System.String, System.Boolean)
    
        
        
        
        :type location: System.String
        
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
           public override void Redirect(string location, bool permanent)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public override Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.ContentLength
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public override long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.Cookies
    
        
        :rtype: Microsoft.AspNet.Http.IResponseCookies
    
        
        .. code-block:: csharp
    
           public override IResponseCookies Cookies { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool HasStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public override IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public override HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpResponse.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int StatusCode { get; set; }
    

