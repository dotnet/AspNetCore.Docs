

IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin> Class
===========================================================






Represents a user in the identity system


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity.EntityFrameworkCore`
Assemblies
    * Microsoft.AspNetCore.Identity.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser\<TKey, TUserClaim, TUserRole, TUserLogin>`








Syntax
------

.. code-block:: csharp

    public class IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>
        where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser`4
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.IdentityUser()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser\`1`\.
    
        
    
        
        .. code-block:: csharp
    
            public IdentityUser()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.IdentityUser(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser\`1`\.
    
        
    
        
        :param userName: The user name.
        
        :type userName: System.String
    
        
        .. code-block:: csharp
    
            public IdentityUser(string userName)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.AccessFailedCount
    
        
    
        
        Gets or sets the number of failed login attempts for the current user.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int AccessFailedCount { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.Claims
    
        
    
        
        Navigation property for the claims this user possesses.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{TUserClaim}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<TUserClaim> Claims { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.ConcurrencyStamp
    
        
    
        
        A random value that must change whenever a user is persisted to the store
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ConcurrencyStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.Email
    
        
    
        
        Gets or sets the email address for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Email { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.EmailConfirmed
    
        
    
        
        Gets or sets a flag indicating if a user has confirmed their email address.
    
        
        :rtype: System.Boolean
        :return: True if the email address has been confirmed, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool EmailConfirmed { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.Id
    
        
    
        
        Gets or sets the primary key for this user.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey Id { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.LockoutEnabled
    
        
    
        
        Gets or sets a flag indicating if the user could be locked out.
    
        
        :rtype: System.Boolean
        :return: True if the user could be locked out, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool LockoutEnabled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.LockoutEnd
    
        
    
        
        Gets or sets the date and time, in UTC, when any user lockout ends.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public virtual DateTimeOffset? LockoutEnd { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.Logins
    
        
    
        
        Navigation property for this users login accounts.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{TUserLogin}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<TUserLogin> Logins { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.NormalizedEmail
    
        
    
        
        Gets or sets the normalized email address for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string NormalizedEmail { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.NormalizedUserName
    
        
    
        
        Gets or sets the normalized user name for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string NormalizedUserName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.PasswordHash
    
        
    
        
        Gets or sets a salted and hashed representation of the password for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string PasswordHash { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.PhoneNumber
    
        
    
        
        Gets or sets a telephone number for the user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string PhoneNumber { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.PhoneNumberConfirmed
    
        
    
        
        Gets or sets a flag indicating if a user has confirmed their telephone address.
    
        
        :rtype: System.Boolean
        :return: True if the telephone number has been confirmed, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool PhoneNumberConfirmed { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.Roles
    
        
    
        
        Navigation property for the roles this user belongs to.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{TUserRole}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<TUserRole> Roles { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.SecurityStamp
    
        
    
        
        A random value that must change whenever a users credentials change (password changed, login removed)
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string SecurityStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.TwoFactorEnabled
    
        
    
        
        Gets or sets a flag indicating if two factor authentication is enabled for this user.
    
        
        :rtype: System.Boolean
        :return: True if 2fa is enabled, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool TwoFactorEnabled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.UserName
    
        
    
        
        Gets or sets the user name for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string UserName { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>.ToString()
    
        
    
        
        Returns the username for this user.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

