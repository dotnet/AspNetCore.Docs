

DefaultAuthenticationManager Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Authentication.AuthenticationManager`
* :dn:cls:`Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager`








Syntax
------

.. code-block:: csharp

   public class DefaultAuthenticationManager : AuthenticationManager, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Authentication/DefaultAuthenticationManager.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager.DefaultAuthenticationManager(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public DefaultAuthenticationManager(IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager.AuthenticateAsync(Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.Authentication.AuthenticateContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task AuthenticateAsync(AuthenticateContext context)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager.ChallengeAsync(System.String, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, Microsoft.AspNet.Http.Features.Authentication.ChallengeBehavior)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :type behavior: Microsoft.AspNet.Http.Features.Authentication.ChallengeBehavior
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ChallengeAsync(string authenticationScheme, AuthenticationProperties properties, ChallengeBehavior behavior)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager.GetAuthenticationSchemes()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Http.Authentication.AuthenticationDescription}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<AuthenticationDescription> GetAuthenticationSchemes()
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager.SignInAsync(System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task SignInAsync(string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNet.Http.Authentication.Internal.DefaultAuthenticationManager.SignOutAsync(System.String, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task SignOutAsync(string authenticationScheme, AuthenticationProperties properties)
    

