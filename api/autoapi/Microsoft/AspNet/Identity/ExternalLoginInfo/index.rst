

ExternalLoginInfo Class
=======================



.. contents:: 
   :local:



Summary
-------

Represents login information, source and externally source principal for a user record





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.UserLoginInfo`
* :dn:cls:`Microsoft.AspNet.Identity.ExternalLoginInfo`








Syntax
------

.. code-block:: csharp

   public class ExternalLoginInfo : UserLoginInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/ExternalLoginInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.ExternalLoginInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.ExternalLoginInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.ExternalLoginInfo.ExternalLoginInfo(System.Security.Claims.ClaimsPrincipal, System.String, System.String, System.String)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Identity.ExternalLoginInfo`
    
        
        
        
        :param externalPrincipal: The  to associate with this login.
        
        :type externalPrincipal: System.Security.Claims.ClaimsPrincipal
        
        
        :param loginProvider: The provider associated with this login information.
        
        :type loginProvider: System.String
        
        
        :param providerKey: The unique identifier for this user provided by the login provider.
        
        :type providerKey: System.String
        
        
        :param displayName: The display name for this user provided by the login provider.
        
        :type displayName: System.String
    
        
        .. code-block:: csharp
    
           public ExternalLoginInfo(ClaimsPrincipal externalPrincipal, string loginProvider, string providerKey, string displayName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.ExternalLoginInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.ExternalLoginInfo.ExternalPrincipal
    
        
    
        Gets or sets the :any:`System.Security.Claims.ClaimsPrincipal` associated with this login.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal ExternalPrincipal { get; set; }
    

