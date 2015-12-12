

OwinFeatureCollection Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Owin.OwinFeatureCollection`








Syntax
------

.. code-block:: csharp

   public class OwinFeatureCollection : IFeatureCollection, IEnumerable<KeyValuePair<Type, object>>, IEnumerable, IHttpRequestFeature, IHttpResponseFeature, IHttpConnectionFeature, IHttpSendFileFeature, ITlsConnectionFeature, IHttpRequestIdentifierFeature, IHttpRequestLifetimeFeature, IHttpAuthenticationFeature, IHttpWebSocketFeature, IOwinEnvironmentFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Owin/OwinFeatureCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.OwinFeatureCollection

Constructors
------------

.. dn:class:: Microsoft.AspNet.Owin.OwinFeatureCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinFeatureCollection.OwinFeatureCollection(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type environment: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public OwinFeatureCollection(IDictionary<string, object> environment)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Owin.OwinFeatureCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Get(System.Type)
    
        
        
        
        :type key: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Get(Type key)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.Type,System.Object}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestLifetimeFeature.Abort()
    
        
    
        
        .. code-block:: csharp
    
           void IHttpRequestLifetimeFeature.Abort()
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpResponseFeature.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           void IHttpResponseFeature.OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpResponseFeature.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           void IHttpResponseFeature.OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpSendFileFeature.SendFileAsync(System.String, System.Int64, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
        
        
        :type path: System.String
        
        
        :type offset: System.Int64
        
        
        :type length: System.Nullable{System.Int64}
        
        
        :type cancellation: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task IHttpSendFileFeature.SendFileAsync(string path, long offset, long ? length, CancellationToken cancellation)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpWebSocketFeature.AcceptAsync(Microsoft.AspNet.Http.Features.WebSocketAcceptContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.WebSocketAcceptContext
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           Task<WebSocket> IHttpWebSocketFeature.AcceptAsync(WebSocketAcceptContext context)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.ITlsConnectionFeature.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Security.Cryptography.X509Certificates.X509Certificate2}
    
        
        .. code-block:: csharp
    
           Task<X509Certificate2> ITlsConnectionFeature.GetClientCertificateAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.Set(System.Type, System.Object)
    
        
        
        
        :type key: System.Type
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Set(Type key, object value)
    
    .. dn:method:: Microsoft.AspNet.Owin.OwinFeatureCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Owin.OwinFeatureCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Environment
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> Environment { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Item[System.Type]
    
        
        
        
        :type key: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object this[Type key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature.Handler
    
        
        :rtype: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
           IAuthenticationHandler IHttpAuthenticationFeature.Handler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           ClaimsPrincipal IHttpAuthenticationFeature.User { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpConnectionFeature.IsLocal
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IHttpConnectionFeature.IsLocal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpConnectionFeature.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           IPAddress IHttpConnectionFeature.LocalIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpConnectionFeature.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int IHttpConnectionFeature.LocalPort { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpConnectionFeature.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           IPAddress IHttpConnectionFeature.RemoteIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpConnectionFeature.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int IHttpConnectionFeature.RemotePort { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           Stream IHttpRequestFeature.Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           IHeaderDictionary IHttpRequestFeature.Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Scheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestIdentifierFeature.TraceIdentifier
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestIdentifierFeature.TraceIdentifier { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpRequestLifetimeFeature.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           CancellationToken IHttpRequestLifetimeFeature.RequestAborted { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpResponseFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           Stream IHttpResponseFeature.Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpResponseFeature.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IHttpResponseFeature.HasStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpResponseFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           IHeaderDictionary IHttpResponseFeature.Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpResponseFeature.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpResponseFeature.ReasonPhrase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpResponseFeature.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int IHttpResponseFeature.StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.IHttpWebSocketFeature.IsWebSocketRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IHttpWebSocketFeature.IsWebSocketRequest { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Microsoft.AspNet.Http.Features.ITlsConnectionFeature.ClientCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
           X509Certificate2 ITlsConnectionFeature.ClientCertificate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.Revision
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Revision { get; }
    
    .. dn:property:: Microsoft.AspNet.Owin.OwinFeatureCollection.SupportsWebSockets
    
        
    
        Gets or sets if the underlying server supports WebSockets. This is enabled by default.
        The value should be consistent across requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SupportsWebSockets { get; set; }
    

