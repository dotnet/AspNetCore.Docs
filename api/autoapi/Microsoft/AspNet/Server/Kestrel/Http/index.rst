

Microsoft.AspNet.Server.Kestrel.Http Namespace
==============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/Connection/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/ConnectionContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/DateHeaderValueManager/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/Frame/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/FrameContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/FrameHeaders/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/FrameRequestHeaders/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/FrameRequestHeaders/Enumerator/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/FrameRequestStream/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/FrameResponseHeaders/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/FrameResponseHeaders/Enumerator/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/IConnectionControl/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/IFrameControl/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/IMemoryPool/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/ISocketOutput/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/Listener/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/ListenerContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/ListenerPrimary/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/ListenerSecondary/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/MemoryPool/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/MemoryPoolTextWriter/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/MessageBody/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/PipeListener/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/PipeListenerPrimary/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/PipeListenerSecondary/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/ProduceEndType/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/ReasonPhrases/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/SocketInput/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/SocketInput/IncomingBuffer/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/SocketInputExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/SocketOutput/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/TcpListener/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/TcpListenerPrimary/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/TcpListenerSecondary/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Http/UrlPathDecoder/index
   
   











.. dn:namespace:: Microsoft.AspNet.Server.Kestrel.Http


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Connection`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager`
        Manages the generation of the date header value.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Frame`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameContext`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameHeaders`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Listener`
        Base class for listeners in Kestrel. Listens for incoming connections


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary`
        A primary listener waits for incoming connections on a specified socket. Incoming
        connections may be passed to a secondary listener to handle.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary`
        A secondary listener is delegated requests from a primary listener via a named pipe or
        UNIX domain socket.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.MemoryPool`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.MessageBody`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.PipeListener`
        Implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.Listener` that uses UNIX domain sockets as its transport.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.PipeListenerPrimary`
        An implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary` using UNIX sockets.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.PipeListenerSecondary`
        An implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary` using UNIX sockets.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ReasonPhrases`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.SocketInput`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.SocketInputExtensions`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.SocketOutput`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.TcpListener`
        Implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.Listener` that uses TCP sockets as its transport.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary`
        An implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary` using TCP sockets.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.TcpListenerSecondary`
        An implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary` using TCP sockets.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.UrlPathDecoder`
        


    .. rubric:: Structures


    struct :dn:struct:`Microsoft.AspNet.Server.Kestrel.Http.FrameRequestHeaders.Enumerator`
        


    struct :dn:struct:`Microsoft.AspNet.Server.Kestrel.Http.FrameResponseHeaders.Enumerator`
        


    struct :dn:struct:`Microsoft.AspNet.Server.Kestrel.Http.SocketInput.IncomingBuffer`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Server.Kestrel.Http.IConnectionControl`
        


    interface :dn:iface:`Microsoft.AspNet.Server.Kestrel.Http.IFrameControl`
        


    interface :dn:iface:`Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool`
        


    interface :dn:iface:`Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput`
        Operations performed for buffered socket output


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Server.Kestrel.Http.ProduceEndType`
        


