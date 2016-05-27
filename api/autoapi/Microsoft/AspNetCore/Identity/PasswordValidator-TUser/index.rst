

PasswordValidator<TUser> Class
==============================






Provides the default password policy for Identity.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.PasswordValidator\<TUser>`








Syntax
------

.. code-block:: csharp

    public class PasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class








.. dn:class:: Microsoft.AspNetCore.Identity.PasswordValidator`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>.Describer
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to supply error text.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
        :return: The :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to supply error text.
    
        
        .. code-block:: csharp
    
            public IdentityErrorDescriber Describer
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>.PasswordValidator(Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        Constructions a new instance of :any:`Microsoft.AspNetCore.Identity.PasswordValidator\`1`\.
    
        
    
        
        :param errors: The :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` to retrieve error text from.
        
        :type errors: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public PasswordValidator(IdentityErrorDescriber errors = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>.IsDigit(System.Char)
    
        
    
        
        Returns a flag indicting whether the supplied character is a digit.
    
        
    
        
        :param c: The character to check if it is a digit.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is a digit, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool IsDigit(char c)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>.IsLetterOrDigit(System.Char)
    
        
    
        
        Returns a flag indicting whether the supplied character is an ASCII letter or digit.
    
        
    
        
        :param c: The character to check if it is an ASCII letter or digit.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is an ASCII letter or digit, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool IsLetterOrDigit(char c)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>.IsLower(System.Char)
    
        
    
        
        Returns a flag indicting whether the supplied character is a lower case ASCII letter.
    
        
    
        
        :param c: The character to check if it is a lower case ASCII letter.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is a lower case ASCII letter, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool IsLower(char c)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>.IsUpper(System.Char)
    
        
    
        
        Returns a flag indicting whether the supplied character is an upper case ASCII letter.
    
        
    
        
        :param c: The character to check if it is an upper case ASCII letter.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is an upper case ASCII letter, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool IsUpper(char c)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.PasswordValidator<TUser>.ValidateAsync(Microsoft.AspNetCore.Identity.UserManager<TUser>, TUser, System.String)
    
        
    
        
        Validates a password as an asynchronous operation.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.UserManager\`1` to retrieve the <em>user</em> properties from.
        
        :type manager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param user: The user whose password should be validated.
        
        :type user: TUser
    
        
        :param password: The password supplied for validation
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
    

