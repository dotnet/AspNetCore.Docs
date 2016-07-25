

JwtBearerEvents Class
=====================






Specifies events which the :any:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware` invokes to enable developer control over the authentication process.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.JwtBearer`
Assemblies
    * Microsoft.AspNetCore.Authentication.JwtBearer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents`








Syntax
------

.. code-block:: csharp

    public class JwtBearerEvents : IJwtBearerEvents








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.AuthenticationFailed(Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.Challenge(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task Challenge(JwtBearerChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.MessageReceived(Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task MessageReceived(MessageReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.TokenValidated(Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task TokenValidated(TokenValidatedContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnAuthenticationFailed
    
        
    
        
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext<Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<AuthenticationFailedContext, Task> OnAuthenticationFailed { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnChallenge
    
        
    
        
        Invoked before a challenge is sent back to the caller.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext<Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<JwtBearerChallengeContext, Task> OnChallenge { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnMessageReceived
    
        
    
        
        Invoked when a protocol message is first received.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext<Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<MessageReceivedContext, Task> OnMessageReceived { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnTokenValidated
    
        
    
        
        Invoked after the security token has passed validation and a ClaimsIdentity has been generated.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext<Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<TokenValidatedContext, Task> OnTokenValidated { get; set; }
    

