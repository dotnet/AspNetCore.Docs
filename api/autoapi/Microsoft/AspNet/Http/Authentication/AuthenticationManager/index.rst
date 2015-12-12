

AuthenticationManager Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Authentication.AuthenticationManager`








Syntax
------

.. code-block:: csharp

   public abstract class AuthenticationManager





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/Authentication/AuthenticationManager.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationManager

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.AuthenticateAsync(Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public abstract Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.AuthenticateAsync(System.String)
    
        
        
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}
    
        
        .. code-block:: csharp
    
           public virtual Task<ClaimsPrincipal> AuthenticateAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.ChallengeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ChallengeAsync()
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.ChallengeAsync(Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ChallengeAsync(AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.ChallengeAsync(System.String)
    
        
        
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ChallengeAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.ChallengeAsync(System.String, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ChallengeAsync(string authenticationScheme, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.ChallengeAsync(System.String, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, Microsoft.AspNet.Http.Features.Authentication.ChallengeBehavior)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :type behavior: Microsoft.AspNet.Http.Features.Authentication.ChallengeBehavior
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public abstract Task ChallengeAsync(string authenticationScheme, AuthenticationProperties properties, ChallengeBehavior behavior)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.ForbidAsync(System.String)
    
        
        
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ForbidAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.ForbidAsync(System.String, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ForbidAsync(string authenticationScheme, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.GetAuthenticationSchemes()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Http.Authentication.AuthenticationDescription}
    
        
        .. code-block:: csharp
    
           public abstract IEnumerable<AuthenticationDescription> GetAuthenticationSchemes()
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.SignInAsync(System.String, System.Security.Claims.ClaimsPrincipal)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task SignInAsync(string authenticationScheme, ClaimsPrincipal principal)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.SignInAsync(System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public abstract Task SignInAsync(string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.SignOutAsync(System.String)
    
        
        
        
        :type authenticationScheme: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task SignOutAsync(string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.SignOutAsync(System.String, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public abstract Task SignOutAsync(string authenticationScheme, AuthenticationProperties properties)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Http.Authentication.AuthenticationManager.AutomaticScheme
    
        
    
        Constant used to represent the automatic scheme
    
        
    
        
        .. code-block:: csharp
    
           public const string AutomaticScheme
    

