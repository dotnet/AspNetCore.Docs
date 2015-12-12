

AuthorizeAttribute Class
========================



.. contents:: 
   :local:



Summary
-------

Specifies that the class or method that this attribute is applied to requires the specified authorization.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizeAttribute`








Syntax
------

.. code-block:: csharp

   public class AuthorizeAttribute : Attribute, _Attribute, IAuthorizeData





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/AuthorizeAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizeAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizeAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.AuthorizeAttribute.AuthorizeAttribute()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Authorization.AuthorizeAttribute` class.
    
        
    
        
        .. code-block:: csharp
    
           public AuthorizeAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Authorization.AuthorizeAttribute.AuthorizeAttribute(System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Authorization.AuthorizeAttribute` class with the specified policy.
    
        
        
        
        :param policy: The name of the policy to require for authorization.
        
        :type policy: System.String
    
        
        .. code-block:: csharp
    
           public AuthorizeAttribute(string policy)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizeAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizeAttribute.ActiveAuthenticationSchemes
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ActiveAuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizeAttribute.Policy
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Policy { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizeAttribute.Roles
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Roles { get; set; }
    

