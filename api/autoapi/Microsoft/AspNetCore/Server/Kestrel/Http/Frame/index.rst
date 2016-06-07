

Frame Class
===========





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.Frame`








Syntax
------

.. code-block:: csharp

    public abstract class Frame : FrameContext, IFrameControl, IFeatureCollection, IEnumerable<KeyValuePair<Type, object>>, IEnumerable, IHttpRequestFeature, IHttpResponseFeature, IHttpUpgradeFeature, IHttpConnectionFeature, IHttpRequestLifetimeFeature








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.DuplexStream
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream DuplexStream
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.FrameRequestHeaders
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestHeaders
    
        
        .. code-block:: csharp
    
            protected FrameRequestHeaders FrameRequestHeaders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.HasResponseStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasResponseStarted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.HttpVersion
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HttpVersion
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Method
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IFeatureCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IFeatureCollection.IsReadOnly
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IFeatureCollection.Item[System.Type]
    
        
    
        
        :type key: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IFeatureCollection.this[Type key]
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IFeatureCollection.Revision
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int IFeatureCollection.Revision
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.ConnectionId
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpConnectionFeature.ConnectionId
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            IPAddress IHttpConnectionFeature.LocalIpAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int IHttpConnectionFeature.LocalPort
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            IPAddress IHttpConnectionFeature.RemoteIpAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int IHttpConnectionFeature.RemotePort
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            Stream IHttpRequestFeature.Body
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            IHeaderDictionary IHttpRequestFeature.Headers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpRequestFeature.Method
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpRequestFeature.Path
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpRequestFeature.PathBase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpRequestFeature.Protocol
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpRequestFeature.QueryString
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestFeature.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpRequestFeature.Scheme
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            CancellationToken IHttpRequestLifetimeFeature.RequestAborted
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            Stream IHttpResponseFeature.Body
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IHttpResponseFeature.HasStarted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            IHeaderDictionary IHttpResponseFeature.Headers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IHttpResponseFeature.ReasonPhrase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int IHttpResponseFeature.StatusCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature.IsUpgradableRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IHttpUpgradeFeature.IsUpgradableRequest
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PathBase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string QueryString
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ReasonPhrase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationToken RequestAborted
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.RequestBody
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream RequestBody
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.RequestHeaders
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public IHeaderDictionary RequestHeaders
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.RequestUri
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RequestUri
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ResponseBody
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream ResponseBody
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ResponseHeaders
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public IHeaderDictionary ResponseHeaders
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Scheme
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Frame(Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext
    
        
        .. code-block:: csharp
    
            public Frame(ConnectionContext context)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._abortedCts
    
        
        :rtype: System.Threading.CancellationTokenSource
    
        
        .. code-block:: csharp
    
            protected CancellationTokenSource _abortedCts
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._applicationException
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            protected Exception _applicationException
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._corruptedRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool _corruptedRequest
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._keepAlive
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool _keepAlive
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._manuallySetRequestAbortToken
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
    
        
        .. code-block:: csharp
    
            protected CancellationToken? _manuallySetRequestAbortToken
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._onCompleted
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            protected List<KeyValuePair<Func<object, Task>, object>> _onCompleted
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._onStarting
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            protected List<KeyValuePair<Func<object, Task>, object>> _onStarting
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._requestAborted
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected int _requestAborted
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._requestProcessingStopping
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected volatile bool _requestProcessingStopping
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame._responseStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool _responseStarted
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Abort()
    
        
    
        
        Immediate kill the connection and poison the request and response streams.
    
        
    
        
        .. code-block:: csharp
    
            public void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.FireOnCompleted()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected Task FireOnCompleted()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.FireOnStarting()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected Task FireOnStarting()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.FlushAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task FlushAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.InitializeHeaders()
    
        
    
        
        .. code-block:: csharp
    
            public void InitializeHeaders()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.InitializeStreams(Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody)
    
        
    
        
        :type messageBody: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody
    
        
        .. code-block:: csharp
    
            public void InitializeStreams(MessageBody messageBody)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IFeatureCollection.Get<TFeature>()
    
        
        :rtype: TFeature
    
        
        .. code-block:: csharp
    
            TFeature IFeatureCollection.Get<TFeature>()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IFeatureCollection.Set<TFeature>(TFeature)
    
        
    
        
        :type instance: TFeature
    
        
        .. code-block:: csharp
    
            void IFeatureCollection.Set<TFeature>(TFeature instance)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature.Abort()
    
        
    
        
        .. code-block:: csharp
    
            void IHttpRequestLifetimeFeature.Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            void IHttpResponseFeature.OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            void IHttpResponseFeature.OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature.UpgradeAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.IO.Stream<System.IO.Stream>}
    
        
        .. code-block:: csharp
    
            Task<Stream> IHttpUpgradeFeature.UpgradeAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.PauseStreams()
    
        
    
        
        .. code-block:: csharp
    
            public void PauseStreams()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ProduceContinue()
    
        
    
        
        .. code-block:: csharp
    
            public void ProduceContinue()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ProduceEnd()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected Task ProduceEnd()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ProduceStartAndFireOnStarting()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ProduceStartAndFireOnStarting()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ReportApplicationError(System.Exception)
    
        
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            protected void ReportApplicationError(Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ReportCorruptedHttpRequest(Microsoft.AspNetCore.Server.Kestrel.Exceptions.BadHttpRequestException)
    
        
    
        
        :type ex: Microsoft.AspNetCore.Server.Kestrel.Exceptions.BadHttpRequestException
    
        
        .. code-block:: csharp
    
            public void ReportCorruptedHttpRequest(BadHttpRequestException ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.RequestProcessingAsync()
    
        
    
        
        Primary loop which consumes socket input, parses it for protocol framing, and invokes the
        application delegate for as long as the socket is intended to remain open.
        The resulting Task from this loop is preserved in a field which is used when the server needs
        to drain and close all currently active connections.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public abstract Task RequestProcessingAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ResetComponents()
    
        
    
        
        .. code-block:: csharp
    
            protected void ResetComponents()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ResetFeatureCollection()
    
        
    
        
        .. code-block:: csharp
    
            public void ResetFeatureCollection()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.ResumeStreams()
    
        
    
        
        .. code-block:: csharp
    
            public void ResumeStreams()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Start()
    
        
    
        
        Called once by Connection class to begin the RequestProcessingAsync loop.
    
        
    
        
        .. code-block:: csharp
    
            public void Start()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.StatusCanHaveBody(System.Int32)
    
        
    
        
        :type statusCode: System.Int32
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool StatusCanHaveBody(int statusCode)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Stop()
    
        
    
        
        Should be called when the server wants to initiate a shutdown. The Task returned will
        become complete when the RequestProcessingAsync function has exited. It is expected that
        Stop will be called on all active connections, and Task.WaitAll() will be called on every
        return value.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Stop()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.StopStreams()
    
        
    
        
        .. code-block:: csharp
    
            public void StopStreams()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.Type, System.Object>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.Type<System.Type>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<Type, object>> IEnumerable<KeyValuePair<Type, object>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.TakeMessageHeaders(Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput, Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestHeaders)
    
        
    
        
        :type input: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    
        
        :type requestHeaders: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestHeaders
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TakeMessageHeaders(SocketInput input, FrameRequestHeaders requestHeaders)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.TakeStartLine(Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput)
    
        
    
        
        :type input: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool TakeStartLine(SocketInput input)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.Write(System.ArraySegment<System.Byte>)
    
        
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public void Write(ArraySegment<byte> data)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.WriteAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WriteAsync(ArraySegment<byte> data, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame.WriteAsyncAwaited(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WriteAsyncAwaited(ArraySegment<byte> data, CancellationToken cancellationToken)
    

