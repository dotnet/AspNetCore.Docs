

Microsoft.AspNetCore.Localization Namespace
===========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Localization/AcceptLanguageHeaderRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/CookieRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/CustomRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/IRequestCultureFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/IRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/ProviderCultureResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/QueryStringRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/RequestCulture/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/RequestCultureFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/RequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Localization/RequestLocalizationMiddleware/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Localization


    .. rubric:: Classes


    class :dn:cls:`AcceptLanguageHeaderRequestCultureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider

        
        Determines the culture information for a request via the value of the Accept-Language header.


    class :dn:cls:`CookieRequestCultureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Localization.CookieRequestCultureProvider

        
        Determines the culture information for a request via the value of a cookie.


    class :dn:cls:`CustomRequestCultureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Localization.CustomRequestCultureProvider

        
        Determines the culture information for a request via the configured delegate.


    class :dn:cls:`ProviderCultureResult`
        .. object: type=class name=Microsoft.AspNetCore.Localization.ProviderCultureResult

        
        Details about the cultures obtained from :any:`Microsoft.AspNetCore.Localization.IRequestCultureProvider`\.


    class :dn:cls:`QueryStringRequestCultureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider

        
        Determines the culture information for a request via values in the query string.


    class :dn:cls:`RequestCulture`
        .. object: type=class name=Microsoft.AspNetCore.Localization.RequestCulture

        
        Details about the culture for an :any:`Microsoft.AspNetCore.Http.HttpRequest`\.


    class :dn:cls:`RequestCultureFeature`
        .. object: type=class name=Microsoft.AspNetCore.Localization.RequestCultureFeature

        
        Provides the current request's culture information.


    class :dn:cls:`RequestCultureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Localization.RequestCultureProvider

        
        An abstract base class provider for determining the culture information of an :any:`Microsoft.AspNetCore.Http.HttpRequest`\.


    class :dn:cls:`RequestLocalizationMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware

        
        Enables automatic setting of the culture for :any:`Microsoft.AspNetCore.Http.HttpRequest`\s based on information
        sent by the client in headers and logic provided by the application.


    .. rubric:: Interfaces


    interface :dn:iface:`IRequestCultureFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Localization.IRequestCultureFeature

        
        Represents the feature that provides the current request's culture information.


    interface :dn:iface:`IRequestCultureProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Localization.IRequestCultureProvider

        
        Represents a provider for determining the culture information of an :any:`Microsoft.AspNetCore.Http.HttpRequest`\.


