

IdentityRole<TKey> Class
========================






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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole\<TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityRole<TKey>
        where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.Claims
    
        
    
        
        Navigation property for claims in this role.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<IdentityRoleClaim<TKey>> Claims
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.ConcurrencyStamp
    
        
    
        
        A random value that should change whenever a role is persisted to the store
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ConcurrencyStamp
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.Id
    
        
    
        
        Gets or sets the primary key for this role.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey Id
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.Name
    
        
    
        
        Gets or sets the name for this role.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.NormalizedName
    
        
    
        
        Gets or sets the normalized name for this role.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string NormalizedName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.Users
    
        
    
        
        Navigation property for the users in this role.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<IdentityUserRole<TKey>> Users
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.IdentityRole()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole\`1`\.
    
        
    
        
        .. code-block:: csharp
    
            public IdentityRole()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.IdentityRole(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole\`1`\.
    
        
    
        
        :param roleName: The role name.
        
        :type roleName: System.String
    
        
        .. code-block:: csharp
    
            public IdentityRole(string roleName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<TKey>.ToString()
    
        
    
        
        Returns the name of the role.
    
        
        :rtype: System.String
        :return: The name of the role.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

