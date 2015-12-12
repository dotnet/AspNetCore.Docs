

AuthorizationPolicy Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationPolicy`








Syntax
------

.. code-block:: csharp

   public class AuthorizationPolicy





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/AuthorizationPolicy.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicy

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.AuthorizationPolicy.AuthorizationPolicy(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Authorization.IAuthorizationRequirement>, System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type requirements: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
        
        
        :type authenticationSchemes: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicy(IEnumerable<IAuthorizationRequirement> requirements, IEnumerable<string> authenticationSchemes)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicy.Combine(Microsoft.AspNet.Authorization.AuthorizationOptions, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Authorization.IAuthorizeData>)
    
        
        
        
        :type options: Microsoft.AspNet.Authorization.AuthorizationOptions
        
        
        :type attributes: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizeData}
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public static AuthorizationPolicy Combine(AuthorizationOptions options, IEnumerable<IAuthorizeData> attributes)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicy.Combine(Microsoft.AspNet.Authorization.AuthorizationPolicy[])
    
        
        
        
        :type policies: Microsoft.AspNet.Authorization.AuthorizationPolicy[]
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public static AuthorizationPolicy Combine(params AuthorizationPolicy[] policies)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicy.Combine(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Authorization.AuthorizationPolicy>)
    
        
        
        
        :type policies: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.AuthorizationPolicy}
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public static AuthorizationPolicy Combine(IEnumerable<AuthorizationPolicy> policies)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationPolicy.AuthenticationSchemes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.String}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<string> AuthenticationSchemes { get; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationPolicy.Requirements
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<IAuthorizationRequirement> Requirements { get; }
    

