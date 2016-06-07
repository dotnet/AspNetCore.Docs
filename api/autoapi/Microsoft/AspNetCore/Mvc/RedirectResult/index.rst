

RedirectResult Class
====================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.RedirectResult`








Syntax
------

.. code-block:: csharp

    public class RedirectResult : ActionResult, IKeepTempDataResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectResult.Permanent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Permanent
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectResult.Url
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Url
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectResult.UrlHelper
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper UrlHelper
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RedirectResult.RedirectResult(System.String)
    
        
    
        
        :type url: System.String
    
        
        .. code-block:: csharp
    
            public RedirectResult(string url)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RedirectResult.RedirectResult(System.String, System.Boolean)
    
        
    
        
        :type url: System.String
    
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
            public RedirectResult(string url, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RedirectResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void ExecuteResult(ActionContext context)
    

