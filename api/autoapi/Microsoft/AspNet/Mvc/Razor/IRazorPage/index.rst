

IRazorPage Interface
====================



.. contents:: 
   :local:



Summary
-------

Represents properties and methods that are used by :any:`Microsoft.AspNet.Mvc.Razor.RazorView` for execution.











Syntax
------

.. code-block:: csharp

   public interface IRazorPage





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/IRazorPage.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorPage

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IRazorPage.EnsureRenderedBodyOrSections()
    
        
    
        Verifies that all sections defined in :dn:prop:`Microsoft.AspNet.Mvc.Razor.IRazorPage.PreviousSectionWriters` were rendered, or
        the body was rendered if no sections were defined.
    
        
    
        
        .. code-block:: csharp
    
           void EnsureRenderedBodyOrSections()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IRazorPage.ExecuteAsync()
    
        
    
        Renders the page and writes the output to the :dn:prop:`Microsoft.AspNet.Mvc.Rendering.ViewContext.Writer`\.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: A task representing the result of executing the page.
    
        
        .. code-block:: csharp
    
           Task ExecuteAsync()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.IsLayoutBeingRendered
    
        
    
        Gets or sets a flag that determines if the layout of this page is being rendered.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsLayoutBeingRendered { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.IsPartial
    
        
    
        Gets or sets a value that determines if the current instance of :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` is being executed
        from a partial view.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsPartial { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.Layout
    
        
    
        Gets or sets the path of a layout page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Layout { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.PageExecutionContext
    
        
    
        Gets or sets a :any:`Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext` instance used to instrument the page execution.
    
        
        :rtype: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext
    
        
        .. code-block:: csharp
    
           IPageExecutionContext PageExecutionContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.Path
    
        
    
        Gets the application base relative path to the page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.PreviousSectionWriters
    
        
    
        Gets or sets the sections that can be rendered by this page.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Mvc.Razor.RenderAsyncDelegate}
    
        
        .. code-block:: csharp
    
           IDictionary<string, RenderAsyncDelegate> PreviousSectionWriters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.RenderBodyDelegateAsync
    
        
    
        Gets or sets the action invoked to render the body.
    
        
        :rtype: System.Func{System.IO.TextWriter,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           Func<TextWriter, Task> RenderBodyDelegateAsync { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.SectionWriters
    
        
    
        Gets the sections that are defined by this page.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Mvc.Razor.RenderAsyncDelegate}
    
        
        .. code-block:: csharp
    
           IDictionary<string, RenderAsyncDelegate> SectionWriters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IRazorPage.ViewContext
    
        
    
        Gets or sets the view context of the renderign view.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           ViewContext ViewContext { get; set; }
    

