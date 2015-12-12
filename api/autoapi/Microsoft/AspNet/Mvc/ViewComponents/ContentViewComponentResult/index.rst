

ContentViewComponentResult Class
================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.IViewComponentResult` which writes text when executed.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult`








Syntax
------

.. code-block:: csharp

   public class ContentViewComponentResult : IViewComponentResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/ContentViewComponentResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.ContentViewComponentResult(Microsoft.AspNet.Mvc.Rendering.HtmlString)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult`\.
    
        
        
        
        :param encodedContent: Content to write. The content is treated as already HTML encoded, and no further encoding
            will be performed.
        
        :type encodedContent: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           public ContentViewComponentResult(HtmlString encodedContent)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.ContentViewComponentResult(System.String)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult`\.
    
        
        
        
        :param content: Content to write. The content be HTML encoded when output.
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
           public ContentViewComponentResult(string content)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.Execute(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Writes the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.EncodedContent`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           public void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.ExecuteAsync(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Writes the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.EncodedContent`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A completed <see cref="T:System.Threading.Tasks.Task" />.
    
        
        .. code-block:: csharp
    
           public Task ExecuteAsync(ViewComponentContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.Content
    
        
    
        Gets the content.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Content { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult.EncodedContent
    
        
    
        Gets the encoded content.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           public HtmlString EncodedContent { get; }
    

