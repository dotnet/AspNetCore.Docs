

UserLoginInfo Class
===================



.. contents:: 
   :local:



Summary
-------

Represents login information and source for a user record.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.UserLoginInfo`








Syntax
------

.. code-block:: csharp

   public class UserLoginInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/UserLoginInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.UserLoginInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.UserLoginInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.UserLoginInfo.UserLoginInfo(System.String, System.String, System.String)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Identity.UserLoginInfo`
    
        
        
        
        :param loginProvider: The provider associated with this login information.
        
        :type loginProvider: System.String
        
        
        :param providerKey: The unique identifier for this user provided by the login provider.
        
        :type providerKey: System.String
        
        
        :param displayName: The display name for this user provided by the login provider.
        
        :type displayName: System.String
    
        
        .. code-block:: csharp
    
           public UserLoginInfo(string loginProvider, string providerKey, string displayName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.UserLoginInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.UserLoginInfo.LoginProvider
    
        
    
        Gets or sets the provider for this instance of :any:`Microsoft.AspNet.Identity.UserLoginInfo`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string LoginProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserLoginInfo.ProviderDisplayName
    
        
    
        Gets or sets the display name for the provider.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ProviderDisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserLoginInfo.ProviderKey
    
        
    
        Gets or sets the unique identifier for the user identity user provided by the login provider.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ProviderKey { get; set; }
    

