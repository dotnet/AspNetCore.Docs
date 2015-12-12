

JwtBearerEvents Class
=====================



.. contents:: 
   :local:



Summary
-------

OpenIdConnect bearer token middleware events.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents`








Syntax
------

.. code-block:: csharp

   public class JwtBearerEvents : IJwtBearerEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.JwtBearer/Events/JwtBearerEvents.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.AuthenticationFailed(Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task AuthenticationFailed(AuthenticationFailedContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.Challenge(Microsoft.AspNet.Authentication.JwtBearer.JwtBearerChallengeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerChallengeContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task Challenge(JwtBearerChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.ReceivedToken(Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ReceivedToken(ReceivedTokenContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.ReceivingToken(Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ReceivingToken(ReceivingTokenContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.ValidatedToken(Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ValidatedToken(ValidatedTokenContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.OnAuthenticationFailed
    
        
    
        Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.JwtBearer.AuthenticationFailedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<AuthenticationFailedContext, Task> OnAuthenticationFailed { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.OnChallenge
    
        
    
        Invoked to apply a challenge sent back to the caller.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.JwtBearer.JwtBearerChallengeContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<JwtBearerChallengeContext, Task> OnChallenge { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.OnReceivedToken
    
        
    
        Invoked with the security token that has been extracted from the protocol message.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.JwtBearer.ReceivedTokenContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<ReceivedTokenContext, Task> OnReceivedToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.OnReceivingToken
    
        
    
        Invoked when a protocol message is first received.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.JwtBearer.ReceivingTokenContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<ReceivingTokenContext, Task> OnReceivingToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerEvents.OnValidatedToken
    
        
    
        Invoked after the security token has passed validation and a ClaimsIdentity has been generated.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.JwtBearer.ValidatedTokenContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<ValidatedTokenContext, Task> OnValidatedToken { get; set; }
    

