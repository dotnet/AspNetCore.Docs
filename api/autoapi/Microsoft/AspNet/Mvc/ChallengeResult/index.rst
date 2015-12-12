

ChallengeResult Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ChallengeResult`








Syntax
------

.. code-block:: csharp

   public class ChallengeResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ChallengeResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ChallengeResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ChallengeResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ChallengeResult.ChallengeResult()
    
        
    
        
        .. code-block:: csharp
    
           public ChallengeResult()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ChallengeResult.ChallengeResult(Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public ChallengeResult(AuthenticationProperties properties)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ChallengeResult.ChallengeResult(System.Collections.Generic.IList<System.String>)
    
        
        
        
        :type authenticationSchemes: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public ChallengeResult(IList<string> authenticationSchemes)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ChallengeResult.ChallengeResult(System.Collections.Generic.IList<System.String>, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationSchemes: System.Collections.Generic.IList{System.String}
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public ChallengeResult(IList<string> authenticationSchemes, AuthenticationProperties properties)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ChallengeResult.ChallengeResult(System.String)
    
        
        
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
           public ChallengeResult(string authenticationScheme)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ChallengeResult.ChallengeResult(System.String, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public ChallengeResult(string authenticationScheme, AuthenticationProperties properties)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ChallengeResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ChallengeResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ChallengeResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ChallengeResult.AuthenticationSchemes
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> AuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ChallengeResult.Properties
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; set; }
    

