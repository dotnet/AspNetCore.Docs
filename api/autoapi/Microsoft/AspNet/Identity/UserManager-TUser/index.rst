

UserManager<TUser> Class
========================



.. contents:: 
   :local:



Summary
-------

Provides the APIs for managing user in a persistence store.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.UserManager\<TUser>`








Syntax
------

.. code-block:: csharp

   public class UserManager<TUser> : IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/UserManager.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.UserManager<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.UserManager<TUser>.UserManager(Microsoft.AspNet.Identity.IUserStore<TUser>, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Identity.IdentityOptions>, Microsoft.AspNet.Identity.IPasswordHasher<TUser>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Identity.IUserValidator<TUser>>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Identity.IPasswordValidator<TUser>>, Microsoft.AspNet.Identity.ILookupNormalizer, Microsoft.AspNet.Identity.IdentityErrorDescriber, System.IServiceProvider, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNet.Identity.UserManager<TUser>>, Microsoft.AspNet.Http.IHttpContextAccessor)
    
        
    
        Constructs a new instance of :any:`Microsoft.AspNet.Identity.UserManager\`1`\.
    
        
        
        
        :param store: The persistence store the manager will operate over.
        
        :type store: Microsoft.AspNet.Identity.IUserStore{{TUser}}
        
        
        :param optionsAccessor: The accessor used to access the .
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Identity.IdentityOptions}
        
        
        :param passwordHasher: The password hashing implementation to use when saving passwords.
        
        :type passwordHasher: Microsoft.AspNet.Identity.IPasswordHasher{{TUser}}
        
        
        :param userValidators: A collection of  to validate users against.
        
        :type userValidators: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Identity.IUserValidator{{TUser}}}
        
        
        :param passwordValidators: A collection of  to validate passwords against.
        
        :type passwordValidators: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Identity.IPasswordValidator{{TUser}}}
        
        
        :param keyNormalizer: The  to use when generating index keys for users.
        
        :type keyNormalizer: Microsoft.AspNet.Identity.ILookupNormalizer
        
        
        :param errors: The  used to provider error messages.
        
        :type errors: Microsoft.AspNet.Identity.IdentityErrorDescriber
        
        
        :type services: System.IServiceProvider
        
        
        :param logger: The logger used to log messages, warnings and errors.
        
        :type logger: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Identity.UserManager`1}
        
        
        :param contextAccessor: The accessor used to access the .
        
        :type contextAccessor: Microsoft.AspNet.Http.IHttpContextAccessor
    
        
        .. code-block:: csharp
    
           public UserManager(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger, IHttpContextAccessor contextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.AccessFailedAsync(TUser)
    
        
    
        Increments the access failed count for the user as an asynchronous operation.
        If the failed access account is greater than or equal to the configured maximum number of attempts,
        the user will be locked out for the configured lockout time span.
    
        
        
        
        :param user: The user whose failed access count to increment.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AccessFailedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.AddClaimAsync(TUser, System.Security.Claims.Claim)
    
        
    
        Adds the specified ``claim`` to the ``user``.
    
        
        
        
        :param user: The user to add the claim to.
        
        :type user: {TUser}
        
        
        :param claim: The claim to add.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AddClaimAsync(TUser user, Claim claim)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.AddClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>)
    
        
    
        Adds the specified ``claims`` to the ``user``.
    
        
        
        
        :param user: The user to add the claim to.
        
        :type user: {TUser}
        
        
        :param claims: The claims to add.
        
        :type claims: System.Collections.Generic.IEnumerable{System.Security.Claims.Claim}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AddClaimsAsync(TUser user, IEnumerable<Claim> claims)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.AddLoginAsync(TUser, Microsoft.AspNet.Identity.UserLoginInfo)
    
        
    
        Adds an external :any:`Microsoft.AspNet.Identity.UserLoginInfo` to the specified ``user``.
    
        
        
        
        :param user: The user to add the login to.
        
        :type user: {TUser}
        
        
        :param login: The external  to add to the specified .
        
        :type login: Microsoft.AspNet.Identity.UserLoginInfo
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.AddPasswordAsync(TUser, System.String)
    
        
    
        Adds the ``password`` to the specified ``user`` only if the user
        does not already have a password.
    
        
        
        
        :param user: The user whose password should be set.
        
        :type user: {TUser}
        
        
        :param password: The password to set.
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AddPasswordAsync(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.AddToRoleAsync(TUser, System.String)
    
        
    
        Add the specified ``user`` to the named role.
    
        
        
        
        :param user: The user to add to the named role.
        
        :type user: {TUser}
        
        
        :type role: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AddToRoleAsync(TUser user, string role)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.AddToRolesAsync(TUser, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Add the specified ``user`` to the named roles.
    
        
        
        
        :param user: The user to add to the named roles.
        
        :type user: {TUser}
        
        
        :type roles: System.Collections.Generic.IEnumerable{System.String}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AddToRolesAsync(TUser user, IEnumerable<string> roles)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.ChangeEmailAsync(TUser, System.String, System.String)
    
        
    
        Updates a users emails if the specified email change ``token`` is valid for the user.
    
        
        
        
        :param user: The user whose email should be updated.
        
        :type user: {TUser}
        
        
        :param newEmail: The new email address.
        
        :type newEmail: System.String
        
        
        :param token: The change email token to be verified.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ChangeEmailAsync(TUser user, string newEmail, string token)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.ChangePasswordAsync(TUser, System.String, System.String)
    
        
    
        Changes a user's password after confirming the specified ``currentPassword`` is correct,
        as an asynchronous operation.
    
        
        
        
        :param user: The user whose password should be set.
        
        :type user: {TUser}
        
        
        :param currentPassword: The current password to validate before changing.
        
        :type currentPassword: System.String
        
        
        :param newPassword: The new password to set for the specified .
        
        :type newPassword: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.ChangePhoneNumberAsync(TUser, System.String, System.String)
    
        
    
        Sets the phone number for the specified ``user`` if the specified
        change ``token`` is valid.
    
        
        
        
        :param user: The user whose phone number to set.
        
        :type user: {TUser}
        
        
        :param phoneNumber: The phone number to set.
        
        :type phoneNumber: System.String
        
        
        :param token: The phone number confirmation token to validate.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ChangePhoneNumberAsync(TUser user, string phoneNumber, string token)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.CheckPasswordAsync(TUser, System.String)
    
        
    
        Returns a flag indicating whether the given ``password`` is valid for the
        specified ``user``.
    
        
        
        
        :param user: The user whose password should be validated.
        
        :type user: {TUser}
        
        
        :param password: The password to validate
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing true if
            the specified <paramref name="password" /> matches the one store for the <paramref name="user" />,
            otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> CheckPasswordAsync(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.ConfirmEmailAsync(TUser, System.String)
    
        
    
        Validates that an email confirmation token matches the specified ``user``.
    
        
        
        
        :param user: The user to validate the token against.
        
        :type user: {TUser}
        
        
        :param token: The email confirmation token to validate.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.CreateAsync(TUser)
    
        
    
        Creates the specified ``user`` in the backing store with no password,
        as an asynchronous operation.
    
        
        
        
        :param user: The user to create.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> CreateAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.CreateAsync(TUser, System.String)
    
        
    
        Creates the specified ``user`` in the backing store with given password,
        as an asynchronous operation.
    
        
        
        
        :param user: The user to create.
        
        :type user: {TUser}
        
        
        :param password: The password for the user to hash and store.
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> CreateAsync(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.DeleteAsync(TUser)
    
        
    
        Deletes the specified ``user`` from the backing store.
    
        
        
        
        :param user: The user to delete.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> DeleteAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.Dispose()
    
        
    
        Releases all resources used by the user manager.
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.Dispose(System.Boolean)
    
        
    
        Releases the unmanaged resources used by the role manager and optionally releases the managed resources.
    
        
        
        
        :param disposing: true to release both managed and unmanaged resources; false to release only unmanaged resources.
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.FindByEmailAsync(System.String)
    
        
    
        Gets the user, if any, associated with the specified, normalized email address.
    
        
        
        
        :type email: System.String
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The task object containing the results of the asynchronous lookup operation, the user if any associated with the specified normalized email address.
    
        
        .. code-block:: csharp
    
           public virtual Task<TUser> FindByEmailAsync(string email)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.FindByIdAsync(System.String)
    
        
    
        Finds and returns a user, if any, who has the specified ``userId``.
    
        
        
        
        :param userId: The user ID to search for.
        
        :type userId: System.String
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="userID" /> if it exists.
    
        
        .. code-block:: csharp
    
           public virtual Task<TUser> FindByIdAsync(string userId)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.FindByLoginAsync(System.String, System.String)
    
        
    
        Retrieves the user associated with the specified external login provider and login provider key..
    
        
        
        
        :param loginProvider: The login provider who provided the .
        
        :type loginProvider: System.String
        
        
        :param providerKey: The key provided by the  to identify a user.
        
        :type providerKey: System.String
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> for the asynchronous operation, containing the user, if any which matched the specified login provider and key.
    
        
        .. code-block:: csharp
    
           public virtual Task<TUser> FindByLoginAsync(string loginProvider, string providerKey)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.FindByNameAsync(System.String)
    
        
    
        Finds and returns a user, if any, who has the specified normalized user name.
    
        
        
        
        :type userName: System.String
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="userID" /> if it exists.
    
        
        .. code-block:: csharp
    
           public virtual Task<TUser> FindByNameAsync(string userName)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GenerateChangeEmailTokenAsync(TUser, System.String)
    
        
    
        Generates an email change token for the specified user.
    
        
        
        
        :param user: The user to generate an email change token for.
        
        :type user: {TUser}
        
        
        :type newEmail: System.String
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, an email change token.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GenerateChangeEmailTokenAsync(TUser user, string newEmail)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GenerateChangePhoneNumberTokenAsync(TUser, System.String)
    
        
    
        Generates a telephone number change token for the specified user.
    
        
        
        
        :param user: The user to generate a telephone number token for.
        
        :type user: {TUser}
        
        
        :param phoneNumber: The new phone number the validation token should be sent to.
        
        :type phoneNumber: System.String
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the telephone change number token.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GenerateChangePhoneNumberTokenAsync(TUser user, string phoneNumber)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GenerateConcurrencyStampAsync(TUser)
    
        
    
        Generates a value suitable for use in concurrency tracking.
    
        
        
        
        :param user: The user to generate the stamp for.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the security
            stamp for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GenerateConcurrencyStampAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GenerateEmailConfirmationTokenAsync(TUser)
    
        
    
        Generates an email confirmation token for the specified user.
    
        
        
        
        :param user: The user to generate an email confirmation token for.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, an email confirmation token.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GenerateEmailConfirmationTokenAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GeneratePasswordResetTokenAsync(TUser)
    
        
    
        Generates a password reset token for the specified ``user``, using
        the configured password reset token provider.
    
        
        
        
        :param user: The user to generate a password reset token for.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation,
            containing a password reset token for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GeneratePasswordResetTokenAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GenerateTwoFactorTokenAsync(TUser, System.String)
    
        
    
        Gets a two factor authentication token for the specified ``user``.
    
        
        
        
        :param user: The user the token is for.
        
        :type user: {TUser}
        
        
        :param tokenProvider: The provider which will generate the token.
        
        :type tokenProvider: System.String
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents result of the asynchronous operation, a two factor authentication token
            for the user.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GenerateTwoFactorTokenAsync(TUser user, string tokenProvider)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GenerateUserTokenAsync(TUser, System.String, System.String)
    
        
    
        Generates a token for the given ``user`` and ``purpose``.
    
        
        
        
        :param user: The user the token will be for.
        
        :type user: {TUser}
        
        
        :param tokenProvider: The provider which will generate the token.
        
        :type tokenProvider: System.String
        
        
        :param purpose: The purpose the token will be for.
        
        :type purpose: System.String
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents result of the asynchronous operation, a token for
            the given user and purpose.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GenerateUserTokenAsync(TUser user, string tokenProvider, string purpose)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetAccessFailedCountAsync(TUser)
    
        
    
        Retrieves the current number of failed accesses for the given ``user``.
    
        
        
        
        :param user: The user whose access failed count should be retrieved for.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Int32}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that contains the result the asynchronous operation, the current failed access count
            for the user..
    
        
        .. code-block:: csharp
    
           public virtual Task<int> GetAccessFailedCountAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetChangeEmailTokenPurpose(System.String)
    
        
    
        Generates the token purpose used to change email
    
        
        
        
        :type newEmail: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected static string GetChangeEmailTokenPurpose(string newEmail)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetClaimsAsync(TUser)
    
        
    
        Gets a list of :any:`System.Security.Claims.Claim`\s to be belonging to the specified ``user`` as an asynchronous operation.
    
        
        
        
        :param user: The role whose claims to retrieve.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.Security.Claims.Claim}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <see cref="T:System.Security.Claims.Claim" />s.
    
        
        .. code-block:: csharp
    
           public virtual Task<IList<Claim>> GetClaimsAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetEmailAsync(TUser)
    
        
    
        Gets the email address for the specified ``user``.
    
        
        
        
        :param user: The user whose email should be returned.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The task object containing the results of the asynchronous operation, the email address for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetEmailAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetLockoutEnabledAsync(TUser)
    
        
    
        Retrieves a flag indicating whether user lockout can enabled for the specified user.
    
        
        
        
        :param user: The user whose ability to be locked out should be returned.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, true if a user can be locked out, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> GetLockoutEnabledAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetLockoutEndDateAsync(TUser)
    
        
    
        Gets the last :any:`System.DateTimeOffset` a user's last lockout expired, if any.
        Any time in the past should be indicates a user is not locked out.
    
        
        
        
        :param user: The user whose lockout date should be retrieved.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Nullable{System.DateTimeOffset}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the lookup, a <see cref="T:System.DateTimeOffset" /> containing the last time a user's lockout expired, if any.
    
        
        .. code-block:: csharp
    
           public virtual Task<DateTimeOffset? > GetLockoutEndDateAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetLoginsAsync(TUser)
    
        
    
        Retrieves the associated logins for the specified <param ref="user" />.
    
        
        
        
        :param user: The user whose associated logins to retrieve.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{Microsoft.AspNet.Identity.UserLoginInfo}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> for the asynchronous operation, containing a list of <see cref="T:Microsoft.AspNet.Identity.UserLoginInfo" /> for the specified <paramref name="user" />, if any.
    
        
        .. code-block:: csharp
    
           public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetPhoneNumberAsync(TUser)
    
        
    
        Gets the telephone number, if any, for the specified ``user``.
    
        
        
        
        :param user: The user whose telephone number should be retrieved.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user's telephone number, if any.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetPhoneNumberAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetRolesAsync(TUser)
    
        
    
        Gets a list of role names the specified ``user`` belongs to.
    
        
        
        
        :param user: The user whose role names to retrieve.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.String}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a list of role names.
    
        
        .. code-block:: csharp
    
           public virtual Task<IList<string>> GetRolesAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetSecurityStampAsync(TUser)
    
        
    
        Get the security stamp for the specified ``user``.
    
        
        
        
        :param user: The user whose security stamp should be set.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the security stamp for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetSecurityStampAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetTwoFactorEnabledAsync(TUser)
    
        
    
        Returns a flag indicating whether the specified ``user`` has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
        
        
        :param user: The user whose two factor authentication enabled status should be retrieved.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, true if the specified <paramref name="user " />
            has two factor authentication enabled, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> GetTwoFactorEnabledAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetUserIdAsync(TUser)
    
        
    
        Gets the user identifier for the specified ``user``.
    
        
        
        
        :param user: The user whose identifier should be retrieved.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the identifier for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetUserIdAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetUserNameAsync(TUser)
    
        
    
        Gets the user name for the specified ``user``.
    
        
        
        
        :param user: The user whose name should be retrieved.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the name for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetUserNameAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetUsersForClaimAsync(System.Security.Claims.Claim)
    
        
        
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{{TUser}}}
    
        
        .. code-block:: csharp
    
           public virtual Task<IList<TUser>> GetUsersForClaimAsync(Claim claim)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetUsersInRoleAsync(System.String)
    
        
    
        Returns a list of users from the user store who have the specified :any:`System.Security.Claims.Claim`\.
    
        
        
        
        :type roleName: System.String
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{{TUser}}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <typeparamref name="TUser" />s who
            have the specified claim.
    
        
        .. code-block:: csharp
    
           public virtual Task<IList<TUser>> GetUsersInRoleAsync(string roleName)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.GetValidTwoFactorProvidersAsync(TUser)
    
        
    
        Gets a list of valid two factor token providers for the specified ``user``,
        as an asynchronous operation.
    
        
        
        
        :param user: The user the whose two factor authentication providers will be returned.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.String}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents result of the asynchronous operation, a list of two
            factor authentication providers for the specified user.
    
        
        .. code-block:: csharp
    
           public virtual Task<IList<string>> GetValidTwoFactorProvidersAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.HasPasswordAsync(TUser)
    
        
    
        Gets a flag indicating whether the specified ``user`` has a password.
    
        
        
        
        :param user: The user to return a flag for, indicating whether they have a password or not.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the specified <paramref name="user" /> has a password
            otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> HasPasswordAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.IsEmailConfirmedAsync(TUser)
    
        
    
        Gets a flag indicating whether the email address for the specified ``user`` has been verified, true if the email address is verified otherwise
        false.
    
        
        
        
        :param user: The user whose email confirmation status should be returned.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The task object containing the results of the asynchronous operation, a flag indicating whether the email address for the specified <paramref name="user" />
            has been confirmed or not.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> IsEmailConfirmedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.IsInRoleAsync(TUser, System.String)
    
        
    
        Returns a flag indicating whether the specified ``user`` is a member of the give named role.
    
        
        
        
        :param user: The user whose role membership should be checked.
        
        :type user: {TUser}
        
        
        :param role: The name of the role to be checked.
        
        :type role: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a flag indicating whether the specified <see cref="!:user" /> is
            a member of the named role.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> IsInRoleAsync(TUser user, string role)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.IsLockedOutAsync(TUser)
    
        
    
        Returns a flag indicating whether the specified ``user`` his locked out,
        as an asynchronous operation.
    
        
        
        
        :param user: The user whose locked out status should be retrieved.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, true if the specified <paramref name="user " />
            is locked out, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> IsLockedOutAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.IsPhoneNumberConfirmedAsync(TUser)
    
        
    
        Gets a flag indicating whether the specified ``user``'s telephone number has been confirmed.
    
        
        
        
        :param user: The user to return a flag for, indicating whether their telephone number is confirmed.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the specified <paramref name="user" /> has a confirmed
            telephone number otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> IsPhoneNumberConfirmedAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.NormalizeKey(System.String)
    
        
    
        Normalize a key (user name, email) for consistent comparisons.
    
        
        
        
        :param key: The key to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized value representing the specified <paramref name="key" />.
    
        
        .. code-block:: csharp
    
           public virtual string NormalizeKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.RegisterTokenProvider(System.String, Microsoft.AspNet.Identity.IUserTokenProvider<TUser>)
    
        
    
        Registers a token provider.
    
        
        
        
        :param providerName: The name of the provider to register.
        
        :type providerName: System.String
        
        
        :param provider: The provider to register.
        
        :type provider: Microsoft.AspNet.Identity.IUserTokenProvider{{TUser}}
    
        
        .. code-block:: csharp
    
           public virtual void RegisterTokenProvider(string providerName, IUserTokenProvider<TUser> provider)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.RemoveClaimAsync(TUser, System.Security.Claims.Claim)
    
        
    
        Removes the specified ``claim`` from the given ``user``.
    
        
        
        
        :param user: The user to remove the specified  from.
        
        :type user: {TUser}
        
        
        :param claim: The  to remove.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> RemoveClaimAsync(TUser user, Claim claim)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.RemoveClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>)
    
        
    
        Removes the specified ``claims`` from the given ``user``.
    
        
        
        
        :param user: The user to remove the specified  from.
        
        :type user: {TUser}
        
        
        :param claims: A collection of s to remove.
        
        :type claims: System.Collections.Generic.IEnumerable{System.Security.Claims.Claim}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.RemoveFromRoleAsync(TUser, System.String)
    
        
    
        Removes the specified ``user`` from the named role.
    
        
        
        
        :param user: The user to remove from the named role.
        
        :type user: {TUser}
        
        
        :type role: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.RemoveFromRolesAsync(TUser, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Removes the specified ``user`` from the named roles.
    
        
        
        
        :param user: The user to remove from the named roles.
        
        :type user: {TUser}
        
        
        :type roles: System.Collections.Generic.IEnumerable{System.String}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> RemoveFromRolesAsync(TUser user, IEnumerable<string> roles)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.RemoveLoginAsync(TUser, System.String, System.String)
    
        
    
        Attempts to remove the provided external login information from the specified ``user``.
        and returns a flag indicating whether the removal succeed or not.
    
        
        
        
        :param user: The user to remove the login information from.
        
        :type user: {TUser}
        
        
        :param loginProvider: The login provide whose information should be removed.
        
        :type loginProvider: System.String
        
        
        :param providerKey: The key given by the external login provider for the specified user.
        
        :type providerKey: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> RemoveLoginAsync(TUser user, string loginProvider, string providerKey)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.RemovePasswordAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Removes a user's password.
    
        
        
        
        :param user: The user whose password should be removed.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> RemovePasswordAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.ReplaceClaimAsync(TUser, System.Security.Claims.Claim, System.Security.Claims.Claim)
    
        
    
        Replaces the given ``claim`` on the specified ``user`` with the ``newClaim``
    
        
        
        
        :param user: The user to replace the claim on.
        
        :type user: {TUser}
        
        
        :param claim: The claim to replace.
        
        :type claim: System.Security.Claims.Claim
        
        
        :param newClaim: The new claim to replace the existing  with.
        
        :type newClaim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.ResetAccessFailedCountAsync(TUser)
    
        
    
        Resets the access failed count for the specified ``user``.
    
        
        
        
        :param user: The user whose failed access count should be reset.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ResetAccessFailedCountAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.ResetPasswordAsync(TUser, System.String, System.String)
    
        
    
        Resets the ``user``'s password to the specified ``newPassword`` after
        validating the given password reset ``token``.
    
        
        
        
        :param user: The user whose password should be reset.
        
        :type user: {TUser}
        
        
        :param token: The password reset token to verify.
        
        :type token: System.String
        
        
        :param newPassword: The new password to set if reset token verification fails.
        
        :type newPassword: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.SetEmailAsync(TUser, System.String)
    
        
    
        Sets the ``email`` address for a ``user``.
    
        
        
        
        :param user: The user whose email should be set.
        
        :type user: {TUser}
        
        
        :param email: The email to set.
        
        :type email: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> SetEmailAsync(TUser user, string email)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.SetLockoutEnabledAsync(TUser, System.Boolean)
    
        
    
        Sets a flag indicating whether the specified ``user`` is locked out,
        as an asynchronous operation.
    
        
        
        
        :param user: The user whose locked out status should be set.
        
        :type user: {TUser}
        
        
        :param enabled: Flag indicating whether the user is locked out or not.
        
        :type enabled: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the operation
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> SetLockoutEnabledAsync(TUser user, bool enabled)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.SetLockoutEndDateAsync(TUser, System.Nullable<System.DateTimeOffset>)
    
        
    
        Locks out a user until the specified end date has passed. Setting a end date in the past immediately unlocks a user.
    
        
        
        
        :param user: The user whose lockout date should be set.
        
        :type user: {TUser}
        
        
        :param lockoutEnd: The  after which the 's lockout should end.
        
        :type lockoutEnd: System.Nullable{System.DateTimeOffset}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.SetPhoneNumberAsync(TUser, System.String)
    
        
    
        Sets the phone number for the specified ``user``.
    
        
        
        
        :param user: The user whose phone number to set.
        
        :type user: {TUser}
        
        
        :param phoneNumber: The phone number to set.
        
        :type phoneNumber: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> SetPhoneNumberAsync(TUser user, string phoneNumber)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.SetTwoFactorEnabledAsync(TUser, System.Boolean)
    
        
    
        Sets a flag indicating whether the specified ``user`` has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
        
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: {TUser}
        
        
        :type enabled: System.Boolean
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the operation
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> SetTwoFactorEnabledAsync(TUser user, bool enabled)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.SetUserNameAsync(TUser, System.String)
    
        
    
        Sets the given ``userName`` for the specified ``user``.
    
        
        
        
        :param user: The user whose name should be set.
        
        :type user: {TUser}
        
        
        :param userName: The user name to set.
        
        :type userName: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> SetUserNameAsync(TUser user, string userName)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.UpdateAsync(TUser)
    
        
    
        Updates the specified ``user`` in the backing store.
    
        
        
        
        :param user: The user to update.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> UpdateAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.UpdateNormalizedEmailAsync(TUser)
    
        
    
        Updates the normalized email for the specified ``user``.
    
        
        
        
        :param user: The user whose email address should be normalized and updated.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task UpdateNormalizedEmailAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.UpdateNormalizedUserNameAsync(TUser)
    
        
    
        Updates the normalized user name for the specified ``user``.
    
        
        
        
        :param user: The user whose user name should be normalized and updated.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task UpdateNormalizedUserNameAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.UpdateSecurityStampAsync(TUser)
    
        
    
        Regenerates the security stamp for the specified ``user``.
    
        
        
        
        :param user: The user whose security stamp should be regenerated.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> UpdateSecurityStampAsync(TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.VerifyChangePhoneNumberTokenAsync(TUser, System.String, System.String)
    
        
    
        Returns a flag indicating whether the specified ``user``'s phone number change verification
        token is valid for the given ``phoneNumber``.
    
        
        
        
        :param user: The user to validate the token against.
        
        :type user: {TUser}
        
        
        :param token: The telephone number change token to validate.
        
        :type token: System.String
        
        
        :param phoneNumber: The telephone number the token was generated for.
        
        :type phoneNumber: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the <paramref name="token" />
            is valid, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> VerifyChangePhoneNumberTokenAsync(TUser user, string token, string phoneNumber)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.VerifyPasswordAsync(Microsoft.AspNet.Identity.IUserPasswordStore<TUser>, TUser, System.String)
    
        
    
        Returns a :any:`Microsoft.AspNet.Identity.PasswordVerificationResult` indicating the result of a password hash comparison.
    
        
        
        
        :param store: The store containing a user's password.
        
        :type store: Microsoft.AspNet.Identity.IUserPasswordStore{{TUser}}
        
        
        :param user: The user whose password should be verified.
        
        :type user: {TUser}
        
        
        :param password: The password to verify.
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.PasswordVerificationResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.PasswordVerificationResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           protected virtual Task<PasswordVerificationResult> VerifyPasswordAsync(IUserPasswordStore<TUser> store, TUser user, string password)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.VerifyTwoFactorTokenAsync(TUser, System.String, System.String)
    
        
    
        Verifies the specified two factor authentication ``token`` against the ``user``.
    
        
        
        
        :param user: The user the token is supposed to be for.
        
        :type user: {TUser}
        
        
        :param tokenProvider: The provider which will verify the token.
        
        :type tokenProvider: System.String
        
        
        :param token: The token to verify.
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents result of the asynchronous operation, true if the token is valid,
            otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> VerifyTwoFactorTokenAsync(TUser user, string tokenProvider, string token)
    
    .. dn:method:: Microsoft.AspNet.Identity.UserManager<TUser>.VerifyUserTokenAsync(TUser, System.String, System.String, System.String)
    
        
    
        Returns a flag indicating whether the specified ``token`` is valid for
        the given ``user`` and ``purpose``.
    
        
        
        
        :param user: The user to validate the token against.
        
        :type user: {TUser}
        
        
        :param tokenProvider: The token provider used to generate the token.
        
        :type tokenProvider: System.String
        
        
        :param purpose: The purpose the token should be generated for.
        
        :type purpose: System.String
        
        
        :param token: The token to validate
        
        :type token: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the <paramref name="token" />
            is valid, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> VerifyUserTokenAsync(TUser user, string tokenProvider, string purpose, string token)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Identity.UserManager<TUser>.ConfirmEmailTokenPurpose
    
        
    
        
        .. code-block:: csharp
    
           protected const string ConfirmEmailTokenPurpose
    
    .. dn:field:: Microsoft.AspNet.Identity.UserManager<TUser>.ResetPasswordTokenPurpose
    
        
    
        
        .. code-block:: csharp
    
           protected const string ResetPasswordTokenPurpose
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.UserManager<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.Logger
    
        
    
        Gets the :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected virtual ILogger Logger { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.Store
    
        
    
        Gets or sets the persistence store the manager operates over.
    
        
        :rtype: Microsoft.AspNet.Identity.IUserStore{{TUser}}
    
        
        .. code-block:: csharp
    
           protected IUserStore<TUser> Store { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsQueryableUsers
    
        
    
        Gets a flag indicating whether the backing user store supports returning 
        :any:`System.Linq.IQueryable` collections of information.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsQueryableUsers { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserClaim
    
        
    
        Gets a flag indicating whether the backing user store supports user claims.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserClaim { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserEmail
    
        
    
        Gets a flag indicating whether the backing user store supports user emails.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserEmail { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserLockout
    
        
    
        Gets a flag indicating whether the backing user store supports user lock-outs.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserLockout { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserLogin
    
        
    
        Gets a flag indicating whether the backing user store supports external logins.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserLogin { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserPassword
    
        
    
        Gets a flag indicating whether the backing user store supports user passwords.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserPassword { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserPhoneNumber
    
        
    
        Gets a flag indicating whether the backing user store supports user telephone numbers.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserPhoneNumber { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserRole
    
        
    
        Gets a flag indicating whether the backing user store supports user roles.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserRole { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserSecurityStamp
    
        
    
        Gets a flag indicating whether the backing user store supports security stamps.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserSecurityStamp { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.SupportsUserTwoFactor
    
        
    
        Gets a flag indicating whether the backing user store supports two factor authentication.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsUserTwoFactor { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserManager<TUser>.Users
    
        
    
        Returns an IQueryable of users if the store is an IQueryableUserStore
    
        
        :rtype: System.Linq.IQueryable{{TUser}}
    
        
        .. code-block:: csharp
    
           public virtual IQueryable<TUser> Users { get; }
    

