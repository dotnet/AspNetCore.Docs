

OpenIdConnectRedirectBehavior Enum
==================================



.. contents:: 
   :local:



Summary
-------

Lists the different authentication methods used to
redirect the user agent to the identity provider.











Syntax
------

.. code-block:: csharp

   public enum OpenIdConnectRedirectBehavior





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/OpenIdConnectRedirectBehavior .cs>`_





.. dn:enumeration:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior.FormPost
    
        
    
        Emits an HTML form to redirect the user agent to
        the OpenID Connect provider using a POST request.
    
        
    
        
        .. code-block:: csharp
    
           FormPost = 1
    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior.RedirectGet
    
        
    
        Emits a 302 response to redirect the user agent to
        the OpenID Connect provider using a GET request.
    
        
    
        
        .. code-block:: csharp
    
           RedirectGet = 0
    

