

IdentityUser Class
==================






The default implementation of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser\`1` which uses a string as a primary key.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser{System.String,Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin{System.String}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser{System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser`








Syntax
------

.. code-block:: csharp

    public class IdentityUser : IdentityUser<string>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser.IdentityUser()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser`\.
    
        
    
        
        .. code-block:: csharp
    
            public IdentityUser()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser.IdentityUser(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser`\.
    
        
    
        
        :param userName: The user name.
        
        :type userName: System.String
    
        
        .. code-block:: csharp
    
            public IdentityUser(string userName)
    

