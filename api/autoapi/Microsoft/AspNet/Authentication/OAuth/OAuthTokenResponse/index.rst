

OAuthTokenResponse Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse`








Syntax
------

.. code-block:: csharp

   public class OAuthTokenResponse





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OAuth/OAuthTokenResponse.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse.OAuthTokenResponse(Newtonsoft.Json.Linq.JObject)
    
        
        
        
        :type response: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
           public OAuthTokenResponse(JObject response)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse.AccessToken
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AccessToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse.ExpiresIn
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExpiresIn { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse.RefreshToken
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RefreshToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse.Response
    
        
        :rtype: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
           public JObject Response { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse.TokenType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TokenType { get; set; }
    

