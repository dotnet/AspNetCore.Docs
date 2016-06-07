

IPasswordHasher<TUser> Interface
================================






Provides an abstraction for hashing passwords.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IPasswordHasher<TUser>
        where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IPasswordHasher`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IPasswordHasher<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IPasswordHasher<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IPasswordHasher<TUser>.HashPassword(TUser, System.String)
    
        
    
        
        Returns a hashed representation of the supplied <em>password</em> for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose password is to be hashed.
        
        :type user: TUser
    
        
        :param password: The password to hash.
        
        :type password: System.String
        :rtype: System.String
        :return: A hashed representation of the supplied <em>password</em> for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            string HashPassword(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IPasswordHasher<TUser>.VerifyHashedPassword(TUser, System.String, System.String)
    
        
    
        
        Returns a :any:`Microsoft.AspNetCore.Identity.PasswordVerificationResult` indicating the result of a password hash comparison.
    
        
    
        
        :param user: The user whose password should be verified.
        
        :type user: TUser
    
        
        :param hashedPassword: The hash value for a user's stored password.
        
        :type hashedPassword: System.String
    
        
        :param providedPassword: The password supplied for comparison.
        
        :type providedPassword: System.String
        :rtype: Microsoft.AspNetCore.Identity.PasswordVerificationResult
        :return: A :any:`Microsoft.AspNetCore.Identity.PasswordVerificationResult` indicating the result of a password hash comparison.
    
        
        .. code-block:: csharp
    
            PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
    

