

UserValidator<TUser> Class
==========================



.. contents:: 
   :local:



Summary
-------

Provides validation services for user classes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.UserValidator\<TUser>`








Syntax
------

.. code-block:: csharp

   public class UserValidator<TUser> : IUserValidator<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/UserValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.UserValidator<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.UserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.UserValidator<TUser>.UserValidator(Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Identity.UserValidator\`1`\/
    
        
        
        
        :param errors: The  used to provider error messages.
        
        :type errors: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public UserValidator(IdentityErrorDescriber errors = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.UserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.UserValidator<TUser>.ValidateAsync(Microsoft.AspNet.Identity.UserManager<TUser>, TUser)
    
        
    
        Validates the specified ``user`` as an asynchronous operation.
    
        
        
        
        :param manager: The  that can be used to retrieve user properties.
        
        :type manager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param user: The user to validate.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the validation operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.UserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.UserValidator<TUser>.Describer
    
        
    
        Gets the :any:`Microsoft.AspNet.Identity.IdentityErrorDescriber` used to provider error messages for the current :any:`Microsoft.AspNet.Identity.UserValidator\`1`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public IdentityErrorDescriber Describer { get; }
    

