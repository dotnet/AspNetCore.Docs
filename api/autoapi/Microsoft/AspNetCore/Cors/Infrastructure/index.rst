

Microsoft.AspNetCore.Cors.Infrastructure Namespace
==================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/CorsConstants/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/CorsMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/CorsOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/CorsPolicy/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/CorsPolicyBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/CorsResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/CorsService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/DefaultCorsPolicyProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/ICorsPolicyProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/ICorsService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/IDisableCorsAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Cors/Infrastructure/IEnableCorsAttribute/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Cors.Infrastructure


    .. rubric:: Classes


    class :dn:cls:`CorsConstants`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.CorsConstants

        
        CORS-related constants.


    class :dn:cls:`CorsMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware

        
        An ASP.NET middleware for handling CORS.


    class :dn:cls:`CorsOptions`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions

        
        Provides programmatic configuration for Cors.


    class :dn:cls:`CorsPolicy`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy

        
        Defines the policy for Cross-Origin requests based on the CORS specifications.


    class :dn:cls:`CorsPolicyBuilder`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder

        
        Exposes methods to build a policy.


    class :dn:cls:`CorsResult`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.CorsResult

        
        Results returned by :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsService`\.


    class :dn:cls:`CorsService`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.CorsService

        
        Default implementation of :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsService`\.


    class :dn:cls:`DefaultCorsPolicyProvider`
        .. object: type=class name=Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider

        


    .. rubric:: Interfaces


    interface :dn:iface:`ICorsPolicyProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider

        
        A type which can provide a :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` for a particular :any:`Microsoft.AspNetCore.Http.HttpContext`\.


    interface :dn:iface:`ICorsService`
        .. object: type=interface name=Microsoft.AspNetCore.Cors.Infrastructure.ICorsService

        
        A type which can evaluate a policy for a particular :any:`Microsoft.AspNetCore.Http.HttpContext`\.


    interface :dn:iface:`IDisableCorsAttribute`
        .. object: type=interface name=Microsoft.AspNetCore.Cors.Infrastructure.IDisableCorsAttribute

        
        An interface which can be used to identify a type which provides metdata to disable cors for a resource.


    interface :dn:iface:`IEnableCorsAttribute`
        .. object: type=interface name=Microsoft.AspNetCore.Cors.Infrastructure.IEnableCorsAttribute

        
        An interface which can be used to identify a type which provides metadata needed for enabling CORS support.


