

UserLoginInfo Class
===================






Represents login information and source for a user record.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.UserLoginInfo`








Syntax
------

.. code-block:: csharp

    public class UserLoginInfo








.. dn:class:: Microsoft.AspNetCore.Identity.UserLoginInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.UserLoginInfo

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.UserLoginInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.UserLoginInfo.UserLoginInfo(System.String, System.String, System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.UserLoginInfo`
    
        
    
        
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

.. dn:class:: Microsoft.AspNetCore.Identity.UserLoginInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserLoginInfo.LoginProvider
    
        
    
        
        Gets or sets the provider for this instance of :any:`Microsoft.AspNetCore.Identity.UserLoginInfo`\.
    
        
        :rtype: System.String
        :return: The provider for the this instance of :any:`Microsoft.AspNetCore.Identity.UserLoginInfo`
    
        
        .. code-block:: csharp
    
            public string LoginProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserLoginInfo.ProviderDisplayName
    
        
    
        
        Gets or sets the display name for the provider.
    
        
        :rtype: System.String
        :return: 
            The display name for the provider.
    
        
        .. code-block:: csharp
    
            public string ProviderDisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserLoginInfo.ProviderKey
    
        
    
        
        Gets or sets the unique identifier for the user identity user provided by the login provider.
    
        
        :rtype: System.String
        :return: 
            The unique identifier for the user identity user provided by the login provider.
    
        
        .. code-block:: csharp
    
            public string ProviderKey { get; set; }
    

