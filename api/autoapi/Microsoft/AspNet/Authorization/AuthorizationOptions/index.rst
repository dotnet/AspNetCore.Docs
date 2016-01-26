

AuthorizationOptions Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationOptions`








Syntax
------

.. code-block:: csharp

   public class AuthorizationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authorization/AuthorizationOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationOptions

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationOptions.AddPolicy(System.String, Microsoft.AspNet.Authorization.AuthorizationPolicy)
    
        
        
        
        :type name: System.String
        
        
        :type policy: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public void AddPolicy(string name, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationOptions.AddPolicy(System.String, System.Action<Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder>)
    
        
        
        
        :type name: System.String
        
        
        :type configurePolicy: System.Action{Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder}
    
        
        .. code-block:: csharp
    
           public void AddPolicy(string name, Action<AuthorizationPolicyBuilder> configurePolicy)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationOptions.GetPolicy(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicy GetPolicy(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationOptions.DefaultPolicy
    
        
    
        The initial default policy is to require any authenticated user
    
        
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicy DefaultPolicy { get; set; }
    

