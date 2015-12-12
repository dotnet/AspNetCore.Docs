

RemoteAuthenticationHandler<TOptions> Class
===========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationHandler{{TOptions}}`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationHandler\<TOptions>`








Syntax
------

.. code-block:: csharp

   public abstract class RemoteAuthenticationHandler<TOptions> : AuthenticationHandler<TOptions>, IAuthenticationHandler where TOptions : RemoteAuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/RemoteAuthenticationHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>.HandleAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticateResult}
    
        
        .. code-block:: csharp
    
           protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>.HandleForbiddenAsync(Microsoft.AspNet.Http.Features.Authentication.ChallengeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           protected override Task<bool> HandleForbiddenAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>.HandleRemoteAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticateResult}
    
        
        .. code-block:: csharp
    
           protected abstract Task<AuthenticateResult> HandleRemoteAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>.HandleRemoteCallbackAsync()
    
        
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           protected virtual Task<bool> HandleRemoteCallbackAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>.HandleRequestAsync()
    
        
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           public override Task<bool> HandleRequestAsync()
    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>.HandleSignInAsync(Microsoft.AspNet.Http.Features.Authentication.SignInContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected override Task HandleSignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationHandler<TOptions>.HandleSignOutAsync(Microsoft.AspNet.Http.Features.Authentication.SignOutContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected override Task HandleSignOutAsync(SignOutContext context)
    

