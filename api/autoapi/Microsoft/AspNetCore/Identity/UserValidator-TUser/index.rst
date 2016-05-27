

UserValidator<TUser> Class
==========================






Provides validation services for user classes.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.UserValidator\<TUser>`








Syntax
------

.. code-block:: csharp

    public class UserValidator<TUser> : IUserValidator<TUser> where TUser : class








.. dn:class:: Microsoft.AspNetCore.Identity.UserValidator`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.UserValidator<TUser>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.UserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserValidator<TUser>.Describer
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to provider error messages for the current :any:`Microsoft.AspNetCore.Identity.UserValidator\`1`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
        :return: Yhe :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to provider error messages for the current :any:`Microsoft.AspNetCore.Identity.UserValidator\`1`\.
    
        
        .. code-block:: csharp
    
            public IdentityErrorDescriber Describer
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.UserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.UserValidator<TUser>.UserValidator(Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.UserValidator\`1`\/
    
        
    
        
        :param errors: The :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to provider error messages.
        
        :type errors: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public UserValidator(IdentityErrorDescriber errors = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.UserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserValidator<TUser>.ValidateAsync(Microsoft.AspNetCore.Identity.UserManager<TUser>, TUser)
    
        
    
        
        Validates the specified <em>user</em> as an asynchronous operation.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.UserManager\`1` that can be used to retrieve user properties.
        
        :type manager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param user: The user to validate.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the validation operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
    

