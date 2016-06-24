

IAuthorizeData Interface
========================






Defines the set of data required to apply authorization rules to a resource.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthorizeData








.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizeData
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizeData

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizeData
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.IAuthorizeData.ActiveAuthenticationSchemes
    
        
    
        
        Gets or sets a comma delimited list of schemes from which user information is constructed.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ActiveAuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.IAuthorizeData.Policy
    
        
    
        
        Gets or sets the policy name that determines access to the resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Policy { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.IAuthorizeData.Roles
    
        
    
        
        Gets or sets a comma delimited list of roles that are allowed to access the resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Roles { get; set; }
    

