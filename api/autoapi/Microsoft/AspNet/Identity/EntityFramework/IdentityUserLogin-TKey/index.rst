

IdentityUserLogin<TKey> Class
=============================



.. contents:: 
   :local:



Summary
-------

Represents a login and its associated provider for a user.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin\<TKey>`








Syntax
------

.. code-block:: csharp

   public class IdentityUserLogin<TKey> where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity.EntityFramework/IdentityUserLogin.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<TKey>.LoginProvider
    
        
    
        Gets or sets the login provider for the login (e.g. facebook, google)
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string LoginProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<TKey>.ProviderDisplayName
    
        
    
        Gets or sets the friendly name used in a UI for this login.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ProviderDisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<TKey>.ProviderKey
    
        
    
        Gets or sets the unique provider identifier for this login.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ProviderKey { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<TKey>.UserId
    
        
    
        Gets or sets the of the primary key of the user associated with this login.
    
        
        :rtype: {TKey}
    
        
        .. code-block:: csharp
    
           public virtual TKey UserId { get; set; }
    

