

IdentityUserToken<TKey> Class
=============================






Represents an authentication token for a user.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken\<TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityUserToken<TKey>
        where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<TKey>.LoginProvider
    
        
    
        
        Gets or sets the LoginProvider this token is from.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string LoginProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<TKey>.Name
    
        
    
        
        Gets or sets the name of the token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<TKey>.UserId
    
        
    
        
        Gets or sets the primary key of the user that the token belongs to.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey UserId
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<TKey>.Value
    
        
    
        
        Gets or sets the token value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Value
            {
                get;
                set;
            }
    

