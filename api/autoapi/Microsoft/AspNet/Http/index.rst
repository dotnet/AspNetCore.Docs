

Microsoft.AspNet.Http Namespace
===============================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Http/ConnectionInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/CookieOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/FormFileExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/FragmentString/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/HeaderDictionaryExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/HeaderDictionaryTypeExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/HostString/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/HttpContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/HttpRequest/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/HttpResponse/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/HttpResponseWritingExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IFormCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IFormFile/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IFormFileCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IHeaderDictionary/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IHttpContextAccessor/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IHttpContextFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IReadableStringCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/IResponseCookies/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/PathString/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/QueryString/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/ResponseExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/SendFileResponseExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/SessionExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/StatusCodes/index
   
   
   
   /autoapi/Microsoft/AspNet/Http/WebSocketManager/index
   
   











.. dn:namespace:: Microsoft.AspNet.Http


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Http.ConnectionInfo`
        


    class :dn:cls:`Microsoft.AspNet.Http.CookieOptions`
        Options used to create a new cookie.


    class :dn:cls:`Microsoft.AspNet.Http.FormFileExtensions`
        Extension methods for :any:`Microsoft.AspNet.Http.IFormFile`\.


    class :dn:cls:`Microsoft.AspNet.Http.HeaderDictionaryExtensions`
        


    class :dn:cls:`Microsoft.AspNet.Http.HeaderDictionaryTypeExtensions`
        


    class :dn:cls:`Microsoft.AspNet.Http.HttpContext`
        Encapsulates all HTTP-specific information about an individual HTTP request.


    class :dn:cls:`Microsoft.AspNet.Http.HttpRequest`
        Represents the incoming side of an individual HTTP request.


    class :dn:cls:`Microsoft.AspNet.Http.HttpResponse`
        Represents the outgoing side of an individual HTTP request.


    class :dn:cls:`Microsoft.AspNet.Http.HttpResponseWritingExtensions`
        Convenience methods for writing to the response.


    class :dn:cls:`Microsoft.AspNet.Http.ResponseExtensions`
        


    class :dn:cls:`Microsoft.AspNet.Http.SendFileResponseExtensions`
        Provides extensions for HttpResponse exposing the SendFile extension.


    class :dn:cls:`Microsoft.AspNet.Http.SessionExtensions`
        


    class :dn:cls:`Microsoft.AspNet.Http.StatusCodes`
        


    class :dn:cls:`Microsoft.AspNet.Http.WebSocketManager`
        Manages the establishment of WebSocket connections for a specific HTTP request.


    .. rubric:: Structures


    struct :dn:struct:`Microsoft.AspNet.Http.FragmentString`
        Provides correct handling for FragmentString value when needed to generate a URI string


    struct :dn:struct:`Microsoft.AspNet.Http.HostString`
        Represents the host portion of a URI can be used to construct URI's properly formatted and encoded for use in
        HTTP headers.


    struct :dn:struct:`Microsoft.AspNet.Http.PathString`
        Provides correct escaping for Path and PathBase values when needed to reconstruct a request or redirect URI string


    struct :dn:struct:`Microsoft.AspNet.Http.QueryString`
        Provides correct handling for QueryString value when needed to reconstruct a request or redirect URI string


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Http.IFormCollection`
        Contains the parsed form values.


    interface :dn:iface:`Microsoft.AspNet.Http.IFormFile`
        


    interface :dn:iface:`Microsoft.AspNet.Http.IFormFileCollection`
        


    interface :dn:iface:`Microsoft.AspNet.Http.IHeaderDictionary`
        Represents request and response headers


    interface :dn:iface:`Microsoft.AspNet.Http.IHttpContextAccessor`
        


    interface :dn:iface:`Microsoft.AspNet.Http.IHttpContextFactory`
        


    interface :dn:iface:`Microsoft.AspNet.Http.IReadableStringCollection`
        Accessors for headers, query, forms, etc.


    interface :dn:iface:`Microsoft.AspNet.Http.IResponseCookies`
        A wrapper for the response Set-Cookie header


