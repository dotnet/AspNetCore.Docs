

IdentityUserLogin<TKey> Class
=============================






Represents a login and its associated provider for a user.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin\<TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityUserLogin<TKey>
        where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<TKey>.LoginProvider
    
        
    
        
        Gets or sets the login provider for the login (e.g. facebook, google)
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string LoginProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<TKey>.ProviderDisplayName
    
        
    
        
        Gets or sets the friendly name used in a UI for this login.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ProviderDisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<TKey>.ProviderKey
    
        
    
        
        Gets or sets the unique provider identifier for this login.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ProviderKey { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<TKey>.UserId
    
        
    
        
        Gets or sets the of the primary key of the user associated with this login.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey UserId { get; set; }
    

