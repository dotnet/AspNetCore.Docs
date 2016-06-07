

IJwtBearerEvents Interface
==========================






Specifies events which the :any:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware` invokes to enable developer control over the authentication process.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.JwtBearer`
Assemblies
    * Microsoft.AspNetCore.Authentication.JwtBearer

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IJwtBearerEvents








.. dn:interface:: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents.AuthenticationFailed(Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext)
    
        
    
        
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents.Challenge(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext)
    
        
    
        
        Invoked to apply a challenge sent back to the caller.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task Challenge(JwtBearerChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents.MessageReceived(Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext)
    
        
    
        
        Invoked when a protocol message is first received.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.MessageReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task MessageReceived(MessageReceivedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.IJwtBearerEvents.TokenValidated(Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext)
    
        
    
        
        Invoked after the security token has passed validation and a ClaimsIdentity has been generated.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task TokenValidated(TokenValidatedContext context)
    

