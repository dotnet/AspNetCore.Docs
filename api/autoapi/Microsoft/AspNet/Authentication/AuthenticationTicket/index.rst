

AuthenticationTicket Class
==========================



.. contents:: 
   :local:



Summary
-------

Contains user identity information as well as additional authentication state.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationTicket`








Syntax
------

.. code-block:: csharp

   public class AuthenticationTicket





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/AuthenticationTicket.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationTicket

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationTicket
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.AuthenticationTicket.AuthenticationTicket(System.Security.Claims.ClaimsPrincipal, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Authentication.AuthenticationTicket` class
    
        
        
        
        :param principal: the  that represents the authenticated user.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        
        
        :param properties: additional properties that can be consumed by the user or runtime.
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :param authenticationScheme: the authentication middleware that was responsible for this ticket.
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
           public AuthenticationTicket(ClaimsPrincipal principal, AuthenticationProperties properties, string authenticationScheme)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationTicket
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationTicket.AuthenticationScheme
    
        
    
        Gets the authentication type.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationTicket.Principal
    
        
    
        Gets the claims-principal with authenticated user identities.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationTicket.Properties
    
        
    
        Additional state values for the authentication session.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; }
    

