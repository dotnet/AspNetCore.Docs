

RemoteAuthenticationHandler<TOptions> Class
===========================================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationHandler{{TOptions}}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler\<TOptions>`








Syntax
------

.. code-block:: csharp

    public abstract class RemoteAuthenticationHandler<TOptions> : AuthenticationHandler<TOptions>, IAuthenticationHandler where TOptions : RemoteAuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.GenerateCorrelationId(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            protected virtual void GenerateCorrelationId(AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticateResult<Microsoft.AspNetCore.Authentication.AuthenticateResult>}
    
        
        .. code-block:: csharp
    
            protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleForbiddenAsync(Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected override Task<bool> HandleForbiddenAsync(ChallengeContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleRemoteAuthenticateAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticateResult<Microsoft.AspNetCore.Authentication.AuthenticateResult>}
    
        
        .. code-block:: csharp
    
            protected abstract Task<AuthenticateResult> HandleRemoteAuthenticateAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleRemoteCallbackAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            protected virtual Task<bool> HandleRemoteCallbackAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleRequestAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public override Task<bool> HandleRequestAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleSignInAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignInContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task HandleSignInAsync(SignInContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.HandleSignOutAsync(Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task HandleSignOutAsync(SignOutContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler<TOptions>.ValidateCorrelationId(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual bool ValidateCorrelationId(AuthenticationProperties properties)
    

