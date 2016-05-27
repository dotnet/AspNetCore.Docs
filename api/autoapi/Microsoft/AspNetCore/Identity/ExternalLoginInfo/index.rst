

ExternalLoginInfo Class
=======================






Represents login information, source and externally source principal for a user record


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
* :dn:cls:`Microsoft.AspNetCore.Identity.ExternalLoginInfo`








Syntax
------

.. code-block:: csharp

    public class ExternalLoginInfo : UserLoginInfo








.. dn:class:: Microsoft.AspNetCore.Identity.ExternalLoginInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.ExternalLoginInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.ExternalLoginInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.ExternalLoginInfo.AuthenticationTokens
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authentication.AuthenticationToken<Microsoft.AspNetCore.Authentication.AuthenticationToken>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<AuthenticationToken> AuthenticationTokens
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.ExternalLoginInfo.Principal
    
        
    
        
        Gets or sets the :any:`System.Security.Claims.ClaimsPrincipal` associated with this login.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
        :return: The :any:`System.Security.Claims.ClaimsPrincipal` associated with this login.
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.ExternalLoginInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.ExternalLoginInfo.ExternalLoginInfo(System.Security.Claims.ClaimsPrincipal, System.String, System.String, System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.ExternalLoginInfo`
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` to associate with this login.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param loginProvider: The provider associated with this login information.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The unique identifier for this user provided by the login provider.
        
        :type providerKey: System.String
    
        
        :param displayName: The display name for this user provided by the login provider.
        
        :type displayName: System.String
    
        
        .. code-block:: csharp
    
            public ExternalLoginInfo(ClaimsPrincipal principal, string loginProvider, string providerKey, string displayName)
    

