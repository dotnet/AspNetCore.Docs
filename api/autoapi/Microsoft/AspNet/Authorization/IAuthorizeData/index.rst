

IAuthorizeData Interface
========================



.. contents:: 
   :local:



Summary
-------

Defines the set of data required to apply authorization rules to a resource.











Syntax
------

.. code-block:: csharp

   public interface IAuthorizeData





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/IAuthorizeData.cs>`_





.. dn:interface:: Microsoft.AspNet.Authorization.IAuthorizeData

Properties
----------

.. dn:interface:: Microsoft.AspNet.Authorization.IAuthorizeData
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.IAuthorizeData.ActiveAuthenticationSchemes
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ActiveAuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.IAuthorizeData.Policy
    
        
    
        Gets or sets the policy name that determines access to the resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Policy { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.IAuthorizeData.Roles
    
        
    
        Gets or sets a comma-separated list of roles that are allowed to access the resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Roles { get; set; }
    

