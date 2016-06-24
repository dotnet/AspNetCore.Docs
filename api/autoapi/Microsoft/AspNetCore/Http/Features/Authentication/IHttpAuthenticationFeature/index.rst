

IHttpAuthenticationFeature Interface
====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features.Authentication`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpAuthenticationFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature.Handler
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
            IAuthenticationHandler Handler { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            ClaimsPrincipal User { get; set; }
    

