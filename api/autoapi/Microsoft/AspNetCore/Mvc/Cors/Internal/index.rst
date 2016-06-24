

Microsoft.AspNetCore.Mvc.Cors.Internal Namespace
================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Cors/Internal/CorsApplicationModelProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Cors/Internal/CorsAuthorizationFilterFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Cors/Internal/DisableCorsAuthorizationFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Cors/Internal/ICorsAuthorizationFilter/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Cors.Internal


    .. rubric:: Interfaces


    interface :dn:iface:`ICorsAuthorizationFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Cors.Internal.ICorsAuthorizationFilter

        
        A filter that can be used to enable/disable CORS support for a resource.


    .. rubric:: Classes


    class :dn:cls:`CorsApplicationModelProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Cors.Internal.CorsApplicationModelProvider

        


    class :dn:cls:`CorsAuthorizationFilterFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory

        
        A filter factory which creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Cors.CorsAuthorizationFilter`\.


    class :dn:cls:`DisableCorsAuthorizationFilter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Cors.Internal.DisableCorsAuthorizationFilter

        
        An :any:`Microsoft.AspNetCore.Mvc.Cors.Internal.ICorsAuthorizationFilter` which ensures that an action does not run for a pre-flight request.


