

IdentityErrorDescriber Class
============================



.. contents:: 
   :local:



Summary
-------

Service to enable localization for application facing identity errors.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.IdentityErrorDescriber`








Syntax
------

.. code-block:: csharp

   public class IdentityErrorDescriber





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IdentityErrorDescriber.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.IdentityErrorDescriber

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.IdentityErrorDescriber
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.ConcurrencyFailure()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a concurrency failure.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a concurrency failure.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError ConcurrencyFailure()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.DefaultError()
    
        
    
        Returns the default :any:`Microsoft.AspNet.Identity.IdentityError`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: The default <see cref="T:Microsoft.AspNet.Identity.IdentityError" />,
    
        
        .. code-block:: csharp
    
           public virtual IdentityError DefaultError()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.DuplicateEmail(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating the specified ``email`` is already associated with an account.
    
        
        
        
        :param email: The email that is already associated with an account.
        
        :type email: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating the specified <paramref name="email" /> is already associated with an account.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError DuplicateEmail(string email)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.DuplicateRoleName(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating the specified ``role`` name already exists.
    
        
        
        
        :param role: The duplicate role.
        
        :type role: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating the specific role <paramref name="role" /> name already exists.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError DuplicateRoleName(string role)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.DuplicateUserName(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating the specified ``userName`` already exists.
    
        
        
        
        :param userName: The user name that already exists.
        
        :type userName: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating the specified <paramref name="userName" /> already exists.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError DuplicateUserName(string userName)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.InvalidEmail(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating the specified ``email`` is invalid.
    
        
        
        
        :param email: The email that is invalid.
        
        :type email: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating the specified <paramref name="email" /> is invalid.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError InvalidEmail(string email)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.InvalidRoleName(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating the specified ``role`` name is invalid.
    
        
        
        
        :param role: The invalid role.
        
        :type role: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating the specific role <paramref name="role" /> name is invalid.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError InvalidRoleName(string role)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.InvalidToken()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating an invalid token.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating an invalid token.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError InvalidToken()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.InvalidUserName(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating the specified user ``userName`` is invalid.
    
        
        
        
        :param userName: The user name that is invalid.
        
        :type userName: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating the specified user <paramref name="userName" /> is invalid.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError InvalidUserName(string userName)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.LoginAlreadyAssociated()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating an external login is already associated with an account.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating an external login is already associated with an account.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError LoginAlreadyAssociated()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.PasswordMismatch()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a password mismatch.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a password mismatch.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError PasswordMismatch()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.PasswordRequiresDigit()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a password entered does not contain a numeric character, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a password entered does not contain a numeric character.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError PasswordRequiresDigit()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.PasswordRequiresLower()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a password entered does not contain a lower case letter, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a password entered does not contain a lower case letter.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError PasswordRequiresLower()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.PasswordRequiresNonLetterAndDigit()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a password entered does not contain a non-alphanumeric character, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a password entered does not contain a non-alphanumeric character.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError PasswordRequiresNonLetterAndDigit()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.PasswordRequiresUpper()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a password entered does not contain an upper case letter, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a password entered does not contain an upper case letter.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError PasswordRequiresUpper()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.PasswordTooShort(System.Int32)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a password of the specified ``length`` does not meet the minimum length requirements.
    
        
        
        
        :param length: The length that is not long enough.
        
        :type length: System.Int32
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a password of the specified <paramref name="length" /> does not meet the minimum length requirements.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError PasswordTooShort(int length)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.UserAlreadyHasPassword()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a user already has a password.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a user already has a password.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError UserAlreadyHasPassword()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.UserAlreadyInRole(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a user is already in the specified ``role``.
    
        
        
        
        :param role: The duplicate role.
        
        :type role: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a user is already in the specified <paramref name="role" />.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError UserAlreadyInRole(string role)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.UserLockoutNotEnabled()
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating user lockout is not enabled.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating user lockout is not enabled..
    
        
        .. code-block:: csharp
    
           public virtual IdentityError UserLockoutNotEnabled()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityErrorDescriber.UserNotInRole(System.String)
    
        
    
        Returns an :any:`Microsoft.AspNet.Identity.IdentityError` indicating a user is not in the specified ``role``.
    
        
        
        
        :param role: The duplicate role.
        
        :type role: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityError
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityError" /> indicating a user is not in the specified <paramref name="role" />.
    
        
        .. code-block:: csharp
    
           public virtual IdentityError UserNotInRole(string role)
    

