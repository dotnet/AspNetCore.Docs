

Microsoft.AspNetCore.Http.Features Namespace
============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/DefaultSessionFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/FeatureCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/FeatureReference-T/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/FeatureReferences-TCache/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/FormFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/FormOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/HttpConnectionFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/HttpRequestFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/HttpRequestIdentifierFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/HttpRequestLifetimeFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/HttpResponseFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IFeatureCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IFormFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpBufferingFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpConnectionFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpRequestFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpRequestIdentifierFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpRequestLifetimeFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpResponseFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpSendFileFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpUpgradeFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IHttpWebSocketFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IItemsFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IQueryFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IRequestCookiesFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IResponseCookiesFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/IServiceProvidersFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/ISessionFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/ITlsConnectionFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/ITlsTokenBindingFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/ItemsFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/QueryFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/RequestCookiesFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/ResponseCookiesFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/ServiceProvidersFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Http/Features/TlsConnectionFeature/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Http.Features


    .. rubric:: Interfaces


    interface :dn:iface:`IFeatureCollection`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IFeatureCollection

        
        Represents a collection of HTTP features.


    interface :dn:iface:`IFormFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IFormFeature

        


    interface :dn:iface:`IHttpBufferingFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpBufferingFeature

        


    interface :dn:iface:`IHttpConnectionFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature

        
        Information regarding the TCP/IP connection carrying the request.


    interface :dn:iface:`IHttpRequestFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpRequestFeature

        
        Contains the details of a given request. These properties should all be mutable.
        None of these properties should ever be set to null.


    interface :dn:iface:`IHttpRequestIdentifierFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpRequestIdentifierFeature

        
        Feature to identify a request.


    interface :dn:iface:`IHttpRequestLifetimeFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature

        


    interface :dn:iface:`IHttpResponseFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpResponseFeature

        
        Represents the fields and state of an HTTP response.


    interface :dn:iface:`IHttpSendFileFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature

        
        Provides an efficient mechanism for transferring files from disk to the network.


    interface :dn:iface:`IHttpUpgradeFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature

        


    interface :dn:iface:`IHttpWebSocketFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature

        


    interface :dn:iface:`IItemsFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IItemsFeature

        


    interface :dn:iface:`IQueryFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IQueryFeature

        


    interface :dn:iface:`IRequestCookiesFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IRequestCookiesFeature

        


    interface :dn:iface:`IResponseCookiesFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature

        
        A helper for creating the response Set-Cookie header.


    interface :dn:iface:`IServiceProvidersFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.IServiceProvidersFeature

        


    interface :dn:iface:`ISessionFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.ISessionFeature

        


    interface :dn:iface:`ITlsConnectionFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature

        


    interface :dn:iface:`ITlsTokenBindingFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Http.Features.ITlsTokenBindingFeature

        
        Provides information regarding TLS token binding parameters.


    .. rubric:: Classes


    class :dn:cls:`DefaultSessionFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.DefaultSessionFeature

        
        This type exists only for the purpose of unit testing where the user can directly set the 
        :dn:prop:`Microsoft.AspNetCore.Http.HttpContext.Session` property without the need for creating a :any:`Microsoft.AspNetCore.Http.Features.ISessionFeature`\.


    class :dn:cls:`FeatureCollection`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.FeatureCollection

        


    class :dn:cls:`FormFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.FormFeature

        


    class :dn:cls:`FormOptions`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.FormOptions

        


    class :dn:cls:`HttpConnectionFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.HttpConnectionFeature

        


    class :dn:cls:`HttpRequestFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.HttpRequestFeature

        


    class :dn:cls:`HttpRequestIdentifierFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.HttpRequestIdentifierFeature

        


    class :dn:cls:`HttpRequestLifetimeFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.HttpRequestLifetimeFeature

        


    class :dn:cls:`HttpResponseFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.HttpResponseFeature

        


    class :dn:cls:`ItemsFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.ItemsFeature

        


    class :dn:cls:`QueryFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.QueryFeature

        


    class :dn:cls:`RequestCookiesFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.RequestCookiesFeature

        


    class :dn:cls:`ResponseCookiesFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.ResponseCookiesFeature

        
        Default implementation of :any:`Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature`\.


    class :dn:cls:`ServiceProvidersFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.ServiceProvidersFeature

        


    class :dn:cls:`TlsConnectionFeature`
        .. object: type=class name=Microsoft.AspNetCore.Http.Features.TlsConnectionFeature

        


    .. rubric:: Structures


    struct :dn:struct:`FeatureReference\<T>`
        .. object: type=struct name=Microsoft.AspNetCore.Http.Features.FeatureReference\<T>

        


    struct :dn:struct:`FeatureReferences\<TCache>`
        .. object: type=struct name=Microsoft.AspNetCore.Http.Features.FeatureReferences\<TCache>

        


