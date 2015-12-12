

PasswordValidator<TUser> Class
==============================



.. contents:: 
   :local:



Summary
-------

Provides the default password policy for Identity.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.PasswordValidator\<TUser>`








Syntax
------

.. code-block:: csharp

   public class PasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/PasswordValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.PasswordValidator<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.PasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.PasswordValidator<TUser>.PasswordValidator(Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
    
        Constructions a new instance of :any:`Microsoft.AspNet.Identity.PasswordValidator\`1`\.
    
        
        
        
        :param errors: The  to retrieve error text from.
        
        :type errors: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public PasswordValidator(IdentityErrorDescriber errors = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.PasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.PasswordValidator<TUser>.IsDigit(System.Char)
    
        
    
        Returns a flag indicting whether the supplied character is a digit.
    
        
        
        
        :param c: The character to check if it is a digit.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is a digit, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual bool IsDigit(char c)
    
    .. dn:method:: Microsoft.AspNet.Identity.PasswordValidator<TUser>.IsLetterOrDigit(System.Char)
    
        
    
        Returns a flag indicting whether the supplied character is an ASCII letter or digit.
    
        
        
        
        :param c: The character to check if it is an ASCII letter or digit.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is an ASCII letter or digit, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual bool IsLetterOrDigit(char c)
    
    .. dn:method:: Microsoft.AspNet.Identity.PasswordValidator<TUser>.IsLower(System.Char)
    
        
    
        Returns a flag indicting whether the supplied character is a lower case ASCII letter.
    
        
        
        
        :param c: The character to check if it is a lower case ASCII letter.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is a lower case ASCII letter, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual bool IsLower(char c)
    
    .. dn:method:: Microsoft.AspNet.Identity.PasswordValidator<TUser>.IsUpper(System.Char)
    
        
    
        Returns a flag indicting whether the supplied character is an upper case ASCII letter.
    
        
        
        
        :param c: The character to check if it is an upper case ASCII letter.
        
        :type c: System.Char
        :rtype: System.Boolean
        :return: True if the character is an upper case ASCII letter, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual bool IsUpper(char c)
    
    .. dn:method:: Microsoft.AspNet.Identity.PasswordValidator<TUser>.ValidateAsync(Microsoft.AspNet.Identity.UserManager<TUser>, TUser, System.String)
    
        
    
        Validates a password as an asynchronous operation.
    
        
        
        
        :param manager: The  to retrieve the  properties from.
        
        :type manager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param user: The user whose password should be validated.
        
        :type user: {TUser}
        
        
        :param password: The password supplied for validation
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.PasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordValidator<TUser>.Describer
    
        
    
        Gets the :any:`Microsoft.AspNet.Identity.IdentityErrorDescriber` used to supply error text.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public IdentityErrorDescriber Describer { get; }
    

