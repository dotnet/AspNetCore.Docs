

RedirectResult Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.RedirectResult`








Syntax
------

.. code-block:: csharp

   public class RedirectResult : ActionResult, IKeepTempDataResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/RedirectResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.RedirectResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RedirectResult.RedirectResult(System.String)
    
        
        
        
        :type url: System.String
    
        
        .. code-block:: csharp
    
           public RedirectResult(string url)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RedirectResult.RedirectResult(System.String, System.Boolean)
    
        
        
        
        :type url: System.String
        
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
           public RedirectResult(string url, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.RedirectResult.ExecuteResult(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectResult.Permanent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Permanent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectResult.Url
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Url { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectResult.UrlHelper
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper UrlHelper { get; set; }
    

