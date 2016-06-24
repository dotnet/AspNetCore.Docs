

ContentViewComponentResult Class
================================






An :any:`Microsoft.AspNetCore.Mvc.IViewComponentResult` which writes text when executed.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult`








Syntax
------

.. code-block:: csharp

    public class ContentViewComponentResult : IViewComponentResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult.ContentViewComponentResult(System.String)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult`\.
    
        
    
        
        :param content: Content to write. The content will be HTML encoded when written.
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
            public ContentViewComponentResult(string content)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult.Content
    
        
    
        
        Gets the content.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Content { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult.Execute(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Encodes and writes the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult.Content`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
            public void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult.ExecuteAsync(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Encodes and writes the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult.Content`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A completed :any:`System.Threading.Tasks.Task`\.
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ViewComponentContext context)
    

