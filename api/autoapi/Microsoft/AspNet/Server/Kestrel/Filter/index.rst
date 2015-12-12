

Microsoft.AspNet.Server.Kestrel.Filter Namespace
================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Filter/ConnectionFilterContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Filter/FilteredStreamAdapter/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Filter/IConnectionFilter/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Filter/LibuvStream/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Filter/NoOpConnectionFilter/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Filter/SocketInputStream/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Kestrel/Filter/StreamSocketOutput/index
   
   











.. dn:namespace:: Microsoft.AspNet.Server.Kestrel.Filter


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.ConnectionFilterContext`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.NoOpConnectionFilter`
        


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream`
        This is a write-only stream that copies what is written into a 
        :any:`Microsoft.AspNet.Server.Kestrel.Http.SocketInput` object. This is used as an argument to 
        :dn:meth:`System.IO.Stream.CopyToAsync(System.IO.Stream)` so input filtered by a
        ConnectionFilter (e.g. SslStream) can be consumed by :any:`Microsoft.AspNet.Server.Kestrel.Http.Frame`\.


    class :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter`
        


