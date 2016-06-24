

SignInContext Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features.Authentication`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.Authentication.SignInContext`








Syntax
------

.. code-block:: csharp

    public class SignInContext








.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext.SignInContext(System.String, System.Security.Claims.ClaimsPrincipal, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :type properties: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public SignInContext(string authenticationScheme, ClaimsPrincipal principal, IDictionary<string, string> properties)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext.Accept()
    
        
    
        
        .. code-block:: csharp
    
            public void Accept()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext.Accepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accepted { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext.Principal
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.SignInContext.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Properties { get; }
    

