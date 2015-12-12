

TwitterEvents Class
===================



.. contents:: 
   :local:



Summary
-------

Default :any:`Microsoft.AspNet.Authentication.Twitter.ITwitterEvents` implementation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationEvents`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterEvents`








Syntax
------

.. code-block:: csharp

   public class TwitterEvents : RemoteAuthenticationEvents, ITwitterEvents, IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Twitter/Events/TwitterEvents.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterEvents

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Twitter.TwitterEvents.CreatingTicket(Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext)
    
        
    
        Invoked whenever Twitter successfully authenticates a user
    
        
        
        
        :param context: Contains information about the login session as well as the user .
        
        :type context: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.
    
        
        .. code-block:: csharp
    
           public virtual Task CreatingTicket(TwitterCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Twitter.TwitterEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext)
    
        
    
        Called when a Challenge causes a redirect to authorize endpoint in the Twitter middleware
    
        
        
        
        :param context: Contains redirect URI and  of the challenge
        
        :type context: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToAuthorizationEndpoint(TwitterRedirectToAuthorizationEndpointContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterEvents.OnCreatingTicket
    
        
    
        Gets or sets the function that is invoked when the Authenticated method is invoked.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<TwitterCreatingTicketContext, Task> OnCreatingTicket { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterEvents.OnRedirectToAuthorizationEndpoint
    
        
    
        Gets or sets the delegate that is invoked when the ApplyRedirect method is invoked.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<TwitterRedirectToAuthorizationEndpointContext, Task> OnRedirectToAuthorizationEndpoint { get; set; }
    

