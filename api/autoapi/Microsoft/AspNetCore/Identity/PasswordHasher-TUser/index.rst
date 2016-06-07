

PasswordHasher<TUser> Class
===========================






Implements the standard Identity password hashing.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.PasswordHasher\<TUser>`








Syntax
------

.. code-block:: csharp

    public class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class








.. dn:class:: Microsoft.AspNetCore.Identity.PasswordHasher`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordHasher<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordHasher<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.PasswordHasher<TUser>.PasswordHasher(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Identity.PasswordHasherOptions>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.PasswordHasher\`1`\.
    
        
    
        
        :param optionsAccessor: The options for this instance.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Identity.PasswordHasherOptions<Microsoft.AspNetCore.Identity.PasswordHasherOptions>}
    
        
        .. code-block:: csharp
    
            public PasswordHasher(IOptions<PasswordHasherOptions> optionsAccessor = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordHasher<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.PasswordHasher<TUser>.HashPassword(TUser, System.String)
    
        
    
        
        Returns a hashed representation of the supplied <em>password</em> for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose password is to be hashed.
        
        :type user: TUser
    
        
        :param password: The password to hash.
        
        :type password: System.String
        :rtype: System.String
        :return: A hashed representation of the supplied <em>password</em> for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            public virtual string HashPassword(TUser user, string password)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.PasswordHasher<TUser>.VerifyHashedPassword(TUser, System.String, System.String)
    
        
    
        
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
    
            public virtual PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
    

