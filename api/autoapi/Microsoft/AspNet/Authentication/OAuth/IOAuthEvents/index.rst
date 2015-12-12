

IOAuthEvents Interface
======================



.. contents:: 
   :local:



Summary
-------

Specifies callback methods which the OAuthMiddleware invokes to enable developer control over the authentication process.











Syntax
------

.. code-block:: csharp

   public interface IOAuthEvents : IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OAuth/Events/IOAuthEvents.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.OAuth.IOAuthEvents

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.OAuth.IOAuthEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.IOAuthEvents.CreatingTicket(Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext)
    
        
    
        Invoked after the provider successfully authenticates a user. This can be used to retrieve user information.
        This event may not be invoked by sub-classes of OAuthAuthenticationHandler if they override CreateTicketAsync.
    
        
        
        
        :param context: Contains information about the login session.
        
        :type context: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.
    
        
        .. code-block:: csharp
    
           Task CreatingTicket(OAuthCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.IOAuthEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext)
    
        
    
        Called when a Challenge causes a redirect to the authorize endpoint.
    
        
        
        
        :param context: Contains redirect URI and  of the challenge.
        
        :type context: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToAuthorizationEndpoint(OAuthRedirectToAuthorizationContext context)
    

