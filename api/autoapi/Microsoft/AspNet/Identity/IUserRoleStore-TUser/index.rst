

IUserRoleStore<TUser> Interface
===============================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a store which maps users to roles.











Syntax
------

.. code-block:: csharp

   public interface IUserRoleStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IUserRoleStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserRoleStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserRoleStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserRoleStore<TUser>.AddToRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Add a the specified ``user`` to the named role.
    
        
        
        
        :param user: The user to add to the named role.
        
        :type user: {TUser}
        
        
        :param roleName: The name of the role to add the user to.
        
        :type roleName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task AddToRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserRoleStore<TUser>.GetRolesAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets a list of role names the specified ``user`` belongs to.
    
        
        
        
        :param user: The user whose role names to retrieve.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.String}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a list of role names.
    
        
        .. code-block:: csharp
    
           Task<IList<string>> GetRolesAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserRoleStore<TUser>.GetUsersInRoleAsync(System.String, System.Threading.CancellationToken)
    
        
    
        Returns a list of Users who are members of the named role.
    
        
        
        
        :param roleName: The name of the role whose membership should be returned.
        
        :type roleName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{{TUser}}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a list of users who are in the named role.
    
        
        .. code-block:: csharp
    
           Task<IList<TUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserRoleStore<TUser>.IsInRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Returns a flag indicating whether the specified ``user`` is a member of the give named role.
    
        
        
        
        :param user: The user whose role membership should be checked.
        
        :type user: {TUser}
        
        
        :param roleName: The name of the role to be checked.
        
        :type roleName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a flag indicating whether the specified <see cref="!:user" /> is
            a member of the named role.
    
        
        .. code-block:: csharp
    
           Task<bool> IsInRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserRoleStore<TUser>.RemoveFromRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Add a the specified ``user`` from the named role.
    
        
        
        
        :param user: The user to remove the named role from.
        
        :type user: {TUser}
        
        
        :param roleName: The name of the role to remove.
        
        :type roleName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task RemoveFromRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
    

