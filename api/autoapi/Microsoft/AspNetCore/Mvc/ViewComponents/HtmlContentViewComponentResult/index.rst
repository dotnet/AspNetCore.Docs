

HtmlContentViewComponentResult Class
====================================






An :any:`Microsoft.AspNetCore.Mvc.IViewComponentResult` which writes an :any:`Microsoft.AspNetCore.Html.IHtmlContent` when executed.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult`








Syntax
------

.. code-block:: csharp

    public class HtmlContentViewComponentResult : IViewComponentResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult.HtmlContentViewComponentResult(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult`\.
    
        
    
        
        :type encodedContent: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public HtmlContentViewComponentResult(IHtmlContent encodedContent)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult.EncodedContent
    
        
    
        
        Gets the encoded content.
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent EncodedContent { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult.Execute(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Writes the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult.EncodedContent`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
            public void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult.ExecuteAsync(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Writes the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult.EncodedContent`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A completed :any:`System.Threading.Tasks.Task`\.
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ViewComponentContext context)
    

