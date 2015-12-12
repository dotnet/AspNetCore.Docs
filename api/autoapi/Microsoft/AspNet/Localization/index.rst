

Microsoft.AspNet.Localization Namespace
=======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Localization/AcceptLanguageHeaderRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/CookieRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/CustomRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/IRequestCultureFeature/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/IRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/ProviderCultureResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/QueryStringRequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/RequestCulture/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/RequestCultureFeature/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/RequestCultureProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/RequestLocalizationMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/Localization/RequestLocalizationOptions/index
   
   











.. dn:namespace:: Microsoft.AspNet.Localization


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider`
        Determines the culture information for a request via the value of the Accept-Language header.


    class :dn:cls:`Microsoft.AspNet.Localization.CookieRequestCultureProvider`
        Determines the culture information for a request via the value of a cookie.


    class :dn:cls:`Microsoft.AspNet.Localization.CustomRequestCultureProvider`
        Determines the culture information for a request via the configured delegate.


    class :dn:cls:`Microsoft.AspNet.Localization.ProviderCultureResult`
        Details about the cultures obtained from :any:`Microsoft.AspNet.Localization.IRequestCultureProvider`\.


    class :dn:cls:`Microsoft.AspNet.Localization.QueryStringRequestCultureProvider`
        Determines the culture information for a request via values in the query string.


    class :dn:cls:`Microsoft.AspNet.Localization.RequestCulture`
        Details about the culture for an :any:`Microsoft.AspNet.Http.HttpRequest`\.


    class :dn:cls:`Microsoft.AspNet.Localization.RequestCultureFeature`
        Provides the current request's culture information.


    class :dn:cls:`Microsoft.AspNet.Localization.RequestCultureProvider`
        An abstract base class provider for determining the culture information of an :any:`Microsoft.AspNet.Http.HttpRequest`\.


    class :dn:cls:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware`
        Enables automatic setting of the culture for :any:`Microsoft.AspNet.Http.HttpRequest`\s based on information
        sent by the client in headers and logic provided by the application.


    class :dn:cls:`Microsoft.AspNet.Localization.RequestLocalizationOptions`
        Specifies options for the :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware`\.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Localization.IRequestCultureFeature`
        Represents the feature that provides the current request's culture information.


    interface :dn:iface:`Microsoft.AspNet.Localization.IRequestCultureProvider`
        Represents a provider for determining the culture information of an :any:`Microsoft.AspNet.Http.HttpRequest`\.


