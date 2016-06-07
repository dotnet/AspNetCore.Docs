

TicketReceivedContext Class
===========================






Provides context information to middleware providers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.TicketReceivedContext`








Syntax
------

.. code-block:: csharp

    public class TicketReceivedContext : BaseControlContext








.. dn:class:: Microsoft.AspNetCore.Authentication.TicketReceivedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketReceivedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.TicketReceivedContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public RemoteAuthenticationOptions Options
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.TicketReceivedContext.Principal
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.TicketReceivedContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.TicketReceivedContext.ReturnUri
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ReturnUri
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.TicketReceivedContext.TicketReceivedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions, Microsoft.AspNetCore.Authentication.AuthenticationTicket)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions
    
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public TicketReceivedContext(HttpContext context, RemoteAuthenticationOptions options, AuthenticationTicket ticket)
    

