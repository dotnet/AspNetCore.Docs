

HttpAuthenticationFeature Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features.Authentication`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.Authentication.HttpAuthenticationFeature`








Syntax
------

.. code-block:: csharp

    public class HttpAuthenticationFeature : IHttpAuthenticationFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.HttpAuthenticationFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.HttpAuthenticationFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.HttpAuthenticationFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.HttpAuthenticationFeature.Handler
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler
    
        
        .. code-block:: csharp
    
            public IAuthenticationHandler Handler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.HttpAuthenticationFeature.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal User
            {
                get;
                set;
            }
    

