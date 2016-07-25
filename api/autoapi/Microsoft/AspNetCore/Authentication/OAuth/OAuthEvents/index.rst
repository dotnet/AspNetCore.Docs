

OAuthEvents Class
=================






Default :any:`Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents` implementation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OAuth`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents`








Syntax
------

.. code-block:: csharp

    public class OAuthEvents : RemoteAuthenticationEvents, IOAuthEvents, IRemoteAuthenticationEvents








.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents.CreatingTicket(Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext)
    
        
    
        
        Invoked after the provider successfully authenticates a user.
    
        
    
        
        :param context: Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.
        
        :type context: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` representing the completed operation.
    
        
        .. code-block:: csharp
    
            public virtual Task CreatingTicket(OAuthCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext)
    
        
    
        
        Called when a Challenge causes a redirect to authorize endpoint in the OAuth middleware.
    
        
    
        
        :param context: Contains redirect URI and :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` of the challenge.
        
        :type context: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToAuthorizationEndpoint(OAuthRedirectToAuthorizationContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents.OnCreatingTicket
    
        
    
        
        Gets or sets the function that is invoked when the CreatingTicket method is invoked.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext<Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<OAuthCreatingTicketContext, Task> OnCreatingTicket { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents.OnRedirectToAuthorizationEndpoint
    
        
    
        
        Gets or sets the delegate that is invoked when the RedirectToAuthorizationEndpoint method is invoked.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext<Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<OAuthRedirectToAuthorizationContext, Task> OnRedirectToAuthorizationEndpoint { get; set; }
    

