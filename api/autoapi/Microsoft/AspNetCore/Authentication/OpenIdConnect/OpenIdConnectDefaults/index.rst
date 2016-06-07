

OpenIdConnectDefaults Class
===========================






Default values related to OpenIdConnect authentication middleware


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults`








Syntax
------

.. code-block:: csharp

    public class OpenIdConnectDefaults








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults

Fields
------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationPropertiesKey
    
        
    
        
        Constant used to identify state in openIdConnect protocol message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string AuthenticationPropertiesKey
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme
    
        
    
        
        The default value used for OpenIdConnectOptions.AuthenticationScheme.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string AuthenticationScheme = "OpenIdConnect"
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.Caption
    
        
    
        
        The default value for OpenIdConnectOptions.Caption.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string Caption
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.CookieNoncePrefix
    
        
    
        
        The prefix used to for the nonce in the cookie.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string CookieNoncePrefix
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.RedirectUriForCodePropertiesKey
    
        
    
        
        The property for the RedirectUri that was used when asking for a 'authorizationCode'.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string RedirectUriForCodePropertiesKey
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.UserstatePropertiesKey
    
        
    
        
        Constant used to identify userstate inside AuthenticationProperties that have been serialized in the 'state' parameter.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string UserstatePropertiesKey
    

