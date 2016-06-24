

AuthorizeAttribute Class
========================






Specifies that the class or method that this attribute is applied to requires the specified authorization.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizeAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute, _Attribute, IAuthorizeData








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute.AuthorizeAttribute()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Authorization.AuthorizeAttribute` class. 
    
        
    
        
        .. code-block:: csharp
    
            public AuthorizeAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute.AuthorizeAttribute(System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Authorization.AuthorizeAttribute` class with the specified policy. 
    
        
    
        
        :param policy: The name of the policy to require for authorization.
        
        :type policy: System.String
    
        
        .. code-block:: csharp
    
            public AuthorizeAttribute(string policy)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute.ActiveAuthenticationSchemes
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ActiveAuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Policy { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Roles { get; set; }
    

