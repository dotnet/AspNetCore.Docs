

SecurityStampValidator<TUser> Class
===================================






Provides default implementation of validation functions for security stamps.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.SecurityStampValidator\<TUser>`








Syntax
------

.. code-block:: csharp

    public class SecurityStampValidator<TUser> : ISecurityStampValidator where TUser : class








.. dn:class:: Microsoft.AspNetCore.Identity.SecurityStampValidator`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.SecurityStampValidator<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.SecurityStampValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.SecurityStampValidator<TUser>.SecurityStampValidator(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.IdentityOptions>, Microsoft.AspNetCore.Identity.SignInManager<TUser>)
    
        
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.IdentityOptions<Microsoft.AspNetCore.Builder.IdentityOptions>}
    
        
        :type signInManager: Microsoft.AspNetCore.Identity.SignInManager<Microsoft.AspNetCore.Identity.SignInManager`1>{TUser}
    
        
        .. code-block:: csharp
    
            public SecurityStampValidator(IOptions<IdentityOptions> options, SignInManager<TUser> signInManager)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.SecurityStampValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.SecurityStampValidator<TUser>.ValidateAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        
        Validates a security stamp of an identity as an asynchronous operation, and rebuilds the identity if the validation succeeds, otherwise rejects
        the identity.
    
        
    
        
        :param context: The context containing the :any:`System.Security.Claims.ClaimsPrincipal`
            and :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` to validate.
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous validation operation.
    
        
        .. code-block:: csharp
    
            public virtual Task ValidateAsync(CookieValidatePrincipalContext context)
    

