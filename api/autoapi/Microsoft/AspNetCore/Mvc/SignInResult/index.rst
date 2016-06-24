

SignInResult Class
==================






An :any:`Microsoft.AspNetCore.Mvc.ActionResult` that on execution invokes :dn:meth:`AuthenticationManager.SignInAsync`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.SignInResult`








Syntax
------

.. code-block:: csharp

    public class SignInResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.SignInResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.SignInResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.SignInResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SignInResult.SignInResult(System.String, System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.SignInResult` with the
        specified authentication scheme.
    
        
    
        
        :param authenticationScheme: The authentication scheme to use when signing in the user.
        
        :type authenticationScheme: System.String
    
        
        :param principal: The claims principal containing the user claims.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public SignInResult(string authenticationScheme, ClaimsPrincipal principal)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SignInResult.SignInResult(System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.SignInResult` with the
        specified authentication scheme and <em>properties</em>.
    
        
    
        
        :param authenticationScheme: The authentication schemes to use when signing in the user.
        
        :type authenticationScheme: System.String
    
        
        :param principal: The claims principal containing the user claims.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the sign-in operation.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public SignInResult(string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.SignInResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.SignInResult.AuthenticationScheme
    
        
    
        
        Gets or sets the authentication scheme that is used to perform the sign-in operation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.SignInResult.Principal
    
        
    
        
        Gets or sets the :any:`System.Security.Claims.ClaimsPrincipal` containing the user claims.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.SignInResult.Properties
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the sign-in operation.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.SignInResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.SignInResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

