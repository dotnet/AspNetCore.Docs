

SignInManager<TUser> Class
==========================



.. contents:: 
   :local:



Summary
-------

Provides the APIs for user sign in.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.SignInManager\<TUser>`








Syntax
------

.. code-block:: csharp

   public class SignInManager<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/SignInManager.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.SignInManager<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.SignInManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.SignInManager<TUser>.SignInManager(Microsoft.AspNet.Identity.UserManager<TUser>, Microsoft.AspNet.Http.IHttpContextAccessor, Microsoft.AspNet.Identity.IUserClaimsPrincipalFactory<TUser>, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Identity.IdentityOptions>, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNet.Identity.SignInManager<TUser>>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Identity.SignInManager\`1`\.
    
        
        
        
        :param userManager: An instance of  used to retrieve users from and persist users.
        
        :type userManager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param contextAccessor: The accessor used to access the .
        
        :type contextAccessor: Microsoft.AspNet.Http.IHttpContextAccessor
        
        
        :param claimsFactory: The factory to use to create claims principals for a user.
        
        :type claimsFactory: Microsoft.AspNet.Identity.IUserClaimsPrincipalFactory{{TUser}}
        
        
        :param optionsAccessor: The accessor used to access the .
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Identity.IdentityOptions}
        
        
        :param logger: The logger used to log messages, warnings and errors.
        
        :type logger: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Identity.SignInManager`1}
    
        
        .. code-block:: csharp
    
           public SignInManager(UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TUser>> logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.SignInManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.CanSignInAsync(TUser)
    
        
    
        Returns a flag indicating whether the specified user can sign in.
    
        
        
        
        :param user: The user whose sign-in status should be returned.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The task object representing the asynchronous operation, containing a flag that is true
            if the specified user can sign-in, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> CanSignInAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.ConfigureExternalAuthenticationProperties(System.String, System.String, System.String)
    
        
    
        Configures the redirect URL and user identifier for the specified external login ``provider``.
    
        
        
        
        :param provider: The provider to configure.
        
        :type provider: System.String
        
        
        :param redirectUrl: The external login URL users should be redirected to during the login glow.
        
        :type redirectUrl: System.String
        
        
        :param userId: The current user's identifier, which will be used to provide CSRF protection.
        
        :type userId: System.String
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :return: A configured <see cref="T:Microsoft.AspNet.Http.Authentication.AuthenticationProperties" />.
    
        
        .. code-block:: csharp
    
           public virtual AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.CreateUserPrincipalAsync(TUser)
    
        
    
        Creates a :any:`System.Security.Claims.ClaimsPrincipal` for the specified ``user``, as an asynchronous operation.
    
        
        
        
        :param user: The user to create a  for.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}
        :return: The task object representing the asynchronous operation, containing the ClaimsPrincipal for the specified user.
    
        
        .. code-block:: csharp
    
           public virtual Task<ClaimsPrincipal> CreateUserPrincipalAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.ExternalLoginSignInAsync(System.String, System.String, System.Boolean)
    
        
    
        Signs in a user via a previously registered third party login, as an asynchronous operation.
    
        
        
        
        :param loginProvider: The login provider to use.
        
        :type loginProvider: System.String
        
        
        :param providerKey: The unique provider identifier for the user.
        
        :type providerKey: System.String
        
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.SignInResult}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult" />
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
           public virtual Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.ForgetTwoFactorClientAsync()
    
        
    
        Clears the "Remember this browser flag" from the current browser, as an asynchronous operation.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task ForgetTwoFactorClientAsync()
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.GetExternalAuthenticationSchemes()
    
        
    
        Gets a collection of :any:`Microsoft.AspNet.Http.Authentication.AuthenticationDescription`\s for the known external login providers.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Http.Authentication.AuthenticationDescription}
        :return: A collection of <see cref="T:Microsoft.AspNet.Http.Authentication.AuthenticationDescription" />s for the known external login providers.
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<AuthenticationDescription> GetExternalAuthenticationSchemes()
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.GetExternalLoginInfoAsync(System.String)
    
        
    
        Gets the external login information for the current login, as an asynchronous operation.
    
        
        
        
        :param expectedXsrf: Flag indication whether a Cross Site Request Forgery token was expected in the current request.
        
        :type expectedXsrf: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.ExternalLoginInfo}
        :return: The task object representing the asynchronous operation containing the <see name="ExternalLoginInfo" />
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
           public virtual Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.GetTwoFactorAuthenticationUserAsync()
    
        
    
        Gets the ``TUser`` for the current two factor authentication login, as an asynchronous operation.
    
        
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The task object representing the asynchronous operation containing the <typeparamref name="TUser" />
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
           public virtual Task<TUser> GetTwoFactorAuthenticationUserAsync()
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.IsTwoFactorClientRememberedAsync(TUser)
    
        
    
        Returns a flag indicating if the current client browser has been remembered by two factor authentication
        for the user attempting to login, as an asynchronous operation.
    
        
        
        
        :param user: The user attempting to login.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The task object representing the asynchronous operation containing true if the browser has been remembered
            for the current user.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> IsTwoFactorClientRememberedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.PasswordSignInAsync(System.String, System.String, System.Boolean, System.Boolean)
    
        
    
        Attempts to sign in the specified ``userName`` and ``password`` combination
        as an asynchronous operation.
    
        
        
        
        :param userName: The user name to sign in.
        
        :type userName: System.String
        
        
        :param password: The password to attempt to sign in with.
        
        :type password: System.String
        
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
        
        
        :type lockoutOnFailure: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.SignInResult}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult" />
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
           public virtual Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.PasswordSignInAsync(TUser, System.String, System.Boolean, System.Boolean)
    
        
    
        Attempts to sign in the specified ``user`` and ``password`` combination
        as an asynchronous operation.
    
        
        
        
        :param user: The user to sign in.
        
        :type user: {TUser}
        
        
        :param password: The password to attempt to sign in with.
        
        :type password: System.String
        
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
        
        
        :param lockoutOnFailure: Flag indicating if the user account should be locked if the sign in fails.
        
        :type lockoutOnFailure: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.SignInResult}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult" />
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
           public virtual Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.RefreshSignInAsync(TUser)
    
        
    
        Regenerates the user's application cookie, whilst preserving the existing
        AuthenticationProperties like rememberMe, as an asynchronous operation.
    
        
        
        
        :param user: The user whose sign-in cookie should be refreshed.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task RefreshSignInAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.RememberTwoFactorClientAsync(TUser)
    
        
    
        Sets a flag on the browser to indicate the user has selected "Remember this browser" for two factor authentication purposes,
        as an asynchronous operation.
    
        
        
        
        :param user: The user who choose "remember this browser".
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task RememberTwoFactorClientAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.SignInAsync(TUser, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        Signs in the specified ``user``.
    
        
        
        
        :param user: The user to sign-in.
        
        :type user: {TUser}
        
        
        :param authenticationProperties: Properties applied to the login and authentication cookie.
        
        :type authenticationProperties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :param authenticationMethod: Name of the method used to authenticate the user.
        
        :type authenticationMethod: System.String
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.SignInAsync(TUser, System.Boolean, System.String)
    
        
    
        Signs in the specified ``user``.
    
        
        
        
        :param user: The user to sign-in.
        
        :type user: {TUser}
        
        
        :param isPersistent: Flag indicating whether the sign-in cookie should persist after the browser is closed.
        
        :type isPersistent: System.Boolean
        
        
        :param authenticationMethod: Name of the method used to authenticate the user.
        
        :type authenticationMethod: System.String
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.SignOutAsync()
    
        
    
        Signs the current user out of the application.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task SignOutAsync()
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.TwoFactorSignInAsync(System.String, System.String, System.Boolean, System.Boolean)
    
        
    
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
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.SignInResult}
        :return: The task object representing the asynchronous operation containing the <see name="SignInResult" />
            for the sign-in attempt.
    
        
        .. code-block:: csharp
    
           public virtual Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient)
    
    .. dn:method:: Microsoft.AspNet.Identity.SignInManager<TUser>.ValidateSecurityStampAsync(System.Security.Claims.ClaimsPrincipal, System.String)
    
        
    
        Validates the security stamp for the specified ``principal`` against
        the persisted stamp for the ``userId``, as an asynchronous operation.
    
        
        
        
        :param principal: The principal whose stamp should be validated.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        
        
        :param userId: The ID for the user.
        
        :type userId: System.String
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The task object representing the asynchronous operation. The task will contain the <typeparamref name="TUser" />
            if the stamp matches the persisted value, otherwise it will return false.
    
        
        .. code-block:: csharp
    
           public virtual Task<TUser> ValidateSecurityStampAsync(ClaimsPrincipal principal, string userId)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.SignInManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.SignInManager<TUser>.Logger
    
        
    
        Gets the :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected virtual ILogger Logger { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInManager<TUser>.UserManager
    
        
        :rtype: Microsoft.AspNet.Identity.UserManager{{TUser}}
    
        
        .. code-block:: csharp
    
           protected UserManager<TUser> UserManager { get; set; }
    

