

UserInformationReceivedContext Class
====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext`








Syntax
------

.. code-block:: csharp

    public class UserInformationReceivedContext : BaseOpenIdConnectContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext.User
    
        
        :rtype: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
            public JObject User
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext.UserInformationReceivedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
            public UserInformationReceivedContext(HttpContext context, OpenIdConnectOptions options)
    

