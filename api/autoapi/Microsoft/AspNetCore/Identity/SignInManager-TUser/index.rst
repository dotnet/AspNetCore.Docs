

SignInManager<TUser> Class
==========================






Provides the APIs for user sign in.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.SignInManager\<TUser>`








Syntax
------

.. code-block:: csharp

    public class SignInManager<TUser>
        where TUser : class








.. dn:class:: Microsoft.AspNetCore.Identity.SignInManager`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.SignInManager<TUser>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.SignInManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.Logger
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
        :return: 
            The :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        .. code-block:: csharp
    
            protected virtual ILogger Logger
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.UserManager
    
        
        :rtype: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        .. code-block:: csharp
    
            protected UserManager<TUser> UserManager
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.SignInManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.SignInManager(Microsoft.AspNetCore.Identity.UserManager<TUser>, Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<TUser>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.IdentityOptions>, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNetCore.Identity.SignInManager<TUser>>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.SignInManager\`1`\.
    
        
    
        
        :param userManager: An instance of :dn:prop:`Microsoft.AspNetCore.Identity.SignInManager\`1.UserManager` used to retrieve users from and persist users.
        
        :type userManager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param contextAccessor: The accessor used to access the :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type contextAccessor: Microsoft.AspNetCore.Http.IHttpContextAccessor
    
        
        :param claimsFactory: The factory to use to create claims principals for a user.
        
        :type claimsFactory: Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory`1>{TUser}
    
        
        :param optionsAccessor: The accessor used to access the :any:`Microsoft.AspNetCore.Builder.IdentityOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.IdentityOptions<Microsoft.AspNetCore.Builder.IdentityOptions>}
    
        
        :param logger: The logger used to log messages, warnings and errors.
        
        :type logger: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{Microsoft.AspNetCore.Identity.SignInManager<Microsoft.AspNetCore.Identity.SignInManager`1>{TUser}}
    
        
        .. code-block:: csharp
    
            public SignInManager(UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TUser>> logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.SignInManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.CanSignInAsync(TUser)
    
        
    
        
        Returns a flag indicating whether the specified user can sign in.
    
        
    
        
        :param user: The user whose sign-in status should be returned.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The task object representing the asynchronous operation, containing a flag that is true
            if the specified user can sign-in, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> CanSignInAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.ConfigureExternalAuthenticationProperties(System.String, System.String, System.String)
    
        
    
        
        Configures the redirect URL and user identifier for the specified external login <em>provider</em>.
    
        
    
        
        :param provider: The provider to configure.
        
        :type provider: System.String
    
        
        :param redirectUrl: The external login URL users should be redirected to during the login glow.
        
        :type redirectUrl: System.String
    
        
        :param userId: The current user's identifier, which will be used to provide CSRF protection.
        
        :type userId: System.String
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :return: A configured :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties`\.
    
        
        .. code-block:: csharp
    
            public virtual AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.CreateUserPrincipalAsync(TUser)
    
        
    
        
        Creates a :any:`System.Security.Claims.ClaimsPrincipal` for the specified <em>user</em>, as an asynchronous operation.
    
        
    
        
        :param user: The user to create a :any:`System.Security.Claims.ClaimsPrincipal` for.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}
        :return: The task object representing the asynchronous operation, containing the ClaimsPrincipal for the specified user.
    
        
        .. code-block:: csharp
    
            public virtual Task<ClaimsPrincipal> CreateUserPrincipalAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.ExternalLoginSignInAsync(System.String, System.String, System.Boolean)
    
        
    
        
        Signs in a user via a previously registered third party login, as an asynchronous operation.
    
        
    
        
        :param loginProvider: The login provider to use.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The unique provider identifier for the user.
        
        :type providerKey: System.String
    
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.SignInResult<Microsoft.AspNetCore.Identity.SignInResult>}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult"></see>
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
            public virtual Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.ForgetTwoFactorClientAsync()
    
        
    
        
        Clears the "Remember this browser flag" from the current browser, as an asynchronous operation.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task ForgetTwoFactorClientAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.GetExternalAuthenticationSchemes()
    
        
    
        
        Gets a collection of :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription`\s for the known external login providers.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription<Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription>}
        :return: A collection of :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription`\s for the known external login providers.
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<AuthenticationDescription> GetExternalAuthenticationSchemes()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.GetExternalLoginInfoAsync(System.String)
    
        
    
        
        Gets the external login information for the current login, as an asynchronous operation.
    
        
    
        
        :param expectedXsrf: Flag indication whether a Cross Site Request Forgery token was expected in the current request.
        
        :type expectedXsrf: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.ExternalLoginInfo<Microsoft.AspNetCore.Identity.ExternalLoginInfo>}
        :return: The task object representing the asynchronous operation containing the <see name="ExternalLoginInfo"></see>
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
            public virtual Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.GetTwoFactorAuthenticationUserAsync()
    
        
    
        
        Gets the <em>TUser</em> for the current two factor authentication login, as an asynchronous operation.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: The task object representing the asynchronous operation containing the <em>TUser</em>
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> GetTwoFactorAuthenticationUserAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.IsSignedIn(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        Returns true if the principal has an identity with the application cookie identity
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` instance.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Boolean
        :return: True if the user is logged in with identity.
    
        
        .. code-block:: csharp
    
            public virtual bool IsSignedIn(ClaimsPrincipal principal)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.IsTwoFactorClientRememberedAsync(TUser)
    
        
    
        
        Returns a flag indicating if the current client browser has been remembered by two factor authentication
        for the user attempting to login, as an asynchronous operation.
    
        
    
        
        :param user: The user attempting to login.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The task object representing the asynchronous operation containing true if the browser has been remembered
            for the current user.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> IsTwoFactorClientRememberedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.PasswordSignInAsync(System.String, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Attempts to sign in the specified <em>userName</em> and <em>password</em> combination
        as an asynchronous operation.
    
        
    
        
        :param userName: The user name to sign in.
        
        :type userName: System.String
    
        
        :param password: The password to attempt to sign in with.
        
        :type password: System.String
    
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
    
        
        :param lockoutOnFailure: Flag indicating if the user account should be locked if the sign in fails.
        
        :type lockoutOnFailure: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.SignInResult<Microsoft.AspNetCore.Identity.SignInResult>}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult"></see>
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
            public virtual Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.PasswordSignInAsync(TUser, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Attempts to sign in the specified <em>user</em> and <em>password</em> combination
        as an asynchronous operation.
    
        
    
        
        :param user: The user to sign in.
        
        :type user: TUser
    
        
        :param password: The password to attempt to sign in with.
        
        :type password: System.String
    
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
    
        
        :param lockoutOnFailure: Flag indicating if the user account should be locked if the sign in fails.
        
        :type lockoutOnFailure: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.SignInResult<Microsoft.AspNetCore.Identity.SignInResult>}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult"></see>
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
            public virtual Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.RefreshSignInAsync(TUser)
    
        
    
        
        Regenerates the user's application cookie, whilst preserving the existing
        AuthenticationProperties like rememberMe, as an asynchronous operation.
    
        
    
        
        :param user: The user whose sign-in cookie should be refreshed.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task RefreshSignInAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.RememberTwoFactorClientAsync(TUser)
    
        
    
        
        Sets a flag on the browser to indicate the user has selected "Remember this browser" for two factor authentication purposes,
        as an asynchronous operation.
    
        
    
        
        :param user: The user who choose "remember this browser".
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task RememberTwoFactorClientAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.SignInAsync(TUser, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        
        Signs in the specified <em>user</em>.
    
        
    
        
        :param user: The user to sign-in.
        
        :type user: TUser
    
        
        :param authenticationProperties: Properties applied to the login and authentication cookie.
        
        :type authenticationProperties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param authenticationMethod: Name of the method used to authenticate the user.
        
        :type authenticationMethod: System.String
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.SignInAsync(TUser, System.Boolean, System.String)
    
        
    
        
        Signs in the specified <em>user</em>.
    
        
    
        
        :param user: The user to sign-in.
        
        :type user: TUser
    
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
    
        
        :param authenticationMethod: Name of the method used to authenticate the user.
        
        :type authenticationMethod: System.String
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.SignOutAsync()
    
        
    
        
        Signs the current user out of the application.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task SignOutAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.TwoFactorSignInAsync(System.String, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Validates the two faction sign in code and creates and signs in the user, as an asynchronous operation.
    
        
    
        
        :param provider: The two factor authentication provider to validate the code against.
        
        :type provider: System.String
    
        
        :param code: The two factor authentication code to validate.
        
        :type code: System.String
    
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
    
        
        :param rememberClient: Flag indicating whether the current browser should be remember, suppressing all further 
            two factor authentication prompts.
        
        :type rememberClient: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.SignInResult<Microsoft.AspNetCore.Identity.SignInResult>}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult"></see>
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
            public virtual Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.UpdateExternalAuthenticationTokensAsync(Microsoft.AspNetCore.Identity.ExternalLoginInfo)
    
        
    
        
        Stores any authentication tokens found in the external authentication cookie into the associated user.
    
        
    
        
        :param externalLogin: The information from the external login provider.
        
        :type externalLogin: Microsoft.AspNetCore.Identity.ExternalLoginInfo
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.SignInManager<TUser>.ValidateSecurityStampAsync(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        Validates the security stamp for the specified <em>principal</em> against
        the persisted stamp for the current user, as an asynchronous operation.
    
        
    
        
        :param principal: The principal whose stamp should be validated.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: The task object representing the asynchronous operation. The task will contain the <em>TUser</em>
            if the stamp matches the persisted value, otherwise it will return false.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> ValidateSecurityStampAsync(ClaimsPrincipal principal)
    

