

OpenIdConnectDefaults Class
===========================



.. contents:: 
   :local:



Summary
-------

Default values related to OpenIdConnect authentication middleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults`








Syntax
------

.. code-block:: csharp

   public class OpenIdConnectDefaults





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OpenIdConnect/OpenIdConnectDefaults.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults

Fields
------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationPropertiesKey
    
        
    
        Constant used to identify state in openIdConnect protocol message.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string AuthenticationPropertiesKey
    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme
    
        
    
        The default value used for OpenIdConnectOptions.AuthenticationScheme.
    
        
    
        
        .. code-block:: csharp
    
           public const string AuthenticationScheme
    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults.Caption
    
        
    
        The default value for OpenIdConnectOptions.Caption.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string Caption
    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults.CookieNoncePrefix
    
        
    
        The prefix used to for the nonce in the cookie.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string CookieNoncePrefix
    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults.CookieStatePrefix
    
        
    
        The prefix used for the state in the cookie.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string CookieStatePrefix
    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults.RedirectUriForCodePropertiesKey
    
        
    
        The property for the RedirectUri that was used when asking for a 'authorizationCode'.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string RedirectUriForCodePropertiesKey
    
    .. dn:field:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults.UserstatePropertiesKey
    
        
    
        Constant used to identify userstate inside AuthenticationProperties that have been serialized in the 'state' parameter.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string UserstatePropertiesKey
    

