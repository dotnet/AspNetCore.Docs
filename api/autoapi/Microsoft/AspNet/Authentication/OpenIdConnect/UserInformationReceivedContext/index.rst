

UserInformationReceivedContext Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext`








Syntax
------

.. code-block:: csharp

   public class UserInformationReceivedContext : BaseOpenIdConnectContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/UserInformationReceivedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext.UserInformationReceivedContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public UserInformationReceivedContext(HttpContext context, OpenIdConnectOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext.User
    
        
        :rtype: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
           public JObject User { get; set; }
    

