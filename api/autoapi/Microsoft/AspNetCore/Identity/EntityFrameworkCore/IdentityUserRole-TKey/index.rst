

IdentityUserRole<TKey> Class
============================






Represents the link between a user and a role.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole\<TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityUserRole<TKey>
        where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<TKey>.RoleId
    
        
    
        
        Gets or sets the primary key of the role that is linked to the user.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey RoleId
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<TKey>.UserId
    
        
    
        
        Gets or sets the primary key of the user that is linked to a role.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey UserId
            {
                get;
                set;
            }
    

