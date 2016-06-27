

AuthenticationTokenExtensions Class
===================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions`








Syntax
------

.. code-block:: csharp

    public class AuthenticationTokenExtensions








.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.GetTokenAsync(Microsoft.AspNetCore.Http.Authentication.AuthenticationManager, System.String)
    
        
    
        
        :type manager: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    
        
        :type tokenName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static Task<string> GetTokenAsync(this AuthenticationManager manager, string tokenName)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.GetTokenAsync(Microsoft.AspNetCore.Http.Authentication.AuthenticationManager, System.String, System.String)
    
        
    
        
        :type manager: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    
        
        :type signInScheme: System.String
    
        
        :type tokenName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static Task<string> GetTokenAsync(this AuthenticationManager manager, string signInScheme, string tokenName)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.GetTokenValue(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :type tokenName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetTokenValue(this AuthenticationProperties properties, string tokenName)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.GetTokens(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authentication.AuthenticationToken<Microsoft.AspNetCore.Authentication.AuthenticationToken>}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<AuthenticationToken> GetTokens(this AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.StoreTokens(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authentication.AuthenticationToken>)
    
        
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :type tokens: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authentication.AuthenticationToken<Microsoft.AspNetCore.Authentication.AuthenticationToken>}
    
        
        .. code-block:: csharp
    
            public static void StoreTokens(this AuthenticationProperties properties, IEnumerable<AuthenticationToken> tokens)
    

