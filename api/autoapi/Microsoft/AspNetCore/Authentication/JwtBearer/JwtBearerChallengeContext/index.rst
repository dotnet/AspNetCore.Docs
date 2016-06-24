

JwtBearerChallengeContext Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.JwtBearer`
Assemblies
    * Microsoft.AspNetCore.Authentication.JwtBearer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.BaseJwtBearerContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext`








Syntax
------

.. code-block:: csharp

    public class JwtBearerChallengeContext : BaseJwtBearerContext








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.JwtBearerChallengeContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.JwtBearerOptions, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.JwtBearerOptions
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public JwtBearerChallengeContext(HttpContext context, JwtBearerOptions options, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.AuthenticateFailure
    
        
    
        
        Any failures encountered during the authentication process.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception AuthenticateFailure { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.Error
    
        
    
        
        Gets or sets the "error" value returned to the caller as part
        of the WWW-Authenticate header. This property may be null when 
        :dn:prop:`Microsoft.AspNetCore.Builder.JwtBearerOptions.IncludeErrorDetails` is set to <code>false</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Error { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.ErrorDescription
    
        
    
        
        Gets or sets the "error_description" value returned to the caller as part
        of the WWW-Authenticate header. This property may be null when 
        :dn:prop:`Microsoft.AspNetCore.Builder.JwtBearerOptions.IncludeErrorDetails` is set to <code>false</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ErrorDescription { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.ErrorUri
    
        
    
        
        Gets or sets the "error_uri" value returned to the caller as part of the
        WWW-Authenticate header. This property is always null unless explicitly set.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ErrorUri { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerChallengeContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; }
    

