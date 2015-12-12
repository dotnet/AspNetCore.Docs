

Microsoft.AspNet.Cors.Infrastructure Namespace
==============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/CorsConstants/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/CorsMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/CorsOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/CorsPolicy/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/CorsPolicyBuilder/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/CorsResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/CorsService/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/DefaultCorsPolicyProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/ICorsPolicyProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/ICorsService/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/IDisableCorsAttribute/index
   
   
   
   /autoapi/Microsoft/AspNet/Cors/Infrastructure/IEnableCorsAttribute/index
   
   











.. dn:namespace:: Microsoft.AspNet.Cors.Infrastructure


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsConstants`
        CORS-related constants.


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsMiddleware`
        An ASP.NET middleware for handling CORS.


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsOptions`
        Provides programmatic configuration for Cors.


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicy`
        Defines the policy for Cross-Origin requests based on the CORS specifications.


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder`
        Exposes methods to build a policy.


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsResult`
        Results returned by :any:`Microsoft.AspNet.Cors.Infrastructure.ICorsService`\.


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsService`
        Default implementation of :any:`Microsoft.AspNet.Cors.Infrastructure.ICorsService`\.


    class :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider`
        A type which can provide a :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicy` for a particular :any:`Microsoft.AspNet.Http.HttpContext`\.


    interface :dn:iface:`Microsoft.AspNet.Cors.Infrastructure.ICorsService`
        A type which can evaluate a policy for a particular :any:`Microsoft.AspNet.Http.HttpContext`\.


    interface :dn:iface:`Microsoft.AspNet.Cors.Infrastructure.IDisableCorsAttribute`
        An interface which can be used to identify a type which provides metdata to disable cors for a resource.


    interface :dn:iface:`Microsoft.AspNet.Cors.Infrastructure.IEnableCorsAttribute`
        An interface which can be used to identify a type which provides metadata needed for enabling CORS support.


