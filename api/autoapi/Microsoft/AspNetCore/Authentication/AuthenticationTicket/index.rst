

AuthenticationTicket Class
==========================






Contains user identity information as well as additional authentication state.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationTicket`








Syntax
------

.. code-block:: csharp

    public class AuthenticationTicket








.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationTicket

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.AuthenticationTicket.AuthenticationTicket(System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Authentication.AuthenticationTicket` class
    
        
    
        
        :param principal: the :any:`System.Security.Claims.ClaimsPrincipal` that represents the authenticated user.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param properties: additional properties that can be consumed by the user or runtime.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param authenticationScheme: the authentication middleware that was responsible for this ticket.
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
            public AuthenticationTicket(ClaimsPrincipal principal, AuthenticationProperties properties, string authenticationScheme)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationTicket.AuthenticationScheme
    
        
    
        
        Gets the authentication type.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationTicket.Principal
    
        
    
        
        Gets the claims-principal with authenticated user identities.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationTicket.Properties
    
        
    
        
        Additional state values for the authentication session.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; }
    

