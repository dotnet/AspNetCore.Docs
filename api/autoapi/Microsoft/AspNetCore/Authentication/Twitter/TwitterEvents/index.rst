

TwitterEvents Class
===================






Default :any:`Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents` implementation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Twitter`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents`








Syntax
------

.. code-block:: csharp

    public class TwitterEvents : RemoteAuthenticationEvents, ITwitterEvents, IRemoteAuthenticationEvents








.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents.OnCreatingTicket
    
        
    
        
        Gets or sets the function that is invoked when the Authenticated method is invoked.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext<Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<TwitterCreatingTicketContext, Task> OnCreatingTicket
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents.OnRedirectToAuthorizationEndpoint
    
        
    
        
        Gets or sets the delegate that is invoked when the ApplyRedirect method is invoked.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext<Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<TwitterRedirectToAuthorizationEndpointContext, Task> OnRedirectToAuthorizationEndpoint
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents.CreatingTicket(Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext)
    
        
    
        
        Invoked whenever Twitter successfully authenticates a user
    
        
    
        
        :param context: Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.
        
        :type context: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` representing the completed operation.
    
        
        .. code-block:: csharp
    
            public virtual Task CreatingTicket(TwitterCreatingTicketContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents.RedirectToAuthorizationEndpoint(Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext)
    
        
    
        
        Called when a Challenge causes a redirect to authorize endpoint in the Twitter middleware
    
        
    
        
        :param context: Contains redirect URI and :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` of the challenge 
        
        :type context: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToAuthorizationEndpoint(TwitterRedirectToAuthorizationEndpointContext context)
    

