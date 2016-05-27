

DefaultAuthenticationManager Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Authentication.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Authentication.AuthenticationManager`
* :dn:cls:`Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager`








Syntax
------

.. code-block:: csharp

    public class DefaultAuthenticationManager : AuthenticationManager








.. dn:class:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public override HttpContext HttpContext
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.DefaultAuthenticationManager(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public DefaultAuthenticationManager(HttpContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.AuthenticateAsync(Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.ChallengeAsync(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :type behavior: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ChallengeAsync(string authenticationScheme, AuthenticationProperties properties, ChallengeBehavior behavior)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.GetAuthenticationSchemes()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription<Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription>}
    
        
        .. code-block:: csharp
    
            public override IEnumerable<AuthenticationDescription> GetAuthenticationSchemes()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.Initialize(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public virtual void Initialize(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.SignInAsync(System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task SignInAsync(string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.SignOutAsync(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task SignOutAsync(string authenticationScheme, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Authentication.Internal.DefaultAuthenticationManager.Uninitialize()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Uninitialize()
    

