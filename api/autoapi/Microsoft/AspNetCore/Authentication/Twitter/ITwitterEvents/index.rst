

ITwitterEvents Interface
========================






Specifies callback methods which the :any:`Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware` invokes to enable developer control over the authentication process. />


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Twitter`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITwitterEvents : IRemoteAuthenticationEvents








.. dn:interface:: Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents.CreatingTicket(Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext)
    
        
    
        
        Invoked whenever Twitter succesfully authenticates a user
    
        
    
        
        :param context: Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.
        
        :type context: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` representing the completed operation.
    
        
        .. code-block:: csharp
    
            Task CreatingTicket(TwitterCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext)
    
        
    
        
        Called when a Challenge causes a redirect to authorize endpoint in the Twitter middleware
    
        
    
        
        :param context: Contains redirect URI and :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` of the challenge 
        
        :type context: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RedirectToAuthorizationEndpoint(TwitterRedirectToAuthorizationEndpointContext context)
    

