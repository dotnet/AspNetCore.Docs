

IOAuthEvents Interface
======================






Specifies callback methods which the :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\`1` invokes to enable developer control over the authentication process.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OAuth`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IOAuthEvents : IRemoteAuthenticationEvents








.. dn:interface:: Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents.CreatingTicket(Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext)
    
        
    
        
        Invoked after the provider successfully authenticates a user. This can be used to retrieve user information.
        This event may not be invoked by sub-classes of OAuthAuthenticationHandler if they override CreateTicketAsync.
    
        
    
        
        :param context: Contains information about the login session.
        
        :type context: Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` representing the completed operation.
    
        
        .. code-block:: csharp
    
            Task CreatingTicket(OAuthCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext)
    
        
    
        
        Called when a Challenge causes a redirect to the authorize endpoint.
    
        
    
        
        :param context: Contains redirect URI and :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` of the challenge.
        
        :type context: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RedirectToAuthorizationEndpoint(OAuthRedirectToAuthorizationContext context)
    

