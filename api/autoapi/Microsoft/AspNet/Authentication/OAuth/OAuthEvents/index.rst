

OAuthEvents Class
=================



.. contents:: 
   :local:



Summary
-------

Default :any:`Microsoft.AspNet.Authentication.OAuth.IOAuthEvents` implementation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationEvents`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthEvents`








Syntax
------

.. code-block:: csharp

   public class OAuthEvents : RemoteAuthenticationEvents, IOAuthEvents, IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OAuth/Events/OAuthEvents.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthEvents

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthEvents.CreatingTicket(Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext)
    
        
    
        Invoked after the provider successfully authenticates a user.
    
        
        
        
        :param context: Contains information about the login session as well as the user .
        
        :type context: Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.
    
        
        .. code-block:: csharp
    
           public virtual Task CreatingTicket(OAuthCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext)
    
        
    
        Called when a Challenge causes a redirect to authorize endpoint in the OAuth middleware.
    
        
        
        
        :param context: Contains redirect URI and  of the challenge.
        
        :type context: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToAuthorizationEndpoint(OAuthRedirectToAuthorizationContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthEvents.OnCreatingTicket
    
        
    
        Gets or sets the function that is invoked when the CreatingTicket method is invoked.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<OAuthCreatingTicketContext, Task> OnCreatingTicket { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthEvents.OnRedirectToAuthorizationEndpoint
    
        
    
        Gets or sets the delegate that is invoked when the RedirectToAuthorizationEndpoint method is invoked.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<OAuthRedirectToAuthorizationContext, Task> OnRedirectToAuthorizationEndpoint { get; set; }
    

