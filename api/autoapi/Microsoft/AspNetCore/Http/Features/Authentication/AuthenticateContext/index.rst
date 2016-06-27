

AuthenticateContext Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext`








Syntax
------

.. code-block:: csharp

    public class AuthenticateContext








.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.AuthenticateContext(System.String)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
            public AuthenticateContext(string authenticationScheme)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.Accepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accepted { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.Description
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> Description { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.Error
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Error { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.Principal
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Properties { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.Authenticated(System.Security.Claims.ClaimsPrincipal, System.Collections.Generic.IDictionary<System.String, System.String>, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :type properties: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        :type description: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public virtual void Authenticated(ClaimsPrincipal principal, IDictionary<string, string> properties, IDictionary<string, object> description)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.Failed(System.Exception)
    
        
    
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual void Failed(Exception error)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext.NotAuthenticated()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void NotAuthenticated()
    

