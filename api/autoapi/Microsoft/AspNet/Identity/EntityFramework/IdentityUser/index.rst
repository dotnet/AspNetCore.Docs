

IdentityUser Class
==================



.. contents:: 
   :local:



Summary
-------

The default implementation of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser\`1` which uses a string as a primary key.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.String}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser`








Syntax
------

.. code-block:: csharp

   public class IdentityUser : IdentityUser<string>





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/IdentityUser.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser.IdentityUser()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser`\.
    
        
    
        
        .. code-block:: csharp
    
           public IdentityUser()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityUser.IdentityUser(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser`\.
    
        
        
        
        :param userName: The user name.
        
        :type userName: System.String
    
        
        .. code-block:: csharp
    
           public IdentityUser(string userName)
    

