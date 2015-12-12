

IPasswordHasher<TUser> Interface
================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for hashing passwords.











Syntax
------

.. code-block:: csharp

   public interface IPasswordHasher<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IPasswordHasher.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IPasswordHasher<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IPasswordHasher<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IPasswordHasher<TUser>.HashPassword(TUser, System.String)
    
        
    
        Returns a hashed representation of the supplied ``password`` for the specified ``user``.
    
        
        
        
        :param user: The user whose password is to be hashed.
        
        :type user: {TUser}
        
        
        :param password: The password to hash.
        
        :type password: System.String
        :rtype: System.String
        :return: A hashed representation of the supplied <paramref name="password" /> for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           string HashPassword(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNet.Identity.IPasswordHasher<TUser>.VerifyHashedPassword(TUser, System.String, System.String)
    
        
    
        Returns a :any:`Microsoft.AspNet.Identity.PasswordVerificationResult` indicating the result of a password hash comparison.
    
        
        
        
        :param user: The user whose password should be verified.
        
        :type user: {TUser}
        
        
        :param hashedPassword: The hash value for a user's stored password.
        
        :type hashedPassword: System.String
        
        
        :param providedPassword: The password supplied for comparison.
        
        :type providedPassword: System.String
        :rtype: Microsoft.AspNet.Identity.PasswordVerificationResult
        :return: A <see cref="T:Microsoft.AspNet.Identity.PasswordVerificationResult" /> indicating the result of a password hash comparison.
    
        
        .. code-block:: csharp
    
           PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
    

