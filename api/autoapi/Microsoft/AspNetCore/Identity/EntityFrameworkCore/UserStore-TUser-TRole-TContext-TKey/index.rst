

UserStore<TUser, TRole, TContext, TKey> Class
=============================================






Represents a new instance of a persistence store for the specified user and role types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity.EntityFrameworkCore`
Assemblies
    * Microsoft.AspNetCore.Identity.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore\<TUser, TRole, TContext, TKey>`








Syntax
------

.. code-block:: csharp

    public class UserStore<TUser, TRole, TContext, TKey> : IUserLoginStore<TUser>, IUserRoleStore<TUser>, IUserClaimStore<TUser>, IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser>, IUserEmailStore<TUser>, IUserLockoutStore<TUser>, IUserPhoneNumberStore<TUser>, IQueryableUserStore<TUser>, IUserTwoFactorStore<TUser>, IUserAuthenticationTokenStore<TUser>, IUserStore<TUser>, IDisposable where TUser : IdentityUser<TKey> where TRole : IdentityRole<TKey> where TContext : DbContext where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore`4
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.AutoSaveChanges
    
        
    
        
        Gets or sets a flag indicating if changes should be persisted after CreateAsync, UpdateAsync and DeleteAsync are called.
    
        
        :rtype: System.Boolean
        :return: 
            True if changes should be automatically persisted, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool AutoSaveChanges
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.Context
    
        
    
        
        Gets the database context for this store.
    
        
        :rtype: TContext
    
        
        .. code-block:: csharp
    
            public TContext Context
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.ErrorDescriber
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` for any error that occurred with the current operation.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public IdentityErrorDescriber ErrorDescriber
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.Users
    
        
    
        
        A navigation property for the users the store contains.
    
        
        :rtype: System.Linq.IQueryable<System.Linq.IQueryable`1>{TUser}
    
        
        .. code-block:: csharp
    
            public virtual IQueryable<TUser> Users
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.UserStore(TContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore`\.
    
        
    
        
        :param context: The context used to access the store.
        
        :type context: TContext
    
        
        :param describer: The :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to describe store errors.
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public UserStore(TContext context, IdentityErrorDescriber describer = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.AddClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>, System.Threading.CancellationToken)
    
        
    
        
        Adds the <em>claims</em> given to the specified <em>user</em>.
    
        
    
        
        :param user: The user to add the claim to.
        
        :type user: TUser
    
        
        :param claims: The claim to add to the user.
        
        :type claims: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task AddClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.AddLoginAsync(TUser, Microsoft.AspNetCore.Identity.UserLoginInfo, System.Threading.CancellationToken)
    
        
    
        
        Adds the <em>login</em> given to the specified <em>user</em>.
    
        
    
        
        :param user: The user to add the login to.
        
        :type user: TUser
    
        
        :param login: The login to add to the user.
        
        :type login: Microsoft.AspNetCore.Identity.UserLoginInfo
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task AddLoginAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.AddToRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Adds the given <em>normalizedRoleName</em> to the specified <em>user</em>.
    
        
    
        
        :param user: The user to add the role to.
        
        :type user: TUser
    
        
        :param normalizedRoleName: The role to add.
        
        :type normalizedRoleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task AddToRoleAsync(TUser user, string normalizedRoleName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.ConvertIdFromString(System.String)
    
        
    
        
        Converts the provided <em>id</em> to a strongly typed key object.
    
        
    
        
        :param id: The id to convert.
        
        :type id: System.String
        :rtype: TKey
        :return: An instance of <em>TKey</em> representing the provided <em>id</em>.
    
        
        .. code-block:: csharp
    
            public virtual TKey ConvertIdFromString(string id)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.ConvertIdToString(TKey)
    
        
    
        
        Converts the provided <em>id</em> to its string representation.
    
        
    
        
        :param id: The id to convert.
        
        :type id: TKey
        :rtype: System.String
        :return: An :any:`System.String` representation of the provided <em>id</em>.
    
        
        .. code-block:: csharp
    
            public virtual string ConvertIdToString(TKey id)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.CreateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Creates the specified <em>user</em> in the user store.
    
        
    
        
        :param user: The user to create.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the creation operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.DeleteAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Deletes the specified <em>user</em> from the user store.
    
        
    
        
        :param user: The user to delete.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the update operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.Dispose()
    
        
    
        
        Dispose the store
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.FindByEmailAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Gets the user, if any, associated with the specified, normalized email address.
    
        
    
        
        :param normalizedEmail: The normalized email address to return the user for.
        
        :type normalizedEmail: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The task object containing the results of the asynchronous lookup operation, the user if any associated with the specified normalized email address.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.FindByIdAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds and returns a user, if any, who has the specified <em>userId</em>.
    
        
    
        
        :param userId: The user ID to search for.
        
        :type userId: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user matching the specified <em>userId</em> if it exists.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.FindByLoginAsync(System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        Retrieves the user associated with the specified login provider and login provider key..
    
        
    
        
        :param loginProvider: The login provider who provided the <em>providerKey</em>.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The key provided by the <em>loginProvider</em> to identify a user.
        
        :type providerKey: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` for the asynchronous operation, containing the user, if any which matched the specified login provider and key.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.FindByNameAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds and returns a user, if any, who has the specified normalized user name.
    
        
    
        
        :param normalizedUserName: The normalized user name to search for.
        
        :type normalizedUserName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user matching the specified <em>normalizedUserName</em> if it exists.
    
        
        .. code-block:: csharp
    
            public virtual Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetAccessFailedCountAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Retrieves the current failed access count for the specified <em>user</em>..
    
        
    
        
        :param user: The user whose failed access count should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the failed access count.
    
        
        .. code-block:: csharp
    
            public virtual Task<int> GetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetClaimsAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Get the claims associated with the specified <em>user</em> as an asynchronous operation.
    
        
    
        
        :param user: The user whose claims should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the claims granted to a user.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<Claim>> GetClaimsAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetEmailAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the email address for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose email should be returned.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The task object containing the results of the asynchronous operation, the email address for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetEmailAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetEmailConfirmedAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets a flag indicating whether the email address for the specified <em>user</em> has been verified, true if the email address is verified otherwise
        false.
    
        
    
        
        :param user: The user whose email confirmation status should be returned.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The task object containing the results of the asynchronous operation, a flag indicating whether the email address for the specified <em>user</em>
            has been confirmed or not.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> GetEmailConfirmedAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetLockoutEnabledAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Retrieves a flag indicating whether user lockout can enabled for the specified user.
    
        
    
        
        :param user: The user whose ability to be locked out should be returned.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, true if a user can be locked out, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> GetLockoutEnabledAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetLockoutEndDateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the last :any:`System.DateTimeOffset` a user's last lockout expired, if any.
        Any time in the past should be indicates a user is not locked out.
    
        
    
        
        :param user: The user whose lockout date should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that represents the result of the asynchronous query, a :any:`System.DateTimeOffset` containing the last time
            a user's lockout expired, if any.
    
        
        .. code-block:: csharp
    
            public virtual Task<DateTimeOffset? > GetLockoutEndDateAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetLoginsAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Retrieves the associated logins for the specified <param ref="user" />.
    
        
    
        
        :param user: The user whose associated logins to retrieve.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Identity.UserLoginInfo<Microsoft.AspNetCore.Identity.UserLoginInfo>}}
        :return: 
            The :any:`System.Threading.Tasks.Task` for the asynchronous operation, containing a list of :any:`Microsoft.AspNetCore.Identity.UserLoginInfo` for the specified <em>user</em>, if any.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetNormalizedEmailAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Returns the normalized email for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose email address to retrieve.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The task object containing the results of the asynchronous lookup operation, the normalized email address if any associated with the specified user.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetNormalizedEmailAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetNormalizedUserNameAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the normalized user name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose normalized name should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the normalized user name for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetPasswordHashAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the password hash for a user.
    
        
    
        
        :param user: The user to retrieve the password hash for.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the password hash for the user.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetPhoneNumberAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the telephone number, if any, for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose telephone number should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user's telephone number, if any.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetPhoneNumberAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetPhoneNumberConfirmedAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets a flag indicating whether the specified <em>user</em>'s telephone number has been confirmed.
    
        
    
        
        :param user: The user to return a flag for, indicating whether their telephone number is confirmed.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, returning true if the specified <em>user</em> has a confirmed
            telephone number otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> GetPhoneNumberConfirmedAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetRolesAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Retrieves the roles the specified <em>user</em> is a member of.
    
        
    
        
        :param user: The user whose roles should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the roles the user is a member of.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<string>> GetRolesAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetSecurityStampAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Get the security stamp for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose security stamp should be set.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the security stamp for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetSecurityStampAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetTokenAsync(TUser, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        :type user: TUser
    
        
        :type loginProvider: System.String
    
        
        :type name: System.String
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Task<string> GetTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetTwoFactorEnabledAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Returns a flag indicating whether the specified <em>user</em> has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing a flag indicating whether the specified 
            <em>user</em> has two factor authentication enabled or not.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> GetTwoFactorEnabledAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetUserIdAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the user identifier for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose identifier should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the identifier for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetUserNameAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the user name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the name for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetUsersForClaimAsync(System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        
        Retrieves all users with the specified claim.
    
        
    
        
        :param claim: The claim whose users should be retrieved.
        
        :type claim: System.Security.Claims.Claim
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TUser}}
        :return: 
            The :any:`System.Threading.Tasks.Task` contains a list of users, if any, that contain the specified claim. 
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<TUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.GetUsersInRoleAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Retrieves all users in the specified role.
    
        
    
        
        :param normalizedRoleName: The role whose users should be retrieved.
        
        :type normalizedRoleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TUser}}
        :return: 
            The :any:`System.Threading.Tasks.Task` contains a list of users, if any, that are in the specified role. 
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<TUser>> GetUsersInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.HasPasswordAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Returns a flag indicating if the specified user has a password.
    
        
    
        
        :param user: The user to retrieve the password hash for.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task\`1` containing a flag indicating if the specified user has a password. If the 
            user has a password the returned value with be true, otherwise it will be false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.IncrementAccessFailedCountAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Records that a failed access has occurred, incrementing the failed access count.
    
        
    
        
        :param user: The user whose cancellation count should be incremented.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the incremented failed access count.
    
        
        .. code-block:: csharp
    
            public virtual Task<int> IncrementAccessFailedCountAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.IsInRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Returns a flag indicating if the specified user is a member of the give <em>normalizedRoleName</em>.
    
        
    
        
        :param user: The user whose role membership should be checked.
        
        :type user: TUser
    
        
        :param normalizedRoleName: The role to check membership of
        
        :type normalizedRoleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task\`1` containing a flag indicating if the specified user is a member of the given group. If the 
            user is a member of the group the returned value with be true, otherwise it will be false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> IsInRoleAsync(TUser user, string normalizedRoleName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.RemoveClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>, System.Threading.CancellationToken)
    
        
    
        
        Removes the <em>claims</em> given from the specified <em>user</em>.
    
        
    
        
        :param user: The user to remove the claims from.
        
        :type user: TUser
    
        
        :param claims: The claim to remove.
        
        :type claims: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.RemoveFromRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Removes the given <em>normalizedRoleName</em> from the specified <em>user</em>.
    
        
    
        
        :param user: The user to remove the role from.
        
        :type user: TUser
    
        
        :param normalizedRoleName: The role to remove.
        
        :type normalizedRoleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task RemoveFromRoleAsync(TUser user, string normalizedRoleName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.RemoveLoginAsync(TUser, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        Removes the <em>loginProvider</em> given from the specified <em>user</em>.
    
        
    
        
        :param user: The user to remove the login from.
        
        :type user: TUser
    
        
        :param loginProvider: The login to remove from the user.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The key provided by the <em>loginProvider</em> to identify a user.
        
        :type providerKey: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.RemoveTokenAsync(TUser, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        :type user: TUser
    
        
        :type loginProvider: System.String
    
        
        :type name: System.String
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RemoveTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.ReplaceClaimAsync(TUser, System.Security.Claims.Claim, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        
        Replaces the <em>claim</em> on the specified <em>user</em>, with the <em>newClaim</em>.
    
        
    
        
        :param user: The role to replace the claim on.
        
        :type user: TUser
    
        
        :param claim: The claim replace.
        
        :type claim: System.Security.Claims.Claim
    
        
        :param newClaim: The new claim replacing the <em>claim</em>.
        
        :type newClaim: System.Security.Claims.Claim
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.ResetAccessFailedCountAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Resets a user's failed access count.
    
        
    
        
        :param user: The user whose failed access count should be reset.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task ResetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetEmailAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the <em>email</em> address for a <em>user</em>.
    
        
    
        
        :param user: The user whose email should be set.
        
        :type user: TUser
    
        
        :param email: The email to set.
        
        :type email: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetEmailAsync(TUser user, string email, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetEmailConfirmedAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        Sets the flag indicating whether the specified <em>user</em>'s email address has been confirmed or not.
    
        
    
        
        :param user: The user whose email confirmation status should be set.
        
        :type user: TUser
    
        
        :param confirmed: A flag indicating if the email address has been confirmed, true if the address is confirmed otherwise false.
        
        :type confirmed: System.Boolean
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetEmailConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetLockoutEnabledAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        Set the flag indicating if the specified <em>user</em> can be locked out..
    
        
    
        
        :param user: The user whose ability to be locked out should be set.
        
        :type user: TUser
    
        
        :param enabled: A flag indicating if lock out can be enabled for the specified <em>user</em>.
        
        :type enabled: System.Boolean
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetLockoutEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetLockoutEndDateAsync(TUser, System.Nullable<System.DateTimeOffset>, System.Threading.CancellationToken)
    
        
    
        
        Locks out a user until the specified end date has passed. Setting a end date in the past immediately unlocks a user.
    
        
    
        
        :param user: The user whose lockout date should be set.
        
        :type user: TUser
    
        
        :param lockoutEnd: The :any:`System.DateTimeOffset` after which the <em>user</em>'s lockout should end.
        
        :type lockoutEnd: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetNormalizedEmailAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the normalized email for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose email address to set.
        
        :type user: TUser
    
        
        :param normalizedEmail: The normalized email to set for the specified <em>user</em>.
        
        :type normalizedEmail: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetNormalizedEmailAsync(TUser user, string normalizedEmail, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetNormalizedUserNameAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the given normalized name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be set.
        
        :type user: TUser
    
        
        :param normalizedName: The normalized name to set.
        
        :type normalizedName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetPasswordHashAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the password hash for a user.
    
        
    
        
        :param user: The user to set the password hash for.
        
        :type user: TUser
    
        
        :param passwordHash: The password hash to set.
        
        :type passwordHash: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetPhoneNumberAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the telephone number for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose telephone number should be set.
        
        :type user: TUser
    
        
        :param phoneNumber: The telephone number to set.
        
        :type phoneNumber: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetPhoneNumberAsync(TUser user, string phoneNumber, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetPhoneNumberConfirmedAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        Sets a flag indicating if the specified <em>user</em>'s phone number has been confirmed..
    
        
    
        
        :param user: The user whose telephone number confirmation status should be set.
        
        :type user: TUser
    
        
        :param confirmed: A flag indicating whether the user's telephone number has been confirmed.
        
        :type confirmed: System.Boolean
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetSecurityStampAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the provided security <em>stamp</em> for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose security stamp should be set.
        
        :type user: TUser
    
        
        :param stamp: The security stamp to set.
        
        :type stamp: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetSecurityStampAsync(TUser user, string stamp, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetTokenAsync(TUser, System.String, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        :type user: TUser
    
        
        :type loginProvider: System.String
    
        
        :type name: System.String
    
        
        :type value: System.String
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task SetTokenAsync(TUser user, string loginProvider, string name, string value, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetTwoFactorEnabledAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        Sets a flag indicating whether the specified <em>user</em> has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: TUser
    
        
        :param enabled: A flag indicating whether the specified <em>user</em> has two factor authentication enabled.
        
        :type enabled: System.Boolean
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetTwoFactorEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.SetUserNameAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the given <em>userName</em> for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be set.
        
        :type user: TUser
    
        
        :param userName: The user name to set.
        
        :type userName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.ThrowIfDisposed()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowIfDisposed()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.UpdateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Updates the specified <em>user</em> in the user store.
    
        
    
        
        :param user: The user to update.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the update operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken = null)
    

