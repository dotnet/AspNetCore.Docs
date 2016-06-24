

LocalRedirectResult Class
=========================






An :any:`Microsoft.AspNetCore.Mvc.ActionResult` that returns a redirect to the supplied local URL.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.LocalRedirectResult`








Syntax
------

.. code-block:: csharp

    public class LocalRedirectResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.LocalRedirectResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.LocalRedirectResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.LocalRedirectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.LocalRedirectResult.LocalRedirectResult(System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.LocalRedirectResult` class with the values
        provided.
    
        
    
        
        :param localUrl: The local URL to redirect to.
        
        :type localUrl: System.String
    
        
        .. code-block:: csharp
    
            public LocalRedirectResult(string localUrl)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.LocalRedirectResult.LocalRedirectResult(System.String, System.Boolean)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.LocalRedirectResult` class with the values
        provided.
    
        
    
        
        :param localUrl: The local URL to redirect to.
        
        :type localUrl: System.String
    
        
        :param permanent: Specifies whether the redirect should be permanent (301) or temporary (302).
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
            public LocalRedirectResult(string localUrl, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.LocalRedirectResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.LocalRedirectResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.LocalRedirectResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.LocalRedirectResult.Permanent
    
        
    
        
        Gets or sets the value that specifies that the redirect should be permanent if true or temporary if false.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Permanent { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.LocalRedirectResult.Url
    
        
    
        
        Gets or sets the local URL to redirect to.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Url { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.LocalRedirectResult.UrlHelper
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` for this result.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper UrlHelper { get; set; }
    

