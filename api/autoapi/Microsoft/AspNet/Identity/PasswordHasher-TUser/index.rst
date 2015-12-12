

PasswordHasher<TUser> Class
===========================



.. contents:: 
   :local:



Summary
-------

Implements the standard Identity password hashing.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.PasswordHasher\<TUser>`








Syntax
------

.. code-block:: csharp

   public class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/PasswordHasher.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.PasswordHasher<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.PasswordHasher<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.PasswordHasher<TUser>.PasswordHasher(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Identity.PasswordHasherOptions>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Identity.PasswordHasher\`1`\.
    
        
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Identity.PasswordHasherOptions}
    
        
        .. code-block:: csharp
    
           public PasswordHasher(IOptions<PasswordHasherOptions> optionsAccessor = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.PasswordHasher<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.PasswordHasher<TUser>.HashPassword(TUser, System.String)
    
        
    
        Returns a hashed representation of the supplied ``password`` for the specified ``user``.
    
        
        
        
        :param user: The user whose password is to be hashed.
        
        :type user: {TUser}
        
        
        :param password: The password to hash.
        
        :type password: System.String
        :rtype: System.String
        :return: A hashed representation of the supplied <paramref name="password" /> for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           public virtual string HashPassword(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNet.Identity.PasswordHasher<TUser>.VerifyHashedPassword(TUser, System.String, System.String)
    
        
    
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
    
           public virtual PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
    

