

IdentityUser<TKey> Class
========================



.. contents:: 
   :local:



Summary
-------

Represents a user in the identity system





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser\<TKey>`








Syntax
------

.. code-block:: csharp

   public class IdentityUser<TKey> where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/IdentityUser.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.IdentityUser()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser\`1`\.
    
        
    
        
        .. code-block:: csharp
    
           public IdentityUser()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.IdentityUser(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser\`1`\.
    
        
        
        
        :param userName: The user name.
        
        :type userName: System.String
    
        
        .. code-block:: csharp
    
           public IdentityUser(string userName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.ToString()
    
        
    
        Returns the username for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.AccessFailedCount
    
        
    
        Gets or sets the number of failed login attempts for the current user.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual int AccessFailedCount { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.Claims
    
        
    
        Navigation property for the claims this user possesses.
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim{{TKey}}}
    
        
        .. code-block:: csharp
    
           public virtual ICollection<IdentityUserClaim<TKey>> Claims { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.ConcurrencyStamp
    
        
    
        A random value that must change whenever a user is persisted to the store
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ConcurrencyStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.Email
    
        
    
        Gets or sets the email address for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Email { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.EmailConfirmed
    
        
    
        Gets or sets a flag indicating if a user has confirmed their email address.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool EmailConfirmed { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.Id
    
        
        :rtype: {TKey}
    
        
        .. code-block:: csharp
    
           public virtual TKey Id { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.LockoutEnabled
    
        
    
        Gets or sets a flag indicating if this user is locked out.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool LockoutEnabled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.LockoutEnd
    
        
    
        Gets or sets the date and time, in UTC, when any user lockout ends.
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public virtual DateTimeOffset? LockoutEnd { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.Logins
    
        
    
        Navigation property for this users login accounts.
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin{{TKey}}}
    
        
        .. code-block:: csharp
    
           public virtual ICollection<IdentityUserLogin<TKey>> Logins { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.NormalizedEmail
    
        
    
        Gets or sets the normalized email address for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string NormalizedEmail { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.NormalizedUserName
    
        
    
        Gets or sets the normalized user name for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string NormalizedUserName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.PasswordHash
    
        
    
        Gets or sets a salted and hashed representation of the password for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string PasswordHash { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.PhoneNumber
    
        
    
        Gets or sets a telephone number for the user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string PhoneNumber { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.PhoneNumberConfirmed
    
        
    
        Gets or sets a flag indicating if a user has confirmed their telephone address.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool PhoneNumberConfirmed { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.Roles
    
        
    
        Navigation property for the roles this user belongs to.
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole{{TKey}}}
    
        
        .. code-block:: csharp
    
           public virtual ICollection<IdentityUserRole<TKey>> Roles { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.SecurityStamp
    
        
    
        A random value that must change whenever a users credentials change (password changed, login removed)
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string SecurityStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.TwoFactorEnabled
    
        
    
        Gets or sets a flag indicating if two factor authentication is enabled for this user.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool TwoFactorEnabled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser<TKey>.UserName
    
        
    
        Gets or sets the user name for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string UserName { get; set; }
    

