

IdentityRole<TKey, TUserRole, TRoleClaim> Class
===============================================






Represents a role in the identity system


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole\<TKey, TUserRole, TRoleClaim>`








Syntax
------

.. code-block:: csharp

    public class IdentityRole<TKey, TUserRole, TRoleClaim>
        where TKey : IEquatable<TKey> where TUserRole : IdentityUserRole<TKey> where TRoleClaim : IdentityRoleClaim<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole`3
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.IdentityRole()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole\`1`\.
    
        
    
        
        .. code-block:: csharp
    
            public IdentityRole()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.IdentityRole(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole\`1`\.
    
        
    
        
        :param roleName: The role name.
        
        :type roleName: System.String
    
        
        .. code-block:: csharp
    
            public IdentityRole(string roleName)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.Claims
    
        
    
        
        Navigation property for claims in this role.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{TRoleClaim}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<TRoleClaim> Claims { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.ConcurrencyStamp
    
        
    
        
        A random value that should change whenever a role is persisted to the store
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ConcurrencyStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.Id
    
        
    
        
        Gets or sets the primary key for this role.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey Id { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.Name
    
        
    
        
        Gets or sets the name for this role.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.NormalizedName
    
        
    
        
        Gets or sets the normalized name for this role.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string NormalizedName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.Users
    
        
    
        
        Navigation property for the users in this role.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{TUserRole}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<TUserRole> Users { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey, TUserRole, TRoleClaim>.ToString()
    
        
    
        
        Returns the name of the role.
    
        
        :rtype: System.String
        :return: The name of the role.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

