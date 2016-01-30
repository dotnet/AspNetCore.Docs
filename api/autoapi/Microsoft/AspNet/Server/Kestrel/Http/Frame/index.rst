

Frame Class
===========



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Frame`








Syntax
------

.. code-block:: csharp

   public class Frame : FrameContext, IFrameControl, IFeatureCollection, IEnumerable<KeyValuePair<Type, object>>, IEnumerable, IHttpRequestFeature, IHttpResponseFeature, IHttpUpgradeFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/Frame.Generated.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Frame

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Frame
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Frame(Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext
    
        
        .. code-block:: csharp
    
           public Frame(ConnectionContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Frame
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.BeginChunkBytes(System.Int32)
    
        
        
        
        :type dataCount: System.Int32
        :rtype: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public static ArraySegment<byte> BeginChunkBytes(int dataCount)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public void Flush()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.FlushAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task FlushAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpResponseFeature.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           void IHttpResponseFeature.OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpResponseFeature.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           void IHttpResponseFeature.OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpUpgradeFeature.UpgradeAsync()
    
        
        :rtype: System.Threading.Tasks.Task{System.IO.Stream}
    
        
        .. code-block:: csharp
    
           Task<Stream> IHttpUpgradeFeature.UpgradeAsync()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.ProduceContinue()
    
        
    
        
        .. code-block:: csharp
    
           public void ProduceContinue()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.ProduceStartAndFireOnStarting(System.Boolean)
    
        
        
        
        :type immediate: System.Boolean
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task ProduceStartAndFireOnStarting(bool immediate = true)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.RequestProcessingAsync()
    
        
    
        Primary loop which consumes socket input, parses it for protocol framing, and invokes the
        application delegate for as long as the socket is intended to remain open.
        The resulting Task from this loop is preserved in a field which is used when the server needs
        to drain and close all currently active connections.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RequestProcessingAsync()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.ResetFeatureCollection()
    
        
    
        
        .. code-block:: csharp
    
           public void ResetFeatureCollection()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.ResetResponseHeaders()
    
        
    
        
        .. code-block:: csharp
    
           public void ResetResponseHeaders()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Start()
    
        
    
        Called once by Connection class to begin the RequestProcessingAsync loop.
    
        
    
        
        .. code-block:: csharp
    
           public void Start()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.StatusCanHaveBody(System.Int32)
    
        
        
        
        :type statusCode: System.Int32
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool StatusCanHaveBody(int statusCode)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Stop()
    
        
    
        Should be called when the server wants to initiate a shutdown. The Task returned will
        become complete when the RequestProcessingAsync function has exited. It is expected that
        Stop will be called on all active connections, and Task.WaitAll() will be called on every
        return value.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Stop()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.Type, System.Object>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.Type,System.Object}}
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<Type, object>> IEnumerable<KeyValuePair<Type, object>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.TakeMessageHeaders(Microsoft.AspNet.Server.Kestrel.Http.SocketInput, Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders)
    
        
        
        
        :type input: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
        
        
        :type requestHeaders: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TakeMessageHeaders(SocketInput input, FrameRequestHeaders requestHeaders)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Write(System.ArraySegment<System.Byte>)
    
        
        
        
        :type data: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public void Write(ArraySegment<byte> data)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Frame.WriteAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
        
        
        :type data: System.ArraySegment{System.Byte}
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task WriteAsync(ArraySegment<byte> data, CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Frame
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.DuplexStream
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream DuplexStream { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.HasResponseStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasResponseStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.HttpVersion
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HttpVersion { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.MessageBody
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.MessageBody
    
        
        .. code-block:: csharp
    
           public MessageBody MessageBody { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IFeatureCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IFeatureCollection.IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IFeatureCollection.Item[System.Type]
    
        
        
        
        :type key: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object IFeatureCollection.this[Type key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IFeatureCollection.Revision
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int IFeatureCollection.Revision { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           Stream IHttpRequestFeature.Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           IHeaderDictionary IHttpRequestFeature.Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpRequestFeature.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpRequestFeature.Scheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpResponseFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           Stream IHttpResponseFeature.Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpResponseFeature.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IHttpResponseFeature.HasStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpResponseFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           IHeaderDictionary IHttpResponseFeature.Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpResponseFeature.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IHttpResponseFeature.ReasonPhrase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpResponseFeature.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int IHttpResponseFeature.StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Microsoft.AspNet.Http.Features.IHttpUpgradeFeature.IsUpgradableRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IHttpUpgradeFeature.IsUpgradableRequest { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ReasonPhrase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.RequestBody
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream RequestBody { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.RequestHeaders
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary RequestHeaders { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.RequestUri
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RequestUri { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.ResponseBody
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream ResponseBody { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.ResponseHeaders
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary ResponseHeaders { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Frame.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int StatusCode { get; set; }
    

