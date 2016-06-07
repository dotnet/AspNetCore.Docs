

IUserRoleStore<TUser> Interface
===============================






Provides an abstraction for a store which maps users to roles.


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

    public interface IUserRoleStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserRoleStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserRoleStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserRoleStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserRoleStore<TUser>.AddToRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Add a the specified <em>user</em> to the named role.
    
        
    
        
        :param user: The user to add to the named role.
        
        :type user: TUser
    
        
        :param roleName: The name of the role to add the user to.
        
        :type roleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task AddToRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserRoleStore<TUser>.GetRolesAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets a list of role names the specified <em>user</em> belongs to.
    
        
    
        
        :param user: The user whose role names to retrieve.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing a list of role names.
    
        
        .. code-block:: csharp
    
            Task<IList<string>> GetRolesAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserRoleStore<TUser>.GetUsersInRoleAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Returns a list of Users who are members of the named role.
    
        
    
        
        :param roleName: The name of the role whose membership should be returned.
        
        :type roleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TUser}}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing a list of users who are in the named role.
    
        
        .. code-block:: csharp
    
            Task<IList<TUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserRoleStore<TUser>.IsInRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Returns a flag indicating whether the specified <em>user</em> is a member of the give named role.
    
        
    
        
        :param user: The user whose role membership should be checked.
        
        :type user: TUser
    
        
        :param roleName: The name of the role to be checked.
        
        :type roleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing a flag indicating whether the specified <em>user</em> is
            a member of the named role.
    
        
        .. code-block:: csharp
    
            Task<bool> IsInRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserRoleStore<TUser>.RemoveFromRoleAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Add a the specified <em>user</em> from the named role.
    
        
    
        
        :param user: The user to remove the named role from.
        
        :type user: TUser
    
        
        :param roleName: The name of the role to remove.
        
        :type roleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task RemoveFromRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
    

