

IHttpAuthenticationFeature Interface
====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpAuthenticationFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/Authentication/IHttpAuthenticationFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature.Handler
    
        
        :rtype: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
           IAuthenticationHandler Handler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.IHttpAuthenticationFeature.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           ClaimsPrincipal User { get; set; }
    

