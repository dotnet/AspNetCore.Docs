

TicketReceivedContext Class
===========================



.. contents:: 
   :local:



Summary
-------

Provides context information to middleware providers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.TicketReceivedContext`








Syntax
------

.. code-block:: csharp

   public class TicketReceivedContext : BaseControlContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/Events/TicketReceivedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.TicketReceivedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.TicketReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.TicketReceivedContext.TicketReceivedContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.RemoteAuthenticationOptions, Microsoft.AspNet.Authentication.AuthenticationTicket)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions
        
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public TicketReceivedContext(HttpContext context, RemoteAuthenticationOptions options, AuthenticationTicket ticket)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.TicketReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.TicketReceivedContext.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.RemoteAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public RemoteAuthenticationOptions Options { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.TicketReceivedContext.Principal
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal Principal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.TicketReceivedContext.Properties
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.TicketReceivedContext.ReturnUri
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ReturnUri { get; set; }
    

