

HttpAuthenticationFeature Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Authentication.Internal.HttpAuthenticationFeature`








Syntax
------

.. code-block:: csharp

   public class HttpAuthenticationFeature : IHttpAuthenticationFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/Authentication/HttpAuthenticationFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.Internal.HttpAuthenticationFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.Internal.HttpAuthenticationFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Authentication.Internal.HttpAuthenticationFeature.HttpAuthenticationFeature()
    
        
    
        
        .. code-block:: csharp
    
           public HttpAuthenticationFeature()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.Internal.HttpAuthenticationFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.Internal.HttpAuthenticationFeature.Handler
    
        
        :rtype: Microsoft.AspNet.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
           public IAuthenticationHandler Handler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.Internal.HttpAuthenticationFeature.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal User { get; set; }
    

