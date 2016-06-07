

Microsoft.AspNetCore.Server.Kestrel.Filter Namespace
====================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/ConnectionFilterContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/FilteredStreamAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/IConnectionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/LibuvStream/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/LoggingConnectionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/NoOpConnectionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/SocketInputStream/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/StreamExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Kestrel/Filter/StreamSocketOutput/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Server.Kestrel.Filter


    .. rubric:: Classes


    class :dn:cls:`ConnectionFilterContext`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext

        


    class :dn:cls:`FilteredStreamAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter

        


    class :dn:cls:`LibuvStream`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.LibuvStream

        


    class :dn:cls:`LoggingConnectionFilter`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter

        


    class :dn:cls:`NoOpConnectionFilter`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.NoOpConnectionFilter

        


    class :dn:cls:`SocketInputStream`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream

        
        This is a write-only stream that copies what is written into a
        :any:`Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput` object. This is used as an argument to
        :dn:meth:`System.IO.Stream.CopyToAsync(System.IO.Stream)` so input filtered by a
        ConnectionFilter (e.g. SslStream) can be consumed by :any:`Microsoft.AspNetCore.Server.Kestrel.Http.Frame`\.


    class :dn:cls:`StreamExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.StreamExtensions

        


    class :dn:cls:`StreamSocketOutput`
        .. object: type=class name=Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput

        


    .. rubric:: Interfaces


    interface :dn:iface:`IConnectionFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter

        


