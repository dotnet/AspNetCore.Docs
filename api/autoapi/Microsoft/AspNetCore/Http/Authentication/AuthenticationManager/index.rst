

AuthenticationManager Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Authentication`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Authentication.AuthenticationManager`








Syntax
------

.. code-block:: csharp

    public abstract class AuthenticationManager








.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.AuthenticateAsync(Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public abstract Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.AuthenticateAsync(System.String)
    
        
    
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}
    
        
        .. code-block:: csharp
    
            public virtual Task<ClaimsPrincipal> AuthenticateAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ChallengeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task ChallengeAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ChallengeAsync(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task ChallengeAsync(AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ChallengeAsync(System.String)
    
        
    
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task ChallengeAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ChallengeAsync(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task ChallengeAsync(string authenticationScheme, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ChallengeAsync(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :type behavior: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public abstract Task ChallengeAsync(string authenticationScheme, AuthenticationProperties properties, ChallengeBehavior behavior)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ForbidAsync()
    
        
    
        
        Creates a challenge for the authentication manager with :dn:field:`Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior.Forbidden`\.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that represents the asynchronous challenge operation.
    
        
        .. code-block:: csharp
    
            public virtual Task ForbidAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ForbidAsync(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Creates a challenge for the authentication manager with :dn:field:`Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior.Forbidden`\.
    
        
    
        
        :param properties: Additional arbitrary values which may be used by particular authentication types.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that represents the asynchronous challenge operation.
    
        
        .. code-block:: csharp
    
            public virtual Task ForbidAsync(AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ForbidAsync(System.String)
    
        
    
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task ForbidAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.ForbidAsync(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task ForbidAsync(string authenticationScheme, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.GetAuthenticateInfoAsync(System.String)
    
        
    
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo<Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo>}
    
        
        .. code-block:: csharp
    
            public abstract Task<AuthenticateInfo> GetAuthenticateInfoAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.GetAuthenticationSchemes()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription<Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription>}
    
        
        .. code-block:: csharp
    
            public abstract IEnumerable<AuthenticationDescription> GetAuthenticationSchemes()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.SignInAsync(System.String, System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task SignInAsync(string authenticationScheme, ClaimsPrincipal principal)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.SignInAsync(System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public abstract Task SignInAsync(string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.SignOutAsync(System.String)
    
        
    
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task SignOutAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.SignOutAsync(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public abstract Task SignOutAsync(string authenticationScheme, AuthenticationProperties properties)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.AutomaticScheme
    
        
    
        
        Constant used to represent the automatic scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string AutomaticScheme = "Automatic"
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public abstract HttpContext HttpContext { get; }
    

