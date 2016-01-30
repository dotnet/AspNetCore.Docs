

IJwtBearerEvents Interface
==========================



.. contents:: 
   :local:



Summary
-------

OpenIdConnect bearer token middleware events.











Syntax
------

.. code-block:: csharp

   public interface IJwtBearerEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.JwtBearer/Events/IJwtBearerEvents.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.JwtBearer.IJwtBearerEvents

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.JwtBearer.IJwtBearerEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.IJwtBearerEvents.AuthenticationFailed(Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext)
    
        
    
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.IJwtBearerEvents.Challenge(Microsoft.AspNet.Authentication.JwtBearer.JwtBearerChallengeContext)
    
        
    
        Invoked to apply a challenge sent back to the caller.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task Challenge(JwtBearerChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.IJwtBearerEvents.ReceivedToken(Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext)
    
        
    
        Invoked with the security token that has been extracted from the protocol message.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task ReceivedToken(ReceivedTokenContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.IJwtBearerEvents.ReceivingToken(Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext)
    
        
    
        Invoked when a protocol message is first received.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task ReceivingToken(ReceivingTokenContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.IJwtBearerEvents.ValidatedToken(Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext)
    
        
    
        Invoked after the security token has passed validation and a ClaimsIdentity has been generated.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task ValidatedToken(ValidatedTokenContext context)
    

