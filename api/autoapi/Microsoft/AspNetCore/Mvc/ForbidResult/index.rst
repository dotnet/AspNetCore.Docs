

ForbidResult Class
==================






An :any:`Microsoft.AspNetCore.Mvc.ActionResult` that on execution invokes :dn:meth:`AuthenticationManager.ForbidAsync`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ForbidResult`








Syntax
------

.. code-block:: csharp

    public class ForbidResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ForbidResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ForbidResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ForbidResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ForbidResult.AuthenticationSchemes
    
        
    
        
        Gets or sets the authentication schemes that are challenged.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AuthenticationSchemes
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ForbidResult.Properties
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication challenge.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ForbidResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ForbidResult.ForbidResult()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ForbidResult`\.
    
        
    
        
        .. code-block:: csharp
    
            public ForbidResult()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ForbidResult.ForbidResult(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the
        specified <em>properties</em>.
    
        
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
            challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public ForbidResult(AuthenticationProperties properties)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ForbidResult.ForbidResult(System.Collections.Generic.IList<System.String>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the
        specified authentication schemes.
    
        
    
        
        :param authenticationSchemes: The authentication schemes to challenge.
        
        :type authenticationSchemes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ForbidResult(IList<string> authenticationSchemes)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ForbidResult.ForbidResult(System.Collections.Generic.IList<System.String>, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the
        specified authentication schemes and <em>properties</em>.
    
        
    
        
        :param authenticationSchemes: The authentication scheme to challenge.
        
        :type authenticationSchemes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
            challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public ForbidResult(IList<string> authenticationSchemes, AuthenticationProperties properties)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ForbidResult.ForbidResult(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the
        specified authentication scheme.
    
        
    
        
        :param authenticationScheme: The authentication scheme to challenge.
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
            public ForbidResult(string authenticationScheme)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ForbidResult.ForbidResult(System.String, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the
        specified authentication scheme and <em>properties</em>.
    
        
    
        
        :param authenticationScheme: The authentication schemes to challenge.
        
        :type authenticationScheme: System.String
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
            challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public ForbidResult(string authenticationScheme, AuthenticationProperties properties)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ForbidResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ForbidResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

