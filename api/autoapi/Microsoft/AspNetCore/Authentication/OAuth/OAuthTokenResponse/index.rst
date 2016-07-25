

OAuthTokenResponse Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OAuth`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse`








Syntax
------

.. code-block:: csharp

    public class OAuthTokenResponse








.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.AccessToken
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AccessToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.Error
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Error { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.ExpiresIn
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExpiresIn { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.RefreshToken
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RefreshToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.Response
    
        
        :rtype: Newtonsoft.Json.Linq.JObject
    
        
        .. code-block:: csharp
    
            public JObject Response { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.TokenType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TokenType { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.Failed(System.Exception)
    
        
    
        
        :type error: System.Exception
        :rtype: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    
        
        .. code-block:: csharp
    
            public static OAuthTokenResponse Failed(Exception error)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse.Success(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        :type response: Newtonsoft.Json.Linq.JObject
        :rtype: Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse
    
        
        .. code-block:: csharp
    
            public static OAuthTokenResponse Success(JObject response)
    

