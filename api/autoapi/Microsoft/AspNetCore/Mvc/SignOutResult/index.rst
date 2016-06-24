

SignOutResult Class
===================






An :any:`Microsoft.AspNetCore.Mvc.ActionResult` that on execution invokes :dn:meth:`AuthenticationManager.SignOutAsync`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.SignOutResult`








Syntax
------

.. code-block:: csharp

    public class SignOutResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.SignOutResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.SignOutResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.SignOutResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SignOutResult.SignOutResult(System.Collections.Generic.IList<System.String>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.SignOutResult` with the
        specified authentication schemes.
    
        
    
        
        :param authenticationSchemes: The authentication schemes to use when signing out the user.
        
        :type authenticationSchemes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public SignOutResult(IList<string> authenticationSchemes)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SignOutResult.SignOutResult(System.Collections.Generic.IList<System.String>, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.SignOutResult` with the
        specified authentication schemes and <em>properties</em>.
    
        
    
        
        :param authenticationSchemes: The authentication scheme to use when signing out the user.
        
        :type authenticationSchemes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the sign-out operation.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public SignOutResult(IList<string> authenticationSchemes, AuthenticationProperties properties)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SignOutResult.SignOutResult(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.SignOutResult` with the
        specified authentication scheme.
    
        
    
        
        :param authenticationScheme: The authentication scheme to use when signing out the user.
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
            public SignOutResult(string authenticationScheme)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SignOutResult.SignOutResult(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.SignOutResult` with the
        specified authentication scheme and <em>properties</em>.
    
        
    
        
        :param authenticationScheme: The authentication schemes to use when signing out the user.
        
        :type authenticationScheme: System.String
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the sign-out operation.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public SignOutResult(string authenticationScheme, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.SignOutResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.SignOutResult.AuthenticationSchemes
    
        
    
        
        Gets or sets the authentication schemes that are challenged.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.SignOutResult.Properties
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the sign-out operation.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.SignOutResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.SignOutResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

