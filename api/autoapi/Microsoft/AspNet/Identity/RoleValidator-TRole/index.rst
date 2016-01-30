

RoleValidator<TRole> Class
==========================



.. contents:: 
   :local:



Summary
-------

Provides the default validation of roles.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.RoleValidator\<TRole>`








Syntax
------

.. code-block:: csharp

   public class RoleValidator<TRole> : IRoleValidator<TRole> where TRole : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/RoleValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.RoleValidator<TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.RoleValidator<TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.RoleValidator<TRole>.RoleValidator(Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Identity.RoleValidator\`1`\/
    
        
        
        
        :param errors: The  used to provider error messages.
        
        :type errors: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public RoleValidator(IdentityErrorDescriber errors = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.RoleValidator<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.RoleValidator<TRole>.ValidateAsync(Microsoft.AspNet.Identity.RoleManager<TRole>, TRole)
    
        
    
        Validates a role as an asynchronous operation.
    
        
        
        
        :param manager: The  managing the role store.
        
        :type manager: Microsoft.AspNet.Identity.RoleManager{{TRole}}
        
        
        :param role: The role to validate.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the asynchronous validation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> ValidateAsync(RoleManager<TRole> manager, TRole role)
    

