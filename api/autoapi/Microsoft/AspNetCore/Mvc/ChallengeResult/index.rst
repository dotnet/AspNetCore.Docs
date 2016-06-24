

ChallengeResult Class
=====================






An :any:`Microsoft.AspNetCore.Mvc.ActionResult` that on execution invokes :dn:meth:`AuthenticationManager.ChallengeAsync`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ChallengeResult`








Syntax
------

.. code-block:: csharp

    public class ChallengeResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ChallengeResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ChallengeResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ChallengeResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ChallengeResult.ChallengeResult()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ChallengeResult`\.
    
        
    
        
        .. code-block:: csharp
    
            public ChallengeResult()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ChallengeResult.ChallengeResult(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the
        specified <em>properties</em>.
    
        
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
                challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public ChallengeResult(AuthenticationProperties properties)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ChallengeResult.ChallengeResult(System.Collections.Generic.IList<System.String>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the
        specified authentication schemes.
    
        
    
        
        :param authenticationSchemes: The authentication schemes to challenge.
        
        :type authenticationSchemes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ChallengeResult(IList<string> authenticationSchemes)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ChallengeResult.ChallengeResult(System.Collections.Generic.IList<System.String>, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the
        specified authentication schemes and <em>properties</em>.
    
        
    
        
        :param authenticationSchemes: The authentication scheme to challenge.
        
        :type authenticationSchemes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
                challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public ChallengeResult(IList<string> authenticationSchemes, AuthenticationProperties properties)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ChallengeResult.ChallengeResult(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the
        specified authentication scheme.
    
        
    
        
        :param authenticationScheme: The authentication scheme to challenge.
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
            public ChallengeResult(string authenticationScheme)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ChallengeResult.ChallengeResult(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the
        specified authentication scheme and <em>properties</em>.
    
        
    
        
        :param authenticationScheme: The authentication schemes to challenge.
        
        :type authenticationScheme: System.String
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
                challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public ChallengeResult(string authenticationScheme, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ChallengeResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ChallengeResult.AuthenticationSchemes
    
        
    
        
        Gets or sets the authentication schemes that are challenged.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ChallengeResult.Properties
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication challenge.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ChallengeResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ChallengeResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

