

OpenIdConnectRedirectBehavior Enum
==================================






Lists the different authentication methods used to
redirect the user agent to the identity provider.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum OpenIdConnectRedirectBehavior








.. dn:enumeration:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior.FormPost
    
        
    
        
        Emits an HTML form to redirect the user agent to
        the OpenID Connect provider using a POST request.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior
    
        
        .. code-block:: csharp
    
            FormPost = 1
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior.RedirectGet
    
        
    
        
        Emits a 302 response to redirect the user agent to
        the OpenID Connect provider using a GET request.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior
    
        
        .. code-block:: csharp
    
            RedirectGet = 0
    

