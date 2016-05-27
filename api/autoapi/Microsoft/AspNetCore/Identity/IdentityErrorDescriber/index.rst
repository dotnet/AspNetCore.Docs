

IdentityErrorDescriber Class
============================






Service to enable localization for application facing identity errors.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber`








Syntax
------

.. code-block:: csharp

    public class IdentityErrorDescriber








.. dn:class:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.ConcurrencyFailure()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a concurrency failure.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a concurrency failure.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError ConcurrencyFailure()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.DefaultError()
    
        
    
        
        Returns the default :any:`Microsoft.AspNetCore.Identity.IdentityError`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: The default :any:`Microsoft.AspNetCore.Identity.IdentityError`\,
    
        
        .. code-block:: csharp
    
            public virtual IdentityError DefaultError()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.DuplicateEmail(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>email</em> is already associated with an account.
    
        
    
        
        :param email: The email that is already associated with an account.
        
        :type email: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>email</em> is already associated with an account.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError DuplicateEmail(string email)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.DuplicateRoleName(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>role</em> name already exists.
    
        
    
        
        :param role: The duplicate role.
        
        :type role: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specific role <em>role</em> name already exists.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError DuplicateRoleName(string role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.DuplicateUserName(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>userName</em> already exists.
    
        
    
        
        :param userName: The user name that already exists.
        
        :type userName: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>userName</em> already exists.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError DuplicateUserName(string userName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.InvalidEmail(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>email</em> is invalid.
    
        
    
        
        :param email: The email that is invalid.
        
        :type email: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>email</em> is invalid.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError InvalidEmail(string email)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.InvalidRoleName(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified <em>role</em> name is invalid.
    
        
    
        
        :param role: The invalid role.
        
        :type role: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specific role <em>role</em> name is invalid.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError InvalidRoleName(string role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.InvalidToken()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating an invalid token.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating an invalid token.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError InvalidToken()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.InvalidUserName(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified user <em>userName</em> is invalid.
    
        
    
        
        :param userName: The user name that is invalid.
        
        :type userName: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating the specified user <em>userName</em> is invalid.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError InvalidUserName(string userName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.LoginAlreadyAssociated()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating an external login is already associated with an account.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating an external login is already associated with an account.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError LoginAlreadyAssociated()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.PasswordMismatch()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password mismatch.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password mismatch.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError PasswordMismatch()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.PasswordRequiresDigit()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain a numeric character, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain a numeric character.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError PasswordRequiresDigit()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.PasswordRequiresLower()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain a lower case letter, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain a lower case letter.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError PasswordRequiresLower()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.PasswordRequiresNonAlphanumeric()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain a non-alphanumeric character, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain a non-alphanumeric character.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError PasswordRequiresNonAlphanumeric()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.PasswordRequiresUpper()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain an upper case letter, which is required by the password policy.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password entered does not contain an upper case letter.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError PasswordRequiresUpper()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.PasswordTooShort(System.Int32)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password of the specified <em>length</em> does not meet the minimum length requirements.
    
        
    
        
        :param length: The length that is not long enough.
        
        :type length: System.Int32
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a password of the specified <em>length</em> does not meet the minimum length requirements.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError PasswordTooShort(int length)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.UserAlreadyHasPassword()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a user already has a password.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a user already has a password.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError UserAlreadyHasPassword()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.UserAlreadyInRole(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a user is already in the specified <em>role</em>.
    
        
    
        
        :param role: The duplicate role.
        
        :type role: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a user is already in the specified <em>role</em>.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError UserAlreadyInRole(string role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.UserLockoutNotEnabled()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating user lockout is not enabled.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating user lockout is not enabled..
    
        
        .. code-block:: csharp
    
            public virtual IdentityError UserLockoutNotEnabled()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityErrorDescriber.UserNotInRole(System.String)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a user is not in the specified <em>role</em>.
    
        
    
        
        :param role: The duplicate role.
        
        :type role: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityError
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityError` indicating a user is not in the specified <em>role</em>.
    
        
        .. code-block:: csharp
    
            public virtual IdentityError UserNotInRole(string role)
    

