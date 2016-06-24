

Microsoft.AspNetCore.Mvc.Authorization Namespace
================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Authorization/AllowAnonymousFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Authorization/AuthorizeFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Authorization/IAllowAnonymousFilter/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Authorization


    .. rubric:: Interfaces


    interface :dn:iface:`IAllowAnonymousFilter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Authorization.IAllowAnonymousFilter

        
        A filter that allows anonymous requests, disabling some :any:`Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter`\s.


    .. rubric:: Classes


    class :dn:cls:`AllowAnonymousFilter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.Authorization.IAllowAnonymousFilter`


    class :dn:cls:`AuthorizeFilter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter` which applies a specific 
        :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy`\. MVC recognizes the :any:`Microsoft.AspNetCore.Authorization.AuthorizeAttribute` and adds an instance of
        this filter to the associated action or controller.


