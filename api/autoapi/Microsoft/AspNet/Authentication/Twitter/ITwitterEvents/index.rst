

ITwitterEvents Interface
========================



.. contents:: 
   :local:



Summary
-------

Specifies callback methods which the :any:`Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware` invokes to enable developer control over the authentication process. /&gt;











Syntax
------

.. code-block:: csharp

   public interface ITwitterEvents : IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Twitter/Events/ITwitterEvents.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.Twitter.ITwitterEvents

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.Twitter.ITwitterEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Twitter.ITwitterEvents.CreatingTicket(Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext)
    
        
    
        Invoked whenever Twitter succesfully authenticates a user
    
        
        
        
        :param context: Contains information about the login session as well as the user .
        
        :type context: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.
    
        
        .. code-block:: csharp
    
           Task CreatingTicket(TwitterCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Twitter.ITwitterEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext)
    
        
    
        Called when a Challenge causes a redirect to authorize endpoint in the Twitter middleware
    
        
        
        
        :param context: Contains redirect URI and  of the challenge
        
        :type context: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToAuthorizationEndpoint(TwitterRedirectToAuthorizationEndpointContext context)
    

