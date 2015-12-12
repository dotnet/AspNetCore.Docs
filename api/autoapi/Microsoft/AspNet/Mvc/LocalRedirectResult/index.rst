

LocalRedirectResult Class
=========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ActionResult` that returns a redirect to the supplied local URL.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.LocalRedirectResult`








Syntax
------

.. code-block:: csharp

   public class LocalRedirectResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/LocalRedirectResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.LocalRedirectResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.LocalRedirectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.LocalRedirectResult.LocalRedirectResult(System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.LocalRedirectResult` class with the values
        provided.
    
        
        
        
        :param localUrl: The local URL to redirect to.
        
        :type localUrl: System.String
    
        
        .. code-block:: csharp
    
           public LocalRedirectResult(string localUrl)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.LocalRedirectResult.LocalRedirectResult(System.String, System.Boolean)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.LocalRedirectResult` class with the values
        provided.
    
        
        
        
        :type localUrl: System.String
        
        
        :param permanent: Specifies whether the redirect should be permanent (301) or temporary (302).
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
           public LocalRedirectResult(string localUrl, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.LocalRedirectResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.LocalRedirectResult.ExecuteResult(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.LocalRedirectResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.LocalRedirectResult.Permanent
    
        
    
        Gets or sets the value that specifies that the redirect should be permanent if true or temporary if false.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Permanent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.LocalRedirectResult.Url
    
        
    
        Gets or sets the local URL to redirect to.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Url { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.LocalRedirectResult.UrlHelper
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.IUrlHelper` for this result.
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper UrlHelper { get; set; }
    

