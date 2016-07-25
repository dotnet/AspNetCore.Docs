

UserManager<TUser> Class
========================






Provides the APIs for managing user in a persistence store.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.UserManager\<TUser>`








Syntax
------

.. code-block:: csharp

    public class UserManager<TUser> : IDisposable where TUser : class








.. dn:class:: Microsoft.AspNetCore.Identity.UserManager`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.UserManager<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.UserManager<TUser>.UserManager(Microsoft.AspNetCore.Identity.IUserStore<TUser>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.IdentityOptions>, Microsoft.AspNetCore.Identity.IPasswordHasher<TUser>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Identity.IUserValidator<TUser>>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Identity.IPasswordValidator<TUser>>, Microsoft.AspNetCore.Identity.ILookupNormalizer, Microsoft.AspNetCore.Identity.IdentityErrorDescriber, System.IServiceProvider, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNetCore.Identity.UserManager<TUser>>)
    
        
    
        
        Constructs a new instance of :any:`Microsoft.AspNetCore.Identity.UserManager\`1`\.
    
        
    
        
        :param store: The persistence store the manager will operate over.
        
        :type store: Microsoft.AspNetCore.Identity.IUserStore<Microsoft.AspNetCore.Identity.IUserStore`1>{TUser}
    
        
        :param optionsAccessor: The accessor used to access the :any:`Microsoft.AspNetCore.Builder.IdentityOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.IdentityOptions<Microsoft.AspNetCore.Builder.IdentityOptions>}
    
        
        :param passwordHasher: The password hashing implementation to use when saving passwords.
        
        :type passwordHasher: Microsoft.AspNetCore.Identity.IPasswordHasher<Microsoft.AspNetCore.Identity.IPasswordHasher`1>{TUser}
    
        
        :param userValidators: A collection of :any:`Microsoft.AspNetCore.Identity.IUserValidator\`1` to validate users against.
        
        :type userValidators: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Identity.IUserValidator<Microsoft.AspNetCore.Identity.IUserValidator`1>{TUser}}
    
        
        :param passwordValidators: A collection of :any:`Microsoft.AspNetCore.Identity.IPasswordValidator\`1` to validate passwords against.
        
        :type passwordValidators: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Identity.IPasswordValidator<Microsoft.AspNetCore.Identity.IPasswordValidator`1>{TUser}}
    
        
        :param keyNormalizer: The :any:`Microsoft.AspNetCore.Identity.ILookupNormalizer` to use when generating index keys for users.
        
        :type keyNormalizer: Microsoft.AspNetCore.Identity.ILookupNormalizer
    
        
        :param errors: The :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to provider error messages.
        
        :type errors: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        :param services: The :any:`System.IServiceProvider` used to resolve services.
        
        :type services: System.IServiceProvider
    
        
        :param logger: The logger used to log messages, warnings and errors.
        
        :type logger: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}}
    
        
        .. code-block:: csharp
    
            public UserManager(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.AccessFailedAsync(TUser)
    
        
    
        
        Increments the access failed count for the user as an asynchronous operation.
        If the failed access account is greater than or equal to the configured maximum number of attempts,
        the user will be locked out for the configured lockout time span.
    
        
    
        
        :param user: The user whose failed access count to increment.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AccessFailedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.AddClaimAsync(TUser, System.Security.Claims.Claim)
    
        
    
        
        Adds the specified <em>claim</em> to the <em>user</em>.
    
        
    
        
        :param user: The user to add the claim to.
        
        :type user: TUser
    
        
        :param claim: The claim to add.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AddClaimAsync(TUser user, Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.AddClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>)
    
        
    
        
        Adds the specified <em>claims</em> to the <em>user</em>.
    
        
    
        
        :param user: The user to add the claim to.
        
        :type user: TUser
    
        
        :param claims: The claims to add.
        
        :type claims: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AddClaimsAsync(TUser user, IEnumerable<Claim> claims)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.AddLoginAsync(TUser, Microsoft.AspNetCore.Identity.UserLoginInfo)
    
        
    
        
        Adds an external :any:`Microsoft.AspNetCore.Identity.UserLoginInfo` to the specified <em>user</em>.
    
        
    
        
        :param user: The user to add the login to.
        
        :type user: TUser
    
        
        :param login: The external :any:`Microsoft.AspNetCore.Identity.UserLoginInfo` to add to the specified <em>user</em>.
        
        :type login: Microsoft.AspNetCore.Identity.UserLoginInfo
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.AddPasswordAsync(TUser, System.String)
    
        
    
        
        Adds the <em>password</em> to the specified <em>user</em> only if the user
        does not already have a password.
    
        
    
        
        :param user: The user whose password should be set.
        
        :type user: TUser
    
        
        :param password: The password to set.
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AddPasswordAsync(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.AddToRoleAsync(TUser, System.String)
    
        
    
        
        Add the specified <em>user</em> to the named role.
    
        
    
        
        :param user: The user to add to the named role.
        
        :type user: TUser
    
        
        :param role: The name of the role to add the user to.
        
        :type role: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AddToRoleAsync(TUser user, string role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.AddToRolesAsync(TUser, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Add the specified <em>user</em> to the named roles.
    
        
    
        
        :param user: The user to add to the named roles.
        
        :type user: TUser
    
        
        :param roles: The name of the roles to add the user to.
        
        :type roles: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AddToRolesAsync(TUser user, IEnumerable<string> roles)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ChangeEmailAsync(TUser, System.String, System.String)
    
        
    
        
        Updates a users emails if the specified email change <em>token</em> is valid for the user.
    
        
    
        
        :param user: The user whose email should be updated.
        
        :type user: TUser
    
        
        :param newEmail: The new email address.
        
        :type newEmail: System.String
    
        
        :param token: The change email token to be verified.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ChangeEmailAsync(TUser user, string newEmail, string token)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ChangePasswordAsync(TUser, System.String, System.String)
    
        
    
        
        Changes a user's password after confirming the specified <em>currentPassword</em> is correct,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose password should be set.
        
        :type user: TUser
    
        
        :param currentPassword: The current password to validate before changing.
        
        :type currentPassword: System.String
    
        
        :param newPassword: The new password to set for the specified <em>user</em>.
        
        :type newPassword: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ChangePhoneNumberAsync(TUser, System.String, System.String)
    
        
    
        
        Sets the phone number for the specified <em>user</em> if the specified
        change <em>token</em> is valid.
    
        
    
        
        :param user: The user whose phone number to set.
        
        :type user: TUser
    
        
        :param phoneNumber: The phone number to set.
        
        :type phoneNumber: System.String
    
        
        :param token: The phone number confirmation token to validate.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ChangePhoneNumberAsync(TUser user, string phoneNumber, string token)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.CheckPasswordAsync(TUser, System.String)
    
        
    
        
        Returns a flag indicating whether the given <em>password</em> is valid for the
        specified <em>user</em>.
    
        
    
        
        :param user: The user whose password should be validated.
        
        :type user: TUser
    
        
        :param password: The password to validate
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing true if
            the specified <em>password</em> matches the one store for the <em>user</em>,
            otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> CheckPasswordAsync(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ConfirmEmailAsync(TUser, System.String)
    
        
    
        
        Validates that an email confirmation token matches the specified <em>user</em>.
    
        
    
        
        :param user: The user to validate the token against.
        
        :type user: TUser
    
        
        :param token: The email confirmation token to validate.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.CreateAsync(TUser)
    
        
    
        
        Creates the specified <em>user</em> in the backing store with no password,
        as an asynchronous operation.
    
        
    
        
        :param user: The user to create.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> CreateAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.CreateAsync(TUser, System.String)
    
        
    
        
        Creates the specified <em>user</em> in the backing store with given password,
        as an asynchronous operation.
    
        
    
        
        :param user: The user to create.
        
        :type user: TUser
    
        
        :param password: The password for the user to hash and store.
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> CreateAsync(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.DeleteAsync(TUser)
    
        
    
        
        Deletes the specified <em>user</em> from the backing store.
    
        
    
        
        :param user: The user to delete.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> DeleteAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.Dispose()
    
        
    
        
        Releases all resources used by the user manager.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.Dispose(System.Boolean)
    
        
    
        
        Releases the unmanaged resources used by the role manager and optionally releases the managed resources.
    
        
    
        
        :param disposing: true to release both managed and unmanaged resources; false to release only unmanaged resources.
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.FindByEmailAsync(System.String)
    
        
    
        
        Gets the user, if any, associated with the specified, normalized email address.
    
        
    
        
        :param email: The normalized email address to return the user for.
        
        :type email: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The task object containing the results of the asynchronous lookup operation, the user if any associated with the specified normalized email address.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByEmailAsync(string email)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.FindByIdAsync(System.String)
    
        
    
        
        Finds and returns a user, if any, who has the specified <em>userId</em>.
    
        
    
        
        :param userId: The user ID to search for.
        
        :type userId: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user matching the specified <em>userId</em> if it exists.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByIdAsync(string userId)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.FindByLoginAsync(System.String, System.String)
    
        
    
        
        Retrieves the user associated with the specified external login provider and login provider key..
    
        
    
        
        :param loginProvider: The login provider who provided the <em>providerKey</em>.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The key provided by the <em>loginProvider</em> to identify a user.
        
        :type providerKey: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` for the asynchronous operation, containing the user, if any which matched the specified login provider and key.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByLoginAsync(string loginProvider, string providerKey)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.FindByNameAsync(System.String)
    
        
    
        
        Finds and returns a user, if any, who has the specified user name.
    
        
    
        
        :param userName: The user name to search for.
        
        :type userName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user matching the specified <em>userName</em> if it exists.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByNameAsync(string userName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateChangeEmailTokenAsync(TUser, System.String)
    
        
    
        
        Generates an email change token for the specified user.
    
        
    
        
        :param user: The user to generate an email change token for.
        
        :type user: TUser
    
        
        :param newEmail: The new email address.
        
        :type newEmail: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, an email change token.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GenerateChangeEmailTokenAsync(TUser user, string newEmail)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateChangePhoneNumberTokenAsync(TUser, System.String)
    
        
    
        
        Generates a telephone number change token for the specified user.
    
        
    
        
        :param user: The user to generate a telephone number token for.
        
        :type user: TUser
    
        
        :param phoneNumber: The new phone number the validation token should be sent to.
        
        :type phoneNumber: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the telephone change number token.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GenerateChangePhoneNumberTokenAsync(TUser user, string phoneNumber)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateConcurrencyStampAsync(TUser)
    
        
    
        
        Generates a value suitable for use in concurrency tracking.
    
        
    
        
        :param user: The user to generate the stamp for.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the security
            stamp for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GenerateConcurrencyStampAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateEmailConfirmationTokenAsync(TUser)
    
        
    
        
        Generates an email confirmation token for the specified user.
    
        
    
        
        :param user: The user to generate an email confirmation token for.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, an email confirmation token.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GenerateEmailConfirmationTokenAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GeneratePasswordResetTokenAsync(TUser)
    
        
    
        
        Generates a password reset token for the specified <em>user</em>, using
        the configured password reset token provider.
    
        
    
        
        :param user: The user to generate a password reset token for.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation,
            containing a password reset token for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GeneratePasswordResetTokenAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateTwoFactorTokenAsync(TUser, System.String)
    
        
    
        
        Gets a two factor authentication token for the specified <em>user</em>.
    
        
    
        
        :param user: The user the token is for.
        
        :type user: TUser
    
        
        :param tokenProvider: The provider which will generate the token.
        
        :type tokenProvider: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents result of the asynchronous operation, a two factor authentication token
            for the user.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GenerateTwoFactorTokenAsync(TUser user, string tokenProvider)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateUserTokenAsync(TUser, System.String, System.String)
    
        
    
        
        Generates a token for the given <em>user</em> and <em>purpose</em>.
    
        
    
        
        :param user: The user the token will be for.
        
        :type user: TUser
    
        
        :param tokenProvider: The provider which will generate the token.
        
        :type tokenProvider: System.String
    
        
        :param purpose: The purpose the token will be for.
        
        :type purpose: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents result of the asynchronous operation, a token for
            the given user and purpose.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GenerateUserTokenAsync(TUser user, string tokenProvider, string purpose)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetAccessFailedCountAsync(TUser)
    
        
    
        
        Retrieves the current number of failed accesses for the given <em>user</em>.
    
        
    
        
        :param user: The user whose access failed count should be retrieved for.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
        :return: The :any:`System.Threading.Tasks.Task` that contains the result the asynchronous operation, the current failed access count
            for the user.
    
        
        .. code-block:: csharp
    
            public virtual Task<int> GetAccessFailedCountAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetAuthenticationTokenAsync(TUser, System.String, System.String)
    
        
    
        
        Returns an authentication token for a user.
    
        
    
        
        :type user: TUser
    
        
        :param loginProvider: The authentication scheme for the provider the token is associated with.
        
        :type loginProvider: System.String
    
        
        :param tokenName: The name of the token.
        
        :type tokenName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetChangeEmailTokenPurpose(System.String)
    
        
    
        
        Generates the token purpose used to change email
    
        
    
        
        :type newEmail: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected static string GetChangeEmailTokenPurpose(string newEmail)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetClaimsAsync(TUser)
    
        
    
        
        Gets a list of :any:`System.Security.Claims.Claim`\s to be belonging to the specified <em>user</em> as an asynchronous operation.
    
        
    
        
        :param user: The user whose claims to retrieve.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that represents the result of the asynchronous query, a list of :any:`System.Security.Claims.Claim`\s.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<Claim>> GetClaimsAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetEmailAsync(TUser)
    
        
    
        
        Gets the email address for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose email should be returned.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The task object containing the results of the asynchronous operation, the email address for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetEmailAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetLockoutEnabledAsync(TUser)
    
        
    
        
        Retrieves a flag indicating whether user lockout can enabled for the specified user.
    
        
    
        
        :param user: The user whose ability to be locked out should be returned.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, true if a user can be locked out, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> GetLockoutEnabledAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetLockoutEndDateAsync(TUser)
    
        
    
        
        Gets the last :any:`System.DateTimeOffset` a user's last lockout expired, if any.
        Any time in the past should be indicates a user is not locked out.
    
        
    
        
        :param user: The user whose lockout date should be retrieved.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that represents the lookup, a :any:`System.DateTimeOffset` containing the last time a user's lockout expired, if any.
    
        
        .. code-block:: csharp
    
            public virtual Task<DateTimeOffset? > GetLockoutEndDateAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetLoginsAsync(TUser)
    
        
    
        
        Retrieves the associated logins for the specified <param ref="user" />.
    
        
    
        
        :param user: The user whose associated logins to retrieve.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Identity.UserLoginInfo<Microsoft.AspNetCore.Identity.UserLoginInfo>}}
        :return: 
            The :any:`System.Threading.Tasks.Task` for the asynchronous operation, containing a list of :any:`Microsoft.AspNetCore.Identity.UserLoginInfo` for the specified <em>user</em>, if any.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetPhoneNumberAsync(TUser)
    
        
    
        
        Gets the telephone number, if any, for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose telephone number should be retrieved.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user's telephone number, if any.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetPhoneNumberAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetRolesAsync(TUser)
    
        
    
        
        Gets a list of role names the specified <em>user</em> belongs to.
    
        
    
        
        :param user: The user whose role names to retrieve.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing a list of role names.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<string>> GetRolesAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetSecurityStampAsync(TUser)
    
        
    
        
        Get the security stamp for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose security stamp should be set.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the security stamp for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetSecurityStampAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetTwoFactorEnabledAsync(TUser)
    
        
    
        
        Returns a flag indicating whether the specified <em>user</em> has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose two factor authentication enabled status should be retrieved.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, true if the specified <em>user </em>
            has two factor authentication enabled, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> GetTwoFactorEnabledAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetUserAsync(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> GetUserAsync(ClaimsPrincipal principal)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetUserId(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        Returns the User ID claim value if present otherwise returns null.
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` instance.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.String
        :return: The User ID claim value, or null if the claim is not present.
    
        
        .. code-block:: csharp
    
            public virtual string GetUserId(ClaimsPrincipal principal)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetUserIdAsync(TUser)
    
        
    
        
        Gets the user identifier for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose identifier should be retrieved.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the identifier for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetUserIdAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetUserName(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        Returns the Name claim value if present otherwise returns null.
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` instance.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.String
        :return: The Name claim value, or null if the claim is not present.
    
        
        .. code-block:: csharp
    
            public virtual string GetUserName(ClaimsPrincipal principal)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetUserNameAsync(TUser)
    
        
    
        
        Gets the user name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be retrieved.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the name for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetUserNameAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetUsersForClaimAsync(System.Security.Claims.Claim)
    
        
    
        
        Returns a list of users from the user store who have the specified <em>claim</em>.
    
        
    
        
        :param claim: The claim to look for.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TUser}}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that represents the result of the asynchronous query, a list of <em>TUser</em>s who
            have the specified claim.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<TUser>> GetUsersForClaimAsync(Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetUsersInRoleAsync(System.String)
    
        
    
        
        Returns a list of users from the user store who are members of the specified <em>roleName</em>.
    
        
    
        
        :param roleName: The name of the role whose users should be returned.
        
        :type roleName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TUser}}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that represents the result of the asynchronous query, a list of <em>TUser</em>s who
            are members of the specified role.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<TUser>> GetUsersInRoleAsync(string roleName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.GetValidTwoFactorProvidersAsync(TUser)
    
        
    
        
        Gets a list of valid two factor token providers for the specified <em>user</em>,
        as an asynchronous operation.
    
        
    
        
        :param user: The user the whose two factor authentication providers will be returned.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents result of the asynchronous operation, a list of two
            factor authentication providers for the specified user.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<string>> GetValidTwoFactorProvidersAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.HasPasswordAsync(TUser)
    
        
    
        
        Gets a flag indicating whether the specified <em>user</em> has a password.
    
        
    
        
        :param user: The user to return a flag for, indicating whether they have a password or not.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, returning true if the specified <em>user</em> has a password
            otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> HasPasswordAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.IsEmailConfirmedAsync(TUser)
    
        
    
        
        Gets a flag indicating whether the email address for the specified <em>user</em> has been verified, true if the email address is verified otherwise
        false.
    
        
    
        
        :param user: The user whose email confirmation status should be returned.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The task object containing the results of the asynchronous operation, a flag indicating whether the email address for the specified <em>user</em>
            has been confirmed or not.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> IsEmailConfirmedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.IsInRoleAsync(TUser, System.String)
    
        
    
        
        Returns a flag indicating whether the specified <em>user</em> is a member of the give named role.
    
        
    
        
        :param user: The user whose role membership should be checked.
        
        :type user: TUser
    
        
        :param role: The name of the role to be checked.
        
        :type role: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing a flag indicating whether the specified <em>user</em> is
            a member of the named role.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> IsInRoleAsync(TUser user, string role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.IsLockedOutAsync(TUser)
    
        
    
        
        Returns a flag indicating whether the specified <em>user</em> his locked out,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose locked out status should be retrieved.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, true if the specified <em>user </em>
            is locked out, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> IsLockedOutAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.IsPhoneNumberConfirmedAsync(TUser)
    
        
    
        
        Gets a flag indicating whether the specified <em>user</em>'s telephone number has been confirmed.
    
        
    
        
        :param user: The user to return a flag for, indicating whether their telephone number is confirmed.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, returning true if the specified <em>user</em> has a confirmed
            telephone number otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> IsPhoneNumberConfirmedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.NormalizeKey(System.String)
    
        
    
        
        Normalize a key (user name, email) for consistent comparisons.
    
        
    
        
        :param key: The key to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized value representing the specified <em>key</em>.
    
        
        .. code-block:: csharp
    
            public virtual string NormalizeKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RegisterTokenProvider(System.String, Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider<TUser>)
    
        
    
        
        Registers a token provider.
    
        
    
        
        :param providerName: The name of the provider to register.
        
        :type providerName: System.String
    
        
        :param provider: The provider to register.
        
        :type provider: Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider<Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider`1>{TUser}
    
        
        .. code-block:: csharp
    
            public virtual void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<TUser> provider)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RemoveAuthenticationTokenAsync(TUser, System.String, System.String)
    
        
    
        
        Remove an authentication token for a user.
    
        
    
        
        :type user: TUser
    
        
        :param loginProvider: The authentication scheme for the provider the token is associated with.
        
        :type loginProvider: System.String
    
        
        :param tokenName: The name of the token.
        
        :type tokenName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: Whether a token was removed.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemoveAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RemoveClaimAsync(TUser, System.Security.Claims.Claim)
    
        
    
        
        Removes the specified <em>claim</em> from the given <em>user</em>.
    
        
    
        
        :param user: The user to remove the specified <em>claim</em> from.
        
        :type user: TUser
    
        
        :param claim: The :any:`System.Security.Claims.Claim` to remove.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemoveClaimAsync(TUser user, Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RemoveClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>)
    
        
    
        
        Removes the specified <em>claims</em> from the given <em>user</em>.
    
        
    
        
        :param user: The user to remove the specified <em>claims</em> from.
        
        :type user: TUser
    
        
        :param claims: A collection of :any:`System.Security.Claims.Claim`\s to remove.
        
        :type claims: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RemoveFromRoleAsync(TUser, System.String)
    
        
    
        
        Removes the specified <em>user</em> from the named role.
    
        
    
        
        :param user: The user to remove from the named role.
        
        :type user: TUser
    
        
        :param role: The name of the role to remove the user from.
        
        :type role: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RemoveFromRolesAsync(TUser, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Removes the specified <em>user</em> from the named roles.
    
        
    
        
        :param user: The user to remove from the named roles.
        
        :type user: TUser
    
        
        :param roles: The name of the roles to remove the user from.
        
        :type roles: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemoveFromRolesAsync(TUser user, IEnumerable<string> roles)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RemoveLoginAsync(TUser, System.String, System.String)
    
        
    
        
        Attempts to remove the provided external login information from the specified <em>user</em>.
        and returns a flag indicating whether the removal succeed or not.
    
        
    
        
        :param user: The user to remove the login information from.
        
        :type user: TUser
    
        
        :param loginProvider: The login provide whose information should be removed.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The key given by the external login provider for the specified user.
        
        :type providerKey: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemoveLoginAsync(TUser user, string loginProvider, string providerKey)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.RemovePasswordAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Removes a user's password.
    
        
    
        
        :param user: The user whose password should be removed.
        
        :type user: TUser
    
        
        :param cancellationToken: The :dn:prop:`Microsoft.AspNetCore.Identity.UserManager\`1.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemovePasswordAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ReplaceClaimAsync(TUser, System.Security.Claims.Claim, System.Security.Claims.Claim)
    
        
    
        
        Replaces the given <em>claim</em> on the specified <em>user</em> with the <em>newClaim</em>
    
        
    
        
        :param user: The user to replace the claim on.
        
        :type user: TUser
    
        
        :param claim: The claim to replace.
        
        :type claim: System.Security.Claims.Claim
    
        
        :param newClaim: The new claim to replace the existing <em>claim</em> with.
        
        :type newClaim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ResetAccessFailedCountAsync(TUser)
    
        
    
        
        Resets the access failed count for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose failed access count should be reset.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ResetAccessFailedCountAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ResetPasswordAsync(TUser, System.String, System.String)
    
        
    
        
        Resets the <em>user</em>'s password to the specified <em>newPassword</em> after
        validating the given password reset <em>token</em>.
    
        
    
        
        :param user: The user whose password should be reset.
        
        :type user: TUser
    
        
        :param token: The password reset token to verify.
        
        :type token: System.String
    
        
        :param newPassword: The new password to set if reset token verification fails.
        
        :type newPassword: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SetAuthenticationTokenAsync(TUser, System.String, System.String, System.String)
    
        
    
        
        Sets an authentication token for a user.
    
        
    
        
        :type user: TUser
    
        
        :param loginProvider: The authentication scheme for the provider the token is associated with.
        
        :type loginProvider: System.String
    
        
        :param tokenName: The name of the token.
        
        :type tokenName: System.String
    
        
        :param tokenValue: The value of the token.
        
        :type tokenValue: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName, string tokenValue)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SetEmailAsync(TUser, System.String)
    
        
    
        
        Sets the <em>email</em> address for a <em>user</em>.
    
        
    
        
        :param user: The user whose email should be set.
        
        :type user: TUser
    
        
        :param email: The email to set.
        
        :type email: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetEmailAsync(TUser user, string email)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SetLockoutEnabledAsync(TUser, System.Boolean)
    
        
    
        
        Sets a flag indicating whether the specified <em>user</em> is locked out,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose locked out status should be set.
        
        :type user: TUser
    
        
        :param enabled: Flag indicating whether the user is locked out or not.
        
        :type enabled: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the operation
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetLockoutEnabledAsync(TUser user, bool enabled)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SetLockoutEndDateAsync(TUser, System.Nullable<System.DateTimeOffset>)
    
        
    
        
        Locks out a user until the specified end date has passed. Setting a end date in the past immediately unlocks a user.
    
        
    
        
        :param user: The user whose lockout date should be set.
        
        :type user: TUser
    
        
        :param lockoutEnd: The :any:`System.DateTimeOffset` after which the <em>user</em>'s lockout should end.
        
        :type lockoutEnd: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SetPhoneNumberAsync(TUser, System.String)
    
        
    
        
        Sets the phone number for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose phone number to set.
        
        :type user: TUser
    
        
        :param phoneNumber: The phone number to set.
        
        :type phoneNumber: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetPhoneNumberAsync(TUser user, string phoneNumber)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SetTwoFactorEnabledAsync(TUser, System.Boolean)
    
        
    
        
        Sets a flag indicating whether the specified <em>user</em> has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: TUser
    
        
        :param enabled: A flag indicating whether the specified <em>user</em> has two factor authentication enabled.
        
        :type enabled: System.Boolean
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the operation
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetTwoFactorEnabledAsync(TUser user, bool enabled)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SetUserNameAsync(TUser, System.String)
    
        
    
        
        Sets the given <em>userName</em> for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be set.
        
        :type user: TUser
    
        
        :param userName: The user name to set.
        
        :type userName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetUserNameAsync(TUser user, string userName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ThrowIfDisposed()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowIfDisposed()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.UpdateAsync(TUser)
    
        
    
        
        Updates the specified <em>user</em> in the backing store.
    
        
    
        
        :param user: The user to update.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> UpdateAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.UpdateNormalizedEmailAsync(TUser)
    
        
    
        
        Updates the normalized email for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose email address should be normalized and updated.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task UpdateNormalizedEmailAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.UpdateNormalizedUserNameAsync(TUser)
    
        
    
        
        Updates the normalized user name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose user name should be normalized and updated.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task UpdateNormalizedUserNameAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.UpdateSecurityStampAsync(TUser)
    
        
    
        
        Regenerates the security stamp for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose security stamp should be regenerated.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> UpdateSecurityStampAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.VerifyChangePhoneNumberTokenAsync(TUser, System.String, System.String)
    
        
    
        
        Returns a flag indicating whether the specified <em>user</em>'s phone number change verification
        token is valid for the given <em>phoneNumber</em>.
    
        
    
        
        :param user: The user to validate the token against.
        
        :type user: TUser
    
        
        :param token: The telephone number change token to validate.
        
        :type token: System.String
    
        
        :param phoneNumber: The telephone number the token was generated for.
        
        :type phoneNumber: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, returning true if the <em>token</em>
            is valid, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> VerifyChangePhoneNumberTokenAsync(TUser user, string token, string phoneNumber)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.VerifyPasswordAsync(Microsoft.AspNetCore.Identity.IUserPasswordStore<TUser>, TUser, System.String)
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Identity.PasswordVerificationResult` indicating the result of a password hash comparison.
    
        
    
        
        :param store: The store containing a user's password.
        
        :type store: Microsoft.AspNetCore.Identity.IUserPasswordStore<Microsoft.AspNetCore.Identity.IUserPasswordStore`1>{TUser}
    
        
        :param user: The user whose password should be verified.
        
        :type user: TUser
    
        
        :param password: The password to verify.
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.PasswordVerificationResult<Microsoft.AspNetCore.Identity.PasswordVerificationResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.PasswordVerificationResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            protected virtual Task<PasswordVerificationResult> VerifyPasswordAsync(IUserPasswordStore<TUser> store, TUser user, string password)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.VerifyTwoFactorTokenAsync(TUser, System.String, System.String)
    
        
    
        
        Verifies the specified two factor authentication <em>token</em> against the <em>user</em>.
    
        
    
        
        :param user: The user the token is supposed to be for.
        
        :type user: TUser
    
        
        :param tokenProvider: The provider which will verify the token.
        
        :type tokenProvider: System.String
    
        
        :param token: The token to verify.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents result of the asynchronous operation, true if the token is valid,
            otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> VerifyTwoFactorTokenAsync(TUser user, string tokenProvider, string token)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserManager<TUser>.VerifyUserTokenAsync(TUser, System.String, System.String, System.String)
    
        
    
        
        Returns a flag indicating whether the specified <em>token</em> is valid for
        the given <em>user</em> and <em>purpose</em>.
    
        
    
        
        :param user: The user to validate the token against.
        
        :type user: TUser
    
        
        :param tokenProvider: The token provider used to generate the token.
        
        :type tokenProvider: System.String
    
        
        :param purpose: The purpose the token should be generated for.
        
        :type purpose: System.String
    
        
        :param token: The token to validate
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, returning true if the <em>token</em>
            is valid, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> VerifyUserTokenAsync(TUser user, string tokenProvider, string purpose, string token)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ConfirmEmailTokenPurpose
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected const string ConfirmEmailTokenPurpose = "EmailConfirmation"
    
    .. dn:field:: Microsoft.AspNetCore.Identity.UserManager<TUser>.ResetPasswordTokenPurpose
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected const string ResetPasswordTokenPurpose = "ResetPassword"
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.Logger
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
        :return: 
            The :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        .. code-block:: csharp
    
            protected virtual ILogger Logger { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.Store
    
        
    
        
        Gets or sets the persistence store the manager operates over.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IUserStore<Microsoft.AspNetCore.Identity.IUserStore`1>{TUser}
        :return: The persistence store the manager operates over.
    
        
        .. code-block:: csharp
    
            protected IUserStore<TUser> Store { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsQueryableUsers
    
        
    
        
        Gets a flag indicating whether the backing user store supports returning 
        :any:`System.Linq.IQueryable` collections of information.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports returning :any:`System.Linq.IQueryable` collections of
            information, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsQueryableUsers { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserAuthenticationTokens
    
        
    
        
        Gets a flag indicating whether the backing user store supports authentication tokens.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports  authentication tokens, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserAuthenticationTokens { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserClaim
    
        
    
        
        Gets a flag indicating whether the backing user store supports user claims.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user claims, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserClaim { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserEmail
    
        
    
        
        Gets a flag indicating whether the backing user store supports user emails.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user emails, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserEmail { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserLockout
    
        
    
        
        Gets a flag indicating whether the backing user store supports user lock-outs.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user lock-outs, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserLockout { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserLogin
    
        
    
        
        Gets a flag indicating whether the backing user store supports external logins.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports external logins, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserLogin { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserPassword
    
        
    
        
        Gets a flag indicating whether the backing user store supports user passwords.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user passwords, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserPassword { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserPhoneNumber
    
        
    
        
        Gets a flag indicating whether the backing user store supports user telephone numbers.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user telephone numbers, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserPhoneNumber { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserRole
    
        
    
        
        Gets a flag indicating whether the backing user store supports user roles.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user roles, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserRole { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserSecurityStamp
    
        
    
        
        Gets a flag indicating whether the backing user store supports security stamps.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user security stamps, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserSecurityStamp { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.SupportsUserTwoFactor
    
        
    
        
        Gets a flag indicating whether the backing user store supports two factor authentication.
    
        
        :rtype: System.Boolean
        :return: 
            true if the backing user store supports user two factor authentication, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsUserTwoFactor { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserManager<TUser>.Users
    
        
    
        
            Returns an IQueryable of users if the store is an IQueryableUserStore
    
        
        :rtype: System.Linq.IQueryable<System.Linq.IQueryable`1>{TUser}
    
        
        .. code-block:: csharp
    
            public virtual IQueryable<TUser> Users { get; }
    

